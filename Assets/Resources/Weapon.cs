using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Weapon : Entity
{
    [XmlAttribute("name")]
    public string name { get; set; }
    [XmlAttribute("damage")]
    public int damage { get; set; }
    [XmlAttribute("speed")]
    public float speed { get; set; }
}
