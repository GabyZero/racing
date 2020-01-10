using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Take a timmer and create the display in format MM SS mm
 **/
public class UITimer : MonoBehaviour
{
 
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private TMPro.TextMeshProUGUI minutes;

    [SerializeField]
    private TMPro.TextMeshProUGUI seconds;

    [SerializeField]
    private TMPro.TextMeshProUGUI milliseconds;

    // Start is called before the first frame update
    void Start()
    {
        if (timer == null) throw new UnityException("UITimer need a timer");
    }

    // Update is called once per frame
    void Update()
    {

        minutes.text = ((timer.Time.minutes < 10) ? "0" : "")+timer.Time.minutes;
        seconds.text = ((timer.Time.seconds < 10) ? "0" : "") + timer.Time.seconds;
        milliseconds.text = ((timer.Time.milliseconds < 10) ? "00" : ((timer.Time.milliseconds<100)?"0":"")) + timer.Time.milliseconds;
    }
}
