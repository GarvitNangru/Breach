using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DialogueManagerLevel1 : MonoBehaviour
{
    public GameObject textBox;
    public string[] sentences;
    public int index = 0;

    public TMP_Text dilogueText;
    public float typingSpeed;

    public int stopIndex;
    bool stopDialogue;

    public UnityEvent exitEvent;
    bool alreadyRunning=false;
    //public GameObject loadingScreen;
    //public Slider ProgressBar;


    //  public GameObject continueButton;
    private bool showText = true;
    bool alreadyCalled = false;
   // int count = 0;
     SceneLoader loader;
    bool sceneLoading=false;
    private void Start()
    {
        Invoke("startDialogue", 2f);
        loader = GetComponent<SceneLoader>();
    }
    IEnumerator Type()
    {

        alreadyCalled = false;
        alreadyRunning = true;
        foreach (char letter in sentences[index].ToCharArray())
        {
            dilogueText.text += letter;
          
            yield return new WaitForSeconds(typingSpeed);
        }
        if (dilogueText.text == sentences[index])
                alreadyRunning = false;

        if (index == stopIndex)
        {
            showText = false;
        }
       
    }
    public void startDialogue()
    {

        if (alreadyRunning)
            return;

        showText = true;
        textBox.SetActive(true);
        //    count = 1;
        dilogueText.text = "";
        dilogueText.gameObject.SetActive(true);

        StartCoroutine(Type());
    }
    public void nextSentence()
    {
        // alreadyCalled = true;
        //     continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            dilogueText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            dilogueText.text = "";
            //    continueButton.SetActive(false);
            //   Debug.Log("true");
        }
    }
    void Update()
    {
        if (sceneLoading)
            return;
        //if (dilogueText.text == sentences[index])
        //    alreadyRunning = false;

    

        if (dilogueText.text == sentences[index] && !alreadyCalled && showText && !alreadyRunning)
        {
            alreadyCalled = true;
            //continueButton.SetActive(true);
            Invoke("nextSentence", 1f);
        }

        if (index == stopIndex && !showText)
        {
            index = stopIndex;
            dilogueText.text = "";
            textBox.SetActive(false);
            dilogueText.gameObject.SetActive(false);
            //   continueButton.SetActive(false);
            showText = false;
        }
        if(index >= sentences.Length-1 && !showText)
        {
            //  loader.GotoLevel2();
            exitEvent.Invoke();
            sceneLoading = true;
        }

    }
    
}
