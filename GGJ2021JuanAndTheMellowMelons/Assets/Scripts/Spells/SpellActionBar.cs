using UnityEngine;
using System.Collections.Generic;

public class SpellActionBar : MonoBehaviour
{
    [SerializeField] private string playerTag;
    private SpellCaster playerCaster;

    // Currently assuming that slots has a RectTransform;
    [SerializeField, Header("Slots")] private GameObject slotPrefab;

    [SerializeField] private uint slotCount;
    [SerializeField] private Vector2 slotSize;
    [SerializeField] private Vector2 slotPadding;

    private List<SpellSlot> slots = new List<SpellSlot>();

    private void Start()
    {
        playerCaster = GameObject.FindWithTag(playerTag).GetComponent<SpellCaster>();

        SpawnSlots();
        PopulateSlotsWithSpells();
    }

    private void SpawnSlots()
    {
        slots.Clear();

        for (int i = 1; i <= slotCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, transform);
            RectTransform slotTrans = slot.GetComponent<RectTransform>();

            if (slotCount % 2 == 0)
            {
                float x = (slotSize.x / 2 + slotPadding.x / 2 + (i - 1) / 2 * (slotSize.x + slotPadding.x)) * (i % 2 == 0 ? -1 : 1);
                slotTrans.anchoredPosition = new Vector2(x, slotSize.y / 2 + slotPadding.y);
            }
            else
            {
                slotTrans.anchoredPosition = new Vector2(i / 2 * (slotSize.x + slotPadding.x) * (i % 2 == 0 ? -1 : 1), slotSize.y / 2 + slotPadding.y);
            }

            slots.Add(slot.GetComponent<SpellSlot>());
        }
    }

    private void PopulateSlotsWithSpells()
    {
        List<Spell> spells = UnlockedSpells.GetUnlockedSpells();

        if (spells.Count > slots.Count)
        {
            Debug.LogError("More spells than slots. Something is wrong");
            return;
        }

        for (int i = 0; i < spells.Count; i++)
        {
            slots[i].Spell = spells[i];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSpell(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSpell(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetSpell(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSpell(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetSpell(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetSpell(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetSpell(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetSpell(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SetSpell(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SetSpell(9);
        }
    }

    private void SetSpell(int slotIndex)
    {
        if (slotIndex >= slots.Count)
        {
            Debug.Log("Selected spell index is out of range");
            return;
        }

        playerCaster.SetSpell(slots[slotIndex].Spell);
    }
}