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
