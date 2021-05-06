using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    public GameObject playerObj;
    public GameObject Maps;
    public GameObject grid;
    private void Update()
    {
        CreateMap();
        
    }

    //생성된 맵 카운터
    private int createdMapCnt = 1;

    //맵 자동생성 메소드
    public void CreateMap()
    {
        
        if (playerObj.transform.position.x / 10f >= createdMapCnt)
        {
            createdMapCnt++;
            
            //맵 생성 포인트를 현재 플레이어의 포지션.X +5 로 함 
            Vector3 point = new Vector3(playerObj.transform.position.x + 5f, 0f, 0f);
            //타일맵을 Grid 오브젝트의 자식으로 생성
            Instantiate(Maps, point, Quaternion.identity).transform.parent = grid.transform;

        }
        
        
        
    }


}
