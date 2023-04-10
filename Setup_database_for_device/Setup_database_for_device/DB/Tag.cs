﻿using System.Xml.Linq;

namespace Setup_database_for_device.DB
{
    class Tag : AbstractTag
    {
        private int _ordinal;

        public int Ordinal {
            get { return _ordinal; } 
        }

        public Tag(int ordinal, string id = "", string value = "нет данных???", string name = "", string eu = "") : base(id, value, name, eu)
        {
            _ordinal = ordinal;

            XAttribute ordinalAttr = new XAttribute("Ordinal", _ordinal);

            base.XML.Add(ordinalAttr);
        }

        
    }
}
