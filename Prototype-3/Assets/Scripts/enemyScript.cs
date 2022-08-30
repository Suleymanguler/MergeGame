using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class enemyScript : MonoBehaviour
{
    public int maxHealth, minHealth;
    public float damage;
    public float healthBarVar;
    public float Health,initialHealth;
    public float enemyRunSpeed;
    public GameObject mainCharacterObject;
    public Image healthBar;
    public bool pushback;
    public float pushbackTime;
    public GameObject Explosion;
    Animator enemyAnimator;
    private void Start()

    {
        enemyAnimator = GetComponent<Animator>();
        pushback = false;

        enemyRunSpeed =11.5f;

        Health = Random.Range(minHealth, maxHealth);
        initialHealth = Health;
        mainCharacterObject = GameObject.FindGameObjectWithTag("mainCharacter");
        
    }
    private void LateUpdate()
    {
        //move towards enemy
        if (gameObject.tag != "dead")
        {
            transform.position = Vector3.MoveTowards(transform.position, mainCharacterObject.transform.position, enemyRunSpeed * Time.deltaTime);
        }

        if(pushback)
        {
            enemyAnimator.SetBool("stumble", true);
            enemyRunSpeed = 0;
            pushbackTime += Time.deltaTime;
            if(pushbackTime>0.5f)
            {
                enemyAnimator.SetBool("stumble", false);
                pushback = false;
                enemyRunSpeed = 11.5f;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="explosive")
        {
            Debug.Log("trigger");
            //Instantiate(Explosion, transform.position, transform.rotation);
            Health -= damage;
            healthBar.fillAmount = Health / initialHealth;
            //lower health bar 

            if (Health <= 0)
            {
                //GetComponent<Renderer>().material.color = Color.black;
                gameObject.tag = "dead";
                enemyRunSpeed = 0f;
                enemyAnimator.SetBool("dead", true);
                Destroy(gameObject, 5f);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="dead")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider>(), GetComponent<CapsuleCollider>());
        }
        if (collision.transform.tag == "FX")
        {
            Health -= damage;
            healthBar.fillAmount = Health / initialHealth;
            //lower health bar 
            if(Health<=0)
            {
                //GetComponent<Renderer>().material.color = Color.black;
                gameObject.tag = "dead";
                enemyRunSpeed = 0f;
                enemyAnimator.SetBool("dead", true);
                Destroy(gameObject, 5f);
            }
        }
        else if (collision.transform.tag == "pushback")
        {
            
            pushback = true;
            Health -= damage;
            healthBar.fillAmount = Health / initialHealth;
            //lower health bar 
            
            if (Health <= 0)
            {
                //GetComponent<Renderer>().material.color = Color.black;
                gameObject.tag = "dead";
                enemyRunSpeed = 0f;
                enemyAnimator.SetBool("dead", true);
                Destroy(gameObject, 5f);
            }
        }
        //else if (collision.transform.tag == "explosive")
        //{
            
        //    //Instantiate(Explosion, transform.position, transform.rotation);
        //    Health -= damage;
        //    healthBar.fillAmount = Health / initialHealth;
        //    //lower health bar 
            
        //    if (Health <= 0)
        //    {

        //        gameObject.tag = "dead";
        //        enemyRunSpeed = 0f;
        //        enemyAnimator.SetBool("dead", true);
        //        Destroy(gameObject, 5f);
        //    }
        //}
    }
}
