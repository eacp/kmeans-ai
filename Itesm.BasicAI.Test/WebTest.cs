using Itesm.BasicAI.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Itesm.BasicAI.Test
{
    [TestClass]
    public class WebTest
    {

        // Flattened version of the 2D array
        private const string SampleFlat = "2,4,3,6,6,5,3,4,8,9,8,5,2,3,7,5,6,7,8,8";

        private readonly float[,] ExpectedDeflatten = {
            {2f,4f},
			{3f,6f},
			{6f,5f},
			{3f,4f},
			{8f,9f},
			{8f,5f},
			{2f,3f},
			{7f,5f},
			{6f,7f},
			{8f,8f}
        };

        [TestMethod]
        public void TestDeserializeIris()
        {
            // Deflatten
            float[,] sampleData = ClusteringRequest.Deflatten(SampleFlat, 10, 2);

            for(int i = 0; i < 10; i++) {
                float expected1 = ExpectedDeflatten[i, 0];
                float expected2 = ExpectedDeflatten[i, 1];

                float got1 = sampleData[i, 0];
                float got2 = sampleData[i, 1];

                // Assert equal

                Assert.AreEqual(expected1, got1);
                Assert.AreEqual(expected2, got2);
            }

        }
    }
}