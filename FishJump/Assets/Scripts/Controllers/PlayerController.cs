using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    protected Define.State _state = Define.State.Idle;

    public virtual Define.State State
    {
        get { return _state; }
        set
        {
            _state = value;

            Animator anim = GetComponent<Animator>();
            switch (_state)
            {
                case Define.State.Idle:
                    anim.CrossFade("IDLE", 0.1f);
                    break;
                case Define.State.Jump:
                    anim.CrossFade("JUMP", 0.1f);
                    break;
            }
        }
    }

    float _jumpVelocity = 12.0f;
    float _angle;

    CapsuleCollider2D _collider2D;
    Rigidbody2D _rb2d;
    CameraController _camera;

    string _curPlatformName;
    bool _isJumping;

    void Start()
    {
        _collider2D = GetComponent<CapsuleCollider2D>();
        _rb2d = GetComponent<Rigidbody2D>();

        _camera = Camera.main.GetComponent<CameraController>();

        State = Define.State.Idle;
    }

    void Update()
    {
        if (Managers.Game.IsGameOver)
            return;

        if (!IsGrounded() && !_isJumping)
        {
            _isJumping = true;
            State = Define.State.Jump;
        }
        if (IsGrounded() && _isJumping)
        {
            _isJumping = false;
            State = Define.State.Idle;
        }

        GetInput();
        UpdateRotation();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                _rb2d.velocity = new Vector2(0.0f, _jumpVelocity);
                State = Define.State.Jump;
            }
        }
    }

    void UpdateRotation()
    {
        float targetAngle;

        targetAngle = Mathf.Atan2(_rb2d.velocity.y, 1.0f) * Mathf.Rad2Deg;
        targetAngle = Mathf.Max(targetAngle, 0.0f);

        _angle = Mathf.Lerp(_angle, targetAngle, Time.deltaTime * 10.0f);

        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -_angle);
    }

    public bool IsGrounded()
    {
        float extraHeight = 0.1f;
        int layermask = 1 << (int)Define.Layer.Platform;
        RaycastHit2D raycastHit = Physics2D.Raycast(_collider2D.bounds.center, Vector2.down, _collider2D.bounds.extents.y + extraHeight, layermask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.name != _curPlatformName)
            {
                State = Define.State.Idle;
                Managers.Game.AddScore();
                _curPlatformName = raycastHit.collider.name;
                if (raycastHit.collider.transform.parent.GetComponent<PlatformGroup>().IsMovingPlatform)
                    _camera.CameraFollow(transform.position + Vector3.up * 2.366f);
                else
                    _camera.CameraFollow(transform.position);
            }
            rayColor = Color.green;
        }
        else
            rayColor = Color.red;
        Debug.DrawRay(_collider2D.bounds.center, Vector2.down * (_collider2D.bounds.extents.y + extraHeight), rayColor);
        //Debug.Log(raycastHit.collider);

        if (raycastHit.collider != null)
            return true;
        else
            return false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroy")
            Managers.Game.GameOver();
    }
}
