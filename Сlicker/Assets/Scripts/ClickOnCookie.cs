using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCookie : MonoBehaviour
{
    [SerializeField] AudioSource _clickSound;
    private int _playerCountCookies = 0;
    private Camera _cam;

    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray mouseRay = _cam.ScreenPointToRay(Input.mousePosition);
            Vector2 mousePos = mouseRay.GetPoint(1f);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if(hit)
            {
                _playerCountCookies++;
                Debug.Log(_playerCountCookies);
                _clickSound.Play();
                MainMechanic.MainGameplay.DestroyCookie(hit.collider.gameObject);
            }
        }
    }
}
