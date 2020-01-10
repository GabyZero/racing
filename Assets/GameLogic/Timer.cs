using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Timer that count time and calculate if the format minutes, seconds, milliseconds
 **/
public class Timer : MonoBehaviour
{
    public struct timer
    {
        public int minutes;
        public int seconds;
        public int milliseconds;
    }

    private timer time;
    public timer Time { get { return time; } }

    private float count;
    public float RawSeconds { get { return count; } }

    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        time.minutes = 0; time.seconds = 0; time.milliseconds = 0;
        running = false;
    }

    public string getString()
    {
        return string.Format("{0,2:00}:{1,2:00}:{2,3:000}", time.minutes, time.seconds, time.milliseconds);
    }

    public void setTime(float f)
    {
        time.minutes = Mathf.FloorToInt(f / 60);
        time.seconds = Mathf.FloorToInt(f % 60);
        time.milliseconds = Mathf.RoundToInt((f - (time.minutes * 60 + time.seconds)) * 1000);
    }

    public void Run()
    {
        running = true;
    }

    public void Stop()
    {
        running = false;
    }

    public void Reset()
    {
        count = 0;
        time.minutes = 0; time.seconds = 0; time.milliseconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            count += UnityEngine.Time.deltaTime;

            time.minutes = Mathf.FloorToInt(count / 60);
            time.seconds = Mathf.FloorToInt(count % 60);
            time.milliseconds = Mathf.RoundToInt((count - (time.minutes * 60 + time.seconds)) * 1000);

            //Debug.Log(count);
        }

        if (Input.GetKeyDown(KeyCode.R)) Run();
        if (Input.GetKeyDown(KeyCode.S)) Stop();
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) Reset();
    }
}
