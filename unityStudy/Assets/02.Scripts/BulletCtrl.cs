using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float damage = 20f; //�Ѿ� ���ݷ�
    public float speed = 1000f;//�Ѿ� �ӵ�
    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);   
    }
}
