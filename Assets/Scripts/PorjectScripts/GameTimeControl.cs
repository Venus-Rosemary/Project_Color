using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimeControl : Singleton<GameTimeControl>
{
    public GameObject TimeUI=null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeUI.activeSelf)
        {
            KeepTime();
        }
    }

    public void Set_GameTimeStart()
    {
        if (GameManagement.Instance.commonLevel)
        {
            currentTime = 60;
        }
        else if (GameManagement.Instance.difficultyLevel)
        {

            currentTime = 120;
        }
    }

    public TMP_Text timerText; // 引用到你的Text UI组件
    public float currentTime = 60f; // 1分钟的计时
    //计时
    public void KeepTime()
    {
        // 每帧减少时间
        currentTime -= Time.deltaTime;

        // 更新UI文本显示当前剩余时间
        timerText.text = FormatTime(currentTime);
        // 当计时结束时的操作
        if (currentTime <= 0)
        {
            currentTime = 0;
            // 在这里可以添加计时结束后的逻辑
            timerText.text = "00:00";
        }
    }
    // 将时间格式化为mm:ss
    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{00:00}:{01:00}", minutes, seconds);
    }

    //加减时间交互
    public void AddT(float additionalTime)
    {
        currentTime += additionalTime;
    }
}
