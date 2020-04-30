using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;


    // Start is called before the first frame update
    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -groundHorizontalLength-8f)
        {
            RepositionBackground();

        }

    }
    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(0, groundHorizontalLength * 4.25f);
        transform.position = (Vector2)transform.position + groundOffset;

    }
}
