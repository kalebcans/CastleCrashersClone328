using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemies;
    public GameObject enemy;
    public float spawnFrequency;

    private float spawnTimer;

    Vector3 cameraInitialPosition;
	private float shakeMagnetude = 0.05f, shakeTime = 0.6f;
	private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnFrequency;
        mainCamera = Camera.main;
        ShakeIt();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (checkEnemyCount() < maxEnemies && spawnTimer <= 0)
        {
            spawnEnemy();
            spawnTimer = spawnFrequency;
        }
    }

    int checkEnemyCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void spawnEnemy ()
    {
        GameObject newEnemy = Instantiate(enemy);

        newEnemy.transform.parent = gameObject.transform;
    }

    private void ShakeIt()
	{
		cameraInitialPosition = mainCamera.transform.position;
		InvokeRepeating ("StartCameraShaking", 0f, 0.005f);
		Invoke ("StopCameraShaking", shakeTime);
	}

	void StartCameraShaking()
	{
		float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
		Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
		cameraIntermadiatePosition.x += cameraShakingOffsetX;
		cameraIntermadiatePosition.y += cameraShakingOffsetY;
		mainCamera.transform.position = cameraIntermadiatePosition;
	}

	void StopCameraShaking()
	{
		CancelInvoke ("StartCameraShaking");
		mainCamera.transform.position = cameraInitialPosition;
	}
}
