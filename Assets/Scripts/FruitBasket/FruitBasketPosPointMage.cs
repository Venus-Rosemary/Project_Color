using System.Collections.Generic;
using UnityEngine;

public class FruitBasketPosPointMage : MonoBehaviour
{
    public List<FruitBasketControl> fruitBasketList;

    public List<Transform> commonPos_A_List;
    public List<Transform> commonPos_B_List;

    public int firstNum = 3;
    public int scondNum = 4;
    public int thirdlyNum = 4;

    public bool secondStart;
   

    private void OnEnable()
    {
        if (GameManagement.Instance.commonLevel)
            CreateCommonFirst();

        if (GameManagement.Instance.difficultyLevel)
            CreateDifficulty();
    }

    //生成普通关卡第一阶段水果桶
    public void CreateCommonFirst()
    {
        fruitBasketList.Shuffles();
        ClearFirstCommonPos(commonPos_B_List);
        for (int i = 0; i < fruitBasketList.Count; i++)
        {
            if (i < firstNum)
            {
                GameObject ga = Instantiate(fruitBasketList[i].currentObj, commonPos_A_List[i]);
                GameManagement.Instance.first_Current_Data.Add(ga.GetComponent<FruitBasketControl>());
            }
        }

        UIManagement.Instance.gamePlane.InitFristGameUI();
    }

    //生成普通关卡第二阶段水果桶
    public void CreateCommonSecond()
    {
        fruitBasketList.Shuffles();
        ClearFirstCommonPos(commonPos_A_List);
        for (int i = 0; i < fruitBasketList.Count; i++)
        {
            if (i < scondNum)
            {
                GameObject ga = Instantiate(fruitBasketList[i].currentObj, commonPos_B_List[i]);
                GameManagement.Instance.second_Current_Data.Add(ga.GetComponent<FruitBasketControl>());
            }
        }
        UIManagement.Instance.gamePlane.InitSecondGameUI();
    }

    //生成困难关卡水果桶
    public void CreateDifficulty()
    {
        fruitBasketList.Shuffles();
        ClearFirstCommonPos(commonPos_B_List);
        for (int i = 0; i < fruitBasketList.Count; i++)
        {
            if (i < thirdlyNum)
            {
                GameObject ga = Instantiate(fruitBasketList[i].currentObj, commonPos_B_List[i]);
                ga.GetComponent<FruitBasketControl>().is_ThirdPass = true;
                ga.GetComponent<FruitBasketControl>().CloseColor();
                GameManagement.Instance.difficulty_Current_Data.Add(ga.GetComponent<FruitBasketControl>());
            }
            else
                return;

        }
    }


    private void Update()
    {
        if (!secondStart && GameManagement.Instance._startSecond)
        {
            //测试
            secondStart = true;
            FruitCreatePointMags.Instance.commonSecondStart = true;
            CreateCommonSecond();

        }
    }


    //清空物体
    public void ClearFirstCommonPos(List<Transform> _transforms)
    {
        for (int i = 0; i < _transforms.Count; i++)
        {
            for (int j = 0; j < _transforms[i].childCount; j++)
            {   
                Destroy(_transforms[i].GetChild(j).gameObject);
            }
        }
    
    }

    private void OnDisable()
    {
        secondStart = false;
        GameManagement.Instance.InitData();
        ClearFirstCommonPos(commonPos_A_List);
        ClearFirstCommonPos(commonPos_B_List);
    }

}
//打乱List顺序
public static class ListExtensions
{
    public static void Shuffles<T>(this List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}
