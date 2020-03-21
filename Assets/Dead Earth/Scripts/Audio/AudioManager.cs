using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


// -----------------------------------------------------------------------------------------
// CLASS	:	TrackInfo
// DESC		:	Wraps an AudioMixerGroup in Unity's AudioMixer. Contains the name of the
//				group (which is also its exposed volume paramater), the group itself
//				and an IEnumerator for doing track fades over time.
// -----------------------------------------------------------------------------------------
public class TrackInfo
{
    public string Name = string.Empty;
    public AudioMixerGroup Group = null;
    public IEnumerator TrackFader = null;
}// End TrackInfo Class

// ----------------------------------------------------------------------------------------
// CLASS	:	AudioManager
// DESC		: 	Provides pooled one-shot functionality with priority system and also
//				wraps the Unity Audio Mixer to make easier manipulation of audiogroup
//				volumes 
// ---------------------------------------------------------------------------------------- 
public class AudioManager : MonoBehaviour
{
    // Statics
    private static AudioManager _instance = null;
    public static AudioManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = (AudioManager)FindObjectOfType(typeof(AudioManager));
            }
            return _instance;
        }
    }

    // Inspector Assigned Variables
    [SerializeField] AudioMixer _mixer = null;

    // Provate Variables
    Dictionary<string, TrackInfo> _tracks = new Dictionary<string, TrackInfo>();

    private void Awake()
    {
        // This object must live for the entire application
        DontDestroyOnLoad(gameObject);

        // Return if we have no valid mixer reference
        if (!_mixer) return;

        // Fetch all the groups in the mixer - These will be our mixers tracks
        AudioMixerGroup[] groups = _mixer.FindMatchingGroups(string.Empty);

    }



}
