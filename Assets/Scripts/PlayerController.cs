using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float player_speed = 50.0f;

    [SerializeField]
    float player_max_speed = 10.0f;

    [SerializeField]
    float meteo_add_speed = 10.0f;

    [SerializeField]
    float meteo_max_speed = 300.0f;

    [SerializeField]
    float invincible_time = 2.0f;

    [SerializeField]
    float meteo_down_time = 1.5f;

    //[SerializeField]
    //float player_speed = 1.0f;

    //[SerializeField]
    //float player_side_add_speed = 1.0f;



    //[SerializeField]
    //float player_x_speed = 30.0f;

    //[SerializeField]
    //float player_hit_heal_seconds = 2.0f;

    //[SerializeField]
    //float player_hit_heal_speed = 1000.0f;

    //[SerializeField]
    //float dashbord_add_speed = 2500.0f;

    [SerializeField]
    PhysicMaterial physicMaterial;

    [SerializeField]
    float player_inertia = 0.7f;

    public GameObject player_box;

    Rigidbody r_body;
    Collider player_hit_box;
    bool leftFlag, rightFlag, upFlag, downFlag;

    float maxSpeed;
    float stay_time;
    bool side_hit_flag;
    bool right_side_flg;
    bool left_side_flg;
    float stick_angle;

    bool meteo_add_flg;
    bool meteo_gensoku_flg;
    float gensokuTime;
    float nowSpeed;
    bool meteo_hit_flg;
    bool meteo_active;


    void Start()
    {
        leftFlag  = false;
        rightFlag = false;
        upFlag = false;
        downFlag = false;
        side_hit_flag = false;
        right_side_flg = false;
        left_side_flg = false;
        meteo_add_flg = false;

        r_body = GetComponent<Rigidbody>();

        player_hit_box = GetComponent<Collider>();

        
    }

    private void FixedUpdate()
    {
        if (meteo_hit_flg)
        {
            if (!meteo_active)
            {
                meteo_active = true;

                if (meteo_active)
                {
                    player_box.SetActive(true);
                }
            }
            else
            {
                meteo_active = false;

                if (!meteo_active)
                {
                    player_box.SetActive(false);
                }
            }
        }
        else
        {
            player_box.SetActive(true);
        }
        //Vector3 force = gameObject.transform.rotation * new Vector3(0.0f, 0.0f, 5.0f);
        //        r_body.AddForce(force);

        //if (rightFlag)
        //{
        //    if (r_body.velocity.x < 0.0f)
        //    {
        //        var velocity = r_body.velocity;
        //        velocity.x *= player_inertia;
        //        r_body.velocity = velocity;
        //    }

        //    r_body.AddForce(player_x_speed, 0.0f, 0.0f);
        //    //force += new Vector3(player_x_speed, 0.0f, 0.0f);
        //    rightFlag = false;
        //}

        //if (leftFlag)
        //{
        //    if (r_body.velocity.x > 0.0f)
        //    {
        //        var velocity = r_body.velocity;
        //        velocity.x *= player_inertia;
        //        r_body.velocity = velocity;
        //    }

        //    r_body.AddForce(-player_x_speed, 0.0f, 0.0f);
        //    //force += new Vector3(-player_x_speed, 0.0f, 0.0f);
        //    leftFlag = false;
        //}

        //if (upFlag)
        //{
        //    if (r_body.velocity.z < 0.0f)
        //    {
        //        var velocity = r_body.velocity;
        //        velocity.z *= player_inertia;
        //        r_body.velocity = velocity;
        //    }

        //    r_body.AddForce(0.0f, 0.0f, player_x_speed);
        //    //force += new Vector3(player_x_speed, 0.0f, 0.0f);
        //    upFlag = false;
        //}

        //if (downFlag)
        //{
        //    if (r_body.velocity.z > 0.0f)
        //    {
        //        var velocity = r_body.velocity;
        //        velocity.z *= player_inertia;
        //        r_body.velocity = velocity;
        //    }

        //    r_body.AddForce(0.0f, 0.0f, -player_x_speed);
        //    //force += new Vector3(player_x_speed, 0.0f, 0.0f);
        //    downFlag = false;
        //}

        if (r_body.velocity.magnitude > player_max_speed)
        {
            r_body.velocity = r_body.velocity.normalized * player_max_speed;
        }

        //r_body.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        float l_stick_h = Input.GetAxis("L_Stick_H");
        float l_stick_v = Input.GetAxis("L_Stick_V");

        Vector3 velocity;
        velocity.x = l_stick_h * Mathf.Sqrt(1.0f - 0.5f * l_stick_v * l_stick_v);
        velocity.y = 0.0f;
        velocity.z = l_stick_v * Mathf.Sqrt(1.0f - 0.5f * l_stick_h * l_stick_h);

        r_body.velocity = velocity * player_speed;

        if (!meteo_hit_flg)
        {
            if (Input.GetKey("joystick button 1"))
            {
                meteo_add_flg = true;
                meteo_gensoku_flg = false;

                GameObject[] meteos = GameObject.FindGameObjectsWithTag("Meteo Tag");
                for (int i = 0; i < meteos.Length; i++)
                {
                    meteos[i].GetComponent<MeteoriteController>().MeteoAcceleration(-meteo_add_speed, meteo_max_speed);
                }

                if (meteos.Length > 0)
                    nowSpeed = meteos[0].GetComponent<MeteoriteController>().MeteoSpeed();
            }

            if (meteo_add_flg)
            {
                if (Input.GetKeyUp("joystick button 1"))
                {
                    meteo_add_flg = false;
                    meteo_gensoku_flg = true;
                    gensokuTime = 0.0f;
                }
            }
        }
        //else
        //{
        //    meteo_gensoku_flg = true;
        //}

        if (meteo_gensoku_flg)
        {
            gensokuTime += Time.deltaTime * meteo_down_time;
            GameObject[] meteos = GameObject.FindGameObjectsWithTag("Meteo Tag");
            for (int i = 0; i < meteos.Length; i++)
            {
                float speed = Mathf.Lerp(nowSpeed, -MeteoriteController.move_speed / 3, gensokuTime);
                meteos[i].GetComponent<MeteoriteController>().MeteoSpeedUpdate(speed);
                //Debug.Log(speed);
            }

            if (gensokuTime >= 1.0f)
            {
                meteo_gensoku_flg = false;
                gensokuTime = 0.0f;
            }

        }

        //if (meteo_hit_flg) 
        //{
        //    float speed_down_time = 0;
        //    speed_down_time += Time.deltaTime;
        //    GameObject[] meteos = GameObject.FindGameObjectsWithTag("Meteo Tag");
        //    for (int i = 0; i < meteos.Length; i++)
        //    {
        //        float speed = Mathf.Lerp(nowSpeed, -10, speed_down_time);
        //        meteos[i].GetComponent<MeteoriteController>().MeteoSpeedUpdate(speed);
        //        //Debug.Log(speed);
        //    }

        //    if (gensokuTime >= 1.0f)
        //    {
        //        meteo_hit_flg = false;
        //        gensokuTime = 0.0f;
        //    }
        //}

        //float d_pad_h = Input.GetAxis("D_Pad_H");
        //float d_pad_v = Input.GetAxis("D_Pad_V");
        //float l_stick_h = Input.GetAxis("L_Stick_H");
        //float l_stick_v = Input.GetAxis("L_Stick_V");

        //if (!right_side_flg)
        //{
        //    if (Input.GetKey(KeyCode.D) || d_pad_h > 0 || l_stick_h > 0)
        //    {
        //        rightFlag = true;
        //        //            transform.Rotate(0, 50 * Time.deltaTime, 0);
        //    }
        //}

        //if (!left_side_flg)
        //{
        //    if (Input.GetKey(KeyCode.A) || d_pad_h < 0 || l_stick_h < 0)
        //    {
        //        leftFlag = true;
        //        //            transform.Rotate(0, -50 * Time.deltaTime, 0);
        //    }
        //}

        //if (Input.GetKey(KeyCode.W) || d_pad_v > 0 || l_stick_v > 0)
        //{
        //    upFlag = true;
        //    //            transform.Rotate(0, 50 * Time.deltaTime, 0);
        //}

        //if (Input.GetKey(KeyCode.S) || d_pad_v < 0 || l_stick_v < 0)
        //{
        //    downFlag = true;
        //    //            transform.Rotate(0, 50 * Time.deltaTime, 0);
        //}


        //if (r_body.velocity.z >= 20.0f)
        //    physicMaterial.bounciness = 0.2f;
        //else
        //    physicMaterial.bounciness = 0.4f;

        //if (r_body.velocity.z > maxSpeed)
        //    maxSpeed = r_body.velocity.z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!meteo_hit_flg)
        {
            if (collision.gameObject.CompareTag("Meteo Tag"))
            {
                this.gameObject.layer = LayerMask.NameToLayer("Invincible");
                Invoke("StopInvincible", invincible_time);
                meteo_hit_flg = true;
                meteo_gensoku_flg = true;
                nowSpeed = GameObject.FindGameObjectWithTag("Meteo Tag").GetComponent<MeteoriteController>().MeteoSpeed();
            }
        }
        //if (collision.gameObject.CompareTag("Front"))
        //{
        //    Invoke("AddPower", player_hit_heal_seconds);
        //}

        //if (collision.gameObject.CompareTag("Side"))
        //{
        //    side_hit_flag = true;
        //}

        
    }

    void StopInvincible()
    {
        this.gameObject.layer = 0;
        meteo_hit_flg = false;
    }

    private void OnCollisionExit(Collision collision)
    {

        //if (maxSpeed >= 10.0f)
        //        r_body.AddForce(0.0f, 0.0f, maxSpeed * 50.0f);
        //        maxSpeed = 0.0f;
        

    }

    

    private void OnTriggerEnter(Collider other)
    {
        //stay_time = 0.0f;
        //side_hit_flag = false;

        if (other.gameObject.CompareTag("Right Side"))
        {
            right_side_flg = true;
        }

        if (other.gameObject.CompareTag("Left Side"))
        {
            left_side_flg = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //stay_time += Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {      
        //if (!side_hit_flag)
        //r_body.AddForce(0.0f, 0.0f, player_side_add_speed * stay_time);

        //side_hit_flag = false;
        right_side_flg = false;
        left_side_flg = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(player);
    //}
}
