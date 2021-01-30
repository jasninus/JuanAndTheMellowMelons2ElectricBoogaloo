using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnlockedSpells
{
    private static List<Spell> spells = new List<Spell>();

    private static string actionBarTag = "ActionBar";
    private static SpellActionBar actionBar;

    private static string spellConfigurationsPath = "SpellConfigurations";
    private static GameObject spellConfigurations, unlockedSpellConfigurations;

    private static bool isSetup;

    // Might be necessary to make a deep copy of each spell at some point
    public static List<Spell> GetUnlockedSpells() => new List<Spell>(spells);

    /// <summary>
    /// Unlock a specific class of spell
    /// </summary>
    /// <typeparam name="T">The class of spell to unlock</typeparam>
    public static void AddSpell<T>() where T : Spell
    {
        if (!isSetup)
        {
            SetupSpellConfigurations();
            isSetup = true;
        }

        MonoBehaviour copiedSpell = ComponentUtils.AddComponent(unlockedSpellConfigurations, spellConfigurations.GetComponent<T>());
        spells.Add((Spell)copiedSpell);
        actionBar.PopulateSlotsWithSpells();
    }

    private static void SetupSpellConfigurations()
    {
        spellConfigurations = Resources.Load<GameObject>(spellConfigurationsPath);
        unlockedSpellConfigurations = new GameObject();
        actionBar = GameObject.FindWithTag(actionBarTag).GetComponent<SpellActionBar>();
    }
}
