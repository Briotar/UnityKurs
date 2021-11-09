using System.Collections;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private AudioClip _mainTheme;
        [SerializeField] private GameObject _endgameMenu;

        private SoundManager _soundManager;
        private HUDManager _hudManager;

        private SoundObject _soundObject;

        public bool IsTimerMode = false;

        [Inject]
        private void Construct(CookieManager spawnCookie, SoundManager soundManager, HUDManager hudManager)
        {
            _soundManager = soundManager;
            _hudManager = hudManager;
        }

        void Start()
        {
            _soundObject = _soundManager.SpawnSoundObject();
            _soundObject.Play(_mainTheme, true);
        }

        private IEnumerator StartTimer()
        {
            IsTimerMode = true;
            int leftTime = 3;
            _hudManager.UpdateTimer(leftTime);

            while (leftTime > 0)
            {
                leftTime--;

                yield return new WaitForSeconds(1f);

                 _hudManager.UpdateTimer(leftTime);
            }

            Time.timeScale = 0;
            _endgameMenu.SetActive(true);
            IsTimerMode = false;
        }

        public void StartTimerJob()
        {
            StartCoroutine(StartTimer());
        }
    }
}
