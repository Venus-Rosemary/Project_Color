using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelManagement : MonoBehaviour
{

    public List<SetWaveNumber> SetWN;
    public Blackboard FirstB;
    public GameObject PlayerPos;
    private Vector3 StartPos;
    void Start()
    {
        StartPos = gameObject.transform.position;
    }

    void Update()
    {
        
    }
    public void Set_PlayStartPos()
    {
        PlayerPos.transform.position = StartPos;
    }
    public int FiresIndex=0;
    public void Set_ActiveBool()
    {
        #region …Ë÷√∫⁄∞Â÷µ
        switch (FiresIndex)
        {
            case 0:
                FirstB.SetVariableValue("Red", true);
                FirstB.SetVariableValue("Orange", false);
                FirstB.SetVariableValue("Yellow", false);
                FirstB.SetVariableValue("Green", false);
                FirstB.SetVariableValue("Blue", false);
                FirstB.SetVariableValue("Purple", false);
                FirstB.SetVariableValue("Black", false);
                FiresIndex += 1;
                break;
            case 1:
                FirstB.SetVariableValue("Red", false);
                FirstB.SetVariableValue("Orange", true);
                FirstB.SetVariableValue("Yellow", false);
                FirstB.SetVariableValue("Green", false);
                FirstB.SetVariableValue("Blue", false);
                FirstB.SetVariableValue("Purple", false);
                FirstB.SetVariableValue("Black", false);
                FiresIndex += 1;
                break;
            case 2:
                FirstB.SetVariableValue("Red", false);
                FirstB.SetVariableValue("Orange", false);
                FirstB.SetVariableValue("Yellow", true);
                FirstB.SetVariableValue("Green", false);
                FirstB.SetVariableValue("Blue", false);
                FirstB.SetVariableValue("Purple", false);
                FirstB.SetVariableValue("Black", false);
                FiresIndex += 1;
                break;
            case 3:
                FirstB.SetVariableValue("Red", false);
                FirstB.SetVariableValue("Orange", false);
                FirstB.SetVariableValue("Yellow", false);
                FirstB.SetVariableValue("Green", true);
                FirstB.SetVariableValue("Blue", false);
                FirstB.SetVariableValue("Purple", false);
                FirstB.SetVariableValue("Black", false);
                FiresIndex += 1;
                break;
            case 4:
                FirstB.SetVariableValue("Red", false);
                FirstB.SetVariableValue("Orange", false);
                FirstB.SetVariableValue("Yellow", false);
                FirstB.SetVariableValue("Green", false);
                FirstB.SetVariableValue("Blue", true);
                FirstB.SetVariableValue("Purple", false);
                FirstB.SetVariableValue("Black", false);
                FiresIndex += 1;
                break;
            case 5:
                FirstB.SetVariableValue("Red", false);
                FirstB.SetVariableValue("Orange", false);
                FirstB.SetVariableValue("Yellow", false);
                FirstB.SetVariableValue("Green", false);
                FirstB.SetVariableValue("Blue", false);
                FirstB.SetVariableValue("Purple", true);
                FirstB.SetVariableValue("Black", false);
                FiresIndex += 1;
                break;
            case 6:
                FirstB.SetVariableValue("Red", false);
                FirstB.SetVariableValue("Orange", false);
                FirstB.SetVariableValue("Yellow", false);
                FirstB.SetVariableValue("Green", false);
                FirstB.SetVariableValue("Blue", false);
                FirstB.SetVariableValue("Purple", false);
                FirstB.SetVariableValue("Black", true);
                FiresIndex += 1;
                break;
            case 7:
                FirstB.SetVariableValue("Red", false);
                FirstB.SetVariableValue("Orange", false);
                FirstB.SetVariableValue("Yellow", false);
                FirstB.SetVariableValue("Green", false);
                FirstB.SetVariableValue("Blue", false);
                FirstB.SetVariableValue("Purple", false);
                FirstB.SetVariableValue("Black", false);
                FiresIndex = 0;
                break;
        }
        #endregion
    }
    public void Set_ActiveIndex(int index)
    {
        for (int i = 0; i < SetWN.Count; i++)
        {
            if (i==index)
            {
                SetWN[i].Fruit.SetActive(true);
                SetWN[i].FruitBasket.SetActive(true);
            }
            else
            {
                SetWN[i].Fruit.SetActive(false);
                SetWN[i].FruitBasket.SetActive(false);
            }
        }
    }
}

[System.Serializable]
public class SetWaveNumber
{
    public GameObject Fruit;
    public GameObject FruitBasket;
}
