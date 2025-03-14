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
    public bool _isFillBasket;
    public GameObject currentObj;
    [Header("���ֽ�ѧ�빴ѡis_FirstPass")]
    public bool is_FirstPass=false;

    private int rangeTotality;
    private float ActiveTime;
    [Header("�����빴ѡis_ThirdPass")]
    public bool is_ThirdPass = false;
    public GameObject coloured;
    public GameObject colourless;

    // ����Inspector������޸ı���ʱ��Unity����ô˷���
    private void OnValidate()
    {
        //int FirstP = is_FirstPass ? 1 : 0;

        if (is_FirstPass && is_ThirdPass)
        {
            is_FirstPass = false;
            is_ThirdPass = false;
        }

    }

    private void Update()
    {
        //Debug.Log("��");

        if (totality>=7 && !is_FirstPass&&!is_ThirdPass)
        {
            _isFillBasket = true;
            gameObject.SetActive(false);
            totality = 0;
            if (GameManagement.Instance._startSecond)
                GameManagement.Instance.RemoveSecondFruitBasket();
            else
                GameManagement.Instance.RemoveFruitBasket();
        }
        Set_FirstPassBasket();
        Set_ThirdPassBasket();
    }

    //����������ر���ɫ��ʾ
    public void CloseColor()
    {
        if (is_ThirdPass)
        {
            coloured.SetActive(true);
            colourless.SetActive(false);
            //rangeTotality = Random.Range(4, 8);
            rangeTotality = 1;
            ActiveTime = Time.time + 3f;
        }
    }
    public void Set_FirstPassBasket()   //���ֽ�ѧ�Ĺ�������
    {
        if (is_FirstPass)
        {
            if (totality==1)
            {
                if (treeOneC == null) return;
                treeOneC.StartDialogue();
                gameObject.SetActive(false);
                totality = 0;
            }
        }
    }
    public void Set_ThirdPassBasket()   //���ѵĹ�������
    {
        if (is_ThirdPass)
        {
            if (totality == rangeTotality)
            {
                //gameObject.SetActive(false);
                //totality = 0;
            }
            if (Time.time> ActiveTime)
            {
                coloured.SetActive(false);
                colourless.SetActive(true);
            }
        }
    }

    //�����߼���Ѫ
    public void LoseBlood()
    {
        if (is_ThirdPass && totality > rangeTotality)
        {
           GameManagement.Instance.InjuredHP();
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("����������");
        if (other.gameObject.GetComponent<FruitData>() == null)
        {
            return;
        }
        #region ������жϣ�û������������һ��
        switch (color)
        {
            case ReceivingColor.Red:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                    LoseBlood();
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
                    LoseBlood();
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
                    LoseBlood();
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
                    LoseBlood();
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
                    LoseBlood();
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
                    LoseBlood();
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
                    LoseBlood();
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
        #endregion
    }
}
