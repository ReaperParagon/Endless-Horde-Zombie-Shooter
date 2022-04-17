using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float speedMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;
    public float health = 100.0f;

    private IEnumerator SpeedChangeCoroutine_Ref;

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
}
