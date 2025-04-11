using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject enemyOnePrefab;
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
    }

    // Update is called once per frame
    void Update()
    {
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
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
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
