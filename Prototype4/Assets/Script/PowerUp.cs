using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create public array selection for PowerUp so that other script can use

public enum PowerUpSelection { None, Push, Bullet}
public class PowerUp : MonoBehaviour
{
    public PowerUpSelection powerUpType;
}
