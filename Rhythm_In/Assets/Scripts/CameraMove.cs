using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject playerPosition;
    private Transform playerTransition;
    public float yPos;

    void Start()
    {
        playerTransition = playerPosition.transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransition.position.x, playerTransition.position.y * 0.2f + yPos, transform.position.z);
    }
}