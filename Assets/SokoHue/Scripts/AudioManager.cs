using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSrc;
    public AudioSource SfxSrc;
    public AudioClip bgm;

    public AudioClip moveSound;
    public AudioClip winSound;
    public AudioClip resetSound;

    public static AudioManager instance;

    private void OnEnable()
    {
        PlayerController.Move += OnMove;
        PlayerController.Win += OnWin;
        PlayerController.Resetting += ResetPlay;
    }

    private void OnDisable()
    {
        PlayerController.Move -= OnMove;
        PlayerController.Win -= OnWin;
        PlayerController.Resetting -= ResetPlay;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        MusicSrc.clip = bgm;
        MusicSrc.Play();
    }

    private void OnMove()
    {
        SfxSrc.pitch = Random.Range(0.5f, 1f);
        SfxSrc.clip = moveSound;
        SfxSrc.PlayOneShot(moveSound);
        
    }

    private void OnWin()
    {
        SfxSrc.pitch = 1;
        SfxSrc.clip = winSound;
        SfxSrc.PlayOneShot(winSound);
    }
    
    private void ResetPlay()
    {
        SfxSrc.pitch = 1;
        SfxSrc.clip = resetSound;
        SfxSrc.PlayOneShot(resetSound);
    }
}
