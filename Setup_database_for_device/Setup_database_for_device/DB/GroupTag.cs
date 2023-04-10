using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Setup_database_for_device.DB
{
    class GroupTag : AbstractTag
    {
        private int _index;

        public int Index {
            get { return _index; } 
        }

        public GroupTag(int index, string id, string value = "нет данных???", string name = "", string eu = "") : base(id, value, name, eu)
        {
            _index = index;

            XAttribute indexAttr = new XAttribute("Index", _index);

            base.XML.Add(indexAttr);
        }
    }
}
