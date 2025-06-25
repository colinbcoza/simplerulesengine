using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRulesEngine.Entities;

public class Query
{
    public string QueryId { get; set; }
    public string Description { get; set; }

    public Dictionary<string, object> Parameters { get; set; }

}
