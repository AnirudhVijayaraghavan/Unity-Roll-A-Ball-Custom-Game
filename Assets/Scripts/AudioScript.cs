using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class AudioScript : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}


public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();  // Start the music
    }

    public void StopMusic()
    {
        audioSource.Stop();  // Stop the music if needed
    }
}
