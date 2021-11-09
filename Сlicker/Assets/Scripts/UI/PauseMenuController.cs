using System;
using UnityEngine;

namespace UI
{
    public class PauseMenuController : MonoBehaviour
    {
        public event Action BackInGameEvent;
        public event Action BackToMenuEvent;

        public void BackInGameJob()
        {
            BackInGameEvent?.Invoke();
        }

        public void BackToMenuJob()
        {
            BackToMenuEvent?.Invoke();
        }
    }
}
