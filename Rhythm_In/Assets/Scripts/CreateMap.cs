﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject Maps;
    [SerializeField] private GameObject grid;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] enemys;

    private Vector2 enemyAppear;
    int bpm=0;
    float curTime = 0;

    //float delayTime;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
        bpm = gm.Bpm1;
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
            Vector3 point = new Vector3(player.transform.position.x + 5f, 0f, 0f);
            //타일맵을 Grid 오브젝트의 자식으로 생성
            Instantiate(Maps, point, Quaternion.identity).transform.parent = grid.transform;
        }
    }

    //적 자동 생성
    private void CreateEnemy()
    {
        curTime += Time.deltaTime;
        
        //적 생성 지점: 플레이어 x= x좌표+20f, y= 2.5f
        enemyAppear = new Vector2(player.transform.position.x + 20f, 2.5f);

        if (curTime >= 60f / bpm)    //bpm=120이라면, curTime이 0.5초마다 생성
        {
            GameObject curEnemy = Instantiate(enemys[Random.Range(0,2)], enemyAppear, Quaternion.identity);
            curTime -= 60f / bpm;
        }
    }
}
