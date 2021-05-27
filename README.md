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
