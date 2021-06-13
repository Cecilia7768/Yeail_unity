using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{

    public GameObject sparkEffect; //����ũ ������
    private void OnCollisionEnter(Collision collision)
    {        
        //�ݹ��Լ�.
        //�浹�� �߻��� �͵� �߿��� �ҷ� �±׸� ����
        if (collision.collider.tag == "BULLET")
        {
            //����ũ ����Ʈ �Լ� ȣ��
            ShowEffect(collision);            

            //�浹�� �߻��� ������Ʈ ����
            Destroy(collision.gameObject); //��û���
            //Destroy(collision.gameObject,5f); //5�ʵڿ� ����
            //collision.gameObject.SetActive(false); �̹���� ���� üũ
        }
    }

    void ShowEffect(Collision coll)
    {
        ContactPoint contact = coll.contacts[0];
        //ContactPoint /contacts[0] �浹�� �߻��� ���� ������ [0] �κ��� ������
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward,contact.normal);
        //FromToRotation (ȸ����Ű���� �ϴ� ����, Ÿ�Ϻ���) : �ش� ���͸� ��������
        //vector.back���� �ᵵ�ȴ�(�Ƹ���?)
        //���� ���Ͷ�� �Ѵܴ�!


        Vector3 point = contact.point + (-contact.normal * 0.05f); 
        //�巳�� ���̾�� ��¦ ���� �Ѿ��ڱ��� ���̰�

        GameObject spark = Instantiate(sparkEffect,point, rot);
        //�浹�� ����Ʈ�� ȿ�������� �������ͷ� ����


        //�������� �� ����Ʈ�� �θ�� �巳���� ����
        spark.transform.SetParent(this.transform);
    }

}
