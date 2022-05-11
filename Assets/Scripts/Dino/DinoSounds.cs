using UnityEngine;

public class DinoSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _soundTakeDamage;
    [SerializeField] private AudioSource _soundTakeHeart;
    [SerializeField] private Dino _dino;

    private void OnEnable()
    {
        _dino.onTakeDamage += SoundTakeDamage;
        _dino.onHealth += TakeHeart;
    }

    private void OnDisable()
    {
        _dino.onTakeDamage -= SoundTakeDamage;
        _dino.onHealth -= TakeHeart;
    }

    private void SoundTakeDamage()
    {
        _soundTakeDamage.pitch = Random.Range(0.9f, 1.1f);
        _soundTakeDamage.Play();
    }

    private void TakeHeart()
    {
        _soundTakeHeart.pitch = Random.Range(0.8f, 1.2f);
        _soundTakeHeart.Play();
    }
}
