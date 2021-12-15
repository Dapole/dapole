using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Blue_potion : MonoBehaviour
{
    public float cooldown;
    public bool isCooldown;

    private Image shieldImage;
    private PlayerMovement player;

    void Start()
    {
        shieldImage = GetComponent<Image>();
        player = GetComponent<PlayerMovement>();
        isCooldown = true;
    }

    void Update()
    {
        if (isCooldown)
        {
            shieldImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (shieldImage.fillAmount <= 0)
            {
                shieldImage.fillAmount = 1;
                isCooldown = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void ResetTimer()
    {
        shieldImage.fillAmount = 1;
    }

    public void ReduceTime(int damage)
    {
        shieldImage.fillAmount += damage / 5f;
    }
}
