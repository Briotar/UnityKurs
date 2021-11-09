using System;
using UnityEngine;
using Zenject;
using Core;

namespace UI
{
    public class PlaymodeMenuMechanic : MonoBehaviour
    {
        [SerializeField] private GameObject _blockClickPanel;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private Transform _physicFloor;
        [SerializeField] private Transform _physicWallLeft;
        [SerializeField] private Transform _physicWallRight;
        [SerializeField] private GameObject _scoreLabel;
        [SerializeField] private GameObject _timeLabel;

        private PlaymodeMenuController _playmodeMenu;

        private GameManager _gameManager;
        private CookieManager _cookieManager;

        [Inject]
        private void Construct(GameManager gameManager, CookieManager cookieManager)
        {
            _gameManager = gameManager;
            _cookieManager = cookieManager;
        }

        void Start()
        {
            _playmodeMenu = GetComponent<PlaymodeMenuController>();

            _playmodeMenu.StartEvent += () =>
            {
                Time.timeScale = 1;
                _playmodeMenu.gameObject.SetActive(false);
                _blockClickPanel.SetActive(false);
                _scoreLabel.SetActive(true);
            };

            _playmodeMenu.TimeModeEvent += () =>
            {
                Time.timeScale = 1;
                _playmodeMenu.gameObject.SetActive(false);
                _blockClickPanel.SetActive(false);
                _timeLabel.SetActive(true);
                _gameManager.StartTimerJob();
            };

            _playmodeMenu.PhysicsModeEvent += () =>
            {
                Time.timeScale = 1;
                _playmodeMenu.gameObject.SetActive(false);
                _blockClickPanel.SetActive(false);
                _physicFloor.gameObject.SetActive(true);
                _physicWallLeft.gameObject.SetActive(true);
                _physicWallRight.gameObject.SetActive(true);
                _scoreLabel.SetActive(true);
                _cookieManager.SwitchPhysicsMode();
            };

            _playmodeMenu.BackToMenuEvent += () =>
            {
                _playmodeMenu.gameObject.SetActive(false);
                _mainMenu.SetActive(true);
            };
        }
    }
}
