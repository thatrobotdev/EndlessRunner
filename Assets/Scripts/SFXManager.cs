using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip doubleJumpSFX;
    [SerializeField] AudioClip gameOverHitSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip landSFX;
    [SerializeField] AudioClip powerupDoubleJumpSFX;
    [SerializeField] AudioClip powerupShieldSFX;
    [SerializeField] AudioClip shieldBreakSFX;

    public void PlaySFX(string clipToPlay)
    {
        if(clipToPlay == "Coin")
        {
            audioSource.clip = coinSFX;
        } else if(clipToPlay == "DoubleJump")
        {
            audioSource.clip = doubleJumpSFX;
        } else if(clipToPlay == "GameOverHit")
        {
            audioSource.clip = gameOverHitSFX;
        } else if(clipToPlay == "Jump")
        {
            audioSource.clip = jumpSFX;
        } else if(clipToPlay == "Land")
        {
            audioSource.clip = landSFX;
        } else if(clipToPlay == "PowerupDoubleJump")
        {
            audioSource.clip = powerupDoubleJumpSFX;
        } else if(clipToPlay == "PowerupShield")
        {
            audioSource.clip = powerupShieldSFX;
        } else if(clipToPlay == "ShieldBreak")
        {
            audioSource.clip = shieldBreakSFX;
        } else 
        {
            Debug.LogError($"Invalid clip name {clipToPlay}");
        }

        audioSource.Play();
    }
}
