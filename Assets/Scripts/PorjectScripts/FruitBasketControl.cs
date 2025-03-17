using NodeCanvas.DialogueTrees;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int totality=0;
    private int maxValue = 7;
    public DialogueTreeController treeOneC;
    public bool _isFillBasket;
    public GameObject currentObj=null;
    public GameObject CountUI_Prefab=null;
    private GameObject CountUI_P=null;
    private TMP_Text CountUI=null;

    [Header("新手教学请勾选is_FirstPass")]
    public bool is_FirstPass=false;

    private int rangeTotality;
    private float ActiveTime;
    [Header("高难请勾选is_ThirdPass")]
    public bool is_ThirdPass = false;
    public GameObject coloured;
    public GameObject colourless;

    // 当在Inspector面板中修改变量时，Unity会调用此方法
    private void OnValidate()
    {
        //int FirstP = is_FirstPass ? 1 : 0;

        if (is_FirstPass && is_ThirdPass)
        {
            is_FirstPass = false;
            is_ThirdPass = false;
        }

    }
    private void Start()
    {
        CountUI_P = Instantiate(CountUI_Prefab, this.gameObject.transform);
        if (CountUI_P != null)
        {
            CountUI_P.GetComponent<Canvas>().worldCamera = Camera.main;
            CountUI_P.SetActive(false);
            CountUI = CountUI_P.GetComponentInChildren<TMP_Text>();
        }
    }
    private void Update()
    {
        //Debug.Log("？");
        if (is_FirstPass || is_ThirdPass)
        {
            if (CountUI_P!=null)
            {
                CountUI_P.SetActive(false);
            }
        }
        else
        {
            CountUI_P.SetActive(true);
        }
        HPLookAtCamera();
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

    //随机数量、关闭颜色显示
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
    public void Set_FirstPassBasket()   //新手教学的果篮设置
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
    public void Set_ThirdPassBasket()   //高难的果篮设置
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

    //放满逻辑扣血
    public void LoseBlood()
    {
        if (is_ThirdPass && totality > rangeTotality)
        {
           GameManagement.Instance.InjuredHP();
        }
        UI_QuantityDisplay();
    }
    private void HPLookAtCamera()
    {
        if (CountUI_P!=null)
        {
            CountUI_P.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }
    }
    public void UI_QuantityDisplay()
    {
        if (CountUI == null) return;
        CountUI.text = string.Format("{0}/{1}", totality, maxValue);
        //CountUI.text = $"{totality}/{maxValue}"; ;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰到东西了");
        if (other.gameObject.GetComponent<FruitData>() == null)
        {
            return;
        }
        #region 抽象的判断，没法看，看不了一点
        switch (color)
        {
            case ReceivingColor.Red:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                    GameTimeControl.Instance.AddT(10f);
                    LoseBlood();
                }
                else if(other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    GameTimeControl.Instance.AddT(-10f);
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Orange:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                    GameTimeControl.Instance.AddT(10f);
                    LoseBlood();
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    GameTimeControl.Instance.AddT(-10f);
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Yellow:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                    GameTimeControl.Instance.AddT(10f);
                    LoseBlood();
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    GameTimeControl.Instance.AddT(-10f);
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Green:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                    GameTimeControl.Instance.AddT(10f);
                    LoseBlood();
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    GameTimeControl.Instance.AddT(-10f);
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Blue:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                    GameTimeControl.Instance.AddT(10f);
                    LoseBlood();
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    GameTimeControl.Instance.AddT(-10f);
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Purple:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                    GameTimeControl.Instance.AddT(10f);
                    LoseBlood();
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red)
                {
                    GameTimeControl.Instance.AddT(-10f);
                    Destroy(other.gameObject);
                }
                break;
            case ReceivingColor.Black:
                if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Black)
                {
                    Destroy(other.gameObject);
                    totality += 1;
                    GameTimeControl.Instance.AddT(10f);
                    LoseBlood();
                }
                else if (other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Red
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Orange
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Yellow
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Green
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Blue
                                    || other.gameObject.GetComponent<FruitData>().fruitDataClass.colorType == FruitColorType.Purple)
                {
                    GameTimeControl.Instance.AddT(-10f);
                    Destroy(other.gameObject);
                }
                break;
        }
        #endregion
    }
}
