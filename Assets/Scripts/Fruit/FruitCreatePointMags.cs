using System.Collections.Generic;
using UnityEngine;

public class FruitCreatePointMags : MonoBehaviour
{
    public static FruitCreatePointMags Instance;

    public List<FruitData> fruitDatas = new List<FruitData>();

    public List<FruitData> secondLevelFruitDatas = new List<FruitData>();

    private Dictionary<FruitType, FruitData> fruitDic = new Dictionary<FruitType, FruitData>();

    public GameObject fruitObj;

    public Transform rightTrans;

    public Transform leftTrans;

    public int changeDirectionTime = 10;

    public bool _isActive;                  //新手引导

    public bool commonSecondStart;          //普通关卡第二阶段

    private bool isStartTimer = false;
    private float timer = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        FruitInit();        //字典初始化
    }
     
    private void OnEnable()
    {
        if (GameManagement.Instance.difficultyLevel)
        {
            StartCreateFruit_D();
            UIManagement.Instance.OpenGamePlaneD();
        }

        if (GameManagement.Instance.commonLevel)
        {
            StartCreateFruit_C();
            UIManagement.Instance.OpenGamePlane();
        }
            
    }

    //两秒生成水果
    public void TwoSecondFruit()
    {
        if (isStartTimer)
        {
            GameObject GA = Instantiate(fruitObj, rightTrans);
            GA.GetComponent<Fruitattribute>().CreateFruit();
        }
        else
        {
            GameObject GA = Instantiate(fruitObj, leftTrans);
            GA.GetComponent<Fruitattribute>().CreateFruit();
        }
    }

    //切换方向生成
    public void StartLeftCreate()
    {
        isStartTimer = true;
    }

    private void Update()
    {
        if (isStartTimer)
        {
            timer += Time.deltaTime;
            if (timer >= changeDirectionTime)
            {
                isStartTimer = false;
                timer = 0;
            }
        }

    }

    //清空子集
    public void ClearFruit()
    {
        for (int i = 0; i < rightTrans.childCount; i++)
        {
            Destroy(rightTrans.GetChild(0).gameObject);
        }

        for (int i = 0; i < leftTrans.childCount; i++)
        {
            Destroy(leftTrans.GetChild(0).gameObject);
        }
    }

    private void OnDisable()
    {
        commonSecondStart = false;
        CancelInvoke();
        ClearFruit();
    }

    #region 关卡模式 ---- 普通

    //开始生成
    public void StartCreateFruit_C()
    {
        InvokeRepeating("CreateCommonFruit", 2f, 2f);
        InvokeRepeating("StartLeftCreate", 0f, 20f);
    }

    //普通关卡生成
    public void CreateCommonFruit()
    {
        if (!commonSecondStart)
        {
            //第一阶段
            CreateFirstCommonLevelFruit();
        }
        else 
        {
            //第二阶段
            CreateSecondCommonLevelFruit();
        }
    }


    //普通关卡生成水果 第一阶段
    public void CreateFirstCommonLevelFruit()
    {
        if (isStartTimer)
        {
            GameObject GA = Instantiate(fruitObj, rightTrans);
            GA.GetComponent<Fruitattribute>().CreateColorFriut();
        }
        else
        {
            GameObject GA = Instantiate(fruitObj, leftTrans);
            GA.GetComponent<Fruitattribute>().CreateColorFriut();
        }
    }

    //普通关卡生成水果  第二阶段
    public void CreateSecondCommonLevelFruit() 
    {
        if (isStartTimer)
        {
            GameObject GA = Instantiate(fruitObj, rightTrans);
            GA.GetComponent<Fruitattribute>().CertainFruit();
        }
        else
        {
            GameObject GA = Instantiate(fruitObj, leftTrans);
            GA.GetComponent<Fruitattribute>().CertainFruit();
        }
    }

    //private int fruitType;
    //public void RandomFruitType()
    //{
    //    fruitType = Random.Range(0, 7);
    //}

    //第二阶段 随机一种水果
    //public FruitType RandomSecondFruitType()
    //{
    //    switch (fruitType)
    //    {
    //        case 0:
    //            return FruitType.Apple;
    //        case 1:
    //            return FruitType.Orange;
    //        case 2:
    //            return FruitType.Banana;
    //        case 3:
    //            return FruitType.GreenMango;
    //        case 4:
    //            return FruitType.Blueberry;
    //        case 5:
    //            return FruitType.Grape;
    //        case 6:
    //            return FruitType.Mangosteen;
    //    }

    //    return FruitType.None;
    //}

    #endregion

    #region 关卡模式 ---- 困难

    //开始生成
    public void StartCreateFruit_D()
    {
        InvokeRepeating("CreateDifficultyFruit", 2f, 2f);
        InvokeRepeating("StartLeftCreate", 0f, 20f);
    }


    //生成水果
    public void CreateDifficultyFruit()
    {
        if (isStartTimer)
        {
            GameObject GA = Instantiate(fruitObj, rightTrans);
            GA.GetComponent<Fruitattribute>().CreateFruit();
        }
        else
        {
            GameObject GA = Instantiate(fruitObj, leftTrans);
            GA.GetComponent<Fruitattribute>().CreateFruit();
        }
    }


    #endregion

    #region 字典(按水果类型查找数据)

    //字典初始化
    public void FruitInit()
    {
        for (int i = 0; i < fruitDatas.Count; i++)
        {
            fruitDic.Add(fruitDatas[i].fruitDataClass.fruitType, fruitDatas[i]);
        }
    }

    //根据类型寻找水果预制体
    public GameObject CertainFruit(FruitType _fruitType)
    {
        if (fruitDic.ContainsKey(_fruitType))
            return fruitDic[_fruitType].fruitDataClass.fruitPrefab;

        return null;
    }

    #endregion
}
