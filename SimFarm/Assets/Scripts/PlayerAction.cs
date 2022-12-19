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
    private bool stop = true;
    private AudioSource audioSource;

    private bool soundPlay = true;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        manager = GameManager.Instance;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator _soundPlay() {
        yield return new WaitForSeconds(0.3f);
        audioSource.Play();
        soundPlay = true;
    }

    void Update()
    {
        if(stop){
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        if(rigid.velocity.magnitude > 0 && soundPlay){
            StartCoroutine(_soundPlay());
            soundPlay = false;
        }

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
    
    public void moveToggle() {
        this.stop = !this.stop;
    }
    
    void OnTriggerEnter2D(Collider2D o)
    {
        string input = o.gameObject.tag;
        manager.onEnter(input);

    }    
    void OnTriggerExit2D(Collider2D o) {
        manager.offEnter();
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(h*10f, v*10f);
    }
}
