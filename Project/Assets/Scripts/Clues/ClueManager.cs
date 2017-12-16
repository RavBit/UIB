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

    public static GameObject canvas;
    public ClueDatabase ClueDB;
    
    
    //make this a better singleton pls
    public static ClueManager ins;
    void Awake() {
        ins = this;

        canvas = GameObject.FindWithTag("ClueCanvas");
        canvas.SetActive(false);
        //Load();
    }
    void LoadInClues()
    {

    }
    //save function
    public void Save() {
        //open xml file
        XmlSerializer serializer = new XmlSerializer(typeof(ClueDatabase));
        FileStream stream = new FileStream(Application.persistentDataPath + "/ClueData.xml", FileMode.Create);
        
        serializer.Serialize(stream, ClueDB);
        stream.Close();
    }

    //load function
    public void Load() {
        XmlSerializer serializer = new XmlSerializer(typeof(ClueDatabase));
        FileStream stream = new FileStream(Application.persistentDataPath + "/ClueData.xml", FileMode.Open);
        if (stream == null) {
            Save();
        }

        ClueDB = serializer.Deserialize(stream) as ClueDatabase;

        stream.Close();

    }

}