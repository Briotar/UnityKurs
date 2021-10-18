using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMechanic
{
    public class MainGameplay : MonoBehaviour
    {
        [SerializeField] private Transform _cookie;
        [SerializeField] private int _maxCookies = 1;
        private System.Random _rand;
        private int _maxCoordinateY = 4;
        private int _minCoordinateY = -4;
        private int _maxCoordinateX = 9;
        private int _minCoordinateX = -9;
        private static int _currentCountCookies = 0;


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
        }

        public static void DestroyCookie(GameObject cookieForDestroy)
        {
            _currentCountCookies--;
            Destroy(cookieForDestroy);
        }
    }
}

