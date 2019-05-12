using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    private bool facingRight = false;

    public float jumpForce = 1000;
    private bool isGround = false;
    private Transform groundCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();       
        groundCheck = gameObject.transform.Find("EnemyGroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(!isGround)
        {
            speed *= -1;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if(speed > 0 && !facingRight)
        {
            Flip();
        }
        else if(speed < 0 && facingRight)
        {
            Flip();
        }
    }
 
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();

            foreach(BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            speed = 0;

            transform.Rotate(new Vector3(0, 0, -180));
            
            Destroy(gameObject);
        }
    }
}