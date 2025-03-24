using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Range(1, 100)][SerializeField] private int health;
    public int Health { get => health; set => health = Mathf.Clamp(value, 0, 100); }

    [Range(1,100)][SerializeField] private int attack;
    public int Attack { get => attack; set => attack = Mathf.Clamp(value, 1 ,100); }
    [Range(1,100)][SerializeField] private int defense;
    public int Defense { get => defense; set => defense = Mathf.Clamp(value, 0 ,100); }
    [Range(1,100)][SerializeField] private int critical;
    public int Critical { get => critical; set => critical = Mathf.Clamp(value, 0 ,100); }
    [SerializeField] private int gold = 0;
    public int Gold { get => gold; set => gold = value; }

    
}
