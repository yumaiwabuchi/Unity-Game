using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    // Start is called before the first frame update

    public static float move_speed = 100.0f;

    GameObject player;

    Rigidbody r_body;

    public bool EnableMove = false;
    public ShadowSetteing Setteing = new ShadowSetteing();

    [System.Serializable]
    public class ShadowSetteing
    {
        public float Rotate;
        public float Speed;
    }

    Vector3 add_speed;
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
        if (transform.position.z < -20.0f)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (EnableMove)
        {
            if (transform.position.z < 50.0f)
            {
                float meteo_rotate = Setteing.Rotate;
                float meteo_speed = Setteing.Speed;

                float r = (2 * Mathf.PI) * (meteo_rotate / 360);
                var angles = new Vector3(Mathf.Cos(r), 0, Mathf.Sin(r));

                //Vector3 velocity = meteo_rotate * new Vector3(meteo_speed * 0.1f, 0.0f, 0.0f);

                add_speed = angles * meteo_speed;
                r_body.velocity += r_body.velocity;
                EnableMove = false;
            }
        }




    }

    public void MeteoSpeedUpdate(float move_speed)
    {
        Vector3 velocity = new Vector3(0.0f, 0.0f, move_speed);
        r_body.velocity = velocity + add_speed;
    }

    public void MeteoAcceleration(float acceleration, float maxSpeed)
    {
        Vector3 velocity = r_body.velocity - add_speed;
        velocity.z += acceleration;
        if (velocity.z < -maxSpeed)
            velocity.z = -maxSpeed;
        r_body.velocity = velocity + add_speed;
    }

    public float MeteoSpeed()
    {
        Vector3 velocity = r_body.velocity - add_speed;
        return velocity.z;
    }
}
