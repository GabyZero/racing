using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public static GlobalController instance;

    /** data **/
    private  Dictionary<string, Color> car_colors;
    public  Dictionary<string,Color> Car_colors { get { return car_colors; } set { car_colors = value; } }

    private static HighScores hScores;
    public static HighScores HighScores { get { return hScores; } }
    public static bool IsHighScoresLoaded { get { return hScores != null; } }

    private void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Debug.Log("2 instances of GlobalController");
            Destroy(gameObject);
        }
    }

    public static void loadHighScores()
    {
        hScores = IOHightScore.get();
        if(hScores == null)
        {
            Debug.Log("creating empty hightscores");
            hScores = new HighScores();
            hScores.highScores = new List<MapHighScore>();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {

            HighScore hs = new HighScore();
            hs.seconds = 50f + Random.Range(0, 10);
            if (GlobalController.HighScores.highScores.Count < (PlayerPrefs.GetInt("map") + 1))
            {
                for (int i = 0; i <= PlayerPrefs.GetInt("map"); ++i)
                    GlobalController.HighScores.highScores.Add(new MapHighScore());
            }
            Debug.Log("adding");
            GlobalController.HighScores.highScores[PlayerPrefs.GetInt("map")].highScores.Add(hs); //using player prefs in not safe
            Debug.Log("Now " + HighScores.highScores[PlayerPrefs.GetInt("map")].highScores.Count);

        }
    }


}
