using System.Collections.Generic;
using WildStar.TestBed.GameTable;

namespace WildStar.TestBed
{
    class Program
    {
        static void Main(string[] args)
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

            AddLightDecor("Art\\Light\\LIT_Level_Up_Spotlight_000.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Mask_Point_Med_AurinHanging.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Mask_Spotlight_Gate_000.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Point_Hard.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Point_Hard_Bright.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Point_Med.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Point_Med_Bright.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Point_Med_Bright_Amb.m3"); // Works, super bright
            AddLightDecor("Art\\Light\\LIT_Point_Soft.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Bright.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Overbright.m3"); // Works, super bright
            AddLightDecor("Art\\Light\\LIT_Point_Soft_Throb.m3"); // Works, but not animated
            AddLightDecor("Art\\Light\\LIT_Rec_Hard.m3"); // rectangle spotlight
            AddLightDecor("Art\\Light\\LIT_Rec_Med.m3"); // rectangle spotlight
            AddLightDecor("Art\\Light\\LIT_Rec_Soft.m3"); // rectangle spotlight
            // AddLightDecor("Art\\Light\\LIT_SphereTester_000.m3"); // actual sphere model

            AddLightDecor("Art\\Light\\LIT_Spot_Diffused_Overbright.m3"); // Works, super bright
            AddLightDecor("Art\\Light\\LIT_Spot_Hard.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Spot_Med.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Spot_MedNarrow_Soft.m3"); // short range
            AddLightDecor("Art\\Light\\LIT_Spot_Narrow_Med.m3"); // only starts after some distance
            AddLightDecor("Art\\Light\\LIT_Spot_Narrow_Soft.m3"); // same
            AddLightDecor("Art\\Light\\LIT_Spot_Soft.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Spot_Wide_Hard.m3"); // 80 degree cone or so
            AddLightDecor("Art\\Light\\LIT_Spot_Wide_Med.m3"); // Works!
            AddLightDecor("Art\\Light\\LIT_Spot_Wide_Soft.m3"); // Works!

            // AddLightDecor("Art\\Light\\ManScaleRef.m3"); // dummy human A-posing
            // AddLightDecor("Art\\Light\\ManTester.m3"); // huge dummy
            AddLightDecor("Art\\Light\\Mask_LIT_DIR_Crystline_001.m3"); // Subtly textured directional light
            AddLightDecor("Art\\Light\\Mask_LIT_DIR_SimpleNarrow_001.m3"); // Narrow directional light
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Cubic_Fire_001.m3"); // Cubic fire texture
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Med_Brazier.m3"); // Works!
            // AddLightDecor("Art\\Light\\Mask_LIT_Point_Med_Crystal.m3"); // Glitchy disco
            AddLightDecor("Art\\Light\\Mask_LIT_Point_Med_LavaTube.m3"); // Soft cubic firey texture
            // AddLightDecor("Art\\Light\\Mask_LIT_Point_Med_MetalCage.m3"); // Glitchy disco 2.0 purple boogaloo
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Branches_001.m3"); // Soft branch texture, directional
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Chain.m3"); // Chain texture, directional light
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001.m3"); // dappled light
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001_Short.m3"); // doesn't seem shorter in any way
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002.m3"); // dappled light, softer
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002_Short.m3"); // doesn't seem shorter in any way
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Fire_001.m3"); // Fire texture spotlight
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Grate.m3"); // Grate, directional
            AddLightDecor("Art\\Light\\Mask_LIT_Spot_Grate_Large.m3"); // Same
            /* AddLightDecor("Art\\Light\\Mask_LIT_IceShards_001.m3"); // Nothing
            AddLightDecor("Art\\Light\\Mask_LIT_Imperium.m3");
            AddLightDecor("Art\\Light\\Mask_LIT_Leaves.m3");
            AddLightDecor("Art\\Light\\Mask_LIT_Leaves_001.m3");
            AddLightDecor("Art\\Light\\Mask_LIT_Snowflake_001.m3");
            AddLightDecor("Art\\Light\\Mask_LIT_Snowflake_002.m3");
            AddLightDecor("Art\\Light\\Mask_LIT_Snowflake_003.m3");
            AddLightDecor("Art\\Light\\MC08_LIT_Point_Med.m3");
            AddLightDecor("Art\\Light\\N_LIT_Point_Hard.m3");
            AddLightDecor("Art\\Light\\N_LIT_Point_Hard_Bright.m3");
            AddLightDecor("Art\\Light\\N_LIT_Point_Med.m3");
            AddLightDecor("Art\\Light\\N_LIT_Point_Med_Bright.m3");
            AddLightDecor("Art\\Light\\N_LIT_Point_Soft.m3");
            AddLightDecor("Art\\Light\\N_LIT_Point_Soft_Bright.m3");
            AddLightDecor("Art\\Light\\N_LIT_Spot_Med.m3");*/ // Nothing


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

            foreach(var entry in emotes.Entries)
            {
                uint id = (uint) entry.Values[0].Value;
                if(id == 425)
                {
                    entry.Values[24].SetValue("lounge3");
                    break;
                }
            }

            /*foreach(var entry in housingPlugItem.Entries)
            {
                uint id = (uint)entry.Values[0].Value;
                if(id == 557)
                {
                    entry.Values[27].SetValue((uint) 0);
                }
            }*/


            hookAssets.Save("../../../../TblNew/HookAsset.tbl");

            decorInfo.Save("../../../../TblNew/HousingDecorInfo.tbl");

            language.Save("../../../../TblNew/en-US.bin");

            colorShift.Save("../../../../TblNew/ColorShift.tbl");

            //housingPlugItem.Save("../../../../TblNew/HousingPlugItem.tbl");

            emotes.Save("../../../../TblNew/Emotes.tbl");
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

        static uint AddLightDecor(string hookAsset)
        {
            return AddGenericDecor(hookAsset, 13, true);
        }

        static uint AddGenericDecor(string hookAsset, uint category = 13, bool particleAlt = false)
        {
            var entry = new GameTableEntry();
            entry.AddInteger(category); // "light" category
            entry.AddInteger(12); // hookassettypeid, 12 or 22 seem okay, 10 is not
            entry.AddInteger(language.AddEntry(hookAsset)); // localizedtextid, borrowed from Aurin Sconce
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

            decorInfo.AddEntry(entry, nextDecorID);
            nextDecorID += 1;
            return nextDecorID - 1;
        }

        static uint AddColorShift(string colorShiftAsset)
        {
            var entry = new GameTableEntry();
            entry.AddString(colorShiftAsset); // Asset path
            entry.AddInteger(language.AddEntry(colorShiftAsset)); // localizedtextid
            entry.AddString("BasicSprites:Grey"); // preview swatch icon

            colorShift.AddEntry(entry, nextShiftID);
            nextShiftID += 1;
            return nextShiftID - 1;
        }

        static uint AddEmote(uint animationID, string command)
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

            emotes.AddEntry(entry, nextEmoteID);
            nextEmoteID += 1;
            return nextEmoteID - 1;
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
