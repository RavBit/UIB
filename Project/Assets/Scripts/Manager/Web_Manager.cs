using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using System;


public class Web_Manager : MonoBehaviour
{
    public static Web_Manager instance;
    public string[] words;
    public List<Suspect> test;
    public List<Quest> _questdata;
    public List<Witness> _temp;
    public Witness[] wtest;
   
    void Awake()
    {
        if (instance != null)
            Debug.LogError("More than one App Manager in the scene");
        else
            instance = this;
    }
    public IEnumerator LoadQuests()
    {
        //Command gescheiden bestand CSV
        // ! https://www.mysql.com/products/workbench/
        WWW questdata = new WWW("http://81.169.177.181/UIB/request_quests.php");
        yield return questdata;
        Debug.Log(questdata.text);
        if (string.IsNullOrEmpty(questdata.error))
        {
            _questdata = JsonHelper.getJsonArray<Quest>(questdata.text).ToList<Quest>();
            for (int i = 0; i < _questdata.Count; i++)
            {
                WWWForm quest_id = new WWWForm();
                quest_id.AddField("quest_id", _questdata[i].id);
                WWW witnessdata = new WWW("http://81.169.177.181/UIB/request_witness.php", quest_id);
                yield return witnessdata;
                _questdata[i].witness = JsonHelper.getJsonArray<Witness>(witnessdata.text).ToList<Witness>();
                for (int j = 0; j < _questdata[i].witness.Count; j++)
                {
                    WWWForm witness_id = new WWWForm();
                    witness_id.AddField("witness_id", _questdata[i].witness[j].id);
                    WWW w = new WWW("http://81.169.177.181/UIB/request_dialogs.php", witness_id);
                    yield return w;
                    _questdata[i].witness[j].dialogs = JsonHelper.getJsonArray<Quest_BaseDialog>(w.text).ToList<Quest_BaseDialog>();
                }
                WWW suspectdata = new WWW("http://81.169.177.181/UIB/request_suspects.php", quest_id);
                yield return suspectdata;
                _questdata[i].Suspects = JsonHelper.getJsonArray<Suspect>(suspectdata.text).ToList<Suspect>();
                WWW cluesdata = new WWW("http://81.169.177.181/UIB/request_clues.php", quest_id);
                yield return cluesdata;
                _questdata[i].Clues = JsonHelper.getJsonArray<Quest_Clues>(cluesdata.text).ToList<Quest_Clues>();
            }
        }
        else
        {
            Debug.LogError("ERROR FATAL");
        }
        Event_Manager.Set_QuestList(_questdata);
        //_questdata.Clear();
    }
}
