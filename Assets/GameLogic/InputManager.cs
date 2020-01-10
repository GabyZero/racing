using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** manage the input that are not used for driving the car **/
public class InputManager : MonoBehaviour
{

    /** return to the last checkpoint **/
    [SerializeField]
    private KeyCode lastCheckpoint;

    public UnityEngine.Events.UnityEvent lastCheckpointEvent;

    /** pause**/
    [SerializeField]
    private KeyCode pause;

    public UnityEngine.Events.UnityEvent pauseEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(lastCheckpoint))
        {
            lastCheckpointEvent.Invoke();
        }

        if(Input.GetKeyDown(pause))
        {
            pauseEvent.Invoke();
        }
    }
}
