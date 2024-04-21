using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/StaticData", fileName = "StaticData")]
public class StaticData : ScriptableObject
{
    public List<LevelStaticData> levels;
}