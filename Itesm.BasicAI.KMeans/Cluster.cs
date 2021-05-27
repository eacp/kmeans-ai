using System.Linq;
using System.Collections.Generic;

namespace Itesm.BasicAI.KMeans
{
    public class Cluster {
        // The K in K means
        // IMMUTABLE
        public int K {get;}

        // How many features are we going to use
        private int features {get;}

        // The vectors inside
        public Row[] Vectors {get; private set;}

        // The centers of this cluster
        // They can be read from the outside, but NOT altered
        public Row[] Centers {get; private set;}

        private System.Random r{get;}

        // Util for sampling
        private T[] Sample<T>(T[] src, int samples) {
            var list = new T[samples];
            int n = src.Length;

            System.Array.Copy(src, list, samples);

            for(int j, i = 0; i < n; i++) {
                j = r.Next(i);

                if(j < samples) {
                    list[j] = src[i];
                }
            }

            return list;
        }


        // Constructor that also takes 
        public Cluster(int k, Row[] vecs, int seed = 0) {
            // Init K
            K = k;

            // Init the content of this cluster
            Vectors = vecs;

            // This entire lib ASSUMES all rows have the same cols
            features = vecs[0].Data.Length;

            

            // Allow for custom seeds for testability

            // If the seed is zero, then just use the default random,
            // otherwise use the given seed
            r = seed == 0 ? new System.Random() : new System.Random(seed);
        }

        // One round of the clasification
        private void Round() {
            // Create an array of lists, and we can add each center
            // to its appropiate category

            // One liner with a lambda and functional programming baby
            var buckets = Vectors.GroupBy((v) => v.IndexOfClosest(Centers));

            foreach (var bucket in buckets)
            {
                // Compute the average position of each part
                var avg = new float[features];

                // Iterate for each feature
                for (int i = 0; i < features; i++)
                {   
                    // Get the average of a single coulmn
                    avg[i] = bucket.Average( v => v.Data[i] );
                }

                // Now I have to do something with the centers

                Centers[bucket.Key] = new Row(avg);

                // I have to register the class

                foreach (var row in bucket)
                {
                    row.Class = bucket.Key;
                }
            }


        }

        // The groupings. Read only from outside
        public Dictionary<int, Row[]> Groups{get; private set;}

        public void Classify(int rounds = 10) {
            
            // Initialize the centers accordingly
            Centers = Sample(Vectors, K);

            for(int i = 0; i < rounds; i++) Round();

            // Make the groups
            Groups = Vectors
                .GroupBy( v => v.Class)
                .ToDictionary(g => g.Key, g => g.ToArray());
        }

        // Utility method to get ONLY the classes, ordered
        // Pure functional baby
        public int[] Labels{get =>  Vectors.Select( v => v.Class).ToArray();}

        
        
    }
}