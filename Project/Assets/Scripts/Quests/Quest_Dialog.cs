using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Quest_Dialog : MonoBehaviour {
    [Header("UI Attributes")]
    public Text Name;
    public Text Dialog;
    public GameObject Suspect_Item;
    public GameObject Suspect_Container;
    public Quest CurQuest;

    public Draw_Manager DM;
    private void Awake() {
        Event_Manager.DialogLoad += SetDialog;
    }
    public void SetDialog(Quest _quest, List<Suspect> _suspects) {
        CurQuest = _quest;
        Name.text = _quest.name;
        Dialog.text = _quest.description;
        InitSuspects(_suspects);
    }
    public void StartQuest()
    {
        OnlineMaps.instance.RemoveMarker(DM.GetM());
        Web_Manager.instance.StartCoroutine("StartQuest", CurQuest);

    }
    public void InitSuspects(List<Suspect> _suspect) {
        /*
        foreach(Suspect sus in _suspect) {
            GameObject g = Instantiate(Suspect_Item, Suspect_Container.transform.position, Quaternion.identity) as GameObject;
            Suspect_Item si = g.GetComponent<Suspect_Item>();
            si.suspectName = sus.name;
            si.description = sus.description;
            si.look = sus.look;
            si.height = sus.height;
            g.transform.SetParent(Suspect_Container.transform);
        }
        */
    }

    public void CloseAndSafeClues()
    {
        Debug.Log("Close and Save Clues");
        Event_Manager.Save_QuestClues();
        Quest_Manager.Load_Quest();

    }

    public void DeclineQuest() {
        GameObject[] sus = GameObject.FindGameObjectsWithTag("Suspect");
        foreach(GameObject obj in sus) {
            Destroy(obj);
        }
    }
	
}
