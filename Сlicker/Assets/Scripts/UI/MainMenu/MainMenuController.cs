using System;
using UnityEngine;

namespace UI
{
    public class MainMenuController : MonoBehaviour
    {
        public event Action QuitEvent;
        public event Action SettingsEvent;
        public event Action AutorEvent;
        public event Action ChoosePlaymodeEvent;

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

        public void ChoosePlaymodeEventJob()
        {
            ChoosePlaymodeEvent?.Invoke();
        }
    }
}
