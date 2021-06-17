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
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshPro>();
        txt.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Distance : " + Distance);
        Distance = Vector2.Distance(new Vector2(player.transform.position.x, 0), new Vector2(sign.transform.position.x, 0));
        if(Distance <= showDistance && txt.color.a < 1)
        {
            txt.color = new Color(1, 1, 1, txt.color.a + 2 * Time.deltaTime);
        }
        else if (Distance > showDistance && txt.color.a > 0)
        {
            txt.color = new Color(1, 1, 1, txt.color.a - 2 * Time.deltaTime);
        }
    }
}
