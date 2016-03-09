using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDExemplifier : MonoBehaviour
{
    public float secondsToLive = 5f;
    public float secondsTillSpawn = 2f;
    public QuickHUD hud;
    private int spawncount;
    private Color c;
    private List<Color> colors = new List<Color> { Color.red, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta };

    // Use this for initialization
    void Start()
    {
        c = colors[spawncount % colors.Count];
        this.GetComponent<MeshRenderer>().material.color = c;
        if (secondsTillSpawn < secondsToLive) StartCoroutine(spawnWatch(secondsTillSpawn));
        StartCoroutine(deathWatch(secondsToLive));
    }

    IEnumerator deathWatch(float liveTime)
    {
        var t = hud.registerHudElement();
        var lt = liveTime;
        while(lt > 0f)
        {
            lt -= Time.smoothDeltaTime;
            
            t.text = string.Format("{0} {2}'s Status:\n\tSeconds to live:{1:F2}\n\tColor:<color=#{3:X2}{4:X2}{5:X2}{6:X2}>#{3:X2}{4:X2}{5:X2}{6:X2}</color>", this.name, lt, spawncount, (int)(c.r * 255), (int)(c.g * 255), (int)(c.b * 255), (int)(c.a * 255));
            yield return null;
        }
        Object.Destroy(t.gameObject);
        Object.Destroy(this.gameObject);
    }

    IEnumerator spawnWatch(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        var o = Object.Instantiate<HUDExemplifier>(this);
        o.spawncount = this.spawncount + 1;
        o.name = this.name;
        o.secondsToLive -= 0.5f;
        o.transform.position += new Vector3(0f, 1f, 0f);
    }
}