using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.IO;
using System.Linq;

public class PreViewSprite
    {
        public static bool ChangeSprite
        { get; set; }
    }

public class FieldsPathFile
{
    public string PathField;
    public string NameField;
}

public class Menu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject BrowserFilsPanel;
    public GameObject FilePole;
    public Button PrefabLinePath;
    public Button TurnBackButton;
    public GameObject ip;
    public GameObject port;
    public GameObject VersionGameCanvas;
    public GameObject VersionStatCanvas;
    public Text Path;
    private string FullPath;
    private string ParentDirectory;
    private string InSideMemoryDirectory;
    public Toggle Bacground1;
    public Toggle Bacground2;
    public Toggle Bacground3;
    public Toggle Bacground4;
    public Image Toggle4Background;
    public Image PrewviewImeg;
    public Image GameCanvasBackground;
    public Image TabelCanvasBackground;
    public GameObject LastGameCanvasBackground;
    public ParticleSystem Left;
    public ParticleSystem Up;
    public IEnumerator CorutineAddSprite;
    private Sprite BackgroundSprite;
    private static MonoBehaviour instance;
   
    List<FieldsPathFile> PathList = new List<FieldsPathFile>();

    void Awake()
    {
        instance = this;
    }

    void Start () {
        PreViewSprite.ChangeSprite = true;

        TurnBackButton.onClick.AddListener(delegate { InDerectory(UpPath(FullPath)); });

        Bacground1.onValueChanged.AddListener((value) => { ChangeBacground(Bacground1.name); });
        Bacground2.onValueChanged.AddListener((value) => { ChangeBacground(Bacground2.name); });
        Bacground3.onValueChanged.AddListener((value) => { ChangeBacground(Bacground3.name); });
        Bacground4.onValueChanged.AddListener((value) => { ChangeBacground(Bacground4.name); });

        AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.os.Environment");
        InSideMemoryDirectory = androidJavaClass.CallStatic<AndroidJavaObject>("getExternalStorageDirectory").Call<string>("getAbsolutePath");

        ParentDirectory = "/storage";
       // ParentDirectory = "D:\\";

        string stHost;
        int iPort;
 
        MainScript.DoGetServerParam(out stHost, out iPort);

        if (PlayerPrefs.HasKey("ipsave"))
        {           
           ip.GetComponent<InputField>().text = PlayerPrefs.GetString("ipsave");
        }
        else
        {
           ip.GetComponent<InputField>().text = stHost;
        }
        
        if (PlayerPrefs.HasKey("portsave"))
        {
            port.GetComponent<InputField>().text = Convert.ToString(PlayerPrefs.GetInt("portsave"));
        }
        else
        {
           port.GetComponent<InputField>().text = Convert.ToString(iPort);
        }    
       
        /// Version Application
        VersionGameCanvas.GetComponent<Text>().text =  Application.version;
        VersionStatCanvas.GetComponent<Text>().text =  Application.version;
       
        ChangeBacground(PlayerPrefs.GetString("ToggleOn", "BackgroundToggle1"));
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        Application.Quit();
	    }
	}

    public void OpenBrowserfilsPanel()
    {
        BrowserFilsPanel.SetActive(true);
        OpenBrowser();
    }

    private string WehnToggleOn()
    {
        string ToggleName = "";

        if (Bacground1.isOn == true)
        {
            ToggleName = "BackgroundToggle1";
            return ToggleName;
        }
        else if (Bacground2.isOn == true)
        {
            ToggleName = "BackgroundToggle2";
            return ToggleName;
        }
        else if (Bacground3.isOn == true)
        {
            ToggleName = "BackgroundToggle3";
            return ToggleName;
        }
        else if (Bacground4.isOn == true)
        {
            ToggleName = "BackgroundToggle4";
            return ToggleName;
        }

        return "BackgroundToggle1";
    }

    private void SetToggleOn(string ToggleName)
    {
        if (ToggleName == "BackgroundToggle1")
        {
            Bacground1.isOn = true;
        }
        else if (ToggleName == "BackgroundToggle2")
        {
            Bacground2.isOn = true;
        }
        else if (ToggleName == "BackgroundToggle3")
        {
            Bacground3.isOn = true;
        }
        else if (ToggleName == "BackgroundToggle4")
        {
            Bacground4.isOn = true;
        }
    }

    private IEnumerator ImageAsSprite(string filePath, Image View)
    {
        Texture2D texture = null;
        byte[] fileData;
        View.sprite = null;
        bool sp = true;
        

        while (sp)
        {   
            if (PreViewSprite.ChangeSprite == true)
            {
               PreViewSprite.ChangeSprite = false;
               fileData = File.ReadAllBytes(filePath);
               yield return null;
                
               if(fileData != null)
               { 
                   texture = new Texture2D(200, 100, TextureFormat.RGB24, true, false);
                   texture.LoadImage(fileData);
                   yield return null;
                   Rect rec = new Rect(0, 0, texture.width, texture.height);
                   PrewviewImeg.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                   View.sprite = Sprite.Create(texture, rec, new Vector2(1f, 1f), 100);
                   Resources.UnloadUnusedAssets();
                   texture = null;
                   PreViewSprite.ChangeSprite = true;
                   sp = false;
                   yield break;   
               }
                                   
            }
            sp = false;
            yield break;
        }
        sp = false;
    }

    public static Texture2D ConvertImegeToSprite(string filePath)
    {
        Texture2D tex = null;
        byte[] fileData;
  
        fileData = File.ReadAllBytes(filePath);
        tex = new Texture2D(1280, 720, TextureFormat.RGBA32, false);
        tex.LoadImage(fileData);
        
        return tex;
    }

    public Sprite ReturnSpriteFromImageFile(string Path)
    {
        Texture2D texture = ConvertImegeToSprite(Path);
        Rect rec = new Rect(0, 0, texture.width, texture.height);
        return Sprite.Create(ConvertImegeToSprite(Path), rec, new Vector2(1f, 1f), 100);
    }

    public void MenuOn()
    {
        Sprite SpriteObj = null;
        MenuPanel.SetActive(true);

        if (File.Exists(Application.persistentDataPath + "Background_4.png"))
        {
            SpriteObj = ReturnSpriteFromImageFile(Application.persistentDataPath + "Background_4.png");
            Resources.UnloadUnusedAssets();
        }

        Bacground4.interactable = (SpriteObj != null);

        if (Bacground4.interactable == true)
        {
            Toggle4Background.sprite = SpriteObj;           
        }

        SetToggleOn(PlayerPrefs.GetString("ToggleOn", "BackgroundToggle1"));
    }

    public void MenuOff()
    {
        MenuPanel.SetActive(false);
        if (MovePanelSetting.bButtonState == true)
        {
            MovePanelSetting.Anim.SetTrigger("Down");
            MovePanelSetting.bButtonState = false;
        }
    }

    public void CloseBrowserFilesPanel()
    {
        
        if (File.Exists(Application.persistentDataPath + "Background_4.png"))
        {
            BackgroundSprite = ReturnSpriteFromImageFile(Application.persistentDataPath + "Background_4.png");
            Toggle4Background.sprite =  BackgroundSprite;
            Bacground4.interactable = true;
            Resources.UnloadUnusedAssets();
        }

        ChangeBacground(WehnToggleOn());
        CleaDate();
        PrewviewImeg.sprite = null;
        PrewviewImeg.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        BrowserFilsPanel.SetActive(false);
       
        
    }

    public void Save()
    {
        PlayerPrefs.SetString("ipsave", ip.GetComponent<InputField>().text);
        PlayerPrefs.SetInt("portsave", Convert.ToInt32(port.GetComponent<InputField>().text));
        PlayerPrefs.SetString("ToggleOn", WehnToggleOn());
        PlayerPrefs.Save();
        MainScript.DoChangeServerParam(ip.GetComponent<InputField>().text, Convert.ToInt32(port.GetComponent<InputField>().text));       
        MenuOff();
    }

    public void ChangeBacground(string NameToggle)
    {
        switch (NameToggle)
        {
            case "BackgroundToggle1":
                GameCanvasBackground.sprite = Resources.Load<Sprite>("Background/Background_1");
                TabelCanvasBackground.sprite = Resources.Load<Sprite>("Background/Background_1");
               // LastGameCanvasBackground.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Background/Background_1");
                Left.Play(true);
                Up.Play(true);
                break;

            case "BackgroundToggle2":
                GameCanvasBackground.sprite = Resources.Load<Sprite>("Background/Background_2");
                TabelCanvasBackground.sprite = Resources.Load<Sprite>("Background/Background_2");
               // LastGameCanvasBackground.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Background/Background_2");
                Left.Pause(true);
                Up.Pause(true);
                break;

            case "BackgroundToggle3":
                GameCanvasBackground.sprite = Resources.Load<Sprite>("Background/Background_3");
                TabelCanvasBackground.sprite = Resources.Load<Sprite>("Background/Background_3");
               // LastGameCanvasBackground.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Background/Background_3");
                Left.Pause(true);
                Up.Pause(true);
                break;

            case "BackgroundToggle4":
                if (BackgroundSprite == null)
                {
                    BackgroundSprite = ReturnSpriteFromImageFile(Application.persistentDataPath + "Background_4.png");
                    Resources.UnloadUnusedAssets();
                }
                GameCanvasBackground.sprite = BackgroundSprite;
                TabelCanvasBackground.sprite = BackgroundSprite;
               // LastGameCanvasBackground.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Background/Background_1");
                Left.Pause(true);
                Up.Pause(true);
                break;

        }

    }

    public void SeveFileInRecources()
    {

        if (File.Exists(FullPath))
        {
           File.Copy(FullPath, Application.persistentDataPath + "Background_4.png", true);
        }
    }

   private void AddImegOnPreview(string path)
   {
     
      if (PreViewSprite.ChangeSprite == true)
      {
          instance.StopAllCoroutines();
          Resources.UnloadUnusedAssets();
          CorutineAddSprite = ImageAsSprite(path, PrewviewImeg);
          StartCoroutine(CorutineAddSprite);
          FullPath = path;
          Path.text = path;
      }
   
      
   }

    public string UpPath(string CurrPath)
    {
        if (CurrPath != ParentDirectory)
        {
            string path = (CurrPath.Remove(CurrPath.LastIndexOf("/")));
            return path;
        }
        else
        return CurrPath;
    }

    public void OpenBrowser()
    {
        Path.text = ParentDirectory;
        FullPath = ParentDirectory;

        GetListFilesAndFilder(ParentDirectory);
        GetListFilesAndFilder(InSideMemoryDirectory);

        Add_Line(PathList);
    }

    public void InDerectory(string PathWithButton)
    {
        CleaDate();
        Path.text = PathWithButton;
        PrewviewImeg.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        FullPath = PathWithButton;

        GetListFilesAndFilder(PathWithButton);

        if (FullPath == ParentDirectory)
        {
            GetListFilesAndFilder(InSideMemoryDirectory);
        }

        Add_Line(PathList);
    }

    private void GetListFilesAndFilder(string Path)
    {
        string[] subdirectoryEntries = Directory.GetDirectories(Path);
        foreach (string path in subdirectoryEntries)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if ((dir.Attributes & FileAttributes.Hidden) == 0)
            {
                String dirName = dir.Name;
                PathList.Add(new FieldsPathFile() { PathField = path, NameField = dirName });
            }
        }

        string[] fileEntries = Directory.GetFiles(Path, "*.png");

        foreach (string fileName in fileEntries)
        {
            DirectoryInfo dir = new DirectoryInfo(fileName);
            if ((dir.Attributes & FileAttributes.Hidden) == 0)
            {
                String dirName = dir.Name;
                PathList.Add(new FieldsPathFile() { PathField = fileName, NameField = dirName });
            }
        }

        string[] fileEntries2 = Directory.GetFiles(Path, "*.jpg");
        foreach (string fileName in fileEntries2)
        {
            DirectoryInfo dir = new DirectoryInfo(fileName);
            if ((dir.Attributes & FileAttributes.Hidden) == 0)
            {
                String dirName = dir.Name;
                PathList.Add(new FieldsPathFile() { PathField = fileName, NameField = dirName });
            }
        }
    }

    public void CleaDate()
    {
        foreach (Transform child in FilePole.transform)
        {
           GameObject.Destroy(child.gameObject);
        }

        FieldsPathFile n;
        for (int i = 0; i < PathList.Count; i++)
        {
           n = PathList[i];
           n = null;
        }

        PathList.Clear();
    }

    public void Add_Line(List<FieldsPathFile> A)
    {

        int line = A.Count;
        int step = -12;

        //размер прокрутки под количество полей
        FilePole.GetComponent<RectTransform>().sizeDelta = new Vector2(FilePole.GetComponent<RectTransform>().sizeDelta.x, (20 * line) + 5f) ;

        foreach (FieldsPathFile aPart in A)
        {
            Button button = (Button)Instantiate(PrefabLinePath);
            button.transform.SetParent(FilePole.transform);
            button.GetComponent<RectTransform>().localPosition = new Vector2(140f, step);
            button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            button.name = aPart.NameField;
            button.GetComponentInChildren<Text>().GetComponent<Text>().text = aPart.NameField;
            step = step - 20;
            if (Directory.Exists(aPart.PathField))
            {
               button.onClick.AddListener(delegate { InDerectory(aPart.PathField); });
            }
            else if (File.Exists(aPart.PathField))
            {
               button.onClick.AddListener(delegate { AddImegOnPreview(aPart.PathField); });
            }
        }

    }

}
