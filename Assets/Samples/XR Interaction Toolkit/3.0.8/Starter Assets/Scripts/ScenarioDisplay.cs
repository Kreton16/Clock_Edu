using UnityEngine;
using TMPro;

public class ScenarioDisplay : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshPro scenarioText;

    [System.Serializable]
    public class Scenario
    {
        public string text;
        public string requiredTag; // тег взуття, яке потрібно
    }

    public Scenario[] scenarios;

    [HideInInspector]
    public string currentCorrectTag;

    public void ShowRandomScenario()
    {
        if (scenarioText == null || scenarios.Length == 0)
            return;

        int index = Random.Range(0, scenarios.Length);
        scenarioText.text = scenarios[index].text;
        currentCorrectTag = scenarios[index].requiredTag;
    }

    public void ShowSuccessMessage()
    {
        scenarioText.text = "Вітаю, ти правильно все поставив!";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowRandomScenario();
        }
    }
}
