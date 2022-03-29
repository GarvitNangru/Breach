using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOverPanel;
    public GameObject winningPanel;
    public void panelTobeActive(string panelName)
    {
        winningPanel.SetActive(panelName.Equals(winningPanel.name));
        GameOverPanel.SetActive(panelName.Equals(GameOverPanel.name));
    }
    public void GameExit()
    {
//        EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
