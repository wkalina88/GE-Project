using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public bool moving = false;
    float speed = 5.0f;
    private Animator animator;

    public AudioSource gunshot;

    public float curHealth;
    public float maxHealth = 300f;
    public Text playerLife;
    public Text KillCount;

    public int KillCounter;

    

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        curHealth = maxHealth;
        CountersUpdate();
        KillCounter = 0;

    }
	
	// Update is called once per frame
	void Update () {

        CountersUpdate();

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("PlayerShoot");
            gunshot.Play();
        }
        if (Input.GetButtonDown("Melee"))
        {
            animator.SetTrigger("PlayerMelee");
        }
        
        Movement();

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            Dead();
        }

        
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            moving = true;
            animator.SetBool("PlayerMove", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            moving = true;
            animator.SetBool("PlayerMove", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            moving = true;
            animator.SetBool("PlayerMove", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            moving = true;
            animator.SetBool("PlayerMove", true);
            
        }
        if(Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.S) != true && Input.GetKey(KeyCode.W) != true)
        {
            moving = false;
            animator.SetBool("PlayerMove", false);
        }
       
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            curHealth -= 2.0f;

        }

    }
    
    
    void Dead()
    {
        //restart
        Application.LoadLevel(Application.loadedLevel);
    }

    void CountersUpdate()
    {
        playerLife.text = string.Format("{0}", curHealth);
        KillCount.text = string.Format("{0}", KillCounter);
    }

    public void UpdateKillCount()
    {
        KillCounter += 1;
    }
}
