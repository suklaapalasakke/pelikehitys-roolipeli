using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;

    public int experience;
    public int hitpoints;
    public int coins;

    public TMP_Text ExperienceText;
    public TMP_Text HitPointText;
    public TMP_Text CoinText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddExperience(int amount)
    {
        experience += amount;

        if (experience < 0)
            experience = 0;

        UpdateUI();
    }

    public void AddHealth(int amount)
    {
        hitpoints += amount;

        if (hitpoints < 0)
            hitpoints = 0;

        UpdateUI();
    }

    public int RemoveHealth(int damageAmount)
    {
        hitpoints -= damageAmount;

        if (hitpoints < 0)
            hitpoints = 0;

        UpdateUI();
        return hitpoints;
    }

    public int AddMoney(int coinAmount)
    {
        coins += coinAmount;

        if (coins < 0)
            coins = 0;

        UpdateUI();
        return coins;
    }

    public bool TakeMoney(int coinAmount)
    {
        if (coins >= coinAmount)
        {
            coins -= coinAmount;
            UpdateUI();
            return true;
        }

        return false;
    }

    void UpdateUI()
    {
        if (ExperienceText != null)
            ExperienceText.text = "XP: " + experience;

        if (HitPointText != null)
            HitPointText.text = "HP: " + hitpoints;

        if (CoinText != null)
            CoinText.text = "Coins: " + coins;
    }
}