using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public event Action StartEvent;
    public event Action QuitEvent;
    public event Action SettingsEvent;
    public event Action AutorEvent;
    public event Action BackToMenuEvent;
    public event Action CountCookies5Event;
    public event Action CountCookies10Event;
    public event Action CountCookies15Event;
    public event Action ChoosePlaymodeEvent;
    public event Action TimeModeEvent;
    public event Action PhysicsModeEvent;

    public void OnGameStart()
    {
        StartEvent?.Invoke();
    }

    public void OnGameQuit()
    {
        QuitEvent?.Invoke();
    }

    public void OnGameSettings()
    {
        SettingsEvent?.Invoke();
    }

    public void OnGameAutorInfo()
    {
        AutorEvent?.Invoke();
    }

    public void BackToMenuJob()
    {
        BackToMenuEvent?.Invoke();
    }

    public void SetCountCookies5()
    {
        CountCookies5Event?.Invoke();
    }

    public void SetCountCookies10()
    {
        CountCookies10Event?.Invoke();
    }

    public void SetCountCookies15()
    {
        CountCookies15Event?.Invoke();
    }

    public void ChoosePlaymodeEventJob()
    {
        ChoosePlaymodeEvent?.Invoke();
    }

    public void StartTimeMode()
    {
        TimeModeEvent?.Invoke();
    }

    public void StartPhysicsMode()
    {
        PhysicsModeEvent?.Invoke();
    }
}
