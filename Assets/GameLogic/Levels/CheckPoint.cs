using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CheckPointEvent : UnityEngine.Events.UnityEvent<int>
{ }

/**
 * CheckPoint of the level.
 * 
 **/
public class CheckPoint : MonoBehaviour
{
    // id of the checkpoint, begin to 0
    [SerializeField]
    private int id;

    [SerializeField]
    private CheckPointEvent evt;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        evt.Invoke(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/**
 * Draw a line one the front of the checkpoint to know the orientation for reset
 **/
/*public class CheckPointGizmoDrawer
{
    [UnityEditor.DrawGizmo(UnityEditor.GizmoType.Selected | UnityEditor.GizmoType.Active | UnityEditor.GizmoType.InSelectionHierarchy)]
    static void DrawGizmoForCheckPoint(CheckPoint cp, UnityEditor.GizmoType gtype)
    {
        Gizmos.DrawLine(cp.transform.position + new Vector3(0,5,0), cp.transform.position + cp.transform.forward * 5 + new Vector3(0, 5, 0));
    }
}*/