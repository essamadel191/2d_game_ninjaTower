using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCollumn : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(0, GameContol.instance.scrollSpeed - 0.5f);
        if (GameContol.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
