using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenuObject;
    public GameObject controlsObject;
    public GameObject creditsObject;
    public AudioSource selection;

    // Start is called before the first frame update
    public void StartGame() {
        selection.Play();
        SceneManager.LoadScene("Level1Scene", LoadSceneMode.Single);
    }

    public void EnterControls() {
        selection.Play();
        mainMenuObject.SetActive(false);
        controlsObject.SetActive(true);
    }

    public void LeaveControls() {
        selection.Play();
        mainMenuObject.SetActive(true);
        controlsObject.SetActive(false);
    }

    public void EnterSettings() {
        selection.Play();
        mainMenuObject.SetActive(false);
        creditsObject.SetActive(true);
    }

    public void LeaveSettings() {
        selection.Play();
        mainMenuObject.SetActive(true);
        creditsObject.SetActive(false);
    }
}
