using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; //ī�޶� ������ ���
    public float moveDamping = 15f; //�̵��ӵ� ���
    public float rotateDamping = 5f; //ȸ���ӵ� ���
    //�����Լ�
    //�ε巴�� �����̱� ����
    public float distance = 5f; //���� ������ �Ÿ�
    public float height = 4f; // ���� ������ ����
    public float targerOffset = 2f; //���� ��ǥ�� ������
    //ĳ������ �ٴ��� �ƴ� �������κ��� �ٶ󺸰�

    Transform tr; //�����̰��� �Ҷ�

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    //�ݹ��Լ� - ȣ���� �������� �ʾƵ� �˾Ƽ� �۵��ϴ� �Լ�
    //�̺�Ʈ Ʈ���� �� �������� ������ ����.
    private void LateUpdate() //ī�޶� �۵��Ҷ� �ַ� ���
    {
        var camPos = target.position - (target.forward * distance) + (target.up * height);
        tr.position = Vector3.Slerp(tr.position, camPos, Time.deltaTime * moveDamping);
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * rotateDamping);
        tr.LookAt(target.position + (target.up * targerOffset)); //�߹ٴں��»��� + �����¸�ŭ(��������)
    }
}

//���Ž� , ��ī�� �ִϸ��̼�
