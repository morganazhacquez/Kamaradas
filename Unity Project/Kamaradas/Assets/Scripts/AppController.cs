using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kamaradas
{
    public class AppController : MonoBehaviour
    {
        [Header("Input Fields")]
        [SerializeField] TMP_InputField Username_Input;
        [SerializeField] TMP_InputField CPF_Input;
        [SerializeField] TMP_InputField Password_Input;
        [SerializeField] TMP_InputField Confirm_Password_Input;

        [Header("Switch Fields")]
        [SerializeField] TextMeshProUGUI SwitchButtonText;
        [SerializeField] Image SwitchButtonColor;
        [SerializeField] GameObject Confirm_Password;

        bool loginMode;

        void Start()
        {
            SwitchMode();
        }

        public void SwitchMode()
        {
            if (loginMode) //Entra em modo registro
            {
                loginMode = false;
                SwitchButtonText.text = "Já tenho conta";
                SwitchButtonColor.color = Color.darkGreen;
                Confirm_Password.SetActive(true);
            }
            else //Entra em modo login
            {
                loginMode = true;
                SwitchButtonText.text = "Não tenho conta";
                SwitchButtonColor.color = Color.darkRed;
                Confirm_Password.SetActive(false);
            }
        }

        public void ContinueToLogin()
        {
            string username = Username_Input.text;
            string cpf = CPF_Input.text;
            string password = Password_Input.text;
            string confirmPassword = Confirm_Password_Input.text;
        }
    }
}