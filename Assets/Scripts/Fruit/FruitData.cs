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

        Debug.Log("����" + fruitDataClass.fruitType + "��ɫ��" + fruitDataClass.colorType);
    }

    //����ˮ����ɫ
    public void ChangeFruitColor()
    {
        int randomColor = UnityEngine.Random.Range(0,7);
        fruitDataClass.colorType = ChangeFruitType(randomColor);
        fruitDataClass.fruitPrefab.GetComponent<MeshRenderer>().material = FruitColorRGB(randomColor);
    }

    //������ɫRGBֵ
    public Material FruitColorRGB(int ID)
    {
        return fruitDataClass.materialsList[ID];
    }

    //������ɫö������
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

//ˮ������
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

//ˮ����ɫ
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
