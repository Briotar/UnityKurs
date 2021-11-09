using UnityEngine;
using TMPro;
using Core;
using Zenject;

namespace UI
{
    public class EndgameMechanic : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private TMP_Text _timeLabel;
        [SerializeField] private GameObject _blockClickPanel;

        private EndgameController _endgameController;

        private HUDManager _hudManager;

        [Inject]
        private void Construct(HUDManager hudManager)
        {
            _hudManager = hudManager;
        }

        private void OnEnable()
        {
            _timeLabel.gameObject.SetActive(false);
            _blockClickPanel.SetActive(true);
            _hudManager.ShowEndgameScore();
        }

        private void Start()
        {
            _endgameController = GetComponent<EndgameController>();

            _endgameController.BackToMenuEvent += () =>
            {
                _endgameController.gameObject.SetActive(false);
                _mainMenu.SetActive(true);
            };
        }
    }
}
