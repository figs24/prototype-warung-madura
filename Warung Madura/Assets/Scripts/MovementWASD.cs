using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWASD : MonoBehaviour
{
    float speed = 200f;
    private Rigidbody rb;
    float verticalMove;
    float horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        verticalMove = 0;
        horizontalMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(horizontalMove * speed * Time.deltaTime, 0f, verticalMove * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontalMove = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontalMove = 1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            verticalMove = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            verticalMove = -1;
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            verticalMove = 0;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            horizontalMove = 0;
        }


        //float hAxis = Input.GetAxis("Horizontal");
        //float vAxis = Input.GetAxis("Vertical");
        //rb.velocity = (transform.forward * vAxis) * speed * Time.deltaTime;
        //transform.Rotate((transform.up * hAxis) * rotation * Time.deltaTime);
    }
}
