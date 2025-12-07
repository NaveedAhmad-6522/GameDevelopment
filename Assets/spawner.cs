using UnityEngine;

public class spawner : MonoBehaviour

{
   public GameObject resourcePrefab;


 BoxCollider spawnArea;

 void Start()
 {
    
     spawnArea = GetComponent<BoxCollider>();

    
     InvokeRepeating("SpawnResource", 0f, 5f);
 }

 void SpawnResource()
 {
    
     Bounds b = spawnArea.bounds;

     float x = Random.Range(b.min.x, b.max.x);
     float y = Random.Range(b.min.y, b.max.y);
     float z = Random.Range(b.min.z, b.max.z);

     Vector3 randomPos = new Vector3(x, y, z);

     Instantiate(resourcePrefab, randomPos, Quaternion.identity);
 }
}

