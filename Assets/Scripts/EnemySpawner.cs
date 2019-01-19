﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;

	// Use this for initialization
	void Start () {
        spawnAllowed = true;
        InvokeRepeating("SpawnEnemy", 0f, 1.5f);
	}
	
	
	void SpawnEnemy () {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);
        }
	}
}
