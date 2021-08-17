using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public static int quiznum = 0;

    public void startbutton()
    {
      quiznum = 0;
      SceneManager.LoadScene("SampleScene");
    }
}
