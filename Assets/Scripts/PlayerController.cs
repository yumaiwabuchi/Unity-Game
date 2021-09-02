using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float player_speed = 1.0f;

    [SerializeField]
    float limit_right_speed = 10.0f;

    [SerializeField]
    float limit_left_speed = -10.0f;

    [SerializeField]
    float limit_speed_z = 10.0f;

    [SerializeField]
    PhysicMaterial physicMaterial;

    public GameObject player;

    Rigidbody r_body;
    bool leftFlag, rightFlag;

    float maxSpeed;
    float stay_time;
    bool side_hit_flag;

    void Start()
    {
        leftFlag  = false;
        rightFlag = false;
        side_hit_flag = false;
    }

    private void FixedUpdate()
    {
        r_body = GetComponent<Rigidbody>();
        Vector3 force = gameObject.transform.rotation * new Vector3(0.0f, 0.0f, 5.0f);
        r_body.AddForce(force);

        if(rightFlag)
        {
            r_body.AddForce(30.0f, 0.0f, 0.0f);
            rightFlag = false;
        }
        if (leftFlag)
        {
            r_body.AddForce(-30.0f, 0.0f, 0.0f);
            leftFlag = false;
        }

        if(r_body.velocity.magnitude > limit_right_speed)
        {
            r_body.velocity = r_body.velocity.normalized * limit_right_speed;
        }

        //if (r_body.velocity.magnitude < limit_left_speed)
        //{
        //    r_body.velocity = r_body.velocity.normalized * limit_left_speed;
        //}

        //transform.position += force * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float d_pad_h = Input.GetAxis("D_Pad_H");
        float l_stick_h = Input.GetAxis("L_Stick_H");

        if (Input.GetKey(KeyCode.D) || d_pad_h > 0 || l_stick_h > 0)
        {
            rightFlag = true;
//            transform.Rotate(0, 50 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A) || d_pad_h < 0 || l_stick_h < 0)
        {
            leftFlag = true;
//            transform.Rotate(0, -50 * Time.deltaTime, 0);
        }

        if (r_body.velocity.z >= 20.0f)
            physicMaterial.bounciness = 0.2f;
        else
            physicMaterial.bounciness = 0.4f;

        if (r_body.velocity.z > maxSpeed)
            maxSpeed = r_body.velocity.z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Front"))
        {
            Invoke("AddPower", 2.0f);
        }

        if (collision.gameObject.CompareTag("Side"))
        {
            side_hit_flag = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
        //if (maxSpeed >= 10.0f)
//        r_body.AddForce(0.0f, 0.0f, maxSpeed * 50.0f);
//        maxSpeed = 0.0f;
    }

    void AddPower()
    {
        r_body.AddForce(0.0f, 0.0f, 1000,0f);
        maxSpeed = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        stay_time = 0.0f;
        side_hit_flag = false;
    }

    private void OnTriggerStay(Collider other)
    {
        stay_time += Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {      
        if (!side_hit_flag)
        r_body.AddForce(0.0f, 0.0f, 2500.0f * stay_time);

        side_hit_flag = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Destroy(player);
    //}
}
