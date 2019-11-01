using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int armor;
    public GameUI gameUI;
    public Game game;
    public AudioClip playerDead;

    private GunEquipper gunEquipper;
    private Ammo ammo;


    
    void Start()
    {
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
        
    }

    public void TakeDamage(int amount) // G  -- typo in book? won't run***
    {
        int healthDamage = amount;
        
        if (armor > 0 )
        {
              int effectiveArmor = armor * 2;
              effectiveArmor -= healthDamage;

          /*if armor, no need to process health dmg.*/

            if (effectiveArmor > 0 )
            {
             armor = effectiveArmor / 2;

             gameUI.SetArmorText(armor);

             return;
            }
            armor = 0;
            gameUI.SetArmorText(armor);

        }

         health -= healthDamage;

        // Debug.Log("Health is  " + health); replace with
        gameUI.SetHealthText(health);

        if (health <=0 )
        {
            //Debug.Log("Game Over"); replaced with
            GetComponent<AudioSource>().PlayOneShot(playerDead);
            game.GameOver();
        } 
    }
    private void pickupHealth()
    {
        health += 50;
        if(health > 200)
        {
            health = 200;
        }

        gameUI.SetPickUpText("+50 Health!!");
        gameUI.SetHealthText(health);

    }

    private void pickupArmor()
    {
        armor += 15;
        gameUI.SetPickUpText("Armor picked up +15 armor");
        gameUI.SetArmorText(armor);
        
    }
    //2
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        gameUI.SetPickUpText("AssaultRifle Ammo +50 ammo!!");
        if (gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)
        {
           gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    }

    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);

        gameUI.SetAmmoText(ammo.GetAmmo("Pistol ammo +20 !!"));
        if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }

    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);

        gameUI.SetAmmoText(ammo.GetAmmo("Shotgun ammo +10 !!"));
        if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
        }
    }

    public void PickUpItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.PickupArmor:
                pickupArmor();
                break;
            case Constants.PickupHealth:
                pickupHealth();
                break;
            case Constants.PickupAssaultRifleAmmo:
                pickupAssaultRifleAmmo();
                break;
            case Constants.PickupPistolAmmo:
                pickupPistolAmmo();
                break;
            case Constants.PickupShotgunAmmo:
                pickupShotgunAmmo();
                break;

            default:
                Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
}
