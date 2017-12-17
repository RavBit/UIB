using System.Collections.Generic;

[System.Serializable]
public class Quest {
    public int id;
    public string name;
    public string description;
    public float start_x;
    public float start_y;
    public int curdialog;
    public List<Witness> witness;
    private OnlineMapsMarker dynamicMarker;
    public bool ClickAble;
    public List<Suspect> Suspects;
    public List<Quest_Clues> Clues;
    //TODO: DRAW CIRCLE AROUND MARKER
    //public List<UnityEngine.Vector2> cirpoints;
    //public OnlineMapsDrawingPoly StartPoly;
    public void AddInteraction() {
        OnlineMaps map = OnlineMaps.instance;

        // Add OnClick events to static markers
        foreach (OnlineMapsMarker marker in map.markers) {
            if (marker.label == name)
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

    private void OnMarkerClick(OnlineMapsMarkerBase marker) {
        Event_Manager.Toggle_Elements(DRAW_OBJECTS.Dialog, true, id);
    }

    public void RemoveInteraction() {
        dynamicMarker = null;
        ClickAble = false;
    }
} 
