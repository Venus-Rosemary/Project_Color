using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruitattribute : MonoBehaviour
{
    //水果预制体
    public GameObject fruitObj;

    private FruitData fruitDataObj;

    public float moveSpeed = 5;

    public Rigidbody rb;

    //生成正常水果
    public void CreateFruit()
    {
        fruitDataObj = Instantiate(RandomFruit(),transform).GetComponent<FruitData>();
        fruitDataObj.FruitInit(fruitDataObj.fruitDataClass);
        fruitObj = fruitDataObj.gameObject;
    }

    //生成不同颜色的水果
    public void CreateColorFriut()
    {
        fruitDataObj = Instantiate(RandomFruit(), transform).GetComponent<FruitData>();
        fruitDataObj.FruitInit(fruitDataObj.fruitDataClass);
        fruitObj = fruitDataObj.gameObject;
    }

    //生成某一类水果
    public void CertainFruit(FruitType _fruitType)
    {
        fruitDataObj = Instantiate(FruitCreatePointMags.Instance.CertainFruit(_fruitType), transform).GetComponent<FruitData>();
        fruitDataObj.FruitInit(fruitDataObj.fruitDataClass, true);
        fruitObj = fruitDataObj.gameObject;
    }

    //随机水果
    public GameObject RandomFruit()
    {
        int _randomFruit = Random.Range(0,FruitCreatePointMags.Instance.fruitDatas.Count);
        return FruitCreatePointMags.Instance.fruitDatas[_randomFruit].fruitDataClass.fruitPrefab;
    }

    //播放变小动画
    public void PlayAnim()
    {

        Invoke("DestroyFruit",1f);
    }

    //对象池回收
    public void DestroyFruit()
    { 
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
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

    //水果交互

    //水果的移动方法

    //水果的生成时间间隔方法


}
