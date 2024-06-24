using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public bool Save = false;
    public bool Load = false;
    [SerializeField] private string textForSave;
    [SerializeField] private string textForLoad;
    [SerializeField] private Transform imgShure;
    private TextMeshProUGUI textShure;

    private void Start(){
        textShure = imgShure.GetChild(0).GetComponent<TextMeshProUGUI>();
    }
    private void Update() {
        if(Save){
            textShure.text = textForSave;
        } else if(Load){
            textShure.text = textForLoad;
        }
    }
    public void BtnYes(){
        if(Save){
            //логика сохранения
            DataPersistenceManager.instance.SaveGame();
            imgShure.gameObject.SetActive(false);
        }else if(Load){
            //логика загрузки
            DataPersistenceManager.instance.LoadGame();
        }
    }
    public void BtnNo(){
        imgShure.gameObject.SetActive(false);
    }
    public void OpenShure(){
        imgShure.gameObject.SetActive(true);
    }
    public void CloseShure(){
        imgShure.gameObject.SetActive(false);
    }
}
