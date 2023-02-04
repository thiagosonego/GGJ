using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Collider2D collider2D;
    [SerializeField]
    private ContactFilter2D filter;
    private List<Collider2D> collidedObjects = new List<Collider2D>(1);
    public InteratibleTypes type;
    public enum InteratibleTypes
    {
        Plant,
        Scissor,
        Medicine,
        Dialog
    }

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        GetComponent<Collider2D>().OverlapCollider(filter, collidedObjects);
        foreach (var o in collidedObjects)
        {
            OnCollided(o.gameObject);
        }
    }

    private void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKeyDown("space"))
        {
            //check on the type of object and call the correct method
            switch (type)
            {
                case InteratibleTypes.Plant:
                    Plant();
                    break;
                case InteratibleTypes.Scissor:
                    break;
                case InteratibleTypes.Medicine:
                    break;
                case InteratibleTypes.Dialog:
                    break;
                default:
                    break;
            }
        }
    }

    private void Plant()
    {
        //call on the method for updating the objective
        Debug.Log("Teste");
        Destroy(gameObject);
    }
}
