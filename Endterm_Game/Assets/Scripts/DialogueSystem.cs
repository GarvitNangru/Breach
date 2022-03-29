using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textBox;
    public string[] sentences;
    private int index=0;
  
    public TMP_Text dilogueText;
    public float typingSpeed;

    public GameObject loadingScreen;
    public Slider ProgressBar;
    AudioSource audioSource;
    public AudioSource HummingAudio;
  //  public GameObject continueButton;
    private bool showText = true;
    bool alreadyCalled=false;
    // int count = 0;

    private void Start()
    {
        //  startDialogue();
        audioSource = GetComponent<AudioSource>();
    }
    IEnumerator Type()
    {

        alreadyCalled = false;
        foreach(char letter in sentences[index].ToCharArray())
        {
            dilogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        if(index>=sentences.Length-1)
        {
            showText = false;
        }
    }
    public void startDialogue()
    {
 //       count = 1;
        dilogueText.text = "";
        dilogueText.gameObject.SetActive(true);
     
        StartCoroutine(Type());
    }
    public void nextSentence()
    {
       // alreadyCalled = true;
   //     continueButton.SetActive(false);
        if (index < sentences.Length-1)
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
    public void enableTextBox()
    {
        textBox.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (dilogueText.text==sentences[index] && !alreadyCalled)
        {
            alreadyCalled=true;
            //continueButton.SetActive(true);
            Invoke("nextSentence",1f);
        }
       
        if (index >= sentences.Length - 1 && !showText)
        {
            index = 0;
            dilogueText.text = "";
            textBox.SetActive(false);
            dilogueText.gameObject.SetActive(false);
         //   continueButton.SetActive(false);r
            showText = false;
        }

    }
    public void GotoLevel1()
    {
        //    SceneManager.LoadScene("Level1");
        StartCoroutine(LoadScene());
        audioSource.Stop();
        HummingAudio.Stop();
    }
    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level1");
        loadingScreen.SetActive(true);
       
        while(!operation.isDone)
        {
            Debug.Log(operation.progress);
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            ProgressBar.value = progress;
            yield return null;
        }
    }
    public void playAudio()
    {
        audioSource.Play();
    }
 
}
