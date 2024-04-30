using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRestore : MonoBehaviour
{
    [SerializeField]
    float RestoreAmount = 25.0f;
    float RotateSpeed = 25.0f;
    void Update()
    {
        transform.Rotate(transform.up, RotateSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerShooter.PickUpAmmo(RestoreAmount);
        Destroy(gameObject);
    }
}
