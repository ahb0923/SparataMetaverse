using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected int maxPoint = 0;
    protected int currPoint = 0;
    protected bool isGameActive = false;

    // 외부에서 시작 호출
    public virtual void StartMinigame()
    {
        currPoint = 0;
        isGameActive = true;
        OnGameStart();
    }

    public virtual void EndMinigame()
    {
        isGameActive = false;
        OnGameEnd();
    }


    protected void AddPoint(int amount)
    {
        currPoint += amount;
        if (currPoint >= maxPoint)
        {
            currPoint = maxPoint;
            OnGameSuccess();
            EndMinigame();
        }
    }

    protected virtual void OnGameStart() { }
    protected virtual void OnGameEnd() { }
    protected virtual void OnGameSuccess() { }

    // 게임 루프
    protected virtual void Update()
    {
        if (!isGameActive) return;

        // 개별 미니게임에서 구현할 내용
        OnGameUpdate();
    }

    protected abstract void OnGameUpdate();
}
