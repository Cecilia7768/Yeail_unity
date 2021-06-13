using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform target;//ī�޶� �������
    public float moveDamping = 15f;//�̵��ӵ� ���
    public float rotateDamping = 500f;//ȸ���ӵ� ���

    public float distance = 10f; //���������� �Ÿ�
    public float height = 3f; //���������� ����
    public float tagetOffset = 2f;//������ǥ�� ������
    //�ٴڸ��� �������� ����

    Transform tr;
    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        var campos = target.position - (target.forward * distance) + (target.up * height);
        tr.position = Vector3.Slerp(tr.position, campos, Time.deltaTime * moveDamping);
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * rotateDamping);
        tr.LookAt(target.position + (target.up * tagetOffset));
        //�����¸�ŭ �������� ����
    }
}
