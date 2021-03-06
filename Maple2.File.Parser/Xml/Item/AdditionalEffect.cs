﻿using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class AdditionalEffect {
        [XmlIgnore] public int[] id;
        [XmlIgnore] public int[] level;
        [XmlAttribute] public bool dropEffect;

        /* Custom Attribute Serializers */
        [XmlAttribute("id")]
        public string _id {
            get => Serialize.IntCsv(id);
            set => id = Deserialize.IntCsv(value);
        }

        [XmlAttribute("level")]
        public string _level {
            get => Serialize.IntCsv(level);
            set => level = Deserialize.IntCsv(value);
        }
    }
}