using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour {

    public List<Quest> Quests;
    void Start()
    {
        Setup();
        Load_Quest();
    }
    void Setup()
    {
        //Pool to setup the events in
        Event_Manager.AddQuest += AddQuest;
        Event_Manager.DrawQuests += DrawQuests;
    }
    static void Load_Quest()
    {
        //Event_Manager.Load_Objects(LOAD_OBJECTS.Quest);
        Web_Manager.instance.StartCoroutine("SelectField");
    }
    public void AddQuest(Quest quest)
    {
        Quests.Add(quest);
    }

    public void DrawQuests() {
        foreach(Quest quest in Quests)
        {
            Event_Manager.Add_QuestMarker(quest);
            Debug.Log("Draw Quests");
        }
    }
}
