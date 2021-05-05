using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro;
public class SheepSpawner : MonoBehaviour
{
    public int count;
    public bool canSpawn = true; // 1
    public GameObject sheepPrefab; // 2
    public List<Transform> sheepSpawnPositions = new List<Transform>(); // 3
    public float timeBetweenSpawns;
    private List<GameObject> sheepList = new List<GameObject>(); // 5

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        count = 0;
        countText.text = "Count: " + count.ToString();
        restartButton.gameObject.SetActive(false);
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        endgame();
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; // 1
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); // 2
        sheepList.Add(sheep); // 3
        sheep.GetComponent<Sheep>().SetSpawner(this); // 4
    }
    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn) // 2
        {
            SpawnSheep(); // 3
            yield return new WaitForSeconds(timeBetweenSpawns); // 4
        }
    }

    public void RemoveSheepFromList(GameObject sheep, bool hit)
    {  

        if(hit == true)
        {

            sheepList.Remove(sheep);
            count++;
            countText.text = "Count: " + count.ToString();
            endgame();
        }
        else
        {
            restartButton.gameObject.SetActive(true);
            loseTextObject.SetActive(true);
            sheepList.Remove(sheep);
        }
    }


    void endgame()
    {
        if (count >= 10)
        {
            restartButton.gameObject.SetActive(true);
            loseTextObject.SetActive(false);

            // Set the text value of your 'winText'
            winTextObject.SetActive(true);

        }
    }


}
