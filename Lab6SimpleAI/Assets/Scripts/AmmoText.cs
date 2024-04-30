using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    private PlayerShooter playerShooter;

    private void Start()
    {
        playerShooter = FindObjectOfType<PlayerShooter>();
    }
    private void Update()
    {
        ammoText.text = $"{playerShooter.currentAmmo}/{PlayerShooter.totalAmmo}";
    }
}
