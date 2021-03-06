﻿using System.Numerics;
using System.Xml.Serialization;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser.Xml.Item {
    public class Install {
        [XmlAttribute] public int placeable;
        [XmlAttribute] public int unchangeable;
        [XmlAttribute] public int cannotStackAttach;
        [XmlAttribute] public int stackable;
        [XmlAttribute] public int stackableD;
        [XmlAttribute] public int attachable;
        [XmlAttribute] public int wall;
        [XmlAttribute] public int generatePhysX;
        [XmlAttribute] public int cubeProp;
        [XmlAttribute] public int space;
        [XmlAttribute] public int animatable;
        [XmlAttribute] public int funcCode;
        [XmlAttribute] public int objCode;
        [XmlAttribute] public float staticAngle;
        [XmlAttribute] public int indoor;
        [XmlAttribute] public int bankType;
        [XmlAttribute] public string asset;
        [XmlAttribute] public string preset;
        [XmlAttribute] public string mapAttribute;
        [XmlAttribute] public string propCollisionGroup;
        [XmlAttribute] public bool useInstancing = true;
        [XmlIgnore] public Vector3 physXdimension;

        /* Custom Attribute Serializers */
        [XmlAttribute("physXdimension")]
        public string _physXdimension {
            get => Serialize.Vector3(physXdimension);
            set => physXdimension = Deserialize.Vector3(value);
        }
    }
}