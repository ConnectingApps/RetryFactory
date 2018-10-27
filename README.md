# RetryFactory
A demo to explain how the .NET Core factory class for HttpClient can be used in .NET Core 2.1 . Here is the [theory](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests). And here you can see it in action with a swagger interface. Make sure there is no application using port 5000.

```bash
git clone https://github.com/ConnectingApps/RetryFactory.git
cd RetryFactory/RetryFactory
docker build -t retryfactoryshow .
docker run -p 5000:5000 retryfactoryshow
```
**DO NOT FORGET THE DOT (.) SIGN IN THE BUILD COMMAND**

Then visit http://localhost:5000/ using a recent web browser.



