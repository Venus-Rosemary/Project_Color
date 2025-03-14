using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitData : MonoBehaviour
{
    public FruitDataClass fruitDataClass;

    public void FruitInit(FruitDataClass _fruitData,bool _change = false)
    {
        fruitDataClass = _fruitData;

        if (_change)
            ChangeFruitColor();
    }

    //返回水果颜色
    public void ChangeFruitColor()
    {
        fruitDataClass.fruitMaterial = FruitColorRGB(fruitDataClass.colorType);
    }

    //返还颜色RGB值
    public Material FruitColorRGB(FruitColorType fruitColorType)
    {
        switch (fruitColorType)
        {
            case FruitColorType.Red:
                return fruitDataClass.materialsList[0];
            case FruitColorType.Orange:
                return fruitDataClass.materialsList[1];
            case FruitColorType.Yellow:
                return fruitDataClass.materialsList[2];
            case FruitColorType.Green:
                return fruitDataClass.materialsList[3];
            case FruitColorType.Blue:
                return fruitDataClass.materialsList[4];
            case FruitColorType.Purple:
                return fruitDataClass.materialsList[5];
            case FruitColorType.Black:
                return fruitDataClass.materialsList[6]; 
        }

        return null;
    }
}

//水果类型
public enum FruitType
{
    Apple,
    Orange,
    Mangosteen,

}

//水果颜色
public enum FruitColorType
{ 
    Red, 
    Orange, 
    Yellow,
    Green,
    Blue,
    Purple,
    Black,

}

[Serializable]
public class FruitDataClass
{
    public FruitType fruitType;
    public FruitColorType colorType;
    public GameObject fruitPrefab;
    public Material fruitMaterial;
    public List<Material> materialsList;

}
