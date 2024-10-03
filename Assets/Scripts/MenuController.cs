using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public GameObject endPanel;

    public GameObject[] pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseUI[0].SetActive(false);
        pauseUI[1].SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        pauseUI[0].SetActive(true);
        pauseUI[1].SetActive(false);
    }

    public void LoseGame () { 
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "GAME OVER.";
    }

    public void WinGame() { 
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "VICTORY.";
    }
}
