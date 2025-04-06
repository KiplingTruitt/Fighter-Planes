using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{

    public bool goingUp;
    public float speed;
    private Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()

    {
        if (goingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (goingUp == false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (transform.position.y >= Player.verticalScreenLimit * 1.25f || transform.position.y <= -Player.verticalScreenLimit * 1.25f)
        {
            Destroy(this.gameObject);
        }

                
                
    }
}
