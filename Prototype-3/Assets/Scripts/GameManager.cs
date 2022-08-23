using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gunLv1;
    public int gunLevel;
    public Transform[] spawnLocations;
    public RawImage[] gunImages;
    private int spawnOrderNumber;

    private void Awake()
    {
        spawnOrderNumber = 0;
    }
    public void spawnGunLevel1()
    {
        for (spawnOrderNumber = 0; spawnOrderNumber <= 11; spawnOrderNumber++)
        {
            if (spawnLocations[spawnOrderNumber].GetComponent<dropScript>().isOccupied == false)
            {
                GameObject gunLv1Object = Instantiate(gunLv1, spawnLocations[spawnOrderNumber].position, transform.rotation, GameObject.Find("MergeItems").transform);
                gunLv1Object.GetComponent<RawImage>().texture = gunImages[gunLevel].texture;
                gunLv1Object.transform.tag = gunLevel.ToString();
                gunLv1Object.transform.position = spawnLocations[spawnOrderNumber].position;
                gunLv1Object.GetComponent<DragScript>().initialPos = spawnLocations[spawnOrderNumber];
                spawnLocations[spawnOrderNumber].GetComponent<dropScript>().isOccupied = true;
                
                break;
            }
           
        }
    }
    public void loadLevel1()
    {
        SceneManager.LoadScene("Level-Sample");
    }
    
}
