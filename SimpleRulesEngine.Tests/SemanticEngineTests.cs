using Microsoft.Extensions.Logging;
using Moq;
using SimpleRulesEngine.Entities;
using SimpleRulesEngine.Evaluators;
using SimpleRulesEngine.LogicEngine;
using SimpleRulesEngine.SemanticEngine;
using System.Data;

namespace SimpleRulesEngine.Tests;

public class SemanticEngineTests
{
    [Fact]
    public async void EvaluateQuery_text_compare_attributes_returns_success()
    {
        ILogger logger = new Mock<ILogger>().Object;

        ISemanticEngine semanticEngine = new SimpleSemanticEngine();

        var attributeTypes = new List<AttributeType>
        {
            new AttributeType{ Key = "one" },
            new AttributeType{ Key = "another" },
        };

        var ruleLogicEvaluator = new TextEqualEvaluator("text-equal", logger);

        var ruleLogicEvaluatorParamSeqMap = new List<string>
        {
            "one", "another"
        };

        var ruleLogicEvaluatorConfig = new RuleEvaluatorConfiguration
        {
            Evaluator = ruleLogicEvaluator,
            ParameterSequenceMap = ruleLogicEvaluatorParamSeqMap,
            Description = "textequals-[one]-[another]",
        };

        var ruleLogicConfig = new LogicConfig
        {
            Operator = Operator.Type.True,
            EvaluatorConfigurations = new List<RuleEvaluatorConfiguration>
            {
                ruleLogicEvaluatorConfig
            }
        };

        var rule = new SimpleRule("test-rule-id", logger, "basic rule description")
        {
            RuleLogic = new List<LogicConfig> { ruleLogicConfig }
        };

        var query = new Query
        {
            Id = "test-query",
            Description = "test query",
            RequiredParameters = attributeTypes,
            Rule = rule
        };

        await semanticEngine.Queries.Upsert(new Dictionary<string, Query>
        {
            { query.Id, query },
        });

        var queryAttribParams = new Dictionary<string, object> { { "one", "Test" }, { "another", "Test" } };

        var result = await semanticEngine.EvaluateQuery("test-query", queryAttribParams);

        Assert.True(ResultType.Success == result.Result);
    }
}
