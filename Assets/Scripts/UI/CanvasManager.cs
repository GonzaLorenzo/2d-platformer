using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour, IObserver
{
    List<IObserver> _allObservers = new List<IObserver>();

    void PlayerLost()
    {
        var screenLose = Instantiate(Resources.Load<ScreenLose>("LoseCanvas"));
        ScreenManager.Instance.Push(screenLose);
    }

    void PlayerWon()
    {
        //AudioManager.instance.Play("RUIDO DE VICTORIA");

        var screenWin = Instantiate(Resources.Load<ScreenWin>("WinCanvas"));
        ScreenManager.Instance.Push(screenWin);
    }

    public void Notify(string action)
    {
        if(action == "PlayerLost")
        {
            PlayerLost();
        }
        else if (action == "PlayerWon")
        {
            PlayerWon();
        }

    }
}
