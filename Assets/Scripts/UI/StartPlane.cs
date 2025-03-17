using NodeCanvas.DialogueTrees;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartPlane : MonoBehaviour
{
    public static StartPlane Instance;

    public Button novice_BTN;
    public Button common_BTN;
    public Button difficulty_BTN;
    public Button exit_BTN;
    
    public GameObject level_Data_Obj;
    public GameObject novice_Data_Obj;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        novice_BTN.onClick.AddListener(NoviceLevelClick);
        common_BTN.onClick.AddListener(CommonLevelClick);
        difficulty_BTN.onClick.AddListener(DifficultyLevelClick);
        exit_BTN.onClick.AddListener(ExitClick);
    }

    public void NoviceLevelClick()
    {
        novice_Data_Obj.SetActive(true);
        novice_Data_Obj.GetComponent<DialogueTreeController>().StartDialogue();
        gameObject.SetActive(false);
    }

    //普通关卡开始
    public void CommonLevelClick()
    {
        GameManagement.Instance.commonLevel = true;
        GameManagement.Instance.difficultyLevel = false;
        level_Data_Obj.SetActive(true);
        gameObject.SetActive(false);

    }

    //困难关卡开始
    public void DifficultyLevelClick()
    {
        GameManagement.Instance.commonLevel = false;
        GameManagement.Instance.difficultyLevel = true;
        level_Data_Obj.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitClick()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    

}

