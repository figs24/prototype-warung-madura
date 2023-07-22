using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWASD : MonoBehaviour
{
    public float speed = 300f;
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
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontalMove = 1;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            verticalMove = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            verticalMove = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            verticalMove = 0;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            horizontalMove = 0;
        }
    }
}
