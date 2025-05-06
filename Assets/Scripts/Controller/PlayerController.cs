using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;

    private bool isJumping = false;

    [SerializeField]
    private Transform renderImgTrans;
    [SerializeField]
    private Transform shadowTrans;

    // 추후 stathandler로 이동
    public float jumpHeight = 1f;
    public float jumpDuration = 0.5f;

    protected override void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        aniHandler = GetComponent<AnimationHandler>();
        camera = Camera.main;
        if(renderImgTrans != null)
            renderImgTrans = transform.Find("MainSprite").gameObject.transform;
        if (shadowTrans != null)
            shadowTrans = transform.Find("Shadow").gameObject.transform;
    }

    private void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>().normalized;
    }

    private void OnJump(InputValue value)
    {
        if (!isJumping)
        {
            StartCoroutine(JumpRoutine());
            aniHandler.Jump();
            shadowTrans.GetComponent<Animator>().SetTrigger("IsJump");

        }
    }

    private void OnLook(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);
        lookDir = (worldPos - (Vector2)transform.position);

        if(lookDir.sqrMagnitude < 0.8f)
        {
            lookDir = Vector2.zero;
        }
        else
        {
            lookDir = lookDir.normalized;
        }
        Debug.DrawLine(transform.position, transform.position + (Vector3)lookDir * 2f, Color.red);
    }


    private IEnumerator JumpRoutine()
    {
        isJumping = true;

        Vector3 start = renderImgTrans.localPosition;
        Vector3 peak = start + Vector3.up * jumpHeight;

        float time = 0f;

        // 올라갈 때
        while (time < jumpDuration / 2f)
        {
            renderImgTrans.localPosition = Vector3.Lerp(start, peak, time / (jumpDuration / 2f));
            time += Time.deltaTime;
            yield return null;
        }

        // 떨어질 때
        time = 0f;
        while (time < jumpDuration / 2f)
        {
            renderImgTrans.localPosition = Vector3.Lerp(peak, start, time / (jumpDuration / 2f));
            time += Time.deltaTime;
            yield return null;
        }

        renderImgTrans.localPosition = start;
        isJumping = false;
    }
}
