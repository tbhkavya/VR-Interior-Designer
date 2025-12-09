using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TagAndColorChanger : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField tagInputField;
    public TMP_InputField colorInputField;
    public Button applyButton;

    void Start()
    {
        if (applyButton != null)
            applyButton.onClick.AddListener(ApplyColorChange);
    }

    void ApplyColorChange()
    {
        string targetTag = tagInputField.text.Trim();
        string colorName = colorInputField.text.Trim();

        if (string.IsNullOrEmpty(targetTag) || string.IsNullOrEmpty(colorName))
        {
            Debug.LogWarning("Please enter both a tag and a color.");
            return;
        }

        // Find all objects with the given tag
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);

        if (taggedObjects.Length == 0)
        {
            Debug.LogWarning($"No objects found with tag '{targetTag}'.");
            return;
        }

        // Parse color
        Color newColor;
        if (!TryGetColor(colorName, out newColor))
        {
            Debug.LogWarning($"Invalid color name '{colorName}'. Try red, blue, green, yellow, etc.");
            return;
        }

        // Apply color to all tagged objects
        foreach (GameObject obj in taggedObjects)
        {
            Renderer rend = obj.GetComponent<Renderer>();
            if (rend != null)
                rend.material.color = newColor;
        }

        Debug.Log($"✅ Changed color of all '{targetTag}' objects to {colorName}.");
    }

    bool TryGetColor(string name, out Color color)
    {
        // Try HTML color (#FF0000, etc.)
        if (ColorUtility.TryParseHtmlString(name, out color))
            return true;

        // Try basic color names
        switch (name.ToLower())
        {
            case "red": color = Color.red; return true;
            case "green": color = Color.green; return true;
            case "blue": color = Color.blue; return true;
            case "yellow": color = Color.yellow; return true;
            case "black": color = Color.black; return true;
            case "white": color = Color.white; return true;
            case "cyan": color = Color.cyan; return true;
            case "magenta": color = Color.magenta; return true;
            case "gray": color = Color.gray; return true;
            default: color = Color.clear; return false;
        }
    }
}
