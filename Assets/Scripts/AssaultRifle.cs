using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
    protected override void update()
    {
        base.update();
        /* Auto-Fire */
        if (Input.GetMouseButton(0) && (Time.time - lastFireTime > fireRate))
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
