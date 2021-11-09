using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace ClickMechanic
{
    public class ClickOnCookie : MonoBehaviour
    {
        [SerializeField] private AudioSource _clickSound;
        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private GameObject _endgameMenu;
        [SerializeField] private Transform _clickParticle;
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
                        if(hit.collider.gameObject.tag == "Cookie")
                        {
                            StartCoroutine(StartParticle(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y));
                            _playerCountCookies++;
                            _clickSound.Play();
                            MainMechanic.MainGameplay.DestroyCookie(hit.collider.gameObject);
                        }
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

        private IEnumerator StartParticle(float coordinateX, float coordinateY)
        {
            Vector3 vec = new Vector3(coordinateX, coordinateY, 1);
            Transform newParticle = Instantiate(_clickParticle, vec, Quaternion.identity);

            yield return new WaitForSeconds(1f);

            Destroy(newParticle.gameObject);
        }

        public static void EndGameFlagSwitch()
        {
            _endgame = true;
        }
    }
}

