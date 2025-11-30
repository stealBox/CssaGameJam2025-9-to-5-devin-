using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{

    const string NAME_NONE = "Prime";
    const string NAME_EVO1 = "Speed";
    const string NAME_EVO2 = "Jump";
    const string NAME_EVO3 = "Glide";

    private static GlobalVars.Evolutions playerState;

    public string zoneName = "Level";

    public PlayerManager playerManager;
    public Text textZone;
    public Text textEvo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textZone.text = zoneName;
    }

    public void SetEvoText(GlobalVars.Evolutions evo) {
        switch (evo) {
            case GlobalVars.Evolutions.defaultEvo:
                textEvo.text = NAME_NONE;
                break;
            case GlobalVars.Evolutions.evo1:
                textEvo.text = NAME_EVO1;
                break;
            case GlobalVars.Evolutions.evo2:
                textEvo.text = NAME_EVO2;
                break;
            case GlobalVars.Evolutions.evo3:
                textEvo.text = NAME_EVO3;
                break;
        }
    }
}
