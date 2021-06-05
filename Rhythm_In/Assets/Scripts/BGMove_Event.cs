using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove_Event : MonoBehaviour
{
    [SerializeField] private GameObject backGround;
    private InputManager im;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (im.right)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        else if (im.left)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

    }
}
