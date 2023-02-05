using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed; // sets the speed

    [SerializeField] protected Transform pointL, pointR;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 _currentTarget;

   void Start()
    {
        _currentTarget = pointR.position;
    }

    void Movement()
    {
        if (transform.position == pointL.position)
        {
            _currentTarget = pointR.position;
            spriteRenderer.flipY = true;
        }
        else if (transform.position == pointR.position)
        {
            _currentTarget = pointL.position;
            spriteRenderer.flipY = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }

    void LateUpdate()
    {
        Movement();
    }
}
