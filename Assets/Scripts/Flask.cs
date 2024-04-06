using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : Pickup
{
    [SerializeField] float flaskSpeed;
    [SerializeField] int flaskBounce;
    [SerializeField] GameObject breakEffect;
    public override void Start()
    {
        base.Start();
        speed = flaskSpeed;
        bounceAmount = flaskBounce;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && isActive)
        {
            Break();
        }
        base.OnCollisionEnter2D(other);
    }

    public override void Throw(Vector2 mouseDirection, float speedMultiplier)
    {
        base.Throw(mouseDirection, speedMultiplier);
    }
    public override void Bounce(Collision2D other)
    {
        base.Bounce(other);
        Debug.Log("Flask bounced");
    }
    public override void Break()
    {
        Debug.Log("Flask Break()");
        Instantiate(breakEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public override void GetComponents()
    {
        base.GetComponents();
    }
}
