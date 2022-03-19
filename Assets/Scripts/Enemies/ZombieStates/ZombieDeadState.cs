using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadState : ZombieStates
{
    int movementZHash = Animator.StringToHash("MovementZ");
    int isDeadhash = Animator.StringToHash("isDead");

    public ZombieDeadState(ZombieComponent zombie, ZombieStateMachine zombieStateMachine) : base(zombie, zombieStateMachine)
    {

    }

    public override void Start()
    {
        base.Start();
        ownerZombie.zombieNavMeshAgent.isStopped = true;
        ownerZombie.zombieNavMeshAgent.ResetPath();
        ownerZombie.zombieAnimator.SetFloat(movementZHash, 0);
        ownerZombie.zombieAnimator.SetBool(isDeadhash, true);
    }

    public override void Exit()
    {
        base.Exit();
        ownerZombie.zombieNavMeshAgent.isStopped = false;
        ownerZombie.zombieAnimator.SetBool(isDeadhash, false);
    }

}
