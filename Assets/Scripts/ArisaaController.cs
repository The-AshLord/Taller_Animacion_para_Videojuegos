using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArisaaController : MonoBehaviour
{
    private enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Jump,
    }
 
    public Animator _CharacterAnimator;
    private PlayerState _currentState;
    void Start()
    {
        SetState(PlayerState.Idle);
    }
    void Update()
    {
        PlayerState newState = DeterminateState();
        if (newState != _currentState)
            SetState(newState);
    }
    private bool IsWalking()
    {
        return (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift));
    }
    private bool IsRunning()
    {
        return (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift));
    }
    private bool IsJumping()
    {
        return Input.GetKey(KeyCode.Space);
    }
   
   private void SetState(PlayerState newState)
    {
        // Disable the current state
        DisableState(_currentState);

        // Enable the new state
        EnableState(newState);

        _currentState = newState;
    }

    private void DisableState(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Idle:
                _CharacterAnimator.SetBool("Idle", false);
                break;
            case PlayerState.Walk:
                _CharacterAnimator.SetBool("Walk", false);
                break;
            case PlayerState.Run:
                _CharacterAnimator.SetBool("Run", false);
                break;
            case PlayerState.Jump:
                _CharacterAnimator.SetBool("Jump", false);
                break;
        }
    }

    private void EnableState(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Idle:
                _CharacterAnimator.SetBool("Idle", true);
                break;
            case PlayerState.Walk:
                _CharacterAnimator.SetBool("Walk", true);
                break;
            case PlayerState.Run:
                _CharacterAnimator.SetBool("Run", true);
                break;
            case PlayerState.Jump:
                _CharacterAnimator.SetBool("Jump", true);
                break;
        }
    }

    private PlayerState DeterminateState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return PlayerState.Jump;
        }
        else if (IsRunning())
        {
            return PlayerState.Run;
        }
        else if (IsWalking())
        {
            return PlayerState.Walk;
        }
        else
        {
            return PlayerState.Idle;
        }

    }
}
