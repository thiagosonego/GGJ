using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectiveTracker : MonoBehaviour
{
    public GameObject objectiveText;
    public GameObject objectiveTracking;
    public GameObject fatherObject;
    public GameObject endObject;
    public AudioSource endSound;
    public AudioSource music;
    public AudioClip newMusic;

    public int totalObjective;
    int currentObjective = 0;

    public stages objective;

    public enum stages
    {
        Start,
        Count,
        GoBack
    }

    void Start()
    {
        objectiveText = this.gameObject.transform.Find("Objective").gameObject;
        objectiveTracking = this.gameObject.transform.Find("Counter").gameObject;
        objective = stages.Start;
    }

    public void UpdateObjective(string type ,bool isFirstFase = true)
    {
        switch (objective)
        {
            case stages.Start:
                if (type != "Dialog")
                    break;
                if(isFirstFase)
                    objectiveText.GetComponent<TMP_Text>().text = "Objective: Trim the bushes";
                else
                    objectiveText.GetComponent<TMP_Text>().text = "Objective: Get remedies for your father";
                objectiveTracking.GetComponent<TMP_Text>().text = currentObjective + " of " + totalObjective;
                objectiveTracking.SetActive(true);
                objective = stages.Count;
                break;
            case stages.Count:
                currentObjective++;
                if (currentObjective < totalObjective)
                    objectiveTracking.GetComponent<TMP_Text>().text = currentObjective + " of " + totalObjective;
                else
                {
                    objectiveText.GetComponent<TMP_Text>().text = "Go back to your father!";
                    objectiveTracking.SetActive(false);
                    fatherObject.SetActive(false);
                    endObject.SetActive(true);
                    endSound.Play();
                    music.clip = newMusic;
                    music.Play();
                    objective = stages.GoBack;
                }
                break;
            case stages.GoBack:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            default:
                break;
        }
    }
}
