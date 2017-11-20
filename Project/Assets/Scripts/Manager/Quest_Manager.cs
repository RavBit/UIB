using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour {
    [Header("Quests List")]
    public List<Quest> Quests;

    [Header("UI Objects")]
    public Texture2D RedMarker;
    public Texture2D GreenMarker;

    public GameObject DialogScreen;
    void Start()
    {
        Setup();
        Load_Quest();
    }
    void CheckDistanceQuest() {
        foreach(Quest quest in Quests) {
            Debug.Log("Quest: " + quest.name + "  = " + (OnlineMapsUtils.DistanceBetweenPointsD(new Vector2(quest.start_y, quest.start_x), new Vector2(OnlineMapsLocationService.instance.GetLocationX(), OnlineMapsLocationService.instance.GetLocationY()))));
            double dis = OnlineMapsUtils.DistanceBetweenPointsD(new Vector2(quest.start_y, quest.start_x), new Vector2(OnlineMapsLocationService.instance.GetLocationX(), OnlineMapsLocationService.instance.GetLocationY()));
            if(dis < 0.05f) {
                foreach(OnlineMapsMarker marker in OnlineMaps.instance.markers) {
                    if (marker.label == quest.name) {
                        if (!quest.ClickAble) {
                            marker.texture = RedMarker;
                            marker.Init();
                            OnlineMaps.instance.Redraw();
                            quest.AddInteraction();
                        }
                    }
                }
            }
        }
    }
    void Setup()
    {
        //Pool to setup the events in
        Event_Manager.AddQuest += AddQuest;
        Event_Manager.DrawQuests += DrawQuests;
        //Event_Manager.ToggleDialog += DrawDialog;
        Event_Manager.InsertDialog += InsertDialogs;
        Event_Manager.DistanceCheck += CheckDistanceQuest;
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
    public void DrawDialog(bool toggle) {
        DialogScreen.SetActive(toggle);
    }
    public void InsertDialogs(int id, string[] dialogs) {
        Quests[id].dialogs = dialogs;
    }
}
