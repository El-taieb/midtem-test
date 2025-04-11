using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    public Light targetLight; // Assign your Point Light in the Inspector

    public void Toggle()
    {
        if (targetLight != null)
        {
            targetLight.enabled = !targetLight.enabled;
        }
        else
        {
            Debug.LogError("Target Light is not assigned in ToggleLight script!");
            Debug.Log("Button Clicked: Toggle function called.");

        }
    }
}
