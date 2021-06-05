using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLogo : MonoBehaviour
{
    public GameObject Logo1;
    public GameObject Logo2;
    private int random;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                Logo1.SetActive(false);
                Logo2.SetActive(true);
                break;
            case 1:
                Logo1.SetActive(true);
                Logo2.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
