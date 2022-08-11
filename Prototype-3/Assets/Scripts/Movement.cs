using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Touch touch;
    public float speedModifier, LRMovement;
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speedModifier = 0.005f;
    }

    void LateUpdate()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal") * LRMovement * Time.deltaTime;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float xPosition = Mathf.Clamp(transform.position.x, -6, 6);
                transform.position = new Vector3(xPosition + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
        }
    }
}
