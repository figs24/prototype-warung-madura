using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private ParticleSystem dustVFX;
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    private Rigidbody rb;
    float verticalMove;
    float horizontalMove;
    Vector3 input;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
        SpawnDust();
    }

    private void ReadInput()
    {
        input = new Vector3(Input.GetAxis(horizontalInputName), 0, Input.GetAxis(verticalInputName));
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

    private void SpawnDust()
    {
        if (input != Vector3.zero && !dustVFX.isPlaying)
        {
            dustVFX.Play();
        }
        else if (input == Vector3.zero && dustVFX.isPlaying)
        {
            dustVFX.Stop();
        };

        animator.SetBool("isMoving", input != Vector3.zero);
    }
}
