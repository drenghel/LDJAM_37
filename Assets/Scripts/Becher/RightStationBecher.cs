﻿using UnityEngine;

class RightStationBecher : Becher


{
    void Start()
    {
        EditBecher(ChemicalType.Red);
        Debug.Log("Current liquid color" + CurrentLiquidColor);
        Debug.Log("_containingChemicalType" + _containingChemicalType);
    }
}