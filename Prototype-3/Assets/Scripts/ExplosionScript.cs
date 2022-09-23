using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float force;
    public float radius;
    public GameObject[] doors;
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 explotionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explotionPos, radius);
        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if(rb!=null)
            {
                rb.AddExplosionForce(force, explotionPos, radius, 0.05f,ForceMode.Impulse);
            }

            foreach(GameObject door in doors)
            {
                Destroy(door);
            }

            Destroy(gameObject);
        }
    }
}
