using AppLambda;
using Amazon.Lambda.APIGatewayEvents;

var fn = new Function();
var resp = fn.FunctionHandler(new APIGatewayProxyRequest { HttpMethod="GET", Path="/" }, null!);
Console.WriteLine(resp.StatusCode);
Console.WriteLine(resp.Body);
