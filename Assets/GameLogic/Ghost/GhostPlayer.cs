using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    public Ghost ghost;

    float lastframe;

    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("ghost"));
        if (PlayerPrefs.GetString("ghost") == "")
        {
            Debug.Log("No Ghost");
            gameObject.SetActive(false);
        }
        else
        {
            ghost = DataSaver.loadData<Ghost>(PlayerPrefs.GetString("ghost"));

            PlayPart();
        }
    }

    void PlayPart()
    {
        lastframe = Time.time;
        GhostPart tmp = ghost.record[frame];
        transform.position = tmp.position;
        transform.rotation = tmp.rotation;

        //Vector3.Lerp
        //Quaternion.Lerp

        ghost.record.Add(tmp);
        frame++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastframe >= ghost.freq)
            PlayPart();
    }
}
