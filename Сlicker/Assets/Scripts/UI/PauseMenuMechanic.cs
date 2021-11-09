using UnityEngine;
using TMPro;

namespace UI
{
    public class PauseMenuMechanic : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _blockClickPanel;
        [SerializeField] private GameObject _scoreLabel;

        private PauseMenuController _pauseMenuController;

        private void OnEnable()
        {
            _blockClickPanel.SetActive(true);
            _scoreLabel.SetActive(false);
        }

        private void Start()
        {
            _pauseMenuController = GetComponent<PauseMenuController>();

            _pauseMenuController.BackInGameEvent += () =>
            {
                _pauseMenuController.gameObject.SetActive(false);
                _blockClickPanel.SetActive(false);
                _scoreLabel.SetActive(true);
                Time.timeScale = 1;
            };

            _pauseMenuController.BackToMenuEvent += () =>
            {
                _pauseMenuController.gameObject.SetActive(false);
                _mainMenu.SetActive(true);
            };
        }
    }
}
