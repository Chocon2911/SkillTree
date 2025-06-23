using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredPointsToUnlockSO : ScriptableObject, Condition
{
    public int requiredPoints = 15;
    public int indexRowBehindCurr = 1;

    bool Condition.IsGood()
    {
        return true;
    }
}
