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
        switch (clipToPlay)
        {
            case "Coin":
                audioSource.clip = coin;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJump;
                break;
            case "GameOverHit":
                audioSource.clip = gameOverHit;
                break;
            case "Jump":
                audioSource.clip = jump;
                break;
            case "Land":
                audioSource.clip = land;
                break;
            case "PowerupDoubleJump":
                audioSource.clip = powerupDoubleJump;
                break;
            case "PowerupShield":
                audioSource.clip = powerupShield;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreak;
                break;
            default:
                Debug.LogError($"Invalid clip name {clipToPlay}");
                break;
        }

        audioSource.Play();
    }
}
