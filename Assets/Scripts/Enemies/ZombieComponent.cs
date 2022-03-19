using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieComponent : MonoBehaviour
{
    public float zombieDamage = 5;
    public NavMeshAgent zombieNavMeshAgent;
    public Animator zombieAnimator;
    public ZombieStateMachine statemachine;
    public GameObject followTarget;

    private void Awake()
    {
        zombieAnimator = GetComponent<Animator>();
        zombieNavMeshAgent = GetComponent<NavMeshAgent>();
        statemachine = GetComponent<ZombieStateMachine>();
        Initialize(followTarget);
    }

    public void Initialize(GameObject _followTarget)
    {
        followTarget = _followTarget;

        ZombieIdleState idleState = new ZombieIdleState(this, statemachine);
        statemachine.AddState(ZombieStateType.Idling, idleState);

        ZombieFollowState followState = new ZombieFollowState(followTarget, this, statemachine);
        statemachine.AddState(ZombieStateType.Following, followState);

        ZombieAttackState attackState = new ZombieAttackState(followTarget, this, statemachine);
        statemachine.AddState(ZombieStateType.Attacking, attackState);

        ZombieDeadState deadState = new ZombieDeadState(this, statemachine);
        statemachine.AddState(ZombieStateType.IsDead, deadState);

        statemachine.Initialize(ZombieStateType.Following);
    }

}
