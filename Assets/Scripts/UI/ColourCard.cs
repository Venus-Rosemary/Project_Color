using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourCard : MonoBehaviour
{
    //颜色
    public Image imageColor;

    //初始化
    public void InitColorCard(FruitColorType _fruitColorType)
    {
        imageColor.color = GetCardColorUI(_fruitColorType);
    }

    //根据水果颜色返回对应的UI颜色
    public Color GetCardColorUI(FruitColorType fruitColorType)
    {
        switch (fruitColorType)
        {
            case FruitColorType.Red:
                return GameManagement.Instance.red;
            case FruitColorType.Orange:
                return GameManagement.Instance.orange;
            case FruitColorType.Yellow:
                return GameManagement.Instance.yellow;
            case FruitColorType.Green:
                return GameManagement.Instance.green;
            case FruitColorType.Blue:
                return GameManagement.Instance.blue;
            case FruitColorType.Purple:
                return GameManagement.Instance.purple;
            case FruitColorType.Black:
                return GameManagement.Instance.black;
        }
        return Color.white;
    }

}
