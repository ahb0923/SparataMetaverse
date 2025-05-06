using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWindowController : MonoBehaviour
{
    [SerializeField]
    GameObject window;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        window?.gameObject.SetActive(false);
    }

    public void OnButtonClose()
    {
        window.gameObject.SetActive(false);
        gameManager.EndMinigame();
    }
}
