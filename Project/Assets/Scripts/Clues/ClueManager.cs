using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

/* Clue Manager:
 * Manages amount of clues,
 * state of clues,
 * which clues are found.
 */

    
public class ClueManager : MonoBehaviour {

    //make this a better singleton pls
    public static ClueManager ins;
    void Awake() {
        ins = this;
    }

    public ClueDatabase ClueDB;
    
    //save function
    public void Save() {
        //open xml file
        XmlSerializer serializer = new XmlSerializer(typeof(ClueDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/ClueData.xml", FileMode.Create);
        serializer.Serialize(stream, ClueDB);
        stream.Close();
    }

    //load function
    public void Load() {
        XmlSerializer serializer = new XmlSerializer(typeof(ClueDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/ClueData.xml", FileMode.Open);
        ClueDB = serializer.Deserialize(stream) as ClueDatabase;

        stream.Close();
    }

}

[System.Serializable]
public class ClueEntry {
    public string clueName;
    public bool isFound;
    public string description;
    public bool isKeyClue;
}

[System.Serializable]
public class ClueDatabase {
    public List<ClueEntry> clues = new List<ClueEntry>();
}