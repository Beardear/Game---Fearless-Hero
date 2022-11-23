using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBorn : MonoBehaviour
{

    //Player
    public GameObject player;

    //�ó��������ɵĹ���
    public GameObject targetEnemy;
    public GameObject targetDarkKnight;
    //���ɹ����������
    public int enemyTotalNum = 3;
    //���ɹ����ʱ����
    public float intervalTime = 5;
    //���ɹ���ļ�����
    public int newEnemyCounter;
    //���ϻ����ŵĹ���ļ�����
    public int curEnemyCounter;
    //ˢ�ֽ���
    public bool bornFinished = false;

    //�ڶ��ֹ��������
    private int enemyDarkKnightNum = 0;

    void Start()
    {
        //instance = this;
        //��ʼʱ���������Ϊ0��
        newEnemyCounter = 0;
        curEnemyCounter = 0;
        enemyDarkKnightNumInit();
        //�ظ����ɹ���
        InvokeRepeating("CreatEnemy", 1F, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //��������ʼ��enemyDarkKnightNum
    private void enemyDarkKnightNumInit()
    {
        Scene scene = SceneManager.GetActiveScene();        //��ǰ��������
        switch (scene.name)
        {
            case "StartScene":
                enemyDarkKnightNum = 0;
                break;
            case "Level1":
                enemyDarkKnightNum = 0;
                break;
            case "Level2":
                enemyDarkKnightNum = 1;
                break;
            case "Level3":
                enemyDarkKnightNum = 2;
                break;
            case "Level4":
                enemyDarkKnightNum = 3;
                break;
            case "EndScene":
                enemyDarkKnightNum = 0;
                break;
            default:
                enemyDarkKnightNum = 0;
                break;
        }
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
        if (newEnemyCounter < enemyTotalNum-enemyDarkKnightNum)         //����������ﻹû���ɹ�
        {
            Instantiate(targetEnemy, newPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(targetDarkKnight, newPosition, Quaternion.identity);        //����������ﹻ����
        }
        

        newEnemyCounter++;
        curEnemyCounter++;

        //��������ﵽ���ֵ
        if (newEnemyCounter == enemyTotalNum)
        {
            //ֹͣˢ��
            bornFinished = true;
            CancelInvoke();
        }
    }
}