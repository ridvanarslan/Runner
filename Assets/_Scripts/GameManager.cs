using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("LEVEL SETTINGS")]
    [SerializeField] [Range(10,25)] private int maxEnemyAmountInLevel;
    [SerializeField] private List<Enemy_AI> enemyPool;
    [SerializeField] private int activeCloneAmount;
    [SerializeField]public bool IsLastFightStarted;
    public int ActiveCloneAmount
    {
        get => activeCloneAmount;
        set => activeCloneAmount = value;
    }
    public int ActiveEnemyAmount
    {
        get => maxEnemyAmountInLevel;
        set => maxEnemyAmountInLevel = value;
    }
    
    private void Start() => CreateEnemies();

    private void CreateEnemies()
    {
        for (int i = 0; i < maxEnemyAmountInLevel; i++)
        {
            foreach (var item in enemyPool.Where(enemy => !enemy.gameObject.activeInHierarchy))
            {
                item.gameObject.SetActive(true);
                break;
            }
        }
    }
    public void TriggerClones()
    {
        foreach (var enemy in enemyPool.Where(x => x.gameObject.activeInHierarchy))
        {
            enemy.TriggerAnimation();
        }
    }
    
    public void GameOver()
    {
        //TODO: GameOver
    }


}
