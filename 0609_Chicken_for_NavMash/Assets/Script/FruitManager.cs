using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public static GameObject banana;
    public static GameObject cheese;
    public static GameObject olive;
    public static GameObject hamburger;
    public GameObject Banana;
    public GameObject Cheese;
    public GameObject Olive;
    public GameObject Hamburger;

    private static float dropSpeed = -0.1f;
    public static List<GameObject> Fruit_List = new List<GameObject>();

    float span = 1.0f;
    float delta = 0f;
    int ratio = 2;
    float speed = -0.03f;

    private void Start()
    {
        banana = Banana;
        cheese = Cheese;
        olive = Olive;
        hamburger = Hamburger;

        this.transform.Translate(0, dropSpeed, 0);

        StartCoroutine(Co_Create_Fruits());
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Box"))
    //    {
    //        other.gameObject.SetActive(false);
    //        Destroy(other.gameObject);
    //    }
    //    //if(other.gameObject.CompareTag("Floor")) //���ڲ� ��Ű��??
    //    //{
    //    //    other.gameObject.SetActive(false);
    //    //    Destroy(other.gameObject);
    //    //}
    //}
    //private void Update()
    //{
    //    //Destroy_Fruits(); //�ڷ�ƾ�̶� ��Ŵ
    //}
    public void SetParameter(float span,float speed,int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }      
    IEnumerator Co_Create_Fruits()
    {
        while(true)
        {
            if (Fruit_List.Count < 5)            
                Set_XY(Making_Fruit());            
            
            yield return new WaitForSeconds(5f);
        }      
    }  
    //////////////////////////////////////////////////////////////////////////
    /////������Ʈ Ǯ�� ..... ������Ʈ ��Ȱ��ȭ �ȵ� (����Ȯ���ϱ�...��.��)///
   
    private void Update()
    {
        //if (transform.position.y < -1.0f)
        //    gameObject.SetActive(false);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Floor"))
    //        other.gameObject.SetActive(false); //�ڽ��� �ٴڿ� �ε����� �����

    //    Re_Using_Fruit(); //      ��������� �ٽ� ����

    //}
    public static void Re_Using_Fruit() //������ ����������� ������ ����Ʈ���� �ٽ� ������
    {
        GameObject F_obj = null;
        for(int i =0;i<Fruit_List.Count;i++)
        {
            if(!Fruit_List[i].activeSelf) //��Ȱ��ȭ�� ������ ������
            {
                F_obj = Fruit_List[i];
                Set_XY(F_obj);
                F_obj.SetActive(true);
                F_obj.transform.Translate(0, dropSpeed, 0);
            }
        }
    }

    ////////////////////////////////////////////////////////////////

    static GameObject Making_Fruit() //���� ���� �̴� �Լ�
    {
        GameObject item;
        GameObject tmp_Fruit;
        int what_Fruit = Random.Range(0, 4);
        if (what_Fruit == 0)
            tmp_Fruit = banana;
        else if (what_Fruit == 1)
            tmp_Fruit = cheese;
        else if (what_Fruit == 2)
            tmp_Fruit = hamburger;
        else
            tmp_Fruit = olive;

        item = Instantiate(tmp_Fruit) as GameObject;

        return item;
    }  
    private static void Set_XY(GameObject obj) //���� ������ ������ǥ�̱�
    {
        
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);
        obj.transform.position = new Vector3(x, 15, z);
        // item.GetComponent<FruitCtrl>().dropSpeed = this.speed; 
        Fruit_List.Add(obj);
        obj.SetActive(true);
    }
}
