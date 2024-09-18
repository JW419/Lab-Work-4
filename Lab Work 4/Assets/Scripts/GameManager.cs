using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;
    public bool gameOver = false;
    public CinemachineVirtualCamera virtualCamera;

    public int meteorCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GameObject.Find("Ship Camera").GetComponent<CinemachineVirtualCamera>();
        InvokeRepeating("SpawnMeteor", 1f, 2f);

        SpawnPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene("Week5Lab");
        }

        if (meteorCount == 5)
        {
            BigMeteor();
        }
    }

    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }
    void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        virtualCamera.m_Follow = GameObject.Find("Player(Clone)").transform;
    }
}
