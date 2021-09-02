using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject meteorite_prefab;

    [SerializeField]
    float meteorite_start_pos = 50.0f;

    void Start()
    {
        InvokeRepeating("GenerateMeteorite", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMeteorite()
    {
        Instantiate(meteorite_prefab, new Vector3(-5.5f + 9.0f * Random.value, 0.0f, meteorite_start_pos),Quaternion.identity);
    }
}
