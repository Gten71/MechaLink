using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // ������ �� ������
    public float followSpeed = 5f;  // �������� ����������

    private bool isFollowingPlayer = true;  // ���� ��� ������������ ��������� ����������

    void Update()
    {
        if (isFollowingPlayer)
        {
            FollowPlayerCharacter();
        }

    }

    void FollowPlayerCharacter()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, followSpeed * Time.deltaTime);
    }
}
