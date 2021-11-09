using UnityEngine;
using System;

namespace UI
{
    public class EndgameController : MonoBehaviour
    {
        public event Action BackToMenuEvent;

        public void BackToMenuJob()
        {
            BackToMenuEvent?.Invoke();
        }
    }
}
