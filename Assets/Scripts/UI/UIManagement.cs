using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    public static UIManagement Instance;

    public StartPlane mainPlane;

    public EndPlane endPlane;

    public GamePlane gamePlane;
    public GameObject colorPlane;
    public GameObject hpPlane;

    public GameObject redWarnObj;
    public GameObject addTextObj;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    //打开主界面
    public void OpenMainPlane()
    {
        CloseAllPlane();
        CloseLevelData();
        mainPlane.gameObject.SetActive(true);
    }

    //打开结束界面
    public void OpenEndPlane()
    {
        CloseAllPlane();
        CloseLevelData();
        endPlane.gameObject.SetActive(true);
    }

    //打开游戏界面
    public void OpenGamePlane()
    {
        CloseAllPlane();
        gamePlane.gameObject.SetActive(true);
        colorPlane.SetActive(true);
        hpPlane.SetActive(false);
    }
    public void OpenGamePlaneD()
    {
        CloseAllPlane();
        gamePlane.gameObject.SetActive(true);
        colorPlane.SetActive(false);
        hpPlane.SetActive(true);
    }

    //关闭所有界面
    public void CloseAllPlane()
    {
        redWarnObj.SetActive(false);
        mainPlane.gameObject.SetActive(false);
        endPlane.gameObject.SetActive(false);
        gamePlane.gameObject.SetActive(false);
    }

    //关闭关卡数据生成逻辑
    public void CloseLevelData()
    {
        mainPlane.level_Data_Obj.SetActive(false);
        mainPlane.novice_Data_Obj.SetActive(false);
    }

    //打开警告界面
    public void OpenWarnPlane()
    {
        redWarnObj.SetActive(true);
        Invoke("CloseWarnPlane",1.4f) ;
    }

    //关闭警告界面
    public void CloseWarnPlane()
    {
        redWarnObj.SetActive(false);
    }

    //打开加时界面
    public void OpenAddTmpPlane(int timer = 10)
    {
        addTextObj.SetActive(true);
        addTextObj.transform.GetComponentInChildren<TMP_Text>().text = "+" + timer + "秒";
        Invoke("CloseAddTmpPlane", 1.2f);
    }

    //关闭加时界面
    public void CloseAddTmpPlane()
    {
        addTextObj.SetActive(false);
    }
}
