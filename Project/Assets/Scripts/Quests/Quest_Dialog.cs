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
        Web_Manager.instance.StartCoroutine("StartQuest", CurQuest);

    }
    public void InitSuspects(List<Suspect> _suspect) {
        foreach(Suspect sus in _suspect) {
            Suspect S = new Suspect(sus.name, sus.description, sus.look, sus.height);
            //GameObject g = Instantiate(Suspect_Item, Suspect_Container.transform.position, Quaternion.identity) as GameObject;
            //g.GetComponent<Suspect_Item>().Name.text = sus.name;
            //g.transform.SetParent(Suspect_Container.transform);
        }
    }

    public void CloseAndSafeClues()
    {
        Debug.Log("Close and Save Clues");
        Event_Manager.Save_QuestClues();
        OnlineMaps.instance.RemoveAllMarkers();
        Quest_Manager.Load_Quest();

    }
	
}
