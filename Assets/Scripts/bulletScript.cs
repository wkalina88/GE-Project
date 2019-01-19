using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {


    private PlayerController player;

    public float speed = 20f;

    public GameObject splash;
    
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);

        Destroy(gameObject, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
            Destroy(gameObject);
            
            Instantiate(splash, transform.position, transform.rotation = Quaternion.identity);

            Destroy(collision.gameObject);

            player.UpdateKillCount();
        }

    }
    
}
