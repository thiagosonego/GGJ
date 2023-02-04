using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteratibleTypes type;
    public enum InteratibleTypes
    {
        Plant,
        Scissor,
        Medicine,
        Dialog
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (Input.GetKey("space"))
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
        this.gameObject.transform.Find("Before").gameObject.SetActive(false);
        this.gameObject.transform.Find("After").gameObject.SetActive(true);
        //call on the method for updating the objective
    }
}
