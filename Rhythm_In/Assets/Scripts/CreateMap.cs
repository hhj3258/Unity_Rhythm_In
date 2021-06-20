using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject[] Maps;
    [SerializeField] private GameObject grid;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] enemys;

    GameManager gm;

    private Vector2 enemyAppear;
    float curTime = 0;

    public float enemyOffset;

    private void Start()
    {
        gm = GameManager.Instance;
        //delayTime = (60f / gm.Bpm1) / 2f;
    }


    //생성된 맵 카운터
    private int createdMapCnt = 1;

    void Update()
    {
        CreateMaps();
        //CreateEnemy();
    }

    //맵 자동생성 메소드
    private void CreateMaps()
    {

        if (player.transform.position.x / 13f >= createdMapCnt)
        {
            createdMapCnt++;

            //맵 생성 포인트를 현재 플레이어의 포지션.X +5 로 함 
            Vector3 point = new Vector3(player.transform.position.x + 38f, 0f, 0f);
            //타일맵을 Grid 오브젝트의 자식으로 생성
            Instantiate(Maps[0], point, Quaternion.identity).transform.parent = grid.transform;
            Instantiate(Maps[1], point, Quaternion.identity).transform.parent = grid.transform;
        }
    }

    int createdEnemyCnt = 1;
    int enemyIndex = 0;
    //적 자동 생성
    private void CreateEnemy()
    {
        curTime += Time.deltaTime;
        //Debug.Log((int)Time.timeSinceLevelLoad);
        if ((int)Time.timeSinceLevelLoad == 20 && enemyIndex == 0)
        {
            enemyIndex = 1;
            Invoke("BpmChangeDelay", 2);
        }
        else if ((int)Time.timeSinceLevelLoad == 31 && enemyIndex == 1)
        {
            enemyIndex = 0;
            Invoke("BpmChangeDelay", 2);
        }
        else if ((int)Time.timeSinceLevelLoad == 60 && enemyIndex == 0)
        {
            enemyIndex = 1;
            Invoke("BpmChangeDelay", 2);
            Invoke("EnemyCntResize", 2);
        }


        // X포지션 = (플레이어 이동속도 * 생성된 에너미 프리팹 수) + (플레이어 이동속도*오프셋) + (플레이어 이동속도 / 2)
        // 플레이어 이동속도(속도) * 오프셋(시간) = 거리
        // 플레이어 이동속도(속도) * 초당bpm / 2(시간) = 거리
        // enemyOffset: 에너미 위치 보정
        enemyAppear = new Vector2(enemyOffset + PlayerMove.MoveSpeed * createdEnemyCnt +
            PlayerMove.MoveSpeed * gm.offset + PlayerMove.MoveSpeed * 60f / 60f / 2f, 0f);

        if (curTime >= (60f / gm.Bpm1))    //bpm=120이라면, curTime이 0.5초마다 생성
        {
            //Debug.Log(enemyAppear);
            createdEnemyCnt += (int)(4 * 60f / gm.Bpm1);
            GameObject curEnemy = Instantiate(enemys[enemyIndex], enemyAppear, Quaternion.identity);
            curTime -= 60f / gm.Bpm1 * 4;
        }
    }

    void BpmChangeDelay()
    {
        if(gm.Bpm1 == 60)
        {
            gm.Bpm1 = 120;
            
        }
        else if(gm.Bpm1 == 120)
        {
            gm.Bpm1 = 60;
            createdEnemyCnt += 2;
        }
    }

    void EnemyCntResize()
    {
        createdEnemyCnt -= 2;
    }
}
