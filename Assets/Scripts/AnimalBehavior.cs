using UnityEngine;

public class AnimalBehavior : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Fungsi ini akan dipanggil saat hewan disentuh
    public void Interact()
    {
        // 1. Mainkan Animasi (Pastikan di Animator ada Parameter Trigger bernama "Action")
        if(anim != null) anim.SetTrigger("Action"); 
        
        // 2. Mainkan Suara
        if(audioSource != null) audioSource.Play();

        // 3. Efek Fisika (Loncat dikit biar kerasa 'Physics'-nya)
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddForce(Vector3.up * 100f); // Dorong ke atas sedikit
        }
    }
}