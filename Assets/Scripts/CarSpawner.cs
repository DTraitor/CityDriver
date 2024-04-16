using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform carSpawnLocation;
    [SerializeField]
    private RCC_Camera camera;
    [SerializeField]
    private string nextScene;

    private void Start()
    {
        var selectedCar = PlayerPrefs.GetInt(CarSelector.PreferencesKey, 0);
        var car = RCC.SpawnRCC(DefaultCars.CarsList.Cars[selectedCar], carSpawnLocation.position, carSpawnLocation.rotation, true, true, true);
        car.gameObject.layer = LayerMask.NameToLayer(FinishLine.LayerName);
        camera.playerCar = car;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
