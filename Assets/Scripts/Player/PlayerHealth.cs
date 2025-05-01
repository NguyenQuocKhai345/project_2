using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake()
    {
        currentHealth = 1;
        maxHealth = 3;
    }

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < currentHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    public void AddHeart(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}