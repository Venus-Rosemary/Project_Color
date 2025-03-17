using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlane : MonoBehaviour
{
    public GameObject colorCardPrefab;
    public Transform colorCardTrans;

    //初始化第一阶段
    public void InitFristGameUI()
    {
        ClearTrans();
        for (int i = 0; i < GameManagement.Instance.first_Current_Data.Count; i++)
        {
            GameObject GO = Instantiate(colorCardPrefab, colorCardTrans);
            GO.GetComponent<ColourCard>().InitColorCard(GameManagement.Instance.first_Current_Data[i].color);
        }
    }

    //初始化第二阶段
    public void InitSecondGameUI()
    {
        ClearTrans();
        for (int i = 0; i < GameManagement.Instance.second_Current_Data.Count; i++)
        {
            GameObject GO = Instantiate(colorCardPrefab, colorCardTrans);
            GO.GetComponent<ColourCard>().InitColorCard(GameManagement.Instance.second_Current_Data[i].color);
        }
    }

    //清空子物体
    public void ClearTrans()
    { 
        for(int i = 0; i < colorCardTrans.childCount; i++)
        {
            Destroy(colorCardTrans.GetChild(i).gameObject);
        }
    }
}
