using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ccf.Ck.Models.NodeSet
{
    public partial class Node : INode
    {
        private bool _HasRequireAuthenticationSet;
        private bool _RequireAuthentication;
        //[JsonIgnore]
        public bool RequireAuthentication
        {
            get => _RequireAuthentication;
            set
            {
                _HasRequireAuthenticationSet = true;
                _RequireAuthentication = value;
            }
        }

        public bool HasView() => (Views != null && Views.Count > 0);

        public bool HasLookup() => (Lookups != null && Lookups.Count > 0);
       

        public List<Parameter> CollectedReadParameters { get; set; }
        public List<Parameter> CollectedWriteParameters { get; set; }

        public bool HasValidDataSection(bool iswriteoperation)
        {
            return 
                (!iswriteoperation)
                    ? true //Now we support read also for custom plugins without read operation ((Read != null) && (Read.Select != null))
                    : ((Write != null) && ((Write.Insert != null) || (Write.Update != null) || (Write.Delete != null)));
        }

        public void Setup()
        {
            if (string.IsNullOrEmpty(DataPluginName))
            {
                DataPluginName = NodeSet.DataPluginName;
            }
            if (!_HasRequireAuthenticationSet)
            {
                RequireAuthentication = NodeSet.RequireAuthentication;
            }
        }
    }
}