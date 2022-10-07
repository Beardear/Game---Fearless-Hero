using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    //Outlet
    Rigidbody2D _rigidbody2D;
    SpriteRenderer sprite;
    Animator animator;

    public Slider slider;
    public int hp = 100;
    private int hpHolder;
    /// <summary>
    /// ��߹�����ײ��
    /// </summary>
    public GameObject LeftWeapon;
    /// <summary>
    /// �ұ߹�����ײ��
    /// </summary>
    public GameObject RightWeapon;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        hpHolder = hp;

        // ����Ĭ������
        setDirection(false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);


        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += new Vector3(0, 0.1f, 0);
            _rigidbody2D.AddForce(Vector2.up * 25f * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += new Vector3(0, -0.1f, 0);
            _rigidbody2D.AddForce(Vector2.down * 25f * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += new Vector3(-0.1f, 0, 0);
            _rigidbody2D.AddForce(Vector2.left * 36f * Time.deltaTime, ForceMode2D.Impulse);
            sprite.flipX = true;
            setDirection(true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(0.1f, 0, 0);
            _rigidbody2D.AddForce(Vector2.right * 36f * Time.deltaTime, ForceMode2D.Impulse);
            sprite.flipX = false;
            setDirection(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //_rigidbody2D.velocity.Set(0,0);
            //animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);

            animator.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)                          //Bug1: Collision with Player may attack; Bug2: Weapon position is not true, is the player pushdown 'A'
    {
        print("player tag:" + collision.collider.tag);
        //�������������Ż�����ǲ����˺�
        if (collision.collider.tag != "MonsterWeapon")
        {
            return;
        }
        collision.collider.enabled = false;
        if (hp < 0) return;
        hp -= 5;
        slider.value = (float)hp / hpHolder;//ͨ���ı�value��ֵ��float���ͣ����ı�Ѫ�����ȡ�
        //if (hp <= 0)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    //public void TakeDamge(int damage)//���ܵ��˺�
    //{
    //    if (hp < 0) return;
    //    hp -= damage;
    //    slider.value = (float)hp / hpHolder;//ͨ���ı�value��ֵ��float���ͣ����ı�Ѫ�����ȡ�
    //    //if (hp <= 0)
    //    //{
    //    //    Destroy(this.gameObject);
    //    //}
    //}

    /// <summary>
    /// �������Ƿ�����ʾ��Ӧ������ײ��
    /// </summary>
    /// <param name="value"></param>
    private void setDirection(bool value)
    {
        LeftWeapon.SetActive(value);
        RightWeapon.SetActive(!value);
    }
}