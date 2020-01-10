using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Create the map used to customize a car
 **/
public class RegisterColors : MonoBehaviour
{
    //customizable parts
    [SerializeField]
    private MeshRenderer[] renderers;

    public Dictionary<string, Color> getMap()
    {
        Dictionary<string, Color> res = new Dictionary<string, Color>();
        foreach(MeshRenderer mr in renderers)
        {
            res.Add(mr.name, mr.materials[0].color);
        }

        return res;

    }
}
