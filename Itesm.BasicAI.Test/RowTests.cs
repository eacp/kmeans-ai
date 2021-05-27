using Microsoft.VisualStudio.TestTools.UnitTesting;
using Itesm.BasicAI.KMeans;

namespace Itesm.BasicAI.Test
{
    [TestClass]
    public class RowTests
    {
        [TestMethod]
        public void TestCalcDist()
        {
            // Two example rows
            var r1 = new Row(new float[] {1.0f, 2.0f, 3.0f});
            var r2 = new Row(new float[] {4.0f, 5.0f, 6.0f});

            // For this two points, the dist is known to be sq(27)
            float dist = r1.Dist(r2);
            float sq27 = System.MathF.Sqrt(27.0f);

            // Check the results
            Assert.AreEqual(sq27, dist);
        }

        [TestMethod]
        public void TestCalcSqDist()
        {
            // Two example rows
            var r1 = new Row(new float[] {1.0f, 2.0f, 3.0f});
            var r2 = new Row(new float[] {4.0f, 5.0f, 6.0f});

            float squareOfDist = r1.SquaredDist(r2);

            Assert.AreEqual(27.0f, squareOfDist);
        }

        [TestMethod]
        public void TestClosestIndex()
        {
            // Create 3 candidate centers. This represents
            // comparisson to fit in a class

            var centers = new Row[] {
                // Zero
                new Row(new float[]{0f, 0f, 0f}),

                // One that is VERY close
                new Row(new float[]{1.1f, 1.1f, 1f}),

                // Two others that are VERY far away

                new Row(new float[]{10f,20f,30f}),

                new Row(new float[]{100f,200f,300f}),

                new Row(new float[]{25f,50f, 100f}),
            };

            // The current row
            var r = new Row(new float[]{1f, 1f, 1f});

            // The closest one should be the index 1
            int closest = r.IndexOfClosest(centers);

            Assert.AreEqual(1, closest);
        }

        
    }
}
