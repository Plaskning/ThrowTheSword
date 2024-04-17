using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickup : Pickup
{
    [SerializeField] float speed;
    [SerializeField] int bounceAmount;
    [SerializeField] GameObject bounceEffect;
    [SerializeField] GameObject breakEffect;
    public override void Start()
    {
        base.Start();
        base.speed = speed;
        base.bounceAmount = bounceAmount;
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
    }

    public override void Throw(Vector2 mouseDirection, float speedMultiplier)
    {
        base.Throw(mouseDirection, speedMultiplier);
    }
    public override void Bounce(Collision2D other)
    {
        base.Bounce(other);
        if(bounceEffect != null)
            Instantiate(bounceEffect, transform.position, Quaternion.identity);
    }
    public override void Break()
    {
        base.Break();
        if(breakEffect != null)
            Instantiate(breakEffect,transform.position,Quaternion.identity);
    }

    public override void GetComponents()
    {
        base.GetComponents();
    }
}
