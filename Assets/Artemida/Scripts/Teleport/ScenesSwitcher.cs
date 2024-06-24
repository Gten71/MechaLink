using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSwitcher : MonoBehaviour
{
    private Scene _currentScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            switch (_currentScene.name)
            {
                case "MonsterArena":
                    SceneManager.LoadScene("MainTest");
                    break;
                case "MainTest":
                    SceneManager.LoadScene("MonsterArena");
                    break;
            }
        }
    }
}
