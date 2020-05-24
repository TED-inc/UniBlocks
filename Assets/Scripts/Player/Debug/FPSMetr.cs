using UnityEngine;
using TMPro;

namespace TEDinc.UniBlocks
{
    public class FPSMetr : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text text;

        private void Update()
        {
            text.text = ((int)(1f / Time.deltaTime)).ToString();
        }
    }
}