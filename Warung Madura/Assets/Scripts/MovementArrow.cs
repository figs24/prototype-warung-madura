using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrow : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horizontalMove = -1;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            horizontalMove = 1;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            verticalMove = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            verticalMove = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            verticalMove = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            horizontalMove = 0;
        }
    }
}
