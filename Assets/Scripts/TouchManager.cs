using UnityEngine;
using UnityEngine.XR.ARFoundation; // Wajib untuk AR

public class TouchManager : MonoBehaviour
{
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main; // Mengambil kamera utama
    }

    void Update()
    {
        // Cek apakah ada sentuhan jari di layar
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Tembakkan Ray (Garis invisible) dari posisi sentuhan
            Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            // Jika Ray mengenai sesuatu yang punya Collider
            if (Physics.Raycast(ray, out hit))
            {
                // Cek apakah yang kena itu Hewan?
                if (hit.transform.CompareTag("Animal"))
                {
                    // Panggil fungsi Interact yang ada di hewan tersebut
                    AnimalBehavior animalScript = hit.transform.GetComponent<AnimalBehavior>();
                    if (animalScript != null)
                    {
                        animalScript.Interact();
                    }
                }
            }
        }
    }
}