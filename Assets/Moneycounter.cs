using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneycounter : MonoBehaviour
{
    public float currentTime = 0;
    public float minutes;
    public float seconds;
    public float money;
    public GameObject timeText;
    public GameObject oneHundred;
    public int count;
    public Transform SpawnPosition;
    public int range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(currentTime / 60);
        seconds = Mathf.FloorToInt(currentTime % 60);
        money = (float)(currentTime * 72.43);
        string output = string.Format("{0:00}:{1:00}", minutes, seconds);
        output += "\n"+string.Format("${0:.00}", (float)money);
        if(money / 100 > count)
        {
            count++;
            int spawnX = Random.Range(-range, range);
            int spawnZ = Random.Range(-range, range);
            Vector3 newSpawn = new Vector3(SpawnPosition.position.x + spawnX/1000.0f, SpawnPosition.position.y , SpawnPosition.position.z + spawnZ / 1000.0f);
            Instantiate(oneHundred, newSpawn, SpawnPosition.rotation);
        }
        timeText.GetComponent<TMPro.TextMeshPro>().text = output;
    }
}
