using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;
using Game;
using UnityEngine.SceneManagement;

public class FirstTest
{
    [UnityTest]
    public IEnumerator LoseGame()
    {
        GameObject playerGameObject =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));

        var player = playerGameObject.gameObject.GetComponent<PlayerController>();

        var playerRigidbody = playerGameObject.gameObject.GetComponent<Rigidbody>();

        player.Hitpoints = 0;

        yield return null;

        Assert.AreEqual(playerRigidbody.velocity.magnitude, 0f);
    }

    [UnityTest]
    public IEnumerator StartGame()
    {
        GameObject playerGameObject =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));

        var player = playerGameObject.gameObject.GetComponent<PlayerController>();

        yield return null;

        Assert.Greater(player.Hitpoints, 0f);
    }

    [UnityTest]
    public IEnumerator PlayerShoot()
    {
        GameObject playerGameObject =
           MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));

        var player = playerGameObject.gameObject.GetComponent<PlayerController>();

        yield return null;

        Assert.Greater(player.FireTime, 0f);
    }
}
