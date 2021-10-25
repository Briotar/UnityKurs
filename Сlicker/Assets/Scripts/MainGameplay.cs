using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

namespace MainMechanic
{
    public class MainGameplay : MonoBehaviour
    {
        [SerializeField] private Transform _cookie;
        [SerializeField] private TMP_Text _timeLabel;
        [SerializeField] private GameObject _blockClickPanel;
        [SerializeField] private GameObject _endgameMenu;
        private System.Random _rand;
        private int _maxCoordinateY = 4;
        private int _minCoordinateY = -4;
        private int _maxCoordinateX = 9;
        private int _minCoordinateX = -9;
        private static int _currentCountCookies = 0;
        private static int _maxCookies = 1;
        private static bool _isStart = false;


        void Start()
        {
            _rand = new System.Random();
        }

        void Update()
        {
            if(_currentCountCookies < _maxCookies)
            {
                Vector3 vec = new Vector3(_rand.Next(_minCoordinateX, _maxCoordinateX), _rand.Next(_minCoordinateY, _maxCoordinateY), 1);
                Transform newCookie = Instantiate(_cookie, vec, Quaternion.identity);
                _currentCountCookies++;
            }

            if (_isStart)
            {
                StartCoroutine(StartTimer());
                _isStart = false;
            }
        }

        public static void DestroyCookie(GameObject cookieForDestroy)
        {
            _currentCountCookies--;
            Destroy(cookieForDestroy);
        }

        public static void SetMaxCountCookies(int countCookies)
        {
            _maxCookies = countCookies;
        }

        public static void StartTimerStatic()
        {
            _isStart = true;
        }

        public IEnumerator StartTimer()
        {
            int leftTime = 15;
            _timeLabel.gameObject.SetActive(true);

            while(leftTime > 0)
            {
                leftTime--;
                string textLabel = "Left time: " + leftTime.ToString();
                _timeLabel.text = textLabel;
                yield return new WaitForSeconds(1f);
            }

            Time.timeScale = 0;
            _timeLabel.gameObject.SetActive(false);
            _blockClickPanel.gameObject.SetActive(true);
            _endgameMenu.gameObject.SetActive(true);
            ClickMechanic.ClickOnCookie.EndGameFlagSwitch();
        }
    }
}

