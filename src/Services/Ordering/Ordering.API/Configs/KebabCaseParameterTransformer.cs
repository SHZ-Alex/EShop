using System.Text.RegularExpressions;

namespace Ordering.API.Configs;

public class KebabCaseParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object? value)
    {
        var str = value!.ToString();
        return (string.IsNullOrEmpty(str) 
            ? str 
            : Regex.Replace(str, "([a-z])([A-Z])", "$1-$2").ToLower())!;
    }
}