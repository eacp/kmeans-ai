# Imports and load dataset

#importing the libraries
import numpy as np
import matplotlib.pyplot as plt

from sklearn.cluster import KMeans

#importing the Iris dataset with pandas
dataset = pd.read_csv('drive/MyDrive/iris.csv')
x = dataset.iloc[:, [1, 2, 3, 4]].values

data = np.delete(x, np.s_[-1:], axis=1)

#Applying kmeans to the dataset / Creating the kmeans classifier
kmeans = KMeans(n_clusters = 3, init = 'k-means++', max_iter = 300, n_init = 10, random_state = 0)
y_kmeans = kmeans.fit_predict(data)

# This one is used to check my hand made implementation is correct
print(kmeans.cluster_centers_)

for flower, label in zip(data, kmeans.labels_):
  print(flower, label)
