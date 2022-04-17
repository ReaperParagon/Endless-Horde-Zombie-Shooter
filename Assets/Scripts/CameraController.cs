using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;

    private IEnumerator TempFOVCoroutine_Ref;
    private IEnumerator FOVCoroutine_Ref;
    private float startFOV;

    private void Awake()
    {
        startFOV = vCamera.m_Lens.FieldOfView;
    }

    public void TemporaryChangeFOV(float FOV, float duration)
    {
        if (TempFOVCoroutine_Ref != null)
            StopCoroutine(TempFOVCoroutine_Ref);

        TempFOVCoroutine_Ref = TemporaryChangeFOV_Coroutine(FOV, duration);
        StartCoroutine(TempFOVCoroutine_Ref);
    }

    public IEnumerator TemporaryChangeFOV_Coroutine(float FOV, float duration)
    {
        GoToFOV(FOV);

        yield return new WaitForSeconds(duration);

        GoToFOV(startFOV);

        TempFOVCoroutine_Ref = null;
    }

    public void GoToFOV(float FOV)
    {
        if (FOVCoroutine_Ref != null)
            StopCoroutine(FOVCoroutine_Ref);

        FOVCoroutine_Ref = GoToFOV_Coroutine(FOV);
        StartCoroutine(FOVCoroutine_Ref);
    }

    public IEnumerator GoToFOV_Coroutine(float FOV)
    {
        for (float f = vCamera.m_Lens.FieldOfView; Mathf.Abs(f - FOV) > 0.01f; f = Mathf.Lerp(f, FOV, Time.fixedDeltaTime))
        {
            vCamera.m_Lens.FieldOfView = f;
            yield return new WaitForFixedUpdate();
        }

        FOVCoroutine_Ref = null;
    }
}
