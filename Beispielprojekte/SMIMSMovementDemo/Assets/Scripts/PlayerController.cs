using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody rb;
    public float jumpForce = 10f;
    public float gravityScale;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * moveSpeed);

        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
            }
        }

        moveDirection = new Vector3(moveHorizontal * moveSpeed, moveDirection.y, moveVertical * moveSpeed);
        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale;
        rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
    }
}
