using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class question : MonoBehaviour
{
    TextAsset SSIDCSV;
    public static List<string[]> csvData = new List<string[]>();
    public static List<int> qnum = new List<int>();
    public int csvrow;
    public static string answer;
    private int k = 0;
    private int qrand = 0;
    // Start is called before the first frame update
    void Start()
    {
        int qcount = 0; //gamestart.getqCount();
        if(qcount == 0)
        {
          SSIDCSV = Resources.Load("SSIDCSV") as TextAsset;
          StringReader reader = new StringReader(SSIDCSV.text);
          while(reader.Peek() != -1)
          {
            string line = reader.ReadLine();
            csvData.Add(line.Split(','));
            csvrow++;
          }

          for (int i = 1; i <= csvrow-1; i++) {
            qnum.Add(i);
          }

          qnum = qnum.OrderBy(a => System.Guid.NewGuid()).ToList();
          csvrow = 0;
        }
        qrand = qnum[qcount];
        QuestionLabelSet();
        AnswerLabelSet();
    }

    private void QuestionLabelSet()
    {
        csvData[k] = csvData[qrand];
        Text qLabel = GameObject.Find("Canvas/Question").GetComponent<Text>();
        qLabel.text = "SSID : " + csvData[k][0];
    }

    private void AnswerLabelSet()
    {
        string[] array = new string[]{csvData[k][1],csvData[k][2],csvData[k][3],csvData[k][4],csvData[k][5],csvData[k][6]};
        array = array.OrderBy(x => System.Guid.NewGuid()).ToArray();

        for(int j = 1; j <= 6; j++)
        {
          Text aLabel = GameObject.Find("Canvas/OptionButton"+j).GetComponentInChildren<Text>();
          aLabel.text = array[j-1];
          answer = csvData[k][1];
        }
    }
}
