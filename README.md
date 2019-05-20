# functions-triggers-bindings-example
Repo containing an example Azure Functions project that implements different types of Bindings. There are a few examples:

#### BlobTriggerInputBinding

This example shows you how to copy the triggering Blob into another container by coding it out completely.
- Connect to a Storage Account
- Create a BlobClient
- Get a reference to a container (and create it if it doesn't exist)
- Get a reference to a blob
- Upload the file

#### BlobTriggerInputBindingOutputBinding

This example shows you the power of an output binding: only _one_ line of code to copy the blob!

#### BlobTriggerInputBindingOutputBinding2

In this Function, we add a message to a queue for each word in the triggering Blob. The only line of code we
need for that is calling the `Add()` method on the `ICollector<T>`.

#### BlobTriggerInputBindingOutputBinding3

Dynamic output binding by using the `Binder` class.
