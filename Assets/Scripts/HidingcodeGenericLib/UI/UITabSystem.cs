using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class UITabSystem : MonoBehaviour
{
    
    public int totalTabs { get; private set; }
    public int currentTabIndex { get; private set; }
    
    [Header("References")]
    [SerializeField] private GameObject[] uiTabs;
    

    // Start is called before the first frame update
    void Start()
    {
        totalTabs = uiTabs.Length;
    }
    
    public void SetActiveTabIndex(int index)
    {
        if (index < 0 || index >= uiTabs.Length)
        {
            Debug.LogError("UI Tab System: Invalid index");
            return;
        }

        uiTabs[currentTabIndex].SetActive(false);
        currentTabIndex = index;
        uiTabs[currentTabIndex].SetActive(true);
        
        //onTabIndexChange?.Invoke(currentTabIndex, totalTabs);
        // for (int i = 0; i < uiTabs.Length; i++)
        // {
        //     if (i == index)
        //     {
        //         uiTabs[i].SetActive(true);
        //     }
        //     else
        //     {
        //         uiTabs[i].SetActive(false);
        //     }
        // }
    }
    
    public void MoveToNextTab()
    {
        if (currentTabIndex < totalTabs - 1)
        {
            SetActiveTabIndex(currentTabIndex + 1);
        }
    }
    
    public void MoveToPreviousTab()
    {
        if (currentTabIndex > 0)
        {
            SetActiveTabIndex(currentTabIndex - 1);
        }
    }
}
