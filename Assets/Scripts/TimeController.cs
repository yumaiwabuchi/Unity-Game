using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject text_display;

    float goal_time;

    int int_time;

    string time_string;

    bool time_flg;

    float time = 0.0f;

    // Update is called once per frame
    public void Update()
    {
        if (time_flg)
        {
            time += Time.deltaTime;
        }

        goal_time = time;
        int_time = (int)(goal_time * 10.0f);
        time_string = int_time.ToString("D4");

        if(int_time/1000 < 1 && int_time / 100 < 1)
        {
            text_display.GetComponent<TextMeshProUGUI>().text =
            "<sprite=" + time_string[2] + ">" +
            "<sprite=" + time_string[3] + ">";
        }
        else if(int_time / 1000 < 1)
        {
            text_display.GetComponent<TextMeshProUGUI>().text =
            "<sprite=" + time_string[1] + ">" +
            "<sprite=" + time_string[2] + ">" +
            "<sprite=" + time_string[3] + ">";
        }
        else
        {
            text_display.GetComponent<TextMeshProUGUI>().text =
            "<sprite=" + time_string[0] + ">" +
            "<sprite=" + time_string[1] + ">" +
            "<sprite=" + time_string[2] + ">" +
            "<sprite=" + time_string[3] + ">";
        }
    }

    public void TimeStartUpdate(bool player_time_flg)
    {
        time_flg = player_time_flg;
    }
}
