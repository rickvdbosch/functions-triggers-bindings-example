# functions-triggers-bindings-example

Repo containing an example Azure Functions project that implements different types of input and output Bindings.

## Accompanying blog posts:

Here are some blog posts giving more context and explaining the examples a bit more:

- [Using Triggers & Bindings in Azure Functions V2](https://www.rickvandenbosch.net/blog/using-triggers-bindings-in-azure-functions-v2/)
- [Dynamic output bindings in Azure Functions](https://www.rickvandenbosch.net/blog/dynamic-output-bindings-in-azure-functions/)
- [Azure Functions: Binding to a property](https://www.rickvandenbosch.net/blog/azure-functions-binding-to-a-property/)
- [Using (Table Storage) Bindings in Azure Functions](https://www.rickvandenbosch.net/blog/using-table-storage-bindings-in-azure-functions/)
 
## Examples 

There are a few examples:

### BlobTriggerInputBinding

This example shows you how to copy the triggering Blob into another container by coding it out completely. The steps implemented:

- Connect to a Storage Account
- Create a BlobClient
- Get a reference to a container (and create it if it doesn't exist)
- Get a reference to a blob
- Upload the file

### BlobTriggerInputBindingOutputBinding

This example shows you the power of an output binding: only _one_ line of code to copy the blob!

### BlobTriggerInputBindingOutputBinding2

In this Function, we add a message to a queue for each word in the triggering Blob. The only line of code we
need for that is calling the `Add()` method on the `ICollector<T>`.

### BlobTriggerInputBindingOutputBinding3

Dynamic output binding by using the `Binder` class. 

### HttpTriggerReturnBinding

The HttpTrigger isn't bound to a generic `HttpRequest`, but is TYPED to a `RequestModel`. The platform takes care of the deserialization of the message body for you.  
The return binding above the Function does a couple of things for you:

- It creates a Blob in the 'copied' container with a random GUID as the filename
- It automatically writes the output of the Function call into that Blob

### HttpTriggerPropertyBinding

The HttpTrigger isn't bound to a generic `HttpRequest`, but is TYPED to a `RequestModel`. The platform takes care of the deserialization of the message body for you.  
The blob binding above the Function does a couple of things for you:

- It creates a Blob in the 'properties' container with the value of the `Identifier` property as the filename
- It writes the message of the posted model into that Blob

### HttpTriggerTableInputBinding

In this Function example the Table Storage binding takes care of connecting to Table Storage.
We’re automatically getting an instance of a `CloudTable` pointing to the right (partition of a) table, or even an instance of a typed entity, in the right storage account, all by simply specifying the binding the right way.
