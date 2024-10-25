using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    PLAYERFOOTSTEP,
    PLAYERJUMP,
    PLAYERDIE,
    GAINSOUL,
    GAINLIFE,
    GATEUNLOCKED
    //add more here
}

namespace Code.Scripts.Managers
{

    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : Singleton<AudioManager>
    {
        //TO USE EXAMPLE:  AudioManager.Instance.PlayAudio(AudioType.PLAYERFOOTSTEP);
        [SerializeField] private AudioClip[] audioList;
        private AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudio(AudioType sound, float volume = 0.25f)
        {
            Instance.audioSource.loop = false;
            Instance.audioSource.PlayOneShot(Instance.audioList[(int)sound], volume);
        }

        public void PlayAudioContinuous(AudioType sound, float volume = 0.5f)
        {
            Instance.audioSource.clip = Instance.audioList[(int)sound];
            Instance.audioSource.loop = true;
            Instance.audioSource.Play();
        }

        public void StopPlaying()
        {
            Instance.audioSource.loop = false;
            Instance.audioSource.Stop();
        }
    }
}