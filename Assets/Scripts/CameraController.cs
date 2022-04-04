using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vCamera;

    private IEnumerator FOVCoroutine;

    public void GoToFOV(float FOV)
    {
        if (FOVCoroutine != null)
            StopCoroutine(FOVCoroutine);

        FOVCoroutine = GoToFOV_Coroutine(FOV);
        StartCoroutine(FOVCoroutine);
    }

    public IEnumerator GoToFOV_Coroutine(float FOV)
    {
        for (float f = vCamera.m_Lens.FieldOfView; Mathf.Abs(f - FOV) > 0.01f; f = Mathf.Lerp(f, FOV, Time.fixedDeltaTime))
        {
            vCamera.m_Lens.FieldOfView = f;
            yield return new WaitForFixedUpdate();
        }

        FOVCoroutine = null;
    }
}
