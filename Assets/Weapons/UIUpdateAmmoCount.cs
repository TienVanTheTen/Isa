using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdateAmmoCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ammoCountTXT;
    [SerializeField]
    private TextMeshProUGUI magCapacityTXT;
    public void UpdateUI(int currentAmmoCount, int magCapacity)
    {
        ammoCountTXT.text = currentAmmoCount.ToString();
        magCapacityTXT.text = magCapacity.ToString();
    }
}
