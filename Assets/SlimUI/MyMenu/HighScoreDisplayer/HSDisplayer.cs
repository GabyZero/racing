using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSDisplayer : MonoBehaviour
{
    //entry prefab
    [SerializeField]
    private GameObject p_entry;

    //entry parent
    [SerializeField]
    private GameObject parent;

    public void loadEntriesFromMap(int id)
    {
        for (int i = 0; i < parent.transform.childCount; ++i)
            Destroy(parent.transform.GetChild(i).gameObject);
        HighScores hss = GlobalController.HighScores;
        if(hss ==null || hss.highScores ==null|| hss.highScores.Count ==0 || hss.highScores.Count <=id || hss.highScores[id].highScores.Count == 0)
        {
            GameObject go = Instantiate(p_entry, parent.transform);
            go.GetComponentInChildren<UnityEngine.UI.Text>().text = "No scores";
        }
        else
        {
            Timer tm = gameObject.AddComponent<Timer>();
            int nb = 0;
            foreach(HighScore hs in hss.highScores[id].highScores)
            {
                GameObject go = Instantiate(p_entry, parent.transform);

                tm.setTime(hs.seconds);
                go.GetComponentInChildren<UnityEngine.UI.Text> ().text = tm.getString();

                go.GetComponent<RectTransform>().anchoredPosition -= nb * new Vector2(0,go.GetComponent<RectTransform>().rect.size.y);

                go.AddComponent<SetGhost>().id = nb;

                go.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=>
                {
                    go.GetComponent<SetGhost>().setGhost();
                });

                nb++;
            }

            Destroy(tm);
        }
    }
}
