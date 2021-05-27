# Unit testing and Test Driven Development

In order to ensure the correct implementation of the KMeans algorithm, and the usability of such implementation, Test Driven Development (TDD) was used. 
TDD can be defined as:

> software development process relying on software requirements being converted to test
cases before software is fully developed, and tracking all software development by repeatedly testing the software against all test cases. (Wikipedia)

In the context of this project, tests cases were written during the development of the core library to emulate real workd usage. These tests can be
run automatically inside Visual Studio and Visual Studio Code, thus increasing development speed and ensuring the correctness of the application.

## Structure

There are 2 C# files in this folder, both are labeled as `[TestClass]` in the code. One tests the implementation of vector and
euclidean operations to compute and compare distances, while the other one tests the clustering algorithm and the behavious of the clusters.

