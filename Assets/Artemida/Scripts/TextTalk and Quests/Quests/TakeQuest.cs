using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeQuest : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private string[] tasks;
    public string[] Tasks => tasks;
    [SerializeField]private bool[] doneQuests = new bool[4];
    [SerializeField] private string[] NpcText;
    [SerializeField] private string[] endNPCText;
    [SerializeField] TalkNPC endNPC;
    private TalkNPC talkNPC;
    private ShowNameTaskInMenu taskMenager;
    public ShowNameTaskInMenu TaskMenager => taskMenager;
    public bool addTask=false;
    private bool getTextEndNPC = false;

    private void Start(){
        talkNPC = GetComponent<TalkNPC>();
        taskMenager = FindObjectOfType<ShowNameTaskInMenu>();
        talkNPC.SetMonologue(NpcText);
        for(int i = 0; i < doneQuests.Length; i++){
            doneQuests[i] = false;
        }
       talkNPC.quest = true;
    }
    private void Update(){
        if(talkNPC.takeQuest){
            if(!addTask){
            taskMenager.AddTask(name, description, tasks, doneQuests);
            addTask = true;
            }
            taskMenager.UdateBools(name, doneQuests);
        }
        CheckLastQuest();
        if(endNPC.finishQuest){
            taskMenager.RemoveTask(name);
            talkNPC.quest = false;
            talkNPC.takeQuest = false;
            endNPC.endQest = false;
            endNPC.finishQuest = false;
            endNPC.OffText();
            gameObject.GetComponent<TakeQuest>().enabled = false;
        }
        for(int i = 0; i < 4; i++){
            if(tasks[i]==""){
                doneQuests[i] = true;
            }
        }
    }
    
    public void DoneTask(int number){
        doneQuests[number] = true;
    }
    private void CheckLastQuest(){
        for(int i = 0; i < 3; i++){
            if(!doneQuests[i]){
                return;
            }
        }
        if(!getTextEndNPC){
        endNPC.SetMonologue(endNPCText);
        getTextEndNPC = true;
        }
        endNPC.endQest = true;
    }
}
