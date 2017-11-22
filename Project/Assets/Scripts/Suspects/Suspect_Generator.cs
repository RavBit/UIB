using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Suspect Generator:
 * Creates a suspect with a randomized design
 * Components that are randomized:
 * Hair, face, clothes
 */

public class Suspect_Generator : MonoBehaviour {
    //make lists for all the different components that will be randomized
    public Sprite[] sprites;
    private Suspect suspect;

    int randomHair;
    int randomFace;
    int randomClothes;

    //fill the lists
    void OnEnable() {
        suspect = GetComponent<Suspect>();
        GenerateSuspect();
        suspect.SetHairColor(GenerateColor());
        suspect.SetFaceColor(GenerateColor());
        suspect.SetClothesColor(GenerateColor());
    }

    private Color GenerateColor() {
        float randomR = UnityEngine.Random.Range(0f, 1f);
        float randomG = UnityEngine.Random.Range(0f, 1f);
        float randomB = UnityEngine.Random.Range(0f, 1f);

        return new Color(randomR, randomG, randomB);
    }

    public void GenerateSuspect() {
        randomHair = UnityEngine.Random.Range(0, 3);
        randomFace = UnityEngine.Random.Range(0, 3);
        randomClothes = UnityEngine.Random.Range(0, 3);

        Sprite hairSprite = sprites[randomHair];
        Sprite faceSprite = sprites[randomFace];
        Sprite clothesSprite = sprites[randomClothes];

        suspect.SetSuspect(hairSprite, faceSprite, clothesSprite);
    }
}
