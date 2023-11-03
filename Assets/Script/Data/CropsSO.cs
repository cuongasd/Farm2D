using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CropsSO", menuName = "Data/CropsSO", order = 0)]
public class CropsSO : ScriptableObject
{
    public List<Crops> listCrops;
}
