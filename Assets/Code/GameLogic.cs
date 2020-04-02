using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameLogic : MonoBehaviour
{

    [SerializeField] GameObject coronaVirus;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject uiNumberText;
    [SerializeField] private Canvas uiWorldCanvas;
    List<int> orderedNumbers = new List<int>();
    List<int> randomNumbers = new List<int>();
    int currentNumberInList = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 90; i++)
        {
            orderedNumbers.Add(i);
        }

        int l = orderedNumbers.Count;
        string numberList = "";
        for (int i = 0; i < l; i++)
        {
            int randomIndex = Random.Range(0, orderedNumbers.Count);
            randomNumbers.Add(orderedNumbers[randomIndex]);
            
            numberList += orderedNumbers[randomIndex].ToString() + ", ";

            orderedNumbers.Remove(orderedNumbers[randomIndex]);
        }

        string path = "Assets/Resources/numbers.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(numberList);
        writer.Close();

        CreateVirus();
    }

    void SaveNumbers(int _number)
    {

    }
    
    public void SetPointInWorld(Vector3 _position)
    {

        GameObject uiText = Instantiate(uiNumberText, uiWorldCanvas.transform);
        uiText.GetComponent<TextMeshProUGUI>().rectTransform.localRotation = Quaternion.Euler(64f, 0f, 0f);
        uiText.GetComponent<TextMeshProUGUI>().rectTransform.anchoredPosition3D = _position;
        uiText.GetComponent<TextMeshProUGUI>().text = randomNumbers[currentNumberInList].ToString();
        //textMeshPro.rectTransform.anchoredPosition3D = _position;
        //textMeshPro.text = randomNumbers[currentNumberInList].ToString();

        StartCoroutine(TimeScale(1f, 2f));

        currentNumberInList++;

        CreateVirus();
    }

    IEnumerator TimeScale(float _pauseBeforeTimeStop, float _slowMotionLength)
    {
        
        yield return new WaitForSeconds(_pauseBeforeTimeStop);

        Time.timeScale = 0f;

        float time = 0f;
        float clampedTime = 0f;

        while (time <= 3f)
        {
            clampedTime = Mathf.InverseLerp(0f, _slowMotionLength, time);

            Time.timeScale = clampedTime;
            time += Time.unscaledDeltaTime;

            yield return null;
        }

        Time.timeScale = 1f;

    }

    public void CreateVirus()
    {
        int spawnId = Random.Range(0, spawnPoints.Length);

        Instantiate(coronaVirus, spawnPoints[spawnId].position, Quaternion.identity);
    }
}
