using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinPrefab;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("DestroyObjectDelayed", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            gameManager.AddScore(1);
            Destroy(this.gameObject);
        }
        
        
    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 2 seconds after loading the object
        Destroy(gameObject, 2);
    }

}
