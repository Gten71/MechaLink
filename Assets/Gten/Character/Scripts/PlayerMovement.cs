using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 5f; // ������� �������� ������������
    public float fastSpeed = 10f;  // �������� ��� ��������� (������� Shift)
    public Camera playerCamera;
    private Animator _animator;

    private bool isScriptEnabled = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
       if (isScriptEnabled)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forwardDirection = playerCamera.transform.forward * vertical;
        Vector3 rightDirection = playerCamera.transform.right * horizontal;
        Vector3 movement = (forwardDirection + rightDirection).normalized;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? fastSpeed : normalSpeed;

        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        float horizontalDragFactor = 0.5f; // Значение Drag для горизонтального движения
        Vector3 horizontalMovement = new Vector3(movement.x * currentSpeed, 0f, movement.z * currentSpeed);
        horizontalMovement -= horizontalMovement * horizontalDragFactor * Time.deltaTime;

        velocity.y += Physics.gravity.y * Time.deltaTime;

        GetComponent<Rigidbody>().velocity = new Vector3(horizontalMovement.x, velocity.y, horizontalMovement.z);
            Quaternion lookRotation = Quaternion.LookRotation(transform.position - playerCamera.transform.position);
            transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
            
            _animator.SetBool("RunForward", forwardDirection.magnitude > 0.1f && vertical > 0);
            _animator.SetBool("RunBackward", forwardDirection.magnitude > 0.1f && vertical < 0);
            _animator.SetBool("RunLeft", forwardDirection.magnitude > 0.1f && horizontal < 0);
            _animator.SetBool("RunBackwardLeft", forwardDirection.magnitude > 0.1f && horizontal < 0);
            _animator.SetBool("StrafeLeft", horizontal < 0);
            _animator.SetBool("RunRight", forwardDirection.magnitude > 0.1f && horizontal > 0);
            _animator.SetBool("RunBackwardRight", forwardDirection.magnitude > 0.1f && horizontal > 0);
            _animator.SetBool("StrafeRight", horizontal > 0);
            _animator.SetBool("Sprint", forwardDirection.magnitude > 0.1f && vertical > 0 && Input.GetKey(KeyCode.LeftShift));
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameObject.CompareTag("Player"))
            {
                isScriptEnabled = !isScriptEnabled;

                Debug.Log("PlayerMovement script " + (isScriptEnabled ? "enabled" : "disabled"));
            }
        }

    }
}
