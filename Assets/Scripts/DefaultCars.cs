using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DefaultCars : MonoBehaviour
{
    [CanBeNull] private CarsList carsList;
    public CarsList CarsList
    {
        get
        {
            if (carsList == null)
            {
                carsList = Resources.Load<CarsList>("DefaultCars");
            }
            return carsList;
        }
    }
}
