using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 720f;
    public Football football;
    public Transform[] teammates;
    public Transform[] teammateHands;
    public Transform playerHand;

    private Rigidbody rb;
    private Vector3 movement;
    private float currentSpeed;
    private bool isControlled = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        football.AttachTo(playerHand);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isControlled) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        movement = new Vector3(h, 0f, v).normalized;

        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            football.PassTo(teammates[0], teammateHands[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            football.PassTo(teammates[1], teammateHands[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            football.PassTo(teammates[2], teammateHands[2]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            football.PassTo(teammates[3], teammateHands[3]);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    public void SetControlled(bool controlled)
    {
        isControlled = controlled;
    }
}
