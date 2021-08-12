using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatisfiedText : MonoBehaviour
{
    public static int SatisGauge = 0;
    // Start is called before the first frame update
    void Start()
    {
        Text SatisLabel = GameObject.Find("Canvas/Satisfied").GetComponent<Text>();
        SatisLabel.text = SatisGauge + "%";
    }
}
