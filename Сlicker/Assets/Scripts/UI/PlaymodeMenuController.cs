using System;
using UnityEngine;

namespace UI
{
    public class PlaymodeMenuController : MonoBehaviour
    {
        public event Action BackToMenuEvent;
        public event Action StartEvent;
        public event Action TimeModeEvent;
        public event Action PhysicsModeEvent;

        public void OnGameStart()
        {
            StartEvent?.Invoke();
        }
        public void StartTimeMode()
        {
            TimeModeEvent?.Invoke();
        }

        public void StartPhysicsMode()
        {
            PhysicsModeEvent?.Invoke();
        }

        public void BackToMenuJob()
        {
            BackToMenuEvent?.Invoke();
        }
    }
}
