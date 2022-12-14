using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    float h;
    float v;
    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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


    }
    void OnTriggerEnter2D(Collider2D o)
    {
        switch (o.gameObject.tag)
        {
            case "Pig":
                print(o.gameObject.name);
                break;
            case "Chicken":
                print(o.gameObject.name);
                break;
            case "Horse":
                print(o.gameObject.name);
                break;
            case "Sheep":
                print(o.gameObject.name);
                break;
            case "Duck":
                print(o.gameObject.name);
                break;
            case "Cow":
                print(o.gameObject.name);
                break;
            case "Shop":
                print(o.gameObject.name);
                break;
        }

    }



    

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(h*10f, v*10f);
    }
}
