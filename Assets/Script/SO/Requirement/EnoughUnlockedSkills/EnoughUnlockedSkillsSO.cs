using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnoughUnlockedSkill", menuName = "SO/Requirement/EnoughUnlockedSkills")]
public class EnoughUnlockedSkillsSO : ScriptableObject, Requirement
{
    public int requiredAmount;
    public int rowIndex;

    bool Requirement.IsGood(List<Row> rows)
    {
        return rows[rowIndex].GetTotalUnlockedSkillAmount() >= requiredAmount;
    }
}
