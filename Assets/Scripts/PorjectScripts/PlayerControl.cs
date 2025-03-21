﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject GrabDecide;//抓取触发器
    private float deactivateTriggerTime;
    [SerializeField]
    private float GrabDecideTime=0.3f;//触发器显示时间
    public GameObject GrabPoint;//抓到的东西存放位置
    [SerializeField]
    private bool is_InHands=false;//手中是否有东西
    public GameObject InHands;//手里抓到的东西
    [SerializeField]
    private bool isProcessing=true;
    public bool canControl=true;
    public bool is_inFirst = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (canControl)
        {
            PlayerMove();
            if (Input.GetMouseButtonDown(0) && !is_InHands && isProcessing)
            {
                Set_GrabDecide();
            }
            if (Input.GetMouseButtonDown(0) && is_InHands)
            {
                Set_PutDown();
            }
        }

        if (GrabDecide.activeSelf==true&&Time.time> deactivateTriggerTime)
        {
            GrabDecide.SetActive(false);
            isProcessing = true;
        }
    }
    public void Set_PlayerNotCanControl()
    {
        canControl = false;
    }
    public void Set_PlayerCanControl()
    {
        canControl = true;
    }
    public void Set_GrabDecide()
    {
        GrabDecide.SetActive(true);
        isProcessing = false;
        deactivateTriggerTime = Time.time + GrabDecideTime;
    }

    public void Set_PutDown()
    {
        isProcessing = true;
        is_InHands = false;
        if (InHands.gameObject!=null)
        {
            InHands.transform.SetParent(null);
        }
        InHands.AddComponent<Rigidbody>();
    }

    public float speed = 5.0f; // 移动速度
    public float rotationSpeed = 10.0f; // 旋转速度
    public Rigidbody rb;
    private Vector3 movement;

    public float moveHorizontal;
    public float moveVertical;
    public void PlayerMove()
    {
        // 在每一帧获取输入，并计算移动的方向
         moveHorizontal = Input.GetAxisRaw("Horizontal");
         moveVertical = Input.GetAxisRaw("Vertical");
        bool hasInput = Mathf.Abs(Input.GetAxis("Horizontal")) > 0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0f;
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        transform.position += movement * Time.deltaTime * speed;
        if (movement!=Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, movement, Time.deltaTime * rotationSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GrabDecide.activeSelf)
        {
            return;
        }
        if (other.gameObject.GetComponent<FruitData>()==null)
        {
            return;
        }
        if (other.gameObject.GetComponent<Rigidbody>()!=null)
        {
            return;
        }
        if (is_InHands) return;
        is_InHands = true;
        if (!is_inFirst)
        {
            other.gameObject.SetActive(false);
        }
        Debug.Log("碰到:"+other.gameObject.name);
        InHands = Instantiate(other.gameObject, GrabPoint.transform);
        InHands.transform.localScale = new Vector3(1, 1, 1);
        //InHands.gameObject.transform.SetParent(GrabPoint.transform,false);
        InHands.SetActive(true);
        GrabDecide.SetActive(false);
    }
}
