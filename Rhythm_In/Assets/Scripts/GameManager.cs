using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    public GameObject playerObj;
    public GameObject Maps;
    

    public void CreateMap()
    {
        if (playerObj.transform.position.x > 10)
        {
            Vector3 point = new Vector3(playerObj.transform.position.x, 0f, 0f);
            Instantiate(Maps,point,Quaternion.identity);
        }
    }
}
