using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;

    float player_pos_z;
    float goal_pos_z;

    float player_UI_pos_x = -301.0f;
    float player_UI_goal_pos = -138.4f;

    float player_start_pos;

    float goal_start_pos;

    float player_goal_dif;
    float goal_dif;
    float UI_pos_dif;

    float player_UI_pos_add;

    float UI_add;
    // Start is called before the first frame update
    void Start()
    {
        player_start_pos = player.transform.position.z;
        goal_start_pos = goal.transform.position.z;

        goal_dif = Mathf.Abs(player_start_pos - goal.transform.position.z);

        player_goal_dif = Mathf.Abs(goal_start_pos - player_start_pos);
        UI_pos_dif = Mathf.Abs(player_UI_pos_x - player_UI_goal_pos);

//        player_UI_pos_add = goal_start_pos - player_goal_dif;

//        UI_add = UI_pos_dif / player_goal_dif;
    }

    // Update is called once per frame
    void Update()
    {
        //        player_pos_z = player.transform.position.z;


        float wariai = Mathf.Abs(goal_dif - goal.transform.position.z) / player_goal_dif;
        float ui_x = UI_pos_dif * wariai;

        Vector3 pos = transform.localPosition;
        pos.x = player_UI_pos_x + ui_x;
//        transform.position = pos;
        this.transform.localPosition = pos;

 //       player_UI_pos_x = transform.position.x;



        //        this.transform.Translate(player_pos_z * -UI_add, 0.0f, 0.0f);
    }
}
