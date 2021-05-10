using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPosition;
    private Transform playerTransition;
    void Start()
    {
        playerTransition = playerPosition.transform;
    }

    void LateUpdate()
    {
        // 캐릭터의 X좌표 값 따라 카메라 이동
        //카메라의 Y 값은 2로, Z값은 -0.5로 고정
        transform.position = new Vector3(playerTransition.position.x, playerTransition.position.y * 0.2f, -0.5f);
    }
}
