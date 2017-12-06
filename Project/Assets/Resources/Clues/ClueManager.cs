using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

/* Clue Manager:
 * Manages amount of clues,
 * state of clues,
 * which clues are found.
 */

[XmlRoot("ClueCollection")]
public class ClueManager {

    [XmlArray("Clues")]
    [XmlArrayItem("Clue")]
    public List<Clue> clues = new List<Clue>();

    public static ClueManager Load(string path) {
        TextAsset xml = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(ClueManager));

        StringReader reader = new StringReader(xml.text);

        ClueManager clues = serializer.Deserialize(reader) as ClueManager;

        reader.Close();

        return clues;
    }

    public void Save(string path) {
        var serializer = new XmlSerializer(typeof(ClueManager));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, this);
        stream.Close();
    }


}