using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class SimpleColorChanger : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField colorInput; // Assign your TMP_InputField
    public Button applyButton;        // Assign a Button to trigger color change

    [Header("Objects & Material")]
    public List<GameObject> targetObjects; // Objects to change color
    public Material materialToChange;      // Material to update

    void Start()
    {
        if (applyButton != null)
            applyButton.onClick.AddListener(ChangeColor);

        if (materialToChange == null)
            Debug.LogWarning("Material not assigned!");
        if (targetObjects.Count == 0)
            Debug.LogWarning("No target objects assigned!");
    }

    public void ChangeColor()
    {
        string input = colorInput.text.Trim().ToLower();
        if (string.IsNullOrEmpty(input))
        {
            Debug.LogWarning("Please enter a color!");
            return;
        }

        Color newColor;
        if (!TryGetColor(input, out newColor))
        {
            Debug.LogWarning("Unknown color: " + input);
            return;
        }

        // Apply color to the material
        materialToChange.color = newColor;

        // Apply material to all target objects
        foreach (var obj in targetObjects)
        {
            Renderer rend = obj.GetComponent<Renderer>();
            if (rend != null)
                rend.material = materialToChange;
        }
    }

    private bool TryGetColor(string colorName, out Color color)
    {
        // Try hex code first
        if (ColorUtility.TryParseHtmlString(colorName, out color))
            return true;

        // Named colors
        switch (colorName)
        {
            case "red": color = Color.red; return true;
            case "blue": color = Color.blue; return true;
            case "green": color = Color.green; return true;
            case "yellow": color = Color.yellow; return true;
            case "white": color = Color.white; return true;
            case "black": color = Color.black; return true;
            case "cyan": color = Color.cyan; return true;
            case "magenta": color = Color.magenta; return true;
            case "gray": color = Color.gray; return true;
            default: color = Color.white; return false;
        }
    }
}
