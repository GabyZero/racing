using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    public Ghost ghost;

    private float lastframe;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ghost = new Ghost();
        NewPart();
    }

    void NewPart()
    {
        lastframe = Time.time;
        GhostPart tmp = new GhostPart();
        tmp.position = player.transform.position;
        tmp.rotation = player.transform.rotation;

        ghost.record.Add(tmp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastframe >= ghost.freq)
            NewPart();
    }
}
