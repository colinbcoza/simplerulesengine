using Microsoft.Extensions.Logging;
using Moq;
using SimpleRulesEngine.Entities;
using SimpleRulesEngine.Evaluators;

namespace SimpleRulesEngine.Tests;


public class EvaluatorTests
{
    [Fact]
    public async void TextEqualEvaluator_returns_success()
    {
        ILogger logger = new Mock<ILogger>().Object;

        var textEqualEvaluator = new TextEqualEvaluator(Guid.NewGuid().ToString(), (ILogger)logger);
        var result = await textEqualEvaluator.Evaluate(new Dictionary<string, object>(), "Test", "Test");

        Assert.True(ResultType.Success == result.Result);
        Assert.True(nameof(TextEqualEvaluator) == result.Description);
    }

    [Fact]
    public async void TextEqualEvaluator_multiuple_arguments_returns_success()
    {
        ILogger logger = new Mock<ILogger>().Object;

        var textEqualEvaluator = new TextEqualEvaluator(Guid.NewGuid().ToString(), (ILogger)logger);
        var result = await textEqualEvaluator.Evaluate(new Dictionary<string, object>(), "Test", "Test", "Test", "Test", "Test", "Test");

        Assert.True(ResultType.Success == result.Result);
    }

    [Fact]
    public async void TextEqualEvaluator_case_mismatch_returns_success()
    {
        ILogger logger = new Mock<ILogger>().Object;

        var textEqualEvaluator = new TextEqualEvaluator(Guid.NewGuid().ToString(), (ILogger)logger);
        var result = await textEqualEvaluator.Evaluate(new Dictionary<string, object>(), "test", "TEST");

        Assert.True(ResultType.Success == result.Result);
    }

    [Fact]
    public async void TextEqualEvaluator_non_match_returns_failure()
    {
        ILogger logger = new Mock<ILogger>().Object;

        var textEqualEvaluator = new TextEqualEvaluator(Guid.NewGuid().ToString(), (ILogger)logger);
        var result = await textEqualEvaluator.Evaluate(new Dictionary<string, object>(), "Test", "Test", "Test", "fail", "Test");

        Assert.True(ResultType.Failure == result.Result);
    }

    [Fact]
    public async void TextEqualEvaluator_null_arguments_throws_exception()
    {
        ILogger logger = new Mock<ILogger>().Object;

        var textEqualEvaluator = new TextEqualEvaluator(Guid.NewGuid().ToString(), (ILogger)logger);
        //await textEqualEvaluator.Evaluate("one");

        Assert.Throws<ArgumentNullException>(() => textEqualEvaluator.Evaluate(null).GetAwaiter().GetResult);
    }

    [Fact]
    public async void TextEqualEvaluator_less_than_2_arguments_throws_exception()
    {
        ILogger logger = new Mock<ILogger>().Object;

        var textEqualEvaluator = new TextEqualEvaluator(Guid.NewGuid().ToString(), (ILogger)logger);
        //await textEqualEvaluator.Evaluate("one");

        Assert.Throws<ArgumentOutOfRangeException>(() => textEqualEvaluator.Evaluate(
            new Dictionary<string, object>(),
            "one").GetAwaiter().GetResult);
    }

}
