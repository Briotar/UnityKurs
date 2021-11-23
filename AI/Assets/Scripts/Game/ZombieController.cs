using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Game
{
    public class ZombieController : MonoBehaviour
    {
        private NavMeshPath _path;
        private NavMeshAgent _agent;
        private ZombieComponent _zombie;
        private PlayerController _playerController;

        public bool IsPlayerDetected = false;
        public Collider Player;

        [Inject]
        private void Construct(PlayerController playerController)
        {
            _playerController = playerController;
        }

        private void Awake()
        {
            _path = new NavMeshPath();
            _agent = GetComponentInParent<NavMeshAgent>();
            _zombie = gameObject.GetComponentInParent<ZombieComponent>();
        }

        private void Update()
        {
            if (IsPlayerDetected && _zombie.IsWalking)
            {
                if(_agent.enabled)
                {
                    for (int i = 0; i < _path.corners.Length - 1; i++)
                        Debug.DrawLine(_path.corners[i], _path.corners[i + 1], Color.red);

                    _agent.path = _path;
                }
            }

            if(!_zombie.IsWalking || _playerController.Hitpoints == 0)
            {
                _agent.enabled = false;
            }
        }

        private void OnTriggerStay(Collider enterOnCollider)
        {
            if(enterOnCollider.tag == "Player")
            {
                IsPlayerDetected = true;
                NavMesh.CalculatePath(transform.position, Player.gameObject.transform.position, NavMesh.AllAreas, _path);
            }
        }

        private void OnTriggerExit(Collider exitOnCollider)
        {
            if (exitOnCollider.tag == "Player")
            {
                IsPlayerDetected = false;
            }
        }
    }
}
