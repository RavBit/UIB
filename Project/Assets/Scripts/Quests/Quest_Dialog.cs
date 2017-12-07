using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Quest_Dialog : MonoBehaviour {
    [Header("UI Attributes")]
    public Text Name;
    public Text Dialog;
    public GameObject Suspects;
    public Suspect_Item Suspect_Item;
    private void Awake() {
        Event_Manager.DialogLoad += SetDialog;
    }
    public void SetDialog(string _name, string _dialog, List<Suspect> _suspects) {
        Name.text = _name;
        Dialog.text = _dialog;
        InitSuspects(_suspects);
    }

    public void InitSuspects(List<Suspect> _suspect) {
        foreach(Suspect sus in _suspect) {

            Debug.Log("");//Instantiate(brick, Vector3(x, y, 0), Quaternion.identity);
        }
    }
	
}
