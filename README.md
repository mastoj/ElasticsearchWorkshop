Sample code and exercises for NEST and elasticsearch
=====================

The documentation to NEST is found here: http://nest.azurewebsites.net/. I also recommend to install the Marvel plugin on your developing instance of elasticsearch so you get access to sense, which is a great tool querying aginst elasticsearch. The sample is using the northwnd database as a sample dataset.

We are not focusing on the UI, so to test the functionality you need a client like [postman](https://chrome.google.com/webstore/detail/postman-rest-client/fdmmgilgnpjigdojojpjoooidkmcomcm).

## 1. Index some data
Index all the products, customers and orders using NEST. http://nest.azurewebsites.net/nest/core/

## 2. Simple querying
Make a simple query where you search against everything and returns everything and add the query in the `IndexController` under the `GET` method with a simple query parameter. To query against multiple types at once you use:

    var result = _indexer.Search<object>(s => s
      .Types(typeof (Product), typeof (Order), typeof (Customer))
      .QueryString(query));

## 3. Make separate queries for products, orders and customers
The next step is to basically to the same thing but now we are only interested in one thing at a time. Create one query each for customers, products and orders and put them in the respective controllers.

At this point it might be wise to creat a base controller that all the others are using so you don't have instantiate the elasticsearch client all the time.

Note that elasticsearch allows for wildcard queries, so to search for everything you specify '*'
