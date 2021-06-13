using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect; //���� ����Ʈ ������ ����
    int hitCount = 0;//�Ѿ� ���� Ƚ��
    Rigidbody rb;
    
    public Mesh[] meshes; //����� ����ϴ� �޽� //ex �ִϸ��̼� Ŭ��
    MeshFilter meshFilter;//�޽��� �������� �޽����� //ex �ִϸ�����

    public Texture[] textures; //�����⸦ ����ϴ� �ؽ���
    MeshRenderer _renderer;  //�ؽ��ĸ� �������� �޽� ������

    public float expRadius = 10f; //���߹ݰ�

    AudioSource _audio;
    public AudioClip expSfx;
    private void Start()
    {        
        rb = GetComponent<Rigidbody>();
        meshFilter = GetComponent<MeshFilter>();
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material.mainTexture = textures[Random.Range(0,textures.Length)];
        _audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            hitCount++; //�Ѿ��̶� �浹�ϸ� �浹Ƚ�� ����
            if (hitCount == 3) //���� �ĸ�����
            {
                //���� ȿ�� �Լ� ȣ��
                ExpBarrel();
            }
        }
    }
    void ExpBarrel()
    {
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        //���������� �Ǵ� ���� effect��� ��ü�̸��� �ο�����
        //���� effect��� ��ü���� ���ؼ� �����

        Destroy(effect,2f); //2�ʵڿ� ȿ�� ����

        ////Quaternion.identity :�����̳ʰ� ���� ���� �� �״�� ��������! �����ص帲
        //rb.mass = 1f; //���O�� mass ���� �����ؾߵ� / �巳�̶� �Ѿ��̶� �浹�� ���ߵ� �����ǰ�
        //rb.AddForce(Vector3.up * 500f); //���� 500�� ������ ��������

        IndirectDamage(transform.position);

        //��ϵ� �޽��߿��� �ϳ��� �����ϱ� ���� �������� �̰�
        int idx = Random.Range(0, meshes.Length);
        //���� �ε����� �ش��ϴ� �޽��� �����ؼ� �޽����Ϳ� ����
        meshFilter.sharedMesh = meshes[idx];

        _audio.PlayOneShot(expSfx, 1f);
    }
    void IndirectDamage(Vector3 pos) //(������ �Ͼ ������ �Ű������� �޾ƿ�)
    {
        Collider[] colls = Physics.OverlapSphere(pos, expRadius, 1 << 8); //�ټ��� ��쿡�� �迭�� ���� 
        //8�� ���̾ 1������ �ű��
        //(���߿���, �ݰ�, ������ �� ���̾�)

        //����� ������Ʈ�� ���������� �ϳ��� �����ϵ��� ��
        //1�� �����ϴ� for���� ������
        foreach (var coll in colls)
        {
            var _rb = coll.GetComponent<Rigidbody>();
            _rb.mass = 1;
            _rb.AddExplosionForce(600f, pos, expRadius, 500f);
            //(���� ���߷�, ���߿���, ���ߺ���, ���� ���߷�)
        }

    }
}
