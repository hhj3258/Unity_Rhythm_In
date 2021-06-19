using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowText : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject sign;
    private float Distance;
    [SerializeField] private float showDistance;
    TextMeshPro txt;
    [SerializeField] public InputManager im;
    private static bool isInterect;
    public int number;

    [SerializeField] private static int textNum;
    public static bool IsInterect() { return isInterect; }
    public static int TextNum() { return textNum; }

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshPro>();
        txt.color = new Color(1, 1, 1, 0);
        isInterect = false;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector2.Distance(new Vector2(player.transform.position.x, 0), new Vector2(sign.transform.position.x, 0));
        if (Distance <= showDistance && txt.color.a < 1)
        {
            txt.color = new Color(1, 1, 1, txt.color.a + 2 * Time.deltaTime);
            if (im.interact)
            {
                textNum = number;
                isInterect = true;
            }
        }
        else if (Distance > showDistance && txt.color.a > 0)
        {
            isInterect = false;
            txt.color = new Color(1, 1, 1, txt.color.a - 2 * Time.deltaTime);
        }
    }
}
