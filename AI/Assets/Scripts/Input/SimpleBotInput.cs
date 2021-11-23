using System.Linq;
using Game;
using UnityEngine;
using UnityEngine.AI;

public class SimpleBotInput : PlayerInput
{
    [SerializeField] private ZombieMap _zombieMap;
    [SerializeField] private Transform _player;
    [SerializeField] private float _fireDistance;

    private NavMeshPath _path;

    public Vector3 _currentTarget;

    public override (Vector3 moveDirection, Quaternion viewDirection, bool shoot) CurrentInput()
    {
        var alivePositions = _zombieMap.AlivePositions();
        if (alivePositions.Count == 0)
        {
            return (Vector3.zero, Quaternion.identity, false);
        }

        _currentTarget = alivePositions.First();


        for (int i = 0; i < alivePositions.Count; i++)
        {
            var zombiePosition = alivePositions[i];

            if (zombiePosition.sqrMagnitude < _currentTarget.sqrMagnitude)
            {
                _currentTarget = zombiePosition;
            }
        }

        var direction = (_currentTarget - _player.position);

        return (direction, Quaternion.LookRotation(direction), direction.magnitude <= _fireDistance);
    }
}