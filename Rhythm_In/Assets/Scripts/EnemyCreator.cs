using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] private GameObject[] enemys;

    private Vector2 enemyAppear;
    public float enemyOffset;

    private float curTime;
    private int tempTime;

    private float createdEnemyCnt = 2;

    [SerializeField] private AudioSource bgm;

    private void Start()
    {
        curTime = 0;
        tempTime = 0;
        gm = GameManager.Instance;
        Debug.Log(bgm.clip.length - 3);
    }
    private void Update()
    {
        curTime += Time.deltaTime;  //���� �ð�
        Debug.Log("cur: " + curTime);
        if ((int)curTime > tempTime && bgm.clip.length - 3 > curTime)
        {
            int index = CreateEnemy();

            if (index == 1)
            {
                tempTime = (int)curTime + 1;
            }
            else
            {
                tempTime = (int)curTime;
            }

        }


    }


    private int CreateEnemy()
    {
        int rand = Random.Range(0, 3);

        enemyAppear = new Vector2(PlayerMove.MoveSpeed * ((int)curTime + createdEnemyCnt) + enemys[rand].transform.position.x + enemyOffset,
            enemys[rand].transform.position.y);

        Instantiate(enemys[rand], enemyAppear, Quaternion.identity);

        return rand;
    }


}
