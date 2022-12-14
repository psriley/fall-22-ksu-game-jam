using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused;
    public float holdDownTime;
    public int howOverloaded = 0; // 0 = not, 1 = kinda, 2 = very, 3 = max
    public SpriteRenderer[] enemies;
    [SerializeField] int cats;
    [SerializeField] GameObject text;
    public AudioSource a;
    public AudioClip normal;
    public AudioClip boosted;
    public bool swap;

    [SerializeField] Image fillImage;
    public float[] fillAmountTriggers;
    [SerializeField] ScriptableRendererFeature[] features;
    [SerializeField] PlayerMovement movement;

    private void Awake() {
        paused = false;
        pauseMenu.SetActive(false);
        a = GetComponent<AudioSource>();
        a.clip = normal;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (paused){
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
            else {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
        }

        if (Input.GetMouseButtonUp(0))
        {
            foreach (SpriteRenderer enemy in enemies) {
                enemy.color = Color.white;
                enemy.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            }
        }

        if (Input.GetMouseButton(0))
        {
            foreach (SpriteRenderer enemy in enemies) {
                enemy.color = Color.red;
                enemy.maskInteraction = SpriteMaskInteraction.None;
            }

            holdDownTime += 0.2f * Time.deltaTime;
            holdDownTime = Mathf.Clamp01(holdDownTime);
            fillImage.fillAmount = holdDownTime;

            if (fillImage.fillAmount >= fillAmountTriggers[1] &&
                fillImage.fillAmount < fillAmountTriggers[2])
            {
                howOverloaded = 1;
            }
            if (fillImage.fillAmount >= fillAmountTriggers[2] &&
                fillImage.fillAmount < fillAmountTriggers[3])
            {
                howOverloaded = 2;
            }
            if (fillImage.fillAmount >= fillAmountTriggers[3])
            {
                howOverloaded = 3;
            }

            Debug.Log(fillImage.fillAmount);
            // if (fillAmount.fillAmount >= fillAmountTriggers[2] &&
            //     fillAmount.fillAmount < fillAmountTriggers[3])
            // {
            //     howOverloaded = 3;
            // }
            // if (fillAmount.fillAmount >= fillAmountTriggers[3])
            // {
            //     howOverloaded = 4;
            // }
        }


        if (Input.GetKey(KeyCode.E))
        {
            movement.enabled = false;
            holdDownTime -= 0.08f * Time.deltaTime;
            holdDownTime = Mathf.Clamp01(holdDownTime);
            fillImage.fillAmount = holdDownTime;

            if (fillImage.fillAmount >= fillAmountTriggers[0] &&
                fillImage.fillAmount < fillAmountTriggers[1])
            {
                howOverloaded = 0;
            }
            if (fillImage.fillAmount >= fillAmountTriggers[1] &&
                fillImage.fillAmount < fillAmountTriggers[2])
            {
                howOverloaded = 1;
            }
            if (fillImage.fillAmount >= fillAmountTriggers[2] &&
                fillImage.fillAmount < fillAmountTriggers[3])
            {
                howOverloaded = 2;
            }
            
            Debug.Log(fillImage.fillAmount);
        }
        if (!(Input.GetKey(KeyCode.E))) 
        {
            movement.enabled = true;
        }

        if (howOverloaded == 0)
        {
            if (a.clip != normal) {
                a.clip = normal;
                swap = true;
            }
            features[0].SetActive(false);
            features[1].SetActive(false);
            features[2].SetActive(false);
        }
        else if (howOverloaded == 1)
        {
            if (a.clip != normal) {
                a.clip = normal;
                swap = true;
            }
            features[0].SetActive(true);
            features[1].SetActive(false);
            features[2].SetActive(false);
        }
        else if (howOverloaded == 2)
        {
            if (a.clip != boosted) {
                a.clip = boosted;
                swap = true;
            }
            features[0].SetActive(true);
            features[1].SetActive(true);
            features[2].SetActive(false);
        }
        else if (howOverloaded == 3)
        {
            if (a.clip != boosted) {
                a.clip = boosted;
                swap = true;
            }
            features[0].SetActive(true);
            features[1].SetActive(true);
            features[2].SetActive(true);
        }

        if (swap) {
            a.Play();
            swap = false;
        }
    }

    public bool GetCat() {
        if (cats > 0) {
            cats--;
            ShowUI();
            return false;
        }
        else {
            return true;
        }
    }

    public void ShowUI() {
        text.SetActive(true);
        StartCoroutine("Wait");
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}
