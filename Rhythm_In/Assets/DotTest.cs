using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(3f,1f).SetDelay(1f).SetEase(Ease.InCirc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
