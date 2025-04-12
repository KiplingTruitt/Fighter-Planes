using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    //how to define a variable
    //1. access modifier: public or private
    //2. data type: int, float, bool, string
    //3. variable name: camelCase
    //4. value: optional

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;
    private int weaponType;
    public float horizontalScreenLimit = 10f;
    public float verticalScreenLimit = 6.5f;

    public GameObject bulletPrefab;
    public GameObject shieldPrefab;
    private int lives = 3;
    public bool Shield;
    private GameManager gameManager;

    void Start()
    {
        playerSpeed = 5.5f;
        //This function is called at the start of the game
        transform.position= new Vector3(0, -3.43f, 0);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        weaponType = 1;
        Shield = false;

    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(weaponType)
            {
                case 1:
                    Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 1, 0), Quaternion.identity);
                    Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 1, 0), Quaternion.identity);
                    break;
            }
            
        }
    }

    public void LoseAlife()
    {
        //lives = lives - 1;
        //lives -= 1;
        if (Shield == false)
            //lose a life
        {
            lives--;

        }
        else
        //do not lose a life, deactivate shield instead!
        {
            shieldPrefab.SetActive(false);
            Shield = false;
        }
    }



        IEnumerator WeaponPowerDown()
    {
        yield return new WaitForSeconds(3f);
        weaponType = 1;
    }



    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Powerup")
        {
            Destroy(whatDidIHit.gameObject);
            //shield
            int whichPowerup = Random.Range(1, 3);
            switch(whichPowerup)
            {
                case 1:
                    //Picked up shield
                    //Do I already have a shield?
                    if (Shield == true)
                    {
                        //do nothing
                        Debug.Log("Shield is already active");
                    }
                    else
                    {
                        //activate the shield's visibility
                        Shield = true;
                        shieldPrefab.SetActive(true);

                    }


                    break;
                case 2:
                    //Picked up double weapon
                    StartCoroutine(WeaponPowerDown());
                    weaponType = 2;
                    break;
            }
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        //Player leaves the screen vertically
        if(transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

}
