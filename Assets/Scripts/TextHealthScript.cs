using TMPro;
using UnityEngine;

public class TextHealthScript : MonoBehaviour
{
    // Variables
    public float healthNumber;

    //components
    private TextMeshProUGUI hpText;
    private PlayerHealthScrip healthScrip;

    void Start()
    {
        //Get the TextMeshPro component
        hpText = GetComponent<TextMeshProUGUI>();

        //get the PlayerHealthScrip component
        healthScrip = FindFirstObjectByType<PlayerHealthScrip>();
    }

    void Update()
    {
        //get the player's current health
        healthNumber = healthScrip.health;

        //Update the UI text
        hpText.text = "HP: " + healthNumber.ToString();
    }
}