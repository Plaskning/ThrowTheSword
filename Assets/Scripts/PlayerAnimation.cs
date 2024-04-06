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
        float movement =  Mathf.Max(playerMovement.movementInput.x, playerMovement.movementInput.y);

        if(movement < 0)
            movement *= -1;

        animator.SetFloat("Movement", movement);
    }
}
