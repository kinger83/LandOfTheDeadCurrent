using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class ClipBank
{
    public List<AudioClip> Clips = new List<AudioClip>();
}



[CreateAssetMenu(fileName = "New Audio Collection")]
public class AudioCollection : ScriptableObject
{
    // Inspector Assigned Variables
    [SerializeField] string _audioGroup = string.Empty;
    [SerializeField] [Range(0.0f, 1.0f)] float _volume = 1.0f;
    [SerializeField] [Range(0.0f, 1.0f)] float _spatialBlend = 1.0f;
    [SerializeField] [Range(0, 256)] int _priorty = 128;
    [SerializeField] List<ClipBank> _AudioClipBanks = new List<ClipBank>();

    // Public Accessors
    public string AudioMixerGroup { get { return _audioGroup; } }
    public float volume { get { return _volume; } }
    public float spatialBlend { get { return _spatialBlend; } }
    public int priority { get { return _priorty; } }
    public int bankCount { get { return _AudioClipBanks.Count; } }


    public AudioClip this[int i]
    {
        get
        {
            if (_AudioClipBanks == null || _AudioClipBanks.Count <= i) return null;
            if (_AudioClipBanks[i].Clips.Count == 0) return null;

            List<AudioClip> clipList = _AudioClipBanks[i].Clips;
            AudioClip clip = clipList[Random.Range(0, clipList.Count)];

            return clip;

        }
    }


    public AudioClip audioClip
    {
        get
        {
            if (_AudioClipBanks == null || _AudioClipBanks.Count == 0) return null;
            if (_AudioClipBanks[0].Clips.Count == 0) return null;

            List<AudioClip> clipList = _AudioClipBanks[0].Clips;
            AudioClip clip = clipList[Random.Range(0, clipList.Count)];

            return clip;
        }
    }
}
