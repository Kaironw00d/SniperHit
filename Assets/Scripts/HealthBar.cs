using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image fill;

    private void Awake()
    {
        GetComponentInParent<EnemyController>().OnHealthChange += UpdateBar;
    }

    private void UpdateBar(int health)
    {
        if(health <= 0)
            gameObject.SetActive(false);
        
        fill.fillAmount = (float) health / 100;
    }
}
