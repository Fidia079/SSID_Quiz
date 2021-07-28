using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{

    public void Judge()
    {
      Text selectButton = this.GetComponentInChildren<Text>();

        if(question.answer == selectButton.text)
        {
          Debug.Log("正解");
        }
        else
        {
          Debug.Log("不正解");
        }
    }
}
