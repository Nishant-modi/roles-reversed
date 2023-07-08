<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GravitySlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    public Mover player;
    void Start()
    {
        slider.onValueChanged.AddListener((v) => { sliderText.text = v.ToString("0.00"); player.rb2.gravityScale=v; });
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GravitySlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    public Mover player;
    void Start()
    {
        slider.onValueChanged.AddListener((v) => { sliderText.text = v.ToString("0.00"); player.rb2.gravityScale=v; });
    }
}
>>>>>>> Stashed changes
