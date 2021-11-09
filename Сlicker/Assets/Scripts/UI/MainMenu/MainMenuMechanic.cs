using UnityEngine;
using UnityEditor;
using TMPro;

namespace UI
{
    public class MainMenuMechanic : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsMenu;
        [SerializeField] private GameObject _autorMenu;
        [SerializeField] private GameObject _playmodeMenu;
        
        private MainMenuController _mainMenu;

        private void Start()
        {
            Time.timeScale = 0;
            _mainMenu = GetComponent<MainMenuController>();

            _mainMenu.QuitEvent += () =>
            {
                //Application.Quit();
                EditorApplication.ExitPlaymode();
            };

            _mainMenu.ChoosePlaymodeEvent += () =>
            {
                _mainMenu.gameObject.SetActive(false);
                _playmodeMenu.SetActive(true);
            };

            _mainMenu.SettingsEvent += () =>
            {
                _mainMenu.gameObject.SetActive(false);
                _settingsMenu.SetActive(true);
            };

            _mainMenu.AutorEvent += () =>
            {
                _mainMenu.gameObject.SetActive(false);
                _autorMenu.SetActive(true);
            };
        }
    }
}
