using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Ссылка на игрока
    public float followSpeed = 5f;  // Скорость следования

    private bool isFollowingPlayer = true;  // Флаг для отслеживания состояния следования

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
