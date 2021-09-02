using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Vector3 local_gravity;

    private Rigidbody r_body;

    void Start()
    {
        r_body = this.GetComponent<Rigidbody>();
        r_body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        SetLocalGravity(); //重力をAddForceでかけるメソッドを呼ぶ。FixedUpdateが好ましい。
    }

    private void SetLocalGravity()
    {
        r_body.AddForce(local_gravity, ForceMode.Acceleration);
    }

}
