using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaseMainMenu : MonoBehaviour
{
    private Transform currentCanvase;
    [SerializeField] private Transform _tutorial;

    private void Start()
    {
        currentCanvase = gameObject.transform.Find("MainCanvase(Start)");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscMenu();
        }
    }
    
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LastSave()
    {
        ChangeCanvase("LastSave");
    }
    public void Tutorial(){
        ChangeCanvase("TutorialFirstPage");
    }

    public void Saves()
    {
        ChangeCanvase("Saves");
    }

    public void Settings()
    {
        ChangeCanvase("Settings");
    }

    public void Authors()
    {
        ChangeCanvase("Authors");
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void EscMenu()
    {
        ChangeCanvase("MainCanvase(Start)");
    }
    
    private void ChangeCanvase(string In)
    {
        
        if(In == currentCanvase.name){
            return;
        }
        Transform childTransformFrom = currentCanvase;
        currentCanvase = gameObject.transform.Find(In);
        if(In == "TutorialFirstPage"){
            currentCanvase = _tutorial;
        }
        currentCanvase.gameObject.GetComponent<Canvas>().enabled = true;
        childTransformFrom.gameObject.GetComponent<Canvas>().enabled = false;
    }
}
