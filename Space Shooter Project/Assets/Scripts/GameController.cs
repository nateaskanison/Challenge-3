using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public bool hardMode;

    public Text ScoreText;
    public Text restartText;
    public Text gameoverText;
    public Text hardmodeText;

    public bool gameOver;
    private bool restart;
    public int score;
    
    
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioClip baseMusic;
    public AudioSource musicSource;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameoverText.text = "";
        score = 0;
        UpdateScore();
        musicSource.clip = baseMusic;
        musicSource.Play();
        HardMode();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            hardMode = true;
            hardmodeText.text = "";
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        hardmodeText.text = "";
        while (true)
        {
            if (hardMode)
            {
                hazardCount = hazardCount * 2;
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
            else
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        ScoreText.text = "Points:" + score;
        if (score >= 100)
        {
            musicSource.Stop();
            musicSource.clip = winMusic;
            musicSource.Play();
            gameoverText.text = "You Won by Nathan Pluskota";
            gameOver = true;
            restart = true;
        }
    }
    void HardMode()
    {
        hardmodeText.text = "Press H to enable Hardmode";
    }
    public void GameOver()
    {
        gameoverText.text = "Game Over by Nathan Pluskota";
        musicSource.Stop();
        musicSource.clip = loseMusic;
        musicSource.Play();
        gameOver = true;
    }
}
