using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAOE : MonoBehaviour
{
    private Collider2D col;
    private HealAOE healAOE;
    [SerializeField] private int healAmount = 1;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        healAOE = GetComponent<HealAOE>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth);
            playerHealth.Heal(healAmount);
            Destroy(healAOE);
        }
    }
}
