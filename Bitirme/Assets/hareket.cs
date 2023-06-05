using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hareket : MonoBehaviour
{

    bool oyunbitti = false;
    public int puan=0;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        puan = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Çağrılma Süresi" + Time.deltaTime); 


        if (oyunbitti == false)
            GetComponent<Rigidbody>().AddForce(Vector3.left * 100 , ForceMode.Force);
        else if (oyunbitti == true)
            GetComponent<Rigidbody>().velocity = Vector3.zero;


        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 110, ForceMode.Force);
        }

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -110, ForceMode.Force);
        }

        if ((GetComponent<Rigidbody>().position.z<-10) || (GetComponent<Rigidbody>().position.z > 10))
        {

            oyunbitti = true;
            Invoke("restart", 3f);

        }
    }

    private void FixedUpdate()
    {
        Debug.Log("FixeUpdate Çağrılma Süresi" + Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            Invoke("restart", 3f);
            oyunbitti = true;
            audioSource.Play();
        }

        if (collision.collider.tag == "Coin")
        {
            puan++;
            Destroy(collision.gameObject);
            //audioSource.Play();
        }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oyunbitti = false;

    }

  





}
