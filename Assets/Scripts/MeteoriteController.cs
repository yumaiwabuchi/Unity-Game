using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    // Start is called before the first frame update
    float move_speed;

    GameObject player;
    void Start()
    {
        //move_speed = 0.1f + 0.1f * Random.value;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0.0f, 0.0f, -move_speed);

        //if (transform.position.z < -10.0f)
        //{
        //    Destroy(gameObject);
        //}
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
