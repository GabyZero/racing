using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Used to change the colors part of a car
 **/
public class CustomizeColors : MonoBehaviour
{

    /** list of the customizable parts **/
    [SerializeField]
    List<MeshRenderer> customParts;

    public void setColors(Dictionary<string,Color> colors)
    {

        for (int i = 0; i < customParts.Count; ++i)
        {
            Color color;
            if (colors.TryGetValue(customParts[i].name, out color))
                customParts[i].materials[0].color = color;
        }

    }
}
