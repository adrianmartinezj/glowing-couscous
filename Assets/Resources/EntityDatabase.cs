using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ItemCollection")]
public class EntityDatabase 
{
    [XmlArray("WeaponCollection")]
    [XmlArrayItem("Weapon")]
    public List<Weapon> weapons = new List<Weapon>();
    [XmlArray("ArmorCollection")]
    [XmlArrayItem("Armor")]
    public List<Armor> armor = new List<Armor>();

    public static EntityDatabase Load (string path)
    {
        TextAsset _xml = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(EntityDatabase));

        StringReader reader = new StringReader(_xml.text);

        EntityDatabase ed = serializer.Deserialize(reader) as EntityDatabase;

        reader.Close();

        return ed;

    }
}
