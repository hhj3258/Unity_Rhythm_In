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
        backMusic.PlayDelayed( (60f / gm.Bpm1) / 2f );  //���� ���� �� ����� Ÿ�̹��� ���߱� ���ؼ� ������
    }

}
