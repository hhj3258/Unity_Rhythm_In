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
    }
}
