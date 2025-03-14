using NodeCanvas.DialogueTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBasketControl : MonoBehaviour
{
    public enum ReceivingColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple,
        Black,
    }

    public ReceivingColor color;
    public int totality;
    public DialogueTreeController treeOneC;
    [Header("新手教学请勾选is_FirstPass")]
    public bool is_FirstPass=false;

    private void Update()
    {
        //Debug.Log("？");

        if (totality>=7 && !is_FirstPass)
        {
            gameObject.SetActive(false);
            totality = 0;
        }
        if (totality==1 && is_FirstPass)
        {
            if (treeOneC == null) return; 
            treeOneC.StartDialogue();
            gameObject.SetActive(false);
            totality = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰到东西了");
        if (other.gameObject.GetComponent<FruitData>() == null)
        {
            return;
        }
        switch (color)
        {
            case ReceivingColor.Red:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red)
                {
                    Debug.Log("碰到red");
                    Destroy(other.gameObject);
                    totality += 1;
                }
                else if(other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Orange:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Yellow:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Green:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Blue:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Purple:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red)
                {
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Black:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    Destroy(other.gameObject);
                }
                break;
        }
    }
}
