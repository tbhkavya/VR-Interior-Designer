using UnityEngine;

public class PanelToggleManager : MonoBehaviour
{
    [Header("Assign panels in the inspector (order matters)")]
    public GameObject[] panels;    // visible and editable in Inspector

    [Header("Optional: index of panel active on start (-1 = none)")]
    public int defaultPanelIndex = 0;

    void Start()
    {
        if (panels == null || panels.Length == 0) return;
        // Clamp default index
        if (defaultPanelIndex >= 0 && defaultPanelIndex < panels.Length)
            ShowPanel(defaultPanelIndex);
        else
            // turn all off if default invalid
            ShowPanel(-1);
    }

    // Call this from your Button OnClick() (pass index)
    public void ShowPanel(int panelIndex)
    {
        if (panels == null) return;

        for (int i = 0; i < panels.Length; i++)
        {
            bool shouldBeActive = (i == panelIndex);
            if (panels[i] != null)
                panels[i].SetActive(shouldBeActive);
        }
    }
}
