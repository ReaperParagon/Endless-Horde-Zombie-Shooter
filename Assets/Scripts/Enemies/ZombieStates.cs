using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieStateType
{
    Idling, Attacking, Following, IsDead
}

public class ZombieStates : State
{
    protected ZombieComponent ownerZombie;

    public ZombieStates(ZombieComponent zombie, ZombieStateMachine stateMachine) : base(stateMachine)
    {
        ownerZombie = zombie;
    }
}
