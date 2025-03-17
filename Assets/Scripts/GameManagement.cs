using System.Collections;
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
    public List<FruitBasketControl> first_difficulty_Current_Data;
    public List<FruitBasketControl> second_difficulty_Current_Data;
    public bool _startDifficultySecond;                         //开启困难关卡第二阶段
    public FruitBasketPosPointMage fruitBaskeData;

    [Header("人物血量")]
    public int HP = 4;
    public List<GameObject> HpImage;

    [Header("颜色")]
    public Color red;
    public Color orange;
    public Color yellow;
    public Color green;
    public Color blue;
    public Color purple;
    public Color black;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    #region  普通关卡
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
            UIManagement.Instance.OpenEndPlane();
        }

        for (int i = 0; i < second_Current_Data.Count; i++)
        {
            if (second_Current_Data[i]._isFillBasket)
                second_Current_Data.Remove(second_Current_Data[i]);
        }
    }
    #endregion


    #region  困难关卡

    //第一阶段
    public void RemoveDifficultyFruitBasketData()
    {
        if (first_difficulty_Current_Data.Count == 0)
        {
            _startDifficultySecond = true;
            fruitBaskeData.CreateScondDifficulty();
            first_difficulty_Current_Data.Clear();
            Debug.Log("困难关卡第二阶段开始----");
            return;
            //开始第二轮的篮子生成
        }
        for (int i = 0; i < first_difficulty_Current_Data.Count; i++)
        {
            if (first_difficulty_Current_Data[i]._isFillBasket)
                first_difficulty_Current_Data.Remove(first_difficulty_Current_Data[i]);
        }
    }

    //第二阶段
    public void RemoveSecondDifficultyFruitBasketData()
    {
        if (second_difficulty_Current_Data.Count == 0)
        {
            //游戏结束
            second_difficulty_Current_Data.Clear();
            UIManagement.Instance.OpenEndPlane();
        }

        for (int i = 0; i < second_difficulty_Current_Data.Count; i++)
        {
            if (second_difficulty_Current_Data[i]._isFillBasket)
                second_difficulty_Current_Data.Remove(second_difficulty_Current_Data[i]);
        }
    }


    #endregion


    //数据初始化
    public void InitData()
    {
        HP = 4;
        for (int i = 0; i < HpImage.Count; i++)
        {
            HpImage[i].gameObject.SetActive(true);
        }
        _startSecond = false;
        _startDifficultySecond = false;
        first_Current_Data.Clear();
        second_Current_Data.Clear();
        first_difficulty_Current_Data.Clear();
        first_difficulty_Current_Data.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManagement.Instance.OpenEndPlane();
        }
    }


    #region 人物身上血量

    //扣血
    public void InjuredHP()
    {
        HP -= 1;
        HpImage[HP].gameObject.SetActive(false);
        if (HP == 0)
        {
            HP = 0;
            UIManagement.Instance.OpenEndPlane();
            //游戏结束
            return;
        }
    }

    #endregion

}
