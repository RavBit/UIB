using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;

public class Web_Manager : MonoBehaviour {
    public static Web_Manager instance;
    public string[] words;
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
        
        for (int i = 0; i < mc_name.Count; i++)
        {
            //New Quest instantiate and insert the data into the database
            Quest q = new Quest();
            q.id = int.Parse(mc_id[i].Groups[1].Value);
            q.name = mc_name[i].Groups[1].Value;
            q.start_x = float.Parse(mc_startx[i].Groups[1].Value);
            q.start_y = float.Parse(mc_starty[i].Groups[1].Value);

            //Get the Quests dialogs from the server
            WWWForm form_dialog = new WWWForm();
            form_dialog.AddField("questDataPost", q.id);
            WWW questdialog_Data = new WWW("http://81.169.177.181/UIB/request_dialogs.php", form_dialog);
            yield return questdialog_Data;
            string[] quest_dialog = questdialog_Data.text.Split(';');
            List<string> quest_dialog_list = quest_dialog.ToList();
            q.dialogs = quest_dialog_list;
            q.dialogs.Remove(q.dialogs[q.dialogs.Count - 1]);
            Event_Manager.Add_Quest(q);
        }
        Event_Manager.Draw_Quest(DRAW_OBJECTS.Quest);
    }
}
