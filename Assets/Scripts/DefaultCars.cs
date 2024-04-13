using JetBrains.Annotations;
using UnityEngine;

public class DefaultCars : MonoBehaviour
{
    [CanBeNull] private static CarsList carsList;

    public static CarsList CarsList
    {
        get
        {
            if (carsList == null)
            {
                carsList = Resources.Load("DefaultCars") as CarsList;
            }
            return carsList;
        }
    }
}
