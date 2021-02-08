using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour, ISwipped
{
    int type = 0;

    public void OnSwipe(SwipeEventArgs args)
    {
        if(args.SwipeDirection == SwipeDirections.LEFT)
        {
            type--;
        }
        else if (args.SwipeDirection == SwipeDirections.RIGHT)
        {
            type++;
        }

        if (type < 0) type = 2;
        else if (type > 2) type = 0;

        switch (type)
        {
            case 0: 
                PlayerManager.Instance.ChangeWeapon(WeaponType.Arrow1); 
                break;

            case 1:
                PlayerManager.Instance.ChangeWeapon(WeaponType.Arrow2);
                break;

            case 2:
                PlayerManager.Instance.ChangeWeapon(WeaponType.Arrow3);
                break;
        }
    }
}
