using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider ProgressBar;
    public UnityEvent SceneLoadEvent;
    public void GotoMainMenu()
    {
        StartCoroutine(LoadScene(0));
    }
    public void GotoLevel2()
    {
        StartCoroutine(LoadScene(3));
    }
    public void GotoLevel1()
    {
        StartCoroutine(LoadScene(1));
    }
    public void ReloadCurrentScene()
    {
       StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

IEnumerator LoadScene(int index)
{
        SceneLoadEvent.Invoke();
    AsyncOperation operation = SceneManager.LoadSceneAsync(index);
    loadingScreen.SetActive(true);

    while (!operation.isDone)
    {
        Debug.Log(operation.progress);
        float progress = Mathf.Clamp01(operation.progress / 0.9f);
        ProgressBar.value = progress;
        yield return null;
    }
}

}
