using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamManager : MonoBehaviour
{
    AudioController AC;
    int ScreamCount;
    [SerializeField]
    float MinTime;
    [SerializeField]
    float MaxTime;
    [SerializeField]
    float SetTime;
    [SerializeField]
    float CurrentTime;
    // Start is called before the first frame update
    void Start()
    {
        AC = GetComponent<AudioController>();
        ScreamCount = AC.Length();
        SetNewTime();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= Time.deltaTime;
        if (CurrentTime < 0)
        {
            PlayScream();
            SetNewTime();
        }
    }
    void SetNewTime()
    {
        SetTime = Random.Range(MinTime, MaxTime);
        CurrentTime = SetTime;
    }
    void PlayScream()
    {
        AC.Play(Random.Range(0, ScreamCount), 1, 1);
    }
}
