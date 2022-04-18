using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{
    protected override void Start()
    {
        base.Start();
        PlayerEvents.InvokeOnHealthInitializeEvent(this);
    }

    public override void Destroy()
    {
        AppEvents.InvokeOnGameCompletion(false);

        base.Destroy();
    }
}
