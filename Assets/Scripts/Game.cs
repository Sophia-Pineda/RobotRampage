﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static Game singleton;
    [SerializeField]
    RobotSpawn[] spawns;

    public int enemiesLeft;

    //1 
    private void Start()
    {
        singleton = this;
        SpawnRobots();
    }
    //2
    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
            spawn.SpawnRobots();
        enemiesLeft++;

    }

}

