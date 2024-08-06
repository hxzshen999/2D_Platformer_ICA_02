using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AudioClips", menuName = "AudioClips", order = 1)]
public class AudioSO : ScriptableObject
{

    public string audioName;
    public AudioClip audioClip;

}
