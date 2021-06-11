using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector2 record;
    void Start()
    {
        record = transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("��ġ : " + transform.position);
            //Debug.Log("���� : " + new Vector2(transform.position.x - record.x, 0));
            record = transform.position;
        }
    }
}
