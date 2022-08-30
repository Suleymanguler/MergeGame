using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gunDropScript : MonoBehaviour, IDropHandler
{
    public GameObject[] guns;
    projectileActor player;
    GameObject[] enemy;
    Transform pointBefore;
    public GameObject objectBefore;
    Animator mainAnimator;
    public Transform pistolSpawnPoint;
    public Transform rifleSpawnPoint;
    public Transform rpgSpawnPoint;
   public  bool dropHandler = false;

   

    private void Awake()
    {
        

        player = GameObject.Find("Player_2017").GetComponent<projectileActor>();
        enemy = GameObject.FindGameObjectsWithTag("enemy");
        mainAnimator = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<Animator>();
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        dropHandler = true;
        if (objectBefore != null)
        {
            if (eventData.pointerDrag.tag == objectBefore.tag)
            {
                eventData.pointerDrag.transform.position = eventData.pointerDrag.GetComponent<DragScript>().initialPos.position;
                dropHandler = false;
                Debug.Log("taglar ayný fonk çalýþtý");
            }
        }
        if (objectBefore != null && dropHandler == true)
        {
            Debug.Log("destroy çalýþtý");
            Destroy(objectBefore);
        }


        
        //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        //objectBefore = eventData.pointerDrag;
        //pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
        //pointBefore.GetComponent<dropScript>().isOccupied = false;
        
        

        if (eventData.pointerDrag.tag=="0" && dropHandler)
        {

            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            Debug.Log("objeyi sabitle çalýþtý");
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[0], pistolSpawnPoint.transform.position, pistolSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(pistolSpawnPoint);
            //GameObject.FindGameObjectWithTag("gun").transform.eulerAngles = new Vector3(43, -472, -272);
            //animation
            mainAnimator.SetBool("IsPistol", true);
            //bullet type
            player.bombType = 1;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach(GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 6f;
            }
            //fire rate
            player.rapidFireDelay = 0.5f;
        }
        else if (eventData.pointerDrag.tag == "1" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[1], pistolSpawnPoint.transform.position, pistolSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(pistolSpawnPoint);
            gun.transform.eulerAngles = new Vector3(14, -8, -40);
            //animation
            mainAnimator.SetBool("IsPistol", true);
            //bullet type
            player.bombType = 0;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 6f;
            }
            //fire rate
            player.rapidFireDelay = 0.08f;
        }
        else if (eventData.pointerDrag.tag == "2" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[2], rifleSpawnPoint.transform.position, rifleSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(rifleSpawnPoint);
            
            //animation
            mainAnimator.SetBool("IsPistol", false);
            mainAnimator.SetBool("IsMinigun", false);
            
            //bullet type
            player.bombType = 3;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 9f;
            }
            //fire rate
            player.rapidFireDelay = 1f;
        }
        else if (eventData.pointerDrag.tag == "3" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[3], rifleSpawnPoint.transform.position-new Vector3(0,0,0.4f), rifleSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(rifleSpawnPoint);
            gun.transform.rotation = Quaternion.Euler(0, 90, 0);
            //animation
            mainAnimator.SetBool("IsPistol", false);
            //bullet type
            player.bombType = 3;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 9f;
            }
            //fire rate
            player.rapidFireDelay = 0.5f;
        }
        else if (eventData.pointerDrag.tag == "4" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[4], rifleSpawnPoint.transform.position, rifleSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(rifleSpawnPoint);
            gun.transform.rotation = Quaternion.Euler(90,0,180);
            //animation
            mainAnimator.SetBool("IsPistol", false);
            //bullet type
            player.bombType = 2;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 35f;
            }
            //fire rate
            player.rapidFireDelay = 1f;
        }
        else if (eventData.pointerDrag.tag == "5" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[5], rifleSpawnPoint.transform.position-new Vector3(-0.1f,0.2f,1.2f), rifleSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(rifleSpawnPoint);
            gun.transform.rotation = Quaternion.Euler(0, 90,0);
            
            //animation
            mainAnimator.SetBool("IsPistol", false);
            //bullet type
            player.bombType = 0;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 9f;
            }
            //fire rate
            player.rapidFireDelay = 0.1f;
        }
        else if (eventData.pointerDrag.tag == "6" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[6], rifleSpawnPoint.transform.position-new Vector3(1,0.5f,0.9f), rifleSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(rifleSpawnPoint);
            gun.transform.rotation = Quaternion.Euler(65, 46, -40);
            //animation
            mainAnimator.SetBool("IsPistol", false);
            mainAnimator.SetBool("IsMinigun", true);
            //bullet type
            player.bombType = 0;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 5f;
            }
            //fire rate
            player.rapidFireDelay = 0.07f;
        }
        else if (eventData.pointerDrag.tag == "7" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 8000;
            player.upwardSpeed = 4000;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[7], rifleSpawnPoint.transform.position, rifleSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(rifleSpawnPoint);
            gun.transform.rotation = Quaternion.Euler(90,0,0);
            //animation
            mainAnimator.SetBool("IsPistol", false);
            mainAnimator.SetBool("IsMinigun", false);
            //bullet type
            player.bombType = 6;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;

            //SEPACIAL EFFECT FOR THIS GUN
            player.isGrenade = true;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 15f;
            }
            //fire rate
            player.rapidFireDelay = 1.5f;
        }
        else if (eventData.pointerDrag.tag == "8" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[8], rpgSpawnPoint.transform.position, rpgSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(rpgSpawnPoint);
            gun.transform.rotation = Quaternion.Euler(90, 90, 270);
            //animation
            mainAnimator.SetBool("IsPistol", false);
            //bullet type
            player.bombType = 5;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = true;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 15f;
            }
            //fire rate
            player.rapidFireDelay = 1.5f;
        }
        else if (eventData.pointerDrag.tag == "9" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[9], pistolSpawnPoint.transform.position +new Vector3(0,0.1f,0), pistolSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(pistolSpawnPoint);
            gun.transform.rotation = Quaternion.Euler(105, 75, 90);
            //animation
            mainAnimator.SetBool("IsPistol", true);
            //bullet type
            player.bombType = 34;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 15f;
            }
            //fire rate
            player.rapidFireDelay = 0.5f;
        }
        else if (eventData.pointerDrag.tag == "10" && dropHandler)
        {
            //projectile speed
            player.forwardSpeed = 5000;
            player.upwardSpeed = 0;
            //////
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objectBefore = eventData.pointerDrag;
            pointBefore = eventData.pointerDrag.GetComponent<DragScript>().initialPos;
            pointBefore.GetComponent<dropScript>().isOccupied = false;
            //destroying gun there before
            Destroy(GameObject.FindGameObjectWithTag("gun"));
            //spawn gun 3d
            GameObject gun = Instantiate(guns[10], rifleSpawnPoint.transform.position, rifleSpawnPoint.transform.rotation);
            gun.tag = "gun";
            gun.transform.SetParent(rifleSpawnPoint);
            gun.transform.rotation = Quaternion.Euler(0, 0, 0);
            //animation
            mainAnimator.SetBool("IsPistol", false);
            //bullet type
            player.bombType = 40;
            //dragged object parent transform etc
            eventData.pointerDrag.transform.SetParent(gameObject.transform);
            eventData.pointerDrag.GetComponent<DragScript>().enabled = false;
            //is grenade
            player.isGrenade = false;
            foreach (GameObject dusman in enemy)
            {
                //damage
                dusman.GetComponent<enemyScript>().damage = 15f;
            }
            //fire rate
            player.rapidFireDelay = 0.4f;
        }

    }
}
