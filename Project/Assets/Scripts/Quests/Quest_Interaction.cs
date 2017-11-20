using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Interaction : MonoBehaviour {
    /*public float radius = 64; //pixels
    public int segments = 16;

    private OnlineMapsDrawingPoly poly;
    private OnlineMaps map;
    private OnlineMapsMarker marker;
    private Vector2 markerPosition;

    //Quest Manager
    private Quest_Manager QM;
    private void Start() {
        map = OnlineMaps.instance;
        QM = GetComponent<Quest_Manager>();
        Event_Manager.AddQuestCircles += DrawQuestPoints;
    }
    public void DrawQuestPoints(Quest quest) {
        quest.cirpoints = new List<Vector2>(segments);
        for (int i = 0; i < segments; i++) quest.cirpoints.Add(new Vector2());

        // Create poly
        quest.StartPoly = new OnlineMapsDrawingPoly(quest.cirpoints, Color.green, 3);
        UpdateCircle(quest);
        map.AddDrawingElement(quest.StartPoly);
    }
    private void UpdateCircle(Quest quest) {
        float r = radius / OnlineMapsUtils.tileSize;
        float step = 360f / segments;
        double x, y;
        x = quest.start_x;
        y = quest.start_y;
        // Old way (Online Maps v2.3):
        // OnlineMapsUtils.LatLongToTiled(x, y, map.zoom, out x, out y);

        OnlineMapsProjection projection = map.projection;
        projection.CoordinatesToTile(x, y, map.zoom, out x, out y);

        for (int i = 0; i < segments; i++) {
            double px = x + Mathf.Cos(step * i * Mathf.Deg2Rad) * r;
            double py = y + Mathf.Sin(step * i * Mathf.Deg2Rad) * r;
            // Old way (Online Maps v2.3):
            // OnlineMapsUtils.TileToLatLong(px, py, map.zoom, out px, out py);

            projection.TileToCoordinates(px, py, map.zoom, out px, out py);

            quest.cirpoints[i] = new Vector2((float)px, (float)py);
        }
    }*/
}
