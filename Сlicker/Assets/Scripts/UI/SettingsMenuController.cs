using System;
using UnityEngine;

namespace UI
{
    public class SettingsMenuController : MonoBehaviour
    {
        public event Action BackToMenuEvent;
        public event Action CountCookies5Event;
        public event Action CountCookies10Event;
        public event Action CountCookies15Event;

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
    }
}
