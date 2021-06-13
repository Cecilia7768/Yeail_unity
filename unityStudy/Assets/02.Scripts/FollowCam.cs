using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target; //카메라가 추적할 대상
    public float moveDamping = 15f; //이동속도 계수
    public float rotateDamping = 5f; //회전속도 계수
    //러프함수
    //부드럽게 움직이기 위함
    public float distance = 5f; //추적 대상과의 거리
    public float height = 4f; // 추적 대상과의 높이
    public float targerOffset = 2f; //추적 좌표의 오프셋
    //캐릭터의 바닥이 아닌 정수리부분을 바라보게

    Transform tr; //움직이고자 할때

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    //콜백함수 - 호출을 따로하지 않아도 알아서 작동하는 함수
    //이벤트 트리거 등 여러가지 사용법이 있음.
    private void LateUpdate() //카메라 작동할때 주로 사용
    {
        var camPos = target.position - (target.forward * distance) + (target.up * height);
        tr.position = Vector3.Slerp(tr.position, camPos, Time.deltaTime * moveDamping);
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * rotateDamping);
        tr.LookAt(target.position + (target.up * targerOffset)); //발바닥보는상태 + 오프셋만큼(위쪽으로)
    }
}

//레거시 , 메카님 애니메이션
