using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider, _sfxSlider;
    [SerializeField] GameObject _audioPanel;

    private void Start()
    {
        _audioPanel.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _audioPanel.SetActive(!_audioPanel.activeSelf);
            }
        }
    }
    public void MusicToggle()
    {
        AudioManager.Instance.EnableMusic();
    }

    public void SfxToggle()
    {
        AudioManager.Instance.EnableSFX();
    }

    public void MusicVol()
    {
        Debug.Log("Music Slider Value: " + _musicSlider.value);
        AudioManager.Instance.VolumeAdjustMusic(_musicSlider.value);
    }

    public void SfxVol()
    {
        Debug.Log("SFX Slider Value: " + _sfxSlider.value);
        AudioManager.Instance.VolumeAdjustSFX(_sfxSlider.value);
    }
}
