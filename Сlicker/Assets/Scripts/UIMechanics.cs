using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class UIMechanics : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameObject _blockClickPanel;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _autorMenu;
    [SerializeField] private TMP_Text _scoreLabel;
    [SerializeField] private GameObject _playmodeMenu;
    [SerializeField] private GameObject _endgameMenu;
    [SerializeField] private Transform _physicFloor;
    [SerializeField] private Transform _physicWallLeft;
    [SerializeField] private Transform _physicWallRight;

    void Start()
    {
        Time.timeScale = 0;

        _mainMenu.QuitEvent += () =>
        {
            //Application.Quit();
            EditorApplication.ExitPlaymode();
        };

        _mainMenu.StartEvent += () =>
        {
            Time.timeScale = 1;
            _playmodeMenu.SetActive(false);
            _blockClickPanel.SetActive(false);
            _scoreLabel.gameObject.SetActive(true);
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

        _mainMenu.BackToMenuEvent += () =>
        {
            _autorMenu.SetActive(false);
            _settingsMenu.SetActive(false);
            _playmodeMenu.SetActive(false);
            _endgameMenu.SetActive(false);
            _mainMenu.gameObject.SetActive(true);
        };

        _mainMenu.CountCookies5Event += () =>
        {
            MainMechanic.MainGameplay.SetMaxCountCookies(5);
        };

        _mainMenu.CountCookies10Event += () =>
        {
            MainMechanic.MainGameplay.SetMaxCountCookies(10);
        };

        _mainMenu.CountCookies15Event += () =>
        {
            MainMechanic.MainGameplay.SetMaxCountCookies(15);
        };

        _mainMenu.ChoosePlaymodeEvent += () =>
        {
            _mainMenu.gameObject.SetActive(false);
            _playmodeMenu.SetActive(true);
        };

        _mainMenu.TimeModeEvent += () =>
        {
            Time.timeScale = 1;
            _playmodeMenu.SetActive(false);
            _blockClickPanel.SetActive(false);
            MainMechanic.MainGameplay.StartTimerStatic();
        };

        _mainMenu.PhysicsModeEvent += () =>
        {
            Time.timeScale = 1;
            _playmodeMenu.SetActive(false);
            _blockClickPanel.SetActive(false);
            MainMechanic.MainGameplay.StartPhysicsMode();
            _physicFloor.gameObject.SetActive(true);
            _scoreLabel.gameObject.SetActive(true);
            _physicWallLeft.gameObject.SetActive(true);
            _physicWallRight.gameObject.SetActive(true);
        };
    }
}
