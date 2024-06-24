using UnityEngine;

public class Jump : MonoBehaviour
{
    public Transform targetPoint; // Поинт на сцене, к которому персонаж будет прыгать
    public float jumpHeight = 2f; // Высота прыжка
    public float jumpDuration = 1f; // Продолжительность прыжка

    private bool isJumping = false;
    private bool isInTrigger = false; // Переменная для отслеживания нахождения игрока в триггере
    private Vector3 initialPosition;
    private float jumpStartTime;
    private Transform player;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isJumping)
        {
            float jumpProgress = (Time.time - jumpStartTime) / jumpDuration;
            if (jumpProgress >= 1f)
            {
                isJumping = false;
                player.position = targetPoint.position;
            }
            else
            {
                float yOffset = Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight;
                player.position = Vector3.Lerp(initialPosition, targetPoint.position, jumpProgress) + Vector3.up * yOffset;
            }
        }
        else if (isInTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            StartJump();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            isInTrigger = true; // Устанавливаем, что игрок находится в триггере
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false; // Устанавливаем, что игрок покинул триггер
        }
    }

    void StartJump()
    {
        isJumping = true;
        jumpStartTime = Time.time;
    }
}
