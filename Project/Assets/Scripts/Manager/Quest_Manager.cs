using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour {
    [Header("Quests List")]
    [SerializeField]
    public  List<Quest> Quests;
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
        Event_Manager.ToggleDialog += DrawDialog;
        Event_Manager.DistanceCheck += CheckDistanceQuest;
    }
    static void Load_Quest()
    {
        Web_Manager.instance.StartCoroutine("LoadQuests");
    }
    public void AddQuest(Quest quest)
    {
        Debug.Log("adding: " + quest.name);
        Quests.Add(quest);
    }
<<<<<<< HEAD
    public void SetQuest(List<Quest> ql) {
        Quests = new List<Quest>();
        Quests = ql;
    }
=======
>>>>>>> 588dd3c0296194261d085c2f9cd4f9a242e7c72a

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
                Event_Manager.Dialog_Load(quest.name, quest.dialogs[quest.curdialog]);
            }
        }
    }
}
