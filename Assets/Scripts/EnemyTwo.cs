using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject explosionPrefab;
    private float timer;
    public float speed;
    private float y;
    private float x;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            y = transform.position.y;
            x = transform.position.x;
            timer += Time.deltaTime;
            if (timer < 1.9)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            if (timer > 1.9)
            {

                transform.position = new Vector3((Random.Range(x + 6, x - 6)), y, 0);
                
                timer = 0;

            }

            if (x <= -gameManager.horizontalScreenSize * 1.05f)
            {
                transform.position = new Vector3((Random.Range (x + 3,x + 6)), y, 0);
                timer = 0;
            }
            
            if (x >= gameManager.horizontalScreenSize * 1.05f)
            {
                transform.position = new Vector3((Random.Range(x - 3, x - 6)), y, 0);
                timer = 0;
            }


                if (transform.position.y >= gameManager.verticalScreenSize * 1.25f || transform.position.y <= -gameManager.verticalScreenSize * 1.25f)
            {
                Destroy(this.gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.AddScore(5);
            Destroy(this.gameObject);
        }
    }

}