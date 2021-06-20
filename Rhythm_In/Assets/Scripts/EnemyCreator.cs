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
        
    }
    private void Update()
    {
        curTime += Time.deltaTime;  //���� �ð�
        //Debug.Log("cur: " + curTime);
        if ((int)curTime > tempTime)
        {
            int index = CreateEnemy();
            
            if (index == 1)
            {
                tempTime = (int)curTime + 1;
                //Debug.Log("������ ����");
            }
            else
            {
                tempTime = (int)curTime;
                //Debug.Log("���ʹ� ����");
            }

        }


    }


    private int CreateEnemy()
    {
        int rand = Random.Range(0, 3);

        enemyAppear = new Vector3(PlayerMove.MoveSpeed * ((int)curTime + createdEnemyCnt) + enemys[rand].transform.position.x + enemyOffset,
            enemys[rand].transform.position.y,20f);
        //Debug.Log("���ʹ� X��ǥ: "+enemyAppear);
        Instantiate(enemys[rand], enemyAppear, Quaternion.identity);

        return rand;
    }


}
