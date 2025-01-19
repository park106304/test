using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    
    Rigidbody2D rigid;

    public float speed;

    SpriteRenderer spriter;

    Animator anim;
    public Scaner scaner;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>(); 
        anim = GetComponent<Animator>();
        scaner = GetComponent<Scaner>();
        
        
    }

    // Update is called once per frame

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

    }
 
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
     
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();

    }

    void LateUpdate()
    {
        if ( inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;

        }

        anim.SetFloat("Speed", inputVec.magnitude);
    }

    
}
