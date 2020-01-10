using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : MonoBehaviour
{
    public void setMap(int n)
    {
        PlayerPrefs.SetInt("map", n);

        PlayerPrefs.SetString("ghost", "");
    }
}
