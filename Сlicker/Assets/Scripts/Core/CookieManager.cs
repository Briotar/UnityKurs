using UnityEngine;
using System;
using Zenject;

namespace Core
{
    public class CookieManager : MonoBehaviour
    {
        [SerializeField] private Transform _cookie;
        [SerializeField] private Transform _physicsCookie;

        private PrefabFactory _prefabFactory;

        private System.Random _rand;
        private int _maxCoordinateY = 4;
        private int _minCoordinateY = -4;
        private int _maxCoordinateX = 9;
        private int _minCoordinateX = -9;

        private static int _currentCountCookies = 0;
        private static int _maxCookies = 3;

        private bool isPhysicsMode = false;

        [Inject]
        private void Construct(PrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
        }

        private void Start()
        {
            _rand = new System.Random();
        }

        private void Update()
        {
            if (Time.timeScale != 0)
            {
                if (_currentCountCookies < _maxCookies)
                {
                    if(isPhysicsMode)
                    {
                        SpawnCookieJob(isPhysicsMode);
                        _currentCountCookies++;
                    }
                    else
                    {
                        SpawnCookieJob(isPhysicsMode);
                        _currentCountCookies++;
                    }
                }
            }
        }

        public void SpawnCookieJob(bool isPhysicalCookie = false)
        {
            Vector3 vec = new Vector3(_rand.Next(_minCoordinateX, _maxCoordinateX), _rand.Next(_minCoordinateY, _maxCoordinateY), 1);

            if (isPhysicalCookie)
            {
                _prefabFactory.Spawn(_physicsCookie.gameObject, vec, Quaternion.identity);
            }
            else
            {
                _prefabFactory.Spawn(_cookie.gameObject, vec, Quaternion.identity);
            }
        }

        public void DecreaseCountCookie()
        {
            _currentCountCookies--;
        }

        public void SetMaxCountCookies(int countCookies)
        {
            _maxCookies = countCookies;
        }

        public void SwitchPhysicsMode()
        {
            isPhysicsMode = true;
        }
    }
}
