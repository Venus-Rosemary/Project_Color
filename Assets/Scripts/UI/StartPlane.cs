using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class StartPlane : MonoBehaviour
{
    public static StartPlane Instance;
    public Button common_BTN;
    public Button difficulty_BTN;

    public GameObject level_Obj;

    public GameObject common_End_Obj;
    public GameObject start_Obj;
    public GameObject difficulty_End_Obj;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        common_BTN.onClick.AddListener(CommonLevelClick);
        difficulty_BTN.onClick.AddListener(DifficultyLevelClick);
    }

    //普通关卡开始
    public void CommonLevelClick()
    {
        GameManagement.Instance.commonLevel = true;
        GameManagement.Instance.difficultyLevel = false;
        level_Obj.SetActive(true);
        start_Obj.SetActive(false);

    }

    //困难关卡开始
    public void DifficultyLevelClick()
    {
        GameManagement.Instance.commonLevel = false;
        GameManagement.Instance.difficultyLevel = true;
        level_Obj.SetActive(true);
        start_Obj.SetActive(false);
    }

    public void OpenCommonEndPlane()
    {
        level_Obj.SetActive(false);
        common_End_Obj.SetActive(true);
    }

    public void OpenDifficultyEndPlane()
    {
        level_Obj.SetActive(false);
        difficulty_End_Obj.SetActive(true);
    }

    public void CloseEndPlane()
    {
        start_Obj.SetActive(true);
        difficulty_End_Obj.SetActive(false);
        common_End_Obj.SetActive(false);

    }

    public void BackMain()
    { 
    
    }
}

