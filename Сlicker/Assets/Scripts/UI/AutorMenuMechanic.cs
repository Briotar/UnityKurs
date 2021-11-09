using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class AutorMenuMechanic : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;

        private AutorMenuController _autorMenu;

        void Start()
        {
            _autorMenu = GetComponent<AutorMenuController>();

            _autorMenu.BackToMenuEvent += () =>
            {
                _autorMenu.gameObject.SetActive(false);
                _mainMenu.SetActive(true);
            };
        }
    }
}

