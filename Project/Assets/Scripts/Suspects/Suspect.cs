
/* Suspect:
 * Has sprites for hair, face, clothing
 * Is a culprit or not
 */

[System.Serializable]
public class Suspect : Base_Suspect {


    //public Suspect GetSuspect() {
    //    return suspect;
    //}

    public Suspect(string n, string d, string l, float h) : base(n, d, l, h) {
    }
}
