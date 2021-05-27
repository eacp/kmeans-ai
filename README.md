# KMeans implementation and comparisson with unit testing

This is the implementation of the Kmeans algorithm and a comparisson with KMeans++.

The application can be used at https://basicai.eduardoandres.dev/

[Unit Testing](https://github.com/eacp/kmeans-ai/tree/main/Itesm.BasicAI.Test)


## Verification

To verify the implementation, I used a dataset known as *iris*. This dataset is about flowers, and it contains 150 labeled samples. It has 3 classes, and the 
each class contains exactly 50 classes. The samples are already sorted by class, so it can be used to evaluate the classification is working.

I also made a Python script to verify the clustering using KMeans++ and SciKit Learn, to compare the results and see if they match.


## Deployment
The application frontend was deployed to AWS Amplify. The backend was deployed to Azure Functions. 

[Information about the interface](https://github.com/eacp/kmeans-ai/tree/main/WebFront)
[Information about the api](https://github.com/eacp/kmeans-ai/tree/main/Itesm.BasicAI.Rest)


# Usage

![usage](https://user-images.githubusercontent.com/13637639/119901991-3edb3c00-bf0c-11eb-99cc-b1f5971c3f0c.png)


Paste your CSV data in the in the TEXT field

Specify your K

Specify if you want to use headers or not

Hit run

# Unit testing and Test Driven Development

In order to ensure the correct implementation of the KMeans algorithm, and the usability of such implementation, Test Driven Development (TDD) was used. 
TDD can be defined as:

> software development process relying on software requirements being converted to test
cases before software is fully developed, and tracking all software development by repeatedly testing the software against all test cases. (Wikipedia)

In the context of this project, tests cases were written during the development of the core library to emulate real workd usage. These tests can be
run automatically inside Visual Studio and Visual Studio Code, thus increasing development speed and ensuring the correctness of the application.

## Structure

There are 3 C# files in this folder, both are labeled as `[TestClass]` in the code. One tests the implementation of vector and
euclidean operations to compute and compare distances, while the other one tests the clustering algorithm and the behavious of the clusters.

There is a file to test the behavious of the API server. It tests it can read the queries sent by the client application written in Svelte.

# Frontend for the KMeans implementation

This folder contains the frontend code of my kmeans implementation. This frontend is what can be seen on https://basicai.eduardoandres.dev.
The code is a Svelte Application. Svelte is a small UI library that adds declarative programming capabilities to JS and Typescript, as well as
reactivity. It was chosen because the frontend is relatively small. 

More information about running and building Svelte apps can be found in the [SVELTE_README.md](https://github.com/eacp/kmeans-ai/blob/main/WebFront/SVELTE_README.md) 
file.

## Structure

The 2 main files are `main.ts` and `App.svelte`. These contain the code to make the app work properly. The public folder contains the actual 
files that are uploaded to the web. Two example datasets, Iris and the one from a quiz from this course, have been preloaded as CSV files for 
conveniance purposes, although 
any dataset in the CSV format will work fine. They can be found both in this folder or in the public subfolder, because they are to be uploaded to  
the web as well so the front end has access to them. 

## Deployment

The front end is deployed in [AWS Amplify](https://aws.amazon.com/es/amplify/hosting/). After running the `npm run build` command, the resulting files
in the `public` folder are uploaded to the plattfrom. 

Alternatively, the build can be deployed to any static web server or plattform, including but not limited to:

- Firebase Hosting
- Netlify
- Heroku
- Vercel

More information can be found in the [SVELTE_README.md](https://github.com/eacp/kmeans-ai/blob/main/WebFront/SVELTE_README.md) 
file.
