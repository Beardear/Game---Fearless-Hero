using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBorn : MonoBehaviour
{
    public static EnemyBorn instance;

    //Player
    public GameObject player;

    //�ó��������ɵĹ���
    public GameObject targetEnemy;
    //���ɹ����������
    public int enemyTotalNum = 3;
    //���ɹ����ʱ����
    public float intervalTime = 5;
    //���ɹ���ļ�����
    public int enemyCounter;
    //ˢ�ֽ���
    public bool bornFinished=false;

    //���ɹ���ļ�����

    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //��ʼʱ���������Ϊ0��
        enemyCounter = 0;
        //�ظ����ɹ���
        InvokeRepeating("CreatEnemy", 1F, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //���������ɹ���
    private void CreatEnemy()
    {
        //Random Positions
        //X����2-8��Y����-4--1��EnemyBorn.transform.position=(2,-4)
        Vector3 newPosition = this.transform.position;
        newPosition.x += Random.Range(0, 6.0f);
        newPosition.y += Random.Range(0, 3.0f);

        //����һֻ����
        Instantiate(targetEnemy, newPosition, Quaternion.identity);
        //targetEnemy.GetComponent<Enemy>().target = player.transform;
        enemyCounter++;
        //��������ﵽ���ֵ
        if (enemyCounter == enemyTotalNum)
        {
            //ֹͣˢ��
            CancelInvoke();
            bornFinished = true;
        }
    }
}