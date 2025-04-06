using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyOnePrefab;
    public GameObject playerPrefab;
    public GameObject coinPrefab;
    public int score;
    private Player Player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateCoin", 2, 3);

        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Player = GameObject.Find("Player").GetComponent<Player>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-6f, 6f),(Random.Range(-3.5f,5f)), 0), Quaternion.identity);
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }

    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
    }



}
