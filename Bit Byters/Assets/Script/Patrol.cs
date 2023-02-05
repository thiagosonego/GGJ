using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed; // sets the speed
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots; // sets patrol spots
    private int randomSpot; // picks random spot for patrol

    [SerializeField] protected Transform pointL, pointR;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 _currentTarget;


   void Start()
    {
        //randomSpot = Random.Range(0, moveSpots.Length);
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
        Debug.Log(_currentTarget);
    }

    void LateUpdate()
    {
        Movement();
    }


    /*void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }*/
}
