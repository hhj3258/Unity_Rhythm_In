using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField] private float ScrollSpeed = 0.5f;
    private Material thisMeterial;
    void Start()
    {
        thisMeterial = GetComponent<Renderer>().material;     
    }
    void Update()
    {
        Vector2 newOffset = thisMeterial.mainTextureOffset;
        newOffset.Set(newOffset.x + (ScrollSpeed * Time.deltaTime), 0);
        thisMeterial.mainTextureOffset = newOffset;
    }

}
