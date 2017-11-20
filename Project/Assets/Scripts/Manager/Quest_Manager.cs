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

    private void Update() {
        CheckDistanceQuest();
    }
    void CheckDistanceQuest() {
        foreach(Quest quest in Quests) {
            Debug.Log("Quest: " + quest.name + "  = " + (OnlineMapsUtils.DistanceBetweenPointsD(new Vector2(quest.start_y, quest.start_x), new Vector2(OnlineMapsLocationService.instance.GetLocationX(), OnlineMapsLocationService.instance.GetLocationY()))));
            double dis = OnlineMapsUtils.DistanceBetweenPointsD(new Vector2(quest.start_y, quest.start_x), new Vector2(OnlineMapsLocationService.instance.GetLocationX(), OnlineMapsLocationService.instance.GetLocationY()));
            if(dis < 0.05f) {
                Debug.Log("QUEST: " + quest.name);
            }
        }
    }
    void Setup()
    {
        //Pool to setup the events in
        Event_Manager.AddQuest += AddQuest;
        Event_Manager.DrawQuests += DrawQuests;
    }
    static void Load_Quest()
    {
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
            //TODO: MAKE MARKER
            //Event_Manager.Add_QuestCircles(quest);
        }

    }
}
