using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class downPanelScript : MonoBehaviour, IDropHandler
{
    GameObject droppedObject;
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.position = eventData.pointerDrag.GetComponent<DragScript>().initialPos.position;
    }
}
