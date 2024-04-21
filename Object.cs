using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class Object
    {
        private List<string> _ids;
        
        public Object(string[] ids) 
        {
            foreach(string id in ids) 
            {
                _ids = new List<string>();
                AddIdentifier(id);
            }
        }

        public string GetFirstId
        {
            get
            {
                return _ids[0];
            }
        }

        public bool AreYou(string id)
        {
            foreach(string ident in _ids) 
            {
                if(ident == id)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddIdentifier(string id)
        {
            _ids.Add(id);
        }
    }
}
