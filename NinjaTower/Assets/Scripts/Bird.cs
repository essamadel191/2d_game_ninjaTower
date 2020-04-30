using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    public float speed = 5f;
    public bool isGround;
    public bool isJumping;
    public bool isGlide;
    public float jump_rec=0;

    public float timeInvincible = 3.0f;
    public bool isInvincible;
    float invincibleTimer;

    private float hit_area_count = 0;
    private float movement = 0f;
    //is on ground
    private bool is_on;
    private Rigidbody2D rb2d;
    public Animator anim;
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        isGround = true;
        is_on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameContol.instance.isDead == false)
        {
            movement = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(speed * movement, rb2d.velocity.y);

            if (movement < 0f)
            {
                trans.localScale = new Vector3(-0.42159f, trans.localScale.y, trans.localScale.z);
                if (!isGlide && is_on)
                {
                    anim.SetBool("walk", true);
                }
            }
            if (movement > 0f)
            {
                trans.localScale = new Vector3(0.42159f, trans.localScale.y, trans.localScale.z);
                if (!isGlide && is_on)
                {
                    anim.SetBool("walk", true);

                }
            }
            if (movement == 0f)
            {
                if (!isGlide)
                {
                    anim.SetBool("walk", false);
                    anim.SetTrigger("idel");
                }
            }


            if (Input.GetButtonDown("Jump") && jump_rec < 3)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                isGround = false;
                is_on = false;
                jump_rec++;
                if (!isGlide)
                {

                    anim.SetBool("jump2",true);

                }
            }
            if(Input.GetButtonUp("Jump"))
            {
                isGround = true;
                anim.SetBool("jump2",false);
            }


            if (Input.GetButtonDown("Fire1") && is_on)
            {

                anim.SetBool("walk", false);
                anim.SetTrigger("attack");
            }
            if (Input.GetButtonUp("Fire1"))
            {
                GameContol.instance.isAttacking = false;
            }
            if (!is_on && Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("jump_attack");
            }
            

            if (Input.GetButtonDown("Fire2"))
            {
                isGlide = true;
               // anim.SetBool("walk", false);
                anim.SetBool("glid", true);
            }
            if (Input.GetButtonUp("Fire2"))
            {
                isGlide = false;
                anim.SetBool("walk", false);
                anim.SetBool("glid", false);
            }

        }
        else
        {
            rb2d.velocity = Vector2.zero;
            
            GameContol.instance.BirdDie();
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

   
    
     private void OnCollisionEnter2D(Collision2D collision)
    {
        jump_rec = 0;
        is_on = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "dieArea" && hit_area_count <4)
        {
            rb2d.AddForce(new Vector2(0,2500f));
            hit_area_count++;
        }
    }
    


}
