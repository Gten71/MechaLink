using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private TakeQuest selectQuest;
    [SerializeField] private int taskNumber;
    [SerializeField] private int killCountForDone;
    private string text;
    [SerializeField] private int killCount = 0;
    private SpawnEnemy spawnEnemy;
    private void Start(){
        spawnEnemy = GetComponent<SpawnEnemy>();
        text = selectQuest.Tasks[taskNumber];
        selectQuest.Tasks[taskNumber] = text+" "+killCount.ToString()+"/"+killCountForDone.ToString();
    }
    private void Update(){
        if(killCount >= killCountForDone && selectQuest.addTask){
            selectQuest.DoneTask(taskNumber);
        }else if(selectQuest.addTask){
            for(int i = spawnEnemy.allEnemies.Count - 1; i >= 0; i--){
                if(spawnEnemy.allEnemies[i] == null){
                    killCount++;
                    spawnEnemy.allEnemies.RemoveAt(i);
                    selectQuest.TaskMenager.UpdateTaskText(taskNumber, text+" "+killCount.ToString()+"/"+killCountForDone.ToString());
                }
            }
        }
    }
}
