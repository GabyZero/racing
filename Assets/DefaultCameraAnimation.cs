using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// camera animation for the beginning of the level on the default map
[RequireComponent(typeof(Animator))]
public class DefaultCameraAnimation : MonoBehaviour
{

    private Animator animator;

    [SerializeField]
    private Transform center;

    private Vector3 firstPostion;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        transform.position = center.position;
        transform.rotation = center.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
