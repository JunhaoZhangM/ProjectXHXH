using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public Vector2 _moveInput;

    public bool _isRunInput;

    public bool _jumpInput;
    public bool _attackInput;
    public bool _deadInput;

    public UnityEvent _startAttackEvent;
    public UnityEvent _stopAttackEvent;

    private PlayerInputActions _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();

        // 移动输入绑定
        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled += OnMove;

        // 跑步输入绑定
        _inputActions.Player.Run.started += OnRun;
        _inputActions.Player.Run.canceled += OnRun;

        // 跳跃输入绑定
        _inputActions.Player.Jump.started += OnJump;
        _inputActions.Player.Jump.canceled += OnJump;

        // 攻击输入绑定
        _inputActions.Player.Attack.started += OnAttack;
        _inputActions.Player.Attack.canceled += OnAttack;

        // 死亡输入绑定
        _inputActions.Player.Dead.started += OnDead;
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isRunInput = true;
        }
        if (context.canceled)
        {
            _isRunInput = false;
        }
    }
    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.started) 
        {
            _jumpInput = true;
        }
        if(context.canceled)
        {
            _jumpInput = false;
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _attackInput = true;
            _startAttackEvent.Invoke();
        }
        if (context.canceled)
        {
            _attackInput = false;
            _stopAttackEvent.Invoke();
        }
    }

    public void OnDead(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _deadInput = true;
        }
    }

}
