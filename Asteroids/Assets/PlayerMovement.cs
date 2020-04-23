using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 50f;
    public float mainForce = 5f;
    public float sideForce = 3f;
    private int turnInput;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            turnInput = 1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            turnInput = -1;
        } else
        {
            turnInput = 0;
        }

    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, turnInput *
            turnSpeed * Time.deltaTime);

        GetComponent<Rigidbody2D>().
            AddForce(transform.up * mainForce *
                Input.GetAxisRaw("Vertical"));
        GetComponent<Rigidbody2D>().
            AddForce(transform.right * sideForce *
                Input.GetAxisRaw("Horizontal"));
    }
}
