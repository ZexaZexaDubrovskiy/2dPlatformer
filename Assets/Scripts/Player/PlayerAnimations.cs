using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    
    public bool IsMoving { private get; set; }
    public bool IsFlying { private get; set; }
    public bool IsGrounded { private get; set; }

    private void Start() => _animator = GetComponentInChildren<Animator>();
    

    private void Update()
    {
        _animator.SetBool("IsMoving", IsMoving);
        _animator.SetBool("IsFlying", IsFlying);
    }

    public void Jump()
    {
        if (_animator.GetBool("IsFlying") == false)
            _animator.SetTrigger("Jump");
    }

}
