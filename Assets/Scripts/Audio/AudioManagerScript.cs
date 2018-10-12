using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///	AudioManager is a class to manage sound, music, volume
/// </summary>

namespace TowerDefense
{

    public class AudioManagerScript : SingletonScript<AudioManagerScript>
    {

        public float MusicVolume { get; set; }
        public float SoundsVolume { get; set; }
        public AudioClip CurrentMusic { get; set; }

        class ClipInfo
        {
            public AudioSource source { get; set; }
            public float defaultVolume { get; set; }
        }

        // Public Variables

        // Private Variables
        private List<ClipInfo> _activeAudioList;
        private AudioSource _activeMusic;
        private AudioSource _activeVoiceOver;
        private float _volumeMod;
        private float _volumeMin;
        private bool _VOfade;

        void Awake()
        {
            this._activeAudioList = new List<ClipInfo>();
            this._activeVoiceOver = null;
            this._activeMusic = null;
        }

        void Start()
        {
            this._volumeMod = 1;
            this._volumeMin = 0.2f;
            this._VOfade = false;

            this.MusicVolume = 1.0f;//UserPropertiesModel.Instance.musicActivated;
            this.SoundsVolume = 0.70f;//UserPropertiesModel.Instance.musicActivated;
        }

        void Update()
        {
            if (this._VOfade && this._volumeMod >= this._volumeMin)
            {
                this._volumeMod -= 0.1f;
            }
            else if (!this._VOfade && this._volumeMod < 1.0f)
            {
                this._volumeMod += 0.1f;
            }
            //this.UpdateActiveAudio();
        }

        public void AdjustVolume()
        {
            float value = 0.0f;

            if (this.MusicVolume == 0.0f)
            {
                value = 1.0f;
            }

            if (this._activeMusic != null)
            {
                this._activeMusic.volume = value;
            }
            UserPropertiesModel.Instance.musicActivated = (int)value;

            this.MusicVolume = 1.0f;//UserPropertiesModel.Instance.musicActivated;
            this.SoundsVolume = 0.70f;//UserPropertiesModel.Instance.musicActivated;
        }

        /*public void EnableSounds() {
            UserPropertiesModel.Instance.musicActivated = 1;

            this.MusicVolume = UserPropertiesModel.Instance.musicActivated;
            this.SoundsVolume = UserPropertiesModel.Instance.musicActivated;
        }

        public void DisableSounds() {
            UserPropertiesModel.Instance.musicActivated = 0;

            this.MusicVolume = UserPropertiesModel.Instance.musicActivated;
            this.SoundsVolume = UserPropertiesModel.Instance.musicActivated;
        }*/

        public void UpdateSounds()
        {
            this.MusicVolume = 1.0f;//UserPropertiesModel.Instance.musicActivated;
            this.SoundsVolume = 0.70f;//UserPropertiesModel.Instance.musicActivated;

            List<ClipInfo> toRemove = new List<ClipInfo>();
            try
            {
                foreach (ClipInfo audioClip in this._activeAudioList)
                {
                    if (!audioClip.source)
                    {
                        toRemove.Add(audioClip);
                    }
                    else
                    {
                        audioClip.source.volume = this.SoundsVolume;
                    }
                }
                this._activeMusic.volume = this.MusicVolume;
            }
            catch
            {
                Debug.Log("Error updating active audio clips");
                return;
            }

            foreach (ClipInfo audioClip in toRemove)
            {
                this._activeAudioList.Remove(audioClip);
            }
        }

        private void SetSource(ref AudioSource source, AudioClip clip, float volume)
        {
            source.rolloffMode = AudioRolloffMode.Logarithmic;
            source.dopplerLevel = 0.5f;
            source.minDistance = 2;
            source.maxDistance = 30;
            source.priority = 128;
            source.clip = clip;
            source.volume = volume;
        }

        public AudioSource PlayVoiceOver(AudioClip voiceOver, float volume)
        {
            AudioSource source = Play(voiceOver, transform, volume);

            this._VOfade = true;
            this._activeVoiceOver = source;
            this._volumeMod = 0.2f;

            return source;
        }

        public AudioSource PlayMusic(AudioClip music, float volume)
        {
            this.CurrentMusic = music;
            this._activeMusic = PlayLoop(music, transform, volume);
            this._activeMusic.priority = 0;

            return this._activeMusic;
        }

        public IEnumerator PlayMusicWithFadeIn(AudioClip music, float volume)
        {
            this.CurrentMusic = music;
            this._activeMusic = PlayLoop(music, transform, 0.0f);
            this._activeMusic.priority = 0;

            while (this._activeMusic.volume < volume)
            {
                this._activeMusic.volume += 0.01f;
                yield return new WaitForEndOfFrame();
            }
        }

        public IEnumerator PauseMusicWithFadeOut()
        {
            while (this._activeMusic.volume > 0)
            {
                this._activeMusic.volume -= 0.05f;
                yield return new WaitForEndOfFrame();
            }
            this._activeMusic.Pause();
        }

        public IEnumerator UnPauseMusicWithFadeIn()
        {
            this._activeMusic.Play();
            while (this._activeMusic.volume < MusicVolume)
            {
                this._activeMusic.volume += 0.05f;
                yield return new WaitForEndOfFrame();
            }
        }

        public void StopMusic()
        {
            StopSound(this._activeMusic);
        }

        public IEnumerator FadeInMusic(AudioClip music, float volume)
        {
            this.CurrentMusic = music;
            if (this._activeMusic == null)
            {
                PlayMusic(music, volume);
            }
            else
            {
                while (this._activeMusic.volume > 0)
                {
                    this._activeMusic.volume -= 0.05f;
                    yield return new WaitForEndOfFrame();
                }
                StartCoroutine(FadeOutMusic(music, volume));
            }
        }

        private IEnumerator FadeOutMusic(AudioClip music, float volume)
        {
            StopSound(this._activeMusic);
            if (music)
            {
                PlayMusic(music, 0.0f);
                while (this._activeMusic.volume < volume)
                {
                    this._activeMusic.volume += 0.05f;
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        public AudioSource Play(AudioClip clip, Vector3 soundOrigin, float volume)
        {
            if (clip == null) return null;

            GameObject soundLoc = new GameObject("Audio: " + clip.name);
            AudioSource source = soundLoc.AddComponent<AudioSource>();

            Debug.Log(source);

            soundLoc.transform.position = soundOrigin;
            this.SetSource(ref source, clip, volume);
            this._activeAudioList.Add(new ClipInfo { source = source, defaultVolume = volume });

            source.Play();
            Destroy(soundLoc, clip.length);
            return source;
        }

        public AudioSource Play(AudioClip clip, Transform emitter, float volume)
        {
            AudioSource source = Play(clip, emitter.position, volume);

            source.transform.parent = emitter;
            return source;
        }

        public AudioSource PlayLoop(AudioClip loop, Transform emitter, float volume)
        {
            if (loop == null) return null;

            GameObject movingSoundLoc = new GameObject("Audio: " + loop.name);
            AudioSource source = movingSoundLoc.AddComponent<AudioSource>();

            movingSoundLoc.transform.position = emitter.position;
            movingSoundLoc.transform.parent = emitter;

            this.SetSource(ref source, loop, volume);
            source.loop = true;
            source.Play();

            this._activeAudioList.Add(new ClipInfo { source = source, defaultVolume = volume });
            return source;
        }

        public void StopSound(AudioSource toStop)
        {
            if (toStop == null) return;

            try
            {
                Destroy(this._activeAudioList.Find(s => s.source == toStop).source.gameObject);
            }
            catch
            {
                Debug.Log("Error trying to stop audio source " + toStop);
            }
        }

        public bool IsPlaying(AudioClip clip)
        {
            if (clip == null) return false;

            try
            {
                return this._activeAudioList.Find(s => s.source.clip == clip) == null ? false : true;
            }
            catch
            {
                return false;
            }
        }

        private void UpdateActiveAudio()
        {
            List<ClipInfo> toRemove = new List<ClipInfo>();
            try
            {
                if (!this._activeVoiceOver)
                {
                    this._VOfade = false;
                }
                foreach (ClipInfo audioClip in this._activeAudioList)
                {
                    if (!audioClip.source)
                    {
                        toRemove.Add(audioClip);
                    }
                    else if (audioClip.source != this._activeVoiceOver)
                    {
                        audioClip.source.volume = audioClip.defaultVolume * this._volumeMod;
                    }
                }
            }
            catch
            {
                Debug.Log("Error updating active audio clips");
                return;
            }

            foreach (ClipInfo audioClip in toRemove)
            {
                this._activeAudioList.Remove(audioClip);
            }
        }

        public void PauseFX()
        {
            foreach (ClipInfo audioClip in this._activeAudioList)
            {
                try
                {
                    if (audioClip.source != this._activeMusic)
                    {
                        audioClip.source.Pause();
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        public void UnpauseFX()
        {
            foreach (ClipInfo audioClip in this._activeAudioList)
            {
                try
                {
                    if (!audioClip.source.isPlaying)
                    {
                        audioClip.source.Play();
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
