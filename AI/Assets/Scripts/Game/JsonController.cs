using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Game
{
    public class JsonController : MonoBehaviour
    {
        public Item item;

        [ContextMenu("Load")]
        public void LoadField()
        {
            item = JsonUtility.FromJson<Item>(File.ReadAllText(Application.streamingAssetsPath + "/map.json"));
        }

        [ContextMenu("Save")]
        public void SaveField()
        {
            File.WriteAllText(Application.streamingAssetsPath + "/map.json", JsonUtility.ToJson(item));
        }

        [System.Serializable]
        public class Item
        {
            public List<Vector3> _points;
        }
    }
}
