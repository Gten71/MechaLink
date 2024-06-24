using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowNameTaskInMenu : MonoBehaviour
{
    private int indexNowOpen = 0;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private List<TextMeshProUGUI> _namesBtns = new List<TextMeshProUGUI>(7);
    [SerializeField] private TextMeshProUGUI _description;
    private List<string> _descriptionBtns = new List<string>(7);
    [SerializeField] private TextMeshProUGUI[] _tasksShow = new TextMeshProUGUI[4];
    private string[,] _tasks = new string[7, 4];
    private bool[,] _doneTasks = new bool[7, 4];

    private int index = 0;

    public  void AddTask(string name, string description, string[] tasks,bool[] donesTasks){
        if (index < _namesBtns.Count) {
        _namesBtns[index].text = name;
        _descriptionBtns.Add(description);
        for (int i = 0; i < tasks.Length; i++) {
            _tasks[index, i] = tasks[i];
            _doneTasks[index, i] = donesTasks[i];
        }
        index++;
    }
    }
  public void RemoveTask(string name){
    int removeIndex = -1;
    for(int i = 0; i < index; i++){
        if(_namesBtns[i].text == name){
            removeIndex = i;
            break;
        }
    }
    if(removeIndex != -1){
        for(int i = removeIndex; i < index - 1; i++){
            _namesBtns[i].text = _namesBtns[i + 1].text;
            _descriptionBtns[i] = _descriptionBtns[i + 1];
            for(int j = 0; j < 4; j++){
                _tasks[i, j] = _tasks[i + 1, j];
                _doneTasks[i, j] = _doneTasks[i + 1, j];
            }
        }

        _namesBtns[index - 1].text = "";
        _descriptionBtns[index - 1] = "";
        for(int j = 0; j < 4; j++){
            _tasks[index - 1, j] = "";
            _doneTasks[index - 1, j] = false;
        }

        index--;

        UpdateVisuals();
    }
}

private void UpdateVisuals() {
    if(index > 0){
        for(int i = 0; i < _namesBtns.Count; i++){
            _namesBtns[i].enabled = i < index;
        }
        _name.text = _namesBtns[indexNowOpen].text;
        _description.text = _descriptionBtns[indexNowOpen];
        for(int j = 0; j < 4; j++){
            _tasksShow[j].text = _tasks[indexNowOpen, j];
            if(_tasks[indexNowOpen, j] != "" && _doneTasks[indexNowOpen, j]){
                _tasksShow[j].text += " ✔";
            }
        }
    } else {
        for(int i = 0; i < _namesBtns.Count; i++){
            _namesBtns[i].enabled = false;
        }
        _name.text = "Empty";
        _description.text = "Now there are no tasks";
        for(int j = 0; j < 4; j++){
            _tasksShow[j].text = " ";
        }
    }
}

public void UpdateTaskText(int taskIndex, string newText) {
    _tasks[indexNowOpen, taskIndex] = newText;
    _tasksShow[taskIndex].text = newText;
}
public void UdateBools(string name,bool[] bools){
    for(int i = 0; i < _namesBtns.Count; i++){
        if(_namesBtns[i].text == name){
            for(int j = 0; j < 4; j++){
                _doneTasks[i, j] = bools[j];
            }
        }
    }
}

    private void Update() {
        if(index > 0){
            for(int i = 0; i < index; i++){ 
                _namesBtns[i].enabled = true;
                _name.text = _namesBtns[indexNowOpen].text;
                _description.text = _descriptionBtns[indexNowOpen];
                for(int j = 0; j < 4; j++){
                    if(_tasks[indexNowOpen, j] == ""){
                        _tasksShow[j].text = "";
                    }
                    else{
                    _tasksShow[j].text = _tasks[indexNowOpen, j];

                    }
                    if(_doneTasks[indexNowOpen, j]){
                        _tasksShow[j].text += " ✔";
                    }
                }
            }
        }
        else{
            for(int i = 0; i < _namesBtns.Count; i++){
                _namesBtns[i].enabled = false;
            }
            _name.text = "Empty";
            _description.text = "Now there are no tasks";
            for(int j = 0; j < 4; j++){
                _tasksShow[j].text = " ";
            }
        }
    }

    public string Get3Name(int index){
        if(_namesBtns[index].enabled){
            return _namesBtns[index].text;
        }
        return "";
    }
    public string Get3Tasks(int index){ 
        if(_namesBtns[index].enabled){
            for(int i = 0; i < 4; i++){
                if(!_doneTasks[index, i]){
                    return _tasks[index, i];
                }
            }
        }
        return "";
    }
    public void N1(){
        indexNowOpen = 0;
    }
    public void N2(){
        indexNowOpen = 1;
    }
    public void N3(){
        indexNowOpen = 2;
    }
    public void N4(){
        indexNowOpen = 3;
    }
    public void N5(){
        indexNowOpen = 4;
    }
    public void N6(){
        indexNowOpen = 5;
    }
    public void N7(){
        indexNowOpen = 6;
    }
}
