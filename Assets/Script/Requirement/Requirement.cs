using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Requirement
{
    bool IsGood(List<Row> rows);
}
