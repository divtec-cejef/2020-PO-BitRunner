using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float startTime;
    public string secondes;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float score = Time.time - startTime;
        
        secondes = (score).ToString("f2");

        PlayerPrefs.SetString("score", secondes);
    }
}
