using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragScript : MonoBehaviour,IDragHandler,IPointerDownHandler,IEndDragHandler,IBeginDragHandler,IDropHandler
{
    RectTransform myRectTransform;
    CanvasGroup myCanvasGroup;

    public RawImage[] LvObjects;

    [SerializeField]public  Transform initialPos;

    int gunLevelCounter;


    private void Awake()
    {
   
        myRectTransform = GetComponent<RectTransform>();
        myCanvasGroup = GetComponent<CanvasGroup>();
        GetComponent<RawImage>().texture = LvObjects[0].texture;
        
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //Drag began
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        myRectTransform.anchoredPosition += eventData.delta * 3/ 5;
        myCanvasGroup.blocksRaycasts = false;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        myCanvasGroup.blocksRaycasts = true;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bokluk vra");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collisinbk");
    }

    
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
      
        if (eventData.pointerDrag.tag == gameObject.tag)
        {

            //GameObject Lv2ObjectImage = Instantiate(Lv2Object, gameObject.transform.position, transform.rotation) as GameObject;
            //Lv2ObjectImage.transform.SetParent(GameObject.Find("Canvas").transform, false);
            //Lv2ObjectImage.transform.position = gameObject.transform.position;
            int.TryParse(eventData.pointerDrag.transform.tag,out gunLevelCounter);
            gunLevelCounter++;
            gameObject.tag = gunLevelCounter.ToString();
            GetComponent<RawImage>().texture = LvObjects[gunLevelCounter].texture;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DragScript>().initialPos.GetComponent<dropScript>().isOccupied = false;
            eventData.pointerDrag.SetActive(false);
            Destroy(eventData.pointerDrag);
        }
        else if(eventData.pointerDrag.tag!=gameObject.tag)
        {
            eventData.pointerDrag.transform.position = eventData.pointerDrag.GetComponent<DragScript>().initialPos.position;
        }
    }
}
