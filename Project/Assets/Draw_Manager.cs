using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Manager : MonoBehaviour {
    private void Start() {
        Setup();
    }
    public void Setup() {
        //Pool to setup the events in
        Event_Manager.AddQuestMarker += DrawQuests;
    }
    public void DrawQuests(Quest quest) {
        OnlineMaps.instance.AddMarker(new Vector2(quest.start_y, quest.start_x), quest.name);
    }
}
