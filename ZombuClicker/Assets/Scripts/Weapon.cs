using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Unity.Mathematics;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    Zombie zombie;
    public GameObject popUPDamagePrefab;
    public SpawnerZombu spawnerZombu;

    public TMP_Text popUpText;
    public GameObject ParentpopUpText;
    [SerializeField] public int damage = 5;
    FlashEffect fleff;
    [SerializeField] public int hitCount = 0;
    public SoundEffectsPlayer sfxPlayer;

    void Start()
    {
        spawnerZombu = GameObject.Find("SpawnerZombu").GetComponent<SpawnerZombu>();
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
        fleff = GameObject.Find("Zombu").GetComponent<FlashEffect>();
        popUpText.text = damage.ToString();
        sfxPlayer = GameObject.Find("Canvas").GetComponent<SoundEffectsPlayer>();
    }

    public void Attack()
    {
        hitCount = hitCount + 1;
        zombie.currentHealth = zombie.currentHealth - damage;
        // Instantiate(popUPDamagePrefab, transform.position, quaternion.identity);

        fleff.Flash();

        if (zombie.currentHealth <= 0)
        {
            spawnerZombu.Die();
            spawnerZombu.SpawnZom();
        }
    }
}
