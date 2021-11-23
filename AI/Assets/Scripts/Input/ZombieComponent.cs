using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class ZombieComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _aliveView;

        [SerializeField] private GameObject _diedView;

        [SerializeField] private float _speed = 5f;

        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private Vector3[] _deltaPath;

        private int _currentPoint = 0;
        private Vector3 _initPosition;
       
        public bool IsWalking = true;

        public Collider Player;

        private void Awake()
        {
            _initPosition = transform.position;
        }

        private void OnEnable()
        {
            SetState(true);
        }

        public void SetState(bool alive)
        {
            _aliveView.SetActive(alive);
            _diedView.SetActive(!alive);

            if(!alive)
            {
                IsWalking = false;
            }
        }

        public bool IsAlive => _aliveView.activeInHierarchy;
    }
}