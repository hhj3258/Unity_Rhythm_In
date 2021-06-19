using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove_Event : MonoBehaviour
{
    private Material backGround;
    [SerializeField] private float moveSpeed;
    public InputManager im;
    public PlayerMove_Event pm;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        backGround = GetComponent<Renderer>().material;
        moveSpeed /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 10)
            bgMove();
    }
    void bgMove()
    {
        if (im.right)
        {
            if (pm.getisMoving)
            {
                Vector2 newOffset = backGround.mainTextureOffset;
                newOffset.Set(newOffset.x + (moveSpeed * Time.deltaTime), 0);
                backGround.mainTextureOffset = newOffset;
            }
        }

        else if (im.left)
        {
            if (pm.getisMoving)
            {
                Vector2 newOffset = backGround.mainTextureOffset;
                newOffset.Set(newOffset.x - (moveSpeed * Time.deltaTime), 0);
                backGround.mainTextureOffset = newOffset;
            }

        }
    }
}
