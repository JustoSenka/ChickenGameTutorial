using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    //public GameObject loadingImage;

    public GameObject whiteChickenArrow;
    public GameObject yellowChickenArrow;

    public GameObject whiteChickenCollider;
    public GameObject yellowChickenCollider;

    //Back music
    public AudioClip backMusic;
    private AudioSource source;

    public void Awake()
   {
        whiteChickenArrow.SetActive(false);
        yellowChickenArrow.SetActive(false);

    }


    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            var chickenIndex = GetClickedChickenIndex();
            Debug.Log(chickenIndex);

            if (chickenIndex != 0)
            {
                GameManager.Instance.ChickenIndex = chickenIndex;
                SceneManager.LoadScene(1);
            }
        }
    }


    private int GetClickedChickenIndex()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Raycast hit");

            if (hit.collider.gameObject == whiteChickenCollider)
                return 1;
            else if (hit.collider.gameObject == yellowChickenCollider)
                return 2;
            else
                return 0;
        }

        Debug.Log("No hit");
        return 0;
    }

    public void ShowArrowsAboveChickens()
    {
        whiteChickenArrow.SetActive(true);
        yellowChickenArrow.SetActive(true);
    }

    public void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();

        Debug.Log("Music is playing");
        
    }


    public void ShowOptions()
    {

    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}

