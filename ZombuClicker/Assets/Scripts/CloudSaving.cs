using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using YG;

public class CloudSaving : MonoBehaviour
{
    public Zombie zombie;
    public BaseShield baseShield;
    public Heal heal;
    public FireAspect fireAspect;
    public Autoclicker autoclicker;
    public DamageDoubler damageDoubler;
    public DamageAdder damageAdder;
    public Vampirism vampirism;
    public BaseHPValue baseHPValue;
    public Weapon weapon;

    void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
        baseShield = GameObject.Find("BaseShield").GetComponent<BaseShield>();
        heal = GameObject.Find("Heal").GetComponent<Heal>();
        fireAspect = GameObject.Find("FireAspect").GetComponent<FireAspect>();
        autoclicker = GameObject.Find("Autoclicker").GetComponent<Autoclicker>();
        damageDoubler = GameObject.Find("DamageDoubler").GetComponent<DamageDoubler>();
        damageAdder = GameObject.Find("DamageAdder").GetComponent<DamageAdder>();
        vampirism = GameObject.Find("Vampirism").GetComponent<Vampirism>();
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>();
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();

        if(YandexGame.SDKEnabled == true)
        {
            LoadSaveCloud();
        }
    }

    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;
    private void OnDisable() => YandexGame.GetDataEvent -= LoadSaveCloud;

    public void LoadSaveCloud()
    {
        // items
        baseShield.isOwned = YandexGame.savesData.baseShieldIsOwned;
        heal.isOwned = YandexGame.savesData.healIsOwned;
        fireAspect.isOwned = YandexGame.savesData.fireAspectIsOwned;
        autoclicker.isOwned = YandexGame.savesData.autoclickerIsOwned;
        damageDoubler.isOwned = YandexGame.savesData.damageDoublerIsOwned;
        damageAdder.isOwned = YandexGame.savesData.damageAdderIsOwned;
        vampirism.isOwned = YandexGame.savesData.vampirismIsOwned;

        // class Zombie
        zombie.CoinsBalance = YandexGame.savesData.money;
        zombie.MinCoin = YandexGame.savesData.MinCoin;
        zombie.MaxCoin = YandexGame.savesData.MaxCoin;
        zombie.zwaHealth = YandexGame.savesData.zwaHealth;
        zombie.sZombie = YandexGame.savesData.sZombie;
        zombie.jnbHealth = YandexGame.savesData.jnbHealth;
        zombie.jnzwaHealth = YandexGame.savesData.jnzwaHealth;
        zombie.jnszHealth = YandexGame.savesData.jnszHealth;

        // damage adder
        weapon.damage = YandexGame.savesData.weaponDamage;
        damageAdder.quantity = YandexGame.savesData.damageAdderQuantity;

        // vamp
        zombie.HPRegenBase = YandexGame.savesData.zombieHPRegenBase;

        // shield
        baseHPValue.Armor = YandexGame.savesData.baseHPValueArmor;

        // heal
        baseHPValue.BaseHealth = YandexGame.savesData.baseHPValue;

        // autoclicker
        autoclicker.quantity = YandexGame.savesData.autoclickerQuantity;
        autoclicker.damage = YandexGame.savesData.autoclickerDamage;
    }

    public void MySave()
    {
        // item status saves
        YandexGame.savesData.baseShieldIsOwned = baseShield.isOwned;
        YandexGame.savesData.healIsOwned = heal.isOwned;
        YandexGame.savesData.fireAspectIsOwned = fireAspect.isOwned;
        YandexGame.savesData.autoclickerIsOwned = autoclicker.isOwned;
        YandexGame.savesData.damageAdderIsOwned = damageAdder.isOwned;
        YandexGame.savesData.damageDoublerIsOwned = damageDoubler.isOwned;
        YandexGame.savesData.vampirismIsOwned = vampirism.isOwned;
        
        // class Zombie fields 
        YandexGame.savesData.money = zombie.CoinsBalance;
        YandexGame.savesData.MinCoin = zombie.MinCoin;
        YandexGame.savesData.MaxCoin = zombie.MaxCoin;
        YandexGame.savesData.zwaHealth = zombie.zwaHealth;
        YandexGame.savesData.sZombie = zombie.sZombie;
        YandexGame.savesData.jnbHealth = zombie.jnbHealth;
        YandexGame.savesData.jnzwaHealth = zombie.jnzwaHealth;
        YandexGame.savesData.jnszHealth = zombie.jnszHealth;

        // damage adder
        YandexGame.savesData.weaponDamage = weapon.damage;
        YandexGame.savesData.damageAdderQuantity = damageAdder.quantity;

        // vampirism
        YandexGame.savesData.zombieHPRegenBase = zombie.HPRegenBase;

        // shield
        YandexGame.savesData.baseHPValueArmor = baseHPValue.Armor;

        // heal
        YandexGame.savesData.baseHPValue = baseHPValue.BaseHealth;

        // fire is developed so it'll check if its owned on start

        // autoclicker is also checked on start
        YandexGame.savesData.autoclickerQuantity = autoclicker.quantity;
        YandexGame.savesData.autoclickerDamage = autoclicker.damage;

        // damage doubler



        YandexGame.SaveProgress();
    }

    // call on restarting the game
    public void DefaultVariables()
    {
        baseShield.isOwned = false;
        heal.isOwned = false;
        fireAspect.isOwned =  false;
        autoclicker.isOwned = false;
        damageDoubler.isOwned = false;
        damageAdder.isOwned = false;
        vampirism.isOwned = false;
        zombie.CoinsBalance = 0;
        zombie.MinCoin = 2;
        zombie.MaxCoin = 7;
        zombie.zwaHealth = 200;
        zombie.sZombie = 150;
        zombie.jnbHealth = 10000;
        zombie.jnzwaHealth = 500;
        zombie.jnszHealth = 600;
        baseHPValue.BaseHealth = 100;
        baseHPValue.Armor = 30;

        weapon.damage = 5;
        damageAdder.quantity = 0;
        autoclicker.quantity = 0;
        autoclicker.damage = 1;
    }
}
