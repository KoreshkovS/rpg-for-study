using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioSource _sourceSFX;
    private static AudioSource _sourceMusic;
    private static AudioSource _sourceRandomSFX;
    private static float _musicVolume = 0.1f;
    private static float _sfxVolume = 0.1f;
    private static AudioClip[] _musicClips = null;
    private static AudioClip[] _soundsClips = null;
   

    public static void Init()
    {
        GameObject gameObject = new GameObject("AudioController");
        DontDestroyOnLoad(gameObject);
        _sourceSFX = gameObject.AddComponent<AudioSource>();
        _sourceMusic = gameObject.AddComponent<AudioSource>();
        _sourceRandomSFX = gameObject.AddComponent<AudioSource>();
        _musicClips = Resources.LoadAll<AudioClip>("Audio/Musics");
        _soundsClips = Resources.LoadAll<AudioClip>("Audio/Sounds");
    }

    private static AudioClip GetClip(string clipName)
    {
        for (int i = 0; i < _soundsClips.Length; i++)
        {
            if (_soundsClips[i].name == clipName)
            {
                return _soundsClips[i];
            }
        }
        Debug.LogError("Не найдет аудио клип");
        return null;

    }

    private static AudioClip GetMusic(string clipName)
    {
        for (int i = 0; i < _musicClips.Length; i++)
        {
            if (_musicClips[i].name == clipName)
            {
                return _musicClips[i];
            }
        }
        Debug.LogError("Не найдет аудио клип");
        return null;

    }

    public static void PlaySound(string name)
    {
        _sourceSFX.PlayOneShot(GetClip(name), _sfxVolume);
    }

    public static void PlayRandomPichSound(string name)
    {
        _sourceRandomSFX.pitch = Random.Range(0.73f, 1.3f);
        _sourceRandomSFX.PlayOneShot(GetClip(name), _sfxVolume);
    }

    public static void StopSound()
    {
        _sourceSFX.Stop();

    }

    public static void StopMusic()
    {
        _sourceMusic.Stop();

    }

    public static void PlayMusic(string name)
    {
        _sourceMusic.Stop();
        _sourceMusic.clip = GetMusic(name);
        _sourceMusic.volume = _musicVolume;
        _sourceMusic.Play();
    }

    public static void SetSoundVolume(float volume)
    {
        if (volume > 1)
        {
            volume = 1;
        }
        DataStore.SaveSoundsVolume(volume);
        _sfxVolume = DataStore.LoadSoundsVolume();
    }

    public static void SetMusicVolume(float volume)
    {
        if (volume > 1)
        {
            volume = 1;
        }
        DataStore.SaveMusicVolume(volume);
        _musicVolume = DataStore.LoadMusicVolume();
    }
}
