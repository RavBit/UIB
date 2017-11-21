using UnityEngine;
using UnityEngine.UI;
public class Quest_Dialog : MonoBehaviour {
    [Header("UI Attributes")]
    public Text Name;
    public Text Dialog;
    public GameObject Suspects;
    private void Awake() {
        Event_Manager.DialogLoad += SetDialog;
    }
    public void SetDialog(string _name, string _dialog) {
        Debug.Log("Name: " + _name + " _Dialog " + _dialog);
    }

    public void TestFunction() {
        Debug.Log("Hallo");
    }
	
}
