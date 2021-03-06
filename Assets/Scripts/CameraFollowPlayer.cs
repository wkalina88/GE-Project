﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    GameObject player;
    bool followPlayer = true;
    public float camDistance = -15.0f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(followPlayer == true)
        {
            camFollowPlayer();
        }
	}

    public void setFollowPlayer(bool val)
    {
        followPlayer = val;
    }
    
    void camFollowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, camDistance);
        this.transform.position = newPos;
    }
}
