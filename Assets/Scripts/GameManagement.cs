﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance;

    [Header("普通关卡数据")]

    public bool commonLevel;                //普通关卡
    public List<FruitBasketControl> first_Current_Data;         //第一轮关卡数据桶
    public List<FruitBasketControl> second_Current_Data;        //第二轮关卡数据桶
    public bool _startSecond;                                   //是否开启第二轮

    [Header("困难关卡")]
    public bool difficultyLevel;            //困难关卡
    public List<FruitBasketControl> difficulty_Current_Data;


    [Header("人物血量")]
    public int HP = 4;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    //移除数据
    public void RemoveFruitBasket()
    {
        if (first_Current_Data.Count == 1)
        {
            _startSecond = true;
            FruitCreatePointMags.Instance.commonSecondStart = true;
            first_Current_Data.Clear();
            Debug.Log("普通关卡第二阶段开始----");
            return;
            //开始第二轮的篮子生成
        }
        for (int i = 0; i < first_Current_Data.Count; i++)
        {
            if (first_Current_Data[i]._isFillBasket)
                first_Current_Data.Remove(first_Current_Data[i]);
        }
    }

    public void RemoveSecondFruitBasket()
    {
        if (second_Current_Data.Count == 1)
        {
            //游戏结束
            second_Current_Data.Clear();
            StartPlane.Instance.OpenCommonEndPlane();
        }

        for (int i = 0; i < second_Current_Data.Count; i++)
        {
            if (second_Current_Data[i]._isFillBasket)
                second_Current_Data.Remove(second_Current_Data[i]);
        }
    }

    //数据初始化
    public void InitData()
    {
        HP = 4;
        first_Current_Data.Clear();
        second_Current_Data.Clear();
        difficulty_Current_Data.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (commonLevel)
                StartPlane.Instance.OpenCommonEndPlane();
            else
                StartPlane.Instance.OpenDifficultyEndPlane();
        }
    }


    #region 人物身上血量

    //扣血
    public void InjuredHP()
    {
        HP -= 1;
        if (HP == 0)
        {
            HP = 0;
            StartPlane.Instance.OpenCommonEndPlane();
            //游戏结束
        }
    }

    #endregion

}
