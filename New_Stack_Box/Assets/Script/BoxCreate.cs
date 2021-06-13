using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCreate : MonoBehaviour
{
    static float add_for_Height = 1f;

    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;

    GameObject tmp;
    TimerUI about_UI;

    //public Mesh[] meshes;
    //MeshFilter meshFilter;

//    Renderer Box_color;

    float speed = 1.0f;
    float add_speed = 0.1f;

    static List<GameObject> BoxList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(Coru_Box_Maker());
        //Box_color = gameObject.GetComponent<Renderer>();
        //meshFilter = GetComponent<MeshFilter>();
    }

    IEnumerator Coru_Box_Maker() //�ڽ� �����̸��̸� ���ӻ���
    {
        while(true)
        {
            if(BoxList.Count<15 && TimerUI.timelimit > 0f)//�ڽ��� ���� �̸��̶��
            {
                //�����Լ�
                Box_Creator();
            }
            yield return new WaitForSeconds(speed);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Box_Destroy(0);
            add_speed *= 2;
            speed -= add_speed;         
        }
        else  if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Box_Destroy(1);
            add_speed *= 2;
            speed -= add_speed;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Box_Destroy(2);
            add_speed *= 2;
            speed -= add_speed;     
        }            
    }
    void Box_Creator()
    {
        GameObject b_obj;
        GameObject tmp_obj;
        int i = Random.Range(0, 3);
        if (i == 0)
            tmp_obj = Box1;
        else if (i == 1)
            tmp_obj = Box2;
        else
            tmp_obj = Box3;

        b_obj = Instantiate(tmp_obj) as GameObject;
        b_obj.transform.position = new Vector3(tmp_obj.transform.position.x, (tmp_obj.transform.position.y) * add_for_Height,tmp_obj.transform.position.z);

        //Box_color.material.color = Color.red; �÷� �����̱�
        BoxList.Add(b_obj);

        b_obj.SetActive(true);
        add_for_Height += .5f;
        if (add_for_Height > 5) //�ʹ� �ϴûѼ� �����Ѽ� ���̿��� ��������
            add_for_Height = 2.5f; //���ߵ� ��������
    }

    void Box_Destroy(int choice_case)
    {   
        //�迭�� ã������ ������ Ŭ���� �̸��� ��ġ�ϴٸ� �װ� �����ؾ���
        //ex) 0���� ������ -> list�߿� Box (clone) �ΰ��߿� ù��°�ΰ��� ã�ƾ���
        for (int i = 0; i < BoxList.Count; i++) 
        {
            if (choice_case == 0)
            {
                if (BoxList[i].activeSelf && BoxList[i].name == "Tir_Box(Clone)") //������ ����Ʈ�� Ȱ��ȭ�Ǿ��ִٸ�
                {
                    BoxList[i].SetActive(false); //��Ȱ��ȭ ���ְ�
                    Destroy(BoxList[i]);
                    BoxList.RemoveAt(i);               
                    break; //����������
                }
            }
            else if (choice_case == 1)
            {
                if (BoxList[i].activeSelf && BoxList[i].name == "Box(Clone)") //������ ����Ʈ�� Ȱ��ȭ�Ǿ��ִٸ�
                {
                    BoxList[i].SetActive(false); //��Ȱ��ȭ ���ְ�
                    Destroy(BoxList[i]);
                    BoxList.RemoveAt(i);                 
                    break; //����������
                }
            }
            else
            {
                if (BoxList[i].activeSelf && BoxList[i].name == "Sec_Box(Clone)") //������ ����Ʈ�� Ȱ��ȭ�Ǿ��ִٸ�
                {
                    BoxList[i].SetActive(false); //��Ȱ��ȭ ���ְ�
                    Destroy(BoxList[i]);
                    BoxList.RemoveAt(i);                
                    break; //����������
                }
            } 
                 
        }
        TimerUI.score++;
    }

    //void Makeing_Color_Box() //�����޽�
    //{
    //    int idx = Random.Range(0, meshes.Length);
    //    meshFilter.sharedMesh = meshes[idx];
    //}

    //bool Game_Clear() //�������� ù��° ��ġ (�ٴ�)�� �ƹ��͵� ������ ���� Ŭ����
    //{
    //    if (transform.position == null) //�ٴڿ� �ƹ��͵� ������       
    //        return true;
    //    else
    //        return false;
    //}
}
