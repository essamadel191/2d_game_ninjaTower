using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{ public GameObject d;
    private Rigidbody2D p;
    // Start is called before the first frame update
    void Start()
    {
        p = d.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" ) {
            GameContol.instance.hit();
            
        }
    }
    
}
