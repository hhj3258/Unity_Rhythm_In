using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float yPos;
    public float xPos;



    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Event01")
        {
            if (player.transform.position.x >= 10f && player.transform.position.x<=40f)
                Move_Event();
        }
        else
            Move();
    }
    void Move()
    {
        transform.position = new Vector3(player.transform.position.x + xPos, player.transform.position.y * 0.2f + yPos, -10f);
    }
    void Move_Event()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }

    public void CameraAttackMove()
    {
        DOTween.To(() => xPos, x => xPos = x, 7, 0.15f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
        transform.GetComponent<Camera>().DOOrthoSize(7.5f, 0.15f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
    }

}