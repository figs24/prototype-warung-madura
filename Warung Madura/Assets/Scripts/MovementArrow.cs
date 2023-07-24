using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrow : MonoBehaviour
{
    public float speed = 12f;
    private Rigidbody rb;
    float verticalMove;
    float horizontalMove;
    Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }

    private void ReadInput()
    {
        input = new Vector3(Input.GetAxis("HorizontalArrow"), 0, Input.GetAxis("VerticalArrow"));
    }

    private void Move()
    {
        rb.MovePosition(transform.position + input * speed * Time.fixedDeltaTime);
    }

    private void Look()
    {
        if (input == Vector3.zero) return;

        var relative = (transform.position + input) - transform.position;
        var rotation = Quaternion.LookRotation(relative, Vector3.up);

        transform.rotation = rotation;
    }
}
