using UnityEngine;
using Zenject;

namespace Game
{
    public class ZombieTouch : MonoBehaviour
    {
        private Collider _collider;

        private PlayerController _playerController;

        [Inject]
        private void Construct(PlayerController playerController)
        {
            _playerController = playerController;
        }

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                _playerController.PlayerDead();
            }
        }
    }
}
