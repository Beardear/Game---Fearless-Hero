using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;

    //Outlet
    private NavMeshAgent agent;
    public Slider slider;

    private int hp = 100;
    private int hpHolder;


    private bool canAttack = false;
    public float autoAttackTime = 0;
    public float autoAttackCd = 1;
    public BoxCollider2D weapon;
    //Configuration
    //public Transform target;

    //Methods
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.rotation = Quaternion.identity;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        hpHolder = hp;

    }
    void Update()
    {
        agent.SetDestination(target.position);
        
        if(canAttack)
        {
            autoAttackTime += Time.deltaTime;
        }
        if(autoAttackTime > autoAttackCd)
        {
            autoAttackTime = 0;
            playerAttack();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)                          //Bug1: Collision with Player may attack; Bug2: Weapon position is not true, is the player pushdown 'A'
    {
        if (hp <= 0) return;
        //print("enemy tag:" + collision.gameObject.tag);
        if (collision.collider.tag == "Player")
        {
            canAttack = true;
        }
        //�������������Ż�Թ�������˺�
        if (collision.collider.tag != "PlayerWeapon")
        {
            return;
        }
        
        hp -= 20;
        slider.value = (float)hp / hpHolder;//ͨ���ı�value��ֵ��float���ͣ����ı�Ѫ�����ȡ�
        if (hp <= 0)
        {
            EnemyBorn.instance.curEnemyCounter--;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.otherCollider.tag == "Monster")
        {
            canAttack = false;
            autoAttackTime = 0;
        }
    }

    private void playerAttack()
    {
        print("���﹥��");
        weapon.enabled = true;
    }

    //public void TakeDamge(int damage)//���ܵ��˺�
    //{
    //    if (hp < 0) return;
    //    hp -= damage;
    //    slider.value = (float)hp / hpHolder;//ͨ���ı�value��ֵ��float���ͣ����ı�Ѫ�����ȡ�
    //    if (hp <= 0)
    //    {
    //        EnemyBorn.instance.curEnemyCounter--;
    //        Destroy(this.gameObject);
    //    }
    //}
}