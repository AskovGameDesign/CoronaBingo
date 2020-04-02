using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNumbers : MonoBehaviour
{

    List<int> orderedNumbers = new List<int>();
    List<int> randomNumbers = new List<int>();
    int currentNumberInList = 0;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 100; i++)
        {
            orderedNumbers.Add(i);
        }

        int l = orderedNumbers.Count;

        for (int i = 0; i < l; i++)
        {
            int randomIndex = Random.Range(0, orderedNumbers.Count);
            randomNumbers.Add(orderedNumbers[randomIndex]);
            orderedNumbers.Remove(orderedNumbers[randomIndex]);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(GetRandomNumber(15));
            
        }
    }

    IEnumerator GetRandomNumber(int _runCount)
    {
        int i = 0;

        while(i <= _runCount)
        {
            if(textMeshPro)
            {
                textMeshPro.text = Random.Range(0, 100).ToString();
            }

            float delayTime = Mathf.Lerp(0.05f, 0.5f, (1f / _runCount) * i);

            yield return new WaitForSeconds(delayTime);

            Debug.Log("dt " + delayTime);

            i++;

        }

        textMeshPro.text = randomNumbers[currentNumberInList].ToString();

        currentNumberInList++;
    }
}
