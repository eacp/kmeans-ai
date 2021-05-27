using System;
using System.Linq;

namespace Itesm.BasicAI.KMeans
{
    public class Row {
        // The data to use. It will be IMMUTABLE
        public float[] Data {get;}

		// The found class for this element
		// Do not confuse with the keyword class

		// Ignore from json serialization to save network size
		[System.Text.Json.Serialization.JsonIgnore]
		public int Class {get; internal set;}

		// A constructor
		public Row(params float[] data) => Data = data;


		// Euclidean Distance
		// Pure lambda functional baby ;)
		public float SquaredDist(Row other) => Data.Select((num, i) => {

			// The inside of the sum operator
			float diff = num - other.Data[i];

			// The square. Re use the diff to avoid execute the op
			// twice
			return diff*diff;
		}).Sum(); // The sum operator

		// The real distance between two points
		public float Dist(Row other) => MathF.Sqrt(SquaredDist(other));

		// Returns the index of the closes possible center

		// Index of the closest one using functional magic
		public int IndexOfClosest(Row[] centers) =>
			centers
			// Map the distance and index of each centroid
			.Select( (centroid, i) => (SquaredDist(centroid), i) )
			// From that list of key value pairs, get the max by
			// comparing the value.
			// This is more or less how Min is defined
			.Aggregate( (a,b) => a.Item1 < b.Item1 ? a:b )
			// return the key
			.Item2;
		

		// Method to get the farthest vector from this one,
		// usefull for Kmeans++
		public Row Farthest(Row[] rows) =>
			// LINQ Functional Magic
			rows
			// Compute the dist for each vector, and store both the dist and 
			// the index in a tuple
			.Select( (val, i) => (SquaredDist(val),val) )
			// Get the tuple with the highest value in Item1 (the dist)
			// This is more or less how Min is defined
			.Aggregate( (a,b) => a.Item1 > b.Item1 ? a :b )
			// Get the Item 2 in the tuple, which is the index
			.Item2;
        
    }
}
