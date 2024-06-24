using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobTrigger : MonoBehaviour
{
    private bool playerEnter = false;
    private Canvas canvas;
    private Transform scale;
    private RectTransform redImg;
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private Animator _animator;
    private BlackScreen _blackScreen = new BlackScreen();

    private void Start()
    {
        canvas = gameObject.GetComponentInChildren<Canvas>();
        scale = gameObject.transform.GetChild(0);
        redImg = GameObject.Find("Red")?.GetComponent<RectTransform>();
        scale.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerEnter)
        {
            CanvasRotation();
            Filling();
        }
        if (_blackScreen.BlackChekcer)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            TestPlayer _test = playerObject.GetComponent<TestPlayer>();
            _animator.SetBool("Death", false);
            playerObject.transform.position = _test.LastCHP.position;
            StartCoroutine(_blackScreen.UnDimScreen());
        }
    }

    private void Filling()
    {
        if (redImg.sizeDelta.x > -1)
        {
            float newWidth = redImg.sizeDelta.x - Time.deltaTime * speed;
            redImg.sizeDelta = new Vector2(newWidth, redImg.sizeDelta.y);
        }
        else if (playerEnter)
        {
            StartCoroutine(_blackScreen.DimScreen());
            _animator.SetBool("Death", true);
        }
        else
        {
            redImg.sizeDelta = new Vector2(0f, redImg.sizeDelta.y);
        }
    }

    private void CanvasRotation()
    {
        if (canvas.transform.rotation != Camera.main.transform.rotation)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger.");
            playerEnter = true;
            scale.gameObject.SetActive(true);
            Debug.Log("Scale object activated.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger.");
            playerEnter = false;
            scale.gameObject.SetActive(false);
            Debug.Log("Scale object deactivated.");
        }
    }
}
