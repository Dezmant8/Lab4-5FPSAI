using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    Camera PlayerCamera;
    float AttackDamage = 20;
    AudioSource audioSource;
    float ShootDelay = 0.5f;
    float LastShootDelay = 0.0f;
    Animator animator;
    public float magazineCapacity = 10;
    public static float totalAmmo = 50;
    public float totalAmmo2;
    public float currentAmmo;
    public float ammount = 10;

    private void Awake()
    {
        totalAmmo2 = totalAmmo;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        totalAmmo2 = totalAmmo;
        

        LastShootDelay = Mathf.Clamp(LastShootDelay - Time.deltaTime, 0, ShootDelay);
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if (Input.GetMouseButton(0) && LastShootDelay == 0)
        {
            LastShootDelay = ShootDelay;
            if (currentAmmo > 0)
                Shoot();
            
        }
    }

    void Shoot()
    {
        currentAmmo -= 1;
        animator.SetTrigger("Shoot");
        audioSource.Play();
        Vector3 pos = new Vector3(PlayerCamera.pixelWidth / 2, PlayerCamera.pixelHeight / 2, 0);
        Ray ray = PlayerCamera.ScreenPointToRay(pos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.GetComponent<AI_Enemy>() != null)
            {
                hit.collider.SendMessage("ChangeHealth", -AttackDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    void Reload()
    {
        float ammoNeeded = magazineCapacity - currentAmmo;
        if (totalAmmo >= ammoNeeded)
        {
            totalAmmo -= ammoNeeded;
            currentAmmo = magazineCapacity;
        }
        else
        {
            currentAmmo += totalAmmo;
            totalAmmo = 0;
        }
        totalAmmo2 = totalAmmo;
    }

    public static void PickUpAmmo(float ammount)
    {
        totalAmmo += ammount;
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("AmmoPickup"))
    //    {
    //        totalAmmo += ammount;
    //        Reload();
    //        Destroy(other.gameObject);
    //    }
    //}
}
