using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCubeController : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;  //�v���C���[���i�[�p
    private Vector3 offset; // ���΋����擾�p
    private float cube_x;

    void Start()
    {
        this.player = GameObject.Find("Player");

        // ���C���J�����i�������g�j��Player�Ƃ̑��΋��������߂�
        offset = transform.position - player.transform.position;
        cube_x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //�@�V�����g�����X�t�H�[���̒l��������
        transform.position = new Vector3(cube_x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
    }
}
