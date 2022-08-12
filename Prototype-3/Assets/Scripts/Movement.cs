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


    void Start()
    {
        speedWalk = -0.1f;
        rb = gameObject.GetComponent<Rigidbody>();
        speedModifier = 0.005f;
    }
    //void Fire()
    //{
    //    Rigidbody rocketInstance;
    //    rocketInstance = Instantiate(rbBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as Rigidbody;
    //    rocketInstance.AddForce(bulletSpawnPoint.forward *1000f);
    //    rbBullet = GameObject.FindGameObjectWithTag("FX").GetComponent<Rigidbody>();
    //    rbBullet.AddForce(bulletSpawnPoint.forward * 1000f);
    //    firingTimer = 0;
    //}
    void LateUpdate()
    {
        transform.Translate(0, 0, 10 * speedWalk * Time.deltaTime);
        float horizontalAxis = Input.GetAxisRaw("Horizontal") * LRMovement * Time.deltaTime;
        if (Input.touchCount > 0)
        {
            //if (touch.phase == TouchPhase.Began)
            //{
            //    firing = true;
            //}
            //if(touch.phase==TouchPhase.Ended)
            //{
            //    firing = false;
            //    firingTimer = 0;
            //}
            //if(firing)
            //{
            //    firingTimer += Time.deltaTime;
            //}
            //if (firingTimer > 0 && firing)
            //{
            //    Fire();
                
            //}
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float xPosition = Mathf.Clamp(transform.position.x, -6, 6);
                transform.position = new Vector3(xPosition + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
        }
    }
}
