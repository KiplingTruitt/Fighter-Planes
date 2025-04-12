using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{

    public bool goingUp;
    public float speed;
<<<<<<< HEAD

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
=======
    private Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
>>>>>>> origin/Soryanne
    }

    // Update is called once per frame
    void Update()
<<<<<<< HEAD
=======

>>>>>>> origin/Soryanne
    {
        if (goingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (goingUp == false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

<<<<<<< HEAD
        if (transform.position.y >= gameManager.verticalScreenSize * 1.25f || transform.position.y <= -gameManager.verticalScreenSize * 1.25f)
        {
            Destroy(this.gameObject);
        }
=======
        if (transform.position.y >= Player.verticalScreenLimit * 1.25f || transform.position.y <= -Player.verticalScreenLimit * 1.25f)
        {
            Destroy(this.gameObject);
        }

                
                
>>>>>>> origin/Soryanne
    }
}
