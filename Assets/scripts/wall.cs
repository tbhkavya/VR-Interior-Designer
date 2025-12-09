using UnityEngine;

public class WallMaterialColorChanger : MonoBehaviour
{
    [Header("Assign the shared wall material here")]
    public Material wallMaterial;

    public void SetRed()
    {
        if (wallMaterial != null)
            wallMaterial.color = Color.red;
    }

    public void SetBlue()
    {
        if (wallMaterial != null)
            wallMaterial.color = Color.blue;
    }

    public void SetYellow()
    {
        if (wallMaterial != null)
            wallMaterial.color = Color.yellow;
    }
}
