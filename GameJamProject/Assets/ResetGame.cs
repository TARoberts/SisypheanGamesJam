using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject player;
    [SerializeField] private ParallaxMove mover;
    [SerializeField] private Image whiteOut;
    private bool fade = false;
    [SerializeField] private GameObject manager;
    private GameObject[] layerSpawnable;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        manager = GameObject.FindGameObjectWithTag("Manager");

    }
    void Update()
    {
        if (fade)
        {
            whiteOut.color += new Color(1, 1, 1, 5 * Time.deltaTime);
        }
        else
        {
            if (whiteOut.color.a > 0)
            {
                whiteOut.color -= new Color(1, 1, 1, 5 * Time.deltaTime);
            }
            
        }
    }

    public void Reset()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        player.transform.parent = null;
        layerSpawnable = GameObject.FindGameObjectsWithTag("Spawnable");
        for (int i = 0; i < layerSpawnable.Length; i++)
        {
            Destroy(layerSpawnable[i]);
        }
        manager.GetComponent<Obsticle_spawner_script>().zoneTimer = 0f;
        fade = true;
        yield return new WaitForSeconds(2f);
        player.transform.position = spawn.transform.position;
        mover.ResetCam();
        fade = false;
    }
}
