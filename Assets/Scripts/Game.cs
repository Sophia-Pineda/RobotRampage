using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static Game singleton;
    [SerializeField]
    RobotSpawn[] spawns;

    public GameUI gameUI;
    public GameObject player;
    public int enemiesLeft;
    public int Score;
    public int waveCountdown;
    public bool isGameOver;

    //1 
    private void Start()
    {
        singleton = this;
        SpawnRobots();

        StartCoroutine("increaseSCoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountdown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");

    }
    //2
    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
            spawn.SpawnRobots();
        enemiesLeft++;

        gameUI.SetEnemyText(enemiesLeft);
    }

private IEnumerator updateWaveTimer()
        {
            while (!isGameOver)
            {
                yield return new WaitForSeconds(1.0f);
                waveCountdown--;
                gameUI.SetWaveText(waveCountdown);

                //spawn next wave and restart timer
                if (waveCountdown == 0)
                {
                    SpawnRobots();
                    waveCountdown = 30;
                    gameUI.ShowNewWaveText();
                }
            }
        }
        public static void RemoveEnemy()
        {
            singleton.enemiesLeft--;
            singleton.gameUI.SetEnemyText(singleton.enemiesLeft);

            //bonus
            if (singleton.enemiesLeft == 0)
            {
                singleton.Score += 50;
                singleton.gameUI.ShowWaveClearBonus();
            }
        }

  public void AddRobotKillToScore()
        {
            Score += 10;
            gameUI.SetScoreText(Score);
        }
    IEnumerator increaseScoreEachSecond()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            Score += 1;
            gameUI.SetScoreText(Score);
        }
    }

}

