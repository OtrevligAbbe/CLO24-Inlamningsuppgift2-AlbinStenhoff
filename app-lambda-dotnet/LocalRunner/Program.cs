using System;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using AppLambda;

var fn = new Function();
var resp = fn.FunctionHandler(
    new APIGatewayProxyRequest
    {
        HttpMethod = "GET",
        Path = "/"
    },
    new DummyContext()
);

Console.WriteLine($"StatusCode: {resp.StatusCode}");
Console.WriteLine(resp.Body);


class DummyContext : ILambdaContext
{
    public string AwsRequestId => "local";
    public IClientContext? ClientContext => null;
    public string FunctionName => "LocalRunner";
    public string FunctionVersion => "1";
    public ICognitoIdentity? Identity => null;
    public string InvokedFunctionArn => "arn:aws:lambda:local";
    public ILambdaLogger Logger => new ConsoleLambdaLogger();
    public int MemoryLimitInMB => 256;
    public TimeSpan RemainingTime => TimeSpan.FromMinutes(1);

    
    public string LogGroupName => "local-log-group";
    public string LogStreamName => "local-log-stream";
}

class ConsoleLambdaLogger : ILambdaLogger
{
    public void Log(string message) => Console.WriteLine(message);
    public void LogLine(string message) => Console.WriteLine(message);
}
