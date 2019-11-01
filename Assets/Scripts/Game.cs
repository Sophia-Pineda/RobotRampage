using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
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
    public GameObject gameOverPanel;


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

    public void OnGUI()
    {
        if(isGameOver && Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //2
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        player.AddComponent<FirstPersonController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        gameOverPanel.SetActive(true);
    }

    //3
    public void RestartGame()
    {
        SceneManager.LoadScene(Constants.SceneBattle);
        gameOverPanel.SetActive(true);
    }

    //4
    public void Exit()
    {
        Application.Quit();

    }

    //5 
    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.SceneMenu);
    }
}

