using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore : MonoBehaviour
{
    [SerializeField] private TakeQuest selectQuest;
    [SerializeField] private int taskNumber;
     private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && selectQuest.addTask){
            selectQuest.DoneTask(taskNumber);
        }
    }

}
