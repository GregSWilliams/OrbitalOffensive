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
            _ids = new List<string>();
            foreach (string id in ids) 
            {
                AddIdentifier(id);
            }
        }

        public bool AreYou(string id)
        {
            id = id.ToLower();
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
            id = id.ToLower();
            _ids.Add(id);
        }
    }
}
