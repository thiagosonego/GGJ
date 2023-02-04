using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider2D collider2D;
    [SerializeField]
    private ContactFilter2D filter;
    private List<Collider2D> collidedObjects = new List<Collider2D>(1);

    void Start()
    {
        collider2D = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        collider2D.OverlapCollider(filter, collidedObjects);
        foreach (var o in collidedObjects)
        {
            Debug.Log("Collided with " + o.name);
        }
    }
}
