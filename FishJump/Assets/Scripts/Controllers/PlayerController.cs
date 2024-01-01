using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _jumpPower = 420.0f;

    CapsuleCollider2D _collider2D;

    void Start()
    {
        _collider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        IsGrounded();
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (IsGrounded())
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpPower);
            }
        }
    }

    public bool IsGrounded()
    {
        float extraHeight = 0.1f;
        int layermask = 1 << (int)Define.Layer.Platform;
        RaycastHit2D raycastHit = Physics2D.Raycast(_collider2D.bounds.center, Vector2.down, _collider2D.bounds.extents.y + extraHeight, layermask);
        Color rayColor;
        if (raycastHit.collider != null)
            rayColor = Color.green;
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
