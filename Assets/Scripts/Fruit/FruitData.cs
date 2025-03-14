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

        Debug.Log("我是" + fruitDataClass.fruitType + "颜色：" + fruitDataClass.colorType);
    }

    //返回水果颜色
    public void ChangeFruitColor()
    {
        int randomColor = UnityEngine.Random.Range(0,7);
        fruitDataClass.colorType = ChangeFruitType(randomColor);
        fruitDataClass.fruitPrefab.GetComponent<MeshRenderer>().material = FruitColorRGB(randomColor);
    }

    //返还颜色RGB值
    public Material FruitColorRGB(int ID)
    {
        return fruitDataClass.materialsList[ID];
    }

    //返还颜色枚举类型
    public FruitColorType ChangeFruitType(int ID)
    {
        switch (ID)
        {
            case 0:
                return FruitColorType.Red;
            case 1:
                return FruitColorType.Orange;
            case 2:
                return FruitColorType.Yellow;
            case 3:
                return FruitColorType.Green;
            case 4:
                return FruitColorType.Blue;
            case 5:
                return FruitColorType.Purple;
            case 6:
                return FruitColorType.Black;
        }
        return FruitColorType.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Plane") return;

        if (other.gameObject.tag == "Plane")
        {
            Destroy(this.gameObject);
        }
    }
}

//水果类型
public enum FruitType
{
    Apple,
    Orange,
    Banana,
    GreenMango,
    Blueberry,
    Grape,
    Mangosteen,
    None,

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
    None
}

[Serializable]
public class FruitDataClass
{
    public FruitType fruitType;
    public FruitColorType colorType;
    public GameObject fruitPrefab;
    public List<Material> materialsList;

}
