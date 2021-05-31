using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤 사용을 위한 게임매니저 static 변수 선언
    public static GameManager _instance;

    private Image healthBar;    //healthBar 이미지가 현재 없음.
    private float maxHealth = 100f;
    // 이미 게임매니저가 static으로 선언된 클래스이기 때문에 health변수는 static으로 선언할 필요 없음.
    // health는 플레이어의 체력이고, 이는 곧 게임에 하나만 존재하면 되므로 GameManager가 관리하도록 함
    private float health;

    [SerializeField] private int bpm1 = 0;


    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("싱글톤 오브젝트가 null임");
            }
            return _instance;
        }
    }

    //GameManager 싱글톤 적용
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {

        //수정바람-현준
        //healthBar.fillAmount = health / maxHealth;
    }


    //get set
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public int Bpm1
    {
        get { return bpm1; }
    }
}