using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class AnimationCon : MonoBehaviour
{
    public SkeletonAnimation _skeletonAnimation;
    public PlayerCon _player;

    [Space(10)]
    [Header("ÇÐ»»")]
    public PlayerState _previousState;
    public PlayerState _currentState;

    [Space(10)]
    [Header("³öÉú")]
    public bool _isStart;

    private void Awake()
    {
        _player = GetComponent<PlayerCon>();
        _skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
    }

    private void OnEnable()
    {
        _skeletonAnimation.AnimationState.Complete += OnAnimationComplete;
    }
    private void OnDisable()
    {
        _skeletonAnimation.AnimationState.Complete -= OnAnimationComplete;
    }
    private void Update()
    {
        _currentState = _player._state;

        if (_previousState != _currentState && !_isStart)
            UpdateMoveAnimation();
    }

    private void UpdateMoveAnimation()
    {
        //Spine.Animation nextAnimation;
        if (_currentState == PlayerState.Idle)
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);
        }
        else if (_currentState == PlayerState.Walk)
        {
           _skeletonAnimation.AnimationState.SetAnimation(0, "Walk", true);
        }
        else if (_currentState == PlayerState.Run)
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, "Run", true);
        }
        else if (_currentState == PlayerState.Jump_Start)
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, "Jump_Start", false);
        }
        else if(_currentState == PlayerState.Jump)
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, "Jump", false);
        }
        else if(_currentState == PlayerState.Jump_End)
        {
            _skeletonAnimation.AnimationState.SetAnimation(0, "Jump_End", false);
        }
        _previousState = _currentState;

    }

    public void Start()
    {
        _skeletonAnimation.AnimationState.SetAnimation(0, "Start", false);
    }

    public void Attack()
    {
        _skeletonAnimation.AnimationState.SetAnimation(0, "Attack", true);
    }

    public void StopAttack()
    {
        _skeletonAnimation.AnimationState.AddEmptyAnimation(0, 0.5f, 0.1f);
    }

    public void Dead()
    {
        _skeletonAnimation.AnimationState.SetAnimation(0, "Die", false);
    }

    private void OnAnimationComplete(TrackEntry entry)
    {
        if (entry != null)
        {
            if (entry.Animation.Name == "Start"||entry.Animation.Name == "Jump_End")
            {
                _player._state = PlayerState.Idle;
                _player._isAir = false;
            }
        }
    }


}
