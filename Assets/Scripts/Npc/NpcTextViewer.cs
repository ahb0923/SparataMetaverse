using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NpcTextViewer : MonoBehaviour
{
    private enum ActionType { Game, Talk, Yes, No, Next, Close }

    [SerializeField]
    Image menuWindow;
    [SerializeField]
    Image selectWindow;
    [SerializeField]
    Image talkWindow;
    [SerializeField]
    GameObject minigameWindow;

    [Header("Buttons")]
    [SerializeField] private Button gameButton;
    [SerializeField] private Button talkButton;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        ButtonAction(gameButton, ActionType.Game);
        ButtonAction(talkButton, ActionType.Talk);
        ButtonAction(yesButton, ActionType.Yes);
        ButtonAction(noButton, ActionType.No);
        ButtonAction(nextButton, ActionType.Next);
        ButtonAction(closeButton, ActionType.Close);

        InitWindows();
    }

    private void InitWindows()
    {
        menuWindow?.gameObject.SetActive(false);
        selectWindow?.gameObject.SetActive(false);
        talkWindow?.gameObject.SetActive(false);
    }
    private void ButtonAction(Button button, ActionType action)
    {
        if (button != null)
            button.onClick.AddListener(() => OnButtonClick(action));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameButton!=null && talkButton != null)
        {
            menuWindow.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameButton != null && talkButton != null)
        {
            menuWindow.gameObject.SetActive(false);
            selectWindow.gameObject.SetActive(false);
            talkWindow.gameObject.SetActive(false);
        }
    }
    private void OnButtonClick(ActionType action)
    {
        switch (action)
        {
            case ActionType.Game:
                menuWindow.gameObject.SetActive(false);
                selectWindow.gameObject.SetActive(true);
                break;
            case ActionType.Talk:
                menuWindow.gameObject.SetActive(false);
                talkWindow.gameObject.SetActive(true);
                break;
            case ActionType.Yes:
                selectWindow.gameObject.SetActive(false);
                minigameWindow.gameObject.SetActive(true);
                GameManager.Instance.OpenMinigame();
                break;
            case ActionType.No:
                selectWindow.gameObject.SetActive(false);
                menuWindow.gameObject.SetActive(true);
                break;
            case ActionType.Next:
                Debug.Log("준비중입니다..");
                break;
            case ActionType.Close:
                talkWindow.gameObject.SetActive(false);
                menuWindow.gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Button Action Error!");
                break;
        }
    }
    private void Update()
    {
        talkWindow.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.Instance.FlappyPoint.ToString();
    }
}
