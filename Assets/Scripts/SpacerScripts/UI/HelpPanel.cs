using UnityEngine;
using UnityEngine.UI;

namespace ProjectSpacer
{

    public class HelpPanel : MonoBehaviour
    {

        public GameObject EntryTemplate;

        // Use this for initialization
        void Start()
        {
            GameObject strafeEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            strafeEntry.GetRequiredComponent<Text>().text = "Ship Movement: WASD";
            GameObject steerEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            steerEntry.GetRequiredComponent<Text>().text = "Mouse: Steer Ship";
            GameObject fireEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            fireEntry.GetRequiredComponent<Text>().text = "Fire: Left Mouse Click";
            GameObject driftEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            driftEntry.GetRequiredComponent<Text>().text = "Toggle Drift Mode: L Shift";
            GameObject mouseEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            mouseEntry.GetRequiredComponent<Text>().text = "Toggle Mouse/Keyboard Steering: Space";
            GameObject rotEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            rotEntry.GetRequiredComponent<Text>().text = "Rotate in Keyboard Steering Mode: Q and E";
            GameObject zoomEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            zoomEntry.GetRequiredComponent<Text>().text = "Zoom In and Out: Mouse Wheel";
            GameObject layerUpEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            layerUpEntry.GetRequiredComponent<Text>().text = "Change Ship View Mode: R";
            GameObject helpEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            helpEntry.GetRequiredComponent<Text>().text = "Toggle Help Panel: F1";
            GameObject exitEntry = Instantiate(EntryTemplate, this.transform) as GameObject;
            exitEntry.GetRequiredComponent<Text>().text = "Quit: ESC";
        }



    }
}
