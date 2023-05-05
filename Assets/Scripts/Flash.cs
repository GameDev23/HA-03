using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
/**
 * Got this code from  https://answers.unity.com/questions/1241994/how-to-make-a-flash.html
 */
 public class Flash : MonoBehaviour {
     ///////////////////////////////////////////////////
     public float flashTimelength = .1f;
     public bool doCameraFlash = false;
     public static Flash Instance;
     public bool flashing = false;
     public bool isInvoked;
 
     ///////////////////////////////////////////////////
     private Image flashImage;
     private float startTime;
     
 
     ///////////////////////////////////////////////////
 void Start()
 {
     // create singleton
     if (Instance == null)
         Instance = this;
     else if (Instance != this)
         Destroy(gameObject);
     
     flashImage = GetComponent<Image>();
     Color col = flashImage.color;
     col.a = 0.0f;
     flashImage.color = col;
 }
 
     ///////////////////////////////////////////////////
     void Update () {
         if(doCameraFlash && !flashing)
         {
             CameraFlash();
         }
         else
         {
             doCameraFlash = false;
         }
     }
 
     ///////////////////////////////////////////////////

     public void doFlashWithDelay(float delay)
     {
         isInvoked = true;
         Invoke(nameof(setDoFlash), delay);
     }
     
     public void setDoFlash()
     {
         AudioManager.Instance.source.PlayOneShot(AudioManager.Instance.cameraFlash, 0.3f);
         doCameraFlash = true; ;
     }
     public void CameraFlash(float delay = 0f)
     {  
             // initial color
             Color col = flashImage.color;
 
             // start time to fade over time
             startTime = Time.time;
 
             // so we can flash again
             doCameraFlash = false;
 
             // start it as alpha = 1.0 (opaque)
             col.a = 1.0f;
 
             // flash image start color
             flashImage.color = col;
 
             // flag we are flashing so user can't do 2 of them
             flashing = true;
 
             StartCoroutine(FlashCoroutine(delay));
         
     }
 
     ///////////////////////////////////////////////////
     IEnumerator FlashCoroutine(float delay = 0f)
     {
         bool done = false;
         if (delay != 0)
             yield return new WaitForSeconds(delay);
         while(!done)
         {
             float perc;
             Color col = flashImage.color;
 
             perc = Time.time - startTime;
             perc = perc / flashTimelength;
 
             if(perc > 1.0f)
             {
                 perc = 1.0f;
                 done = true;
             }
 
             col.a = Mathf.Lerp(1.0f, 0.0f, perc);
             flashImage.color = col;
             flashing = true;
 
             yield return null;
         }
 
         flashing = false;
         isInvoked = false;
 
         yield break;
     }
 }
