using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    // ��Ʈ�� ��ü �̹��� ������
    [SerializeField]
    private SpriteRenderer characterRenderer;

    // ��Ʈ�� ��ü ��ü
    protected Rigidbody2D _rigidbody2D;

    protected AnimationHandler aniHandler;

    // �̵� ���� ����
    protected Vector2 moveDir = Vector2.zero;
    public Vector2 MoveDir { get { return moveDir; } }
    
    // �ü� ó�� ����
    protected Vector2 lookDir = Vector2.zero;
    public Vector2 LookDir { get { return lookDir; } }

    // �˹�� ���� ����
    private Vector2 knockback = Vector2.zero;
    // �˹� ���� �ð�
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

    // ���� ���� �޾ƿͼ� �ش� �������� �̵���Ű�� �Լ�
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
    
    // ĳ������ ȸ��
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }

}
