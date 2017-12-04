using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_Suspect {
    public SpriteRenderer hairRenderer;
    public SpriteRenderer faceRenderer;
    public SpriteRenderer clothesRenderer;
    public GameObject suspectBody;
    public GameObject suspectHair;
    private SpriteRenderer bodySR;
    private SpriteRenderer hairSR;
    private bool isCulprit;
    private char[] lookArray;

    //NEW ADDED FOR DATABASE DATA STORED
    public string Name;
    public string Description;
    public string Look;
    public float Height;

    public Base_Suspect(string n, string d, string l, float h) {
        Name = n;
        Description = d;
        Look = l;
        Height = h;
        lookArray = Look.ToCharArray();
        suspectBody = new GameObject();
        suspectBody.name = Name;
        bodySR = suspectBody.AddComponent<SpriteRenderer>();
        suspectHair = new GameObject();
        suspectHair.name = Name + " hair";
        suspectHair.transform.SetParent(suspectBody.transform);
        hairSR = suspectHair.AddComponent<SpriteRenderer>();
        Sprite body;
        Sprite hair;

        if (lookArray[0] == 'A' && lookArray[1] == 'A') {
            body = Resources.Load<Sprite>("Sprites/Body/Male");
        } else {
            body = Resources.Load<Sprite>("Sprites/Body/Female");
        }
        bodySR.sprite = body;
        
        if (lookArray[2] == 'a') {
            hair = Resources.Load<Sprite>("Sprites/Hair/Square");
        } else {
            hair = Resources.Load<Sprite>("Sprites/Hair/Triangle");
        }
        hairSR.sprite = hair;
    }

    public void SetSuspect(Sprite newHair, Sprite newFace, Sprite newClothes) {
        hairRenderer.sprite = newHair;
        faceRenderer.sprite = newFace;
        clothesRenderer.sprite = newClothes;
    }

    public void SetHairColor(Color color) {
        hairRenderer.color = color;
    }

    public void SetFaceColor(Color color) {
        faceRenderer.color = color;
    }

    public void SetClothesColor(Color color) {
        clothesRenderer.color = color;
    }
}
