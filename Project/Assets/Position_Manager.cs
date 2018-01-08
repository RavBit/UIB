using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Manager : MonoBehaviour {
    [Header("First Quest Positions")]
    public List<Position> FQ_Clues;
    public List<Position> FQ_Dialogs;
}


[System.Serializable]
public class Position
{
    public double pos_x;
    public double pos_y;
}
