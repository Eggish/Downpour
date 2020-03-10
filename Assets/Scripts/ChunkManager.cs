using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Chunks = new List<GameObject>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D p_Collision)
    {
        if (p_Collision.CompareTag("ChunkBoundary"))
        {
            SpawnNewChunk(p_Collision.transform.position, p_Collision.GetComponent<BoxCollider2D>().bounds);
        }
    }

    private void SpawnNewChunk(Vector3 p_LastChunkPosition, Bounds p_LastChunkBounds)
    {
        GameObject newChunk = Chunks[Random.Range(0, Chunks.Capacity)];
        Vector3 spawnPos = p_LastChunkPosition;
        spawnPos.x += p_LastChunkBounds.size.x;

        Collider[] OverlappingColliders = Physics.OverlapSphere(spawnPos, 1.0f);
        foreach (Collider c in OverlappingColliders)
        {
            if (c.CompareTag("ChunkBoundary"))
                return;
        }

        newChunk = Instantiate(newChunk, spawnPos, Quaternion.identity);
    }
}
