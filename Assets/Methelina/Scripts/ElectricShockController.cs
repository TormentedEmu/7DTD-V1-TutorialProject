using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ElectricShockToggle : MonoBehaviour
{
    public Material[] materials; // Array of materials to which the shader is applied
    public bool enableShock = false; // Flag to enable/disable the effect

    private void OnValidate()
    {
        ToggleElectricShock(enableShock);
    }

    private void ToggleElectricShock(bool enable)
    {
        string keyword = "_ELECTRIC_SHOCK_ON";
        foreach (var material in materials)
        {
            if (enable)
            {
                material.EnableKeyword(keyword); // Enable the keyword if the flag is true
            }
            else
            {
                material.DisableKeyword(keyword); // Disable the keyword if the flag is false
            }
        }
    }
}