using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        StartCoroutine("GetDialog", 1);
    }
    public IEnumerator SelectField()
    {
        //Command gescheiden bestand CSV
        // ! https://www.mysql.com/products/workbench/
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
            Quest q = new Quest();
            q.id = int.Parse(mc_id[i].Groups[1].Value);
            q.name = mc_name[i].Groups[1].Value;
            q.start_x = float.Parse(mc_startx[i].Groups[1].Value);
            q.start_y = float.Parse(mc_starty[i].Groups[1].Value);
            Event_Manager.Add_Quest(q);
        }
        Event_Manager.Draw_Quest(DRAW_OBJECTS.Quest);
    }
    public IEnumerator GetDialog(int questid) {
        WWWForm form = new WWWForm();
        form.AddField("questDataPost", questid);
        //Command gescheiden bestand CSV
        // ! https://www.mysql.com/products/workbench/
        WWW questData = new WWW("http://81.169.177.181/UIB/request_dialogs.php", form);
        yield return questData;
        string questDataString = questData.text;
        words = questDataString.Split(';');
        Event_Manager.Insert_Dialog(questid, words);
    }
}
