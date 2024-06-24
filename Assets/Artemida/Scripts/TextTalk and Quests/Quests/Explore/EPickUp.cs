using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EPickUp : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Canvas canvas;
    [SerializeField] private string firstText = "Press E ";
    [SerializeField] private TakeQuest selectQuest;
    [SerializeField] private PickUp pickUp;
      private bool enterCheker = false;
    private void Start()
    {
        canvas = gameObject.GetComponentInChildren<Canvas>();
        text = canvas.GetComponentInChildren<TextMeshProUGUI>();
        text.enabled = false;
    }
    private void CanvasRotation()
    {
        if (canvas.transform.rotation != Camera.main.transform.rotation)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }
    private void Update(){
        CanvasRotation();
                if (Input.GetKeyDown(KeyCode.E) && enterCheker && (pickUp.PickUpCount < pickUp.PickUpForDone))
        {
            pickUp.PickUpItem();
            Destroy(gameObject);           
        }
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && selectQuest.addTask && (pickUp.PickUpCount < pickUp.PickUpForDone)){
            enterCheker = true;
            text.text = firstText;
            text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterCheker = false;
            text.text = firstText;
            text.enabled = false;
            
        }
    }
}
