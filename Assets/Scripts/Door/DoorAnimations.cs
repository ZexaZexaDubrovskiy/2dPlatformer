using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    private Animator _animator;
    public bool IsOpen { private get; set; }

    private void Start() => _animator = GetComponentInChildren<Animator>();

    private void Update()
    {
        _animator.SetBool("IsOpen", IsOpen);
    }
}
