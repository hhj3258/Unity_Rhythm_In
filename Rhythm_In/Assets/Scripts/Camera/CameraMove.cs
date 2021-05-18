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
        // ĳ������ X��ǥ �� ���� ī�޶� �̵�
        //ī�޶��� Y ���� 2��, Z���� -0.5�� ����
        transform.position = new Vector3(playerTransition.position.x, playerTransition.position.y * 0.2f, -0.5f);
    }
}
