using System;
using UnityEngine;

namespace UI
{
    public class AutorMenuController : MonoBehaviour
    {
        public event Action BackToMenuEvent;

        public void BackToMenuJob()
        {
            BackToMenuEvent?.Invoke();
        }
    }
}
