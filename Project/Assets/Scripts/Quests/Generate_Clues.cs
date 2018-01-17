using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Clues : MonoBehaviour {

    /// <summary>
    /// Google API Key
    /// </summary>
    public Position_Manager PM;
    public string apiKey;
    public int tempcounter = 0;
    public int counter = 0;
    public string _name = "";
    public Texture2D ClueMarker;
    public List<Clue_Map> CM;
    private void Start() {
        Event_Manager.GenerateClues += Generate_Clue;
        PM = GetComponent<Position_Manager>();
    }
    public void Generate_Clue(List<Clue_Map> ClueMap) {
        OnlineMaps.instance.Redraw();
        double x = OnlineMapsLocationService.instance.GetLocationX();
        double y = OnlineMapsLocationService.instance.GetLocationY();
        OnlineMaps.instance.Redraw();
        counter = ClueMap.Count;
        CM = new List<Clue_Map>();
        Debug.Log("CM COUNT " + ClueMap.Count);
        CM = ClueMap;
        // Makes a request to Google Places API.
        OnlineMapsGooglePlaces.FindNearby(
            apiKey,
            new OnlineMapsGooglePlaces.NearbyParams(
                x, // Longitude
                y, // Latitude
                500) // Radius
            {
                types = "school"
            }).OnComplete += OnComplete;
    }

    /// <summary>
    /// This method is called when a response is received.
    /// </summary>
    /// <param name="s">Response string</param>
    private void OnComplete(string s) {
        // Trying to get an array of results.
        OnlineMapsGooglePlacesResult[] results = OnlineMapsGooglePlaces.GetResults(s);

        // If there is no result
        if (results == null) {
            Debug.Log("Error");
            Debug.Log(s);
            return;
        }

        List<OnlineMapsMarker> markers = new List<OnlineMapsMarker>();
        foreach (OnlineMapsGooglePlacesResult result in results) {
            if (tempcounter < counter)
            {
                tempcounter++;
                CM[tempcounter - 1].pos = new Position();
                Debug.Log("TEMPCOUNTER " + tempcounter + " AND COUNTER " + counter);
                // Create a marker at the location of the result.
                OnlineMapsMarker marker = OnlineMaps.instance.AddMarker(PM.FQ_Clues[tempcounter - 1].pos_y, PM.FQ_Clues[tempcounter - 1].pos_x, "??");
                marker.label = "C" + (tempcounter -1);
                //CM[tempcounter - 1].pos.pos_x = PM.FQ_Clues[tempcounter - 1].pos_y;
                //CM[tempcounter - 1].pos.pos_y = PM.FQ_Clues[tempcounter - 1].pos_x;
                marker.texture = ClueMarker;
                marker.scale = 2;
                marker.Init();
                markers.Add(marker);
                CM[tempcounter - 1].AddInteraction(tempcounter - 1);
            }
        }
    }
}
