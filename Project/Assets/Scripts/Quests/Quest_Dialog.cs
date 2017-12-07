using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Quest_Dialog : MonoBehaviour {
    [Header("UI Attributes")]
    public Text Name;
    public Text Dialog;
    public GameObject Suspect_Item;
    public GameObject Suspect_Container;
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
            GameObject g = Instantiate(Suspect_Item, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            g.GetComponent<Suspect_Item>().Name.text = sus.name;
            g.transform.parent = Suspect_Container.transform;
        }
    }
	
}
