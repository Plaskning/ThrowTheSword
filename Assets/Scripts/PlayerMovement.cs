using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private PlayerControls playerControls;
    private Rigidbody2D rigidbody;
    [SerializeField] public Vector2 movementInput;
    public Vector2 lastMovementInput;

    

    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PlayerControls();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();

        if(movementInput != Vector2.zero)
        {
            lastMovementInput = movementInput;
        }
    }

    

   
}
