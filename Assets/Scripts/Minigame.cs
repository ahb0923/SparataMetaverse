using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    protected int maxPoint = 0;
    protected int currPoint = 0;
    protected bool isGameActive = false;

    // �ܺο��� ���� ȣ��
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

    // ���� ����
    protected virtual void Update()
    {
        if (!isGameActive) return;

        // ���� �̴ϰ��ӿ��� ������ ����
        OnGameUpdate();
    }

    protected abstract void OnGameUpdate();
}
