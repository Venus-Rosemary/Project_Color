using System.Collections.Generic;
using UnityEngine;

public class FruitCreatePointMags : MonoBehaviour
{
    public static FruitCreatePointMags Instance;

    public List<FruitData> fruitDatas = new List<FruitData>();

    public GameObject fruitObj;

    public Transform rightTrans;

    public Transform leftTrans;

    public int changeDirectionTime = 10;

    private bool isStartTimer = false;
    private float timer = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
     
    private void Start()
    {
        //TwoSecondFruit();
        InvokeRepeating("TwoSecondFruit", 2f,2f);
        InvokeRepeating("StartLeftCreate",0f,20f);
    }

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

    public void StartLeftCreate()
    {
        isStartTimer = true;
        Debug.Log("开始计时");
    }
}
