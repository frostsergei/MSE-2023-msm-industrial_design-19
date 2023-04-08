using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Setup_database_for_device.DB
{
    class Tag : AbstractTag
    {
        private string _ordinal;

        public string Ordinal {
            get { return _ordinal; } 
        }

        public Tag(string ordinal, string id, string value = "нет данных???", string name = "", string eu = "") : base(id, value, name, eu)
        {
            _ordinal = ordinal;

            XAttribute ordinalAttr = new XAttribute("Ordinal", _ordinal);

            base.XML.Add(ordinalAttr);
        }

        
    }
}
