using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using TMPro;
=======
using UnityEngine.SceneManagement;
>>>>>>> origin/Soryanne

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
<<<<<<< HEAD
    public GameObject cloudPrefab;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        ChangeScoreText(score);
=======
    public GameObject playerPrefab;
    public GameObject coinPrefab;
    public int score;
    private Player Player;
    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject powerupPrefab;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateCoin", 2, 3);
        StartCoroutine(SpawnPowerup());
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Player = GameObject.Find("Player").GetComponent<Player>();
        score = 0;
        gameOver = false;
>>>>>>> origin/Soryanne
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
    }

    void CreateEnemy()
=======
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
       
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-6f, 6f),(Random.Range(-3.5f,5f)), 0), Quaternion.identity);
    }

    void CreateEnemyOne()
>>>>>>> origin/Soryanne
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
        
    }
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore +1;
    }

    public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
    public void ChangeScoreText (int currentScore)
    {
        scoreText.text = "Score: " + currentScore;
    }

    void CreatePowerup()
    {
        Instantiate(powerupPrefab, new Vector3(Random.Range(-7f,7f), (Random.Range(-3.5f, 5.5f)), 0), Quaternion.identity);
    }

    IEnumerator SpawnPowerup()
    {
        float spawnTime = Random.Range(3, 5);
        yield return new WaitForSeconds(spawnTime);
        CreatePowerup();
        StartCoroutine(SpawnPowerup());
    }

    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        CancelInvoke();
    }



}
