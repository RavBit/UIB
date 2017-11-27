using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base_Suspect {
    public SpriteRenderer hairRenderer;
    public SpriteRenderer faceRenderer;
    public SpriteRenderer clothesRenderer;
    private bool isCulprit;

    //NEW ADDED FOR DATABASE DATA STORED
    public string Name;
    public string Description;
    public string Look;
    public float Height;
    //Suspect suspect;

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
