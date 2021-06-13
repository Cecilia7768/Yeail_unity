using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        PATROL,//����
        TRACE,//����
        ATTACK,//����
        DIE//���
    }

    public State state = State.PATROL; //�ʱ���� ����

    Transform playerTr; //�÷��̾� ��ġ ���� ���� //�����ؾ��� �÷��̾� ��ġ
    Transform enemyTr; //��ĳ���� ��ġ ���� ����

    public float attackDist = 5f;
    public float traceDist = 10f;
    public bool isDie = false;

    WaitForSeconds ws; //�ð� ���� ����
    private void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("PLAYER");
        if (player != null)
        {
            playerTr = player.GetComponent<Transform>();
            //Ÿ���̶� ���ܿ��°Ű�
        }
        enemyTr = GetComponent<Transform>();
        //�� �ڽ��̴ϱ� �����´ٰ�?
        ws = new WaitForSeconds(0.3f);
        //�ð����������� 0.3 ������ ����
    }
    private void OnEnable()
    {
        //OnEnable�� �ش� ��ũ��Ʈ�� Ȱ��ȭ �ɶ����� �����
        //���� üũ�ϴ� �ڷ�ƾ �Լ� ȣ��

        StartCoroutine(CheckState());
    }

    IEnumerator CheckState() //����üũ �ڷ�ƾ �Լ�
    {
        while(!isDie) //���� ����ִ� ���� ��� ����ǵ��� while ���
        {
            if (state == State.DIE) //�ڠ�����
                yield break;            
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            //��������� ���� �÷��̾�� �Ÿ��� ����Ѵ� (A��ġ - B��ġ)
            if (dist <= attackDist) //�����Ÿ� �����̸�
            {
                state = State.ATTACK; //���� ����
            }
            else if( dist <= traceDist )//���� ��Ÿ� �̳��� ���� ����
            {
                state = State.TRACE;
            }
            else //�Ѵ� �ƴϸ� �� ���� ����
            {
                state = State.PATROL; 
            }
            yield return ws; //������ ������ 0.3�� ���
        }
    }
}
