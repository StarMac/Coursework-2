using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Block blockPrefab;
    [SerializeField]
    private CrackedBlock crackedBlockPrefab;
    [SerializeField]
    private ToxicBlock toxicBlockPrefab;

    private int playWidth = 8;
    private float distanceBetweenBlocks = 0.7f;
    private int rowsSpawned;
    public int hits;

    private List<dynamic> blocksSpawned = new List<dynamic>();

    private void Awake()
    {
        hits = UnityEngine.Random.Range(1, 3);
    }

    private void OnEnable()
    {
        for (int i = 0; i < 1; i++)
        {
            SpawnRowOfBlocks();
        }
    }

    public void SpawnRowOfBlocks()
    {
        foreach (var block in blocksSpawned)
        {
            if(block != null)
            {
                block.transform.position += Vector3.down * distanceBetweenBlocks;
            }
        }

        for (int i = 0; i < playWidth; i++)
        {
            if (UnityEngine.Random.Range(0, 100) <= 50)
            {
                int whichBlock = UnityEngine.Random.Range(0, 100);
                if (rowsSpawned < 97)
                {
                    hits = UnityEngine.Random.Range(1, 3) + rowsSpawned;
                }

                if (whichBlock <= 33)
                {
                    var block = Instantiate(blockPrefab, GetPosition(i), Quaternion.identity);
                    block.SetHits(hits);
                    blocksSpawned.Add(block);
                }
                else if (whichBlock > 33 && whichBlock <= 66)
                {
                    var crackedBlock = Instantiate(crackedBlockPrefab, GetPosition(i), Quaternion.identity);
                    crackedBlock.SetHits(hits);
                    blocksSpawned.Add(crackedBlock);
                }
                else
                {
                    var toxicBlock = Instantiate(toxicBlockPrefab, GetPosition(i), Quaternion.identity);
                    toxicBlock.SetHits(hits);
                    blocksSpawned.Add(toxicBlock);
                }
            }
        }

        rowsSpawned++;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetweenBlocks;
        return position;
    }
}
