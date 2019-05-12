using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float forceHorizontal = 15;
    public float forceVertical = 10;
    public float timeDestruction = 1;

    private float forceHorizontalDefault;
    
    // Start is called before the first frame update
    void Start()
    {
        forceHorizontalDefault = forceHorizontal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().enabled = false;

            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();

            foreach(BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            if(other.transform.position.x < transform.position.x)
            {
                forceHorizontal *= -1;
            }

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceHorizontal, forceVertical), ForceMode2D.Impulse);

            Destroy(other.gameObject, timeDestruction);

            forceHorizontal = forceHorizontalDefault;
        }
    }
}