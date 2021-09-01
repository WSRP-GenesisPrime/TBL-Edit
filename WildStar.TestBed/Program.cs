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

            AddDecorType(DecorCategory.Beta, "Beta", "INT - Beta");
            AddDecorType(DecorCategory.Structures, "Structures", "INT - Structures");

            AddLightDecor("Art\\Light\\LIT_Level_Up_Spotlight_000.m3", 3699, "Spot Light (Level Up)");
            AddLightDecor("Art\\Light\\LIT_Mask_Point_Med_AurinHanging.m3", 3700, "Point Light (Aurin Hanging Light)");
            AddLightDecor("Art\\Light\\LIT_Mask_Spotlight_Gate_000.m3", 3701, "Spot Light (Gate)");
            AddLightDecor("Art\\Light\\LIT_Point_Hard.m3", 3702, "Point Light (Hard)");
            AddLightDecor("Art\\Light\\LIT_Point_Hard_Bright.m3", 3703, "Point Light (Hard, Bright)");
            AddLightDecor("Art\\Light\\LIT_Point_Med.m3", 3704, "Point Light (Medium)");
            AddLightDecor("Art\\Light\\LIT_Point_Med_Bright.m3", 3705, "Point Light (Medium, Bright)");
            AddLightDecor("Art\\Light\\LIT_Point_Med_Bright_Amb.m3", 3706, "Point Light (Medium, Bright Ambient)");
            AddLightDecor("Art\\Light\\LIT_Point_Soft.m3", 3707, "Point Light (Soft)");
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Bright.m3", 3708, "Point Light (Soft, Bright)");
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Overbright.m3", 3709, "Point Light (Soft, Overbright)");
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Throb.m3", 3710, "Point Light (Soft, Throb)");
            AddLightDecor("Art\\Light\\LIT_Rec_Hard.m3", 3711, "Spot Light (Hard, Rectangle)");
            AddLightDecor("Art\\Light\\LIT_Rec_Med.m3", 3712, "Spot Light (Medium, Rectangle)");
            AddLightDecor("Art\\Light\\LIT_Rec_Soft.m3", 3713, "Spot Light (Soft, Rectangle)");

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

            AddLightDecor("Art\\Light\\Mask_LIT_DIR_Crystline_001.m3", 3724, "Directional Light (Crystal)"); // Subtly textured directional light
            AddLightDecor("Art\\Light\\Mask_LIT_DIR_SimpleNarrow_001.m3", 3725, "Directional Light (Simple, Narrow)"); // Narrow directional light
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Cubic_Fire_001.m3", 3726, "Point Light (Fire Texture)"); // Cubic fire texture
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Med_Brazier.m3", 3727, "Point Light (Brazier)");
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Med_LavaTube.m3", 3728, "Point Light (Lava Tube)"); // Soft cubic firey texture
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Branches_001.m3", 3729, "Spot Light (Branches)"); // Soft branch texture, directional
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Chain.m3", 3730, "Spot Light (Chain Texture)"); // Chain texture, directional light
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001.m3", 3731, "Spot Light (Dappled Light)"); // dappled light
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001_Short.m3", 3732, "Spot Light (Dappled Light, Short)"); // doesn't seem shorter in any way
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002.m3", 3733, "Spot Light (Dappled Light 2)"); // dappled light, softer
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002_Short.m3", 3734, "Spot Light (Dappled Light 2, Short)"); // doesn't seem shorter in any way
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Fire_001.m3", 3735, "Spot Light (Fire)"); // Fire texture spotlight
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Grate.m3", 3736, "Spot Light (Grate)"); // Grate, directional
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Grate_Large.m3", 3737, "Spot Light (Grate, Large)"); // Same


            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\CoolShift_LUT.tex", null, "Cool-Shift");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\WarmShift_LUT.tex", null, "Warm-Shift");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus25_LUT.tex", null, "Hue-Shift, Minus 25 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus50_LUT.tex", null, "Hue-Shift, Minus 50 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus75_LUT.tex", null, "Hue-Shift, Minus 75 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus100_LUT.tex", null, "Hue-Shift, Minus 100 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus125_LUT.tex", null, "Hue-Shift, Minus 125 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus150_LUT.tex", null, "Hue-Shift, Minus 150 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus25_LUT.tex", null, "Hue-Shift, Plus 25 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus50_LUT.tex", null, "Hue-Shift, Plus 50 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus75_LUT.tex", null, "Hue-Shift, Plus 75 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus100_LUT.tex", null, "Hue-Shift, Plus 100 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus125_LUT.tex", null, "Hue-Shift, Plus 125 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus150_LUT.tex", null, "Hue-Shift, Plus 150 Degrees");


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
            betaMode = true;


            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_002", null, "Hanging Cable (Long)", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_003", null, "Hanging Cable (Longer)", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_SegmentedLong_003", null, "Hanging Cable (Long, Drooping)", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\PRP_Cable_Generic_Box_000", null, "Cable Socket", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_007", null, "Phial (Medium)", DecorCategory.Cookware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_008", null, "Potion Bottle", DecorCategory.Cookware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_009", null, "Potion Bottle (Wide)", DecorCategory.Cookware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Bottle_Granok_Beer_000", null, "Beer Bottle (Granok)", DecorCategory.Cookware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Granok_BeerCan_Open_000", null, "Crushed Beer Can", DecorCategory.Cookware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_001", null, "Beer Can (Protostar)", DecorCategory.Cookware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_000", null, "Crushed Beer Can (Protostar)", DecorCategory.Cookware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\PRP_Debris_SmugglerFighterCrashed_VAR_LeftEngine_000", null, "Ruined Fighter Wing", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_000", null, "Metal Plate, Style 1", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_001", null, "Metal Plate, Style 2", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_002", null, "Metal Plate, Style 3", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Falkrin\\PRP_Debris_FalkrinMetalPlate_000", null, "Metal Scrap", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_000", null, "Granok Trailer", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_001", null, "Granok Trailer (2)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_000", null, "Junk Shack (Tall)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_001", null, "Junk Shack (Short)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotArm_Rust_000", null, "Rusty Bot Arm", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotBody_Rust_000", null, "Rusty Bot Torso", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotHead_Rust_000", null, "Rusty Bot Head", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotLeg_Rust_000", null, "Rusty Bot Leg", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_000", null, "Metal Pipe Tower", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_001", null, "Large Metal Tank", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_002", null, "Metal Scaffolding", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_003", null, "Metal Scaffolding", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipe_Cap_000", null, "Chua Pipe Cap", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_000", null, "Chua Pipe", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_001", null, "Chua Pipe (Long)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_002", null, "Chua Pipe (Curved)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_003", null, "Chua Pipe (Intersection)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_004", null, "Chua Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_Stacker_000", null, "Chua Pipe Reinforcement", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_005", null, "Metal Pipe", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_006", null, "Reinforced Metal Pipe", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_009", null, "Metal Pipe (Curved)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_013", null, "Metal Pipe (Long)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_010", null, "Metal Support Beams", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_011", null, "Metal Support Beams", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_013", null, "Metal Rod", DecorCategory.Tools, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_014", null, "Faucet", DecorCategory.Tools, false); 
            
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

        static bool betaMode = false;

        static GameTable.GameTable hookAssets;
        static uint nextHookAsset = 3352;

        static GameTable.GameTable decorInfo;
        static uint nextDecorID = 3699;

        static GameTable.GameTable decorType;
        static uint nextDecorType = 66;

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

            decorType = new GameTable.GameTable();
            decorType.Load("../../../../Tbl/HousingDecorType.tbl");
            nextDecorType = GetMaxID(decorType.Entries) + 1;

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

            decorType.Save(baseFolder + "DB/HousingDecorType.tbl");

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

        enum DecorCategory
        {
            Seating = 4,
            Beds = 5,
            Tables = 6,
            Containers = 7,
            Electronics = 8,
            Bookcases = 9,
            Cabinets = 10,
            Cookware = 11,
            Plants = 12,
            Lighting = 13,
            Toys = 14,
            Rugs = 15,
            Tools = 16,
            Weapons = 17,
            Drapes = 18,
            Windows = 19,
            WallDecor = 20,
            Food = 36,
            Books = 37,
            Statues = 39,
            Audio = 41,
            Accents = 46,
            Banners = 47,
            BuildingBlocks = 48,
            Fireplace = 49,
            Mannequins = 50,
            Pillows = 51,
            Special = 52,
            TravelPosters = 53,
            Trophy = 54,
            Bathroom = 57,
            Doors = 59,
            Spaceship = 60,
            Hoverpark = 61,
            Beta = 66,
            Structures = 67,
        };

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

        static uint AddDecorType(DecorCategory id, string name, string luaString)
        {
            var entry = new GameTableEntry();
            entry.AddInteger(language.AddEntry(name));
            entry.AddString(luaString);

            uint _id = AddEntry(decorType, entry, ref nextDecorType, (uint) id);
            return _id;
        }

        static uint AddLightDecor(string hookAsset, uint? id = null, string name = null)
        {
            return AddGenericDecor(hookAsset, id, name, DecorCategory.Lighting, true);
        }

        static uint AddGenericDecor(string hookAsset, uint? id = null, string name = null, DecorCategory category = DecorCategory.Lighting, bool particleAlt = false)
        {
            if(betaMode)
            {
                category = DecorCategory.Beta;
            }
            var entry = new GameTableEntry();
            entry.AddInteger((uint) category);
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

        static uint AddColorShift(string colorShiftAsset, uint? id = null, string name = null)
        {
            var entry = new GameTableEntry();
            entry.AddString(colorShiftAsset); // Asset path
            if(name != null)
            {
                entry.AddInteger(language.AddEntry(name)); // localizedtextid
            }
            else
            {
                entry.AddInteger(language.AddEntry(colorShiftAsset)); // localizedtextid
            }
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
