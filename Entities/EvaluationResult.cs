namespace SimpleRulesEngine.Entities;

public class EvaluationResult
{
    public ResultType Result { get; set; }
    public string Description { get; set; }
    Dictionary<string, object> IncludeAttributes { get; set; }
    Dictionary<string, object> ExcludeAttributes { get; set; }
}