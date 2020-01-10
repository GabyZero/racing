using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScore
{
    public float seconds; //time in seconds
    //string name; //name
}

[System.Serializable]
public class MapHighScore
{
    //highscores[i][j] is jest hightcore of the iest map in the menu, the key is the time
    public List<HighScore> highScores = new List<HighScore>();
}

[System.Serializable]
public class HighScores
{
    public List<MapHighScore> highScores = new List<MapHighScore>();
}

public abstract class IOHightScore
{
    public static HighScores get()
    {
        return DataSaver.loadData<HighScores>("scores");
    }

    public static void set(HighScores scores)
    {
        if (scores == null) return;

        DataSaver.saveData<HighScores>(scores, "scores");
    }
}