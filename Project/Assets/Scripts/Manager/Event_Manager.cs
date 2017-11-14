using UnityEngine;

public class Event_Manager : MonoBehaviour {
    
    //Delegate to load in objects
    public delegate void LoadObjects();
    public static event LoadObjects LoadQuest;

    //Delegate to add Quest to the QuestManager;
    public delegate void QuestData(Quest quest);
    public static event QuestData AddQuest;

    //Loads in Objects in the scene and deletes other markers or data
    public static void Load_Objects(LOAD_OBJECTS lo)
    {
        switch (lo)
        {
            case LOAD_OBJECTS.Quest:
                LoadQuest();
                break;
            case LOAD_OBJECTS.Userdata:
                break;
        }
        LoadQuest();
    }
    public static void Add_Quest(Quest quest)
    {
        AddQuest(quest);
    }
}
public enum LOAD_OBJECTS
{
    Quest,
    Userdata
}