using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{

    public void Judge()
    {
      Text selectButton = this.GetComponentInChildren<Text>();

        if(question.answer == selectButton.text)
        {
          Debug.Log("正解");
          SceneManager.LoadScene("correct");
        }
        else
        {
          if(StartButton.quiznum == 0)
          {
            StartButton.quiznum += 1;
            Debug.Log(StartButton.quiznum);
          }
          Debug.Log("不正解");
          SceneManager.LoadScene("wrong");
        }
    }
}
