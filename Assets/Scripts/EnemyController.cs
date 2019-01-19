﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

   
    private Animator animator;

    public float damageDistance;

    public float attackRange;
    
    private float lastAttackTime;
    public float attackDelay;


    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;

    

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        //damageDistance = 1.85f;
        target = GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > damageDistance + 4f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isHitting", true);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //animator.SetBool("isMoving", false);
            //animator.SetBool("isHitting", true);
        }

    }

}
