using UnityEngine;
using Cinemachine;

public class SwitchCinemachineTargets : MonoBehaviour
{
    public string followTag = "Pets";       // Тег для объекта, который будет использоваться в Follow
    public string lookAtTag = "PetsLook";   // Тег для объекта, который будет использоваться в Look At
    public CinemachineFreeLook freeLookCamera;

    private Transform originalFollowTarget;
    private Transform originalLookAtTarget;

    void Start()
    {
        // Запоминаем начальные значения Follow и LookAt
        originalFollowTarget = freeLookCamera.Follow;
        originalLookAtTarget = freeLookCamera.LookAt;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject followTarget = GameObject.FindGameObjectWithTag(followTag);
            GameObject lookAtTarget = GameObject.FindGameObjectWithTag(lookAtTag);

            if (followTarget != null && lookAtTarget != null && freeLookCamera != null)
            {
                // Переключаем значения только если они отличаются от текущих
                if (freeLookCamera.Follow != followTarget.transform || freeLookCamera.LookAt != lookAtTarget.transform)
                {
                    freeLookCamera.Follow = followTarget.transform;
                    freeLookCamera.LookAt = lookAtTarget.transform;

                    Debug.Log("Cinemachine targets switched to " + followTarget.name + " (Follow) and " + lookAtTarget.name + " (Look At)");
                }
                else
                {
                    // Возвращаемся к исходным значениям
                    freeLookCamera.Follow = originalFollowTarget;
                    freeLookCamera.LookAt = originalLookAtTarget;

                    Debug.Log("Cinemachine targets reset to original values");
                }
            }
            else
            {
                Debug.LogWarning("Objects with tags " + followTag + " or " + lookAtTag + " not found.");
            }
        }
    }
}
