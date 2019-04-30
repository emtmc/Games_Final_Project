using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public bool levelComplete;
    public bool start=false;
    public GameObject ballPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AdMob.admob.DisplayAdMobBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
     onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
     
     //rb.velocity = new Vector2(40, rb.velocity.y);
     //AdMob.admob.ShowAdMobBanner();
       
       if (Input.GetMouseButtonDown(0))
       {
           start = true;
       }
  
       if (start)
       {
           rb.velocity = new Vector2(60, rb.velocity.y);
       }

        if (Input.GetMouseButtonDown(0) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x,20);
        }

        if (!onGround)
        {
            rb.velocity = new Vector2(30, rb.velocity.y);
        }

    }


}
