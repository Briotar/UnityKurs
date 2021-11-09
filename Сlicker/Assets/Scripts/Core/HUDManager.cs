using UnityEngine;
using TMPro;

namespace Core
{
    public class HUDManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _timeLabel;
        [SerializeField] private TMP_Text _endgameScore;

        private int _currentCountCookies = 0;

        public void SetScoreZero()
        {
            _currentCountCookies = 0;
            string labelText = "Score: " + _currentCountCookies;
            _scoreLabel.text = labelText;
        }

        public void IncreaseScore()
        {
            _currentCountCookies++;
            string labelText = "Score: " + _currentCountCookies;
            _scoreLabel.text = labelText;
        }

        public void UpdateTimer(int leftTime)
        {
            string textLabel = "Left time: " + leftTime.ToString();
            _timeLabel.text = textLabel;
        }

        public void ShowEndgameScore()
        {
            string labelText = "Your Score: " + _currentCountCookies;
            _endgameScore.text = labelText;
            SetScoreZero();
        }
    }
}
