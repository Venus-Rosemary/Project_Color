using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    public static UIManagement Instance;

    public StartPlane mainPlane;

    public EndPlane endPlane;

    public GamePlane gamePlane;

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

    }

    //关闭所有界面
    public void CloseAllPlane()
    {
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
}
