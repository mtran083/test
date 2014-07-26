using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // Public field
    public int pool_size = 50;

    // Private fields
    private int b_idx;
    private Transform[] b_list;

    // Static singleton property
    public static BulletManager Instance { get; private set; }

    void Awake()
    {
        // First we check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            // If that is the case, we destroy other instances
            Destroy(gameObject);
        }

        // Here we save our singleton instance
        Instance = this;

        // Furthermore we make sure that we don't destroy between scenes (this is optional)
        //DontDestroyOnLoad(gameObject);

        b_idx = 0;
        b_list = new Transform[pool_size];
    }

    // Instance method, this method can be accesed through the singleton instance
    public void add_bullet(Transform t)
    {

        if (b_list[b_idx] != null)
        {
            Destroy(b_list[b_idx].gameObject);
            //Debug.Log("Deleting Bullet at " + b_idx);
            b_list[b_idx] = null;
        }

        b_list[b_idx] = t;
        b_idx++;

        if (b_idx >= pool_size) b_idx = 0;

        return;
    }

}