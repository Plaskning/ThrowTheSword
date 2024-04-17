using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Pickup
{
    [SerializeField] float boxSpeed;
    [SerializeField] int boxBounce;
    [SerializeField] GameObject boxDebris;
    public override void Start()
    {
        base.Start();
        speed = boxSpeed;
        bounceAmount = boxBounce;
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
    }
    public override void Break()
    {
        base.Break();
        Instantiate(boxDebris,transform.position,Quaternion.identity);
    }

    public override void GetComponents()
    {
        base.GetComponents();
    }
}
