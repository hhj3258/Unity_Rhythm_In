using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform playerTrans;
    public float yPos;
    public float xPos;

    void LateUpdate()
    {
        transform.position = new Vector2(playerTrans.position.x + xPos, playerTrans.position.y * 0.2f + yPos);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.GetComponent<Camera>().DOOrthoSize(8.5f, 0.2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
        }
    }

}