using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameContol.instance.isAttacking == true)
        {
            g.SetActive(false);
        }
        if (collision.gameObject.tag == "Player")
        {
            GameContol.instance.hit();
        }
        if (collision.gameObject.tag == "dieArea")
        {
            g.SetActive(false);
        }
    }
   */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird player = collision.gameObject.GetComponent<Bird>();
        if(player != null)
        {
            player.isInvincible = true;
            GameContol.instance.hit();
        }
    }
}
