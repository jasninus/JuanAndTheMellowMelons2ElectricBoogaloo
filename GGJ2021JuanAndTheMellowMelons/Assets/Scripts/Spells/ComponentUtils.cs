using System;
using System.Reflection;
using UnityEngine;

public static class ComponentUtils
{
    public static MonoBehaviour AddComponent<T>(GameObject addTo, T componentPrefab) where T : MonoBehaviour
    {
        T e = addTo.AddComponent<T>();
        T copy = componentPrefab.Copy();
        e.GetCopyOf(copy);
        return e;
    }

    public static T GetCopyOf<T>(this Component comp, T other) where T : Component
    {
        Type type = comp.GetType();
        if (type != other.GetType())
        {
            return null; // type mis-match
        }

        CopyToComponent(comp, type, other);

        return comp as T;
    }

    private static void CopyToComponent<T>(Component destination, Type currentType, T other)
    {
        // TODO find out how to also copy members from base class
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
        PropertyInfo[] pInfos = currentType.GetProperties(flags);

        foreach (var pInfo in pInfos)
        {
            if (pInfo.CanWrite)
            {
                try
                {
                    pInfo.SetValue(destination, pInfo.GetValue(other, null), null);
                }
                catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
            }
        }
        FieldInfo[] fInfos = currentType.GetFields(flags);
        foreach (var fInfo in fInfos)
        {
            //fInfo.set
            fInfo.SetValue(destination, fInfo.GetValue(other));
        }

        if (currentType.BaseType != typeof(MonoBehaviour))
        {
            CopyToComponent(destination, currentType.BaseType, other);
        }
    }
}