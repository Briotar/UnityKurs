using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    private Transform _cookieSize;
    private float ScaleX = 1;
    private float ScaleY = 1;

    void Start()
    {
        _cookieSize = GetComponent<Transform>();
        StartCoroutine(ResizeJob());
    }

    IEnumerator ResizeJob()
    {
        for (int i = 0; i < 100; i++)
        {
            ScaleX = ScaleX * 1.004f;
            ScaleY = ScaleY * 1.004f;

            Vector3 vec = new Vector3(ScaleX, ScaleY, 1f);
            _cookieSize.localScale = vec;

            yield return new WaitForSeconds(0.1f);
        }

        MainMechanic.MainGameplay.DestroyCookie(_cookieSize.gameObject);
    }
}
