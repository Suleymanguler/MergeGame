using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //movement items
    private Touch touch;
    public float speedModifier, LRMovement;
    private Rigidbody rb;
    public float speedWalk;

    //fire items
    public GameObject bullet;
    public Rigidbody rbBullet;
    public Transform bulletSpawnPoint;
    public float firingTimer;
    public bool firing;

    //merge items
    public GameObject mergePanel;

    //detecting touch borders
  
    float topBorder;

    public bool isInside;

    void Start()
    {
        
        //topBorder = 800f;
        topBorder = Screen.height*2 / 5;
        speedWalk = -1f;
        rb = gameObject.GetComponent<Rigidbody>();
        speedModifier = 0.005f;
    }
    //public void ÝnBorder(Vector3 p)
    //{
    //    if (touch.position.x < leftBorder)
    //    {
    //        isInside = false;
    //    }
    //    if (touch.position.x > rightBorder)
    //    {
    //        isInside = false;
    //    }
    //    if (touch.position.y > topBorder)
    //    {
    //        isInside = false;
    //    }
    //    if (touch.position.y < bottomBorder)
    //    {
    //        isInside = false;
    //    }
    //    isInside = true;
    //}
  
    void LateUpdate()
    {
        transform.Translate(0, 0, 10 * speedWalk * Time.deltaTime);
        float horizontalAxis = Input.GetAxisRaw("Horizontal") * LRMovement * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            isInside = true;
            //if (touch.position.x < leftBorder&& touch.position.x > rightBorder)
            //{
            //    isInside = false;
            //}
            
            if (touch.position.y < topBorder)
            {
                isInside = false;
            }
            //if (touch.position.y < bottomBorder)
            //{
            //    isInside = false;
            //}

            if (isInside)
            {
                mergePanel.SetActive(false);
                Time.timeScale = 1f;

                if (touch.phase == TouchPhase.Moved)
                {
                    float xPosition = Mathf.Clamp(transform.position.x, -6, 6);
                    transform.position = new Vector3(xPosition + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
                }
            }
        }
        else if(Input.touchCount<=0)
        {
            mergePanel.SetActive(true);
            Time.timeScale = 0.1f;
            
        }
    }
}
