using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    public enum States { Idle, Aggressive, Dead }
    public States state;
    private NavMeshAgent agent;
    private GameObject player;
    private Animator animator;
    private SpriteRenderer bodyRenderer;
    private SpriteRenderer weaponRenderer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        bodyRenderer = GetComponentInChildren<SpriteRenderer>();
        weaponRenderer = GetComponentInChildren<SpriteRenderer>();

        //state = States.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.Idle:
                //Detect nearby players
                break;
            case States.Aggressive:
                //Chase down nearby players
                break;
            case States.Dead:
                //Nothing
                break;
            default:
                break;
        }
    }


    private void Aggressive()
    {

    }
    public void ChangeState(States stateToChangeTo)
    {
        switch (state)
        {
            case States.Idle:
                //Idle anim
                animator.SetTrigger("Idle");
                break;
            case States.Aggressive:
                //Run anim
                animator.SetTrigger("Run");
                Aggressive();
                break;
            case States.Dead:
                break;
            default:
                break;
        }
    }
}




