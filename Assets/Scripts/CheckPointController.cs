using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;

    public Vector3 spawnpoint;

    private CheckPoint[] checkPoints;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        checkPoints = FindObjectsOfType<CheckPoint>();

        spawnpoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateCheckpoints()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].ResetCheckPoint();
        }
    }

    public void SetSpawnPoint(Vector3 newspawnpoint)
    {
        spawnpoint = newspawnpoint;
    }
}
