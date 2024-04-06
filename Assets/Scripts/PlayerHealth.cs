using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        Debug.Log(gameObject.name + " has taken " + damageToTake + " damage");

        if (health <= 0)
        {
            //Death Anim
            Debug.Log(gameObject.name + " has died");
        }
    }

    public void Heal(int healthToHeal)
    {
        health += healthToHeal;
    }
}
