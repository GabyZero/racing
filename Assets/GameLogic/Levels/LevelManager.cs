using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manage a level **/
public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private CheckPoint startCheckpoint;

    [SerializeField]
    private List<CheckPoint> checkpoints;

    public int NbCheckpoint { get { return checkpoints.Count; } }

    [SerializeField]
    private int nbLap;
    public int NbLap { get { return nbLap; } }

    // timer used for this level
    [SerializeField]
    private Timer timer;

    /** current checkpoint, 0 is start **/ 
    private int currentCP;
    public int CurrentCP { get { return currentCP; } }

    private int currentLap;
    public int CurrentLap { get { return currentLap; } }

    
    /** player **/
    public GameObject player;


    /** camera**/
    public VehiclePhysics.VPCameraController cameraController;

    /** Events **/

    /** A checkpoint has been passed **/
    [SerializeField]
    private UnityEngine.Events.UnityEvent checkpoint;

    /** A lap has been completed **/
    [SerializeField]
    private UnityEngine.Events.UnityEvent lap;

    /** The level has been completed **/
    [SerializeField]
    private UnityEngine.Events.UnityEvent end;

    [Header("UI")]

    /** LOADING MENU **/
    [SerializeField]
    private UnityEngine.UI.Slider loadBar;

    [SerializeField]
    private TMPro.TMP_Text finishedLoadingText;

    /** score **/
    [SerializeField]
    private TMPro.TMP_Text score;


    // Start is called before the first frame update
    void Start()
    {
        currentCP = 0;
        currentLap = 0;

        if (nbLap == 0) throw new UnityException("A level must have at least 1 lap");
        // a level can have 0 checkpoint
        if (startCheckpoint == null) throw new UnityException("A level must have a start");

        //TODO: choose car

        player.GetComponent<CustomizeColors>().setColors(GlobalController.instance.Car_colors);
        LastCheckpoint(); //position 
        player.transform.position -= (player.transform.forward * 5 );
        player.GetComponent<VehiclePhysics.VPResetVehicle>().DoReset();
        cameraController.ResetCamera();
    
        StartCoroutine(Begin());
    }

    IEnumerator Begin()
    {
        //block the brake
        player.GetComponent<VehiclePhysics.VPStandardInput>().externalHandbrake = 1;
        yield return new WaitForEndOfFrame();

        //desactive camera
        /*cameraController.enabled = false;
        cameraController.GetComponent<Animator>().enabled = true;*/

        yield return new WaitForSeconds(1);
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        yield return new WaitForSeconds(1);
        player.GetComponent<VehiclePhysics.VPStandardInput>().externalHandbrake = 0;
        timer.Run();
        //GetComponent<>
    }

    public void CheckpointTriggered(int chckId)
    {
        Debug.Log("Event received with id = " + chckId);
        if(currentCP + 1 == chckId )
        {
            currentCP++;

            checkpoint.Invoke();
            Debug.Log("CHECKPOINT");
        }
        else if(currentCP + 1 >= checkpoints.Count && chckId == 0)
        {
            if (currentLap +1 == nbLap)
            {
                timer.Stop();
                currentLap++;
                end.Invoke();
                Debug.Log("END");

                score.SetText(timer.getString());
                HighScore hs = new HighScore();
                hs.seconds = timer.RawSeconds;

                if (GlobalController.HighScores.highScores.Count < (PlayerPrefs.GetInt("map")+1))
                {
                    for (int i = 0; i <= PlayerPrefs.GetInt("map"); ++i)
                        GlobalController.HighScores.highScores.Add(new MapHighScore());
                }
                    
                GlobalController.HighScores.highScores[PlayerPrefs.GetInt("map")].highScores.Add(hs); //using player prefs in not safe

                Ghost ghost = GetComponent<GhostRecorder>().ghost;

                DataSaver.saveData<Ghost>(ghost, "ghostM" + PlayerPrefs.GetInt("map") + "ID" + (GlobalController.HighScores.highScores[PlayerPrefs.GetInt("map")].highScores.Count - 1));
            }
            else
            {
                currentLap++;

                currentCP = 0;
                lap.Invoke();
                Debug.Log("LAP");


            }
        }
    }

    public void LastCheckpoint()
    {
        if(currentCP == 0)
        {
            player.transform.SetPositionAndRotation(startCheckpoint.transform.position, startCheckpoint.transform.rotation);
            player.transform.Rotate(Vector3.up, 180); //start checkkpoint rotation is inversed
        }
        else
        {
            player.transform.SetPositionAndRotation(checkpoints[currentCP-1].transform.position, checkpoints[currentCP - 1].transform.rotation);
            //player.transform.Rotate(Vector3.up, 180);
        }
        player.GetComponent<VehiclePhysics.VPResetVehicle>().DoReset();
        cameraController.ResetCamera();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadAsynchronously("Menus"));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    { 
        // scene name is just the name of the current scene being loaded
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        IOHightScore.set(GlobalController.HighScores);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadBar.value = progress;

            if (operation.progress >= 0.9f)
            {
                finishedLoadingText.gameObject.SetActive(true);

                if (Input.anyKeyDown)
                {
                    Time.timeScale = 1;
                    AudioListener.pause = false;
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
