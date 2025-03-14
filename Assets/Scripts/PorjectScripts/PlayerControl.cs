using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject GrabDecide;//ץȡ������
    private float deactivateTriggerTime;
    [SerializeField]
    private float GrabDecideTime=0.3f;//��������ʾʱ��
    public GameObject GrabPoint;//ץ���Ķ������λ��
    private bool is_InHands=false;//�����Ƿ��ж���
    public GameObject InHands;//����ץ���Ķ���

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
            if (Input.GetMouseButtonDown(0) && !is_InHands)
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
            //isProcessing = false;
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
        deactivateTriggerTime = Time.time + GrabDecideTime;
    }

    public void Set_PutDown()
    {
        is_InHands = false;
        InHands.transform.SetParent(null);
        InHands.AddComponent<Rigidbody>();
    }

    public float speed = 5.0f; // �ƶ��ٶ�
    public float rotationSpeed = 10.0f; // ��ת�ٶ�
    public Rigidbody rb;
    private Vector3 movement;

    public float moveHorizontal;
    public float moveVertical;
    public void PlayerMove()
    {
        // ��ÿһ֡��ȡ���룬�������ƶ��ķ���
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
        if (other.gameObject.GetComponent<FruitData>()==null)
        {
            return;
        }
        if (other.gameObject.GetComponent<Rigidbody>()!=null)
        {
            return;
        }
        //if (other.gameObject.name != "Red" && other.gameObject.name != "Green" && other.gameObject.name != "Blue"
        //    && other.gameObject.name != "Yellow" && other.gameObject.name != "Orange" && other.gameObject.name != "Pink" && other.gameObject.name != "Purple")
        //    return;
        if (is_InHands) return;
        is_InHands = true;
        if (!is_inFirst)
        {
            other.gameObject.SetActive(false);
        }
        InHands = Instantiate(other.gameObject, GrabPoint.transform);
        //InHands.gameObject.transform.SetParent(GrabPoint.transform,false);
        InHands.SetActive(true);
        GrabDecide.SetActive(false);
    }
}
