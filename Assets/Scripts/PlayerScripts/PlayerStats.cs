using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float speedMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;

    private IEnumerator SpeedChangeCoroutine_Ref;
    private IEnumerator DamageChangeCoroutine_Ref;

    public void TemporarySpeedChange(float speedMul, float duration)
    {
        if (SpeedChangeCoroutine_Ref != null)
            StopCoroutine(SpeedChangeCoroutine_Ref);

        SpeedChangeCoroutine_Ref = TemporarySpeedChange_Coroutine(speedMul, duration);
        StartCoroutine(SpeedChangeCoroutine_Ref);
    }

    private IEnumerator TemporarySpeedChange_Coroutine(float speedMul, float duration)
    {
        speedMultiplier = speedMul;

        yield return new WaitForSeconds(duration);

        speedMultiplier = 1.0f;

        SpeedChangeCoroutine_Ref = null;
    }

    public void TemporaryDamageChange(float speedMul, float duration)
    {
        if (DamageChangeCoroutine_Ref != null)
            StopCoroutine(DamageChangeCoroutine_Ref);

        DamageChangeCoroutine_Ref = TemporaryDamageChange_Coroutine(speedMul, duration);
        StartCoroutine(DamageChangeCoroutine_Ref);
    }

    private IEnumerator TemporaryDamageChange_Coroutine(float dmgMul, float duration)
    {
        damageMultiplier = dmgMul;

        yield return new WaitForSeconds(duration);

        damageMultiplier = 1.0f;

        DamageChangeCoroutine_Ref = null;
    }
}
