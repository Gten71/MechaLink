using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMainGame : MonoBehaviour
{
    private Transform currentCanvase;
    private bool OpenTask= false;
    private SaveAndLoad saveAndLoad;
    [SerializeField] private CanvasSettings settingsWindows;
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        currentCanvase = gameObject.transform.Find("MainCanvase(Start)");
        saveAndLoad = FindObjectOfType<SaveAndLoad>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          saveAndLoad.Save = false;
          saveAndLoad.Load = false;
          saveAndLoad.CloseShure();
            if(OpenTask){
                OpenTask = false;
                ChangeCanvase("MainCanvase(Start)");
            }
            else{
            EscGame();
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab)){
            AudioUiClick();
            if(!OpenTask){
                 OpenTask = true;
            Camera.main.GetComponent<CinemachineBrain>().enabled = false;

                OpenTasks();
            }
            else{
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;

                OpenTask = false;
                ChangeCanvase("MainCanvase(Start)");
            }
           
        }
    }
    public void AudioUiClick(){
        audio.Play();
    }
    
    //MainGame
    public void EscGame()
    {
        AudioUiClick();
        if(currentCanvase.name == "Settings"){
            settingsWindows.gameObject.SetActive(false);
        }
        if (currentCanvase.name != "CanvasESC")
        {
            Camera.main.GetComponent<CinemachineBrain>().enabled = false;
            ChangeCanvase("CanvasESC");
        }
        else
        {
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            ChangeCanvase("MainCanvase(Start)");
        }

    }
    
        //EscMenu 
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveGame()
    {
        ChangeCanvase("UploadAndSave");
        saveAndLoad.Save = true;
    }

    public void Upload()
    {
        ChangeCanvase("UploadAndSave");
        saveAndLoad.Load = true;
    }

    public void SettingsInGame()
    {
        ChangeCanvase("Settings");
        settingsWindows.gameObject.SetActive(true);
    }
    public void TutorialMenu()
    {
        ChangeCanvase("Tutorial");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void OpenTasks(){
        ChangeCanvase("Tasks");
    }
    private void ChangeCanvase(string In)
    {
        if(In == currentCanvase.name){
            return;
        }
        Transform childTransformFrom = currentCanvase;
        currentCanvase = gameObject.transform.Find(In);
        currentCanvase.gameObject.GetComponent<Canvas>().enabled = true;
        childTransformFrom.gameObject.GetComponent<Canvas>().enabled = false;
    }
}
