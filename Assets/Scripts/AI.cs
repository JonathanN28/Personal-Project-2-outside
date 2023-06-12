using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public EnemyStateMachine enemyStateMachine;

    private Animator npcAnim;

    private NavMeshAgent agent;

    public Transform playerBall;
    // Start is called before the first frame update
    void Start()
    {
        npcAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyStateMachine = new Idle(gameObject, agent, npcAnim, playerBall);
    }

    // Update is called once per frame
    void Update()
    {
        enemyStateMachine = enemyStateMachine.Runtime();
    }
}
