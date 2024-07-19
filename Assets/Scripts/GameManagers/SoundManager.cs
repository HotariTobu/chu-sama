using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource timeAudioSource;
    [SerializeField] AudioSource seAudioSource1;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<TIMESoundData> timeSoundDatas;
    [SerializeField] List<SESoundData1> seSoundDatas1;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume1 = 1;
    public float timeMasterVolume = 1;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }

    public void StopBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Stop();
    }

    public void PlayTIME(TIMESoundData.TIME time)
    {
        TIMESoundData data = timeSoundDatas.Find(data => data.time == time);
        timeAudioSource.clip = data.audioClip;
        timeAudioSource.volume = data.volume * timeMasterVolume * masterVolume;
        timeAudioSource.Play();
    }

    public void StopTIME(TIMESoundData.TIME time)
    {
        TIMESoundData data = timeSoundDatas.Find(data => data.time == time);
        timeAudioSource.clip = data.audioClip;
        timeAudioSource.volume = data.volume * timeMasterVolume * masterVolume;
        timeAudioSource.Stop();
    }

    public void PlaySE1(SESoundData1.SE1 se1)
    {
        SESoundData1 data = seSoundDatas1.Find(data => data.se1 == se1);
        seAudioSource1.volume = data.volume * seMasterVolume1 * masterVolume;
        seAudioSource1.PlayOneShot(data.audioClip);
    }

    public void StopSE1(SESoundData1.SE1 se1)
    {
        SESoundData1 data = seSoundDatas1.Find(data => data.se1 == se1);
        seAudioSource1.volume = data.volume * seMasterVolume1 * masterVolume;
        seAudioSource1.Stop();
    }
}

[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        NomalBGM,
        RockBGM,
        MuscleBGM,
        ClearBGM, // これがラベルになる
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class TIMESoundData
{
    public enum TIME
    {
        Time,
        Timeearly,
        Enter, // これがラベルになる
    }

    public TIME time;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData1
{
    public enum SE1
    {
        NomalEnter,
        NomalAttack,
        RockEnter,
        RockAttack1,
        RockAttack2,
        MuscleStart,
        MuscleEnter,
        MuscleAttack,
        question,
        Damage,
        correct,
        cross,
        explosion,
        clear, // これがラベルになる
    }

    public SE1 se1;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}