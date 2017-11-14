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
    }
    static void Load_Quest()
    {
        //Event_Manager.Load_Objects(LOAD_OBJECTS.Quest);
        Web_Manager.instance.StartCoroutine("SelectField");
    }

    public void Quest_Loader()
    {

    }

    public void AddQuest(Quest quest)
    {
        Quests.Add(quest);
    }
}
