using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrewiewRotator : MonoBehaviour
{

    private bool autoRotation;

    private Quaternion defaultOrientation;

    private void Start()
    {
        autoRotation = true;

        defaultOrientation = transform.rotation;
    }

    public void SetAutoRotation(bool b)
    {
        autoRotation = b;
        transform.rotation = defaultOrientation;
    }

    private void OnMouseDrag()
    {
        if(!autoRotation)
        {
            RotateWithMouse();
        }
    }

    void RotateWithMouse()
    {
        transform.Rotate(Vector3.up, -(Input.GetAxis("Mouse X") * 50*Mathf.Deg2Rad));
        //transform.Rotate(transform.right, Input.GetAxis("Mouse Y") * 50*Mathf.Deg2Rad);
    }

    // Update is called once per frame
    void Update()
    {
        if (autoRotation)
        {
            transform.Rotate(transform.up, Time.deltaTime * 10);
        }
    }
}
