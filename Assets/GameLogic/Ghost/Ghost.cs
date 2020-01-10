using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GhostPart
{
    public Vector3 position;
    public Quaternion rotation;
}

/**
 * Record of a play
 **/
[System.Serializable]
public class Ghost 
{
    public float freq=0.007f; //100 part per second
    public List<GhostPart> record = new List<GhostPart>();

    //should remeber the color
}
