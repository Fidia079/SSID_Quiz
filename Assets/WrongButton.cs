using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongButton : MonoBehaviour
{
    public void returnque()
    {
      SceneManager.LoadScene("Start");
    }
}
