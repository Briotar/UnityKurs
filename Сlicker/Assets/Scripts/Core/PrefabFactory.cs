using UnityEngine;
using Zenject;

namespace Core
{
    public class PrefabFactory
    {
        private DiContainer _container;

        [Inject]
        public PrefabFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return _container.InstantiatePrefab(prefab, position, rotation, parent);
        }
    }
}
