<script lang="ts">

	// Bad hardcoded, but good enough for the demo.
	const apiRoot = "https://a01702948-basic-ai.azurewebsites.net/api/kmeans";

	// Load example csvs
	let iris = "";
	let xy = "";

	// Load samples
	fetch("iris.csv").then( res => res.text()).then( text => iris = text);
	fetch("quizExample.csv").then( res => res.text()).then( text => xy = text);
	
	let csvText = "Paste your CSV here...\n\nOr load an sample dataset";

	let k = 3;

	// Representation of the expected response
	interface ClusteringResponse {
		Labels: number[]
		Centers: {Data: number[]}[]
	}

	// Representation of each row in the table
	class RowOutput {
		values: string
		label: number

		constructor(values: string, label: number) {
			this.values = values;
			this.label = label;
		}
	}

	// This will be binded later
	let table: RowOutput[] = [];

	// The CSV has headers
	let csvHasHeaders = false;

	// Function to go and fetch the data from Azure
	// (this might take a while because we are using the free tier)

	function clusterData() {
		// Get the lines of the string
		const lines = csvText.split('\n');

		// Check if the first line
		if(csvHasHeaders) lines.shift();

		// Ok now "flatten" the array by joining them with a coma

		const flat = lines.join(',');

		console.log(flat);

		// Infer the shape of the array:
		// The rows are easy
		const rows = lines.length;

		// The cols not so much, but we can count the commas of
		// the first line and then separate them
		const cols = lines[0].split(',').length;

		// construct the url
		const url = `${apiRoot}?data=${flat}&rows=${rows}&cols=${cols}&k=${k}`;

		// Make a fetch
		fetch(url).then(resp => resp.json()).then( (data: ClusteringResponse) => {
			// Use the data to create the table
			table = data.Labels.map( (label, i) => new RowOutput(lines[i], label) );

		}).catch(err => console.log(err));

	}

	function loadIris() {
		csvText = iris;
		csvHasHeaders = true;
		k = 3;
	}

	function loadXY(){
		csvText = xy;
		csvHasHeaders = true;
		k = 2;
	}

</script>

<main>
	<h1>Basic AI Example</h1>
	<p>This is an interface to interact with a hand made Kmeans implementation</p>


	<p>
		Please note the algorithm is implemented as the "classical" <i>Kmeans</i>, as
		opposed to <i>kmeans++</i>, which is better because it offers a
		better inirialization
	</p>

	<br>
	<button on:click={loadIris}>Load Iris sample</button>
	<button on:click={loadXY}>Load XY 2d sample</button>

	<br>
	<textarea cols="50" rows="10" bind:value={csvText}></textarea>

	<br>
	<div id="controls">
		<input type=checkbox bind:checked={csvHasHeaders}> 
		CSV Has headers
		<br>
		<strong>K:</strong> <input type="number" bind:value={k}>
		<button on:click={clusterData}>Make Cluster</button>
	</div>

	<table>
		<tr>
		  <th>ID</th>
		  <th>Data</th>
		  <th>Label (Class)</th>
		</tr>
		

		{#each table as row, id}
		<tr>
			<td>{id}</td>
			<td>{row.values}</td>
			<td>{row.label}</td>
		</tr>
		{/each}
	  </table>


</main>

<style>
	main {
		text-align: center;
		padding: 1em;
		max-width: 240px;
		margin: 0 auto;
	}

	h1 {
		color: #ff3e00;
		text-transform: uppercase;
		font-size: 4em;
		font-weight: 100;
	}

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}


	/*Popular table style courtesy of w3schools*/
	table {
		font-family: arial, sans-serif;
		border-collapse: collapse;
		width: 90%;

		margin: 0 auto;

		max-width: 75em;
	}

	td, th {
		border: 1px solid #dddddd;
		text-align: left;
		padding: 8px;
	}

	tr:nth-child(even) {
		background-color: #dddddd;
	}
</style>