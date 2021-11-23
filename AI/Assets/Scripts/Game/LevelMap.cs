using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;
using System.IO;

namespace Game
{
    public class LevelMap : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;

        [SerializeField] private Transform _root;

        [SerializeField] private List<Vector3> _points;

        public IReadOnlyList<Vector3> Points => _points;

        private JsonController _jsonController;
        private static PrefabFactory _prefabFactory;

        public class Item
        {
            public List<Vector3> _points;
        }

        [Inject]
        private void Construct(JsonController jsonController, PrefabFactory prefabFactory)
        {
            _jsonController = jsonController;
            _prefabFactory = prefabFactory;
        }

        [MenuItem("CONTEXT/LevelMap/Spawn Points")]
        private static void InstantiatePoints(MenuCommand command)
        {
            var item = JsonUtility.FromJson<Item>(File.ReadAllText(Application.streamingAssetsPath + "/map.json"));

            Clear(command);
            
            var levelMap = command.context as LevelMap;
            if (levelMap == null)
                return;

            levelMap._points = item._points;

            foreach (var p in levelMap._points.Distinct())
            {
                var prefab = PrefabUtility.InstantiatePrefab(levelMap._prefab, levelMap._root) as GameObject;
                prefab.transform.position = p;
            }

            /*Clear(command);
            
            var levelMap = command.context as LevelMap;
            if (levelMap == null)
                return;

            foreach (var p in levelMap._points.Distinct())
            {
                var prefab = PrefabUtility.InstantiatePrefab(levelMap._prefab, levelMap._root) as GameObject;
                prefab.transform.position = p;
            }*/
        }

        [MenuItem("CONTEXT/LevelMap/Clear Points")]
        private static void Clear(MenuCommand command)
        {
            var levelMap = command.context as LevelMap;
            if (levelMap == null)
                return;
            
            var count = levelMap._root.childCount;
            for (var i = count - 1; i >= 0; i--)
            {
                DestroyImmediate(levelMap._root.GetChild(i).gameObject);
            }
        }
    }
}