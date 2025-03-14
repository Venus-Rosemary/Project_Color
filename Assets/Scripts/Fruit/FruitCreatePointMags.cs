using System.Collections.Generic;
using UnityEngine;

public class FruitCreatePointMags : MonoBehaviour
{
    public static FruitCreatePointMags Instance;

    public List<FruitData> fruitDatas = new List<FruitData>();

    private Dictionary<FruitType, FruitData> fruitDic = new Dictionary<FruitType, FruitData>();

    public GameObject fruitObj;

    public Transform rightTrans;

    public Transform leftTrans;

    public int changeDirectionTime = 10;

    public bool _isActive;                //��������
    //public bool commonLevel;                //��ͨ�ؿ�
    //public bool difficultyLevel;            //���ѹؿ�

    public bool commonSecondStart;         //��ͨ�ؿ��ڶ��׶�
    private bool isStartTimer = false;
    private float timer = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        FruitInit();        //�ֵ��ʼ��
    }
     
    private void Start()
    {
        //RandomFruitType();

        //if (GameManagement.Instance.difficultyLevel)
        //    StartCreateFruit_D();

        //if (GameManagement.Instance.commonLevel)
        //    StartCreateFruit_C();

    }

    private void OnEnable()
    {
        RandomFruitType();

        if (GameManagement.Instance.difficultyLevel)
            StartCreateFruit_D();

        if (GameManagement.Instance.commonLevel)
            StartCreateFruit_C();
    }

    //��������ˮ��
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

    //�л���������
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

    //����Ӽ�
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

    #region �ؿ�ģʽ ---- ��ͨ

    //��ʼ����
    public void StartCreateFruit_C()
    {
        InvokeRepeating("CreateCommonFruit", 2f, 2f);
        InvokeRepeating("StartLeftCreate", 0f, 20f);
    }

    //��ͨ�ؿ�����
    public void CreateCommonFruit()
    {
        if (!commonSecondStart)
        {
            //��һ�׶�
            CreateFirstCommonLevelFruit();
        }
        else 
        {
            //�ڶ��׶�
            CreateSecondCommonLevelFruit();
        }
    }


    //��ͨ�ؿ�����ˮ�� ��һ�׶�
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

    //��ͨ�ؿ�����ˮ��  �ڶ��׶�
    public void CreateSecondCommonLevelFruit() 
    {
        if (isStartTimer)
        {
            GameObject GA = Instantiate(fruitObj, rightTrans);
            GA.GetComponent<Fruitattribute>().CertainFruit(RandomSecondFruitType());
        }
        else
        {
            GameObject GA = Instantiate(fruitObj, leftTrans);
            GA.GetComponent<Fruitattribute>().CertainFruit(RandomSecondFruitType());
        }
    }

    private int fruitType;
    public void RandomFruitType()
    {
        fruitType = Random.Range(0, 7);
    }

    //�ڶ��׶� ���һ��ˮ��
    public FruitType RandomSecondFruitType()
    {
        switch (fruitType)
        {
            case 0:
                return FruitType.Apple;
            case 1:
                return FruitType.Orange;
            case 2:
                return FruitType.Banana;
            case 3:
                return FruitType.GreenMango;
            case 4:
                return FruitType.Blueberry;
            case 5:
                return FruitType.Grape;
            case 6:
                return FruitType.Mangosteen;
        }

        return FruitType.None;
    }

    #endregion

    #region �ؿ�ģʽ ---- ����

    //��ʼ����
    public void StartCreateFruit_D()
    {
        InvokeRepeating("CreateDifficultyFruit", 2f, 2f);
        InvokeRepeating("StartLeftCreate", 0f, 20f);
    }


    //����ˮ��
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

    #region �ֵ�(��ˮ�����Ͳ�������)

    //�ֵ��ʼ��
    public void FruitInit()
    {
        for (int i = 0; i < fruitDatas.Count; i++)
        {
            fruitDic.Add(fruitDatas[i].fruitDataClass.fruitType, fruitDatas[i]);
        }
    }

    //��������Ѱ��ˮ��Ԥ����
    public GameObject CertainFruit(FruitType _fruitType)
    {
        if (fruitDic.ContainsKey(_fruitType))
            return fruitDic[_fruitType].fruitDataClass.fruitPrefab;

        return null;
    }

    #endregion
}
