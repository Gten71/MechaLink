using System;
using UnityEngine;

public class PlayerMovementModified : MonoBehaviour
{
    public float normalSpeed = 5f; // Обычная скорость передвижения
    public float fastSpeed = 10f;  // Скорость при ускорении (нажатие Shift)
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

            Vector3 groundNormal = Vector3.up;

            Vector3 projectedMovement = Vector3.ProjectOnPlane(movement, groundNormal);

            GetComponent<Rigidbody>().velocity = projectedMovement * currentSpeed;
            Quaternion lookRotation = Quaternion.LookRotation(transform.position - playerCamera.transform.position);
            transform.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);

            if(this.GetComponent<Animator>() != null) 
            {
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
