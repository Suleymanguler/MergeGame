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
    //Measuring distance between enemy and player
    GameObject enemy;
    //grenade launcher launchspeed
    projectileActor player;

    public bool isInside;
    public float distance;
    void Start()
    {
        player = GameObject.Find("Player_2017").GetComponent<projectileActor>();
        enemy = GameObject.FindGameObjectWithTag("enemy");
        distance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);

        //topBorder = 800f;
        topBorder = Screen.height*3 / 6;
        speedWalk = -1f;
        rb = gameObject.GetComponent<Rigidbody>();
        speedModifier = 0.005f;
    }
    
  
    void LateUpdate()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        distance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
        if (distance > 30)
        {
            player.forwardSpeed = distance * 200;
        }
        else if(distance<30 && distance>16)
        {
            player.forwardSpeed = distance * 80;
        }
        else if(distance<16)
        {
            player.forwardSpeed = distance * 200;
            player.upwardSpeed = 1000f;
        }
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
                topBorder = 0;
                if (touch.phase == TouchPhase.Moved)
                {
                    float xPosition = Mathf.Clamp(transform.position.x, -6, 6);
                    transform.position = new Vector3(xPosition + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
                }
            }
        }
        else if(Input.touchCount<=0)
        {
            topBorder= Screen.height * 3 / 6;
            mergePanel.SetActive(true);
            Time.timeScale = 0.1f;
            
        }
    }
}
