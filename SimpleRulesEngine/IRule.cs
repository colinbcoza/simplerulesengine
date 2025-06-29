using SimpleRulesEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine;

public interface IRule : IEvaluator
{
    public string Description { get; set; }
    public List<RuleEvaluatorConfiguration> Evaluators { get; set; }
    public List<LogicConfig> RuleLogic { get; set; }
    public Dictionary<string, object> Configuration { get; set; }


}
