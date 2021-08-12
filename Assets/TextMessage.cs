using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextMessage : MonoBehaviour
{
    [SerializeField]
    Text scenarioMessage;
    List<Scenario> scenarios = new List<Scenario>();

    [SerializeField]
    Transform buttonPanel;

    [SerializeField]
    Button optionButton;

    Scenario currentScenario;
    Scenario scenario01;
    int index = 0;
    HashSet<string> items = new HashSet<string>();

    class Scenario
    {
      public string ScenarioID;
      public List<string> Texts = new List<string>();
      public List<Option> Options = new List<Option>();
      public string NextScenarioID;
    }

    class Option
    {
      public string Text;
      public Action action;
      public Func<bool> IsFlagOK = () => {return true;};
    }

    Scenario scenario02;
    bool isCheckedKey = false;

    void Start()
    {
      var scenario01 = new Scenario()
      {
        ScenarioID = "scenario01",
        Texts = new List<string>()
        {
          "(良し、取り敢えずWi-Fiを繋げたぞ。)",
          "(信頼できるかどうかは分からないが)"
        },
        NextScenarioID = "scenario02"
      };


      var scenario02 = new Scenario()
      {
        ScenarioID = "scenario02",
        Texts = new List<string>()
        {
          "(教えて貰ったYouTubeの動画を見るか...？)",
        },
        Options = new List<Option>
        {
          new Option()
          {
            Text = "見てみる",
            action = LookVideo
          },
          new Option()
          {
            Text = "見ない",
            action = NoLookVideo
          }
        }
      };
      scenarios.Add(scenario02);
      SetScenario(scenario01);
    }

    public void LookVideo()
    {
      var scenario = new Scenario();
      scenario.NextScenarioID = "scenario02";
      scenario.Texts.Add("まぁ動画ぐらい大丈夫だろう。");
      SetScenario(scenario);
    }

    public void NoLookVideo()
    {
      var scenario = new Scenario();
      scenario.NextScenarioID = "scenario02";
      scenario.Texts.Add("別に緊急性があるわけでもないし、後で見れば良いか。");
      SetScenario(scenario);
    }

    void Update()
    {
      if(currentScenario != null)
      {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("return"))
        {
          if(EventSystem.current.IsPointerOverGameObject())
          {
            return;
          }
          if(buttonPanel.GetComponentsInChildren<Button>().Length < 1)
          {
            SetNextMessage();
          }
        }
      }
    }

    void SetScenario(Scenario scenario)
    {
      currentScenario = scenario;
      scenarioMessage.text = currentScenario.Texts[0];
      if(currentScenario.Options.Count > 0)
      {
        SetNextMessage();
      }
    }

    void SetNextMessage()
    {
      if(currentScenario.Texts.Count > index + 1)
      {
        index++;
        scenarioMessage.text = currentScenario.Texts[index];
      }
      else
      {
        ExitScenario();
      }
    }

    void ExitScenario()
    {
      index = 0;

      if(currentScenario.Options.Count > 0)
      {
        SetOptions();
      }

      else
      {
        scenarioMessage.text = "";
        var nextScenario = scenarios.Find(s => s.ScenarioID == currentScenario.NextScenarioID);
        if(nextScenario != null)
        {
          SetScenario(nextScenario);
        }
        else
        {
          currentScenario = null;
        }
      }

    }

    void SetOptions()
    {
      foreach(Option o in currentScenario.Options)
      {
        if(o.IsFlagOK())
        {
          Button b = Instantiate(optionButton);
          Text text = b.GetComponentInChildren<Text>();
          text.text = o.Text;
          b.onClick.AddListener(() => o.action());
          b.onClick.AddListener(() => ClearButtons());
          b.transform.SetParent(buttonPanel, false);
        }
      }
    }

    void ClearButtons()
    {
      foreach(Transform t in buttonPanel)
      {
        Destroy(t.gameObject);
      }
    }

}
