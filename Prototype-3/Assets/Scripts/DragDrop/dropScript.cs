using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dropScript : MonoBehaviour,IDropHandler
{
    public bool isOccupied;
    public Transform pointBefore;

    private void Awake()
    {
        isOccupied = false;
        
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag!=null)
        {
            isOccupied = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            pointBefore=eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            eventData.pointerDrag.GetComponent<DragScript>().initialPos = gameObject.transform;

        }
       
        
    }


  
}
