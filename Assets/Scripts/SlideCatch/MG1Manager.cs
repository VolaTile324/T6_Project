using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MG1Manager : MonoBehaviour
{
    [SerializeField] private int messageNum = 0;
    [SerializeField] private int messageTarget = 10;
    [SerializeField] private TMP_Text messageDisplay;
    [SerializeField] private TMP_InputField messageTargetInput;
    [SerializeField] private Button startGameButton;
    [SerializeField] private List<GameObject> entities;
    [SerializeField] private List<GameObject> spawnPos;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private GameObject retryPanel;
    [SerializeField] private UnityEvent OnSuccess;
    // [SerializeField] private ParticleSystem collectParticle;
    // [SerializeField] private ParticleSystem failParticle;

    private bool startSpawning = false;
    private float spawnTime;
    private int spawnIndex;
    private Vector3 spawnInstPos;
    private int entCount;
    private int spawnCount;

    public int MessageNum { get => messageNum; set => messageNum = value; }
    public bool StartSpawning { get => startSpawning; set => startSpawning = value; }

    private void Start()
    {
        entCount = entities.Count;
        spawnCount = spawnPos.Count;
    }

    public void StartMG1()
    {
        startSpawning = true;
    }

    public void StopMG1()
    {
        startSpawning = false;
    }

    private void Update()
    {
        if (messageTarget < 10)
        {
            startGameButton.interactable = false;
        }
        else
        {
            startGameButton.interactable = true;
            messageDisplay.text = messageNum + " / " + messageTarget;
        }
        
        if (!startSpawning)
        {
            return;
        }
        if (startSpawning)
        {
            if (spawnTime <= 0)
            {
                spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                spawnIndex = Random.Range(0, spawnCount);
                spawnInstPos = new Vector3(spawnPos[spawnIndex].transform.position.x, spawnPos[spawnIndex].transform.position.y, spawnPos[spawnIndex].transform.position.z);

                Instantiate(entities[Random.Range(0, entCount)],
                    spawnInstPos,
                    Quaternion.identity,
                    gameObject.transform
                    );
            }
            else
            {
                spawnTime -= Time.deltaTime;
            }
        }
        if (messageNum >= messageTarget && startSpawning)
        {
            MG1Winner();
            startSpawning = false;
        }
    }

    public void UpdateInput()
    {
        messageTarget = int.Parse(messageTargetInput.text);
    }

    public void MG1Winner()
    {
        winnerPanel.SetActive(true);
        OnSuccess.Invoke();
        
    }

    public void MG1Lose()
    {
        startSpawning = false;
        messageNum = 0;
        retryPanel.SetActive(true);
    }

    public void MG1Restart()
    {
        messageNum = 0;
    }
}
