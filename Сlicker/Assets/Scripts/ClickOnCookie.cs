using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace ClickMechanic
{
    public class ClickOnCookie : MonoBehaviour
    {
        [SerializeField] private AudioSource  _clickSound;
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private GameObject _endgameMenu;
        private int _playerCountCookies = 0;
        private Camera _cam;
        private static bool _endgame = false;

        void Start()
        {
            _cam = GetComponent<Camera>();
        }

        void Update()
        {
            string labelText = "Score: " + _playerCountCookies.ToString();
            _scoreLabel.text = labelText;

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if(Input.GetMouseButton(0))
                {
                    Ray mouseRay = _cam.ScreenPointToRay(Input.mousePosition);
                    Vector2 mousePos = mouseRay.GetPoint(1f);
                    RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                    if(hit)
                    {
                        _playerCountCookies++;
                        _clickSound.Play();
                        MainMechanic.MainGameplay.DestroyCookie(hit.collider.gameObject);
                    }
                }
            }

            if(_endgame)
            {
                EndGameJob();
            }
        }

        private void EndGameJob()
        {
            var endgameInfo = _endgameMenu.gameObject.GetComponentInChildren<TMP_Text>();
            endgameInfo.text = "Your Score: " + _playerCountCookies;
            _playerCountCookies = 0;
            _endgame = false;
        }

        public static void EndGameFlagSwitch()
        {
            _endgame = true;
        }
    }
}

