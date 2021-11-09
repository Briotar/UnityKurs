using System.Collections;
using UnityEngine;
using Core;
using Zenject;

public class CookieLiveTime : MonoBehaviour
{
    private Transform _cookieSize;

    private CookieManager _cookieManager;

    [Inject]
    private void Construct(CookieManager cookieManager)
    {
        _cookieManager = cookieManager;
    }

    void Start()
    {
        _cookieSize = GetComponent<Transform>();
        StartCoroutine(ResizeJob());
    }

    IEnumerator ResizeJob()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.1f);
        }

        DestroyCookie(_cookieSize.gameObject);
    }

    private void DestroyCookie(GameObject cookieForDestroy)
    {
        Destroy(cookieForDestroy);
        _cookieManager.DecreaseCountCookie();
    }
}
