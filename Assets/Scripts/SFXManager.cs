using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip doubleJump;
    [SerializeField] AudioClip gameOverHit;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;
    [SerializeField] AudioClip powerupDoubleJump;
    [SerializeField] AudioClip powerupShield;
    [SerializeField] AudioClip shieldBreak;

    public void PlaySFX(string clipToPlay)
    {
        if (clipToPlay == "Coin")
        {
            audioSource.clip = coin;
        }
        else if (clipToPlay == "DoubleJump")
        {
            audioSource.clip = doubleJump;
        }
        else if (clipToPlay == "GameOverHit")
        {
            audioSource.clip = gameOverHit;
        }
        else if (clipToPlay == "Jump")
        {
            audioSource.clip = jump;
        }
        else if (clipToPlay == "Land")
        {
            audioSource.clip = land;
        }
        else if (clipToPlay == "PowerupDoubleJump")
        {
            audioSource.clip = powerupDoubleJump;
        }
        else if (clipToPlay == "PowerupShield")
        {
            audioSource.clip = powerupShield;
        }
        else if (clipToPlay == "ShieldBreak")
        {
            audioSource.clip = shieldBreak;
        }
        else
        {
            Debug.LogError($"Invalid clip name {clipToPlay}");
        }

        audioSource.Play();
    }
}
