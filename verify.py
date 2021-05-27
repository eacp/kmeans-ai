# -*- coding: utf-8 -*-
"""Iris Test KMeans++

Automatically generated by Colaboratory.

Original file is located at
    https://colab.research.google.com/drive/1AZHmGxXK4G9IdXevv0Cwg8nBziXl2IL8
"""

# Imports and load dataset

#importing the libraries
import numpy as np
import matplotlib.pyplot as plt

from sklearn.cluster import KMeans

#importing the Iris dataset with pandas
dataset = pd.read_csv('drive/MyDrive/iris.csv')
x = dataset.iloc[:, [1, 2, 3, 4]].values

data = np.delete(x, np.s_[-1:], axis=1)

"""# Run the KMeans++ Clustering

Instantiate the KMeans algorithm IN THE KMeans++ config
"""

#Applying kmeans to the dataset / Creating the kmeans classifier
kmeans = KMeans(n_clusters = 3, init = 'k-means++', max_iter = 300, n_init = 10, random_state = 0)
y_kmeans = kmeans.fit_predict(data)

# This one is used to check my hand made implementation is correct
print(kmeans.cluster_centers_)

"""# Clustering Results

We will print the results and the assigned class.

"""

for flower, label in zip(data, kmeans.labels_):
  print(flower, label)

"""# Discussion

We can see that Kmeans++ has better accuracy, but classical kmeans can still be usefull
"""
