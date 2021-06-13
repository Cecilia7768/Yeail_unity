using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerSfx
{
    public AudioClip[] fire;
    public AudioClip[] reload;
}
//struct = ����ü,Ŭ���� ��ȭ������ �����ϸ� ����
//Ŭ������ ����ü ���� ������ ����
//�׷��� ���ݿ��ͼ��� �޸� ���� ������ ���̸� ������ ��ɻ��� ū ���̴� ����

[System.Serializable] //����ȭ �ν����Ϳ� ǥ��

public class FireCtrl : MonoBehaviour
{
    public enum WeaponType
    {
        RIFLE = 0,
        SHOTGUN
    }

    public WeaponType currWeapon = WeaponType.RIFLE;

    public GameObject bullet; //û�� ������ �翵�ϱ� ���� ����
    public Transform firePos; //�Ѿ� �߻� ��ġ
    public ParticleSystem catridge;//ź�� ������
    private ParticleSystem muzzleFlash;//�ѱ�ȭ�� ��ƼŬ

    AudioSource _audio;
    public PlayerSfx playerSfx; //����� Ŭ�� ���� ����
    private void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //0�̸� �� 1�̸� ��Ŭ��
                                         //Down�Լ��� �������� �ѹ��� ����
        {
            //�����Լ� ȣ��
            Fire();
        }
    }
    void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        //Instantiate (�������� �� ������Ʈ, ��ġ , ����)
        //������ �ʴ� ����(������Ʈ)�� Ȱ��ȭ ���ִ� �Լ�

        //�Ѿ� �����ϰ� ����-��!
        catridge.Play(); //ź�� ��ƼŬ ���
        muzzleFlash.Play();
        //FireSfx();
    }
    //void FireSfx()
    //{
    //    var _sfx = playerSfx.fire[(int)currWeapon]; //���� ���������� ���� ������ҽ���ȭ
    //    //���� ���õ� ������ �ѹ��� �´� ���带 �����ؼ� �������
    //    _audio.PlayOneShot(_sfx ,1f);
    //}
}
