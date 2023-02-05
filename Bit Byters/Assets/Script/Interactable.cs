using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    AudioSource audioSource;
    public InteratibleTypes type;
    public bool isFirstFase;

    bool used = false;

    public enum InteratibleTypes
    {
        Plant,
        Medicine,
        Dialog
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (!used)
        {
            collision.gameObject.GetComponent<PlayerControler>().ShowInteraction(true);
            if (Input.GetKey("space"))
            {
                //check on the type of object and call the correct method
                switch (type)
                {
                    case InteratibleTypes.Plant:
                        if(FindObjectOfType<Canvas>().GetComponent<ObjectiveTracker>().objective == ObjectiveTracker.stages.Count)
                            Plant();
                        break;
                    case InteratibleTypes.Medicine:
                        if (FindObjectOfType<Canvas>().GetComponent<ObjectiveTracker>().objective == ObjectiveTracker.stages.Count)
                            Medicine();
                        break;
                    case InteratibleTypes.Dialog:
                            Dialog();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerControler>().ShowInteraction(false);
    }

    private void Plant()
    {
        FindObjectOfType<Canvas>().GetComponent<ObjectiveTracker>().UpdateObjective("Plant");
        this.gameObject.transform.Find("Before").gameObject.SetActive(false);
        this.gameObject.transform.Find("After").gameObject.SetActive(true);
        audioSource.Play();
        used = true;
    }

    private void Medicine()
    {
        FindObjectOfType<Canvas>().GetComponent<ObjectiveTracker>().UpdateObjective("Medicine");
        audioSource.Play();
        used = true;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Dialog()
    {
        FindObjectOfType<Canvas>().GetComponent<ObjectiveTracker>().UpdateObjective("Dialog", isFirstFase);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>().PopUp();
        used = true;
    }
}
