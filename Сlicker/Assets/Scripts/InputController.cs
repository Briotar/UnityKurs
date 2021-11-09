using UnityEngine;
using Core;
using Zenject;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    void Update()
    {
        if(!_gameManager.IsTimerMode)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                _pauseMenu.SetActive(true);
            }
        }
    }
}
