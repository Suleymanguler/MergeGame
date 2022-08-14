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
    private void Start()
    {
        enemyRunSpeed = 12.5f;

        Health = Random.Range(minHealth, maxHealth);
        initialHealth = Health;
        mainCharacterObject = GameObject.FindGameObjectWithTag("mainCharacter");
    }
    private void FixedUpdate()
    {
        //move towards enemy
        transform.position =Vector3.MoveTowards(transform.position, mainCharacterObject.transform.position, enemyRunSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "FX")
        {
            Health -= damage;
            healthBar.fillAmount = Health / initialHealth;
            //lower health bar 
            if(Health<=0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
