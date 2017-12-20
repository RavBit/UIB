using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Save_Manager : MonoBehaviour {

    public ClueDatabase ClueDB;
    public ClueDisplay Cluedisplay;

    public void Start()
    {
        //Loading save and load Events in
        Event_Manager.LoadQuestClues += Load;
        Event_Manager.LoadQuestCluesF += LoadInClues;
        Event_Manager.SaveQuestClues += Save;
        Event_Manager.Get_LoadedClues += Get_LoadedClues;
    }
    public void LoadInClues()
    {
        ClueDB.clues = new List<Quest_Clues>();
        ClueDB.clues = Event_Manager.Get_Clues();
        XmlSerializer serializer = new XmlSerializer(typeof(ClueDatabase));
        FileStream stream = new FileStream(Application.persistentDataPath + "/ClueData.xml", FileMode.Create);
        serializer.Serialize(stream, ClueDB);
        stream.Close();
        Cluedisplay.StartDisplay();
        Debug.Log("LOAD IN CLUES");
    }
    //save function
    public void Save()
    {
        //open xml file
        XmlSerializer serializer = new XmlSerializer(typeof(ClueDatabase));
        FileStream stream = new FileStream(Application.persistentDataPath + "/ClueData.xml", FileMode.Create);
        serializer.Serialize(stream, ClueDB);
        stream.Close();
    }

    //load function
    public void Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ClueDatabase));
        FileStream stream = null;
        try {
            stream = new FileStream(Application.persistentDataPath + "/ClueData.xml", FileMode.Open);
            ClueDB = serializer.Deserialize(stream) as ClueDatabase;
            stream.Close();
        }
        catch(System.Exception e) {
            if(e is System.Xml.XmlException /*|| e is IOException*/) {
                Debug.Log("NO DATA");
                Save();
            }

        }
        /*if (stream == null)
        {
            Debug.Log("SAVE");
            Save();
            return;
        }*/

    }
    public List<Quest_Clues> Get_LoadedClues()
    {
        return ClueDB.clues;
    }

}

[System.Serializable]
public class ClueEntry
{
    public string clueName;
    public bool isFound;
    public string description;
    public bool isKeyClue;
}

[System.Serializable]
public class ClueDatabase
{
    public List<Quest_Clues> clues = new List<Quest_Clues>();
}