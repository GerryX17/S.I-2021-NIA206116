using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    private int count;
    public bool canSpawn = true; // 1
    public GameObject sheepPrefab; // 2
    public List<Transform> sheepSpawnPositions = new List<Transform>(); // 3
    public float timeBetweenSpawns;
    private List<GameObject> sheepList = new List<GameObject>(); // 5

    /*public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject restartButton;*/
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        //endgame();
        //restartButton.gameObject.SetActive(false);
        //winTextObject.SetActive(false);
        //loseTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //print(count);
        //countText.text = "Count: " + count.ToString();
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

    public void RemoveSheepFromList(GameObject sheep)
    {
        //count = count + sheep.GetComponent<Sheep>().count;
        sheepList.Remove(sheep);
    }
    /*void endgame()
    {
        if (count >= 10)
        {
            restartButton.gameObject.SetActive(true);
            loseTextObject.SetActive(false);

            // Set the text value of your 'winText'
            winTextObject.SetActive(true);

        }
    }*/


}
