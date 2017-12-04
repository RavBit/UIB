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
public class ClueManager : MonoBehaviour {

    [XmlArray("Clues")]
    [XmlArrayItem("Clue")]
    public List<Clue> clues = new List<Clue>();

    void Start() {
        Save("C:\\Users\\sarah\\Documents\\test.xml");
    }

    public void Save(string path) { 
        var serializer = new XmlSerializer(typeof(ClueManager));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, this);
        stream.Close();
    }

    public static ClueManager Load(string path) {
        var serializer = new XmlSerializer(typeof(ClueManager));
        using (var stream = new FileStream(path, FileMode.Open)) {
            return serializer.Deserialize(stream) as ClueManager;
        }
    }
}
