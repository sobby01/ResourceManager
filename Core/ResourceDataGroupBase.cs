using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;

namespace ResourceManager.Core
{
    public class ResourceDataGroupBase
    {
        private Dictionary<CultureInfo, ResourceDataBase> data = new Dictionary<CultureInfo, ResourceDataBase>();
        private string name;

        public ResourceDataGroupBase(string name, IResourceFileGroup fileGroup)
        {
            this.name = name;
            this.FileGroup = fileGroup;
        }

        public Dictionary<CultureInfo, ResourceDataBase> ResxData
        {
            get { return data; }
        }
        public string Name
        {
            get { return name; }
        }
        public IResourceFileGroup FileGroup
        {
            get;
            private set;
        }
        public void Add(ResourceDataBase resxdata)
        {
            if(resxdata.ResxFile.Culture != null)
                this.data.Add(resxdata.ResxFile.Culture, resxdata);
        }

        public bool HasChanged
        { 
            get 
            {
                return ResxData.Any(p => p.Value.HasChanged);
            }
        }       
        public bool IsComplete(IEnumerable<CultureInfo> requiredCultures)
        {
            bool ismissedOrPending = ResxData.Keys.Intersect(requiredCultures).Count() == requiredCultures.Count();

            if (ismissedOrPending)
            {
                int count = ResxData.Values.Where(x => x.Comment != null && x.Comment.ToUpperInvariant() == "pending".ToUpperInvariant()).Count();
                if (count > 0)
                    ismissedOrPending = false;
            }

            return ismissedOrPending;
        }
    }
}
