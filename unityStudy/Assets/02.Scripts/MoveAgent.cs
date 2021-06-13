using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //해당 
public class MoveAgent : MonoBehaviour
{
    public List<Transform> wayPoints;
    //list도 배열임
    //차이점 - 가변길이로서 내용물에 따라 길이가 변함

    public int nextIdx; //다음 순찰지점의 배열 인덱스

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        //브레이크를 꺼서 자동 감속하지않도록 해줌
        //목적지에 가까워질수록 속도를 줄이는 옵션

        var group = GameObject.Find("WayPointGroup");
        //하이어라키에서 "오브젝트이름"으로 된 오브젝트를 검색
        if(group != null) //오브젝트 정보가 존재할 경우 != null
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            //WayPointGroup 하위에 있는 모든 Transform 컴포넌트 가지고와서
            //wayPoints 변수에 넣어줌
            wayPoints.RemoveAt(0); //리스트요소중에 지정된 인덱스의 오브젝트 삭제
        }

        //웨이포인트 변경하는 함수 호출    
        MoveWayPoint();
    }

    void MoveWayPoint()
    {
        if (agent.isPathStale) //isPathStale 경로 계산중일때는 true 끝나면 false
                               //거리계산중일때는 순찰경로 변경하지 않도록 하기 위함
        {
            return;
        }
        agent.destination = wayPoints[nextIdx].position;
        //만들어둔 point 중에서 한곳으로 목적지를 설정
        agent.isStopped = false;
        //네비게이션 기능 활성화해서 이동 시작하도록 변경
    }
    private void Update()
    {
     if(agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        //목적지에 도착했는지 판단하기 위한 조건
        //속도가 0.2보다 크고 남은 이동거리가 0.5이하일 경우
        //그냥 Magnitude보다 sqrMagnitude가 성능이 더 좋다(기능은 똑같)
        {
            //목적지에 거의 도착했을때
            nextIdx++;
            //0 1 2 3 4.. watPoints를 0이라고 가정
            //0%10 = 0 ,1%10=10...해서 순환구조를 이루기위해 나머지값 연산을함
            //처름부터 마지막 순찰지 돌고나면 다시 처음으로 돌아가게 인덱스 변경
            nextIdx = nextIdx % wayPoints.Count;
            //인덱스 변경 후 이동시작하기위해 함수 호출
            MoveWayPoint();
        }
    }
}
