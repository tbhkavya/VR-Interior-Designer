using UnityEngine;
using UnityEngine.UI;

public class TableToggleManager : MonoBehaviour
{
    public GameObject[] tables;     // All table objects
    public Button[] tableButtons;   // All UI buttons linked to tables

    private int currentActiveIndex = -1;

    public void ShowTable(int index)
    {
        if (currentActiveIndex == index) return;

        // Disable all tables
        for (int i = 0; i < tables.Length; i++)
            tables[i].SetActive(false);

        // Enable chosen table
        tables[index].SetActive(true);
        currentActiveIndex = index;

        // Update button colors
        UpdateButtonColors(index);
    }

    private void UpdateButtonColors(int selectedIndex)
    {
        for (int i = 0; i < tableButtons.Length; i++)
        {
            var colors = tableButtons[i].colors;

            if (i == selectedIndex)
            {
                // Selected button uses its pressed color
                colors.normalColor = colors.pressedColor;
            }
            else
            {
                // Reset to default (you can change this)
                colors.normalColor = colors.disabledColor;
            }

            tableButtons[i].colors = colors;
        }
    }
}
