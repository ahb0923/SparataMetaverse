using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public enum PLAYER_TYPE { MAIN, FLAPPY }

    [SerializeField]
    private GameObject player;
    public GameObject GetPlayer => player;

    [SerializeField]
    public PLAYER_TYPE P_type { get; set; } = PLAYER_TYPE.MAIN;

    private GameObject currentMinigame;

    [SerializeField]
    private Transform flappySpawn;
    [SerializeField]
    private GameObject flappyMinigamePrefab;
    
    private int flappyPoint = 0;
    public int FlappyPoint => flappyPoint;

    //추후 ui매니저로 이동
    [SerializeField]
    private TextMeshPro minigameText;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObj = new GameObject("GameManager");
                    instance = singletonObj.AddComponent<GameManager>();
                    DontDestroyOnLoad(singletonObj);
                }
            }
            return instance;
        }
    }

    public void ChangePlayerType(PLAYER_TYPE type)
    {
        P_type = type;
    }

    public void OpenMinigame()
    {
        if (currentMinigame == null)
        {
            var playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                Debug.Log("메인캐릭터 이동 제한!!!");
                playerController.enabled = false;
            }
            ChangePlayerType(PLAYER_TYPE.FLAPPY);

            currentMinigame = Instantiate(flappyMinigamePrefab, flappySpawn.position, Quaternion.identity);
        }  
    }
    public void EndMinigame()
    {
        if (currentMinigame != null)
        {
            Destroy(currentMinigame);
            currentMinigame = null;
        }

        // Player 이동 다시 허용
        var playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            Debug.Log("메인캐릭터 이동 재허용!");
            playerController.enabled = true;
        }

        // 플레이어 타입 되돌리기
        ChangePlayerType(PLAYER_TYPE.MAIN);
    }

    public void RetryMinigame()
    {
        if (currentMinigame != null)
        {
            Destroy(currentMinigame);
            currentMinigame = null;
        }
        currentMinigame = Instantiate(flappyMinigamePrefab, flappySpawn.position, Quaternion.identity);
    }

    public void SetPoint(int maxPoint)
    {
        if(flappyPoint < maxPoint)
            flappyPoint = maxPoint;
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);


        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        
    }
}
