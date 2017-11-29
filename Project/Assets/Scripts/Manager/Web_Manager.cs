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

        //Getting the quests for the server and split the string we return
        WWW questData = new WWW("http://81.169.177.181/UIB/request_quests.php");
        yield return questData;
        string questDataString = questData.text;
        Regex r_id = new Regex(@",(.+?),");
        Regex r_name = new Regex(@":(.+?):");
        Regex r_startx = new Regex(@"/(.+?)/");
        Regex r_starty = new Regex(@"#(.+?)#");
        MatchCollection mc_id = r_id.Matches(questDataString);
        MatchCollection mc_name = r_name.Matches(questDataString);
        MatchCollection mc_startx = r_startx.Matches(questDataString);
        MatchCollection mc_starty = r_starty.Matches(questDataString);

        for (int i = 0; i < mc_name.Count; i++) {
            //New Quest instantiate and insert the data into the database
            Quest q = new Quest();
            q.id = int.Parse(mc_id[i].Groups[1].Value);
            q.name = mc_name[i].Groups[1].Value;
            q.start_x = float.Parse(mc_startx[i].Groups[1].Value);
            q.start_y = float.Parse(mc_starty[i].Groups[1].Value);
            q.Suspects = new List<Suspect>();
            q.Clues = new List<Quest_Clues>();
            //Get the Quests dialogs from the server
            WWWForm form_dialog = new WWWForm();
            form_dialog.AddField("questDataPost", q.id);
            WWW questdialog_Data = new WWW("http://81.169.177.181/UIB/request_dialogs.php", form_dialog);
            yield return questdialog_Data;
            string[] quest_dialog = questdialog_Data.text.Split(';');
            List<string> quest_dialog_list = quest_dialog.ToList();
            q.dialogs = quest_dialog_list;
            q.dialogs.Remove(q.dialogs[q.dialogs.Count - 1]);
            //Get the Quests suspects from the server
            WWWForm form_suspects = new WWWForm();
            form_suspects.AddField("suspectDataPost", q.id);
            WWW questssuspects_Data = new WWW("http://81.169.177.181/UIB/request_suspects.php", form_suspects);
            yield return questssuspects_Data;
            Debug.Log(questssuspects_Data.text);
            string quest_suspects = questssuspects_Data.text;
            MatchCollection mc_sus_name = r_id.Matches(quest_suspects);
            MatchCollection mc_sus_desc = r_name.Matches(quest_suspects);
            MatchCollection mc_sus_look = r_startx.Matches(quest_suspects);
            MatchCollection mc_sus_height = r_starty.Matches(quest_suspects);
            for (int s = 0; s < mc_sus_name.Count; s++) {
                    Debug.Log(s + " / Quest " + q.name + " loading suspects");
                    Suspect S = new Suspect(mc_sus_name[s].Groups[1].Value, 
                                            mc_sus_desc[s].Groups[1].Value, 
                                            mc_sus_look[s].Groups[1].Value, 
                                            float.Parse(mc_sus_height[s].Groups[1].Value));
                    //S.Name = mc_sus_name[s].Groups[1].Value;
                    //S.Description = mc_sus_desc[s].Groups[1].Value;
                    //S.Look = (mc_sus_look[s].Groups[1].Value);
                    //S.Height = float.Parse(mc_sus_height[s].Groups[1].Value);
                    Debug.Log(mc_sus_name[s].Groups[1].Value);
                    Debug.Log(mc_sus_desc[s].Groups[1].Value);
                    Debug.Log(mc_sus_look[s].Groups[1].Value);
                    Debug.Log(float.Parse(mc_sus_height[s].Groups[1].Value));
                    if(S.Name != null)
                        q.Suspects.Add(S);   
            }
            WWWForm form_clues = new WWWForm();
            form_clues.AddField("cluesDataPost", q.id);
            WWW form_clues_Data = new WWW("http://81.169.177.181/UIB/request_clues.php", form_clues);
            yield return form_clues_Data;
            Debug.Log(form_clues_Data.text);
            string[] quest_clues = form_clues_Data.text.Split(';');
            List<string> quest_clues_list = quest_clues.ToList();
            for (int c = 0; c < quest_clues_list.Count; c++)
            {
                Quest_Clues C = new Quest_Clues();
                C.clue = quest_clues_list[c];
                C.found = false;
                if (C.clue != null)
                    q.Clues.Add(C);
            }
            q.Clues.Remove(q.Clues[q.Clues.Count - 1]);
            Event_Manager.Add_Quest(q);
        }
        Event_Manager.Draw_Quest(DRAW_OBJECTS.Quest);
    }
}
