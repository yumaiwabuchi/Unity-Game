using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject time_object;

    public float time_count = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text time_text = time_object.GetComponent<Text>();

        time_count += Time.deltaTime;

        time_text.text = "É^ÉCÉÄÅF" + time_count;
    }
}
