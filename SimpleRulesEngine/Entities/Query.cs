using SimpleRulesEngine.LogicEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Entities;

public class Query
{
    public string Id { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<AttributeType> RequiredParameters { get; set; } = new List<AttributeType>();
    public List<AttributeType> OptionalParameters { get; set; } = new List<AttributeType>();

    public TimeSpan? CacheDuration { get; set; }

    public IRule? Rule { get; set; }

    public async Task<EvaluationResult> Evaluate(Dictionary<string, object> attributes)
    {
        var evaluationParameters = await ValidateParameters(attributes);
        return await Rule?.Evaluate(evaluationParameters) ?? throw new InvalidDataException("No rules root configured for query");
    }

    private async Task<Dictionary<string, object>> ValidateParameters(Dictionary<string, object> attributes)
    {
        var result = attributes; //new Dictionary<string, object>();
        //todo: validate return all required, any opensure all attributes 
        return result; 


    }

    private async Task ValidateParameters(object parameters)
    {
        throw new NotImplementedException();
    }
}
