using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void BeginGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StopGame(){
        Debug.Log("helli");
        Application.Quit();
    }
}
