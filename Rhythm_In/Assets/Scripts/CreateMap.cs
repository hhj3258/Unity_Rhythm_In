using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject Maps;
    [SerializeField] private GameObject grid;

    

    [SerializeField] private PlayerMove playerMove;


    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    private Vector2 enemyAppear;
    [SerializeField] private int bpm=0;
    double curTime = 0d;



    //������ �� ī����
    private int createdMapCnt = 1;
    
    void Update()
    {
        CreateMaps();
        CreateEnemy();
    }
    
    //�� �ڵ����� �޼ҵ�
    private void CreateMaps()
    {
        
        if (playerObj.transform.position.x / 10f >= createdMapCnt)
        {
            createdMapCnt++;
            
            //�� ���� ����Ʈ�� ���� �÷��̾��� ������.X +5 �� �� 
            Vector3 point = new Vector3(playerObj.transform.position.x + 5f, 0f, 0f);
            //Ÿ�ϸ��� Grid ������Ʈ�� �ڽ����� ����
            Instantiate(Maps, point, Quaternion.identity).transform.parent = grid.transform;
        }
    }


    int createdEnemyCnt=0;
    int temp = 0;
    private void CreateEnemy()
    {
        curTime += Time.deltaTime;

        enemyAppear = new Vector2(player.transform.position.x + 10, 2.5f);
        if (curTime >= 60d / bpm)    //bpm=120�̶��, curTime�� 0.5�ʸ��� ����
        {
            GameObject curEnemy = Instantiate(enemy, enemyAppear, Quaternion.identity);
            curTime -= 60d / bpm;
        }
    }
}
