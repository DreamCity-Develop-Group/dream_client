using UnityEngine;
using UnityEngine.UI;

namespace Language
{
	[RequireComponent(typeof (Text))]
	[AddComponentMenu("Language/LanguageText")]

	public class LanguageText : UIBase {
		 public string Language;
		 public string File;
		 public string Key;
		 public string Value;

		public LanguageService Localization;
        // Use this for initialization

        private void Awake()
        {
            Bind(UIEvent.LANGUAGE_VIEW);
        }

        public override void Execute(int eventCode, object message)
        {
            switch (eventCode)
            {
                case UIEvent.LANGUAGE_VIEW:
                     Language = message.ToString();
                    SetTextLanguage(Language);
                    break;
                default:
                    break;
            }
        }

        private void SetTextLanguage(string language)
        {
            Localization = LanguageService.Instance;
            var label = GetComponent<Text>();
            GetComponent<Text>().text = Localization.GetFromFile(File, Key, label.text);
            string languagePath = "Localization/" + Language;
            Debug.Log(languagePath);
            Font t = Resources.Load<Font>(languagePath);

            GetComponent<Text>().font = t;
          //  Language = language;
        }

        void Start()
		{
			//Localization = LanguageService.Instance;
			//var label = GetComponent<Text>();
			//GetComponent<Text>().text = Localization.GetFromFile(File, Key, label.text);
		}

	}
}

