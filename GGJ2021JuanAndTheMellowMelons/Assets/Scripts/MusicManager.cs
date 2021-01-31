using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [Tooltip("Array index corresponds to buildIndex for chosen track. Put combat music last")]
    [SerializeField] private AudioClip[] music;

    [SerializeField] private float crossfadeTime;

    private AudioSource primaryAudio, secondaryAudio;

    private void Awake()
    {
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Debug.LogWarning("Multiple instances of MusicManager was found, destroying first instance");
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        AudioSource[] audios = GetComponents<AudioSource>();

        primaryAudio = audios[0];
        secondaryAudio = audios[1];

        ChangeMusicTrack(SceneManager.GetActiveScene().buildIndex);
        SceneManager.sceneLoaded += ChangeMusicTrack;
    }

    private void ChangeMusicTrack(Scene sceneIndex, LoadSceneMode loadMode)
    {
        ChangeMusicTrack(sceneIndex.buildIndex);
    }

    private void ChangeMusicTrack(int sceneIndex)
    {
        if (!primaryAudio)
        {
            return;
        }

        // REASON in case of build index without music, no error will occur
        if (sceneIndex - 1 < music.Length)
        {
            secondaryAudio.clip = primaryAudio.clip;
            secondaryAudio.time = primaryAudio.time;
            primaryAudio.clip = music[sceneIndex];
            primaryAudio.volume = 0;
            secondaryAudio.volume = 1;
            primaryAudio.Play();
            secondaryAudio.Play();

            StartCoroutine(Crossfading());
        }
    }

    private IEnumerator Crossfading()
    {
        while (secondaryAudio.volume > 0)
        {
            secondaryAudio.volume -= Time.deltaTime / crossfadeTime;
            primaryAudio.volume += Time.deltaTime / crossfadeTime;
            yield return null;
        }
    }

    public void StartCombatMusic()
    {
        ChangeMusicTrack(music.Length - 1);
    }

    public void StopCombatMusic()
    {
        ChangeMusicTrack(SceneManager.GetActiveScene().buildIndex);
    }
}