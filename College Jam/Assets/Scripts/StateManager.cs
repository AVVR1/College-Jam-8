using Cinemachine.PostFX;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class StateManager : MonoBehaviour
{
	public enum State { present, past }
	[Header("---Current State---")]
	public State currentState = State.present;

	[Header("Variables")]
	public GameObject presentObjectsParent;
	public GameObject pastObjectsParent;
    public GameObject bothObjectsParent;
    AudioSource grandpaStepsSource;
    AudioSource grandpaAudioSource;
    [SerializeField] GameObject grandpa;
    [SerializeField] AudioClip grandpaAudio;
    [SerializeField] AudioClip grandpaSteps;
	[SerializeField] PostProcessVolume postProcessVolume;
    [SerializeField] GameObject skeleton;

	public List<GameObject> presentObjects = new List<GameObject>();
	public List<GameObject> pastObjects = new List<GameObject>();

    GameObject currentSkeleton;

    private void OnEnable()
    {
        PressurePlate.onStateSwitch += SwitchState;
        PressurePlate.onStateSwitch += LoadState;
    }

    private void OnDisable()
    {
        PressurePlate.onStateSwitch -= SwitchState;
        PressurePlate.onStateSwitch -= LoadState;
    }

    private void Awake()
	{
        CreateLists();
        
        AudioSource[] audioSources = grandpa.GetComponents<AudioSource>();
        grandpaStepsSource = audioSources[0];
        grandpaAudioSource = audioSources[1];
	}

    private void Start()
    {
        LoadState();
    }

    private void CreateLists()
    {
        foreach (Transform child in presentObjectsParent.transform)
        {
            presentObjects.Add(child.gameObject);
        }

        foreach (Transform child in pastObjectsParent.transform)
        {
            pastObjects.Add(child.gameObject);
        }
    }
	public void SwitchState()
	{
        if (currentState == State.present)
        {
            currentState = State.past;
        }
        else
        {
            currentState = State.present;
        }
    }
    public void LoadState()
    {
        if (currentState == State.present)
        {
            // mustavalkoinen pois p‰‰lt‰
            postProcessVolume.enabled = false;
            SpawnSkeleton();
            foreach (GameObject presentObject in presentObjects)
            {
                if (presentObject != null)
                {
                    presentObject.SetActive(true);
                }
            }
            foreach (GameObject pastObject in pastObjects)
            {
                if (pastObject != null)
                {
                    pastObject.SetActive(false);
                }
            }
        }
        else
        {
            //mustavalkoinen p‰‰lles
            postProcessVolume.enabled = true;
            Destroy(currentSkeleton);
            foreach (GameObject presentObject in presentObjects)
            {
                presentObject.SetActive(false);
            }
            foreach (GameObject pastObject in pastObjects)
            {
                pastObject.SetActive(true);
            }
            grandpaAudioSource.clip = grandpaAudio;
            grandpaStepsSource.clip = grandpaSteps;
            grandpaAudioSource.Play();
            grandpaStepsSource.Play();
        }
    }
    private void SpawnSkeleton()
    {
        GameObject newSkeleton = Instantiate(skeleton);
        currentSkeleton = newSkeleton;
    }
}
