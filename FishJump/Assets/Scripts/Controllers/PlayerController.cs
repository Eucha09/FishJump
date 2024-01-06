using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    float _jumpVelocity = 8.5f;
    float _angle;

    CapsuleCollider2D _collider2D;
    Rigidbody2D _rb2d;

    string _curPlatformName;

    void Start()
    {
        _collider2D = GetComponent<CapsuleCollider2D>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        IsGrounded();
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
            }
        }
    }

    void UpdateRotation()
    {
        float targetAngle;

        targetAngle = Mathf.Atan2(_rb2d.velocity.y, 1.0f) * Mathf.Rad2Deg;
        targetAngle = Mathf.Max(targetAngle, -10.0f);

        _angle = Mathf.Lerp(_angle, targetAngle, Time.deltaTime * 10.0f);

        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, _angle);
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
                Managers.Game.AddScore();
                _curPlatformName = raycastHit.collider.name;
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
}
