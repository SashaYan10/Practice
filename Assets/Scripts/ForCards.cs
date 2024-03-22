using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ForCards : MonoBehaviour
{
    public bool Showed;
    [SerializeField] private GameObject card;

    // Start is called before the    first frame update
    void Start()
    {
        card = GetComponent<GameObject>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Showed)
        {
            card.SetActive(true);
        }

        if (!Showed)
        {
            card.SetActive(false);
        }
    }
}
