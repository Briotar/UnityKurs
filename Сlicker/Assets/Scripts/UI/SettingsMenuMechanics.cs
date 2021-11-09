using System;
using UnityEngine;
using Zenject;
using Core;

namespace UI
{
    public class SettingsMenuMechanics : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;

        private SettingsMenuController _settingsMenu;

        private CookieManager _cookieManager;

        [Inject]
        private void Construct(CookieManager cookieManager)
        {
            _cookieManager = cookieManager;
        }

        private void Start()
        {
            _settingsMenu = GetComponent<SettingsMenuController>();

            _settingsMenu.BackToMenuEvent += () =>
            {
                    _settingsMenu.gameObject.SetActive(false);
                    _mainMenu.SetActive(true);
            };

            _settingsMenu.CountCookies5Event += () =>
            {
                _cookieManager.SetMaxCountCookies(5);
            };

            _settingsMenu.CountCookies10Event += () =>
            {
                _cookieManager.SetMaxCountCookies(10);
            };

            _settingsMenu.CountCookies15Event += () =>
            {
                _cookieManager.SetMaxCountCookies(15);
            };
        }
    }
}


