//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Ccf.Ck.Models.NodeSet
{
    public partial class Node : INode
    {
        public Node()
        {
            _Views = new List<View>();
            _Lookups = new List<Lookup>();
            _Children = new List<Node>();
            _Parameters = new List<Parameter>();
        }

#region Private Fields
        private List<View> _Views;
        private List<Lookup> _Lookups;
        private List<Node> _Children;
        private List<Parameter> _Parameters;
#endregion
#region Public Properties
        public string NodeKey
        {
            get;
            set;
        }

        public string DataPluginName
        {
            get;
            set;
        }

        public bool IsList
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public int ExecutionOrder
        {
            get;
            set;
        }

        public NodeSet NodeSet
        {
            get;
            set;
        }

        public Read Read
        {
            get;
            set;
        }

        public Write Write
        {
            get;
            set;
        }

        public List<View> Views
        {
            get
            {
                return _Views;
            }

            set
            {
                _Views = value;
            }
        }

        public List<Lookup> Lookups
        {
            get
            {
                return _Lookups;
            }

            set
            {
                _Lookups = value;
            }
        }

        public List<Node> Children
        {
            get
            {
                return _Children;
            }

            set
            {
                _Children = value;
            }
        }

        public List<Parameter> Parameters
        {
            get
            {
                return _Parameters;
            }

            set
            {
                _Parameters = value;
            }
        }

        public Node ParentNode
        {
            get;
            set;
        }
#endregion
    }
}