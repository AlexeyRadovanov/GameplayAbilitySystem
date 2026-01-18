using UnityEngine;

public static class GameDebug
{
    public static bool EnableLogs = true;

    public static void Log(string message, Object context = null)
    {
        if (!EnableLogs) return;
        Debug.Log($"[Game] {message}", context);
    }

    public static void Warning(string message, Object context = null)
    {
        Debug.LogWarning($"[Game] {message}", context);
    }
}