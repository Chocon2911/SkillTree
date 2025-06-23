using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnoughPointsInRow", menuName = "SO/Requirement/EnoughPointsInRow")]
public class EnoughPointsInRowSO : ScriptableObject, Requirement
{
    public int requiredPoints = 15;
    public int checkedRowIndex;

    bool Requirement.IsGood(List<Row> rows)
    {
        return rows[checkedRowIndex].GetTotalPoints() >= requiredPoints;
    }
}
