using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backMusic;

    GameManager gm;


    void Start()
    {
        gm = GameManager.Instance;
        backMusic.PlayDelayed( (60f / gm.Bpm1) / 2f );  //게임 시작 시 리듬바 타이밍을 맞추기 위해서 딜레이
    }

}
