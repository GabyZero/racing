using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSelectionner : MonoBehaviour
{
    /** detection of a click **/
    private Vector3 positionBeg;

    //color picker
    [SerializeField]
    private ColorPicker colorPicker;

    // Start is called before the first frame update
    void Start()
    {
        if (colorPicker == null) throw new UnityException("PartSelectionner need a color picker");
    }

    private void OnMouseDown()
    {
        positionBeg = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        if ((Input.mousePosition - positionBeg).sqrMagnitude < 0.1)
            OnMouseClick();
    }

    private void OnMouseClick()
    {
        SelectPart();
    }

    private void SelectPart()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        if (hits.Length > 0)
        {
            foreach(RaycastHit hit in hits)
            {
                if(hit.collider.name != name)
                {
                    //set color as the color picker's color
                    hit.collider.GetComponent<MeshRenderer>().materials[0].color = colorPicker.CurrentColor;

                    //remove other listener
                    colorPicker.onValueChanged.RemoveAllListeners();

                    //add the listener
                    colorPicker.onValueChanged.AddListener(color =>
                    {
                        hit.collider.GetComponent<MeshRenderer>().materials[0].color = color;
                    });

                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
