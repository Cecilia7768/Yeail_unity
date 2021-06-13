using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        PATROL,//순찰
        TRACE,//추적
        ATTACK,//공격
        DIE//사망
    }

    public State state = State.PATROL; //초기상태 지정

    Transform playerTr; //플레이어 위치 저장 변수 //추적해야할 플레이어 위치
    Transform enemyTr; //적캐릭터 위치 저장 변수

    public float attackDist = 5f;
    public float traceDist = 10f;
    public bool isDie = false;

    WaitForSeconds ws; //시간 지연 변수
    private void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("PLAYER");
        if (player != null)
        {
            playerTr = player.GetComponent<Transform>();
            //타인이라 땡겨오는거고
        }
        enemyTr = GetComponent<Transform>();
        //나 자신이니까 가져온다공?
        ws = new WaitForSeconds(0.3f);
        //시간지연변수를 0.3 값으로 설정
    }
    private void OnEnable()
    {
        //OnEnable은 해당 스크립트가 활성화 될때마다 실행됨
        //상태 체크하는 코루틴 함수 호출

        StartCoroutine(CheckState());
    }

    IEnumerator CheckState() //상태체크 코루틴 함수
    {
        while(!isDie) //적이 살아있는 동안 계속 실행되도록 while 사용
        {
            if (state == State.DIE) //뒤졋으면
                yield break;            
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            //살아잇으면 적과 플레이어간의 거리를 계산한다 (A위치 - B위치)
            if (dist <= attackDist) //사정거리 안쪽이면
            {
                state = State.ATTACK; //공격 ㄱㄱ
            }
            else if( dist <= traceDist )//추적 사거리 이내면 추적 ㄱㄱ
            {
                state = State.TRACE;
            }
            else //둘다 아니면 걍 순찰 ㄱㄱ
            {
                state = State.PATROL; 
            }
            yield return ws; //위에서 설정한 0.3초 대기
        }
    }
}
