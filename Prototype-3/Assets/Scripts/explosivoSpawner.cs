using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosivoSpawner : MonoBehaviour
{
    public GameObject explosivo;
    

   public void spawnExplosivo()
    {
        Instantiate(explosivo, transform.position, transform.rotation);
    }
}
