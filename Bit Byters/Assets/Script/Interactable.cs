using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    AudioSource audioSource;

    public InteratibleTypes type;

    bool used = false;
        
    public enum InteratibleTypes
    {
        Plant,
        Scissor,
        Medicine,
        Dialog
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey("space") && !used)
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
                    Medicine();
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
        audioSource.Play();
        used = true;
        //call on the method for updating the objective
    }

    private void Medicine()
    {
        audioSource.Play();
        this.gameObject.SetActive(false);
        used = true;
    }
}
