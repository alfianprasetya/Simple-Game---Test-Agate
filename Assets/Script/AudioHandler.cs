using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    void Start()
    {
        var dbMaster = PlayerPrefs.GetFloat("MASTER_ATTENUATION", 0);
        var volMaster = DbToVol(dbMaster);
        audioMixer.SetFloat("MASTER_ATTENUATION", dbMaster);
        masterSlider.SetValueWithoutNotify(volMaster);

        var dbBgm = PlayerPrefs.GetFloat("BGM_ATTENUATION", 0);
        var volBgm = DbToVol(dbBgm);
        audioMixer.SetFloat("BGM_ATTENUATION", dbBgm);
        bgmSlider.SetValueWithoutNotify(volBgm);

        var dbSfx = PlayerPrefs.GetFloat("SFX_ATTENUATION", 0);
        var volSfx = DbToVol(dbSfx);
        audioMixer.SetFloat("SFX_ATTENUATION", dbSfx);
        sfxSlider.SetValueWithoutNotify(volSfx);
    }

    private void OnEnable()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVol);
        bgmSlider.onValueChanged.AddListener(SetBgmVol);
        sfxSlider.onValueChanged.AddListener(SetSfxVol);
    }

    private void OnDisable()
    {
        masterSlider.onValueChanged.RemoveListener(SetMasterVol);
        bgmSlider.onValueChanged.RemoveListener(SetBgmVol);
        sfxSlider.onValueChanged.RemoveListener(SetSfxVol);
        PlayerPrefs.Save();
    }

    public void SetMasterVol(float vol)
    {
        var db = VolToDb(vol);
        audioMixer.SetFloat("MASTER_ATTENUATION", db);
        PlayerPrefs.SetFloat("MASTER_ATTENUATION", db);
    }

    public void SetBgmVol(float vol)
    {
        var db = VolToDb(vol);
        audioMixer.SetFloat("BGM_ATTENUATION", db);
        PlayerPrefs.SetFloat("BGM_ATTENUATION", db);
    }

    public void SetSfxVol(float vol)
    {
        var db = VolToDb(vol);
        audioMixer.SetFloat("SFX_ATTENUATION", db);
        PlayerPrefs.SetFloat("SFX_ATTENUATION", db);
    }

    private float DbToVol(float db)
    {
        return Mathf.Pow(10, db / 20);
    }

    private float VolToDb(float vol)
    {
        if (vol == 0)
            return -80;
        return 20 * Mathf.Log10(vol);
    }

}
