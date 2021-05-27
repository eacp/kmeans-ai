using System.Linq;
using Itesm.BasicAI.KMeans;

namespace Itesm.BasicAI.Web
{   
    // A request containing the matrix and the dimentions
    public class ClusteringRequest
    {   
        // The array
        public float[,] Numbers {get; private set;}

        // The dimentions of the table
        public int Rows{get; private set;} 
        public int Cols{get; private set;}



        // Constructors
        public ClusteringRequest(int rows, int cols, string data)
        {
            Rows = rows;
            Cols = cols;

            Numbers = Deflatten(data, rows, cols);
        }


        /*
            Utility function to flatten an array separeted by commas

            Takes a string of floats separated by commas, and
            creates a matrix of float values according to the specified
            rows and collumns

            Notice it is a pure functional function
        */
        public static float[,] Deflatten(string commas, int rows, int cols) =>
            Make2d(
                // Split and map to parse
                commas.Split(',').Select( s => float.Parse(s) ).ToArray(),
                rows, cols
            );


        // CUDA Memories intensify
        private static T[,] Make2d<T>(T[] flattened, int rows, int cols)
        {
            T[,] twoDIm = new T[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    twoDIm[i, j] = flattened[i * cols + j];
                }
            }
            return twoDIm;
        }
        
    }

    // Maybe put here the response


    // Serializers to save network transit
    public class ClusteringResponse
    {
        public int[] Labels{get; private set;}

        public Row[] Centers{get; private set;}

        public ClusteringResponse(Cluster c)
        {
            // This assumes the classification is done
            Labels = c.Labels;
            Centers = c.Centers;
        }
    }
}