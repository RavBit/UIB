using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Save_Manager : MonoBehaviour {

    public ClueDatabase ClueDB;
    public ClueDisplay Cluedisplay;

    void Start()
    {
        Load();
        Cluedisplay.StartDislay();
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
        FileStream stream = new FileStream(Application.persistentDataPath + "/ClueData.xml", FileMode.Open);
        if (stream == null)
        {
            Debug.Log("IS NULL");
            Save();
        }

        ClueDB = serializer.Deserialize(stream) as ClueDatabase;
        stream.Close();
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