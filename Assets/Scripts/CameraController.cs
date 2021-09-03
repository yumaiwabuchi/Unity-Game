using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;  //プレイヤー情報格納用
    private Vector3 offset; // 相対距離取得用
    private float camera_x;

    void Start()
    {
        this.player = GameObject.Find("Player");

        // メインカメラ（自分自身）とPlayerとの相対距離を求める
        offset = transform.position - player.transform.position;
        camera_x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //　新しいトランスフォームの値を代入する
        transform.position = new Vector3(camera_x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
    }
}
