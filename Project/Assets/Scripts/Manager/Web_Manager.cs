using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Web_Manager : MonoBehaviour {
    public static Web_Manager instance;

    void Awake()
    {
        if (instance != null)
            Debug.LogError("More than one App Manager in the scene");
        else
            instance = this;
    }
    public IEnumerator SelectField()
    {
        WWW fieldNameData = new WWW("http://81.169.177.181/UIB/request_quests.php");
        yield return fieldNameData;
        string fieldDataString = fieldNameData.text;
        //Debug.Log("field data string: " + fieldDataString);
        //Making new Quest here to add to the database
        string[] questsnames = fieldDataString.Split(';');
        Debug.Log((fieldNameData.text.Split(']', '|')[0]));

        /*quest.start_x = float.Parse(fieldDataString.Split(';')[1]);
        quest.start_y = float.Parse(fieldDataString.Split(';')[2]);*/
        for (int i = 0; i < questsnames.Length; i++)
        {
            Quest q = new Quest();
            q.name = (fieldDataString.Split('/')[i]);
            q.start_x = float.Parse((fieldDataString.Split('/', '|')[0]));
            q.start_y = float.Parse((fieldDataString.Split('|', ';')[i]));
            Event_Manager.Add_Quest(q);
        }
        foreach (string quest in questsnames)
        {
            Quest q = new Quest();
            q.name = quest;
            Event_Manager.Add_Quest(q);
        }
    }
}
