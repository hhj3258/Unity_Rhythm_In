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
    int bpm=0;
    float curTime = 0;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
        bpm = gm.Bpm1;
    }


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
        
        if (playerObj.transform.position.x / 14f >= createdMapCnt)
        {
            createdMapCnt++;
            
            //�� ���� ����Ʈ�� ���� �÷��̾��� ������.X +5 �� �� 
            Vector3 point = new Vector3(playerObj.transform.position.x + 5f, 0f, 0f);
            //Ÿ�ϸ��� Grid ������Ʈ�� �ڽ����� ����
            Instantiate(Maps, point, Quaternion.identity).transform.parent = grid.transform;
        }
    }

    //�� �ڵ� ����
    private void CreateEnemy()
    {
        curTime += Time.deltaTime;

        //�� ���� ����: �÷��̾� x��ǥ+20f, 2.5f
        enemyAppear = new Vector2(player.transform.position.x + 20f, 2.5f);

        if (curTime >= 60f / bpm)    //bpm=120�̶��, curTime�� 0.5�ʸ��� ����
        {
            GameObject curEnemy = Instantiate(enemy, enemyAppear, Quaternion.identity);
            curTime -= 60f / bpm;
        }
    }
}
