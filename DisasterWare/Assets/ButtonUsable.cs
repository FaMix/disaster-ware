using UnityEngine;
using UnityEngine.UI;


public class ButtonUsable : MonoBehaviour
{
    public FrostEffect frostEffect;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
        GameObject frostEffectObject = GameObject.Find("Main Camera");
        // Assicurarsi che l'oggetto sia stato trovato
        if (frostEffectObject != null)
        {
            // Ottenere il componente "FrostEffect" dall'oggetto trovato
            FrostEffect frostEffect = frostEffectObject.GetComponent<FrostEffect>();
            if (frostEffect != null)
            {
                // Ora puoi utilizzare la variabile "frostEffect" per interagire con il componente FrostEffect
                // Ad esempio, puoi chiamare i metodi di "frostEffect" o accedere alle sue proprietà.
            }
            else
            {
                Debug.LogError("FrostEffect component not found on the object.");
            }
        }
        else
        {
            Debug.LogError("Object with FrostEffect script not found in the scene.");
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (frostEffect != null)
        {
            // Usa frostEffect.FrostAmount nella tua logica dell'Update
            if (frostEffect.FrostAmount > 0.5f)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }

    }
}
