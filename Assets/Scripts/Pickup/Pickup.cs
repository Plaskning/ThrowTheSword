using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    protected  new Rigidbody2D rigidbody;
    protected  new Collider2D collider;
    protected bool isActive = false;

    protected Vector3 lastVelocity;
    protected int damage = 2;
    protected float speed = 750;
    protected int bounceAmount;
    public virtual void Start()
    {
        GetComponents();
        damage = 2;
        speed = 1000;
        bounceAmount = 1;
    }

    public virtual void Update()
    {
        lastVelocity = rigidbody.velocity;
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (!isActive)
            return;

        if (other.gameObject.CompareTag("Enemy"))
        {
            //damage enemy
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Break();
        }
        else if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Pickup"))
        {
            Bounce(other);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Bounce(other);
        }
    }

    public virtual void Throw(Vector2 mouseDirection, float speedMultiplier)
    {
        isActive = true;

        Vector2 rotation = new Vector2(transform.position.x, transform.position.y) - mouseDirection;
        rigidbody.velocity = new Vector2(mouseDirection.x, mouseDirection.y).normalized * speed * Time.deltaTime;

        //set direction
        //set speed
        //activate collider
    }

    public virtual void Bounce(Collision2D other)
    {
        var speed = lastVelocity.magnitude;

        var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
        rigidbody.velocity = direction * Mathf.Max(speed, 0);

        //Bounce does not break items if set to 999
        if (bounceAmount == 999)
            return;

        if (bounceAmount <= 0)
        {
            Break();
        }
        bounceAmount--;
    }

    public virtual void Break()
    {

        Debug.Log("Pickup used default Break()");
        if(gameObject != null)
            Destroy(gameObject);
    }

    public virtual void GetComponents()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
}
