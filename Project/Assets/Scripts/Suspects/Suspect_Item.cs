using UnityEngine;
using UnityEngine.UI;
public class Suspect_Item : MonoBehaviour {
    public string suspectName;
    public string description;
    public string look;
    public float height;

    public SpriteRenderer hairRenderer;
    public SpriteRenderer faceRenderer;
    public SpriteRenderer clothesRenderer;
    public GameObject suspectBody;
    public GameObject suspectHair;
    private SpriteRenderer bodySR;
    private SpriteRenderer hairSR;
    private bool isCulprit;
    private char[] lookArray;


    public Text Name;

    //ADD CLOTHING GENERATOR AND SUCH
    public Suspect_Item(string n, string d, string l, float h) {
        suspectName = n;
        description = d;
        look = l;
        height = h;
        lookArray = look.ToCharArray();


        Sprite body;
        Sprite hair;

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

        suspectBody = new GameObject();
        suspectBody.name = name;
        bodySR = suspectBody.AddComponent<SpriteRenderer>();
        suspectHair = new GameObject();
        suspectHair.name = name + " hair";
        suspectHair.transform.SetParent(suspectBody.transform);
        hairSR = suspectHair.AddComponent<SpriteRenderer>();
    }
}