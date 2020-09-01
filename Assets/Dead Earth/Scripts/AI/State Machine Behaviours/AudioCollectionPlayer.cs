using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollectionPlayer : AIStateMachineLink
{
    //Inspector Assigned Variables
    [SerializeField] ComChannelName _commandChannel = ComChannelName.ComChannel1;
    [SerializeField] AudioCollection _audioCollection = null;


    // Private 
    private int _previousCommand = 0;
    private AudioManager _audioManager = null;
    private int _commandChannelHash = -1;

    // ---------------------------------------------------------------
    // Name:    OnStateEnter
    // Desc:    Called prior to first frame the animation assigned to this state
    // ---------------------------------------------------------------------

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _audioManager = AudioManager.instance;
        _previousCommand = 0;

        // TODO: Store hashesin state machine lookup
        if (_commandChannelHash == -1)
            _commandChannelHash = Animator.StringToHash(_commandChannel.ToString());
    }

    // ---------------------------------------------------------------------------
    // Name:    OnStateUpdate
    // Desc:    Called by animation system after each frame of updating animation
    // ---------------------------------------------------------------------------
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Dont make sounds for layers whos wieght is zero
        if (layerIndex != 0 && animator.GetLayerWeight(layerIndex).Equals(0.0f)) return;

        int command;
        command = Mathf.FloorToInt(animator.GetFloat(_commandChannelHash));
        
        if(_previousCommand != command && _audioManager!=null && _audioCollection!=null && _stateMachine != null)
        {
            int bank = Mathf.Max(0, Mathf.Min(command - 1, _audioCollection.bankCount - 1));

            _audioManager.PlayOneShotSound(_audioCollection.AudioMixerGroup, _audioCollection[bank], _stateMachine.transform.position, 
                _audioCollection.volume, _audioCollection.spatialBlend, _audioCollection.priority);
        }

        _previousCommand = command;
    }



}
