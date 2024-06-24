using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSettings : MonoBehaviour
{
    private Transform currentCanvase;
     private void Start()
    {
        currentCanvase = gameObject.transform.Find("Visual");
    }
    
    public void Audio(){
        ChangeCanvase("Audio");
    }

    public void Visual(){
        ChangeCanvase("Visual");
    }
    public void Game(){
        ChangeCanvase("Game");
    }
    public void Inputs(){
        ChangeCanvase("Inputs");
    }
    public void ToggleFullscreen()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
            Debug.Log("Fullscreen");
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
            Debug.Log("Windowed");
        }
    }
    public void OnChangeResolution_1920x1080()
    {
        ChangeResolution(1920,1080);
        Debug.Log("1920x1080");
    }
    public void OnChangeResolution_1680x1050()
    {
        ChangeResolution(1680,1050);
        Debug.Log("1680x1050");
    }
    public void OnChangeResolution_1600x900()
    {
        ChangeResolution(1600,900);
        Debug.Log("1600x900");
    }
    public void OnChangeResolution_1440x900()
    {
        ChangeResolution(1440,900);
    }
    public void OnChangeResolution_1400x1050()
    {
        ChangeResolution(1400,1050);
    }
    public void OnChangeResolution_1366x768()
    {
        ChangeResolution(1366,768);
    }
    public void OnChangeResolution_1280x960()
    {
        ChangeResolution(1280,960);
    }
    private void ChangeResolution(int width, int height)
    {
        bool fullscreen = Screen.fullScreen;
        Screen.SetResolution(width, height, fullscreen);
    }
     public void EnableVSync()
    {
        QualitySettings.vSyncCount = 1;
    }

    public void DisableVSync()
    {
        QualitySettings.vSyncCount = 0;
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
