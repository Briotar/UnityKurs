using UnityEngine;
using UnityEngine.EventSystems;
using Core;
using Zenject;

public class ClickOnCookieNew : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;

    private CookieManager _cookieManager;
    private SoundManager _soundManager;
    private HUDManager _hudManager;

    private Camera _cam;

    [Inject]
    private void Construct(CookieManager cookieManager, SoundManager soundManager, HUDManager hudManager)
    {
        _cookieManager = cookieManager;
        _soundManager = soundManager;
        _hudManager = hudManager;
    }

    private void Start()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButton(0))
            {
                Ray mouseRay = _cam.ScreenPointToRay(Input.mousePosition);
                Vector2 mousePos = mouseRay.GetPoint(1f);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit)
                {
                    if (hit.collider.gameObject.tag == "Cookie")
                    {
                        _hudManager.IncreaseScore();
                        DestroyCookie(hit.collider.gameObject);

                        var soundObject = _soundManager.SpawnSoundObject();
                        soundObject.Play(_clickSound);
                    }
                }
            }
        }
    }

    private void DestroyCookie(GameObject cookieForDestroy)
    {
        Destroy(cookieForDestroy);
        _cookieManager.DecreaseCountCookie();
    }
}
