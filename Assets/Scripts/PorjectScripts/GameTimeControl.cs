using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimeControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public TMP_Text timerText; // ���õ����Text UI���
    public float currentTime = 60f; // 3���ӵļ�ʱ
    //��ʱ
    public void KeepTime()
    {
        // ÿ֡����ʱ��
        currentTime -= Time.deltaTime;

        // ����UI�ı���ʾ��ǰʣ��ʱ��
        timerText.text = FormatTime(currentTime);
        // ����ʱ����ʱ�Ĳ���
        if (currentTime <= 0)
        {
            currentTime = 0;
            // �����������Ӽ�ʱ��������߼�
            timerText.text = "00:00";
        }
    }
    // ��ʱ���ʽ��Ϊmm:ss
    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{00:00}:{01:00}", minutes, seconds);
    }

    //�Ӽ�ʱ�佻��
    public void AddT(float additionalTime)
    {
        currentTime += additionalTime;
    }
}
