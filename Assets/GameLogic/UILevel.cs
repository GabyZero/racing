using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Take a level and display information
 * Doesn't take care of the timer
 **/
public class UILevel : MonoBehaviour
{
    [SerializeField]
    private LevelManager manager;

    [SerializeField]
    private TMPro.TextMeshProUGUI lap;

    [SerializeField]
    private TMPro.TextMeshProUGUI cp;

    // Start is called before the first frame update
    void Start()
    {
        if (manager == null) throw new UnityException("manager null");
        if (lap == null) throw new UnityException("lap null");
        if (cp == null) throw new UnityException("cp null");
    }

    // Update is called once per frame
    void Update()
    {
        lap.text = "" + manager.CurrentLap + "/" + manager.NbLap;

        cp.text = "" + manager.CurrentCP + "/" + manager.NbCheckpoint;
    }
}
