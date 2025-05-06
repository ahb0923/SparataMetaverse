using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWindowController : MonoBehaviour
{
    [SerializeField]
    GameObject window;

    private void Awake()
    {
        window?.gameObject.SetActive(false);
    }

    public void OnButtonClose()
    {
        window.gameObject.SetActive(false);
    }
}
