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
        OnlineMapsMarker m = new OnlineMapsMarker();
        m.SetPosition(quest.start_y, quest.start_x);
        m.label = quest.name;
        m.scale = 2;
        OnlineMaps.instance.AddMarker(m);
        //OnlineMapsMarker.OnMarkerDrawTooltip.
    }
    public void DrawClues()
    {

    }
}
