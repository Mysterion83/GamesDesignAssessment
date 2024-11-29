using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemNameFadeOut : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField]
    float FadeOutTime;
    [SerializeField]
    float CurrentTime;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        UpdateTooltip(null,null);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime < 0) return;
        CurrentTime -= Time.deltaTime;
        text.alpha = (CurrentTime / FadeOutTime)*.75f;
    }
    public void UpdateTooltip(string Name, string Description)
    {
        if (name == null ^ Description == null) return;
        text.text = $"{Name}:\n{Description}";
        CurrentTime = FadeOutTime;
    }
}
