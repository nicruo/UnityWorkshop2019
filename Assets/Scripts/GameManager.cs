using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public Text numberText;
    public int startCounter = 3;
    public Text scoreText;

    //private float timeCount;
    //private float timeCount2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart());
        SceneManager.LoadScene("Watermark", LoadSceneMode.Additive);
    }

    IEnumerator CountdownToStart()
    {
        if (numberText != null)
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
    }

    IEnumerator SpawnCR(float t, Vector3 position)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(t);
            GameObject enemy =  Instantiate(enemyPrefab, position, Quaternion.identity);

            enemy.GetComponent<EnemyControl>().gameManager = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameState.instance.score + "";

    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
