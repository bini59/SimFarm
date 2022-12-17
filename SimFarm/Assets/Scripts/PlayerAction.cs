using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Simfarm;
public class PlayerAction : MonoBehaviour
{
    public GameManager manager;
    float h;
    float v;
    Rigidbody2D rigid;
    Animator anim;
    bool isHorizontal;
    bool isVertical;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        manager = GameManager.Instance;
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //좌표를 받아서 사용할 경우
        /*
        Vector2 pos;
        pos = this.gameObject.transform.position;
        Debug.Log(pos);
        */
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        //animation
        if(anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);

        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);


    }
    void OnTriggerEnter2D(Collider2D o)
    {
        string input = o.gameObject.tag;
        
        string tag = input.Equals("Shop") ? input : "BarnAnimal/" + input;
        manager.onEnter(tag);

    }    
    void OnTriggerExit2D(Collider2D o) {
        manager.offEnter();
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(h*10f, v*10f);
    }
}
