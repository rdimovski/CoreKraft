﻿using System.Collections.Generic;

namespace Ccf.Ck.SysPlugins.Interfaces
{
    public interface ICustomPluginExecuteParameters
    {
        Dictionary<string, object> Row { get; set; } // Current row (Store) or parent row (Select)
        List<Dictionary<string, object>> Results { get; set; } // Results generated by the context so far (select)
        List<Dictionary<string, object>> Parents { get; set; }
        string Path { get; set; }
        string Phase { get; set; } // Can be used as alternative to event names
        string RowState { get; set; } // Used only when Action = store to indicate the state of the this.Row (this is a helper you have Api.Set/GetRowState as alternative ways to deal with this)
        string Action { get; set; } // The package action - can be read or write.
                                    //string Parameters { get; set; } // Additional parameters for inject contexts mostly - a string that should be parsed by the rule/inject
                                    //IPackageContextParameters ContextParameters { get; set; }
        string SqlStatement { get; set; }
        string NodeKey { get; set; }
        IParametersContext NodeParameters { get; set; }
    }
}
