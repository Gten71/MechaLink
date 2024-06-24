using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private Canvas[] _pages;
    [SerializeField] private Canvas _menu;
    private int _pageIndex = 0;
    public void CloseTutorial()
    {
        _pages[_pageIndex].enabled = false;
        _menu.enabled = true;
        _pageIndex = 0;
    }

    public void NexytPage()
    {
        _pages[_pageIndex].enabled = false;
        _pageIndex++;
        _pages[_pageIndex].enabled = true;
    }
    public void BackPage()
    {
        _pages[_pageIndex].enabled = false;
        _pageIndex--;
        _pages[_pageIndex].enabled = true;
    }
}
