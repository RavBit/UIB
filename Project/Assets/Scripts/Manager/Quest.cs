using System.Collections.Generic;

[System.Serializable]
public class Quest {
    public string name;
    public float start_x;
    public float start_y;
    private OnlineMapsMarker dynamicMarker;
    public bool ClickAble;
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

        // Add OnClick events to dynamic markers
        dynamicMarker = map.AddMarker(UnityEngine.Vector2.zero, null, "Dynamic marker");
        dynamicMarker.OnClick += OnMarkerClick;
        ClickAble = true;
    }

    private void OnMarkerClick(OnlineMapsMarkerBase marker) {
        // Show in console marker label.
        UnityEngine.Debug.Log(marker.label);
    }

    public void RemoveInteraction() {
        dynamicMarker = null;
        ClickAble = false;
    }
} 
