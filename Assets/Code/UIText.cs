using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIText : MonoBehaviour
{
    private float fadeoutDuration = 4f;
    private TextMeshProUGUI proUGUI;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        proUGUI = GetComponent<TextMeshProUGUI>();

        yield return new WaitForSeconds(1f);

        float time = 0f;
        float clampedTime = 0f;

        while(time <= fadeoutDuration)
        {
            clampedTime = Mathf.InverseLerp(0f, fadeoutDuration, time);

            proUGUI.color = Color.Lerp(Color.white, new Color(1f, 1f, 1f, 0f), clampedTime);
            time += Time.unscaledDeltaTime;

            yield return null;
        }

        Destroy(this.gameObject);
    }

    
}
