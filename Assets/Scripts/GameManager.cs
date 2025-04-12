using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
=======
using UnityEngine.SceneManagement;
>>>>>>> origin/Soryanne

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
<<<<<<< HEAD
    public GameObject enemyThreePrefab;
    public GameObject cloudPrefab;
    public GameObject healthPickupPrefab;
    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject powerupPrefab;
    public GameObject audioPlayer;

    public AudioClip powerupSound;
    public AudioClip powerdownSound;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerupText;
    
    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;
    public int cloudMove;

    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        cloudMove = 1;
        gameOver = false;
        AddScore(0);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateEnemyThree", 2, 4);
        InvokeRepeating("CreateHealthPickup", 8, Random.Range(8, 12));
        StartCoroutine(SpawnPowerup());
        powerupText.text = "No powerups yet!";
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
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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

<<<<<<< HEAD
    void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(0, 0, 0));
    }

    void CreateHealthPickup()
    {
        Instantiate(healthPickupPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(0, 0, 0));
    }

    void CreatePowerup()
    {
        Instantiate(powerupPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize * 0.8f, verticalScreenSize * 0.8f), 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
        
    }

    public void ManagePowerupText(int powerupType)
    {
        switch (powerupType)
        {
            case 1:
                powerupText.text = "Speed!";
                break;
            case 2:
                powerupText.text = "Double Weapon!";
                break;
            case 3:
                powerupText.text = "Triple Weapon!";
                break;
            case 4:
                powerupText.text = "Shield!";
                break;
            default:
                powerupText.text = "No powerups yet!";
                break;
        }
=======
    void CreatePowerup()
    {
        Instantiate(powerupPrefab, new Vector3(Random.Range(-7f,7f), (Random.Range(-3.5f, 5.5f)), 0), Quaternion.identity);
>>>>>>> origin/Soryanne
    }

    IEnumerator SpawnPowerup()
    {
<<<<<<< HEAD
        float spawnTime = Random.Range(3, 5); 
=======
        float spawnTime = Random.Range(3, 5);
>>>>>>> origin/Soryanne
        yield return new WaitForSeconds(spawnTime);
        CreatePowerup();
        StartCoroutine(SpawnPowerup());
    }

<<<<<<< HEAD
    public void PlaySound(int whichSound)
    {
        switch (whichSound)
        {
            case 1:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerupSound);
                break;
            case 2:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerdownSound);
                break;
        }
    }

    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }

    public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
=======
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
>>>>>>> origin/Soryanne
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        CancelInvoke();
<<<<<<< HEAD
        cloudMove = 0;
    }

=======
    }



>>>>>>> origin/Soryanne
}
