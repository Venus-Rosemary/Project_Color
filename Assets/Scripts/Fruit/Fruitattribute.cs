using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruitattribute : MonoBehaviour
{
    //水果预制体
    public GameObject fruitObj;

    public GameObject vanishVFX;

    public Transform fruitTrans;

    private FruitData fruitDataObj;

    public float moveSpeed = 5;

    public Rigidbody rb;

    //生成正常水果
    public void CreateFruit()
    {
        fruitDataObj = Instantiate(RandomFruit(), fruitTrans).GetComponent<FruitData>();
        fruitDataObj.FruitInit(fruitDataObj.fruitDataClass);
        fruitObj = fruitDataObj.gameObject;
    }

    //生成不同颜色的水果
    public void CreateColorFriut()
    {
        fruitDataObj = Instantiate(RandomFruit(), fruitTrans).GetComponent<FruitData>();
        fruitDataObj.FruitInit(fruitDataObj.fruitDataClass);
        fruitObj = fruitDataObj.gameObject;
    }

    //生成某一类水果
    public void CertainFruit()
    {
        fruitDataObj = Instantiate(RandomSecondLevelFruit(), fruitTrans).GetComponent<FruitData>();
        fruitDataObj.FruitInit(fruitDataObj.fruitDataClass);
        fruitObj = fruitDataObj.gameObject;
    }

    //随机水果
    public GameObject RandomFruit()
    {
        int _randomFruit = Random.Range(0,FruitCreatePointMags.Instance.fruitDatas.Count);
        return FruitCreatePointMags.Instance.fruitDatas[_randomFruit].fruitDataClass.fruitPrefab;
    }

    //随机普通关卡 第二阶段水果
    public GameObject RandomSecondLevelFruit()
    {
        int _randomFruit = Random.Range(0,FruitCreatePointMags.Instance.secondLevelFruitDatas.Count);
        return FruitCreatePointMags.Instance.secondLevelFruitDatas[_randomFruit].fruitDataClass.fruitPrefab;
    }

    //播放变小动画
    public void PlayAnim()
    {
        vanishVFX.SetActive(true);
        Invoke("DestroyFruit",1f);
    }

    //对象池回收
    public void DestroyFruit()
    { 
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "EndPos") return;

        if (other.gameObject.tag == "EndPos")
        {
            PlayAnim();//播放变小动画
        }
    }

    //移动
    public void FruitMove()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

}
