using Microsoft.VisualStudio.TestTools.UnitTesting;
using Itesm.BasicAI.KMeans;
using System;

namespace Itesm.BasicAI.Test
{
	[TestClass]
	public class ClusterTest
	{

		private static readonly Row[] sample2d = {
			new(2f,4f),
			new(3f,6f),
			new(6f,5f),
			new(3f,4f),
			new(8f,9f),
			new(8f,5f),
			new(2f,3f),
			new(7f,5f),
			new(6f,7f),
			new(8f,8f)
		};

		// Using the IRIS dataset (from wikipedia)
		private static readonly Row[] iris = {
			new(5.1f, 3.5f, 1.4f, 0.2f),
			new(4.9f, 3.0f, 1.4f, 0.2f),
			new(4.7f, 3.2f, 1.3f, 0.2f),
			new(4.6f, 3.1f, 1.5f, 0.2f),
			new(5.0f, 3.6f, 1.4f, 0.2f),
			new(5.4f, 3.9f, 1.7f, 0.4f),
			new(4.6f, 3.4f, 1.4f, 0.3f),
			new(5.0f, 3.4f, 1.5f, 0.2f),
			new(4.4f, 2.9f, 1.4f, 0.2f),
			new(4.9f, 3.1f, 1.5f, 0.1f),
			new(5.4f, 3.7f, 1.5f, 0.2f),
			new(4.8f, 3.4f, 1.6f, 0.2f),
			new(4.8f, 3.0f, 1.4f, 0.1f),
			new(4.3f, 3.0f, 1.1f, 0.1f),
			new(5.8f, 4.0f, 1.2f, 0.2f),
			new(5.7f, 4.4f, 1.5f, 0.4f),
			new(5.4f, 3.9f, 1.3f, 0.4f),
			new(5.1f, 3.5f, 1.4f, 0.3f),
			new(5.7f, 3.8f, 1.7f, 0.3f),
			new(5.1f, 3.8f, 1.5f, 0.3f),
			new(5.4f, 3.4f, 1.7f, 0.2f),
			new(5.1f, 3.7f, 1.5f, 0.4f),
			new(4.6f, 3.6f, 1.0f, 0.2f),
			new(5.1f, 3.3f, 1.7f, 0.5f),
			new(4.8f, 3.4f, 1.9f, 0.2f),
			new(5.0f, 3.0f, 1.6f, 0.2f),
			new(5.0f, 3.4f, 1.6f, 0.4f),
			new(5.2f, 3.5f, 1.5f, 0.2f),
			new(5.2f, 3.4f, 1.4f, 0.2f),
			new(4.7f, 3.2f, 1.6f, 0.2f),
			new(4.8f, 3.1f, 1.6f, 0.2f),
			new(5.4f, 3.4f, 1.5f, 0.4f),
			new(5.2f, 4.1f, 1.5f, 0.1f),
			new(5.5f, 4.2f, 1.4f, 0.2f),
			new(4.9f, 3.1f, 1.5f, 0.2f),
			new(5.0f, 3.2f, 1.2f, 0.2f),
			new(5.5f, 3.5f, 1.3f, 0.2f),
			new(4.9f, 3.6f, 1.4f, 0.1f),
			new(4.4f, 3.0f, 1.3f, 0.2f),
			new(5.1f, 3.4f, 1.5f, 0.2f),
			new(5.0f, 3.5f, 1.3f, 0.3f),
			new(4.5f, 2.3f, 1.3f, 0.3f),
			new(4.4f, 3.2f, 1.3f, 0.2f),
			new(5.0f, 3.5f, 1.6f, 0.6f),
			new(5.1f, 3.8f, 1.9f, 0.4f),
			new(4.8f, 3.0f, 1.4f, 0.3f),
			new(5.1f, 3.8f, 1.6f, 0.2f),
			new(4.6f, 3.2f, 1.4f, 0.2f),
			new(5.3f, 3.7f, 1.5f, 0.2f),
			new(5.0f, 3.3f, 1.4f, 0.2f),
			new(7.0f, 3.2f, 4.7f, 1.4f),
			new(6.4f, 3.2f, 4.5f, 1.5f),
			new(6.9f, 3.1f, 4.9f, 1.5f),
			new(5.5f, 2.3f, 4.0f, 1.3f),
			new(6.5f, 2.8f, 4.6f, 1.5f),
			new(5.7f, 2.8f, 4.5f, 1.3f),
			new(6.3f, 3.3f, 4.7f, 1.6f),
			new(4.9f, 2.4f, 3.3f, 1.0f),
			new(6.6f, 2.9f, 4.6f, 1.3f),
			new(5.2f, 2.7f, 3.9f, 1.4f),
			new(5.0f, 2.0f, 3.5f, 1.0f),
			new(5.9f, 3.0f, 4.2f, 1.5f),
			new(6.0f, 2.2f, 4.0f, 1.0f),
			new(6.1f, 2.9f, 4.7f, 1.4f),
			new(5.6f, 2.9f, 3.6f, 1.3f),
			new(6.7f, 3.1f, 4.4f, 1.4f),
			new(5.6f, 3.0f, 4.5f, 1.5f),
			new(5.8f, 2.7f, 4.1f, 1.0f),
			new(6.2f, 2.2f, 4.5f, 1.5f),
			new(5.6f, 2.5f, 3.9f, 1.1f),
			new(5.9f, 3.2f, 4.8f, 1.8f),
			new(6.1f, 2.8f, 4.0f, 1.3f),
			new(6.3f, 2.5f, 4.9f, 1.5f),
			new(6.1f, 2.8f, 4.7f, 1.2f),
			new(6.4f, 2.9f, 4.3f, 1.3f),
			new(6.6f, 3.0f, 4.4f, 1.4f),
			new(6.8f, 2.8f, 4.8f, 1.4f),
			new(6.7f, 3.0f, 5.0f, 1.7f),
			new(6.0f, 2.9f, 4.5f, 1.5f),
			new(5.7f, 2.6f, 3.5f, 1.0f),
			new(5.5f, 2.4f, 3.8f, 1.1f),
			new(5.5f, 2.4f, 3.7f, 1.0f),
			new(5.8f, 2.7f, 3.9f, 1.2f),
			new(6.0f, 2.7f, 5.1f, 1.6f),
			new(5.4f, 3.0f, 4.5f, 1.5f),
			new(6.0f, 3.4f, 4.5f, 1.6f),
			new(6.7f, 3.1f, 4.7f, 1.5f),
			new(6.3f, 2.3f, 4.4f, 1.3f),
			new(5.6f, 3.0f, 4.1f, 1.3f),
			new(5.5f, 2.5f, 4.0f, 1.3f),
			new(5.5f, 2.6f, 4.4f, 1.2f),
			new(6.1f, 3.0f, 4.6f, 1.4f),
			new(5.8f, 2.6f, 4.0f, 1.2f),
			new(5.0f, 2.3f, 3.3f, 1.0f),
			new(5.6f, 2.7f, 4.2f, 1.3f),
			new(5.7f, 3.0f, 4.2f, 1.2f),
			new(5.7f, 2.9f, 4.2f, 1.3f),
			new(6.2f, 2.9f, 4.3f, 1.3f),
			new(5.1f, 2.5f, 3.0f, 1.1f),
			new(5.7f, 2.8f, 4.1f, 1.3f),
			new(6.3f, 3.3f, 6.0f, 2.5f),
			new(5.8f, 2.7f, 5.1f, 1.9f),
			new(7.1f, 3.0f, 5.9f, 2.1f),
			new(6.3f, 2.9f, 5.6f, 1.8f),
			new(6.5f, 3.0f, 5.8f, 2.2f),
			new(7.6f, 3.0f, 6.6f, 2.1f),
			new(4.9f, 2.5f, 4.5f, 1.7f),
			new(7.3f, 2.9f, 6.3f, 1.8f),
			new(6.7f, 2.5f, 5.8f, 1.8f),
			new(7.2f, 3.6f, 6.1f, 2.5f),
			new(6.5f, 3.2f, 5.1f, 2.0f),
			new(6.4f, 2.7f, 5.3f, 1.9f),
			new(6.8f, 3.0f, 5.5f, 2.1f),
			new(5.7f, 2.5f, 5.0f, 2.0f),
			new(5.8f, 2.8f, 5.1f, 2.4f),
			new(6.4f, 3.2f, 5.3f, 2.3f),
			new(6.5f, 3.0f, 5.5f, 1.8f),
			new(7.7f, 3.8f, 6.7f, 2.2f),
			new(7.7f, 2.6f, 6.9f, 2.3f),
			new(6.0f, 2.2f, 5.0f, 1.5f),
			new(6.9f, 3.2f, 5.7f, 2.3f),
			new(5.6f, 2.8f, 4.9f, 2.0f),
			new(7.7f, 2.8f, 6.7f, 2.0f),
			new(6.3f, 2.7f, 4.9f, 1.8f),
			new(6.7f, 3.3f, 5.7f, 2.1f),
			new(7.2f, 3.2f, 6.0f, 1.8f),
			new(6.2f, 2.8f, 4.8f, 1.8f),
			new(6.1f, 3.0f, 4.9f, 1.8f),
			new(6.4f, 2.8f, 5.6f, 2.1f),
			new(7.2f, 3.0f, 5.8f, 1.6f),
			new(7.4f, 2.8f, 6.1f, 1.9f),
			new(7.9f, 3.8f, 6.4f, 2.0f),
			new(6.4f, 2.8f, 5.6f, 2.2f),
			new(6.3f, 2.8f, 5.1f, 1.5f),
			new(6.1f, 2.6f, 5.6f, 1.4f),
			new(7.7f, 3.0f, 6.1f, 2.3f),
			new(6.3f, 3.4f, 5.6f, 2.4f),
			new(6.4f, 3.1f, 5.5f, 1.8f),
			new(6.0f, 3.0f, 4.8f, 1.8f),
			new(6.9f, 3.1f, 5.4f, 2.1f),
			new(6.7f, 3.1f, 5.6f, 2.4f),
			new(6.9f, 3.1f, 5.1f, 2.3f),
			new(5.8f, 2.7f, 5.1f, 1.9f),
			new(6.8f, 3.2f, 5.9f, 2.3f),
			new(6.7f, 3.3f, 5.7f, 2.5f),
			new(6.7f, 3.0f, 5.2f, 2.3f),
			new(6.3f, 2.5f, 5.0f, 1.9f),
			new(6.5f, 3.0f, 5.2f, 2.0f),
			new(6.2f, 3.4f, 5.4f, 2.3f),
			new(5.9f, 3.0f, 5.1f, 1.8f),
		};

		
		private const int expectedLeft = 4;
		private const int expectedRight = 6;

		// I am using the same seed for every test to make them
		// Deterministic
		private const int Seed = 5;

		private const int Rounds = 25;

		[TestMethod]
		public void Test2d()
		{
			// Create the cluster

			var cluster = new Cluster(2, sample2d, seed: Seed);

			// Test more rounds to see if it converges
			cluster.Classify(Rounds);

			/*
			Given the initial centers are choosen AT RANDOM
			we might have different results between tests, and
			the centers MIGHT be different from test to test.

			However, I can check if the centroids are in some
			approximate area by comparing their x and y coordinates

			We now one centroid is before 4, and the other one
			is after 6
			*/

			var c1 = cluster.Centers[0];
			float c1x = c1.Data[0];

			var c2 = cluster.Centers[1];
			float c2x = c2.Data[0];

			Assert.IsTrue(c1x < 5f);
			Assert.IsTrue(c2x > 5f);

			/*
			Test the expected labelings for the data points

			We can check point by point the expected labelings
			and allow for a configurable level of accuracy
			*/

			// Because the selection is random,
			// we really dont know if the group one
			// will be the one on the left or right

			int g1 = 0, g2 = 0;

			foreach(var r in cluster.Vectors) {
				if(r.Class == 0) g1++;
				else g2++;
			}

			int left = Math.Min(g1, g2);

			int right = Math.Max(g1, g2);

			// Check there is only a diff of one
			Assert.IsTrue(Math.Abs(left - expectedLeft) <= 1);

			// Check only one wrong
			Assert.IsTrue(Math.Abs(right - expectedRight) <= 1);

			System.Console.WriteLine(cluster);

		}


		/*
			Iris test

			Test the clustering implementation by using a well known
			dataset with well knon labels.

			We will be using the IRIS dataset, 
			which has 3 flower species (K = 3), and
			each class has exactly 50 flowers, making it
			easier to test.


			We will define a 10% error tolerance. The test passes
			if the mislabeled flowers are less than 10%
		*/
		[TestMethod]
		public void TestIris()
		{
			// Create a cluster based on the IRIS dataset
			var cluster = new Cluster(3, iris, Seed);

			// Classify witha around 20 rounds

			// It failed with 25 tests, but not with 50 tests
			// This can be explained by a bad initialization,
			cluster.Classify(Rounds);

			/*
			We know for a fact there are eactly 50 in each class.
			That's because the iris set is ALREADY LABELED in real life,
			so we can just count how many are in each class for this test
			and then check how many incorrect ones are there
			*/

			int expected = 50;
			int incorrect = 0;


			// I am using the 'naive' kmeans instead of kmeans++
			// which has worse accuracy because of initialization
			int tolerance = 15; // 10% of the total

			// Check the clusters are the correct size
			foreach (var group in cluster.Groups)
			{
				// Check the diff between the expected value and
				// the actual value is bellow a certaince tolerance value

				// A group is a dictionary, so the array is in the value
				int groupCount = group.Value.Length;
				int absDiff = Math.Abs(groupCount - expected);

				incorrect += absDiff;

			}

			// Bug patch:
			/*
			Whenever something has an incorrect label, it gets 
			added TWICE because it is in a wrong place, and is also
			out of that place. So, the result should be divided
			by 2 to compensate this effect
			*/

			// Division
			incorrect >>= 1;

			Assert.IsTrue(incorrect <= tolerance);

		}

	}
}