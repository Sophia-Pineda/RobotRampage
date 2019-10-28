using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : Gun
{
    protected override void update()
    {
        base.update();
        /*Shotgun & pistol have semi-auto fire rate*/
        Debug.Log("pistol broooo");
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime)
            > fireRate )
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
