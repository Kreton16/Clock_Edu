using UnityEngine;

[System.Serializable]
public class ClockTask
{
    public Sprite clockImage; // Картинка аналогового годинника
    [Range(1, 12)] public int correctHour;   // Правильна година (1-12)
    [Range(0, 45)] public int correctMinute; // Правильна хвилина (0, 15, 30, 45)
}