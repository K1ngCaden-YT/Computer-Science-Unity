using UnityEngine;

public class FootstepNoise : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float minTimeBetweenSteps = 0.3f;
    public float maxTimeBetweenSteps = 0.7f;
    public float walkSpeedThreshold = 0.1f;
    public Material footstepMaterial;

    private AudioSource audioSource;
    private float lastStepTime;
    private CharacterController characterController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.velocity.magnitude > walkSpeedThreshold && 
            characterController.material == footstepMaterial && 
            Time.time > lastStepTime + Random.Range(minTimeBetweenSteps, maxTimeBetweenSteps))
        {
            lastStepTime = Time.time;
            audioSource.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.Play();
        }
    }
}
