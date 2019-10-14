using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // SCENES

    public const string SceneBattle = "Battle";
    public const string SceneMenu = "MainMenu";
    //GUNS
    public const string Pistol = "Pistol";
    public const string Shotgun = "Shotgun";
    public const string AssaultRifle = "AssaultRifle";
    //BOTS
    public const string RedRobot = "RedRobot";
    public const string BlueRobot = "BlueRobot";
    public const string YellowRobot = "YellowRobot";
    //PICKups
    public const int PickupPistolAmmo = 1;
    public const int PickupAssaultRifleAmmo = 2;
    public const int PickupShotgunAmmo = 3;
    public const int PickupHealth = 4;
    public const int PickupArmor = 5;
    //misc
    public const string Game = "Game";
    public const float CameraDefaultZoom = 60.0f;

    public static readonly int[] AllPickupTypes = new int[5]
    {
        PickupPistolAmmo,
        PickupAssaultRifleAmmo,
        PickupShotgunAmmo,
        PickupHealth,
        PickupArmor

    };
}
