using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static float move_speed = 100.0f;

    GameObject player;

    Rigidbody r_body;
    void Start()
    {
        //move_speed = 0.1f + 0.1f * Random.value;
        r_body = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 velocity = new Vector3(0.0f, 0.0f, -move_speed);
        r_body.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        

        //transform.Translate(0.0f, 0.0f, -move_speed);

        if (transform.position.z < -10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    float player_speed = player.GetComponent<Rigidbody>().velocity.z;
    //    Debug.Log(player_speed);

    //    if(player_speed >= 10)
    //    {
    //        collision.collider.material.bounciness = 0.0f;
    //    }
    //    else
    //    {
    //        collision.collider.material.bounciness = 1.0f;

    //    }
    //}
}
