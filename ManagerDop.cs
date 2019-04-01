using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using tvout;
using System.Linq;
using System;

public class DOP
{
    public GameObject DopObject;
    public GameObject DopSkin;
    public GameObject DopName;
    public GameObject DopCircle;
    public GameObject DopRegimName;
    public int DopId;
    public tvout_DopType DopKind;

}

public class KTSmart: DOP
{
    public tvout_KTSmartType Regim_KTS;
}


public class KTSmart_CaptureTime: KTSmart
{
    public GameObject FirstCommandTime;
    public GameObject SecondCommandTime;
    public GameObject ThirdCommandTime;
    public GameObject FourthCommandTime;
    public List<SliderAndType> ListSliders;

    public void FillListSliders(GameObject FirstSlider, GameObject SecondSlider, GameObject ThirdSlider, GameObject FourthSlider, List<tvout_TCommandType> CommandType)
    {
        ListSliders = new List<SliderAndType>();

        for (int i = 0; i < CommandType.Count; i++)
        {
            if (i == 0)
            {
                ListSliders.Add(new SliderAndType() { Slider = FirstSlider, CommandType = CommandType[0] });
            }
            if (i == 1)
            {
                ListSliders.Add(new SliderAndType() { Slider = SecondSlider, CommandType = CommandType[1] });
            }
            if (i == 2)
            {
                ListSliders.Add(new SliderAndType() { Slider = ThirdSlider, CommandType = CommandType[2] });
            }
            if (i == 3)
            {
                ListSliders.Add(new SliderAndType() { Slider = FourthSlider, CommandType = CommandType[3] });
            }
        }
    }
}

public class SliderAndType
{
    public GameObject Slider;
    public tvout_TCommandType CommandType;
}

public class KTSmart_CaptureShots : KTSmart
{
    public GameObject FirstCommandShots;
    public GameObject SecondCommandShots;
    public GameObject ThirdCommandShots;
    public GameObject FourthCommandShots;
    public List <SliderAndType> ListSliders;

    public void FillListSliders(GameObject FirstSlider, GameObject SecondSlider, GameObject ThirdSlider, GameObject FourthSlider, List<tvout_TCommandType> CommandType)
    {
        ListSliders = new List<SliderAndType>();

        for (int i = 0; i < CommandType.Count; i++)
        {
            if (i == 0)
            {
                ListSliders.Add(new SliderAndType() { Slider = FirstSlider, CommandType = CommandType[0] });
            }
            if (i == 1)
            {
                ListSliders.Add(new SliderAndType() { Slider = SecondSlider, CommandType = CommandType[1] });
            }
            if (i == 2)
            {
                ListSliders.Add(new SliderAndType() { Slider = ThirdSlider, CommandType = CommandType[2] });
            }
            if (i == 3)
            {
                ListSliders.Add(new SliderAndType() { Slider = FourthSlider, CommandType = CommandType[3] });
            }
        }      
    }
}

public class KTSmart_CaptureThird : KTSmart
{
    public GameObject FirstCommandValue;
    public GameObject SecondCommandValue;
    public GameObject ThirdCommandValue;
    public List<SliderAndType> ListSliders;

    public void FillListSliders(GameObject FirstSlider, GameObject SecondSlider, GameObject ThirdSlider, List<tvout_TCommandType> CommandType)
    {
        ListSliders = new List<SliderAndType>();

        for (int i = 0; i < CommandType.Count; i++)
        {
            if (i == 0)
            {
                ListSliders.Add(new SliderAndType() { Slider = FirstSlider, CommandType = CommandType[0] });
            }
            if (i == 1)
            {
                ListSliders.Add(new SliderAndType() { Slider = SecondSlider, CommandType = CommandType[1] });
            }
            if (i == 2)
            {
                ListSliders.Add(new SliderAndType() { Slider = ThirdSlider, CommandType = CommandType[2] });
            }           
        }
    }
}

public class KTSmart_TugOfWar : KTSmart
{
    public GameObject FirstCommandPercent;
    public GameObject SecondCommandPercent;
    public List<SliderAndType> ListSliders;

    public void FillListSliders(GameObject FirstSlider, GameObject SecondSlider, List<tvout_TCommandType> CommandType)
    {
        ListSliders = new List<SliderAndType>();

        for (int i = 0; i < CommandType.Count; i++)
        {
            if (i == 0)
            {
                ListSliders.Add(new SliderAndType() { Slider = FirstSlider, CommandType = CommandType[0] });
            }
            if (i == 1)
            {
                ListSliders.Add(new SliderAndType() { Slider = SecondSlider, CommandType = CommandType[1] });
            }          
        }
    }
}

public class KTSmart_FlagUp : KTSmart
{
    public GameObject RedCommandHealth;
    public GameObject BlueCommandHealth;
    public GameObject YellowCommandHealth;
    public GameObject GreenCommandHealth;
}

public class Sirius: DOP
{
    public tvout_SiriusType Regim_Sirius;
}

public class Sirius_Base : Sirius
{
    public GameObject Base_Life;
}

public class MS : DOP
{
    public tvout_MSType Regim_MS;
}

public class MS_Base : MS
{

    public GameObject Base_Life;
}

public class MS_ControlPoint : MS
{
    public GameObject RedPoint;
    public GameObject BluePoint;
    public GameObject YellowPoint;
    public GameObject GreenPoint;
}


/// Masseg with data for KTS
public class StatisticDataForKTS
{
    public int KTs_id;
    public int Red_Value;
    public int Blue_Value;
    public int Yellow_Value;
    public int Green_Value;
}

/// Masseg with data for Sirius
public class StatisticDataForSirius
{
    public int Sirius_id;
    public int Base_LifeValue;
}

// Masseg with data for MS
public class StatisticDataForMS
{
    public int MS_id;
    public int Red_Value;
    public int Blue_Value;
    public int Yellow_Value;
    public int Green_Value;
}



public class ManagerDop : MonoBehaviour
{
    public static List<DOP> ListDop = new List<DOP>();   
    public static List<tvout_TCommandType> CommandsInScenariy = new List<tvout_TCommandType>();

    public Camera OrigDOP_Camera;
    public GameObject OrigPlaceForDop;

    public GameObject OrigKTSmart_CaptureTimePrefab;
    public GameObject OrigKTSmart_CaptureShotsPrefab;
    public GameObject OrigKTSmart_CaptureThirdPrefab;
    public GameObject OrigKTSmart_TugOfWarPrefab;
    public GameObject OrigKTSmart_FlagUpPrefab;

    public GameObject OrigSirius_BasePrefab;

    public GameObject OrigMS_BasePrefab;
    public GameObject OrigMS_ControlPointPrefab;

    public Sprite OrigSlideRed;
    public Sprite OrigSlideBlue;
    public Sprite OrigSlideYellow;
    public Sprite OrigSlideGreen;

    public Sprite OrigRedSkin;
    public Sprite OrigBlueSkin;
    public Sprite OrigYellowSkin;
    public Sprite OrigGreenSkin;
    public Sprite OrigWhiteSkin;

    public Sprite OrigRedCircle;
    public Sprite OrigBlueCircle;
    public Sprite OrigYellowCircle;
    public Sprite OrigGreenCircle;
    public Sprite OrigWhiteCircle;

    ///--------------------------------
    public static Camera DOP_Camera;
    public static GameObject PlaceForDop;

    public static GameObject KTSmart_CaptureTimePrefab;
    public static GameObject KTSmart_CaptureShotsPrefab;
    public static GameObject KTSmart_CaptureThirdPrefab;
    public static GameObject KTSmart_TugOfWarPrefab;
    public static GameObject KTSmart_FlagUpPrefab;

    public static GameObject Sirius_BasePrefab;

    public static GameObject MS_BasePrefab;
    public static GameObject MS_ControlPointPrefab;

    public static Sprite SlideRed;
    public static Sprite SlideBlue;
    public static Sprite SlideYellow;
    public static Sprite SlideGreen;

    public static Sprite RedSkin;
    public static Sprite BlueSkin;
    public static Sprite YellowSkin;
    public static Sprite GreenSkin;
    public static Sprite WhiteSkin;

    public static Sprite RedCircle;
    public static Sprite BlueCircle;
    public static Sprite YellowCircle;
    public static Sprite GreenCircle;
    public static Sprite WhiteCircle;

    public static int DOP_Layers1;
    public static int DOP_Layers2;
    public static int DOP_Layers3;

    public static int ActiveLayer;
    public static int LayersCount;
    private static MonoBehaviour instance;


    public static StatisticDataForKTS StatisticDateKTS;
    public static StatisticDataForSirius StatisticDataSirius;   
    public static StatisticDataForMS StatisticDataMS;
   


    void Awake()
    {
        DOP_Camera = OrigDOP_Camera;
        PlaceForDop = OrigPlaceForDop;
        KTSmart_CaptureTimePrefab = OrigKTSmart_CaptureTimePrefab;
        KTSmart_CaptureShotsPrefab = OrigKTSmart_CaptureShotsPrefab;
        KTSmart_CaptureThirdPrefab = OrigKTSmart_CaptureThirdPrefab;
        KTSmart_TugOfWarPrefab = OrigKTSmart_TugOfWarPrefab;
        KTSmart_FlagUpPrefab = OrigKTSmart_FlagUpPrefab;
        Sirius_BasePrefab = OrigSirius_BasePrefab;
        MS_BasePrefab = OrigMS_BasePrefab;
        MS_ControlPointPrefab = OrigMS_ControlPointPrefab;
        SlideRed = OrigSlideRed;
        SlideBlue = OrigSlideBlue;
        SlideYellow = OrigSlideYellow;
        SlideGreen = OrigSlideGreen;
        RedSkin = OrigRedSkin;
        BlueSkin = OrigBlueSkin;
        YellowSkin = OrigYellowSkin;
        GreenSkin = OrigGreenSkin;
        WhiteSkin = OrigWhiteSkin;
        RedCircle = OrigRedCircle;
        BlueCircle = OrigBlueCircle;
        YellowCircle = OrigYellowCircle;
        GreenCircle = OrigGreenCircle;
        WhiteCircle = OrigWhiteCircle;

        DOP_Layers1 = 10;
        DOP_Layers2 = 11;
        DOP_Layers3 = 12;
        LayersCount = 1;

        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        ActiveLayer = DOP_Layers1;
    }
   
    // отправляем полученные данные в КТСмарт
    public static void AddDataKTSmart(StatisticDataForKTS StatisticDateForKTS)
    {
        for (int i = 0; i < ListDop.Count; i++)
        {
            if (ListDop[i].DopKind == tvout_DopType.dtDopKTSmart)
            {
                if (ListDop[i].DopId == StatisticDateForKTS.KTs_id)
                {
                    KTSmart KTSmart = (KTSmart)ListDop[i];
                    if (KTSmart.Regim_KTS == tvout_KTSmartType.ktstTimeCapture)
                    {
                        KTSmart_CaptureTime KTSmart_CaptureTime = (KTSmart_CaptureTime)KTSmart;
                        for (int y = 0; y < KTSmart_CaptureTime.ListSliders.Count; y++)
                        {
                            switch (KTSmart_CaptureTime.ListSliders[y].CommandType)
                            {
                                case tvout_TCommandType.ctRed:
                                    KTSmart_CaptureTime.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Red_Value;
                                    break;
                                case tvout_TCommandType.ctBlue:
                                    KTSmart_CaptureTime.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Blue_Value;
                                    break;
                                case tvout_TCommandType.ctYellow:
                                    KTSmart_CaptureTime.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Yellow_Value;
                                    break;
                                case tvout_TCommandType.ctGreen:
                                    KTSmart_CaptureTime.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Green_Value;
                                    break;
                            }
                        }
                    }
                    else
                    if (KTSmart.Regim_KTS == tvout_KTSmartType.ktstCaptureByShot)
                    {
                        KTSmart_CaptureShots KTSmart_CaptureShots = (KTSmart_CaptureShots)KTSmart;
                        for (int y = 0; y < KTSmart_CaptureShots.ListSliders.Count; y++)
                        {
                            switch (KTSmart_CaptureShots.ListSliders[y].CommandType)
                            {
                                case tvout_TCommandType.ctRed:
                                    KTSmart_CaptureShots.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Red_Value;
                                    break;
                                case tvout_TCommandType.ctBlue:
                                    KTSmart_CaptureShots.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Blue_Value;
                                    break;
                                case tvout_TCommandType.ctYellow:
                                    KTSmart_CaptureShots.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Yellow_Value;
                                    break;
                                case tvout_TCommandType.ctGreen:
                                    KTSmart_CaptureShots.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Green_Value;
                                    break;
                            }
                        }
                    }
                    else
                    if (KTSmart.Regim_KTS == tvout_KTSmartType.ktstThreePerson)
                    {
                        KTSmart_CaptureThird KTSmart_CaptureThird = (KTSmart_CaptureThird)KTSmart;
                        for (int y = 0; y < KTSmart_CaptureThird.ListSliders.Count; y++)
                        {
                            switch (KTSmart_CaptureThird.ListSliders[y].CommandType)
                            {
                                case tvout_TCommandType.ctRed:
                                    KTSmart_CaptureThird.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Red_Value;
                                    break;
                                case tvout_TCommandType.ctBlue:
                                    KTSmart_CaptureThird.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Blue_Value;
                                    break;
                                case tvout_TCommandType.ctYellow:
                                    KTSmart_CaptureThird.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Yellow_Value;
                                    break;
                                case tvout_TCommandType.ctGreen:
                                    KTSmart_CaptureThird.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Green_Value;
                                    break;
                            }
                        }
                    }
                    else
                    if(KTSmart.Regim_KTS == tvout_KTSmartType.ktstTugOfWar)
                    {
                        KTSmart_TugOfWar KTSmart_TugOfWar = (KTSmart_TugOfWar)KTSmart;
                        for (int y = 0; y < KTSmart_TugOfWar.ListSliders.Count; y++)
                        {
                            switch (KTSmart_TugOfWar.ListSliders[y].CommandType)
                            {
                                case tvout_TCommandType.ctRed:
                                    KTSmart_TugOfWar.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Red_Value;
                                    break;
                                case tvout_TCommandType.ctBlue:
                                    KTSmart_TugOfWar.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Blue_Value;
                                    break;
                                case tvout_TCommandType.ctYellow:
                                    KTSmart_TugOfWar.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Yellow_Value;
                                    break;
                                case tvout_TCommandType.ctGreen:
                                    KTSmart_TugOfWar.ListSliders[y].Slider.GetComponent<Slider>().value = StatisticDateForKTS.Green_Value;
                                    break;
                            }
                        }
                    }
                    else
                    if (KTSmart.Regim_KTS == tvout_KTSmartType.ktstCaptureFlag)
                    {
                        KTSmart_FlagUp KTSmart_FlagUp = (KTSmart_FlagUp)KTSmart;

                        KTSmart_FlagUp.RedCommandHealth.GetComponent<Slider>().value = StatisticDateForKTS.Red_Value;
                        KTSmart_FlagUp.BlueCommandHealth.GetComponent<Slider>().value = StatisticDateForKTS.Blue_Value;
                        KTSmart_FlagUp.YellowCommandHealth.GetComponent<Slider>().value = StatisticDateForKTS.Yellow_Value;
                        KTSmart_FlagUp.GreenCommandHealth.GetComponent<Slider>().value = StatisticDateForKTS.Green_Value;
                    }
                }         
            }           
        }      
    }

    // отправляем полученные данные в Сириус
    public static void AddDataSirius(StatisticDataForSirius StatisticDataForSirius)
    {
        for (int i = 0; i < ListDop.Count; i++)
        {
            if (ListDop[i].DopKind == tvout_DopType.dtDopSirius)
            {
                if (ListDop[i].DopId == StatisticDataForSirius.Sirius_id)
                {
                    Sirius Sirius = (Sirius)ListDop[i];
                    if(Sirius.Regim_Sirius == tvout_SiriusType.sirtBase)
                    {
                        Sirius_Base Sirius_Base = (Sirius_Base)Sirius;
                        Sirius_Base.Base_Life.GetComponent<Slider>().value = StatisticDataForSirius.Base_LifeValue;
                    }
                }

            }
        }
    }

    // отправляем полученные данные в МС
    public static void AddDataMS(StatisticDataForMS StatisticDataForMS)
    {
        for (int i = 0; i < ListDop.Count; i++)
        {
            if (ListDop[i].DopKind == tvout_DopType.dtDopMS)
            {
                if (ListDop[i].DopId == StatisticDataForMS.MS_id)
                {
                   MS MS = (MS)ListDop[i];
                   if( MS.Regim_MS == tvout_MSType.mstControlPoint)
                   {
                        MS_ControlPoint MS_ControlPoint = (MS_ControlPoint)MS;
                        MS_ControlPoint.RedPoint.GetComponent<TextMesh>().text = StatisticDataForMS.Red_Value.ToString();
                        MS_ControlPoint.BluePoint.GetComponent<TextMesh>().text = StatisticDataForMS.Blue_Value.ToString();
                        MS_ControlPoint.YellowPoint.GetComponent<TextMesh>().text = StatisticDataForMS.Yellow_Value.ToString();
                        MS_ControlPoint.GreenPoint.GetComponent<TextMesh>().text = StatisticDataForMS.Green_Value.ToString();
                   }
                   else
                   if(MS.Regim_MS == tvout_MSType.mstBase)
                   {
                        MS_Base MS_Base = (MS_Base)MS;
                        MS_Base.Base_Life.GetComponent<Slider>().value = StatisticDataForMS.Red_Value;
                   }
                }
            }
        }
    }

    ///  Лист играющих команд в сценарие
    public static void CreatListGamingCommans()
    {
        CommandsInScenariy.Clear();

        foreach (TMyCommand i in TMyCommandList.CommandList)
        {
            if (i.InGame == true)
            {
                CommandsInScenariy.Add(i.CommandType);
            }                 
        }
    }

    // получаем данные статистики доп. устройств
    public static void ReceavDataForStatisticDop(tvout_DopStatistic tvout_DopStatistic)
    {

        switch(tvout_DopStatistic.tvout_DopInfo.DopType)
        {
            case tvout_DopType.dtDopKTSmart:

                StatisticDateKTS = new StatisticDataForKTS
                {
                    KTs_id = tvout_DopStatistic.tvout_DopInfo.DopID
                };

                if (tvout_DopStatistic.Red_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDateKTS.Red_Value = tvout_DopStatistic.Red_Value;
                }
                if (tvout_DopStatistic.Blue_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDateKTS.Blue_Value = tvout_DopStatistic.Blue_Value;
                }
                if (tvout_DopStatistic.Yellow_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDateKTS.Yellow_Value = tvout_DopStatistic.Yellow_Value;
                }
                if (tvout_DopStatistic.Green_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDateKTS.Green_Value = tvout_DopStatistic.Green_Value;
                }

                AddDataKTSmart(StatisticDateKTS);
                break;

            case tvout_DopType.dtDopMS:

                StatisticDataMS = new StatisticDataForMS
                {
                    MS_id = tvout_DopStatistic.tvout_DopInfo.DopID
                };

                if (tvout_DopStatistic.Red_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDataMS.Red_Value = tvout_DopStatistic.Red_Value;
                }
                if (tvout_DopStatistic.Blue_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDataMS.Blue_Value = tvout_DopStatistic.Blue_Value;
                }
                if (tvout_DopStatistic.Yellow_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDataMS.Yellow_Value = tvout_DopStatistic.Yellow_Value;
                }
                if (tvout_DopStatistic.Green_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDataMS.Green_Value = tvout_DopStatistic.Green_Value;
                }
                AddDataMS(StatisticDataMS);
                break;

            case tvout_DopType.dtDopSirius:

                StatisticDataSirius = new StatisticDataForSirius
                {
                    Sirius_id = tvout_DopStatistic.tvout_DopInfo.DopID
                };

                if (tvout_DopStatistic.Red_Value != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
                {
                    StatisticDataSirius.Base_LifeValue = tvout_DopStatistic.Red_Value;
                }
                AddDataSirius(StatisticDataSirius);
                break;

        }

    }

    public static void CreateKTSmart(tvout_AddKTSmartDop addKTSmartDop)
    {
        CreatDopKTSPrefab(addKTSmartDop.KTSmartType, addKTSmartDop.tvout_DopInfo.DopID);
        AddDopPrefabsOnView(PlaceForDop, ListDop);
    }

    public static void CreateMS(tvout_AddMSDop addMSDop)
    {
        CreatDopMSPrefab(addMSDop.MSType, addMSDop.BaseCommand, addMSDop.tvout_DopInfo.DopID);
        AddDopPrefabsOnView(PlaceForDop, ListDop);
    }

    public static void CreateSirius(tvout_AddSiriusDop addSiriusDop)
    {
        CreatDopSiriusPrefab(addSiriusDop.SiriusType, addSiriusDop.BaseCommand, addSiriusDop.tvout_DopInfo.DopID);
        AddDopPrefabsOnView(PlaceForDop, ListDop);
    }


    public static void CleanAllDopDataAndObject()
    {
        if (ListDop.Count > 0)
        {
            foreach(DOP i in ListDop)
            {
                Destroy(i.DopObject);
            }
            
            //foreach (Transform child in PlaceForDop.transform)
            //{
            //   Destroy(child.gameObject);
            //}

            ListDop.Clear();
        }
        
        MainScript.SizeChatSprite(0);
    }

    public static void CreatDopKTSPrefab(tvout_KTSmartType KTSRegim, int Id)
    {
        GameObject obg;
        string PrefabName;

        switch (KTSRegim)
        {
            case tvout_KTSmartType.ktstTimeCapture:
                PrefabName = "KTSmart_CaptureTimePrefab_ID_" + Id + "_" + Time.deltaTime;
                obg = Instantiate(KTSmart_CaptureTimePrefab);
                obg.name = PrefabName;
                obg.transform.parent = PlaceForDop.transform;

                KTSmart_CaptureTime KTSmart_CaptureTime = new KTSmart_CaptureTime
                {
                    DopObject = obg,
                    DopId = Id,
                    DopSkin = GameObject.Find(PrefabName + "/Skin"),
                    DopKind = tvout_DopType.dtDopKTSmart,
                    Regim_KTS = tvout_KTSmartType.ktstTimeCapture,
                    DopName = GameObject.Find(PrefabName + "/DopName"),
                    DopCircle = GameObject.Find(PrefabName + "/Circle"),
                    DopRegimName = GameObject.Find(PrefabName + "/RegimNameKTSmart"),
                    FirstCommandTime = GameObject.Find(PrefabName + "Canvas/SliderFirstCommandTime"),
                    SecondCommandTime = GameObject.Find(PrefabName + "Canvas/SliderSecondCommandTime"),
                    ThirdCommandTime = GameObject.Find(PrefabName + "Canvas/SliderThirdCommandTime"),
                    FourthCommandTime = GameObject.Find(PrefabName + "Canvas/SliderFourthCommandTime"),
                };

                KTSmart_CaptureTime.FirstCommandTime.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[0]);
                KTSmart_CaptureTime.FirstCommandTime.GetComponent<Slider>().value = 100;

                if (CommandsInScenariy.Count > 1)
                {
                    KTSmart_CaptureTime.SecondCommandTime.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[1]);
                    KTSmart_CaptureTime.SecondCommandTime.GetComponent<Slider>().value = 100;
                }
                if (CommandsInScenariy.Count > 2)
                {
                    KTSmart_CaptureTime.ThirdCommandTime.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[2]);
                    KTSmart_CaptureTime.ThirdCommandTime.GetComponent<Slider>().value = 100;
                }
                if (CommandsInScenariy.Count > 3)
                {
                    KTSmart_CaptureTime.FourthCommandTime.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[3]);
                    KTSmart_CaptureTime.FourthCommandTime.GetComponent<Slider>().value = 100;
                }

                KTSmart_CaptureTime.DopName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).KTSmart;
                KTSmart_CaptureTime.DopRegimName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).CapturTime;

                KTSmart_CaptureTime.FillListSliders(KTSmart_CaptureTime.FirstCommandTime, KTSmart_CaptureTime.SecondCommandTime,
                                                        KTSmart_CaptureTime.ThirdCommandTime, KTSmart_CaptureTime.FourthCommandTime, CommandsInScenariy);
                ListDop.Add(KTSmart_CaptureTime);
                
                break;
                                
            case tvout_KTSmartType.ktstCaptureByShot:
                PrefabName = "KTSmart_CaptureShotPrefab_ID_" + Id + "_" + Time.deltaTime;
                obg = Instantiate(KTSmart_CaptureShotsPrefab);
                obg.name = PrefabName;
                obg.transform.parent = PlaceForDop.transform;


                KTSmart_CaptureShots KTSmart_CaptureShots = new KTSmart_CaptureShots
                {
                    DopObject = obg,
                    DopId = Id,
                    DopSkin = GameObject.Find(PrefabName + "/Skin"),
                    DopKind = tvout_DopType.dtDopKTSmart,
                    Regim_KTS = tvout_KTSmartType.ktstCaptureByShot,
                    DopName = GameObject.Find(PrefabName + "/DopName"),
                    DopCircle = GameObject.Find(PrefabName + "/Circle"),
                    DopRegimName = GameObject.Find(PrefabName + "/RegimNameKTSmart"),
                    FirstCommandShots = GameObject.Find(PrefabName + "Canvas/SliderFirstCommandShots"),
                    SecondCommandShots = GameObject.Find(PrefabName + "Canvas/SliderSecondCommandShots"),
                    ThirdCommandShots = GameObject.Find(PrefabName + "Canvas/SliderThirdCommandShots"),
                    FourthCommandShots = GameObject.Find(PrefabName + "Canvas/SliderFourthCommandShots")
                };

                KTSmart_CaptureShots.FirstCommandShots.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[0]);
                KTSmart_CaptureShots.FirstCommandShots.GetComponent<Slider>().value = 100;
                if (CommandsInScenariy.Count > 1)
                {
                    KTSmart_CaptureShots.SecondCommandShots.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[1]);
                    KTSmart_CaptureShots.SecondCommandShots.GetComponent<Slider>().value = 100;
                }
                if (CommandsInScenariy.Count > 2)
                {
                    KTSmart_CaptureShots.ThirdCommandShots.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[2]);
                    KTSmart_CaptureShots.ThirdCommandShots.GetComponent<Slider>().value = 100;
                }
                if (CommandsInScenariy.Count > 3)
                {
                    KTSmart_CaptureShots.FourthCommandShots.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[3]);
                    KTSmart_CaptureShots.FourthCommandShots.GetComponent<Slider>().value = 100;
                }

                KTSmart_CaptureShots.DopName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).KTSmart;
                KTSmart_CaptureShots.DopRegimName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).CapureShots;

                KTSmart_CaptureShots.FillListSliders(KTSmart_CaptureShots.FirstCommandShots, KTSmart_CaptureShots.SecondCommandShots,
                                    KTSmart_CaptureShots.ThirdCommandShots, KTSmart_CaptureShots.FourthCommandShots, CommandsInScenariy);
                ListDop.Add(KTSmart_CaptureShots);                                
                break;

            case tvout_KTSmartType.ktstThreePerson:
                PrefabName = "KTSmart_CaptureThirdPrefab_ID_" + Id + "_" + Time.deltaTime;
                obg = Instantiate(KTSmart_CaptureThirdPrefab);
                obg.name = PrefabName;
                obg.transform.parent = PlaceForDop.transform;

                KTSmart_CaptureThird KTSmart_CaptureThird = new KTSmart_CaptureThird
                {
                    DopObject = obg,
                    DopId = Id,
                    DopSkin = GameObject.Find(PrefabName + "/Skin"),
                    DopKind = tvout_DopType.dtDopKTSmart,
                    Regim_KTS = tvout_KTSmartType.ktstThreePerson,
                    DopName = GameObject.Find(PrefabName + "/DopName"),
                    DopCircle = GameObject.Find(PrefabName + "/Circle"),
                    DopRegimName = GameObject.Find(PrefabName + "/RegimNameKTSmart"),
                    FirstCommandValue = GameObject.Find(PrefabName + "Canvas/SliderFirstCommandValue"),
                    SecondCommandValue = GameObject.Find(PrefabName + "Canvas/SliderSecondCommandValue"),
                    ThirdCommandValue = GameObject.Find(PrefabName + "Canvas/SliderThirdCommandValue")
                };

                KTSmart_CaptureThird.FirstCommandValue.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[0]);
                KTSmart_CaptureThird.FirstCommandValue.GetComponent<Slider>().value = 100;
                if (CommandsInScenariy.Count > 1)
                {
                    KTSmart_CaptureThird.SecondCommandValue.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[1]);
                    KTSmart_CaptureThird.SecondCommandValue.GetComponent<Slider>().value = 100;
                }
                if (CommandsInScenariy.Count > 2)
                {
                    KTSmart_CaptureThird.ThirdCommandValue.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[2]);
                    KTSmart_CaptureThird.ThirdCommandValue.GetComponent<Slider>().value = 100;
                }

                KTSmart_CaptureThird.DopName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).KTSmart;
                KTSmart_CaptureThird.DopRegimName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).CaptureThird;

                KTSmart_CaptureThird.FillListSliders(KTSmart_CaptureThird.FirstCommandValue, KTSmart_CaptureThird.SecondCommandValue,
                                                     KTSmart_CaptureThird.ThirdCommandValue, CommandsInScenariy);

                ListDop.Add(KTSmart_CaptureThird);          
                break;

            case tvout_KTSmartType.ktstTugOfWar:
                PrefabName = "KTSmart_FlagUpPrefab_ID_" + Id + "_" + Time.deltaTime;
                obg = Instantiate(KTSmart_TugOfWarPrefab);
                obg.name = PrefabName;
                obg.transform.parent = PlaceForDop.transform;


                obg.transform.Find("Canvas/SliderFirstCommandPercent/Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[0]);

                if (CommandsInScenariy.Count > 1)
                {
                    obg.transform.Find("Canvas/SliderSecondCommandPercent/Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(CommandsInScenariy[1]);
                }

                KTSmart_TugOfWar KTSmart_TugOfWar = new KTSmart_TugOfWar
                {
                    DopObject = obg,
                    DopId = Id,
                    DopSkin = GameObject.Find(PrefabName + "/Skin"),
                    DopKind = tvout_DopType.dtDopKTSmart,
                    Regim_KTS = tvout_KTSmartType.ktstTugOfWar,
                    DopName = GameObject.Find(PrefabName + "/DopName"),
                    DopCircle = GameObject.Find(PrefabName + "/Circle"),
                    DopRegimName = GameObject.Find(PrefabName + "/RegimNameKTSmart"),
                    FirstCommandPercent = GameObject.Find(PrefabName + "Canvas/SliderFirstCommandPercent"),
                    SecondCommandPercent = GameObject.Find(PrefabName + "Canvas/SliderSecondCommandPercent")
                };

                KTSmart_TugOfWar.DopName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).KTSmart;
                KTSmart_TugOfWar.DopRegimName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).TugOfWar;

                KTSmart_TugOfWar.FillListSliders(KTSmart_TugOfWar.FirstCommandPercent, KTSmart_TugOfWar.SecondCommandPercent, CommandsInScenariy);

                ListDop.Add(KTSmart_TugOfWar); 
                break;

            case tvout_KTSmartType.ktstCaptureFlag:
                PrefabName = "KTSmart_FlagUpPrefab_ID_" + Id + "_" + Time.deltaTime;
                obg = Instantiate(KTSmart_FlagUpPrefab);
                obg.name = PrefabName;
                obg.transform.parent = PlaceForDop.transform;

                KTSmart_FlagUp KTSmart_FlagUp = new KTSmart_FlagUp
                {
                    DopObject = obg,
                    DopId = Id,
                    DopSkin = GameObject.Find(PrefabName + "/Skin"),
                    DopKind = tvout_DopType.dtDopKTSmart,
                    Regim_KTS = tvout_KTSmartType.ktstCaptureFlag,
                    DopName = GameObject.Find(PrefabName + "/DopName"),
                    DopCircle = GameObject.Find(PrefabName + "/Circle"),
                    DopRegimName = GameObject.Find(PrefabName + "/RegimNameKTSmart"),
                    RedCommandHealth = GameObject.Find(PrefabName + "Canvas/SliderRedCommandHealth"),
                    BlueCommandHealth = GameObject.Find(PrefabName + "Canvas/SliderBlueCommandHealth"),
                    YellowCommandHealth = GameObject.Find(PrefabName + "Canvas/SliderYellowCommandHealth"),
                    GreenCommandHealth = GameObject.Find(PrefabName + "Canvas/SliderGreenCommandHealth")
                };

                KTSmart_FlagUp.DopName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).KTSmart;
                KTSmart_FlagUp.DopRegimName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).FlagUp;

                ListDop.Add(KTSmart_FlagUp);
                break;

        }

    }

    public static void CreatDopSiriusPrefab(tvout_SiriusType SiriusRegim, tvout_TCommandType BaseCommand, int Id)
    {
        GameObject obg;
        string PrefabName;

        switch (SiriusRegim)
        {
            case tvout_SiriusType.sirtBase:
                PrefabName = "Sirius_BasePrefab_ID_" + Id + "_" + Time.deltaTime;
                obg = Instantiate(Sirius_BasePrefab);
                obg.name = PrefabName;
                obg.transform.parent = PlaceForDop.transform;

                Sirius_Base Sirius_Base = new Sirius_Base
                {
                    DopObject = obg,
                    DopId = Id,
                    DopSkin = GameObject.Find(PrefabName + "/Skin"),
                    DopKind = tvout_DopType.dtDopSirius,
                    Regim_Sirius = tvout_SiriusType.sirtBase,
                    DopName = GameObject.Find(PrefabName + "/DopName"),
                    DopCircle = GameObject.Find(PrefabName + "/Circle"),
                    DopRegimName = GameObject.Find(PrefabName + "/RegimName_Sirius"),
                    Base_Life = GameObject.Find(PrefabName + "Canvas/SliderBaseLife")
                };

                Sirius_Base.DopSkin.GetComponent<SpriteRenderer>().sprite = ReturnSpritForSkin(BaseCommand);
                Sirius_Base.DopCircle.GetComponent<SpriteRenderer>().sprite = ReturnSpritForCircle(BaseCommand);
                Sirius_Base.Base_Life.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(BaseCommand);
                Sirius_Base.Base_Life.GetComponent<Slider>().value = 100;
                Sirius_Base.DopName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).Sirius;
                Sirius_Base.DopRegimName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).Base;

                ListDop.Add(Sirius_Base);
                break;
        }

    }

    public static void CreatDopMSPrefab(tvout_MSType MSRegim, tvout_TCommandType BaseCommand, int Id)
    {
        GameObject obg;
        string PrefabName;

        switch (MSRegim)
        {
            case tvout_MSType.mstControlPoint:
                PrefabName = "MS_ControlPointPrefab_ID_" + Id + "_" + Time.deltaTime;
                obg = Instantiate(MS_ControlPointPrefab);
                obg.name = PrefabName;
                obg.transform.parent = PlaceForDop.transform;

                MS_ControlPoint MS_ControlPoint = new MS_ControlPoint
                {
                    DopObject = obg,
                    DopId = Id,
                    DopSkin = GameObject.Find(PrefabName + "/Skin"),
                    DopKind = tvout_DopType.dtDopMS,
                    Regim_MS = tvout_MSType.mstControlPoint,
                    DopName = GameObject.Find(PrefabName + "/DopName"),
                    DopCircle = GameObject.Find(PrefabName + "/Circle"),
                    DopRegimName = GameObject.Find(PrefabName + "/RegimName_MS"),
                    RedPoint = GameObject.Find(PrefabName + "/RedPoints"),
                    BluePoint = GameObject.Find(PrefabName + "/BluePoints"),
                    YellowPoint = GameObject.Find(PrefabName + "/YellowPoints"),
                    GreenPoint = GameObject.Find(PrefabName + "/GreenPoints")
                };

                MS_ControlPoint.DopName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).MS;
                MS_ControlPoint.DopRegimName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).ControlPoint;

                ListDop.Add(MS_ControlPoint);
                MainScript.KT_in_Game = true;
                break;

            case tvout_MSType.mstBase:
                PrefabName = "MS_BasePrefab_ID_" + Id + "_" + Time.deltaTime;
                obg = Instantiate(MS_BasePrefab);
                obg.name = PrefabName;
                obg.transform.parent = PlaceForDop.transform;

                MS_Base MS_Base = new MS_Base
                {
                    DopObject = obg,
                    DopId = Id,
                    DopSkin = GameObject.Find(PrefabName + "/Skin"),
                    DopKind = tvout_DopType.dtDopMS,
                    Regim_MS = tvout_MSType.mstBase,
                    DopName = GameObject.Find(PrefabName + "/DopName"),
                    DopCircle = GameObject.Find(PrefabName + "/Circle"),
                    DopRegimName = GameObject.Find(PrefabName + "/RegimName_MS"),
                    Base_Life = GameObject.Find(PrefabName + "Canvas/SliderBaseLife")
                };

                MS_Base.DopSkin.GetComponent<SpriteRenderer>().sprite = ReturnSpritForSkin(BaseCommand);
                MS_Base.DopCircle.GetComponent<SpriteRenderer>().sprite = ReturnSpritForCircle(BaseCommand);
                MS_Base.Base_Life.transform.Find("Fill Area/Fill").GetComponent<Image>().sprite = ReturnSpritForSlide(BaseCommand);
                MS_Base.Base_Life.GetComponent<Slider>().value = 100;
                MS_Base.DopName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).MS;
                MS_Base.DopRegimName.GetComponent<TextMesh>().text = MainScript.LanguageMain.ParamLang(MainScript.LanguageType).Base;
                ListDop.Add(MS_Base);
                break;
        }

    }

    public static Sprite ReturnSpritForSlide(tvout_TCommandType CommandType)
    {
        switch (CommandType)
        {
            case tvout_TCommandType.ctRed:
                return SlideRed;

            case tvout_TCommandType.ctBlue:
                return SlideBlue;

            case tvout_TCommandType.ctYellow:
                return SlideYellow;

            case tvout_TCommandType.ctGreen:
                return SlideGreen;
        }
        return null;
    }

    public static Sprite ReturnSpritForSkin(tvout_TCommandType CommandType)
    {
        switch (CommandType)
        {
            case tvout_TCommandType.ctRed:
                return RedSkin;

            case tvout_TCommandType.ctBlue:
                return BlueSkin;

            case tvout_TCommandType.ctYellow:
                return YellowSkin;

            case tvout_TCommandType.ctGreen:
                return GreenSkin;
        }
        return WhiteSkin;
    }

    public static Sprite ReturnSpritForCircle(tvout_TCommandType CommandType)
    {
        switch (CommandType)
        {
            case tvout_TCommandType.ctRed:
                return RedCircle;

            case tvout_TCommandType.ctBlue:
                return BlueCircle;

            case tvout_TCommandType.ctYellow:
                return YellowCircle;

            case tvout_TCommandType.ctGreen:
                return GreenCircle;
        }
        return WhiteCircle;
    }
   
    public static void AddDopPrefabsOnView(GameObject Parent, List<DOP> ADOP)
    {
        int D = ADOP.Count;

        if (D <= 8)
        {
            LayersCount = 1;
        }
        else
        if ((D > 8) && (D <= 16))
        {
            LayersCount = 2;
        }
        else
        if (D > 16)
        {
            LayersCount = 3;
        }
       
        MainScript.SizeChatSprite(D);

        ADOP.Sort((x, y) => x.DopKind.CompareTo(y.DopKind));


        if (D == 1)
        {
            float Start_Y = 7.98f;
            foreach (DOP iDOP in ADOP)
            {
               // iDOP.DopObject.transform.parent = Parent.transform;
                iDOP.DopObject.transform.position = new Vector3(Parent.transform.position.x, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
            }
        }
        else
        if (D == 2)
        {
            float Start_X = 1.51f;
            float Start_Y = 7.98f;

            foreach (DOP iDOP in ADOP)
            {
               // iDOP.DopObject.transform.parent = Parent.transform;
                iDOP.DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 3)
        {
            float Start_X = 1.51f;
            float Start_Y = 6.3f;

            for (int i = 0; i < D; i++)
            {
                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 0f;
                }
               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }

        }
        else
        if (D == 4)
        {
            float Start_X = 1.51f;
            float Start_Y = 6.3f;

            for (int i = 0; i < D; i++)
            {
                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

                //ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 5)
        {
            float Start_X = 1.51f;
            float Start_Y = 4.8f;

            for (int i = 0; i < D; i++)
            {
                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 0f;
                }

                //ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 6)
        {
            float Start_X = 1.51f;
            float Start_Y = 4.8f;

            for (int i = 0; i < D; i++)
            {
                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 7)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 0f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 8)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 9)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if ((i >= 8) && (i < 16))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 0f;
                    Start_Y = 3.16f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;

            }
        }
        else
        if (D == 10)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i < 16))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;

            }
        }
        else
        if (D == 11)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i < 16))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 0f;
                }

                //ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 12)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i < 16))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }

                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

                //ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;

            }

        }
        else
        if (D == 13)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i < 16))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 12)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 0f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;

            }
        }
        else
        if (D == 14)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i < 16))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 12)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 15)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i < 16))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 12)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 14)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 0f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 16)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i < 16))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 12)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 14)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

               // ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 17)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i <= 15))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }
                else
                if (D > 15)
                {
                    ADOP[i].DopObject.layer = DOP_Layers3;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers3;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 12)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 14)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 16)
                {
                    Start_Y = 3.16f;
                    Start_X = 0f;
                }

                //ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 18)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i <= 15))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }
                else
                if (D > 15)
                {
                    ADOP[i].DopObject.layer = DOP_Layers3;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers3;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 12)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 14)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 16)
                {
                    Start_Y = 3.16f;
                    Start_X = 1.51f;
                }
                if (i == 18)
                {
                    Start_Y = 3.16f;
                    Start_X = 1.51f;
                }

                //ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 19)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i <= 15))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }
                else
                if (D > 15)
                {
                    ADOP[i].DopObject.layer = DOP_Layers3;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers3;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 12)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 14)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 16)
                {
                    Start_Y = 3.16f;
                    Start_X = 1.51f;
                }
                if (i == 18)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 0f;
                }

                //ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }
        else
        if (D == 20)
        {
            float Start_X = 1.51f;
            float Start_Y = 3.16f;

            for (int i = 0; i < D; i++)
            {
                if (i < 8)
                {
                    ADOP[i].DopObject.layer = DOP_Layers1;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers1;
                    }
                }
                else
                if ((i >= 8) && (i <= 15))
                {
                    ADOP[i].DopObject.layer = DOP_Layers2;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers2;
                    }
                }
                else
                if (D > 15)
                {
                    ADOP[i].DopObject.layer = DOP_Layers3;
                    foreach (Transform child in ADOP[i].DopObject.transform)
                    {
                        child.gameObject.layer = DOP_Layers3;
                    }
                }

                if (i == 2)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 4)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 6)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 8)
                {
                    Start_X = 1.51f;
                    Start_Y = 3.16f;
                }
                if (i == 10)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 12)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 14)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }
                if (i == 16)
                {
                    Start_Y = 3.16f;
                    Start_X = 1.51f;
                }
                if (i == 18)
                {
                    Start_Y = Start_Y + 1.68f;
                    Start_X = 1.51f;
                }

                //ADOP[i].DopObject.transform.parent = Parent.transform;
                ADOP[i].DopObject.transform.position = new Vector3(Parent.transform.position.x - Start_X, Parent.transform.position.y - Start_Y, Parent.transform.position.z);
                Start_X = Start_X - 3.02f;
            }
        }

        RestartCorutines();
    }


  public static void RestartCorutines()
  {
        if (LayersCount != 1)
        {    
            instance.StopAllCoroutines();
            instance.StartCoroutine(ChangeLayersForDop(MainScript.TimeChanegLayers, LayersCount));
        }
        else
        {
            instance.StopAllCoroutines();
            DOP_Camera.GetComponent<Camera>().cullingMask |= 1 << DOP_Layers1;
            DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers2);
            DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers3);
            ActiveLayer = DOP_Layers1;
        }
  }

  public static  IEnumerator ChangeLayersForDop(int Interval, int LayersCount)
  { 
     while (true)
     {
        yield return new WaitForSeconds(Interval);
        Debug.Log("change layers dop");
        LayersChange(LayersCount);
     }    
  }

  public static void LayersChange(int LayersCount)
  {
     if (LayersCount == 2)
     {
        if (ActiveLayer == DOP_Layers1)
        {           
           DOP_Camera.GetComponent<Camera>().cullingMask |= 1 << DOP_Layers2;
           DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers1);
           ActiveLayer = DOP_Layers2;
        }
        else
        if(ActiveLayer == DOP_Layers2)
        {
           DOP_Camera.GetComponent<Camera>().cullingMask |= 1 << DOP_Layers1;
           DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers2);
           ActiveLayer = DOP_Layers1;
        }
     }
     if (LayersCount == 3)
     {
        if (ActiveLayer == DOP_Layers1)
        {
            DOP_Camera.GetComponent<Camera>().cullingMask |= 1 << DOP_Layers2;
            DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers1);
            DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers3);
            ActiveLayer = DOP_Layers2;
        }
        else
        if (ActiveLayer == DOP_Layers2)
        {
            DOP_Camera.GetComponent<Camera>().cullingMask |= 1 << DOP_Layers3;
            DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers1);
            DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers2);
            ActiveLayer = DOP_Layers3;
        }
        else
        if (ActiveLayer == DOP_Layers3)
        {
            DOP_Camera.GetComponent<Camera>().cullingMask |= 1 << DOP_Layers1;
            DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers2);
            DOP_Camera.GetComponent<Camera>().cullingMask &= ~(1 << DOP_Layers3);
            ActiveLayer = DOP_Layers1;
        }

        }
     
  }
}

