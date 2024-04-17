using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;
    private Animator animator;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
        FlipX();
    }

    private void FlipX()
    {
        if (playerMovement.lastMovementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(playerMovement.lastMovementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void UpdateAnimation()
    {
        //check movement input, takes the higher number, if it's 0 it check if the lower number is below 0. If so we are moving left.
        //Positive = moving right, Negative = moving left

        float movement =  Mathf.Max(playerMovement.movementInput.x, playerMovement.movementInput.y);

        if(movement == 0)
            movement = Mathf.Min(playerMovement.movementInput.x, playerMovement.movementInput.y);

        if(movement < 0)
            movement *= -1;

        animator.SetFloat("Movement", movement);
    }
}
