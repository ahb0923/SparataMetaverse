using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    protected Animator animator;


    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsJump = Animator.StringToHash("IsJump");


    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 _object)
    {
        animator.SetBool(IsMoving, _object.magnitude > .5f);
    }

    public void Jump()
    {
        animator.SetTrigger(IsJump);
    }


}
