# *Why* Blazor?

Blazor exists to address the "problem" many developers feel when they work with web-based applications. It turns out that the HTTP protocol is, by design, a **stateless** protocol. What that means is, there is a clear and distinct separation between the *client* (typically, the web browser) and the *server* (specifically, our *web* server). The client and server will communicate over the network, but they are *independent* of each other and *do not share any active resources of RAM or disk space*; they simply *exchange data* with each other. This is what we mean by the term ***stateless***.

> Being "stateless" implies the freedom to be "forgetful". After the web server finishes handling the client's request, it "discards" the information about the request in order to free up memory for other requests. That is, it "loses its state". If the client makes another request that requires that "state", then either the client "reminds" the server by sharing that information or the client "identifies" itself in a way that the server can go and look up data (perhaps from a database) related to the new request of the client. All in all, it's like a perpetual exchange with [Ursula the waitress in *Mad About You*](https://youtu.be/134J5VLARRw?feature=shared).

By the very nature of being "web-based", the only interactions between client and server are *request*/*response* communications. The client fires off a *request* over the network to the server and waits for something to happen (at least, for a while - the browser won't wait forever). When the server gets a request, it examines the details of the request in order to deliver some kind of *response*. If the request is for a *static* item or asset (such as an image, a stylesheet, etc.), it will simply return that asset in its response. If the request is for *dynamic* content (such as a POST request of a form the user filled out in the browser), then the details of that request are sent off to some *program* that can do the processing. When the program is done its processing, everything is packaged up as a *response* and the web server sends that back to the browser. 

So, what's the problem with being stateless? The problem is that all this The technolgies and design behind Blazor