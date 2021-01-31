using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatSequence : MonoBehaviour
{
    [SerializeField] private GameObject enemyParent, blockingObjectsParent, rewardItem;

    [SerializeField] private string musicManagerTag = "MusicManager";
    private MusicManager music;

    //CameraSwap
    public Camera camera1;
    public Camera cameraCombat;

    private void Awake()
    {
        GameObject musicManager = GameObject.FindWithTag(musicManagerTag);
        if (musicManager)
        {
            music = musicManager.GetComponent<MusicManager>();
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        ActivateCombat();
    //    }
    //}

    private void Start()
    {
        DeactivateAllChildren();
        rewardItem.GetComponent<IActivatable>().AddToCallback(ActivateCombat);
        camera1.GetComponent<Camera>().enabled = !camera1.GetComponent<Camera>().enabled;
    }

    private void DeactivateAllChildren()
    {
        List<GameObject> toActivate = enemyParent.GetComponentsInChildren<Transform>(true).Select(t => t.gameObject).Skip(1)/*.Concat(blockingObjectsParent.GetComponentsInChildren<Transform>(true).Select(t => t.gameObject).Skip(1))*/.ToList();
        //toActivate.Add(rewardItem);

        foreach (GameObject go in toActivate)
        {
            go.SetActive(false);
        }
    }

    public void ActivateCombat()
    {
        music?.StartCombatMusic();
        ActivateEnemies();
        SetBlockingObjectsState(true);

        print("i'm in 2");
        camera1.GetComponent<Camera>().enabled = false;
        cameraCombat.GetComponent<Camera>().enabled = true;
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
        music?.StopCombatMusic();
        SetBlockingObjectsState(false);
        rewardItem.SetActive(true);
        rewardItem.GetComponent<IActivatable>()?.Activate();

        print("i'm in 1");
        camera1.GetComponent<Camera>().enabled = true;
        cameraCombat.GetComponent<Camera>().enabled = false;
    }
}
