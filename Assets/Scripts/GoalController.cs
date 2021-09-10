using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    // Start is called before the first frame update

    public static float move_speed = 50.0f;

    float meteo_move_start_z = 110.0f;

    GameObject player;

    Rigidbody r_body;

    bool rotation_flg;

    public bool EnableMove = false;
    public ShadowSetteing Setteing = new ShadowSetteing();

    [System.Serializable]
    public class ShadowSetteing
    {
        public float Rotate;
        public float Speed;
        public float Rotation;
    }

    Vector3 add_speed;
    void Start()
    {
        //move_speed = 0.1f + 0.1f * Random.value;
        rotation_flg = false;
        r_body = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 velocity = new Vector3(0.0f, 0.0f, -move_speed);
        r_body.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -500.0f)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (EnableMove)
        {
            if (transform.position.z < meteo_move_start_z)
            {
                float meteo_rotate = Setteing.Rotate;
                float meteo_speed = Setteing.Speed;

                rotation_flg = true;

                float r = (2 * Mathf.PI) * (meteo_rotate / 360);
                var angles = new Vector3(Mathf.Cos(r), 0, Mathf.Sin(r));



                //Vector3 velocity = meteo_rotate * new Vector3(meteo_speed * 0.1f, 0.0f, 0.0f);

                add_speed = angles * meteo_speed;
                r_body.velocity += add_speed;
                EnableMove = false;
            }
        }

        if (rotation_flg)
        {
            if (transform.position.z < meteo_move_start_z)
            {
                float meteo_rotation = Setteing.Rotation;

                transform.Rotate(new Vector3(0.0f, meteo_rotation, 0.0f));
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