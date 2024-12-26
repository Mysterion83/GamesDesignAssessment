using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected string AdditionalToolTip = null;
    protected AudioSource Audio;

    private void Start()
    {
        TryGetComponent<AudioSource>(out Audio);
    }
    public string GetAdditionalToolTip()
    {
        return AdditionalToolTip;
    }
    public virtual void Interact()
    {

    }
    protected void PlayAudio()
    {
        if (Audio != null) Audio.Play();
    }
}
