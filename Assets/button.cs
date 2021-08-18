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
          question.WiFiBool = 1;
        }
        SceneManager.LoadScene("choice-1");
    }
}
