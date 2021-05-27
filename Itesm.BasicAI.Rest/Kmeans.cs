using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Itesm.BasicAI.KMeans;
using System.Text.Json;

namespace Itesm.BasicAI.Web
{
	public static class Kmeans
	{
		[Function("Kmeans")]
		public static HttpResponseData Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
			FunctionContext executionContext,

			string data, int rows, int cols, int k
		)
		{
			var logger = executionContext.GetLogger("Kmeans");
			logger.LogInformation("C# HTTP trigger function processed a request.");


			var response = req.CreateResponse();

			var request = new ClusteringRequest(rows, cols, data);

			var table = new Row[request.Rows];


			// Create a bunch of rows
			for(int i = 0; i < rows; i++) {
				// Create a container for the data of this row
				var rowData = new float[cols];

				// Iterate over each row and store it on the special array
				for(int j = 0; j < cols; j++){
					rowData[j] =request.Numbers[i,j];
				}

				table[i] = new Row(rowData);

			}

			// We can now create the cluster based on the constructed table

			var cluster = new Cluster(k, table);

			cluster.Classify(25);

			response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

			// Create a new response based on the classified data

			var clusterResp = new ClusteringResponse(cluster);

			var json = JsonSerializer.Serialize<ClusteringResponse>(clusterResp);

			response.WriteString(json);
			

			return response;
		}
	}

}
