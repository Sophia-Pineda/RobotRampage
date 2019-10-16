using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] robots;

    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip fireSound;
    [SerializeField]
    private AudioClip weakHitSound;


    private int timesSpawned;     
    private int healthBonus = 0;

    public void SpawnRobots()
    {
        timesSpawned++;
        healthBonus += 1 * timesSpawned;
        GameObject robot = Instantiate(robots[Random.Range(0, robots.Length)]);
        robot.transform.position = transform.position;
        robot.GetComponent<Robot>().health += healthBonus;
    }

}
