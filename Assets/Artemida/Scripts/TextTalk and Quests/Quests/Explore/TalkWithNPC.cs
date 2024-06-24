using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkWithNPC : MonoBehaviour
{
    [SerializeField] private TakeQuest selectQuest;
    [SerializeField] private int taskNumber;
    [SerializeField] private string[] NpcText;
    
    private TalkNPC talkNPC;
    private bool doneCheker, addTask = false;
    private void Start(){
        talkNPC = GetComponent<TalkNPC>();
    }
    private void Update(){
        if(selectQuest.addTask && !doneCheker && !addTask){
            talkNPC.SetMonologue(NpcText);
            talkNPC.endQest = true;
            addTask = true;
        }
        if(talkNPC.finishQuest){
            talkNPC.endQest = false;
            doneCheker = true;
            selectQuest.DoneTask(taskNumber);
            talkNPC.OffText();
            talkNPC.finishQuest = false;

        }
    }

}
