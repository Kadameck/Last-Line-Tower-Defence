using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public static class UI_Utils
{
    public static LTDescr ScrollInDirection(RectTransform objectToMove, Vector2 directionNormal, float distance, float timeInSeconds)
    {
        Vector2 destination = objectToMove.anchoredPosition + (directionNormal * distance);

        LeanTween.moveX(objectToMove, destination.x, timeInSeconds);
        return LeanTween.moveY(objectToMove, destination.y, timeInSeconds);
    }
}
