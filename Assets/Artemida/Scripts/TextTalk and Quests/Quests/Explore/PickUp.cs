using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private TakeQuest selectQuest;
    [SerializeField] private int taskNumber;
    [SerializeField] private int pickCountForDone;
    public int PickUpForDone => pickCountForDone;
    private string text;
    [SerializeField] private int pickCount = 0;
    public int PickUpCount => pickCount;
    private void Start(){
        text = selectQuest.Tasks[taskNumber];
        selectQuest.Tasks[taskNumber] = text+" "+pickCount.ToString()+"/"+pickCountForDone.ToString();
    }
    private void Update(){
        if(pickCount >= pickCountForDone && selectQuest.addTask){
            selectQuest.DoneTask(taskNumber);
        }
    }
    public void PickUpItem(){
        pickCount++;
        selectQuest.TaskMenager.UpdateTaskText(taskNumber, text+" "+pickCount.ToString()+"/"+pickCountForDone.ToString());
    }
}
