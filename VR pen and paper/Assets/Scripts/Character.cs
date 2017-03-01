using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public int HP;
    public int attack; // attack is a modifier for the attack roll
    public int dmg; // Modifier applied to damage rolls
    public int weaponDmg; // This is the die size used for damage
    public int AC; 
    Random random = new Random();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetHP() // HP getter
    {
        return HP;
    }

    public void SetHP(int _HP) // HP setter
    {
        HP = _HP;
    }

    int RollRandom(int max)
    {
        return (int)Random.Range(1, max); //Assumes the minimum value to be 1
        // WHOOPS! Check if the typecasting can roll 1 ... of if it rounds up. 
    }

    void PerformAttack(Character attacker, Character defender) //Standard attack
    {
        int tempHit = attacker.RollRandom(20);
        if (tempHit == 20)
        {
            DealDamage(attacker, defender, true);
        }
        else if (tempHit+attack >= defender.AC)
        {
            DealDamage(attacker, defender, false);

        }  
    }

    void DealDamage(Character attacker, Character defender, bool crit)
    {
        int tempDmg; 
        if (crit == true) {
            tempDmg = attacker.RollRandom(weaponDmg) + attacker.RollRandom(weaponDmg) + dmg;
        }
        else
        {
            tempDmg = attacker.RollRandom(weaponDmg) + dmg;
        }
        
        if (defender.GetHP() - tempDmg <= 0)
        {
            defender.die();
        }
        else
        {
            defender.SetHP(defender.GetHP() - tempDmg);
        }
    }

    void die()
    {

    }
}
