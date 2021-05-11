using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject Maps;
    [SerializeField] private GameObject grid;
    
    //������ �� ī����
    private int createdMapCnt = 1;
    
    void Update()
    {
        CreateMaps();
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
    
}
