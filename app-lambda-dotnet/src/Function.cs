using System.Text.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AppLambda;

public class Function
{
    public APIGatewayProxyResponse FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var body = JsonSerializer.Serialize(new { status="ok", service="dotnet-lambda", message="Hej från Lambda (.NET)!" });
        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = body,
            Headers = new Dictionary<string,string> { ["Content-Type"] = "application/json" }
        };
    }
}
