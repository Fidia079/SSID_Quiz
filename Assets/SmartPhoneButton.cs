using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhoneButton : MonoBehaviour
{
    public static int PhoneTime = 0;
    public GameObject Smart;

    void start()
    {
        Smart = GameObject.Find("Canvas/SmartPhone");
    }

    public void UsePhone()
    {
      PhoneTime += 1;

      if(PhoneTime % 2 == 1)
      {
        Smart.transform.position = new Vector3(5, 0, 0);
        Debug.Log(PhoneTime);
      }else{
        Smart.transform.position = new Vector3(20, 0, 0);
        Debug.Log(PhoneTime);
      }
    }
}
