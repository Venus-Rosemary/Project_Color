using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 用于存储所有对象池的字典，其中键是对象名称，值是对应的池数据
    private Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

    // 缓存池的根对象，用于在层级视图中统一管理
    private GameObject poolObj;

    /// <summary>
    /// 获取对象的方法，从缓存池中取出对象。
    /// 如果池子中没有对象，则动态创建新的对象。
    /// </summary>
    /// <param name="name">对象的名称</param>
    public GameObject GetObj(string name)
    {
        GameObject obj = null;

        // 如果池子中有该类对象的抽屉，并且抽屉中有对象
        if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
        {
            // 从抽屉中取出对象
            obj = poolDic[name].GetObj();
        }
        else
        {
            // 动态创建一个新的对象
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));

            // 将对象的名称设置为与池子名称一致
            obj.name = name;
        }

        return obj; // 返回获取的对象
    }

    /// <summary>
    /// 回收对象的方法，将不使用的对象放入缓存池中。
    /// </summary>
    /// <param name="name">对象的名称</param>
    /// <param name="obj">需要回收的对象</param>
    public void PushObj(string name, GameObject obj)
    {
        // 如果缓存池根对象尚未创建，则创建一个新对象作为根对象
        if (poolObj == null)
            poolObj = new GameObject("Pool");

        // 如果池子中已经有该类对象的抽屉
        if (poolDic.ContainsKey(name))
        {
            // 将对象存入抽屉中
            poolDic[name].PushObj(obj);
        }
        else
        {
            // 如果没有该类对象的抽屉，则创建一个新的抽屉并存入对象
            poolDic.Add(name, new PoolData(obj, poolObj));
        }
    }

    /// <summary>
    /// 清空缓存池的方法，通常在场景切换时使用。
    /// </summary>
    public void Clear()
    {
        // 清空所有对象池数据
        poolDic.Clear();

        // 销毁缓存池的根对象
        poolObj = null;
    }
}


/// <summary>
/// 抽屉数据类，表示缓存池中的一列容器，用于管理某一类对象。
/// </summary>
public class PoolData
{
    // 对象挂载的父对象，用于统一管理该类对象
    public GameObject fatherObj;

    // 存储对象的列表，表示当前抽屉中的所有对象
    public List<GameObject> poolList;

    /// <summary>
    /// 构造函数，初始化一个新的抽屉数据，并将第一个对象存入池子。
    /// </summary>
    /// <param name="obj">需要加入池子的对象</param>
    /// <param name="poolObj">缓存池的根对象，用于挂载抽屉</param>
    public PoolData(GameObject obj, GameObject poolObj)
    {
        // 创建一个新的父对象，将其作为该类对象的容器
        fatherObj = new GameObject(obj.name);

        // 将父对象挂载到缓存池的根对象上
        fatherObj.transform.parent = poolObj.transform;

        // 初始化对象列表
        poolList = new List<GameObject>();

        // 将第一个对象存入池子
        PushObj(obj);
    }

    /// <summary>
    /// 将对象存入池子（抽屉中）
    /// </summary>
    /// <param name="obj">需要存入的对象</param>
    public void PushObj(GameObject obj)
    {
        // 隐藏对象，将其失活
        obj.SetActive(false);

        // 将对象添加到列表中
        poolList.Add(obj);

        // 设置对象的父对象为该抽屉的父对象
        obj.transform.parent = fatherObj.transform;
    }

    /// <summary>
    /// 从池子（抽屉）中取出对象
    /// </summary>
    /// <returns>取出的对象</returns>
    public GameObject GetObj()
    {
        GameObject obj = null;
        
        // 取出列表中的第一个对象
        obj = poolList[0];

        // 从列表中移除取出的对象
        poolList.RemoveAt(0);

        // 激活对象，使其可见
        obj.SetActive(true);

        // 断开与父对象的关系
        obj.transform.parent = null;

        return obj;
    }
}
