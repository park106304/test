using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public RuntimeAnimatorController[] animCon;
    public float health;
    public float maxHealth;
    public Rigidbody2D target;
    bool isLive;
    Rigidbody2D rigid;
    public Animator anim;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait;
    Collider2D coll;
    // Start is called before the first frame update


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        wait = new WaitForFixedUpdate();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
          return;


        Vector2 dirVec = target.position - rigid.position;
        // fixeddeltatime이란? 프레임마다 불합리함을 없에기위해 사용
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;


        
         
    
    }

    void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || isLive)
           return;
        
        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnonkBack());


        if (health > 0) {
           anim.SetTrigger("Hit");
        
        }

        else {
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            spriter.sortingOrder = 1;
            anim.SetBool("Dead", true);
            
            GameManager.instance.Kill++;
            GameManager.instance.GetExp();
            
            

            
        }

       
    }

    IEnumerator KnonkBack()
    {
        yield return null;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 2 ,ForceMode2D.Impulse);
        
    }



    void Dead()
        {
            gameObject.SetActive(false);
        }


   
}
