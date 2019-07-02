using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public Text numberText;
    public int startCounter = 3;

    //private float timeCount;
    //private float timeCount2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (startCounter > 0)
        {
            numberText.text = startCounter + "";

            yield return new WaitForSecondsRealtime(2);

            startCounter--;
        }

        numberText.text = "";

        player.GetComponent<CubeControl>().playable = true;

        StartCoroutine(SpawnCR(1, new Vector3(4, 20, 0)));
        StartCoroutine(SpawnCR(2, new Vector3(0, 20, 4)));
    }

    IEnumerator SpawnCR(float t, Vector3 position)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(t);
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(timeCount >= 1)
        //{
        //    timeCount = 0;
        //    Instantiate(enemyPrefab, new Vector3(4, 20, 0), Quaternion.identity);
        //}
        //timeCount += Time.deltaTime;

        //if (timeCount2 >= 2)
        //{
        //    timeCount2 = 0;
        //    Instantiate(enemyPrefab, new Vector3(0, 20, 3), Quaternion.identity);
        //}
        //timeCount2 += Time.deltaTime;



    }
}
