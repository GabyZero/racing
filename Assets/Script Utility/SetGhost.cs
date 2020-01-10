using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGhost : MonoBehaviour
{
    public int id;

    public void setGhost()
    {
        PlayerPrefs.SetString("ghost", "ghostM" + PlayerPrefs.GetInt("map") + "ID" + id);
    }
}
