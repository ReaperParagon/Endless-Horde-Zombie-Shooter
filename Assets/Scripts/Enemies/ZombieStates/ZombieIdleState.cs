using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : ZombieStates
{
    int movementZHash = Animator.StringToHash("MovementZ");

    public ZombieIdleState(ZombieComponent zombie, ZombieStateMachine zombieStateMachine) : base(zombie, zombieStateMachine)
    {

    }

    public override void Start()
    {
        base.Start();
        ownerZombie.zombieNavMeshAgent.isStopped = true;
        ownerZombie.zombieNavMeshAgent.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
    }

    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieNavMeshAgent.isStopped = false;
    }

}
