using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    public float rangeAttack;
    private float nextAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextAttack)
        {
            Attacking();
        }
    }

    void Attacking()
    {
        anim.SetTrigger("Attack");
        nextAttack = Time.time + rangeAttack;
    }
}