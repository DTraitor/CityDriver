using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour
{
    [SerializeField]
    private Transform carSpawnLocation;
    [SerializeField]
    private string nextScene;
    private List<RCC_CarControllerV3> cars = new();
    private int selectedCarIndex;

    public const string PreferencesKey = "SelectedCarIndex";

    void Start()
    {
        foreach (var car in DefaultCars.CarsList.Cars)
        {
            var newCar = RCC.SpawnRCC(car, carSpawnLocation.position, carSpawnLocation.rotation, false, false, false);
            newCar.gameObject.SetActive(false);
            cars.Add(newCar);
        }

        selectedCarIndex = PlayerPrefs.GetInt(PreferencesKey, 0);
        UpdateCar();
    }

    private void UpdateCar()
    {
        foreach (var car in cars)
        {
            car.gameObject.SetActive(false);
        }

        cars[selectedCarIndex].gameObject.SetActive(true);
    }

    public  void SelectNextCar()
    {
        selectedCarIndex++;
        if (selectedCarIndex >= cars.Count)
        {
            selectedCarIndex = 0;
        }
        PlayerPrefs.SetInt(PreferencesKey, selectedCarIndex);
        UpdateCar();
    }

    public void SelectPreviousCar()
    {
        selectedCarIndex--;
        if (selectedCarIndex < 0)
        {
            selectedCarIndex = cars.Count - 1;
        }
        PlayerPrefs.SetInt(PreferencesKey, selectedCarIndex);
        UpdateCar();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
