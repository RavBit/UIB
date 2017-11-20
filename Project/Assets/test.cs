using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public float radius = 64; //pixels
    public int segments = 16;

    private OnlineMapsDrawingPoly poly;
    public List<Vector2> points;
    private OnlineMaps map;
    private OnlineMapsMarker marker;
    private Vector2 markerPosition;

    private void Start() {
        map = OnlineMaps.instance;

        // Init points
        points = new List<Vector2>(segments);
        for (int i = 0; i < segments; i++) points.Add(new Vector2());

        // Create poly
        poly = new OnlineMapsDrawingPoly(points, Color.green, 3);

        marker = map.AddMarker(new Vector2(OnlineMapsLocationService.instance.GetLocationX(), OnlineMapsLocationService.instance.GetLocationY()), "Center of circle");
        markerPosition = marker.position;
        Debug.Log("Marker position " + marker.position);
        // Draw circle
        UpdateCircle();

        map.AddDrawingElement(poly);
    }

    private void Update() {
        if (markerPosition != marker.position) UpdateCircle();
    }

    private void UpdateCircle() {
        float r = radius / OnlineMapsUtils.tileSize;
        float step = 360f / segments;
        double x, y;
        marker.GetPosition(out x, out y);
        Debug.Log("test");
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

            points[i] = new Vector2((float)px, (float)py);
        }
    }
}