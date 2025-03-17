using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static FruitBasketControl;

public class ColourCard : MonoBehaviour
{
    //颜色
    public Image imageColor;

    //初始化
    public void InitColorCard(ReceivingColor _fruitColorType)
    {
        imageColor.color = GetCardColorUI(_fruitColorType);
    }

    //根据水果颜色返回对应的UI颜色
    public Color GetCardColorUI(ReceivingColor fruitColorType)
    {
        switch (fruitColorType)
        {
            case ReceivingColor.Red:
                return GameManagement.Instance.red;
            case ReceivingColor.Orange:
                return GameManagement.Instance.orange;
            case ReceivingColor.Yellow:
                return GameManagement.Instance.yellow;
            case ReceivingColor.Green:
                return GameManagement.Instance.green;
            case ReceivingColor.Blue:
                return GameManagement.Instance.blue;
            case ReceivingColor.Purple:
                return GameManagement.Instance.purple;
            case ReceivingColor.Black:
                return GameManagement.Instance.black;
        }
        return Color.white;
    }

}
