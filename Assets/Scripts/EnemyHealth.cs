using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]int maxHitPoints = 5;
    [SerializeField]int difficultyRamp = 1;
    int currentHitPoints = 0;

    Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other) {
        currentHitPoints--;
        if(currentHitPoints <= 0) {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
