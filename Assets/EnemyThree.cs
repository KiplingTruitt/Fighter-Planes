using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy3 : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 1)
        {
            transform.Translate(new Vector3((float)0, (float)-0.5, 0) * Time.deltaTime * 3f);
        }
        
        if (timer >= 1)
        {
            transform.Translate(new Vector3((float)0, -5, 0) * Time.deltaTime * 3f);
        }

        
        
           
        
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
