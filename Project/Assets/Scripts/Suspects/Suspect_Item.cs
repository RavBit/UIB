using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Suspect_Item : MonoBehaviour {
    public string suspectName;
    public string description;
    public string look;
    public float height;
    private GameObject suspectParent;
    
    public GameObject suspectBody;
    public GameObject suspectHair;
    private SpriteRenderer bodySR;
    private SpriteRenderer hairSR;
    private bool isCulprit;
    private char[] lookArray;
    private Sprite body;
    private Sprite hair;


    public Text Name;
    
    public Suspect_Item(string n, string d, string l, float h) {
        suspectName = n;
        description = d;
        look = l;
        height = h;
    }

    void OnEnable () {
        suspectBody = gameObject;
        StartCoroutine("FillArray");
    }

    private IEnumerator FillArray() {
        yield return new WaitForSeconds(1);
        if (GameObject.Find(suspectName + " hair") == null) {
            bodySR = suspectBody.AddComponent<SpriteRenderer>();
            suspectHair = new GameObject();
            suspectHair.transform.SetParent(suspectBody.transform);
            hairSR = suspectHair.AddComponent<SpriteRenderer>();

        }
        suspectBody.name = suspectName;
        suspectHair.name = suspectName + " hair";

        lookArray = look.ToCharArray();

        if (lookArray[0] == 'A' && lookArray[1] == 'A') {
            body = Resources.Load<Sprite>("Sprites/Body/Male");
        }
        else {
            body = Resources.Load<Sprite>("Sprites/Body/Female");
        }
        bodySR.sprite = body;

        if (lookArray[2] == 'a') {
            hair = Resources.Load<Sprite>("Sprites/Hair/Square");
        }
        else {
            hair = Resources.Load<Sprite>("Sprites/Hair/Triangle");
        }
        hairSR.sprite = hair;
    }

    public void SelectSuspect() {
        //this should check if the accusion script is enabled in the scene
        Accusion.SetSuspect(this);
        //show a little border around it or something
    }
}
