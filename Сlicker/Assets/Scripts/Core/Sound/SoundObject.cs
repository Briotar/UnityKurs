using UnityEngine;
using Zenject;

namespace Core
{
    public class SoundObject : MonoBehaviour
    {
        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        public void Play(AudioClip clip, bool isLoop = false)
        {
            _source.clip = clip;
            _source.loop = isLoop;

            _source.Play();
        }

        private void Update()
        {
            if(!_source.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
