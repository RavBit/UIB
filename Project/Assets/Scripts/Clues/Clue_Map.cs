using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Clue_Map {
    public List<Quest_Clues> clues;
    public Position pos;
    public bool ClickAble;
    private OnlineMapsMarker dynamicMarker;

    public void AddInteraction(int id)
    {
        OnlineMaps map = OnlineMaps.instance;

        // Add OnClick events to static markers
        foreach (OnlineMapsMarker marker in map.markers)
        {
            if (marker.label == "C" + id)
                marker.OnClick += OnMarkerClick;
        }

        //foreach(Suspect suspect in Suspects) {
        //Suspect_Item SI = new Suspect_Item(suspect.name, suspect.description, suspect.look, suspect.height);
        //}

        // Add OnClick events to dynamic markers
        dynamicMarker = map.AddMarker(UnityEngine.Vector2.zero, null, "Dynamic marker");
        dynamicMarker.OnClick += OnMarkerClick;
        ClickAble = true;
    }

    private void OnMarkerClick(OnlineMapsMarkerBase marker)
    {
        if (ClickAble) {
            ClueDisplay.instance.LoadClues(clues);
            ClueDisplay.instance.StartAR();
        }
    }
}
