using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using tvout;
using System;
using System.Linq;

public class Player
{
    public GameObject PlayerObject;
    public int Player_ID;
    public TVOutEnumCommandType CommandType;
    public TVOutEnumPlayerState PlayerState;
}

public class PlayerCard : Player
{
    public GameObject Avatar;
    public GameObject Name;
    public GameObject Score;
    public GameObject Lifes;
    public GameObject Deaths;
    public GameObject Frags;
    public int Scores;
}

public class PlayerLine : Player
{
    public int PlaceInGame;
    public GameObject Place;
    public GameObject ID;
    public GameObject Name;
    public GameObject Score;
    public GameObject Shots;
    public GameObject Hits;
    public GameObject Frags;
    public GameObject Accuracy;
    public GameObject Captures;
    public GameObject Hits_taken;
    public GameObject Deaths;
    public GameObject Efficiency;
    public int Hit_in_Base;
    public int CapturesCP;
}

public class PlayersManager : MonoBehaviour {

   
    public GameObject PlayerCard_Prefab;
    public GameObject PlayerLine_Prefab;
    public Sprite SkinRedForCard;
    public Sprite SkinBlueForCard;
    public Sprite SkinYellowForCard;
    public Sprite SkinGreenForCard;
    public Sprite SkinRedForLine;
    public Sprite SkinBlueForLine;
    public Sprite SkinYellowForLine;
    public Sprite SkinGreenForLine;

    public static GameObject PlayerCard;
    public static GameObject PlayerLine;
    public static Sprite SkinRedCard;
    public static Sprite SkinBlueCard;
    public static Sprite SkinYellowCard;
    public static Sprite SkinGreenCard;
    public static Sprite SkinRedLine;
    public static Sprite SkinBlueLine;
    public static Sprite SkinYellowLine;
    public static Sprite SkinGreenLine;

    public static List<PlayerCard> Player_Cards = new List<PlayerCard>();
    public static List<PlayerLine> Player_Line = new List<PlayerLine>();

    public static GameObject obg;
    public static string PrefabName;

    private static MonoBehaviour instance;

    private static int MaxLayersInCommands = 0;
    private static int LayersInTable = 0;
   
    private static int TableLayersNumberForChange;
    private static int GameLayersNumberForChange;

    private static readonly int START_LAYER_INDEX = 21;

    private void Awake()
    {
        PlayerCard = PlayerCard_Prefab;
        PlayerLine = PlayerLine_Prefab;
        SkinRedCard = SkinRedForCard;
        SkinBlueCard = SkinBlueForCard;
        SkinYellowCard = SkinYellowForCard;
        SkinGreenCard = SkinGreenForCard;
        SkinRedLine = SkinRedForLine;
        SkinBlueLine = SkinBlueForLine;
        SkinYellowLine = SkinYellowForLine;
        SkinGreenLine = SkinGreenForLine;

        instance = this;
        TableLayersNumberForChange = START_LAYER_INDEX;
        GameLayersNumberForChange = START_LAYER_INDEX;
    }

    private void Start()
    {
        RestartCoroutinChangeLayersForPlayers();
    }

    private static void ChangeLayerPlayers()
    {
        if (MainScript.CameraGame.enabled == true)
        {
            if (MaxLayersInCommands == 0)
            {
                GameLayersNumberForChange = START_LAYER_INDEX;               
            }
            else
            {
                
                MainScript.CameraGame.GetComponent<Camera>().cullingMask &= ~(1 << GameLayersNumberForChange);
                GameLayersNumberForChange++;
                
                if ((GameLayersNumberForChange >= MaxLayersInCommands + START_LAYER_INDEX))
                {
                    GameLayersNumberForChange = START_LAYER_INDEX;
                }
                MainScript.CameraGame.GetComponent<Camera>().cullingMask |= (1 << GameLayersNumberForChange);

            }
        }
        else
        if (MainScript.CameraStatistic.enabled == true)
        {
            if (LayersInTable == 0)
            {
                MainScript.CameraStatistic.GetComponent<Camera>().cullingMask |= (1 << START_LAYER_INDEX);
            }
            else
            {
                if (MainScript.OnChangeLayersTable == true)
                {

                    MainScript.CameraStatistic.GetComponent<Camera>().cullingMask &= ~(1 << TableLayersNumberForChange);
                    TableLayersNumberForChange++;

                    if (TableLayersNumberForChange >= LayersInTable + START_LAYER_INDEX)
                    {
                        TableLayersNumberForChange = START_LAYER_INDEX;
                    }
                    MainScript.CameraStatistic.GetComponent<Camera>().cullingMask |= (1 << TableLayersNumberForChange);
                }

            }
        }
    }

    public static void RestartCoroutinChangeLayersForPlayers()
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(CoroutinChangeLayersForPlayers(MainScript.TimeChanegLayers));
 
    }

    private static IEnumerator CoroutinChangeLayersForPlayers(int Interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(Interval);
            ChangeLayerPlayers();
        }
    }

    /// ---------------------
    private static Sprite ReturnSkinForCard(TVOutEnumCommandType CommandType)
    {
        switch (CommandType)
        {
            case TVOutEnumCommandType.ctRed:
                return SkinRedCard;

            case TVOutEnumCommandType.ctBlue:
                return SkinBlueCard;

            case TVOutEnumCommandType.ctYellow:
                return SkinYellowCard;

            case TVOutEnumCommandType.ctGreen:
                return SkinGreenCard;
        }
        return null;

    }

    private static Sprite ReturnSkinForLine(TVOutEnumCommandType CommandType)
    {
        switch (CommandType)
        {
            case TVOutEnumCommandType.ctRed:
                return SkinRedLine;

            case TVOutEnumCommandType.ctBlue:
                return SkinBlueLine;

            case TVOutEnumCommandType.ctYellow:
                return SkinYellowLine;

            case TVOutEnumCommandType.ctGreen:
                return SkinGreenLine;
            default:
                return null;
        }
    }

    public static void AddPlayer(TVOutAddPlayer tvout_AddPlayer)
    {
        ///-----------Card
        PrefabName = "PlayerCard_ID_" + tvout_AddPlayer.player_id + "_" + Time.deltaTime;
        obg = Instantiate(PlayerCard, new Vector3(0, -10, 94.4f), Quaternion.identity);
        obg.name = PrefabName;

        PlayerCard playerCard = new PlayerCard
        {
            PlayerObject = obg,
            Avatar = GameObject.Find(PrefabName + "/ava"),
            Name = GameObject.Find(PrefabName + "/Name"),
            Score = GameObject.Find(PrefabName + "/Scores"),
            Lifes = GameObject.Find(PrefabName + "/Lifes"),
            Deaths = GameObject.Find(PrefabName + "/Deaths"),
            Frags = GameObject.Find(PrefabName + "/Kill"),
            CommandType = tvout_AddPlayer.command_type,
            Player_ID = tvout_AddPlayer.player_id,
            PlayerState = TVOutEnumPlayerState.pcEnabled,
            Scores = 0
        };

   
        playerCard.Name.GetComponent<TextMesh>().text = tvout_AddPlayer.player_name.Replace(" ", "\n");
        playerCard.PlayerObject.GetComponent<SpriteRenderer>().sprite = ReturnSkinForCard(tvout_AddPlayer.command_type);
        playerCard.Avatar.GetComponent<SpriteRenderer>().sprite = AddAvatar.AddAvatarOnPlayerCard(tvout_AddPlayer.player_id, tvout_AddPlayer.command_type);
        Player_Cards.Add(playerCard);

        ///----------------------------Line
        PrefabName = "PlayerLine_ID_" + tvout_AddPlayer.player_id + "_" + Time.deltaTime;
        obg = Instantiate(PlayerLine, new Vector3(-22.37f, -10, 94.4f), Quaternion.identity);
        obg.name = PrefabName;

        PlayerLine playerLine = new PlayerLine
        {
            PlayerObject = obg,
            Place = GameObject.Find(PrefabName + "/PlacePlayer"),
            ID = GameObject.Find(PrefabName + "/IDPlayer"),
            Name = GameObject.Find(PrefabName + "/NamePlayer"),
            Score = GameObject.Find(PrefabName + "/ScorePlayer"),
            Shots = GameObject.Find(PrefabName + "/ShotsPlayer"),
            Hits = GameObject.Find(PrefabName + "/HitsPlayer"),
            Frags = GameObject.Find(PrefabName + "/FragsPlayer"),
            Accuracy = GameObject.Find(PrefabName + "/AccuracyPlayer"),
            Captures = GameObject.Find(PrefabName + "/CapturesPlayer"),
            Hits_taken = GameObject.Find(PrefabName + "/Hits_takenPlayer"),
            Deaths = GameObject.Find(PrefabName + "/DeathsPlayer"),
            Efficiency = GameObject.Find(PrefabName + "/EfficiencyPlayer"),
            CommandType = tvout_AddPlayer.command_type,
            PlayerState = TVOutEnumPlayerState.pcEnabled,
            Player_ID = tvout_AddPlayer.player_id,
            PlaceInGame = 0,
            Hit_in_Base = 0,
            CapturesCP = 0
        };

        playerLine.Name.GetComponent<TextMesh>().text = tvout_AddPlayer.player_name;
        playerLine.ID.GetComponent<TextMesh>().text = tvout_AddPlayer.player_id.ToString();
        playerLine.PlayerObject.GetComponent<SpriteRenderer>().sprite = ReturnSkinForLine(tvout_AddPlayer.command_type);
        Player_Line.Add(playerLine);

        ManagerCommands.AddPlayerInCommand(tvout_AddPlayer.command_type);
        ManagerCommands.SetPositionBlockCommandByInGame();
      
        
    }

    public static void DeletePlayer(TVOutDeletePlayer tvout_DeletePlayer)
    {
        TVOutEnumCommandType DeletePlayer_CommandType = TVOutEnumCommandType.ctUNKNOWN;

        foreach (PlayerCard i in Player_Cards)
        {
            if (i.Player_ID == tvout_DeletePlayer.player_id)
            {
                i.PlayerObject.GetComponent<Animator>().enabled = true;
                DeletePlayer_CommandType = i.CommandType;                
            }
        }
        Player_Cards.RemoveAll(i => i.Player_ID == tvout_DeletePlayer.player_id);

        foreach (PlayerLine i in Player_Line)
        {
            if (i.Player_ID == tvout_DeletePlayer.player_id)
            {
                i.PlayerObject.GetComponent<Animator>().enabled = true;
            }
        }
        Player_Line.RemoveAll(i => i.Player_ID == tvout_DeletePlayer.player_id);

        ManagerCommands.DeletePlayerFromCommand(DeletePlayer_CommandType);       
    }

    public static void PlayerChangeCommand(TVOutChangePlayerCommand tvout_ChangePlayerCommand)
    {
        TVOutEnumCommandType PlayerLastCommandType = TVOutEnumCommandType.ctUNKNOWN;
        TVOutEnumCommandType PlayerNewCommandType = tvout_ChangePlayerCommand.command_type;

        foreach (PlayerCard i in Player_Cards)
        {
            if (i.Player_ID == tvout_ChangePlayerCommand.player_id)
            {
                PlayerLastCommandType = i.CommandType;
                i.CommandType = tvout_ChangePlayerCommand.command_type;
                i.PlayerObject.GetComponent<SpriteRenderer>().sprite = ReturnSkinForCard(tvout_ChangePlayerCommand.command_type);
                i.Avatar.GetComponent<SpriteRenderer>().sprite = AddAvatar.AddAvatarOnPlayerCard(tvout_ChangePlayerCommand.player_id, tvout_ChangePlayerCommand.command_type);                
            }
        }

        foreach (PlayerLine i in Player_Line)
        {
            if (i.Player_ID == tvout_ChangePlayerCommand.player_id)
            {
                i.CommandType = tvout_ChangePlayerCommand.command_type;
                i.PlayerObject.GetComponent<SpriteRenderer>().sprite = ReturnSkinForLine(tvout_ChangePlayerCommand.command_type);
            }
        }

        ManagerCommands.ChangePlayerBetweenCommands(PlayerLastCommandType, PlayerNewCommandType);
    }

    public static void ChangePlayerState(TVOutChangePlayerState tvout_ChangePlayerState)
    {

        Color C = new Color(1f, 1f, 1f, 1f);

        if (tvout_ChangePlayerState.player_state == TVOutEnumPlayerState.pcDisable)
        {
            C.a = 0.3f;
        }
        else
        {
            C.a = 1f;
        }

        foreach (PlayerCard i in Player_Cards)
        {
            if (i.Player_ID == tvout_ChangePlayerState.player_id)
            {
                i.PlayerObject.GetComponent<SpriteRenderer>().color = C;
                i.Avatar.GetComponent<SpriteRenderer>().color = C;
            }
        }

        foreach (PlayerLine i in Player_Line)
        {
            if (i.Player_ID == tvout_ChangePlayerState.player_id)
            {
                i.PlayerObject.GetComponent<SpriteRenderer>().color = C;
            }
        }
        
    }

    public static void DeleteAllPlayers()
    {
        foreach (PlayerCard i in Player_Cards)
        {
            i.PlayerObject.GetComponent<Animator>().enabled = true;                       
        }
        Player_Cards.Clear();

        foreach (PlayerLine i in Player_Line)
        {
           i.PlayerObject.GetComponent<Animator>().enabled = true;            
        }
        Player_Line.Clear();
    }

    public static void AddPlayerStatistic(TVOutPlayerStatistic tvout_PlayerStatistic)
    {
        IEnumerable<PlayerCard> PlayerGame = Player_Cards.Where(t => t.Player_ID == tvout_PlayerStatistic.player_id);

        foreach (PlayerCard i in PlayerGame)
        {
            if (tvout_PlayerStatistic.score != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Score.GetComponent<TextMesh>().text = tvout_PlayerStatistic.score.ToString();
                i.Scores = tvout_PlayerStatistic.score;
            }
            if (tvout_PlayerStatistic.deaths != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Deaths.GetComponent<TextMesh>().text = tvout_PlayerStatistic.deaths.ToString();
            }
            if (tvout_PlayerStatistic.fragov != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Frags.GetComponent<TextMesh>().text = tvout_PlayerStatistic.fragov.ToString();
            }
            if (tvout_PlayerStatistic.life != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Lifes.GetComponent<TextMesh>().text = tvout_PlayerStatistic.life.ToString();
            }
        }
      

        IEnumerable<PlayerLine> PlayerTable = Player_Line.Where(t => t.Player_ID == tvout_PlayerStatistic.player_id);

        foreach (PlayerLine i in PlayerTable)
        {
            if (tvout_PlayerStatistic.accuracy != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Accuracy.GetComponent<TextMesh>().text = tvout_PlayerStatistic.accuracy.ToString() + "%";
            }
            if (tvout_PlayerStatistic.deaths != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Deaths.GetComponent<TextMesh>().text = tvout_PlayerStatistic.deaths.ToString();
            }
            if (tvout_PlayerStatistic.fragov != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Frags.GetComponent<TextMesh>().text = tvout_PlayerStatistic.fragov.ToString();
            }
            if (tvout_PlayerStatistic.give_damage != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Hits.GetComponent<TextMesh>().text = tvout_PlayerStatistic.give_damage.ToString();
            }
            if (tvout_PlayerStatistic.receive_damage != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Hits_taken.GetComponent<TextMesh>().text = tvout_PlayerStatistic.receive_damage.ToString();
            }
            if (tvout_PlayerStatistic.hit_in_base != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Hit_in_Base = tvout_PlayerStatistic.hit_in_base;
            }
            if (tvout_PlayerStatistic.captures_cp != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.CapturesCP = tvout_PlayerStatistic.captures_cp;
            }
            if (tvout_PlayerStatistic.score != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Score.GetComponent<TextMesh>().text = tvout_PlayerStatistic.score.ToString();
            }
            if (tvout_PlayerStatistic.shots != MainScript.DEFAULT_VALUE_PROTO_PARAM_INT)
            {
                i.Shots.GetComponent<TextMesh>().text = tvout_PlayerStatistic.shots.ToString();
            }

            i.Captures.GetComponent<TextMesh>().text = Convert.ToString(i.Hit_in_Base + i.CapturesCP);
        }
                       
    }

    public static void ChangePlayerName(TVOutChangePlayerName tvout_ChangePlayerName)
    {
        IEnumerable<PlayerCard> PlayerGame = Player_Cards.Where(t => t.Player_ID == tvout_ChangePlayerName.player_id);

        foreach (PlayerCard i in PlayerGame)
        {
            i.Name.GetComponent<TextMesh>().text = tvout_ChangePlayerName.player_name.Replace(" ", "\n");
        }

        IEnumerable<PlayerLine> PlayerTable = Player_Line.Where(t => t.Player_ID == tvout_ChangePlayerName.player_id);

        foreach (PlayerLine i in PlayerTable)
        {
            i.Name.GetComponent<TextMesh>().text = tvout_ChangePlayerName.player_name;
        }
    }

    public static void AddPlayerPlace(TVOutPlayerPlace tvout_PlayerPlace)
    {
        IEnumerable<PlayerLine> PlayerTable = Player_Line.Where(t => t.Player_ID == tvout_PlayerPlace.player_id);

        foreach (PlayerLine i in PlayerTable)
        {
            i.Place.GetComponent<TextMesh>().text = tvout_PlayerPlace.place.ToString();
            i.PlaceInGame = tvout_PlayerPlace.place;
        }

        Player_Line.Sort((x, y) => x.PlaceInGame.CompareTo(y.PlaceInGame));
        FullAlignPlayerLines(true);

        Player_Cards.Sort((x, y) => y.Scores.CompareTo(x.Scores));
        FullAlignPlayersCard(true);
    }

    public static void PlayerStatisticReset()
    {
        Color C = new Color(1f, 1f, 1f, 1f);
   
        foreach (PlayerCard i in Player_Cards)
        {
            i.Score.GetComponent<TextMesh>().text = "0";
            i.Scores = 0;
            i.Deaths.GetComponent<TextMesh>().text = "0";
            i.Frags.GetComponent<TextMesh>().text = "0";
            i.Lifes.GetComponent<TextMesh>().text = "0";
            i.PlayerObject.GetComponent<SpriteRenderer>().color = C;
            i.Avatar.GetComponent<SpriteRenderer>().color = C;
        }

        foreach (PlayerLine i in Player_Line)
        {
            i.Accuracy.GetComponent<TextMesh>().text = "0%";
            //i.Place.GetComponent<TextMesh>().text = "0";
            //i.PlaceInGame = 0;
            i.Deaths.GetComponent<TextMesh>().text = "0";
            i.Frags.GetComponent<TextMesh>().text = "0";
            i.Hits.GetComponent<TextMesh>().text = "0";
            i.Hits_taken.GetComponent<TextMesh>().text = "0";
            i.Captures.GetComponent<TextMesh>().text = "0";
            i.Score.GetComponent<TextMesh>().text = "0";
            i.Shots.GetComponent<TextMesh>().text = "0";
            i.PlayerObject.GetComponent<SpriteRenderer>().color = C;
            i.CapturesCP = 0;
            i.Hit_in_Base = 0;
        }
    }

    public static void FullAlignPlayerLines( bool Move)
    {
        float StartX;
        float StartY;
        float ShiftY;
        int PlayerUndePage;
        int CurrentLayerInTable;

        if (Player_Line.Count > 0)
        {
            StartX = -22.37f;
            StartY = 1.97f;
            ShiftY = 0f;
            LayersInTable = 1;
            PlayerUndePage = 0;
            CurrentLayerInTable = START_LAYER_INDEX;

            foreach (PlayerLine i in Player_Line)
            {
                if (PlayerUndePage > 11)
                {
                    PlayerUndePage = 0;
                    StartY = 1.97f;
                    ShiftY = 0f;
                    CurrentLayerInTable = START_LAYER_INDEX + LayersInTable;
                    LayersInTable++;                   
                }

                switch (Move)
                {
                    case true:
                        Utils.gameObjectMoveTo(i.PlayerObject, new Vector3(StartX, StartY - ShiftY, 94.4f), 2f);                        
                        break;
                    case false:
                        i.PlayerObject.transform.position = new Vector3(StartX, StartY - ShiftY, 94.4f);
                        break;
                }
                               
                i.PlayerObject.layer = CurrentLayerInTable;

                foreach (Transform child in i.PlayerObject.transform)
                {
                    child.gameObject.layer = CurrentLayerInTable;
                }

                PlayerUndePage++; // + плеер
                ShiftY = ShiftY + 0.6f;
            }

        }

    }
 
    public static void FullAlignPlayersCard(bool Move)
    {
        int GENERAL_LAYER_INDEX = 20;                 
        float iPlayerStartPosition_Y = 3.5f;
        float iShiftX = 0.25f;
        float iShiftY = 0.5f;
        float x, y;
        int iMaxCountPlayerInDisplay = 7;
        int iMaxViewPlayerInCommand = 0;
        int iCountViewPlayerInCommand = 0;
        float ZFrontOrder = 94.4f;
        int CurrZLogicOrder = 0;
        int TotalLayerInCommand;

        if (Player_Cards.Count != 0)
        {

            MaxLayersInCommands = 0;

            if (ManagerCommands.CommandsInGameCount() <= 2)
            {
                iMaxViewPlayerInCommand = 14;

                foreach (CommandBlockGame i in ManagerCommands.ListCommandGameBlockCommands)
                {
                    if (i.InGame == false)
                    {
                        continue;
                    }

                    x = i.BlockPositionX;
                    y = iPlayerStartPosition_Y;

                    iCountViewPlayerInCommand = 0;

                    TotalLayerInCommand = 1;

                    if (CurrZLogicOrder != 0)
                    {
                        if (TotalLayerInCommand < CurrZLogicOrder - START_LAYER_INDEX)
                        {
                            TotalLayerInCommand = CurrZLogicOrder - START_LAYER_INDEX;
                        }
                    }

                    if (i.PlayerCountInCommand <= 14)
                    {
                        CurrZLogicOrder = GENERAL_LAYER_INDEX;                        
                    }
                    else
                    {
                        CurrZLogicOrder = START_LAYER_INDEX;
                    }

                    int iCountPlayerInRow = 0;

                    bool bTwoCol = i.PlayerCountInCommand > iMaxCountPlayerInDisplay;
                    if (bTwoCol)
                    {
                       x = i.BlockPositionX - 1.2f;
                    }

                    foreach(PlayerCard player in Player_Cards)
                    {
                        if (i.CommandType != player.CommandType)
                        {
                            continue;
                        }
                        
                        player.PlayerObject.layer = CurrZLogicOrder;

                        foreach (Transform child in player.PlayerObject.transform)
                        {
                            child.gameObject.layer = CurrZLogicOrder;
                        }

                        switch (Move)
                        {
                            case true:
                                Utils.gameObjectMoveTo(player.PlayerObject, new Vector3(x, y, ZFrontOrder), 6f);
                                break;
                            case false:
                                player.PlayerObject.transform.position = new Vector3(x, y, ZFrontOrder);
                                break;
                        }                     

                        iCountPlayerInRow++;

                        if (bTwoCol)
                        {
                            x = x + 2.3f + iShiftX;
                            if (iCountPlayerInRow >= 2)
                            {
                                x = i.BlockPositionX - 1.2f;
                                y = y - 0.8f - iShiftY;
                                iCountPlayerInRow = 0;
                            }
                        }
                        else
                        {
                            y = y - 0.8f - iShiftY;
                        }

                        iCountViewPlayerInCommand++;

                        if (iCountViewPlayerInCommand >= iMaxViewPlayerInCommand)
                        {
                            iCountViewPlayerInCommand = 0;
                            y = iPlayerStartPosition_Y;
                            CurrZLogicOrder++;
                            TableLayersNumberForChange = START_LAYER_INDEX + TotalLayerInCommand;
                            TotalLayerInCommand++;                            
                        }
                    }
                    if (TotalLayerInCommand > MaxLayersInCommands)
                    {
                        MaxLayersInCommands = TotalLayerInCommand;
                    }   
                    
                }
            }
            else
            {
                iMaxViewPlayerInCommand = 7;
                
                foreach (CommandBlockGame i in ManagerCommands.ListCommandGameBlockCommands)
                {

                    if (i.InGame == false)
                    {
                        continue;
                    }

                    y = iPlayerStartPosition_Y;
                    iCountViewPlayerInCommand = 0;
                    TotalLayerInCommand = 1;

                    if (CurrZLogicOrder != 0)
                    {
                        if (TotalLayerInCommand < CurrZLogicOrder - START_LAYER_INDEX)
                        {
                            TotalLayerInCommand = CurrZLogicOrder - START_LAYER_INDEX;
                        }
                    }

                    if (i.PlayerCountInCommand <= 7)
                    {
                        CurrZLogicOrder = GENERAL_LAYER_INDEX;
                    }
                    else
                    {
                        CurrZLogicOrder = START_LAYER_INDEX;
                    }

                    foreach (PlayerCard player in Player_Cards)
                    {
                        if (i.CommandType != player.CommandType)
                        {
                            continue;
                        }

                        if (iCountViewPlayerInCommand >= iMaxViewPlayerInCommand)
                        {
                            iCountViewPlayerInCommand = 0;
                            y = iPlayerStartPosition_Y;
                            CurrZLogicOrder++;
                            TableLayersNumberForChange = START_LAYER_INDEX + TotalLayerInCommand;
                            TotalLayerInCommand++;                            
                        }

                        player.PlayerObject.layer = CurrZLogicOrder;

                        foreach (Transform child in player.PlayerObject.transform)
                        {
                            child.gameObject.layer = CurrZLogicOrder;
                        }

                        switch (Move)
                        {
                            case true:
                                Utils.gameObjectMoveTo(player.PlayerObject, new Vector3(i.BlockPositionX, y, ZFrontOrder), 5f);
                                break;
                            case false:
                                player.PlayerObject.transform.position = new Vector3(i.BlockPositionX, y, ZFrontOrder);
                                break;
                        }
                       
                        y = y - 0.8f - iShiftY;

                        iCountViewPlayerInCommand++;
                    }
                    if (TotalLayerInCommand > MaxLayersInCommands)
                    {
                        MaxLayersInCommands = TotalLayerInCommand;
                    }
                }

            }
        }

    }
}
