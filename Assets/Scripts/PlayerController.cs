using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1.5f;

    public float gravity = 1f;

    public float gravityScale = 0.05f;

    public float gravityReset = -5f;

    public float maxSpeed = -8f;

    public Rigidbody2D playerBody;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            gravity += gravityReset;
            if (gravity < maxSpeed)
            {
                gravity = maxSpeed;
            }
        }
    }

    void FixedUpdate()
    {
        gravity += gravityScale;
        playerBody.MovePosition(playerBody.position + new Vector2(1 * movementSpeed, -1 * gravity) * Time.fixedDeltaTime);
    }
}
