using UnityEngine;
using Cinemachine;

public class SwitchCinemachineTargets : MonoBehaviour
{
    public string followTag = "Pets";       // ��� ��� �������, ������� ����� �������������� � Follow
    public string lookAtTag = "PetsLook";   // ��� ��� �������, ������� ����� �������������� � Look At
    public CinemachineFreeLook freeLookCamera;

    private Transform originalFollowTarget;
    private Transform originalLookAtTarget;

    void Start()
    {
        // ���������� ��������� �������� Follow � LookAt
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
                // ����������� �������� ������ ���� ��� ���������� �� �������
                if (freeLookCamera.Follow != followTarget.transform || freeLookCamera.LookAt != lookAtTarget.transform)
                {
                    freeLookCamera.Follow = followTarget.transform;
                    freeLookCamera.LookAt = lookAtTarget.transform;

                    Debug.Log("Cinemachine targets switched to " + followTarget.name + " (Follow) and " + lookAtTarget.name + " (Look At)");
                }
                else
                {
                    // ������������ � �������� ���������
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
