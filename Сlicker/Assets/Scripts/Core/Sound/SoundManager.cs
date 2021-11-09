using UnityEngine;
using Zenject;

namespace Core
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private SoundObject _soundObject;

        public SoundObject SpawnSoundObject()
        {
            var go = Instantiate(_soundObject);
            return go.GetComponent<SoundObject>();
        }
    }
}
