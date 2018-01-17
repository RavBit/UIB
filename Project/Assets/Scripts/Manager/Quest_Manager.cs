using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Quest_Manager : MonoBehaviour {
    [Header("Current Quest")]
    public Quest CurrentQuest;
    [Header("Quests List")]
    public List<Quest> Quests;

    [Header("UI Objects")]
    public Texture2D RedMarker;
    public Texture2D GreenMarker;
    public OnlineMapsMarker OMM;
    public ClueManager CM;
    public GameObject DialogScreen;
    void Start() {
        Setup();
        Load_Quest();

    }
    public OnlineMapsMarker GetOMM() {
        return OMM;
    }
    void Setup() {
        //Pool to setup the events in
        Event_Manager.AddQuest += AddQuest;
        Event_Manager.DrawQuests += DrawQuests;
        Event_Manager.ToggleDialog += DrawDialog;
        Event_Manager.DistanceCheck += CheckDistanceQuest;
        Event_Manager.DistanceCheck += CheckDistanceClues;
        Event_Manager.SetQuestList += SetQuest;
        Event_Manager.SetCurrentQuest += SetCurrentQuest;
        Event_Manager.GetClues += GetClues;
        Event_Manager.SetCurrentQuestClues += SetCurrentQuestClues;
        Event_Manager.SetClueFound += Set_ClueFound;
    }
    void CheckDistanceQuest() {
        foreach (Quest quest in Quests) {
            double dis = OnlineMapsUtils.DistanceBetweenPointsD(new Vector2(quest.start_y, quest.start_x), new Vector2(OnlineMapsLocationService.instance.GetLocationX(), OnlineMapsLocationService.instance.GetLocationY()));
            if (dis < 0.05f) {
                foreach (OnlineMapsMarker marker in OnlineMaps.instance.markers) {
                    if (marker.label == quest.name) {
                        if (!quest.ClickAble) {
                            marker.texture = RedMarker;
                            marker.Init();
                            OnlineMaps.instance.Redraw();
                            quest.AddInteraction();
                            if (quest.id == 1) {
                                OMM = marker;
                            }
                        }
                    }
                }
            }
        }
    }
    void CheckDistanceClues() {
        foreach (Clue_Map cm in CM.ClueMap) {
            double dis = OnlineMapsUtils.DistanceBetweenPointsD(new Vector2((float)cm.pos.pos_x, (float)cm.pos.pos_y), new Vector2(OnlineMapsLocationService.instance.GetLocationX(), OnlineMapsLocationService.instance.GetLocationY()));
            Debug.Log("DIST: " + dis);
            if (dis < 0.025f) {
                int counter = 0;
                foreach (OnlineMapsMarker marker in OnlineMaps.instance.markers) {
                    if (marker.label == "C" + counter) {
                        if (!cm.ClickAble) {
                            marker.texture = RedMarker;
                            marker.Init();
                            cm.ClickAble = true;
                            OnlineMaps.instance.Redraw();
                            cm.AddInteraction(counter);
                        }
                    }
                    counter++;
                }
            } else {
                Debug.Log("TO FAR AWAY: " + cm.pos.pos_x);
                cm.ClickAble = false;
                OnlineMaps.instance.Redraw();
            }
            
        }
    }
    public static void Load_Quest() {
        Web_Manager.instance.StopCoroutine("LoadQuests");
        Web_Manager.instance.StartCoroutine("LoadQuests");
    }

    void SetCurrentQuestClues(List<Quest_Clues> clues) {
        CurrentQuest.Clues = clues;
    }

    public List<Quest_Clues> GetClues() {
        return CurrentQuest.Clues;
    }
    public void AddQuest(Quest quest) {
        Debug.Log("adding: " + quest.name);
        Quests.Add(quest);
    }
    public void SetQuest(List<Quest> ql) {
        Debug.Log("Set quest list " + ql.Count);
        Quests = new List<Quest>();
        Quests = ql;
    }

    public void Set_ClueFound(Quest_Clues clue) {
        for (int i = 0; i < CurrentQuest.Clues.Count; i++) {
            if(clue.ID == CurrentQuest.Clues[i].ID) {
                Debug.Log("SEND ONE CLUE TO FOUND: " + clue.ID);
                CurrentQuest.Clues[i] = clue;
            }
        }
    }

    public void SetCurrentQuest(Quest _quest)
    {
        CurrentQuest = _quest;
    }

    public void DrawQuests() {
        foreach(Quest quest in Quests)
        {
            Event_Manager.Add_QuestMarker(quest);
            //TODO: MAKE MARKER
            //Event_Manager.Add_QuestCircles(quest);
        }

    }
    public void DrawDialog(bool toggle, int id) {
        foreach (Quest quest in Quests) {
            if(quest.id == id) {
                DialogScreen.gameObject.SetActive(toggle);
                Event_Manager.Dialog_Load(quest, quest.Suspects);
            }
        }
    }
    public void CancelQuest()
    {
        Web_Manager.instance.Cancel_Quest(CurrentQuest);
    }
}
