using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //�ش� 
public class MoveAgent : MonoBehaviour
{
    public List<Transform> wayPoints;
    //list�� �迭��
    //������ - �������̷μ� ���빰�� ���� ���̰� ����

    public int nextIdx; //���� ���������� �迭 �ε���

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        //�극��ũ�� ���� �ڵ� ���������ʵ��� ����
        //�������� ����������� �ӵ��� ���̴� �ɼ�

        var group = GameObject.Find("WayPointGroup");
        //���̾��Ű���� "������Ʈ�̸�"���� �� ������Ʈ�� �˻�
        if(group != null) //������Ʈ ������ ������ ��� != null
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            //WayPointGroup ������ �ִ� ��� Transform ������Ʈ ������ͼ�
            //wayPoints ������ �־���
            wayPoints.RemoveAt(0); //����Ʈ����߿� ������ �ε����� ������Ʈ ����
        }

        //��������Ʈ �����ϴ� �Լ� ȣ��    
        MoveWayPoint();
    }

    void MoveWayPoint()
    {
        if (agent.isPathStale) //isPathStale ��� ������϶��� true ������ false
                               //�Ÿ�������϶��� ������� �������� �ʵ��� �ϱ� ����
        {
            return;
        }
        agent.destination = wayPoints[nextIdx].position;
        //������ point �߿��� �Ѱ����� �������� ����
        agent.isStopped = false;
        //�׺���̼� ��� Ȱ��ȭ�ؼ� �̵� �����ϵ��� ����
    }
    private void Update()
    {
     if(agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        //�������� �����ߴ��� �Ǵ��ϱ� ���� ����
        //�ӵ��� 0.2���� ũ�� ���� �̵��Ÿ��� 0.5������ ���
        //�׳� Magnitude���� sqrMagnitude�� ������ �� ����(����� �Ȱ�)
        {
            //�������� ���� ����������
            nextIdx++;
            //0 1 2 3 4.. watPoints�� 0�̶�� ����
            //0%10 = 0 ,1%10=10...�ؼ� ��ȯ������ �̷������ �������� ��������
            //ó������ ������ ������ ������ �ٽ� ó������ ���ư��� �ε��� ����
            nextIdx = nextIdx % wayPoints.Count;
            //�ε��� ���� �� �̵������ϱ����� �Լ� ȣ��
            MoveWayPoint();
        }
    }
}
