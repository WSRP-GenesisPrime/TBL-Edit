using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using WildStar.TestBed.GameTable;

namespace WildStar.TestBed
{
    class Program
    {
        static Logger log = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {

            LoadTables();

            AddLightDecor("Art\\Light\\LIT_Level_Up_Spotlight_000.m3", 3699, "Spot Light (Level Up)");
            AddLightDecor("Art\\Light\\LIT_Mask_Point_Med_AurinHanging.m3", 3700, "Mask Light (Point, Medium Aurin Hanging)");
            AddLightDecor("Art\\Light\\LIT_Mask_Spotlight_Gate_000.m3", 3701, "Mask Light (Gate Spotlight)");
            AddLightDecor("Art\\Light\\LIT_Point_Hard.m3", 3702, "Point Light (Hard)");
            AddLightDecor("Art\\Light\\LIT_Point_Hard_Bright.m3", 3703, "Point Light (Hard, Bright)");
            AddLightDecor("Art\\Light\\LIT_Point_Med.m3", 3704, "Point Light (Medium)");
            AddLightDecor("Art\\Light\\LIT_Point_Med_Bright.m3", 3705, "Point Light (Medium, Bright)");
            AddLightDecor("Art\\Light\\LIT_Point_Med_Bright_Amb.m3", 3706, "Point Light (Medium, Bright Ambient)");
            AddLightDecor("Art\\Light\\LIT_Point_Soft.m3", 3707, "Point Light (Soft)");
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Bright.m3", 3708, "Point Light (Soft, Bright)");
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Overbright.m3", 3709, "Point Light (Soft, Overbright)");
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Throb.m3", 3710, "Point Light (Soft, Throb)");
            AddLightDecor("Art\\Light\\LIT_Rec_Hard.m3", 3711, "Rectangle Light (Hard)");
            AddLightDecor("Art\\Light\\LIT_Rec_Med.m3", 3712, "Rectangle Light (Medium)");
            AddLightDecor("Art\\Light\\LIT_Rec_Soft.m3", 3713, "Rectangle Light (Soft)");

            AddLightDecor("Art\\Light\\LIT_Spot_Diffused_Overbright.m3", 3714, "Spot Light (Diffused, Overbright)");
            AddLightDecor("Art\\Light\\LIT_Spot_Hard.m3", 3715, "Spot Light (Hard)");
            AddLightDecor("Art\\Light\\LIT_Spot_Med.m3", 3716, "Spot Light (Medium)");
            AddLightDecor("Art\\Light\\LIT_Spot_MedNarrow_Soft.m3", 3717, "Spot Light (Medium, Narrow Soft)");
            AddLightDecor("Art\\Light\\LIT_Spot_Narrow_Med.m3", 3718, "Spot Light (Medium, Narrow)"); // only starts after some distance
            AddLightDecor("Art\\Light\\LIT_Spot_Narrow_Soft.m3", 3719, "Spot Light (Soft, Narrow)"); // same
            AddLightDecor("Art\\Light\\LIT_Spot_Soft.m3", 3720, "Spot Light (Soft)");
            AddLightDecor("Art\\Light\\LIT_Spot_Wide_Hard.m3", 3721, "Spot Light (Hard, Wide)");
            AddLightDecor("Art\\Light\\LIT_Spot_Wide_Med.m3", 3722, "Spot Light (Medium, Wide)");
            AddLightDecor("Art\\Light\\LIT_Spot_Wide_Soft.m3", 3723, "Spot Light (Soft, Wide)");

            AddLightDecor("Art\\Light\\Mask_LIT_DIR_Crystline_001.m3", 3724, "Mask Light (Crystal)"); // Subtly textured directional light
            AddLightDecor("Art\\Light\\Mask_LIT_DIR_SimpleNarrow_001.m3", 3725, "Mask Light (Simple, Narrow)"); // Narrow directional light
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Cubic_Fire_001.m3", 3726, "Mask Light (Point, Cubic Fire)"); // Cubic fire texture
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Med_Brazier.m3", 3727, "Mask Light (Point, Medium Brazier)");
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Med_LavaTube.m3", 3728); // Soft cubic firey texture
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Branches_001.m3", 3729); // Soft branch texture, directional
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Chain.m3", 3730); // Chain texture, directional light
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001.m3", 3731); // dappled light
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001_Short.m3", 3732); // doesn't seem shorter in any way
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002.m3", 3733); // dappled light, softer
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002_Short.m3", 3734); // doesn't seem shorter in any way
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Fire_001.m3", 3735); // Fire texture spotlight
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Grate.m3", 3736); // Grate, directional
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Grate_Large.m3", 3737); // Same


            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\CoolShift_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\WarmShift_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus25_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus50_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus75_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus100_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus125_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus150_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus25_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus50_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus75_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus100_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus125_LUT.tex");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus150_LUT.tex");


            AddEmote(7834, "lounge1");
            AddEmote(7835, "lounge2");

            foreach (var entry in emotes.Entries)
            {
                uint id = (uint)entry.Values[0].Value;
                if (id == 425)
                {
                    entry.Values[24].SetValue("lounge3");
                    break;
                }
            }


            SaveTables("../../../../TblNormal/");

            // BETA YOLO MOOOODE


            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_OGE.m3");
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_noDecal_OGE.m3");
            AddGenericDecor("Art\\FX\\Model\\Impacts\\Lava_Splash\\Lava_Splash_OGE.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_10mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_5mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_10mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_15mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_10mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_3mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_AQU.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_GLD.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_GrndNormal_GLD.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_3mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_5mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_NoGrndConst_5mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGrndConst_10mR.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGrndConst_10mR_V2.m3");
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Wave\\Lava_Wave.m3");
            AddGenericDecor("Art\\FX\\Model\\Particulates\\Water\\Water_Lava.m3");
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_Eruption_2mR_4mH_OGE.m3");
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_LinearEruption_2mR_4mH_NoDecal_OGE.m3");
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_LinearEruption_2mR_4mH_OGE.m3");
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Geyser\\Lava_Geyser_OGE.m3");
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_LavaTube.m3");
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_LavaTube.m3");
            AddGenericDecor("Art\\Prop\\Dungeon\\Datascape\\LavaRock\\PRP_Datascape_LavaRock_000.m3");
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Lavaka_Grill_000.m3");
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Lavaka_IncineratorPit_000.m3");
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Lavaka_Organ_000.m3");
            AddGenericDecor("Art\\Prop\\Housing\\Islands\\PRP_SkymapIsland_Lava_Terrain_000.m3");
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_000.m3");
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_001.m3");
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_002.m3");
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_001.m3");
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_002.m3");
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_003.m3");
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_004.m3");
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_Tall_001.m3");


            /*foreach(var entry in housingPlugItem.Entries)
            {
                uint id = (uint)entry.Values[0].Value;
                if(id == 557)
                {
                    entry.Values[27].SetValue((uint) 0);
                }
            }*/

            SaveTables("../../../../TblBeta/");
            CopyTables("../../../../TblBeta/", "../../../../TblServer/");
        }

        static GameTable.GameTable hookAssets;
        static uint nextHookAsset = 3352;

        static GameTable.GameTable decorInfo;
        static uint nextDecorID = 3699;

        static GameTable.GameTable colorShift;
        static uint nextShiftID = 0;

        static GameTable.GameTable emotes;
        static uint nextEmoteID = 0;

        /*static GameTable.GameTable housingPlugItem;
        static uint nexthpi = 0;*/

        static TextTable.TextTable language;

        public static void LoadTables()
        {
            hookAssets = new GameTable.GameTable();
            hookAssets.Load("../../../../Tbl/HookAsset.tbl");
            nextHookAsset = GetMaxID(hookAssets.Entries) + 1;

            decorInfo = new GameTable.GameTable();
            decorInfo.Load("../../../../Tbl/HousingDecorInfo.tbl");
            nextDecorID = GetMaxID(decorInfo.Entries) + 1;

            colorShift = new GameTable.GameTable();
            colorShift.Load("../../../../Tbl/ColorShift.tbl");
            nextShiftID = GetMaxID(colorShift.Entries) + 1;

            emotes = new GameTable.GameTable();
            emotes.Load("../../../../Tbl/Emotes.tbl");
            nextEmoteID = GetMaxID(emotes.Entries) + 1;

            /*housingPlugItem = new GameTable.GameTable();
            housingPlugItem.Load("../../../../Tbl/HousingPlugItem.tbl");
            nexthpi = GetMaxID(housingPlugItem.Entries) + 1;*/

            language = new TextTable.TextTable();
            language.Load("../../../../Tbl/en-US.bin");
        }

        public static void SaveTables(string baseFolder)
        {
            Directory.CreateDirectory(baseFolder + "DB");

            hookAssets.Save(baseFolder + "DB/HookAsset.tbl");

            decorInfo.Save(baseFolder + "DB/HousingDecorInfo.tbl");

            colorShift.Save(baseFolder + "DB/ColorShift.tbl");

            emotes.Save(baseFolder + "DB/Emotes.tbl");

            //housingPlugItem.Save(baseFolder + "DB/HousingPlugItem.tbl");

            language.Save(baseFolder + "en-US.bin");
        }

        public static void CopyTables(string baseFolder, string destFolder)
        {
            Directory.CreateDirectory(destFolder);
            List<string> names = new List<string>(Directory.GetFiles(baseFolder, "*.tbl", SearchOption.AllDirectories));
            names.AddRange(Directory.GetFiles(baseFolder, "*.bin", SearchOption.AllDirectories));

            foreach (var fileName in names)
            {
                string newPath = destFolder + Path.GetFileName(fileName);
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }
                File.Copy(fileName, newPath);
            }
        }

        static uint AddEntry(GameTable.GameTable table, GameTable.GameTableEntry entry, ref uint nextIDCounter, uint? id = null)
        {
            uint _id = nextIDCounter;
            if(id != null)
            {
                _id = (uint) id;
            }
            if(_id >= nextIDCounter)
            {
                nextIDCounter = _id + 1;
            }
            if (table.HasEntry(_id))
            {
                throw new ArgumentException("Given ID already exists in table!");
            }
            table.AddEntry(entry, _id);
            return _id;
        }

        static uint AddHookAsset(string asset)
        {
            var entry = new GameTableEntry();
            entry.AddString(asset);
            entry.AddSingle(1); // scale
            entry.AddSingle(0); // offset X
            entry.AddSingle(0); // offset Y
            entry.AddSingle(0); // offset Z
            entry.AddSingle(0); // rotation X
            entry.AddSingle(0); // rotation Y
            entry.AddSingle(0); // rotation Z

            hookAssets.AddEntry(entry, nextHookAsset);

            nextHookAsset += 1;
            return nextHookAsset - 1;
        }

        static uint AddLightDecor(string hookAsset, uint? id = null, string name = null)
        {
            return AddGenericDecor(hookAsset, id, name, 13, true);
        }

        static uint AddGenericDecor(string hookAsset, uint? id = null, string name = null, uint category = 13, bool particleAlt = false)
        {
            var entry = new GameTableEntry();
            entry.AddInteger(category); // "light" category
            entry.AddInteger(12); // hookassettypeid, 12 or 22 seem okay, 10 is not
            if (name != null)
            {
                entry.AddInteger(language.AddEntry(name)); // localizedtextid
            }
            else
            {
                entry.AddInteger(language.AddEntry(hookAsset)); // localizedtextid
            }
            entry.AddInteger(0); // flags, sconce has 0
            entry.AddInteger(AddHookAsset(hookAsset)); // hookassetid
            entry.AddInteger(5000); // cost
            entry.AddInteger(1); // costcurrencytypeid
            entry.AddInteger(0); // creature2id
            entry.AddInteger(0); // unlock prereq
            entry.AddInteger(0); // interior buff spell4id
            entry.AddInteger(2); // housing decor limit category id, light
            entry.AddString(""); // alt preview asset
            if (particleAlt)
            {
                entry.AddString("Art\\FX\\Housing\\Decor_FXPlacer\\Decor_FXPlacer_000.m3"); // alt edit asset
            } else
            {
                entry.AddString("");
            }
            entry.AddSingle(0.1f); // min scale
            entry.AddSingle(10f); // max scale

            uint _id = AddEntry(decorInfo, entry, ref nextDecorID, id);
            log.Info($"Added decor {_id}: {hookAsset}");
            return _id;
        }

        static uint AddColorShift(string colorShiftAsset, uint? id = null)
        {
            var entry = new GameTableEntry();
            entry.AddString(colorShiftAsset); // Asset path
            entry.AddInteger(language.AddEntry(colorShiftAsset)); // localizedtextid
            entry.AddString("BasicSprites:Grey"); // preview swatch icon

            return AddEntry(colorShift, entry, ref nextShiftID, id);
        }

        static uint AddEmote(uint animationID, string command, uint? id = null)
        {
            var entry = new GameTableEntry();
            entry.AddInteger(0); // localizedTextIdNoArgToAll
            entry.AddInteger(0); // localizedTextIdNoArgToSelf
            entry.AddInteger(animationID); // NoArgAnim
            entry.AddInteger(0); // localizedTextIdArgToAll
            entry.AddInteger(0); // localizedTextIdArgToArg
            entry.AddInteger(0); // localizedTextIdArgToSelf
            entry.AddInteger(animationID); // ArgAnim
            entry.AddInteger(0); // localizedTextIdSelfToAll
            entry.AddInteger(0); // localizedTextIdSelfToSelf
            entry.AddInteger(animationID); // SelfAnim
            entry.AddBool(true); // SheathWeapons
            entry.AddBool(true); // TurnToFace (to match camera angle?)
            entry.AddBool(false); // TextReplaceable
            entry.AddBool(true); // ChangesStandState
            entry.AddInteger(7); // StandState
            entry.AddInteger(0); // localizedTextIdCommand
            entry.AddInteger(0); // localizedTextIdNotFoundToAll
            entry.AddInteger(0); // localizedTextIdNotFoundToSelf
            entry.AddInteger(animationID); // NotFoundAnim
            entry.AddInteger(animationID); // TextReplaceAnim
            entry.AddInteger(animationID); // modelSequenceIdStandState (Is animation ID for lounge)
            entry.AddInteger(0); // visualEffectId
            entry.AddInteger(0); // flags
            entry.AddString(command); // universalCommand00
            entry.AddString(""); // universalCommand01

            return AddEntry(emotes, entry, ref nextEmoteID, id);
        }

        static uint GetMaxID(List<GameTableEntry> list)
        {
            uint maxVal = 0;
            foreach (var entry in list)
            {
                uint id = (uint)entry.Values[0].Value;
                if (id > maxVal)
                {
                    maxVal = id;
                }
            }
            return maxVal;
        }
    }
}
