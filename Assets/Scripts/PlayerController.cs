using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{

    public int lives;
    private float speed;
    private int weaponType;

    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject thrusterPrefab;
    public GameObject shieldPrefab;
    public bool Shield;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        speed = 5.0f;
        weaponType = 1;
        Shield = false;
        gameManager.ChangeLivesText(lives);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    public void LoseALife()
    {
        //Do I have a shield? If yes: do not lose a life, but instead deactivate the shield's visibility
        //If not: lose a life
        //lives = lives - 1;
        //lives -= 1;
        {
            //lives = lives - 1;
            //lives -= 1;
            if (Shield == false)
            //lose a life
            {
                lives--;
                gameManager.ChangeLivesText(lives);
            }
            else
            //do not lose a life, deactivate shield instead!
            {
                shieldPrefab.SetActive(false);
                Shield = false;
                gameManager.PlaySound(2);
                gameManager.ManagePowerupText(0);
                gameManager.AddScore(5);
            }
        }
    

      
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameManager.GameOver();
            Destroy(this.gameObject);
        }
    }

    public void GainALife()
    {
        if (lives < 2)
        {
            lives++;
            gameManager.ChangeLivesText(lives);
        }

        else if (lives == 2)
        {
            lives++;
            gameManager.ChangeLivesText(lives);
        }

        else
        {
            lives += 0;
            gameManager.score += 5;
            gameManager.scoreText.text = "Score: " + gameManager.score;
        }
    }
    
    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(3f);
        speed = 5f;
        thrusterPrefab.SetActive(false);
        gameManager.ManagePowerupText(0);
        gameManager.PlaySound(2);
    }
    IEnumerator WeaponPowerDown()
    {
        yield return new WaitForSeconds(3f);
        weaponType = 1;
        gameManager.ManagePowerupText(0);
        gameManager.PlaySound(2);
    }

    IEnumerator ShieldPowerDown()
    {
    
        yield return new WaitForSeconds(3f);
        gameManager.ManagePowerupText(0);
        gameManager.PlaySound(2);
        shieldPrefab.SetActive(false);
        Shield = false;

}
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Powerup")
        {
            Destroy(whatDidIHit.gameObject);
            int whichPowerup = Random.Range(1, 5);
            gameManager.PlaySound(1);
            switch (whichPowerup)
            {
                case 1:
                    //Picked up speed
                    speed = 10f;
                    StartCoroutine(SpeedPowerDown());
                    thrusterPrefab.SetActive(true);
                    gameManager.ManagePowerupText(1);
                    break;
                case 2:
                    weaponType = 2; //Picked up double weapon
                    StartCoroutine(WeaponPowerDown());
                    gameManager.ManagePowerupText(2);
                    break;
                case 3:
                    weaponType = 3; //Picked up triple weapon
                    StartCoroutine(WeaponPowerDown());
                    gameManager.ManagePowerupText(3);
                    break;
                case 4:
                    if (Shield == true)
                    {
                        //do nothing
                        Debug.Log("Shield is already active");
                    }
                    else
                    {
                        //activate the shield's visibility
                        Shield = true;
                        shieldPrefab.SetActive(true);//Picked up shield
                        StartCoroutine(ShieldPowerDown());
                        gameManager.ManagePowerupText(4);     
                    }
                        
                    break;
               
                    
            }
        }
    }


    
    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(weaponType)
            {
                case 1:
                    Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
                    Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.Euler(0, 0, 45));
                    Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                    Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.Euler(0, 0, -45));
                    break;
            }
        }
    }

    void Movement()
    {
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float horizontalScreenSize = gameManager.horizontalScreenSize;
        float verticalScreenSize = gameManager.verticalScreenSize;

        if (transform.position.x <= -horizontalScreenSize || transform.position.x > horizontalScreenSize)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y <= -verticalScreenSize/1.6f)
        {
            transform.position = new Vector3(transform.position.x, (-verticalScreenSize/1.6f), 0);
        }

        if (transform.position.y > 1.11f)
        {
            transform.position = new Vector3(transform.position.x, 1.11f, 0);
        }
    }
}
