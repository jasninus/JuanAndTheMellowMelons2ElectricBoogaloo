using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatSequence : MonoBehaviour
{
    [SerializeField] private GameObject enemyParent, blockingObjectsParent, rewardItem;

    [SerializeField] private string musicManagerTag = "MusicManager";
    private MusicManager music;

    private void Awake()
    {
        music = GameObject.FindWithTag(musicManagerTag).GetComponent<MusicManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ActivateCombat();
        }
    }

    private void Start()
    {
        DeactivateAllChildren();
    }

    private void DeactivateAllChildren()
    {
        List<GameObject> toActivate = enemyParent.GetComponentsInChildren<Transform>(true).Select(t => t.gameObject).Skip(1).Concat(blockingObjectsParent.GetComponentsInChildren<Transform>(true).Select(t => t.gameObject).Skip(1)).ToList();
        toActivate.Add(rewardItem);

        foreach (GameObject go in toActivate)
        {
            go.SetActive(false);
        }
    }

    public void ActivateCombat()
    {
        music.StartCombatMusic();
        ActivateEnemies();
        SetBlockingObjectsState(true);
    }

    private void ActivateEnemies()
    {
        MBWithCallbacks[] enemyChildren = enemyParent.GetComponentsInChildren<MBWithCallbacks>(true);

        foreach (MBWithCallbacks enemy in enemyChildren)
        {
            enemy.gameObject.SetActive(true);
            enemy.onDestroy += EnemyDied;
        }
    }

    private void EnemyDied(MBWithCallbacks enemy)
    {
        if (enemyParent.GetComponentsInChildren<MBWithCallbacks>(true).Length == 1)
        {
            DeactivateCombat();
        }
    }

    private void SetBlockingObjectsState(bool active)
    {
        GameObject[] blockingChildren = blockingObjectsParent.GetComponentsInChildren<Transform>(true).Select(t => t.gameObject).ToArray();

        foreach (GameObject blocker in blockingChildren)
        {
            blocker.SetActive(active);
        }
    }

    public void DeactivateCombat()
    {
        music.StopCombatMusic();
        SetBlockingObjectsState(false);
        rewardItem.SetActive(true);
        rewardItem.GetComponent<IActivatable>()?.Activate();
    }
}
