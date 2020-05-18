using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    [SerializeField] private Text Name;
    [SerializeField] private Text Level;
    [SerializeField] private Text Experience;
    [SerializeField] private Text Life;
    [SerializeField] private Text Hungry;
    [SerializeField] private Text Happy;
    [SerializeField] private Text Clean;

    private readonly string nameText = "NAME";
    private readonly string levelText = "LEVEL";
    private readonly string experienceText = "EXPERIENCE";
    private readonly string lifeText = "LIFE";
    private readonly string hungryText = "HUNGRY";
    private readonly string happyText = "HAPPY";
    private readonly string cleanText = "CLEAN";





    public void UpdateUI()
    {
        Name.text = $"{nameText}:";
        Level.text = $"{levelText}:";
        Experience.text = $"{experienceText}:";
        Life.text = $"{lifeText}:";
        Hungry.text = $"{hungryText}:";
        Happy.text = $"{happyText}:";
        Clean.text = $"{cleanText}:";
    }

}
