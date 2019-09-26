using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class EffectAudio : AudioBase
    {
        private void Awake()
        {
            Bind(AudioEvent.PLAY_EFFECT_AUDIO);
        }

        protected internal override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case AudioEvent.PLAY_EFFECT_AUDIO:
                {
                    if (message == null||message.Equals(""))
                    {
                        stopEffectAudio();
                    }
                    else
                    {
                        playeEffectAudio(message.ToString());
                    }
                    
                    break;
                }
                default:
                    break;
            }
        }

        /// <summary>
        /// 播放音乐的组件
        /// </summary>
        private AudioSource audioSource;

        // Use this for initialization
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            playeEffectAudio("");
        }

        /// <summary>
        /// 播放音乐
        /// </summary>
        private void playeEffectAudio(string assetName)
        {
            string audioPath = "Sound/" + assetName;
            AudioClip ac = Resources.Load<AudioClip>(audioPath);
            PlayerPrefs.SetString("AudioPath",audioPath);
            audioSource.clip = ac;
            audioSource.Play();
        }
        /// <summary>
        /// 停止播放音乐
        /// </summary>
        private void stopEffectAudio()
        {
            string audioPath = PlayerPrefs.GetString("AudioPath");
            AudioClip ac = Resources.Load<AudioClip>(audioPath);
            audioSource.Stop();
        }


    }
}
