using UnityEngine;
using UnityEngine.UI;

public class SofaToggleManager : MonoBehaviour
{
    public GameObject[] sofas;         // All sofa objects
    public Button[] sofaButtons;       // All UI buttons linked to sofas

    private int currentActiveIndex = -1;

    public void ShowSofa(int index)
    {
        if (currentActiveIndex == index) return;

        // Disable all sofas
        for (int i = 0; i < sofas.Length; i++)
            sofas[i].SetActive(false);

        // Enable chosen sofa
        sofas[index].SetActive(true);
        currentActiveIndex = index;

        // Update button colors
        UpdateButtonColors(index);
    }

    private void UpdateButtonColors(int selectedIndex)
    {
        for (int i = 0; i < sofaButtons.Length; i++)
        {
            var colors = sofaButtons[i].colors;

            if (i == selectedIndex)
            {
                // Use the Button's "Pressed Color" as selected highlight
                colors.normalColor = colors.pressedColor;
            }
            else
            {
                // Reset to default normal color
                colors.normalColor = colors.disabledColor;
                // OR: assign your own default normal color here
            }

            sofaButtons[i].colors = colors;
        }
    }
}
