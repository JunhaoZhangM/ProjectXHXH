using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerState
{
    Start,
    Idle,
    Walk,
    Run,

    Jump,
    Jump_Start,
    Jump_End,
    Dead,
    Attack
}

public class PlayerCon : MonoBehaviour
{
    [SerializeField]
    public PlayerInput
        _input;
    public AnimationCon _animationCon;
    public Rigidbody _rigbody;
    public PhyCheack _phyCheck;

    [Space(10)]
    [Header("ÊôÐÔ")]
    public float _curSpeed;
    public float _targetSpeed;

    public float _runSpeed;
    public float _walkSpeed;

    public float _jumpForce;
    public float _jumpCount;
    public float _jumpRate;

    [Space(10)]
    [Header("×´Ì¬")]
    public PlayerState _state;
    public bool _isAir;


    [Space(10)]
    [Header("¹¥»÷")]
    private int a;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _animationCon = GetComponent<AnimationCon>();
        _rigbody = GetComponent<Rigidbody>();
        _phyCheck = GetComponent<PhyCheack>();
    }
    private void Start()
    {
        _state = PlayerState.Start;
    }
    private void OnEnable()
    {
        _input._startAttackEvent.AddListener(Attack);
        _input._stopAttackEvent.AddListener(Attack);
    }

    private void Update()
    {
        if (_input._deadInput) 
        {
            Dead();
        }
        Refresh();
    }

    public void Refresh()
    {
        if (_state != PlayerState.Dead && _state!= PlayerState.Start)
        {
            OnMove();
            Jump();
            Fall();
            ToGround();
        }
    }

    public void OnMove()
    {
        PlayerState playerState = _state;
        Vector2 moveInput=_input._moveInput;
        if (_state == PlayerState.Attack)
        {
            _curSpeed = Mathf.Lerp(_curSpeed, 0, Time.deltaTime * 10);
        }
        else
        {
            if (moveInput != Vector2.zero)
            {
                _targetSpeed = _input._isRunInput ? _runSpeed : _walkSpeed;

                playerState = _input._isRunInput ? PlayerState.Run : PlayerState.Walk;

                _curSpeed = Mathf.Lerp(_curSpeed, _targetSpeed, Time.deltaTime * 10);

                if (moveInput.x != 0)
                {
                    if (moveInput.x > 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    else if (moveInput.x < 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
            }
            else
            {
                playerState = PlayerState.Idle;
                _curSpeed = Mathf.Lerp(_curSpeed, 0, Time.deltaTime * 10);
            }
        }

        if(!_isAir)
        {
            _state = playerState;
        }

        _rigbody.velocity = new Vector3(moveInput.x * _curSpeed, _rigbody.velocity.y, moveInput.y * _curSpeed);

    }
    public void Attack()
    {
        if(_state==PlayerState.Dead)
        {
            return;
        }
        if(_input._attackInput)
        {
            _animationCon.Attack();
            _state = PlayerState.Attack;
        }
        else
        {
            _animationCon.StopAttack();
            _state = PlayerState.Idle;
        }
    }

    public void Jump()
    {
        if(_input._jumpInput && _phyCheck._isGround)
        {
            _jumpForce += Time.deltaTime * 5;
            return;
        }
        if(_jumpForce>=0.2f)
        {
            _jumpForce = Mathf.Min(10.0f, _jumpForce);
                        _rigbody.velocity = new Vector3(_rigbody.velocity.x, _jumpForce, _rigbody.velocity.z);
            _jumpForce = 0.0f;
            _state = PlayerState.Jump_Start;
            _isAir = true;
        }
    }

    public void Fall()
    {
        if (_state == PlayerState.Jump_Start)
        {
            if (_rigbody.velocity.y < 0)
            {
                _state = PlayerState.Jump;
            }
        }
    }

    public void ToGround()
    {
        if (_state == PlayerState.Jump)
        {
            if (_phyCheck._isGround)
                _state = PlayerState.Jump_End;
        }
    }

    public void Dead()
    {
        if (_state != PlayerState.Dead)
        {
            _state = PlayerState.Dead;
            _animationCon.Dead();
        }
    }

    public void Restore(Transform _restoretransform)
    {
        _state = PlayerState.Start;
       transform.position = _restoretransform.position;
    }
}

