﻿using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class ImmuneEffectProperty {
        [XmlIgnore] public int[] immuneEffectCodes;
        [XmlIgnore] public int[] immuneBuffCategories;

        /* Custom Attribute Serializers */
        [XmlAttribute("immuneEffectCodes")]
        public string _immuneEffectCodes {
            get => Serialize.IntCsv(immuneEffectCodes);
            set => immuneEffectCodes = Deserialize.IntCsv(value);
        }

        [XmlAttribute("immuneBuffCategories")]
        public string _immuneBuffCategories {
            get => Serialize.IntCsv(immuneBuffCategories);
            set => immuneBuffCategories = Deserialize.IntCsv(value);
        }
    }
}