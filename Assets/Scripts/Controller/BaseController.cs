using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    // 컨트롤 주체 이미지 렌더러
    [SerializeField]
    private SpriteRenderer characterRenderer;

    // 컨트롤 주체 강체
    protected Rigidbody2D _rigidbody2D;

    protected AnimationHandler aniHandler;

    // 이동 방향 벡터
    protected Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } }
    
    // 시선 처리 벡터
    protected Vector2 lookDir = Vector2.zero;
    public Vector2 LookDir { get { return lookDir; } }

    // 넉백시 방향 벡터
    private Vector2 knockback = Vector2.zero;
    // 넉백 지연 시간
    private float knockbackDuration = float.MaxValue;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        aniHandler = GetComponent<AnimationHandler>();
    }
    protected virtual void FixedUpdate()
    {
        Movement(moveDir);

        Rotate(lookDir);
        
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.deltaTime;
        }
    }

    // 방향 벡터 받아와서 해당 방향으로 이동시키는 함수
    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
        if (knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }

        _rigidbody2D.velocity = direction;
        aniHandler.Move(direction);
    }
    
    // 캐릭터의 회전
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }

}
