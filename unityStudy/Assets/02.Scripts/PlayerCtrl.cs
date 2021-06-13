using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//Ŭ������ ��� ������ �޸� ����ȭ �����(���� �˷����) �ν����Ϳ� ǥ�õ�
public class PlayerAnim //����Ŭ����
{
    //����ȭ    
    public AnimationClip idle;
    public AnimationClip runF;
    public AnimationClip runB;
    public AnimationClip runL;
    public AnimationClip runR;
}
public class PlayerCtrl : MonoBehaviour
{
    private float h = 0f;//private ���� ������
    private float v = 0f;
    private float r;

    Transform tr; //Ʈ������ ������Ʈ ���� ����

    public float moveSpeed = 10f;
    public float rotSpeed = 150f; //ȸ�����
                                  //Animator animator;

    public PlayerAnim playerAnim;
    public Animation anim;


void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.clip = playerAnim.idle; //Ȥ�� �𸣴� ù���۽� �÷����� Ŭ�� �˷���
        anim.Play();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        //print("H�� -" + h + " V�� -" + v);
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        moveDir = moveDir.normalized;

        //���� ����ȭ
        //�밢�� �̵��� �Ϲ����� �̵����� ũ�Ⱑ Ŀ�� ���� ������
        //�̸� �ذ��ϰ��� ������ ũ�⸦ �����ϳ� 1�� ����ȭ ��Ŵ

        tr.Translate(moveDir * moveSpeed * Time.deltaTime ,Space.Self);
        //�����ǰ��� �����Ҷ� Translate ���!
        //forward -> ���غ���!        
        //Space.Self : ������Ʈ �������� ������ �����(�۷ι��� ������ ����!)

        //print(Vector3.Magnitude(Vector3.forward + Vector3.right));
        //Magnitude : ������ ũ�⸦ ����
        //print(Vector3.Magnitude((Vector3.forward + Vector3.right).normalized));       
        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);

        //�ִϸ��̼� ���� ����
        if (v >= 0.1f) //����        
            anim.CrossFade(playerAnim.runF.name, 0.3f);
        //CrossFade(�ִϸ��̼� �̸�,��ȯ �ð�(���̵������̵�ƿ��ð�))
        //����ϰ����ϴ� �ִϸ��̼��� �̸����� ����
        else if (v < -0.1f) //����        
            anim.CrossFade(playerAnim.runB.name, 0.3f);
        else if (h >= 0.1f)//������
            anim.CrossFade(playerAnim.runR.name, 0.3f);
        else if (h < -0.1f)//����
            anim.CrossFade(playerAnim.runL.name, 0.3f);
        else //�ƹ� �Էµ� ������
            anim.CrossFade(playerAnim.idle.name, 0.3f);

    }
}
