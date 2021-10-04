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
            AddDecorType(DecorCategory.Unknown, "Unknown", "INT - Unknown");
            AddDecorType(DecorCategory.Structures, "Structures", "INT - Structures");
            AddDecorType(DecorCategory.Decals, "Decals", "INT - Decals");
            AddDecorType(DecorCategory.LightSource, "Light Source", "INT - Light Source");


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

            Dictionary<uint, (String, String)> EmoteLibrary = new Dictionary<uint, (String, String)>()
            {
                { 289, ("chairsit", "chairsit1") },
                { 288, ("chairsit2", null) },
                { 280, ("channeling", "channeling1") },
                //{ 231, ("channeling2", null) },
                //{ 417, ("channeling3", null) },
                { 199, ("combatloop", null) },
                { 59, ("dazed", null) },
                { 259, ("dazedfloat", null) },
                { 134, ("deadfloat", "deadfloat1") },
                { 261, ("deadfloat2", null) },
                { 46, ("dead", "dead1") },
                { 184, ("dead2", null) },
                { 185, ("dead3", null) },
                { 186, ("dead4", null) },
                //{ 187, ("dead5", null) },
                //{ 291, ("dominionpose", null) },
                //{ 290, ("exilepose", null) },
                { 214, ("falling", null) },
                { 216, ("floating", null) },
                { 83, ("holdobject", null) },
                { 158, ("knockdown", null) },
                { 96, ("laser", null) },
                { 425, ("lounge3", null) },
                { 267, ("mount", null) },
                //{ 371, ("pistolfire", null) },
                { 86, ("readyclaws", null) },
                { 43, ("readycombat", null) },
                { 269, ("readycombatfloat", null) },
                { 266, ("readylauncher", null) },
                { 54, ("readypistols", null) },
                { 39, ("readyrifle", null) },
                { 85, ("readysword", null) },
                { 427, ("shiver", null) },
                //{ 249, ("staffchannel", null) },
                //{ 155, ("staffraise", null) },
                //{ 156, ("stealth", null) },
                //{ 232, ("swordblock", null) },
                { 97, ("talking", null) },
                { 263, ("taxisit", null) },
                { 102, ("tiedup", null) },
                { 203, ("tpose", null) },
                { 42, ("use", "use1") },
                { 35, ("use2", null) },
                { 98, ("wounded", "wounded1") },
                { 99, ("wounded2", null) },
                { 100, ("wounded3", null) },
                { 101, ("wounded4", null) }
            };

            foreach (var entry in emotes.Entries)
            {
                uint id = (uint)entry.Values[0].Value;
                if (EmoteLibrary.TryGetValue(id, out var tuple))
                {
                    entry.Values[24].SetValue(tuple.Item1 ?? "");
                    entry.Values[25].SetValue(tuple.Item2 ?? "");
                }
            }

            foreach (var entry in wallpaperInfo.Entries)
            {
                entry.Values[7].SetValue(0u);
                entry.Values[8].SetValue(0u);
            }


            AddGenericDecor("Art\\Light\\LIT_Level_Up_Spotlight_000.m3", 3699, "Spot Light (Level Up)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Mask_Point_Med_AurinHanging.m3", 3700, "Point Light (Aurin Hanging Light)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Mask_Spotlight_Gate_000.m3", 3701, "Spot Light (Gate)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Hard.m3", 3702, "Point Light (Hard)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Hard_Bright.m3", 3703, "Point Light (Hard, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med.m3", 3704, "Point Light (Medium)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med_Bright.m3", 3705, "Point Light (Medium, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med_Bright_Amb.m3", 3706, "Point Light (Medium, Bright Ambient)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft.m3", 3707, "Point Light (Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Bright.m3", 3708, "Point Light (Soft, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Overbright.m3", 3709, "Point Light (Soft, Overbright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Throb.m3", 3710, "Point Light (Soft, Throb)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Hard.m3", 3711, "Spot Light (Hard, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Med.m3", 3712, "Spot Light (Medium, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Soft.m3", 3713, "Spot Light (Soft, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Diffused_Overbright.m3", 3714, "Spot Light (Diffused, Overbright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Hard.m3", 3715, "Spot Light (Hard)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Med.m3", 3716, "Spot Light (Medium)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_MedNarrow_Soft.m3", 3717, "Spot Light (Medium, Narrow Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Narrow_Med.m3", 3718, "Spot Light (Medium, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Narrow_Soft.m3", 3719, "Spot Light (Soft, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Soft.m3", 3720, "Spot Light (Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Hard.m3", 3721, "Spot Light (Hard, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Med.m3", 3722, "Spot Light (Medium, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Soft.m3", 3723, "Spot Light (Soft, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_DIR_Crystline_001.m3", 3724, "Directional Light (Crystal)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_DIR_SimpleNarrow_001.m3", 3725, "Directional Light (Simple, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Cubic_Fire_001.m3", 3726, "Point Light (Fire Texture)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_Brazier.m3", 3727, "Point Light (Brazier)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_LavaTube.m3", 3728, "Point Light (Lava Tube)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Branches_001.m3", 3729, "Spot Light (Branches)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Chain.m3", 3730, "Spot Light (Chain Texture)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001.m3", 3731, "Spot Light (Dappled Light)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001_Short.m3", 3732, "Spot Light (Dappled Light, Short)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002.m3", 3733, "Spot Light (Dappled Light 2)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002_Short.m3", 3734, "Spot Light (Dappled Light 2, Short)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Fire_001.m3", 3735, "Spot Light (Fire)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Grate.m3", 3736, "Spot Light (Grate)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Grate_Large.m3", 3737, "Spot Light (Grate, Large)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_002.m3", 3738, "Hanging Cable (Long)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_003.m3", 3739, "Hanging Cable (Longer)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_SegmentedLong_003.m3", 3740, "Hanging Cable (Long, Drooping)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\PRP_Cable_Generic_Box_000.m3", 3741, "Cable Socket", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_007.m3", 3742, "Phial (Medium)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_008.m3", 3743, "Potion Bottle", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_009.m3", 3744, "Potion Bottle (Wide)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Bottle_Granok_Beer_000.m3", 3745, "Beer Bottle (Granok)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Granok_BeerCan_Open_000.m3", 3746, "Crushed Beer Can", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_001.m3", 3747, "Beer Can (Protostar)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_000.m3", 3748, "Crushed Beer Can (Protostar)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bar\\SanctuaryCommon\\PRP_Bar_DrinkMixer_Gold_000.m3", 3749, "Drink Mixer", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\PRP_Debris_SmugglerFighterCrashed_VAR_LeftEngine_000.m3", 3750, "Ruined Fighter Wing", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_000.m3", 3751, "Metal Panel (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_001.m3", 3752, "Metal Panel", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_002.m3", 3753, "Metal Panel (Uneven)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Falkrin\\PRP_Debris_FalkrinMetalPlate_000.m3", 3754, "Metal Scrap", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_000.m3", 3755, "Granok Trailer", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_001.m3", 3756, "Granok Trailer (Sandstone)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_000.m3", 3757, "Junk Shack (Tall)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_001.m3", 3758, "Junk Shack (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotArm_Rust_000.m3", 3759, "Rusty Bot Arm", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotBody_Rust_000.m3", 3760, "Rusty Bot Torso", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotHead_Rust_000.m3", 3761, "Rusty Bot Head", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotLeg_Rust_000.m3", 3762, "Rusty Bot Leg", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_000.m3", 3763, "Metal Pipe Tower", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_001.m3", 3764, "Large Metal Tank", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_002.m3", 3765, "Metal Scaffolding (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_003.m3", 3766, "Metal Scaffolding ", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_002.m3", 3767, "Metal Pipe Interesection", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_005.m3", 3768, "Metal Pipe Segment", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_006.m3", 3769, "Metal Pipe (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_007.m3", 3770, "Metal Pipe (Thin, Curved)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_008.m3", 3771, "Metal Pipe (Short)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_009.m3", 3772, "Metal Pipe (Curved)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_010.m3", 3773, "Metal Support Beams", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_011.m3", 3774, "Metal Support Beams (Double)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_013.m3", 3775, "Metal Rod", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_014.m3", 3776, "Faucet", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_000.m3", 3777, "Crooked Pipe", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipe_ManHole_RMC_000.m3", 3778, "Metal Pipe Cap", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_PipeBase_RMC_000.m3", 3779, "Redmoon Ventilation Pipes", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_000.m3", 3780, "Metal Tube (Curved)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_001.m3", 3781, "Metal Tube", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_002.m3", 3782, "Metal Tube (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_003.m3", 3783, "Metal Tube (Corner)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_004.m3", 3784, "Metal Pipe Moderator", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_005.m3", 3785, "Chua Sphere", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_006.m3", 3786, "Metal Tube (Reinforced)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_007.m3", 3787, "Metal Tube (Cap)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_008.m3", 3788, "Metal Tube (Short)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_009.m3", 3789, "Chua Orb", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_010.m3", 3790, "Chua Orb (Large)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_011.m3", 3791, "Chua Window", DecorCategory.Windows, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_002.m3", 3792, "Tank (Chua, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_001.m3", 3793, "Valve (Round)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_004.m3", 3794, "Valve", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_Tap_GreyBrown_001.m3", 3795, "Rusty Watertap", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Arkship\\PRP_Container_Arkship_RelicCrate_001.m3", 3796, "Shipping Crate (Open)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Arkship\\PRP_Container_Arkship_RelicCrate_002.m3", 3797, "Shipping Crate Lid", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Chua\\PRP_Chua_Container_002.m3", 3798, "Chua Speaker", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Chua\\PRP_Chua_Container_003.m3", 3799, "Tank (Chua, Small)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_000.m3", 3800, "Metal Canister (Damaged)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_001.m3", 3801, "Metal Canister (Broken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_002.m3", 3802, "Metal Fragment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Generic\\PRP_Container_Generic_Cannister_000.m3", 3803, "Canister (Ornate)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Ikthian_ContainerBot_Boxy_001.m3", 3804, "Treasure Chest (Ikthian, Open)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Container_PlasmaAquaLiquid_BlueYellow_000.m3", 3805, "Plasma Canister (Ikthian)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Container_PlasmaAquaLiquid_BlueYellow_001.m3", 3806, "Plasma Canister (Ikthian, Broken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MachineGun\\Tribal\\PRP_Turret_Tribal_000.m3", 3807, "Turret Barrel", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularShort_000.m3", 3808, "Metal Beam", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularLong_000.m3", 3809, "Metal Beam (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularLargeLong_000.m3", 3810, "Metal Beam (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularBroken_001.m3", 3811, "Metal Beam (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularTFrame_000.m3", 3812, "Metal Beam Pillar", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularShort_Brown_000.m3", 3813, "Wooden Beam", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularLong_Brown_000.m3", 3814, "Wooden Beam (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularLargeLong_Brown_000.m3", 3815, "Wooden Beam (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularBroken_Brown_000.m3", 3816, "Wooden Beam (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularTFrame_Brown_000.m3", 3817, "Wooden Beam Pillar", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamConnector_MineModularMetal_Grey_001.m3", 3818, "Metal Beam Connector", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamConnector_MineModularMetal_Grey_002.m3", 3819, "Metal Beam Connector (2)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_000.m3", 3820, "Hanging Wire (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_001.m3", 3821, "Hanging Wire (Spiraling)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_002.m3", 3822, "Hanging Wire (Coiled)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_003.m3", 3823, "Hanging Wire", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ScienceInstruments\\General\\PRP_General_LargeMicroscope_000.m3", 3824, "Microscope", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ScienceInstruments\\General\\PRP_General_SmallScanner_000.m3", 3825, "Medical Scanner", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\PRP_ArkShip_Planter_007.m3", 3826, "Robotic Arm Segment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\PRP_Bank_Atm_Generic_000.m3", 3827, "ATM Machine", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Freebot\\PRP_Machinery_FreebotTransformer_Green_000.m3", 3828, "Freebot Transformer", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Freebot\\PRP_Machinery_FreebotWelder_Green_000.m3", 3829, "Freebot Welding Unit", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Chua\\PRP_Machinery_ChuaDrill_000.m3", 3830, "Chua Drill Pod", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pillar\\Osun\\PRP_Pillar_OsunHead_000.m3", 3831, "Osun Bust", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pillar\\Algeroc\\PRP_StructuralPillar_AlgorocMineSupport_Brown_000.m3", 3832, "Wooden Column", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\PRP_Weapon_TranquilizerRounds_000.m3", 3833, "Tranquilizer Rounds", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_000.m3", 3834, "Missile (Cluster)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_001.m3", 3835, "Missile (Ballistic)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_002.m3", 3836, "Missile (Angry)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Television\\Pell\\PRP_Television_Pell_000.m3", 3837, "Pell Monitor", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Barrel_000.m3", 3838, "Cannon Barrel", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Barrel_001.m3", 3839, "Cannon Barrel (Exile)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Shield_000.m3", 3840, "Metal Panel (Exile Decal)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Imperium\\PRP_Turret_ImperiumMilitary_000.m3", 3841, "Turret (Dominion)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_000.m3", 3842, "Beaker and Vial", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_001.m3", 3843, "Beaker (Empty)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Blue_000.m3", 3844, "Beaker (Blue, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Blue_001.m3", 3845, "Beaker (Blue)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Green_000.m3", 3846, "Beaker (Green, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Green_001.m3", 3847, "Beaker (Green)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Purple_000.m3", 3848, "Beaker (Purple, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Purple_001.m3", 3849, "Beaker (Purple)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Red_000.m3", 3850, "Beaker (Red, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Red_001.m3", 3851, "Beaker (Red)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ChemistrySet_000.m3", 3852, "Chemistry Set", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ScrewDriver.m3", 3853, "Screwdriver", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_SHookMetal_Gray_003.m3", 3854, "Metal Hook", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ToolCase_000.m3", 3855, "Tool Case", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MinePileBundle_Red_000.m3", 3856, "Wire Bundle", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MinePileBundle_Red_002.m3", 3857, "Wire Bundle (Large)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Shelter\\PRP_Tools_shedgenericanimalshelter_brownrust_000.m3", 3858, "Open Shed", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Pots_and_Pans\\PRP_Tools_PotsPans_000.m3", 3859, "Empty Pot (Small)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\PRP_GearPile_Grey_000.m3", 3860, "Gear Pile", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_LargeGear_000.m3", 3861, "Freebot Gear (Large)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_LargeGear_001.m3", 3862, "Freebot Gear (Large, Tight)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_MediumGear_000.m3", 3863, "Freebot Gear (Jagged)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_SmallGear_000.m3", 3864, "Freebot Gear (Small)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Arkship_Tram_000.m3", 3865, "Arkship Tram", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Imperium_White_000.m3", 3866, "Lifter (Handle)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Imperium_White_001.m3", 3867, "Lifter", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\House\\Pell\\Large\\PRP_PellHouse_Large_000.m3", 3868, "Pell House (Large)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\House\\Pell\\Small\\PRP_PellHouse_Small_000.m3", 3869, "Pell House (Small)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokCorner_000.m3", 3870, "Granok Platform (Junction)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokLeftTurn_000.m3", 3871, "Granok Stairs (Curved, Left)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokLongStairs_000.m3", 3872, "Granok Stairs", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokPlatform_000.m3", 3873, "Granok Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokRightTurn_000.m3", 3874, "Granok Stairs (Curved, Right)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokShortStairs_000.m3", 3875, "Granok Stairs & Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokStairs_000.m3", 3876, "Granok Stairs (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokStraight_000.m3", 3877, "Granok Platform (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_LargeWoodPlank_000.m3", 3878, "Wooden Plank (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_Rope_000.m3", 3879, "Hanging Rope", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_StraightPlatform_000.m3", 3880, "Elevated Platform (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_StraightPlatform_001.m3", 3881, "Elevated Platform (Short)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_TallSmallPlatform_000.m3", 3882, "Elevated Platform (Short, End)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_TallStraightPlatform_000.m3", 3883, "Elevated Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Desk\\Protostar\\PRP_Protostar_Desk_000.m3", 3884, "Protostar Desk (Left)", DecorCategory.Tables, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Desk\\Protostar\\PRP_Protostar_Desk_001.m3", 3885, "Protostar Desk (Right)", DecorCategory.Tables, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Defiance\\PRP_DefianceMilitary_TableControlPanel_000.m3", 3886, "Data Panel (Exile)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Defiance\\PRP_DefianceMilitary_TableControlPanel_004.m3", 3887, "Wall Panel (Exile, Inverted)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Marauder\\PRP_ControlPanel_Marauder_Platform_000.m3", 3888, "Control Panel (Marauder)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Mechari\\PRP_mechari_iciinfocolumn_000.m3", 3889, "Information Terminal (Mechari)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Osun\\PRP_ControlPanel_Osun_Lever_000.m3", 3890, "Osun Lever", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Explorer_000.m3", 3891, "Control Panel (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Base_Monitor_Standing_001.m3", 3892, "Floor Panel (Dominion)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Screen_000.m3", 3893, "Data Panel (Dominion)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Screen_001.m3", 3894, "Dominion Monitor", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_Antenna_Pell_000.m3", 3895, "Antenna (Pell)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_003.m3", 3896, "Pell-Tech Device (Large)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_004.m3", 3897, "Pell-Tech Device (Medium)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_005.m3", 3898, "Pell-Tech Device (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_000.m3", 3899, "Shiphand Console", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_MonitorOcular_000.m3", 3900, "Shiphand Console (Ocular)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_MonitorSmallMid_000.m3", 3901, "Shiphand Console (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_SixButtonWallMonitor_000.m3", 3902, "Control Panel (Shiphand)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\Pell\\PRP_Jar_Pell_000.m3", 3903, "Dubious Jar", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\Imperium\\PRP_Jar_Imperium_000.m3", 3904, "Dominion Pot", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\PRP_Jar_SmugglerPearShaped_Red_000.m3", 3905, "Jar (Ornate, Painted)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jetpack\\Jetpack.m3", 3906, "Jetpack", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_QuestJobBoard_000.m3", 3907, "Job Board (Adventuring)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_000.m3", 3908, "Job Board (Engineering)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_001.m3", 3909, "Job Board Panel", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_002.m3", 3910, "Job Board Pole", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_003.m3", 3911, "Mechanicbot Pole", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_004.m3", 3912, "Job Board Panel (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\Weaponsmith\\PRP_Tradeskill_Weaponsmith_CraftingStation_000.m3", 3913, "Crafting Station (Weapons)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\Generic\\PRP_Tradeskill_GenericTable_000.m3", 3914, "Crafting Station", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Cap_000.m3", 3915, "Eldan Circuit Cap", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Cap_001.m3", 3916, "Eldan Circuit Cap (Advanced)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Tubes_000.m3", 3917, "Eldan Pylon", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Tubes_Technophage_000.m3", 3918, "Eldan Pylon (Technophage)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Pod_FuelRods_002.m3", 3919, "Eldan Fuel Rod Cap", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Warplots\\PRP_Generator_Warplots_Widget_000.m3", 3920, "Generator (Arkship)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Tribal\\PRP_Generator_Batteries_Tribal_000.m3", 3921, "Fusion Battery", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Tribal\\PRP_Generator_Tribal_000.m3", 3922, "Generator (Simple)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\PRP_ArkShip_GeneratorSmall_000.m3", 3923, "Generator (Small, Arkship)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Drakken\\PRP_Drakken_Spike_Barier_000.m3", 3924, "Draken Weapons", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Legendary\\PRP_Quest_Legendary_Maiden_000.m3", 3925, "Sword (Torine, Floating)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\PRP_Quest_Lore_Paper_000.m3", 3926, "Paper Note (Aged)", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\PRP_Quest_Lore_Scroll_000.m3", 3927, "Paper Scroll", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\prp_quest_lore_paper_001.m3", 3928, "Paper Note (Simple)", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\JonnyCab\\PRP_JonnyCab_000.m3", 3929, "TaxiBot", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\JonnyCab\\PRP_JonnyCab_001.m3", 3930, "TaxiBot (Hologram)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\TaxiKiosk\\PRP_Taxi_Kiosk_000.m3", 3931, "Taxi Kiosk", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_000.m3", 3932, "Open Metal Crate (Empty)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_001.m3", 3933, "Relic Crate", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_004.m3", 3934, "Science Crate", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_small_Toys_001.m3", 3935, "Toy Crate", DecorCategory.Toys, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_FinishLine_GroundChecker_000.m3", 3936, "Finish Line", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_HandSnowFrozen_Blue_000.m3", 3937, "Lost Arm (Frozen)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Hand_000.m3", 3938, "Lost Arm", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_HousingJobBoard_000.m3", 3939, "Job Board (Roofed)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_000.m3", 3940, "Teleporter", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_Eldan_000.m3", 3941, "Teleporter (Eldan)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_Protostar_000.m3", 3942, "Teleporter (Protostar)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Vendor_Generic_000.m3", 3943, "Vendor Terminal", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Crate\\PRP_Quest_Crate_Blue_000.m3", 3944, "Metal Crate (Blue)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Crate\\PRP_Quest_Crate_Gold_000.m3", 3945, "Metal Crate (Golden)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_000.m3", 3946, "Force Field", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_001.m3", 3947, "Force Field (Low)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_Red_Emissive_000.m3", 3948, "Forcefield, Red", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Garage_000.m3", 3949, "Garage Door (Wooden)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Cellar\\PRP_CellarDoor_SancCommonDoor_000.m3", 3950, "Cellar Door", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Drakken\\PRP_Door_DrakkenMetalGate_000.m3", 3951, "Metal Gate (Draken)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_RobotSilo_000.m3", 3952, "Eldan Silo Door", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_RobotSilo_Broken_000.m3", 3953, "Eldan Silo Door (Broken)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_IrisEldanMicro_001.m3", 3954, "Door (Eldan)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_LargeEldanDungeon_000.m3", 3955, "Eldan Gate (Large)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_SmallEldanDungeon_000.m3", 3956, "Eldan Gate (Small)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Ikthian\\PRP_Ikthian_Door_000.m3", 3957, "Metal Door (Ikthian)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Imperium\\PRP_Door_ImperiumTower_Bottom_000.m3", 3958, "Dominion Church Door, Style 1", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Imperium\\PRP_Door_ImperiumTower_Top_000.m3", 3959, "Dominion Church Door, Style 2", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Marauder\\PRP_Door_CellDoorSML_000.m3", 3960, "Door (Prison)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Marauder\\PRP_Door_RMC_Small_000.m3", 3961, "Door (Marauder)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Minekit\\PRP_Door_AlgorocMineDoor_Brown_001.m3", 3962, "Wooden Arch (Protostar)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Moodie\\PRP_Door_Frame_Moodie_002.m3", 3963, "Elevated Brazier (Moodie)", DecorCategory.Lighting, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Osun\\PRP_Door_Osun_B_000.m3", 3964, "Osun Stone Panel", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Osun\\PRP_Door_Osun_B_CinematicInteraction.m3", 3965, "Osun Face Carving", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Protostar\\PRP_Door_Protostar_Metal_Large_000.m3", 3966, "Garage Door (Protostar, Flat)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\ShipHand\\PRP_Shiphand_Door_000.m3", 3967, "Metal Door (Shiphand)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\ShipHand\\PRP_Shiphand_Door_Airlock_000.m3", 3968, "Airlock (Shiphand)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Berserker_000.m3", 3969, "Hoverboard (Berserker)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Berserker_Customization_000.m3", 3970, "Hoverboard (Berserker, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Fang_000.m3", 3971, "Hoverboard (Fang)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Fang_Customization_000.m3", 3972, "Hoverboard (Fang, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_GoGo_000.m3", 3973, "Hoverboard (GoGo)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_GoGo_Customization_000.m3", 3974, "Hoverboard (GoGo, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Ringer_000.m3", 3975, "Hoverboard (Ringer)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Ringer_Customization_000.m3", 3976, "Hoverboard (Ringer, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Turbine_000.m3", 3977, "Hoverboard (Turbine)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Turbine_Customization_000.m3", 3978, "Hoverboard (Turbine, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", 3979, "Emblem (Dominion)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", 3980, "Emblem (Exile)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_Bullseye_000.m3", 3981, "Decal (Bullseye)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_Bullseye_001.m3", 3982, "Decal (Bullseye 2)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_DarkspurSkull_000.m3", 3983, "Decal (Darkspur)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_NuclearSign_000.m3", 3984, "Decal (Nuclear)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Drakken\\PRP_MISC_DrakkenBonedStorage_000.m3", 3985, "Ancestral Urn (Draken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Drakken\\PRP_MISC_DrakkenSpikedFooty_000.m3", 3986, "Metal Boot Tip (Draken)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Eldan\\Dome\\PRP_Eldan_AKA_Core_000.m3", 3987, "Eldan Core", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Eldan\\Dome\\PRP_Eldan_Dome_Broken_000.m3", 3988, "Eldan Dome (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_000.m3", 3989, "Coconut", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_001.m3", 3990, "Coconut (Opened)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_003.m3", 3991, "Coconut Pile", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_000.m3", 3993, "Graffiti (Yellow-Violet Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_001.m3", 3994, "Graffiti (Alien Head)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_002.m3", 3995, "Graffiti (Yellow-Purple Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_003.m3", 3996, "Graffiti (Teal Skull)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_004.m3", 3997, "Graffiti (Green-White Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_005.m3", 3998, "Graffiti (Magenta-Teal Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_Judge_Kain_000.m3", 3999, "Graffiti (Judge Kain)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_Marauder_Grafitti_000.m3", 4000, "Graffiti (Marauder)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_000.m3", 4001, "Space Helm", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_001.m3", 4002, "Space Helm (Draken)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_002.m3", 4003, "Space Helm (Grumpel)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_TopHat_000.m3", 4004, "Fancy Top Hat", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\KiddiePool\\PRP_KiddiePool_000.m3", 4005, "Kiddie Pool", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Camera_Generic_001.m3", 4006, "Security Camera", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_DoorKnocker_Granok.m3", 4007, "Door Knocker (Granok)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Arms_000.m3", 4008, "Mechari Spare Arms", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Legs_000.m3", 4009, "Mechari Spare Legs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Torso_000.m3", 4010, "Mechari Spare Torso", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Mechari_Head\\Mechari_Head_Female.m3", 4011, "Mechari Head (Pink)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Mechari_Head\\PRP_Mechari_Head_Female_001.m3", 4012, "Mechari Head (Red)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_MISC_PowerCell_000.m3", 4013, "Power Cell", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Poodad.m3", 4014, "Poodad", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Tire\\PRP_Misc_Tire_001.m3", 4015, "Tire (Hollow)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_000.m3", 4016, "Plain Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_002.m3", 4017, "Striped Towel (Vertical)", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_004.m3", 4018, "Invoker Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_005.m3", 4019, "Fancy Green Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers.m3", 4020, "Stadium Seating (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Cap.m3", 4021, "Stadium Seating (Cap)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Half_000.m3", 4022, "Stadium Seating", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Half_001.m3", 4023, "Stadium Seating (Uncapped)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_000.m3", 4024, "Ritual Pot (Pell, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_002.m3", 4025, "Open Ritual Pot (Pell)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_003.m3", 4026, "Open Ritual Pot (Pell, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\WorldDestroyer_Head_Destroyed.m3", 4027, "Annihilator Head (Destroyed)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSLeftHorn_000.m3", 4028, "Cyclopean Horn (Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSLeftJaw_000.m3", 4029, "Cyclopean Jaw (Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSRightHorn_000.m3", 4030, "Cyclopean Horn (Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSRightJaw_000.m3", 4031, "Cyclopean Jaw (Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSSkull_000.m3", 4032, "Cyclopean Skull", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GiantHornedSkull_000.m3", 4033, "Cyclopean Horned Skull", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Bridge_A.m3", 4034, "Osun Bridge", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Short_A.m3", 4035, "Osun Tower (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Tall_A.m3", 4036, "Osun Stone Tower (Adorned)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Tall_B.m3", 4037, "Osun Stone Tower", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Detail_WolfHead_A.m3", 4038, "Osun Wolf Tower", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Short_A.m3", 4039, "Osun Gate", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Tall_A.m3", 4040, "Osun Siege Gate ", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Tall_B.m3", 4041, "Osun Siege Gate (Ramped)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Stairs_A.m3", 4042, "Osun Stairs", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Stairs_B.m3", 4043, "Osun Stairs (Wide)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_000.m3", 4044, "Osun Walkway", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_A.m3", 4045, "Osun Wall Segment (Slanted, In, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_B.m3", 4046, "Osun Wall Segment (Slanted, In, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_C.m3", 4047, "Osun Wall Segment (Slanted, Out, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_D.m3", 4048, "Osun Wall Segment (Slanted, Out, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_E.m3", 4049, "Osun Wall Segment", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Double_A.m3", 4050, "Osun Siege Wall", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_CurveDouble_A.m3", 4051, "Osun Siege Wall (Curved, Inward)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_CurveDouble_B.m3", 4052, "Osun Siege Wall (Curved, Outward)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Half_A.m3", 4053, "Osun Siege Wall Trim", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_A.m3", 4054, "Osun Wall (Low)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_B.m3", 4055, "Osun Wall (Low, Ramp)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_C.m3", 4056, "Osun Wall (Low, Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Tall_B.m3", 4057, "Osun Wall (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit_Ruins\\PRP_Osun_Entrance_Small.m3", 4058, "Osun Entrance", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder_weapons_000.m3", 4059, "Rocket Launcher (Exile, Small)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_001.m3", 4060, "Bone Pile", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_002.m3", 4061, "Bone Pile (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_003.m3", 4062, "Bone Pile (Elongated)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanSkeleton_Tan_000.m3", 4063, "Skeleton (Hanging)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanSkeleton_Tan_002.m3", 4064, "Skull (Human, Screaming)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_HumanSkull_003.m3", 4065, "Skull (Human, Angry)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\Dinosaur\\PRP_Bones_Dinosaur_Skull_000.m3", 4066, "Giant Skull (Dinosaur)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_000.m3", 4067, "Skull (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_001.m3", 4068, "Skull (Roc, Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_002.m3", 4069, "Skeletal Jaw (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_003.m3", 4070, "Giant Ribcage (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_004.m3", 4071, "Ribcage Bridge", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_005.m3", 4072, "Ribcage Ramp", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_006.m3", 4073, "Giant Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_007.m3", 4074, "Giant Jaw Fragment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_DragonSkeleton_Jaw_Tan_000.m3", 4075, "Dragon Skull (Jaw)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_DragonSkeleton_Skull_Tan_000.m3", 4076, "Dragon Skull (Upper)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_EnvironmentHazard_Trap_000.m3", 4077, "Rib Cluster", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_GirokSkullClean_Tan_000.m3", 4078, "Skull (Girrok)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Hand_Large_Tan_000.m3", 4079, "Giant Skeletal Hand", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegAnimalClean_Tan_000.m3", 4080, "Bone", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegwithMeat_Tan_001.m3", 4081, "Meaty Rib", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegwithMeat_Tan_002.m3", 4082, "Meaty Bone", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LongBone_Large_Tan_000.m3", 4083, "Bone (Massive)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_PumeraSkullClean_Tan_000.m3", 4084, "Skull (Pumera)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RhinoSkull_Small_Tan_000.m3", 4085, "Skull (Mammodin, Juvenile)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RhinoSkull_SquareHorn_Tan_000.m3", 4086, "Skull (Mammodin, Adult)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_000.m3", 4087, "Ribcage (Whole)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_001.m3", 4088, "Ribcage (Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_002.m3", 4089, "Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_004.m3", 4090, "Ribs (Half, left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_005.m3", 4091, "Ribs (Half, right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Hide_Large_Tan_000.m3", 4092, "Giant Ribcage (Spiny, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Hide_Large_Tan_001.m3", 4093, "Giant Ribcage (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_000.m3", 4094, "Giant Ribcage (Spiny)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_001.m3", 4095, "Giant Ribcage (Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_002.m3", 4096, "Giant Ribcage (Half, Collapsed)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_hide_Large_Tan_000.m3", 4097, "Giant Ribcage (Spiny, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsEarthrender_Large_Tan_000.m3", 4098, "Giant Ribcage (Earth-Render)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_000.m3", 4099, "Ribcage (Whole, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_001.m3", 4100, "Ribcage (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_002.m3", 4101, "Ribs (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_003.m3", 4102, "Human Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_000.m3", 4103, "Ribs (Half, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_001.m3", 4104, "Ribcage (Half, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_002.m3", 4105, "Ribcage (Whole, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_SingleRib_Large_Tan_000.m3", 4106, "Giant Rib", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Skull_BirdLikeWithTeath_Tan_000.m3", 4107, "Skull (Giant Pirahna)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Skull_RhinoWithTeath_Tan_000.m3", 4108, "Skull (Rhino, Tusks)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_SpineAnimalClean_Tan_000.m3", 4109, "Misplaced Spine", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_000.m3", 4110, "Fishing Line", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_001.m3", 4111, "Hanging Fish (Clustered)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_002.m3", 4112, "Hanging Fish (Spread)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_003.m3", 4113, "Fish Carcasses (Clustered)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_004.m3", 4114, "Fish Carcasses (Spread)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_005.m3", 4115, "Fish Skeleton", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_006.m3", 4116, "Fish Carcass", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_003.m3", 4117, "Weapon Rack (Draken, Empty)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\ToolShed\\PRP_Tools_shedgenericwood_brownrust_000.m3", 4118, "Tool Shed (Table)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\ToolShed\\PRP_Tools_shedgenericwood_brownrust_001.m3", 4119, "Tool Shed", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\TorineDungeon\\PRP_Water_TorineDungeon_001.m3", 4120, "Pool of Blood", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_OGE.m3", 4121, "Lava Eruption (Line)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_noDecal_OGE.m3", 4122, "Lava Eruption (Line, Scorching)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Impacts\\Lava_Splash\\Lava_Splash_OGE.m3", 4123, "Lava Splash", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_10mR.m3", 4124, "Lava Spring (Large)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_5mR.m3", 4125, "Lava Spring (Medium)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_10mR.m3", 4126, "Lava Bubbles (Large, Ring)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_15mR.m3", 4127, "Lava Bubbles (Medium, Ring)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_10mR.m3", 4128, "Lava Pool (Large, Grounded)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_3mR.m3", 4129, "Lava Pool (Small, Bubbling)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR.m3", 4130, "Lava Pool (Medium)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_AQU.m3", 4131, "Lava Pool (Medium, Teal)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_GLD.m3", 4132, "Lava Pool (Medium, Gold)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_3mR.m3", 4133, "Lava Bubbles (Small)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_5mR.m3", 4134, "Lava Bubbles (Medium, Grounded)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_NoGrndConst_5mR.m3", 4135, "Lava Bubbles (Medium)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGrndConst_10mR.m3", 4136, "Lava Pool (Large)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Wave\\Lava_Wave.m3", 4137, "Lava Bubbles (Violent, Line)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_Eruption_2mR_4mH_OGE.m3", 4138, "Lava Burst (Scorching)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_LinearEruption_2mR_4mH_NoDecal_OGE.m3", 4139, "Lava Burst", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Geyser\\Lava_Geyser_OGE.m3", 4140, "Lava Geyser", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Prop\\Dungeon\\Datascape\\LavaRock\\PRP_Datascape_LavaRock_000.m3", 4141, "Volcanic Rock", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Islands\\PRP_SkymapIsland_Lava_Terrain_000.m3", 4142, "Lava Terrain Slab", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_000.m3", 4143, "Lavafall (Small)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_001.m3", 4144, "Lavafall (Tall)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_002.m3", 4145, "Lava Pool (Small)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_002.m3", 4146, "Lava Blob", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_004.m3", 4147, "Lava Chunk", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_Tall_001.m3", 4148, "Lava Blob (Tall)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood1n2\\Blood1n2.m3", 4149, "Blood Magic (Pulsing)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_01.m3", 4150, "Blood Magic", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Channels\\Siphon\\Siphon.m3", 4151, "Blood Siphon", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Channels\\Siphon\\Siphon_12.m3", 4152, "Orange Glow", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Double_Vertical\\Double_Vertical.m3", 4153, "Blood Explosion", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Gib\\Gib_14.m3", 4154, "Blood Burst (Messy)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Hit_Default\\Hit_Default_14.m3", 4155, "Blood Burst", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Pumera_Pounce\\Pumera_Pounce_14.m3", 4156, "Blood Spray (Intermediate)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Pumera_Pounce\\Pumera_Pounce_14_GRN.m3", 4157, "Blood Spray (Intermediate, Green)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Slash_Horizontal\\Slash_Horizontal_14.m3", 4158, "Blood Squirt", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Slash_Spray\\Slash_Spray.m3", 4159, "Blood Spray (Intermediate, Large)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Vulcarrion_Divebomb\\Vulcarrion_Divebomb_14.m3", 4160, "Blood Burst (Small)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Default\\Default_14.m3", 4161, "Gushing Blood (Messy)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Slash_Wound\\Slash_Wound.m3", 4162, "Gushing Blood (Downward)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Spray_Vertical\\Spray_Vertical.m3", 4163, "Blood Spray (Continuous)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Squirt_01\\Squirt_01_14.m3", 4164, "Blood Squirt (Alternate)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Water\\Ocean\\Water_Ocean_WaveCircle_000.m3", 4165, "Water Surface", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Water\\Ocean\\Water_Ocean_WaveShoreline_000.m3", 4166, "Ocean Waves", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Corner_A.m3", 4167, "Osun Walkway (Corner)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Curve_A.m3", 4168, "Osun Walkway (Curved, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Curve_B.m3", 4169, "Osun Walkway (Curved, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Long_A.m3", 4170, "Osun Walkway (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Ramp_A.m3", 4171, "Osun Ramp", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Short_A.m3", 4172, "Osun Walkway (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_SlopeLong_A.m3", 4173, "Osun Sloped Walk way (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_SlopeShort_A.m3", 4174, "Osun Sloped Walk way", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_A_000.m3", 4175, "Osun Support Arch", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_B.m3", 4176, "Osun Support Strut", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_C.m3", 4177, "Osun Anvil Sculpture", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\Elemental\\PRP_Bones_Elemental_000.m3", 4178, "Elemental Remnants", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_ShortAxe_000.m3", 4179, "Draken War Axe (Short)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_ShortAxe_001.m3", 4180, "Draken War Axe (Long)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_Spear_000.m3", 4181, "Serrated Spear", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\PRP_WeaponRack_ImperiumFreeStanding_Black_000.m3", 4182, "Dominion Weapon Rack", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\PRP_Vending_GranokBeer_000.m3", 4183, "Vending Machine (Granok Beer)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\AbilityVendor\\PRP_Vending_AbilityVendor_000.m3", 4184, "BoxerBot", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\Chua\\PRP_Building_ChuaShop_000.m3", 4185, "Chua Shop", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Speaker\\Generic\\PRP_Speaker_Generic_Grey_000.m3", 4186, "Speaker (Small)", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Speaker\\Marauder\\PRP_Speaker_MarauderSpeaker_000.m3", 4187, "Speaker (Marauder)", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_007.m3", 4188, "Draken Horn (Curved, Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_008.m3", 4189, "Draken Horn (Curved, Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_009.m3", 4190, "Draken Horn (Painted, Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_010.m3", 4191, "Draken Horn (Painted, Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_011.m3", 4192, "Draken Horn (Painted, Short)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_012.m3", 4193, "Draken Horn (Curved, Gilded)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_013.m3", 4194, "Draken Horn (Gilded)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Horn_DrakkenLSupported_000.m3", 4195, "Draken War Horn", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Book\\BookOfDominus\\PRP_Book_BookofDominus_000.m3", 4196, "Invoker's Grimoire", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Fence\\Protostar\\PRP_Fence_ProtostarSpaceGeneric_003.m3", 4197, "Metal Pole", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\CampFire\\PRP_CampFire_Generic_RedGrey_001.m3", 4198, "Campfire (Large)", DecorCategory.Lighting, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\CampFire\\PRP_CampFire_Generic_RedGrey_002.m3", 4199, "Bonfire", DecorCategory.Lighting, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Ship\\GeneralCargoShip\\PRP_Ship_GeneralCargoShip_000.m3", 4200, "Piglet Ship", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Ship\\GeneralCargoShip\\PRP_Ship_GeneralCargoShip_001.m3", 4201, "Piglet Ship (Dark)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vent\\PRP_Vent_Big_RMC_000.m3", 4202, "Redmoon Ship Vent", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", 4203, "Ship Tech Panel (Round)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_001.m3", 4204, "Ship Tech Panel (Flat)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_002.m3", 4205, "Ship Support Strut", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Engine_005.m3", 4206, "Fighter Ship Engine", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Light_002.m3", 4207, "Fighter Ship Light", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Left_002.m3", 4208, "Fighter Ship Wing (Left)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Right_002.m3", 4209, "Fighter Ship Wing (Right)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Water_GenericPool_000.m3", 4210, "Hot Springs Pool (Bright)", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Water_Grimvault_Bubbles_000.m3", 4211, "Glowing Purple Bubble", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Waterfall_NPE_000.m3", 4212, "Waterfall (Triple)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\SunkenShip\\PRP_Water_SunkenShip_000.m3", 4213, "Pool (Hard-edged)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\TorineDungeon\\PRP_Water_TorineDungeon_000.m3", 4214, "Pool (Oddly Shaped)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Sanctuary_Common\\Galeras_Kit\\Windmill\\PRP_Building_SCGalerasWindmill_001.m3", 4215, "Windmill Tower (Geleras)", DecorCategory.Structures, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MedicalStation\\PRP_MedicalStation_FloatingMedCross_000.m3", 4216, "Holographic Medical Sign", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\PellTech\\BrokenPieces\\PRP_PellTech_BrokenPiecesJunk_Aqua_000.m3", 4217, "Pell-Tech Fragment", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\PellTech\\BrokenAntenna\\PRP_PellTech_BrokenAntenna_000.m3", 4218, "Broken Antenna (Pell-Tech)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Mount\\Hoverboard\\Hoverboard_Default\\HoverBoard_Default.m3", 4219, "Hoverboard (Flux)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\DominionHoverBike\\Mount_DominionHoverBike.m3", 4220, "Uniblade", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Flying\\Glider\\Mount_Glider_000.m3", 4221, "Glider", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Flying\\Puffy_Cat\\PuffyCat.m3", 4222, "Snarfelynx", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Ball\\Orbitron\\Mount_Ball_Orbitron_000.m3", 4223, "Orbitron Frame", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Boat\\Mount_Vehicle_Boat.m3", 4224, "Marauder Starsloop", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_ProtoStarEnforcer\\Mount_Vehicle_ProtoStarEnforcer.m3", 4225, "Protostar Spiderbot", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Skiff\\Mount_Vehicle_Skiff_Marauder.m3", 4226, "Marauder Skiff", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Chua\\PRP_Mount_Chua_000.m3", 4227, "Orbitron", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder.m3", 4228, "Grinder (Exile)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DarkspurSpeeder.m3", 4229, "Grinder (Darkspur)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder_001.m3", 4230, "Grinder (Exile, Armed)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Metal_Tech_000.m3", 4231, "Metal Tech Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_Splatter_Decal\\Blood_Splatter_Decal.m3", 4232, "Blood Splatter HoloDecal", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_Splatter_Decal\\Blood_Splatter_Decal_GRN.m3", 4233, "Blood Splatter HoloDecal (Green)", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Black\\OT\\Splatter_Decal\\Blood_Splatter_Decal_01.m3", 4234, "Blood Splatter (Black)", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_01.m3", 4235, "Blood Splatter", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_02.m3", 4236, "Blood Stains", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_02_GRN.m3", 4237, "Blood Stains (Green)", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MineWoodBundle_Red_001.m3", 4238, "Cable (Coiled, Empty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_Caustics.m3", 4239, "Point Light (Caustic, Animated)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_LavaTube.m3", 4240, "Point Light (Lava Tube, Moving)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Hard_Bright_Pulse.m3", 4241, "Point Light (Bright, Slow Pulse)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Med_Flicker.m3", 4242, "Point Light (Bright, Flickering)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Med_Throb.m3", 4243, "Point Light (Fast Pulse)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Drusera_GlowCone_000.m3", 4244, "Volumetric Light (Column)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Rays_LongNarrow_000.m3", 4245, "Volumetric Light (Sphere)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Rays_MediumWide_000.m3", 4246, "Volumetric Light (Sphere, Bright)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_20Man.m3", 4247, "Directional Light (Blue, Dappled)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_IcyPeak.m3", 4248, "Point Light (Bright, Dappled, Blue)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_IcyPeakPlatforms.m3", 4249, "Point Light (Bright, Pale Green)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_RMT_Shredder.m3", 4250, "Directional Light (Orange, Stops at Gizmo)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_Anim_Point_AuroriaAdventureFire_000.m3", 4251, "Point Light (Soft, Orange)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_Design_DatacoreElemental_Point_Med_000.m3", 4252, "Point Light (Soft, Pale Blue)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_Point_5m_Blue_000.m3", 4253, "Point Light (Soft, Blue)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_000.m3", 4254, "Spot Light (Ground Target, Highlight)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_001.m3", 4255, "Spot Light (Highlight)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_HeadLight_000.m3", 4256, "Spot Light (Volumetric, Flickering)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\Light_HalonRing_RotatingAstroid_000.m3", 4257, "Spot Light (Search Light)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Twisted_Climbing_Mossy\\PRP_Tree_Twisted_Climbing_Moss_Gray_001.m3", 4258, "Verdant Climbing Tree", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Twisted_Climbing_Mossy\\PRP_Tree_Twisted_Climbing_Moss_Gray_002.m3", 4259, "Verdant Climbing Tree (Clean)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_000.m3", 4260, "Tree of Life", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentDefense_000.m3", 4261, "Overgrown Exanite Orb", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentOffense_000.m3", 4262, "Overgrown Exanite Spikes", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentReward_000.m3", 4263, "Overgrown Exanite Pillar", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_000.m3", 4264, "Slimefall (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_001.m3", 4265, "Slime Blob (Black, Large)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_002.m3", 4266, "Slimefall (Black, Tall)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_003.m3", 4267, "Slimefall (Black, Tall Vertical)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_004.m3", 4268, "Slimefall (Black, Short Vertical)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_005.m3", 4269, "Hanging Slime (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_006.m3", 4270, "Hanging Slime (Black, Huge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_007.m3", 4271, "Hanging Slimefall (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_008.m3", 4272, "Slime Blob (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_009.m3", 4273, "Slime Web", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_Floor_000.m3", 4274, "Slime Pool (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Soulfrost\\PRP_Natural_Slime_SoulfrostFloor_000.m3", 4275, "Soulfrost Pool", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMedium_GreenDark_000.m3", 4276, "Skug Slime (Medium, Style 1)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMedium_GreenDark_001.m3", 4277, "Skug Slime (Medium, Style 2)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_000.m3", 4278, "Skug Slime (Mini, Style 1)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_001.m3", 4279, "Skug Slime (Mini, Style 2)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_002.m3", 4280, "Skug Slime (Mini, Style 3)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_003.m3", 4281, "Skug Slime (Mini, Style 4)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_000.m3", 4282, "Skug Slime (Small, Style 1)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_001.m3", 4283, "Skug Slime (Small, Style 2)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_002.m3", 4284, "Skug Slime (Small, Style 3)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_003.m3", 4285, "Skug Slime (Small, Style 4)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_004.m3", 4286, "Skug Slime (Small, Style 5)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_005.m3", 4287, "Skug Slime (Small, Style 6)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_006.m3", 4288, "Skug Slime (Small, Style 7)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_007.m3", 4289, "Skug Slime (Small, Style 8)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_008.m3", 4290, "Skug Slime (Small, Style 9)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_009.m3", 4291, "Skug Slime (Small, Style 10)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_000.m3", 4292, "Mud Cube", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_001.m3", 4293, "Mud Cube (Tall)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_002.m3", 4294, "Mud Cube (Wide)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_000.m3", 4295, "Slimefall (Honey)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_001.m3", 4296, "Slimefall (Honey, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_002.m3", 4297, "Hanging Slime (Honey, Huge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_003.m3", 4298, "Hanging Slime (Honey, Ledge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_004.m3", 4299, "Hanging Slimefall (Honey)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_005.m3", 4300, "Hanging Slime (Honey, Broad)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_006.m3", 4301, "Hanging Slime (Honey, Large)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_007.m3", 4302, "Slime Blob (Honey)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_008.m3", 4303, "Hanging Slime (Honey, Drop)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_009.m3", 4304, "Hanging Slime (Honey)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_010.m3", 4305, "Hanging Slime (Honey, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_011.m3", 4306, "Hanging Slime (Honey, Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_012.m3", 4307, "Hanging Slime (Honey, Extra Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_013.m3", 4308, "Hanging Slime (Honey, Thin)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_014.m3", 4309, "Hanging Slime (Honey, Extra Long Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_015.m3", 4310, "Slime Blob (Honey, Small)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_000.m3", 4311, "Slimefall (Tar)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_001.m3", 4312, "Slimefall (Tar, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_002.m3", 4313, "Slime Blob (Tar)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_003.m3", 4314, "Hanging Slime (Tar, Drop)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_004.m3", 4315, "Slime Blob (Tar, Small)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_005.m3", 4316, "Hanging Slimefall (Tar)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_006.m3", 4317, "Hanging Slime (Tar)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_007.m3", 4318, "Hanging Slime (Tar, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_008.m3", 4319, "Hanging Slime (Tar, Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_009.m3", 4320, "Hanging Slime (Tar, Extra Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_010.m3", 4321, "Hanging Slime (Tar, Thin)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_011.m3", 4322, "Hanging Slime (Tar, Extra Long Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\Tar_PPL\\PRP_Natural_Slime_Tar_PPL_004.m3", 4323, "Slime Blob (Purple, Small)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_000.m3", 4324, "Slimefall (Tech)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_001.m3", 4325, "Slimefall (Tech, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_002.m3", 4326, "Hanging Slime (Tech, Huge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_004.m3", 4327, "Hanging Slimefall (Tech)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_005.m3", 4328, "Hanging Slime (Tech, Wide)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_006.m3", 4329, "Hanging Slime (Tech, Large)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_007.m3", 4330, "Slime Blob (Tech)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_008.m3", 4331, "Hanging Slime (Tech, Drop)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_009.m3", 4332, "Hanging Slime (Tech)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_011.m3", 4333, "Hanging Slime (Tech, Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_012.m3", 4334, "Hanging Slime (Tech, Extra Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_013.m3", 4335, "Hanging Slime (Tech, Thin)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_014.m3", 4336, "Hanging Slime (Tech, Extra Long Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_000.m3", 4337, "Slimefall (Metal, Thick)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_001.m3", 4338, "Slimefall (Metal, Tall)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_002.m3", 4339, "Slimefall Pool (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_000.m3", 4340, "Slimefall (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_001.m3", 4341, "Slimefall (Metal, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_002.m3", 4342, "Hanging Slime (Metal, Huge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_003.m3", 4343, "Hanging Slime (Metal, Ledge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_004.m3", 4344, "Hanging Slimefall (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_005.m3", 4345, "Hanging Slime (Metal, Broad)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_006.m3", 4346, "Hanging Slime (Metal, Large)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_007.m3", 4347, "Slime Blob (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_008.m3", 4348, "Hanging Slime (Metal, Drop)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_009.m3", 4349, "Hanging Slime (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_010.m3", 4350, "Hanging Slime (Metal, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_011.m3", 4351, "Hanging Slime (Metal, Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_000.m3", 4352, "Slimefall (Toxic, Thick)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_001.m3", 4353, "Slimefall (Toxic, Horizontal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_002.m3", 4354, "Slimefall Pool (Toxic)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_Foam_000.m3", 4355, "Foamy Waterfall", DecorCategory.ParticleEffects, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyerBot_All.m3", 4356, "Annihilator Robot", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Structure\\Design_Layout\\Eastern\\Algeroc\\STR_Building_SCMedArmorShop_Tan_Background_AP_000.m3", 4357, "Cozy Exile House (Armored)", DecorCategory.Structures, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Islands\\PRP_SkymapIsland_Water_Terrain_000.m3", 4358, "Snowy Platform", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_Battlebot_Head_000.m3", 4359, "Battlebot Head", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotCore_000.m3", 4360, "Megadroid Core", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotFoot_Grey_000.m3", 4361, "Megadroid Foot (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHangingWire_000.m3", 4362, "MegaDroid Wire (Hanging)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHead_000.m3", 4363, "Megadroid Head (Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHead_Grey_000.m3", 4364, "Megadroid Head (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHips_Grey_000.m3", 4365, "Megadroid Hips (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftArm_000.m3", 4366, "Megadroid Arm (Left, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftArm_Grey_000.m3", 4367, "Megadroid Arm (Left, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLeg_Grey_000.m3", 4368, "Megadroid Leg (Left, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerArm_000.m3", 4369, "Megadroid Arm (Left, Lower, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerArm_Grey_000.m3", 4370, "Megadroid Arm (Left, Lower, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerLeg_Grey_000.m3", 4371, "Megadroid Leg (Left, Lower, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperArm_000.m3", 4372, "Megadroid Arm (Left, Upper, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperArm_Grey_000.m3", 4373, "Megadroid Arm (Left, Upper, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperLeg_Grey_000.m3", 4374, "Megadroid Leg (Left, Upper, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightArm_000.m3", 4375, "Megadroid Arm (Right)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightArm_Grey_000.m3", 4376, "Megadroid Arm (Right, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLeg_Grey_000.m3", 4377, "Megadroid Leg (Right, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerArm_000.m3", 4378, "Megadroid Arm (Right, Lower)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerArm_Grey_000.m3", 4379, "Megadroid Arm (Right, Lower, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerLeg_Grey_000.m3", 4380, "Megadroid Leg (Right, Lower, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperArm_000.m3", 4381, "Megadroid Arm (Right, Upper)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperArm_Grey_000.m3", 4382, "Megadroid Arm (Right, Upper, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperLeg_Grey_000.m3", 4383, "Megadroid Leg (Right, Upper, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotShoulder_Grey_000.m3", 4384, "Megadroid Shoulder (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotTorso_000.m3", 4385, "Megadroid Torso (Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotTorso_Grey_000.m3", 4386, "Megadroid Torso (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_000.m3", 4387, "Megadroid (Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_Grey_000.m3", 4388, "Megadroid (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_Grey_001.m3", 4389, "Megadroid (Grey, Active)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWire_000.m3", 4390, "MegaDroid Wire", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Arm_000.m3", 4391, "Warbot Arm", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Head_000.m3", 4392, "Warbot Head", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Leg_000.m3", 4393, "Warbot Leg", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Pauldron_000.m3", 4394, "Warbot Pauldron", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Torso_000.m3", 4395, "Warbot Torso", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_Assorted_Metal_000.m3", 4396, "Metal Door (Tech)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_Assorted_Stone_000.m3", 4397, "Wooden Door (Stone Frame)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_Assorted_wood_000.m3", 4398, "Wooden Door (Tech)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_SancCommon_001.m3", 4399, "Metal Door (Ornate)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_SancCommon_002.m3", 4400, "Metal Door (Stone Frame)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Animated_AsteroidField_000.m3", 4401, "Floating Rocks", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_000.m3", 4402, "Asteroid Field (Large)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_001.m3", 4403, "Asteroid Field (Double)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_002.m3", 4404, "Asteroid Field (Scattered)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_003.m3", 4405, "Asteroid Field (Small)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_000.m3", 4406, "Rock Pillar (Massive, Leaning)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_001.m3", 4407, "Rock Pillar (Straight)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_002.m3", 4408, "Rock Pillar (Jagged)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_003.m3", 4409, "Rock Pillar (Pointy)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\CrumblingGround\\PRP_Rock_CrumblingGround_000.m3", 4410, "Circular Stone Floor", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\CrumblingGround\\PRP_Rock_CrumblingGround_Eldan_000.m3", 4411, "Circular Stone Floor (Eldan)", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Drusera\\PRP_Crystal_Drusera_000.m3", 4412, "Genesis Prime", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlBag_Blue_000.m3", 4413, "Bag of Pearls (Blue)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlBag_Pink_000.m3", 4414, "Bag of Pearls (Pink)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_Blue_000.m3", 4415, "Pearl Pile (Blue)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_Pink_000.m3", 4416, "Pearl Pile (Pink)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_White_000.m3", 4417, "Pearl Pile (White)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Blue_000.m3", 4418, "Pearl (Blue)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Blue_FX_000.m3", 4419, "Pearl (Blue, Glowing)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Green_FX_000.m3", 4420, "Glowing Orb (Green)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Pink_000.m3", 4421, "Pearl (Pink)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_White_000.m3", 4422, "Pearl (White)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Blue_000.m3", 4423, "Mangrove_Blue", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Burnt_000.m3", 4424, "Mangrove Tree (Burnt)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_000.m3", 4425, "Mangrove Tree (Green)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_001.m3", 4426, "Mangrove Tree (Green, Chubby)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_002.m3", 4427, "Mangrove Tree (Green, Lanky)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_003.m3", 4428, "Mangrove Tree (Green, Closed)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Violet_000.m3", 4429, "Mangrove Tree (Violet)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_Seed_000.m3", 4430, "Eldan Tech Seed", DecorCategory.Plants, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Vent_000.m3", 4431, "Redmoon Ventilation System", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Wind_Woosh_000.m3", 4432, "Woosh", DecorCategory.ParticleEffects, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Wind_Woosh_001.m3", 4433, "Woosh (Vortex)", DecorCategory.ParticleEffects, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_PoopPile_000.m3", 4434, "Towering Bathroom Incident", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_PoopPile_Bubble_000.m3", 4435, "Dung Bubble", DecorCategory.ParticleEffects, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\ShellarkTank\\PRP_RMT_Act2_ShellarkTank_000.m3", 4436, "Redmoon Fish Tank", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\ShellarkTank\\PRP_RMT_Act2_ShellarkTank_Shellarks_000.m3", 4437, "Shellarks", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Grill_000.m3", 4438, "Grill", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Light_000.m3", 4439, "Pirate Light", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Pipe_000.m3", 4440, "Pirate Pipe", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Wok_000.m3", 4441, "Wok", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\SteamVent\\PRP_RMT_SteamVent_000.m3", 4442, "Redmoon Steam Vent", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Tesla_Device\\PRP_TeslaDevice_000.m3", 4443, "Redmoon Tesla Device", DecorCategory.Electronics, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Bar\\PRP_RMT_Act2_Bar_001.m3", 4444, "Redmoon Bar (Straight, Long)", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Bar\\PRP_RMT_Act2_Bar_002.m3", 4445, "Redmoon Bar (Straight)", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\GlowingSkull\\PRP_RMT_GlowingSkull_000.m3", 4446, "Skull (Glowing)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Comet\\PRP_RMT_Comet_000.m3", 4447, "Comet", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Fan\\PRP_RMT_Fan_000.m3", 4448, "Redmoon Fan", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_000.m3", 4449, "Ship Hologram (Hopper)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_001.m3", 4450, "Ship Hologram (Arkship)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_002.m3", 4451, "Ship Hologram (Piglet)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_003.m3", 4452, "Ship Hologram (Crabber)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MedbayLight\\PRP_RMT_MedbayLight_000.m3", 4453, "Medical Light", DecorCategory.Lighting, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MogMog\\PRP_RMT_MogMog_000.m3", 4454, "Mask of Mog Mog", DecorCategory.StatuesSculptures, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_000.m3", 4455, "Morgue Drawer (Ornate)", DecorCategory.Containers, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_001.m3", 4456, "Morgue Drawer (Ornate, Crooked)", DecorCategory.Containers, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_002.m3", 4457, "Morgue Drawer (Ornate, Bent)", DecorCategory.Containers, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_003.m3", 4458, "Morgue Drawer (Simple)", DecorCategory.Containers, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_000.m3", 4459, "Operating Storage Table", DecorCategory.Tables, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_001.m3", 4460, "Operating Table", DecorCategory.Tables, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_002.m3", 4461, "Operating Table (Drainage Pipe)", DecorCategory.Tables, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\PASystem\\PRP_RMT_PASystem_000.m3", 4462, "Redmoon Speaker System", DecorCategory.Audio, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Blue_000.m3", 4463, "Planet: Cassus", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Cracked_000.m3", 4464, "Planet: Aldinari", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Tan_000.m3", 4465, "Planet: Vulpes Nix", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Planet\\PRP_Planet_All_000.m3", 4466, "Planet", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Planet\\PRP_Planet_Farside_000.m3", 4467, "Farside", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Planet\\PRP_Planet_Nebula.m3", 4468, "Nebula", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Planet\\PRP_Planet_Nexus_000.m3", 4469, "Planet: Nexus", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\PlantStand\\PRP_RMT_PlantStand_000.m3", 4470, "Redmoon Plant Stand", DecorCategory.Plants, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Sun\\PRP_RMT_Sun_000.m3", 4471, "Sun (Alpha Cassus)", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Vine\\PRP_RMT_Vine_SmallThinLoose_001.m3", 4472, "Hanging Vine (Small, Drooping)", DecorCategory.Plants, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Airlock_Wind_000.m3", 4473, "Airlock Wind", DecorCategory.ParticleEffects, true, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Choppa_Blade_000.m3", 4474, "Redmoon Fan Blade", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Choppa_TrashChuteRing_000.m3", 4475, "Redmoon Fan Ring", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Decal_MarauderHead_Painted_000.m3", 4476, "Metal Sigil (Redmoon, Painted)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Deck_Turret_000.m3", 4477, "Redmoon Deck Turret", DecorCategory.WeaponsArmor, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Elevator_Platform_000.m3", 4478, "Redmoon Elevator Platform", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_BossPlatform_Center_000.m3", 4479, "Redmoon Metal Platform", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_Piston_000.m3", 4480, "Engine Piston", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Furnace_000.m3", 4481, "Redmoon Furnace", DecorCategory.Structures, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Grill_000.m3", 4482, "Redmoon Grill", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Fog\\PRP_Fog_GroundCover_000.m3", 4483, "!NEW! Creeping Fog", DecorCategory.ParticleEffects, true, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Large_umberla_Pine\\PRP_Tree_LargeUmberla_LargePine_001.m3", 4484, "!NEW! Umbrella Pine (Violet)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Large_umberla_Pine\\PRP_Tree_LargeUmberla_MidPine_000.m3", 4485, "!NEW! Umbrella Pine (Lanky)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_000.m3", 4486, "!NEW! Life-Infused Tree", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_001.m3", 4487, "!NEW! Life-Infused Tree (Bushy)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_002.m3", 4488, "!NEW! Life-Infused Tree (Pointy)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_000.m3", 4489, "!NEW! Mangrove Tree (Yellow)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_000.m3", 4490, "!NEW! Green Swirly Rock (Flat)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_001.m3", 4491, "!NEW! Green Swirly Rock (Pointy)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_002.m3", 4492, "!NEW! Green Swirly Rock (Cross)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_003.m3", 4493, "!NEW! Green Swirly Rock (Teardrop)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_000.m3", 4494, "!NEW! Green Swirly Rock (Egg-Shaped, Green)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_001.m3", 4495, "!NEW! Green Swirly Rock (Curved)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_002.m3", 4496, "!NEW! Green Swirly Rock (Concave)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_003.m3", 4497, "!NEW! Green Swirly Rock (Smooth)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_000.m3", 4498, "!NEW! Green Swirly Rock (Uneven)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_001.m3", 4499, "!NEW! Green Swirly Rock (Double)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_002.m3", 4500, "!NEW! Green Swirly Rock", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_003.m3", 4501, "!NEW! Green Swirly Rock (Greener)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Primal\\PRP_Rock_Primal_EarthCrystal_000.m3", 4502, "!NEW! Primal Earth Crystal", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_000.m3", 4503, "!NEW! Creepy Rock (Jagged, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_001.m3", 4504, "!NEW! Creepy Rock (Looming, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_002.m3", 4505, "!NEW! Creepy Rock (Balanced, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_003.m3", 4506, "!NEW! Creepy Rock (Claw-Shaped, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_004.m3", 4507, "!NEW! Creepy Rock (Pointy, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_000.m3", 4508, "!NEW! Creepy Rock (Jagged, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_001.m3", 4509, "!NEW! Creepy Rock (Looming, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_002.m3", 4510, "!NEW! Creepy Rock (Balanced, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_003.m3", 4511, "!NEW! Creepy Rock (Claw-Shaped, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_004.m3", 4512, "!NEW! Creepy Rock (Pointy, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_000.m3", 4513, "!NEW! Tall Rock (Style 1)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_001.m3", 4514, "!NEW! Tall Rock (Style 2)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_002.m3", 4515, "!NEW! Tall Rock (Style 3)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_003.m3", 4516, "!NEW! Tall Rock (Style 4)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_004.m3", 4517, "!NEW! Tall Rock (Style 5)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Whitevale_Crater\\PRP_Rock_Whitevale_Crater_000.m3", 4518, "!NEW! Floating Crater", DecorCategory.Special, false, 4);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_Turbulence_000.m3", 4519, "!NEW! Turbulence", DecorCategory.ParticleEffects, true, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_A.m3", 4520, "!NEW! Aurin Roof (Large, Purple)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_B.m3", 4521, "!NEW! Aurin Roof (Large, Blue)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_C.m3", 4522, "!NEW! Aurin Roof (Large, Magenta)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_D.m3", 4523, "!NEW! Aurin Roof (Large, Red)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_A.m3", 4524, "!NEW! Aurin Roof (Small, Pink)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_B.m3", 4525, "!NEW! Aurin Roof (Small, Blue)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_C.m3", 4526, "!NEW! Aurin Roof (Small, Violet)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianMedium_A.m3", 4527, "!NEW! Cassian Roof (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianMedium_B.m3", 4528, "!NEW! Cassian Roof (Large, Curvy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianSmall_A.m3", 4529, "!NEW! Cassian Roof (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianSmall_B.m3", 4530, "!NEW! Cassian Roof (Small, Shingled)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_A.m3", 4531, "!NEW! Chua Roof Cap (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_B.m3", 4532, "!NEW! Chua Roof Cap (Large, Elaborate)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_C.m3", 4533, "!NEW! Chua Roof Cap (Large, Industrial)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_A.m3", 4534, "!NEW! Chua Roof Cap (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_B.m3", 4535, "!NEW! Chua Roof Cap (Small, Smoking)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_C.m3", 4536, "!NEW! Chua Roof Cap (Small, Industrial)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Medium_A.m3", 4537, "!NEW! Draken Roof (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Medium_B.m3", 4538, "!NEW! Draken Roof (Large, Imposing)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Small_A.m3", 4539, "!NEW! Draken Roof (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Small_B.m3", 4540, "!NEW! Draken Roof (Small, Imposing)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileMedium_A.m3", 4541, "!NEW! Exile Roof (Large, Veranda)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileMedium_B.m3", 4542, "!NEW! Exile Roof (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileSmall_A.m3", 4543, "!NEW! Exile Roof (Small, Rounded)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileSmall_B.m3", 4544, "!NEW! Exile Roof (Small, ", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_A.m3", 4545, "!NEW! Bird House (Hoogle)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_B.m3", 4546, "!NEW! Bird House (Leafy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_C.m3", 4547, "!NEW! Bird House (Bearded Hoogle)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokMedium_A.m3", 4548, "!NEW! Granok Roof (Double, Pipes)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokMedium_B.m3", 4549, "!NEW! Granok Roof (Double, Shingles)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_A.m3", 4550, "!NEW! Granok Roof (Small, Boulder)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_B.m3", 4551, "!NEW! Granok Roof (Small, Slanted)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_C.m3", 4552, "!NEW! Granok Roof (Small, Shingled)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_A.m3", 4553, "!NEW! Osun Pinnacle (Statues)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_B.m3", 4554, "!NEW! Osun Pinnacle (Pointy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_C.m3", 4555, "!NEW! Osun Pinnacle (Sword)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_A.m3", 4556, "!NEW! Wooden Ramp (Natural, Wide)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_B.m3", 4557, "!NEW! Aurin Stairs (Short)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_C.m3", 4558, "!NEW! Aurin Ramp", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_D.m3", 4559, "!NEW! Aurin Stairs (Short, Ornate)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_A.m3", 4560, "!NEW! Wooden Ramp (Natural, Long)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_B.m3", 4561, "!NEW! Aurin Stairs (Long)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_C.m3", 4562, "!NEW! Aurin Ramp (Wide)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_D.m3", 4563, "!NEW! Aurin Stairs (Long, Ornate)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_A.m3", 4564, "!NEW! Cassian Stone Stairs (Pointy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_C.m3", 4565, "!NEW! Cassian Entry (Large, Gated)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_ClosedBack_B.m3", 4566, "!NEW! Cassian Entry (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_A.m3", 4567, "!NEW! Cassian Stone Stairs (Round)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_C.m3", 4568, "!NEW! Cassian Entry (Small, Gated)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_ClosedBack_B.m3", 4569, "!NEW! Cassian Entry (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_A.m3", 4570, "!NEW! Metal Stairs (Chua)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_B.m3", 4571, "!NEW! Metal Stairs (Chua, Tanks)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_C.m3", 4572, "!NEW! Metal Stairs (Chua, Industrial)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_A.m3", 4573, "!NEW! Draken Entry (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_B.m3", 4574, "!NEW! Draken Entry (Large, Chains)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_C.m3", 4575, "!NEW! Draken Entry (Large, Mouth)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_A.m3", 4576, "!NEW! Draken Entry (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_B.m3", 4577, "!NEW! Draken Entry (Small, Chains)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_c.m3", 4578, "!NEW! Draken Entry (Small, Mouth)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_A.m3", 4579, "!NEW! Exile Entry Stairs (Small, Simple)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_B.m3", 4580, "!NEW! Exile Entry Stairs (Small, Sheltered)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_C.m3", 4581, "!NEW! Exile Entry Stairs (Small, Wooden)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_A.m3", 4582, "!NEW! Exile Entry Stairs (Large, Pillars)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_B.m3", 4583, "!NEW! Exile Entry Stairs (Large, Simple)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_C.m3", 4584, "!NEW! Exile Entry Stairs (Large, Wooden)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_A.m3", 4585, "!NEW! Bird House Platform", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_B.m3", 4586, "!NEW! Bird House Platform (Fancy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_C.m3", 4587, "!NEW! Bird House Platform (Gnarly)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_B_Clean.m3", 4588, "!NEW! Granok Entry (Large, Stone Awning)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_C_clean.m3", 4589, "!NEW! Granok Entry (Large, Round Stairs)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Space\\PRP_Entry_Space_Small_A.m3", 4590, "!NEW! Twisting Bridge", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Aurin\\PRP_Door_Aurin_A.m3", 4591, "!NEW! Aurin Door (Glowing)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Aurin\\PRP_Door_Aurin_C.m3", 4592, "!NEW! Aurin Door (Red)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Cassian\\PRP_Door_CassianMedium_A.m3", 4593, "!NEW! Cassian Door (Reinforced)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Cassian\\PRP_Door_CassianSmall_c.m3", 4594, "!NEW! Cassian Door (Luminai)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Chua\\PRP_Door_Chua_A.m3", 4595, "!NEW! Chua Door", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Chua\\PRP_Door_Chua_B.m3", 4596, "!NEW! Chua Door (Window)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Chua\\PRP_Door_Chua_C.m3", 4597, "!NEW! Chua Door (Spiral)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Draken\\PRP_Door_Draken_Medium_A.m3", 4598, "!NEW! Curtains (Draken)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Draken\\PRP_Door_Draken_Small_A.m3", 4599, "!NEW! Draken Door (Glowing)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Draken\\PRP_Door_Draken_Small_B.m3", 4600, "!NEW! Draken Door (Double)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Draken\\PRP_Door_Draken_Small_C.m3", 4601, "!NEW! Mouth Door", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_Bird_A.m3", 4602, "!NEW! Bird House Door (Overgrown)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_Bird_B.m3", 4603, "!NEW! Bird House Door (Wooden)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_Bird_C.m3", 4604, "!NEW! Bird House Door (Stone)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_BlackHole_A.m3", 4605, "!NEW! Black Hole", DecorCategory.Special, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_Hatch_A.m3", 4606, "!NEW! Bunker Hatch", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Granok\\PRP_Door_Granok_A.m3", 4607, "!NEW! Granok Door", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Granok\\PRP_Door_Granok_B.m3", 4608, "!NEW! Granok Door (Round)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Osun\\PRP_Door_Osun_A.m3", 4609, "!NEW! Osun Door (Reinforced)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Osun\\PRP_Door_Osun_B.m3", 4610, "!NEW! Osun Door (Ornate)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Osun\\PRP_Door_Osun_C.m3", 4611, "!NEW! Osun Door (Face)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_005.m3", 4612, "!NEW! Rock Pillar (Tapered)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_000.m3", 4613, "!NEW! Crystal Formation (Green, Snowy)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_001.m3", 4614, "!NEW! Crystal Formation (Green,Floating)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_002.m3", 4615, "!NEW! Crystal Formation (Green)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_003.m3", 4616, "!NEW! Crystal Chunk (Green)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_004.m3", 4617, "!NEW! Floating Crystal Fragments", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Orange_002.m3", 4618, "!NEW! Crystal Cluster (Blue)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Orange_003.m3", 4619, "!NEW! Crystal Chunk (Blue)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_RED_000.m3", 4620, "!NEW! Floating Crystals (Red)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_001.m3", 4621, "!NEW! Blue Crystal (Blunt)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_002.m3", 4622, "!NEW! Blue Crystal (Pointy)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_RED_001.m3", 4623, "!NEW! Orange Crystal (Blunt)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeraduneCanopy\\PRP_Roots_DeraduneCanopy_Leaf_000.m3", 4624, "!NEW! Big Leaf", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Canopy_Dead_RootyMangrove_Brown_000.m3", 4625, "!NEW! Mangrove Canopy (Yellow)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangroveFallen_Brown_001.m3", 4626, "!NEW! Mangrove Tree (Yellow, Fallen)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_001.m3", 4627, "!NEW! Mangrove Tree (Brown, Lanky)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_002.m3", 4628, "!NEW! Mangrove Tree (Brown)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_003.m3", 4629, "!NEW! Mangrove Tree (Brown, Closed)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_000.m3", 4630, "!NEW! Obsidian Rock Stack", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_001.m3", 4631, "!NEW! Obsidian Rock Pillar", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_004.m3", 4632, "!NEW! Obsidian Rock Block", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_005.m3", 4633, "!NEW! Obsidian Rock Wall", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_007.m3", 4634, "!NEW! Obsidian Rock Pedestal", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_008.m3", 4635, "!NEW! Obsidian Rock Slope", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyerBot_Head.m3", 4636, "!NEW! Annihilator Head", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_JetPack.m3", 4637, "!NEW! Annihilator Jetpack", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Left_Arm.m3", 4638, "!NEW! Annihilator Arm (Left)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Left_Leg.m3", 4639, "!NEW! Annihilator Leg (Left))", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Right_Arm.m3", 4640, "!NEW! Annihilator Arm (Right)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Right_Leg.m3", 4641, "!NEW! Annihilator Leg (Right)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Torso_001.m3", 4642, "!NEW! Annihilator Torso", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Waist.m3", 4643, "!NEW! Annihilator Waist", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\WorldDestroyer_CrimsonIsle_Destroyed.m3", 4644, "!NEW! Annihilator (Destroyed)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_B_Clean.m3", 4645, "!NEW! Granok Entry (Small, Wooden Awning)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_A_Clean.m3", 4646, "!NEW! Granok Entry (Large, Stone Pillars)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_000.m3", 4647, "!NEW! Elderoot Tree", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeraduneCanopy\\PRP_Roots_DeraduneCanopy_BlueBall_000.m3", 4648, "!NEW! Blue Bulb Growth (Style 1)", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\Arch_Fat_Round\\PRP_Roots_ArchfatRound_Augmented_000.m3", 4649, "!NEW! Arching Root (Augmented)", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\Arch_Fat_Round\\PRP_Roots_ArchfatRound_GreenMossy_000.m3", 4650, "!NEW! Arching Root", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\Arch_Fat_Round\\PRP_Roots_ArchfatRound_Stairs_GreenMossy_000.m3", 4651, "!NEW! Aurin Mound Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Generic\\PRP_Platform_Generic_Pallet_Metal_000.m3", 4652, "!NEW! Metall Pallet", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Generic\\PRP_Platform_Generic_Pallet_Metal_001.m3", 4653, "!NEW! Metall Pallet (Plain)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platform_Eldan_Datascape_Airboss_000.m3", 4654, "!NEW! Massive Floating Platform (Eldan)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platform_Eldan_RobotSilo_000.m3", 4655, "!NEW! Platform (Eldan)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platform_Eldan_RobotSilo_Technophage_000.m3", 4656, "!NEW! Platform_RobotSilo_Phage", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platform_Eldan_RuinedEdge_000.m3", 4657, "!NEW! Ruined Eldan Tech Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platforms_Eldan_Archon_Computer_000.m3", 4658, "!NEW! Eldan Supercomputer", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Granok\\PRP_Platfrom_LandingPad_Granok_000.m3", 4659, "!NEW! Landing Pad (Granok)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Osun\\PRP_Platform_Osun_BasePlatform_Round_001.m3", 4660, "!NEW! Osun Platform (Small)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Osun\\PRP_Platform_Osun_PlatformLarge_000.m3", 4661, "!NEW! Osun Tech Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Osun\\PRP_Platform_Osun_Platform_Wolfhead_Stairs_001.m3", 4662, "!NEW! Osun Wolfhead Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_CryoChamberRevivalPlatformArm_000.m3", 4663, "!NEW! Cryochamber Arm (Grasping)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_CryoChamberRevivalPlatformArm_Custom_000.m3", 4664, "!NEW! Cryochamber Arm (Magnetic)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Lantern\\Lopp\\PRP_Lantern_StringPostVarious_PostOnly_000.m3", 4665, "!NEW! Long Wooden Stick", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Lantern\\Drakken\\PRP_Lantern_Drakken_000.m3", 4666, "!NEW! Brazier (Draken)", DecorCategory.Lighting, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Cup\\Chua\\PRP_Chua_Cup_002.m3", 4667, "!NEW! Chua Cup (Lid)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachBalls\\PRP_PartyGraw_BeachBall_000.m3", 4668, "!NEW! Beach Ball (Pentacolor)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachBalls\\PRP_PartyGraw_BeachBall_001.m3", 4669, "!NEW! Beach Ball (Hexacolor)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachBalls\\PRP_PartyGraw_BeachBall_002.m3", 4670, "!NEW! Beach Ball (Quadcolor)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachBalls\\PRP_PartyGraw_BeachBall_003.m3", 4671, "!NEW! Beach Ball (Pink)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachChairs\\PRP_PartyGraw_BeachChair_001.m3", 4672, "!NEW! Beach Chair", DecorCategory.Seating, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachUmbrella\\PRP_PartyGraw_BeachUmbrella_000.m3", 4673, "!NEW! Beach Parasol (Decorated)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachUmbrella\\PRP_PartyGraw_BeachUmbrella_001.m3", 4674, "!NEW! Beach Parasol", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachUmbrella\\PRP_PartyGraw_BeachUmbrella_002.m3", 4675, "!NEW! Beach Parasol (Closed)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Beer\\PRP_PartyGraw_Beer_000.m3", 4676, "!NEW! Beer Bottle (Vind)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Beer\\PRP_PartyGraw_Beer_001.m3", 4677, "!NEW! Beer Can (Vind)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BirdPerches\\PRP_PartyGraw_BirdPerch_000.m3", 4678, "!NEW! Tribal Bird Perch", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BirdPerches\\PRP_PartyGraw_BirdPerch_001.m3", 4679, "!NEW! Bird Perch (Hanging)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BirdPerches\\PRP_PartyGraw_BirdPerch_002.m3", 4680, "!NEW! Skull stick", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Cooler\\PRP_PartyGraw_Cooler_000.m3", 4681, "!NEW! Party Cooler", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\DJ\\PRP_PartyGraw_DJ_BoomBox_000.m3", 4682, "!NEW! Boombox", DecorCategory.Audio, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\DJ\\PRP_PartyGraw_DJ_DiscoBall_001.m3", 4683, "!NEW! Floating Discoball", DecorCategory.Electronics, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Drum\\PRP_Drum_Tribal_001.m3", 4684, "!NEW! Tribal Drum (Stocky)", DecorCategory.StatuesSculptures, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Fancy_Drinks\\PRP_PartyGraw_FancyDrink_000.m3", 4685, "!NEW! Tiki Mask Drink", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Fancy_Drinks\\PRP_PartyGraw_FancyDrink_001.m3", 4686, "!NEW! Tiki Skull Drink (Green)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Fancy_Drinks\\PRP_PartyGraw_FancyDrink_002.m3", 4687, "!NEW! Tiki Skull Drink (Red)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\FishNets\\PRP_Holiday_PartyGraw_FishNet_000.m3", 4688, "!NEW! Fishing Net (Messy)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\FishNets\\PRP_Holiday_PartyGraw_FishNet_001.m3", 4689, "!NEW! Fishing Net (Damaged)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\FishNets\\PRP_Holiday_PartyGraw_FishNet_002.m3", 4690, "!NEW! Fishing Net (Untidy)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\FishNets\\PRP_Holiday_PartyGraw_FishNet_003.m3", 4691, "!NEW! Fishing Net (Plain)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\HangingDecor\\PRP_Holiday_PartyGraw_HangingDecor_Flower_000.m3", 4692, "!NEW! String Flowers", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\HangingDecor\\PRP_Holiday_PartyGraw_HangingDecor_Flower_001.m3", 4693, "!NEW! String Flowers (Long)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\HangingDecor\\PRP_Holiday_PartyGraw_HangingDecor_Flower_002.m3", 4694, "!NEW! String Flowers (Short)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\HangingDecor\\PRP_Holiday_PartyGraw_HangingDecor_Flower_Posts_000.m3", 4695, "!NEW! String Flowers (Posts)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_New_000.m3", 4696, "!NEW! Pool Ring (Blue)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_New_001.m3", 4697, "!NEW! Pool Ring (Green)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_New_002.m3", 4698, "!NEW! Pool Ring (Pink)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_Vind_000.m3", 4699, "!NEW! Pool Ring (Vind, Tan)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_Vind_001.m3", 4700, "!NEW! Pool Ring (Vind, Brown)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\NeonSign\\PRP_PartyGraw_NeonSign_Body_000.m3", 4701, "!NEW! Neon Sign (Studrock, Beach)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\NeonSign\\PRP_PartyGraw_NeonSign_Head_000.m3", 4702, "!NEW! Neon Sign (Studrock, Head)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Plant\\PRP_PartyGraw_Plant_000.m3", 4703, "!NEW! Potted Tropical Plants (Tall)", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Plant\\PRP_PartyGraw_Plant_001.m3", 4704, "!NEW! Potted Tropical Plants (Short)", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_000.m3", 4705, "!NEW! Scorecard (00)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_001.m3", 4706, "!NEW! Scorecard (01)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_002.m3", 4707, "!NEW! Scorecard (02)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_003.m3", 4708, "!NEW! Scorecard (03)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_004.m3", 4709, "!NEW! Scorecard (04)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_005.m3", 4710, "!NEW! Scorecard (05)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_006.m3", 4711, "!NEW! Scorecard (06)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_007.m3", 4712, "!NEW! Scorecard (07)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_008.m3", 4713, "!NEW! Scorecard (08)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_009.m3", 4714, "!NEW! Scorecard (09)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_010.m3", 4715, "!NEW! Scorecard (10)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_011.m3", 4716, "!NEW! Scorecard (11)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_000.m3", 4717, "!NEW! Folded Beach Towel (Striped, Red)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_001.m3", 4718, "!NEW! Folded Beach Towel (Striped, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_002.m3", 4719, "!NEW! Folded Beach Towel (Striped, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_003.m3", 4720, "!NEW! Folded Beach Towel (Ornate, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_004.m3", 4721, "!NEW! Folded Beach Towel (Fancy, Magenta)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_005.m3", 4722, "!NEW! Folded Beach Towel (Ornate, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_006.m3", 4723, "!NEW! Folded Beach Towel (Fancy, Green)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_000.m3", 4724, "!NEW! Rolled Beach Towel (Striped, Red)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_001.m3", 4725, "!NEW! Rolled Beach Towel (Striped, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_002.m3", 4726, "!NEW! Rolled Beach Towel (Striped, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_003.m3", 4727, "!NEW! Rolled Beach Towel (Ornate, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_004.m3", 4728, "!NEW! Rolled Beach Towel (Fancy, Magenta)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_005.m3", 4729, "!NEW! Rolled Beach Towel (Ornate, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_006.m3", 4730, "!NEW! Rolled Beach Towel (Fancy, Green)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_000.m3", 4731, "!NEW! Beach Towel (Striped, Red)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_001.m3", 4732, "!NEW! Beach Towel (Striped, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_002.m3", 4733, "!NEW! Beach Towel (Striped, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_003.m3", 4734, "!NEW! Beach Towel (Ornate, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_004.m3", 4735, "!NEW! Beach Towel (Fancy, Magenta)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_005.m3", 4736, "!NEW! Beach Towel (Ornate, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_006.m3", 4737, "!NEW! Beach Towel (Fancy, Green)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\BuildingMaterials\\PRP_BuildingMaterials_Wood_000.m3", 4738, "!NEW! Pile of Planks", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Explorer\\PRP_PlayerPaths_Explorer_RadarDish_000.m3", 4739, "!NEW! Radar Dish (Standing)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Radar\\PRP_DefianceRadardish_000.m3", 4740, "!NEW! Radar Dish (Exile)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Radar\\PRP_DefianceShieldGenerator_000.m3", 4741, "!NEW! Exile Shield Generator", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Protostar\\PRP_Walls_Protostar_000.m3", 4742, "!NEW! Protostar Wall", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Protostar\\PRP_Walls_Protostar_Corner_120_000.m3", 4743, "!NEW! Protostar Wall Corner (Sharp)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Protostar\\PRP_Walls_Protostar_Corner_90_000.m3", 4744, "!NEW! Protostar Wall Corner (Rounded)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\PRP_Brace_RetainingWallPiston_000.m3", 4745, "!NEW! Retaining Piston (Fortified)", DecorCategory.Fencing, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\PRP_Brace_RetainingWallPiston_001.m3", 4746, "!NEW! Retaining Piston (Braced)", DecorCategory.Fencing, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\PRP_Brace_RetainingWallScrew_000.m3", 4747, "!NEW! Retaining Screw", DecorCategory.Fencing, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\WantedPost\\PRP_WantedPoster_000.m3", 4748, "!NEW! Wanted Posted (Bearded Chap)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\WantedPost\\PRP_WantedPoster_001.m3", 4749, "!NEW! Wanted Posted (Old Man)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\WantedPost\\PRP_WantedPoster_002.m3", 4750, "!NEW! Wanted Posted (Young Ruffian)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\WantedPost\\PRP_WantedPoster_003.m3", 4751, "!NEW! Wanted Posted (Rough Fellow)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Defiance\\PRP_PictureFrame_DefiancePoster_001.m3", 4752, "!NEW! Exile Recruitment Poster", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_HoloBase_Imperium_001.m3", 4753, "!NEW! Holographic Projector (Luminai)", DecorCategory.Electronics, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_001.m3", 4754, "!NEW! Stained Glass Hologram (Justice)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_002.m3", 4755, "!NEW! Stained Glass Hologram (Devotion)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_003.m3", 4756, "!NEW! Stained Glass Hologram (Strength)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_004.m3", 4757, "!NEW! Stained Glass Hologram (Courage)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_005.m3", 4758, "!NEW! Stained Glass Hologram (Purity)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_006.m3", 4759, "!NEW! Stained Glass Hologram (Knowledge)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_ImperiumPoster_006.m3", 4760, "!NEW! Propaganda Poster (Mechari)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Imperium_Glow_000.m3", 4761, "!NEW! Glowing Portal", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\PRP_PictureFrame_Blank_000.m3", 4762, "!NEW! Empty Picture Frame (Wide)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\PRP_PictureFrame_Blank_001.m3", 4763, "!NEW! Empty Picture Frame (Wide, Cassian)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\PRP_PictureFrame_Blank_002.m3", 4764, "!NEW! Empty Picture Frame (Tall, Cassian)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\PRP_PictureFrame_Blank_003.m3", 4765, "!NEW! Empty Picture Frame (Tall)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarContractBoard_000.m3", 4766, "!NEW! Protostar Contract Board", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarHorizontal_000.m3", 4767, "!NEW! Protostar Billboard (Wide)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarHorizontal_002.m3", 4768, "!NEW! Warning Sign (Protostar, Tall)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarRound_000.m3", 4769, "!NEW! Protostar Emblem", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarVertical_000.m3", 4770, "!NEW! Protostar Billboard (Tall, Corporaxian)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarVertical_001.m3", 4771, "!NEW! Protostar Billboard (Tall, Loftite)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarVertical_002.m3", 4772, "!NEW! Protostar Billboard (Tall, Real Estate)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Aurin\\PRP_SignPost_AurinCurledHanging_002.m3", 4773, "!NEW! Aurin Signpost", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Chua\\PRP_Sign_Chua_ArrowGuideSign_001.m3", 4774, "!NEW! Arrow Guide (Chua)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Chua\\PRP_Sign_Chua_Signpost_000.m3", 4775, "!NEW! Signpost (Chua)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Defiance\\PRP_Defiance_Sign_004.m3", 4776, "!NEW! Signpost (Exile)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Defiance\\PRP_Defiance_Sign_Arrow_000.m3", 4777, "!NEW! Arrow Guide (Exile)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Drakken\\PRP_SignPost_Drakken_000.m3", 4778, "!NEW! Ornate Post (Draken)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Eldan\\PRP_Sign_Pod_Teleport_002.m3", 4779, "!NEW! Teleporter Sign (Eldan)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Generic\\NoticeBoard\\PRP_Sign_Generic_NoticeBoard_Dominion_000.m3", 4780, "!NEW! Notice Board (Dominion)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Generic\\PRP_Sign_Generic_Teleport_000.m3", 4781, "!NEW! Teleporter Sign", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_PinUp_RMC_000.m3", 4782, "!NEW! Pinup Poster (Draken Lady)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Mine\\PRP_Sign_Mine_000.m3", 4783, "!NEW! Mine Sign", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Murgh\\PRP_Sign_MurghCamp_001.m3", 4784, "!NEW! Suspended Cloth (Murgh)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Pell\\PRP_Sign_PellSignPost_000.m3", 4785, "!NEW! Banner (Pell)", DecorCategory.BannersFlags, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Pell\\PRP_Sign_PellSign_001.m3", 4786, "!NEW! Hanging Sign (Pell)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Pell\\PRP_Sign_PellSign_DreamCatcher_001.m3", 4787, "!NEW! Hanging Disc (Pell)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_BlankSign_OldWooden_000.m3", 4788, "!NEW! Shabby Notice Board (Wooden)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_GalerasTempestRefuge_000.m3", 4789, "!NEW! Sign (Tempest Refuge)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_Generic_POI_000.m3", 4790, "!NEW! Signpost (Floating)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_Generic_POI_Arrow_000.m3", 4791, "!NEW! Directional Sign (Style 1)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_Generic_POI_Arrow_001.m3", 4792, "!NEW! Directional Sign (Style 2)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_Generic_POI_Arrow_002.m3", 4793, "!NEW! Directional Sign (Style 3)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_RockStackRope_Gray_000.m3", 4794, "!NEW! Signpost (Granok)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Buzzbing\\PRP_BuzzbingHive_Piping_Small_001.m3", 4795, "!NEW! Honey Tank", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipe_Cap_000.m3", 4796, "!NEW! Chua Pipe Cap", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_000.m3", 4797, "!NEW! Chua Pipe", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_001.m3", 4798, "!NEW! Chua Pipe (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_002.m3", 4799, "!NEW! Chua Pipe (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_003.m3", 4800, "!NEW! Chua Pipe (Intersection)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_004.m3", 4801, "!NEW! Chua Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_Stacker_000.m3", 4802, "!NEW! Chua Pipe Stacker", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Eldan\\PRP_Pipes_Eldan_000.m3", 4803, "!NEW! Eldan Pipe", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Eldan\\PRP_Pipes_Eldan_001.m3", 4804, "!NEW! Eldan Pipe (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Eldan\\PRP_Pipes_Eldan_002.m3", 4805, "!NEW! Eldan Pipe (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Eldan\\PRP_Pipes_Eldan_003.m3", 4806, "!NEW! Eldan Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_000.m3", 4807, "!NEW! Metal Pipe", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_001.m3", 4808, "!NEW! Metal Pipe (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_002.m3", 4809, "!NEW! Metal Pipe (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_004.m3", 4810, "!NEW! Metal Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_005.m3", 4811, "!NEW! Segmented Tube", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_006.m3", 4812, "!NEW! Segmented Tube (Short)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_007.m3", 4813, "!NEW! Metal Pipe ", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_008.m3", 4814, "!NEW! Metal Pipe ", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_009.m3", 4815, "!NEW! Metal Pipe ", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_010.m3", 4816, "!NEW! Metal Pipe ", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_011.m3", 4817, "!NEW! Segmented Tube (Bendy)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_012.m3", 4818, "!NEW! Segmented Tube (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_013.m3", 4819, "!NEW! Segmented Tube (Wavy)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_014.m3", 4820, "!NEW! Segmented Tube (Long, Bendy)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_015.m3", 4821, "!NEW! Segmented Tube (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_016.m3", 4822, "!NEW! Segmented Tube (Wavy, Large)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Pipes_000.m3", 4823, "!NEW! Lava Pipe ", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Pipes_001.m3", 4824, "!NEW! Lava Pipe (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Pipes_002.m3", 4825, "!NEW! Lava Pipe (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Pipes_004.m3", 4826, "!NEW! Lava Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Piping_Big_000.m3", 4827, "!NEW! Lava-Extraction Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Piping_Small_001.m3", 4828, "!NEW! Lava Tank", DecorCategory.BuildingBlocks, false, 5);
            AddGroundOption("The Floor Is Lava", 579, 580);
            AddGroundOption("Volcanic", 580, 579);
            AddGroundOption("Arcterra", 991, 1159);
            AddGroundOption("Ice Rubble", 1158, 458);
            AddGroundOption("Ice Drift", 1257, 1256);
            AddGroundOption("Desolation", 24, 260);
            AddGroundOption("Galeras Meadow", 757, 544);
            AddGroundOption("Paved", 1079, 1079);
            AddGroundOption("Runed Temple Floor", 249, 250);
            AddGroundOption("Overgrown Pavement", 1079, 422);
            AddGroundOption("Sleeping Volcano", 580, 422);
            AddGroundOption("Hot and Cold", 1257, 579);
            AddGroundOption("Crystal Field (Yellow in Grass)", 105, 893);
            AddGroundOption("Crystal Field (Blue in Dirt)", 894, 464);
            AddGroundOption("Halon Ring", 336, 1172);
            AddGroundOption("Tech", 299, 484);
            AddGroundOption("Eldan Hexagons", 608, 608);
            AddGroundOption("Eldan Hexagons (Corrupted)", 921, 921);
            AddGroundOption("Metal Hexagons", 953, 953);
            AddGroundOption("Scorched Rock", 580, 1250);
            AddEmote(7834, "lounge1", "lounge", 433);
            AddEmote(7835, "lounge2", null, 434);


            SaveTables("../../../../TblNormal/");

            // BETA YOLO MOOOODE
            betaMode = true;


            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_Combat.m3", null, "Directional Light (Stops at Gizmo)", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_002.m3", null, "Light_Spotlight_Generic_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_003.m3", null, "Light_Spotlight_Generic_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_GroundConstrain_000.m3", null, "Light_Spotlight_Generic_GroundConstrain", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_GroundConstrain_NoCylinder_000.m3", null, "Light_Spotlight_Generic_GroundConstrain2", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_HeadLight_Brighter_000.m3", null, "Spot Light (Volumetric, Bright, Flickering)", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\IGCinematic\\LIT_Point_Med_IGCSwitch.m3", null, "Light_Med_IGCSwitch", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\IGCinematic\\LIT_Point_Soft_Bright_IGCSwitch.m3", null, "Light_SoftBright_IGCSwitch", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\IGCinematic\\LIT_Spot_Soft_IGCSwitch.m3", null, "Light_Soft_IGCSwitch", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Light\\IGCinematic\\LIT_Spot_Soft_Wide_IGCSwitch.m3", null, "Light_Wide_IGCSwitch", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_000.m3", null, "TreeofLife_Root_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_001.m3", null, "TreeofLife_Root_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_002.m3", null, "TreeofLife_Root_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_003.m3", null, "TreeofLife_Root_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_004.m3", null, "TreeofLife_Root_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_005.m3", null, "TreeofLife_Root_005", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_006.m3", null, "TreeofLife_Root_006", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_007.m3", null, "TreeofLife_Root_007", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_008.m3", null, "TreeofLife_Root_008", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_009.m3", null, "TreeofLife_Root_009", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_002.m3", null, "Obsidian Rock (002)", DecorCategory.Rocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\Keepfish\\PRP_Water_Keepfish_000.m3", null, "Water_Keepfish", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_000.m3", null, "DeraduneLargeWaterfall_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_001.m3", null, "DeraduneLargeWaterfall_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_Mist_000.m3", null, "DeraduneLargeWaterfall_Mist", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneSmallWaterfall_000.m3", null, "DeraduneSmallWaterfall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_MistFX_000.m3", null, "MistFX_000", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_MistFX_001.m3", null, "MistFX_001", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_RippleFX_000.m3", null, "Water Ripples", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_SplashFX_000.m3", null, "SplashFX", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_000.m3", null, "Water_Wilderrun_LargeTiered_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_001.m3", null, "Water_Wilderrun_LargeTiered_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_002.m3", null, "Water_Wilderrun_LargeTiered_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_003.m3", null, "Water_Wilderrun_LargeTiered_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_004.m3", null, "Water_Wilderrun_LargeTiered_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_TempleFalls_000.m3", null, "Water_Wilderrun_TempleFalls_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_TempleFalls_Corrupted_000.m3", null, "Water_Wilderrun_TempleFalls_Corrupted", DecorCategory.Beta, false);
            AddGenericDecor("Art\\FX\\Echo\\Earth_BRN\\Earth_BRN.m3", null, "Echo_Earth", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Echo\\Fire_OGE\\Fire_1o5mPosY_OGE.m3", null, "Echo_Fire_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Echo\\Fire_OGE\\Fire_OGE.m3", null, "Echo_Fire_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Echo\\Shock_BLE\\Shock_BLE.m3", null, "Echo_Shock", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Echo\\Water_BLE\\Water_BLE.m3", null, "Echo_Water", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Fire_FireRain\\Fire_FireRain_10m.m3", null, "Caster_FireRain_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Fire_FireRain\\Fire_FireRain_SingleLarge.m3", null, "Caster_FireRain_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Fire_FireRain\\Fire_FireRain_noDecalnGrdFX_10m.m3", null, "Caster_FireRain_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Ice_Blizzard\\Ice_Blizzard_5m.m3", null, "Caster_Blizzard_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Ice_Blizzard\\Ice_Blizzard_Flurry_5m.m3", null, "Caster_Blizzard_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Fire_OGE\\Fire_NoDecal_OGE.m3", null, "Model_Fire_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Fire_OGE\\Fire_OGE.m3", null, "Model_Fire_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Fire_Trail\\Fire_Trail_Loop_OGE.m3", null, "Model_Fire_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Fire_Trail\\Fire_Trail_OGE.m3", null, "Model_Fire_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Test\\MMalley\\Test_Weapon_Orb_FireBall_Stationary.m3", null, "MMalley_Fireball", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Test\\SLee\\3D\\TS_Fire_Ground.m3", null, "Fire_Ground", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Action\\Fire_Flame_OGE\\Fire_Flame_OGE.m3", null, "Fire_FLame_OGE", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Molotov_Fire_ORA\\Molotov_Fire_ORA.m3", null, "Fire_Molotov", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Molotov_Fire_ORA\\Molotov_Fire_noDecal_ORA.m3", null, "Fire_Molotov_noDecal", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Probebot_Pell\\Probebot_Pell_LaserSweep_FireRing\\ProbeBot_Pell_LaserSweep_FireRing.m3", null, "Laser_FireRing", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Caster\\Fire_OrbitingFlames\\Fire_OrbitingFlames_OGE.m3", null, "Fire_Orbiting", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_BallDual_OGE\\Fire_BallDual_3FL_OGE.m3", null, "Fire_BallDual_3FL", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_BallDual_OGE\\Fire_BallDual_OGE.m3", null, "Fire_BallDual", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_BallQuad_OGE\\Fire_BallQuad_3FL_OGE.m3", null, "Fire_BallQuad_3FL", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_BallQuad_OGE\\Fire_BallQuad_OGE.m3", null, "Fire_BallQuad", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Ball\\Fire_Ball_GRN_12.m3", null, "Fire_Ball_GRN", DecorCategory.Beta, false);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Ball_OGE\\Fire_Ball_3FL_OGE_12.m3", null, "Fire_Ball_3FL", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Ball_OGE\\Fire_Ball_OGE_12.m3", null, "Fire_Ball", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Burn_OGE\\Fire_Burn_OGE.m3", null, "Fire_urn", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Flame_OGE\\Fire_Flame_OGE.m3", null, "(though the) Fire_Flame", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_OrbitingFlames\\Fire_OrbitingFlames_OGE.m3", null, "Caster_Fire_Orbiting", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Torso_002.m3", null, "Destroyer_Torso_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_B.m3", null, "Entry_Cassian_B", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_B.m3", null, "Entry_Cassian_Small_B", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_A_Clean.m3", null, "Granok Entry (Small, Round Stairs)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_C_Clean.m3", null, "Granok Entry (Small, Pillars)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_D_Clean.m3", null, "Granok Entry (Small, Stone Awning)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_A.m3", null, "Entry_Osun_A", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_B.m3", null, "Entry_Osun_B", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_C.m3", null, "Entry_Osun_C", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Cassian\\PRP_Door_CassianSmall_B.m3", null, "Door_Cassian_Small_B", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Exile\\PRP_Door_ExileSmall_A.m3", null, "Door_Exile_A", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Exile\\PRP_Door_ExileSmall_B.m3", null, "Door_Exile_B", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Exile\\PRP_Door_ExileSmall_C.m3", null, "Door_Exile_C", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Exile\\PRP_Door_ExileSmall_D.m3", null, "Door_Exile_D", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Exile\\PRP_Door_ExileSmall_E.m3", null, "Door_Exile_E", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Granok\\PRP_Door_Granok_C.m3", null, "Door_Granok_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_004.m3", null, "MoorRock_004", DecorCategory.Rocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_006.m3", null, "MoorRock_006", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_007.m3", null, "MoorRock_007", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_000.m3", null, "AlgorocMineCrystal_Blue_000", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_001.m3", null, "AlgorocMineCrystal_Blue_001", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_002.m3", null, "AlgorocMineCrystal_Blue_002", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_003.m3", null, "AlgorocMineCrystal_Blue_003", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_004.m3", null, "AlgorocMineCrystal_Blue_004", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_005.m3", null, "AlgorocMineCrystal_Blue_005", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_006.m3", null, "AlgorocMineCrystal_Blue_006", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystals_Blue_000.m3", null, "AlgorocMineCrystal_Blue_007", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystals_Blue_001.m3", null, "AlgorocMineCrystal_Blue_008", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_000.m3", null, "Exanite Wall Fragment ", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_001.m3", null, "Exanite Wall Fragment ", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_002.m3", null, "Exanite Wall Fragment ", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_003.m3", null, "Exanite Wall Fragment ", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_Tentacles_000.m3", null, "Wiggling Augmented Stump", DecorCategory.Trees, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_000.m3", null, "Exanite_Brokenwall_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_001.m3", null, "Exanite_Brokenwall_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_002.m3", null, "Exanite_Brokenwall_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_003.m3", null, "Exanite_Brokenwall_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_004.m3", null, "Exanite_Brokenwall_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_Exanite_TreeofLifeGateDestroyed_000.m3", null, "Overgrown Exanite Wall (Broken)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_Exanite_TreeofLifeGate_000.m3", null, "Overgrown Exanite Wall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_001.m3", null, "Exanite_Wall_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_002.m3", null, "Exanite_Wall_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_003.m3", null, "Exanite_Wall_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_004.m3", null, "Exanite_Wall_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_005.m3", null, "Exanite_Wall_005", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_006.m3", null, "Exanite_Wall_006", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_Illium_001.m3", null, "Exanite_Wall_Illium", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillarCap_Huge_000.m3", null, "ExanitePillarCap_Huge", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillarCap_Large_000.m3", null, "ExanitePillarCap_Large", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Large_000.m3", null, "ExanitePillar_Large", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Pillar_001.m3", null, "ExanitePillar_Pillar", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Platform_000.m3", null, "ExanitePillar_Platform", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_SmallFloating_000.m3", null, "ExanitePillar_SmallFloating", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Vents_000.m3", null, "RMT_Vents", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_Shower_Decals_Puddle_000.m3", null, "Shower_Decals_Puddle", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Hand_000.m3", null, "Shower_Decals_Hand_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Hand_001.m3", null, "Shower_Decals_Hand_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_LFoot_000.m3", null, "Shower_Decals_LFoot_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_LFoot_001.m3", null, "Shower_Decals_LFoot_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_RFoot_000.m3", null, "Shower_Decals_RFoot_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_RFoot_001.m3", null, "Shower_Decals_RFoot_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Smear_000.m3", null, "Shower_Decals_Smear", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Trail_000.m3", null, "Shower_Decals_Trail", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\AsteroidBelt\\PRP_RMT_AsteroidBelt_Arc_000.m3", null, "RMT_AsteroidBelt", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\SquidPlant\\PRP_RMT_Act2_SquidPlant_000.m3", null, "RMT_Squidplant", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_003.m3", null, "RMT_SewagePipes_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_004.m3", null, "RMT_SewagePipes_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_005.m3", null, "RMT_SewagePipes_005", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Compactor_Smasher_000.m3", null, "Compactor_Smasher", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_BossPlatform_Side_000.m3", null, "Engine_BossPlatform_Side", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_FlamePillar_000.m3", null, "Engine_FlamePillar", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Lavaka_Grill_000.m3", null, "Lavaka_Grill", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Lavaka_IncineratorPit_000.m3", null, "Lavaka_IncineratorPit", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_000.m3", null, "Liferoot (Curved)", DecorCategory.Trees, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_001.m3", null, "Liferoot (Split)", DecorCategory.Trees, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_002.m3", null, "Liferoot (Pointy)", DecorCategory.Trees, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_003.m3", null, "Liferoot (Forked)", DecorCategory.Trees, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_004.m3", null, "Liferoot (Gnarly)", DecorCategory.Trees, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_000.m3", null, "DeadBranch_GreenBrown_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_001.m3", null, "DeadBranch_GreenBrown_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_002.m3", null, "DeadBranch_GreenBrown_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_003.m3", null, "DeadBranch_GreenBrown_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_004.m3", null, "DeadBranch_GreenBrown_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeraduneCanopy\\PRP_Roots_DeraduneCanopy_BlueBall_001.m3", null, "Blue Bulb Growth (Style 2)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeraduneCanopy\\PRP_Roots_DeraduneCanopy_BlueBall_002.m3", null, "Blue Bulb Growth (Style 3)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Logicleaf\\PRP_Tradeskill_Plant_Logicleaf_000.m3", null, "Tradeskill_Logicleaf", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Exanite\\MiningNode_Exanite_000.m3", null, "MiningNode_Exanite", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Exanite\\PRP_Tradeskill_MiningNode_Exanite_000.m3", null, "PRP_MiningNode_Exanite", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Hydrogem\\MiningNode_Hydrogem.m3", null, "MiningNode_Hydrogem", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Hydrogem\\PRP_Tradeskill_MiningNode_Hydrogem_000.m3", null, "PRP_MiningNode_Hydrogem", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Iron\\MiningNode_Iron.m3", null, "Miningnode_Iron", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Iron\\PRP_Tradeskill_MiningNode_Iron_000.m3", null, "PRP_MiningNode_Iron", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Novanium\\MiningNode_Novanium.m3", null, "MiningNode_Novanium", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Novanium\\PRP_Tradeskill_MiningNode_Novanium_000.m3", null, "PRP_MiningNode_Novanium", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Platinum\\MiningNode_Platinum.m3", null, "MiningNode_Platinum", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Platinum\\PRP_Tradeskill_MiningNode_Platinum_000.m3", null, "PRP_MiningNode_Platinum", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Shadeslate\\MiningNode_Shadeslate.m3", null, "MiningNode_Shadeslate", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Shadeslate\\PRP_Tradeskill_MiningNode_Shadeslate_000.m3", null, "PRP_MiningNode_Shadeslate", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Titanium\\MiningNode_Titanium.m3", null, "MiningNode_Titanium", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Titanium\\PRP_Tradeskill_MiningNode_Titanium_000.m3", null, "PRP_MiningNode_Titanium", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Xenocite\\MiningNode_Xenocite.m3", null, "MiningNode_Xenocite", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Xenocite\\PRP_Tradeskill_MiningNode_Xenocite_000.m3", null, "PRP_MiningNode_Xenocite", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Zephyrite\\MiningNode_Zephyrite.m3", null, "MiningNode_Zephyrite", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\MiningNode\\Zephyrite\\PRP_Tradeskill_MiningNode_Zephyrite_000.m3", null, "PRP_MiningNode_Zephyrite", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Growthshroom_GRN_000.m3", null, "Growthshroom_GRN_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Growthshroom_GRN_001.m3", null, "Growthshroom_GRN_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Growthshroom_GRN_002.m3", null, "Growthshroom_GRN_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Harvestshroom_RED_000.m3", null, "Growthshroom_RED_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Harvestshroom_RED_001.m3", null, "Growthshroom_RED_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Harvestshroom_RED_002.m3", null, "Growthshroom_RED_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Renewshroom_BLU_000.m3", null, "Growthshroom_BLU_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Renewshroom_BLU_001.m3", null, "Growthshroom_BLU_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Renewshroom_BLU_002.m3", null, "Growthshroom_BLU_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Bladeleaf\\PRP_Tradeskill_Plant_Bladeleaf_000.m3", null, "Tradeskill_Plant_Bladeleaf", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\BloodBriar\\PRP_Tradeskill_Plant_BloodBriar_000.m3", null, "Tradeskill_Plant_BloodBriar", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Candleflower\\PRP_Tradeskill_Plant_Candleflower_000.m3", null, "Tradeskill_Plant_CandleFlower", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Clawblossom\\PRP_Tradeskill_Plant_Clowblossom_000.m3", null, "Tradeskill_Plant_Clowblossom", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Coralscale\\PRP_Tradeskill_Plant_Coralscale_000.m3", null, "Tradeskill_Plant_Coralscale", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Crowncorn\\PRP_Tradeskill_Plant_Crowncorn_000.m3", null, "Tradeskill_Plant_Crowncorn", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Devilspine\\PRP_Tradeskill_Plant_Devilspine_000.m3", null, "Tradeskill_Plant_Devilspine", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Faerybloom\\PRP_Tradeskill_Plant_Faerybloom_000.m3", null, "Tradeskill_Plant_Faerybloom", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Fiberstalk\\PRP_Tradeskill_Plant_Fiberstalk_000.m3", null, "Tradeskill_Plant_Fiberstalk", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Flamefrond\\PRP_Tradeskill_Plant_Flamefrond_000.m3", null, "Tradeskill_Plant_Flamefrond", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Glowmelon\\PRP_Tradeskill_Plant_Glowmelon_000.m3", null, "Tradeskill_Plant_Glowmelon", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Goldleaf\\PRP_Tradeskill_Plant_Goldleaf_000.m3", null, "Tradeskill_Plant_Goldleaf", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Grimgourd\\PRP_Tradeskill_Plant_Grimgourd_000.m3", null, "Tradeskill_Plant_Grimgourd", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Gunberry\\PRP_Tradeskill_Plant_Gunberry_000.m3", null, "Tradeskill_Plant_Gunberry", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Heartichoke\\PRP_Tradeskill_Plant_Heartichoke_000.m3", null, "Tradeskill_Plant_Heartichoke", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Honeywheat\\PRP_Tradeskill_Plant_Honeywheat_000.m3", null, "Tradeskill_Plant_Honeywheat", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Logicleaf\\PRP_Tradeskill_Plant_Logicleaf_000.m3", null, "Tradeskill_Plant_Logicleaf", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Mourningstar\\PRP_Tradeskill_Plant_Mourningstar_000.m3", null, "Tradeskill_Plant_Mourningstar", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Octopod\\PRP_Tradeskill_Plant_Octopod_000.m3", null, "Tradeskill_Plant_Octopod", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Pummelgranate\\PRP_Tradeskill_Plant_Pummelgranate_000.m3", null, "Tradeskill_Plant_Pummelgrenate", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Scorchweed\\PRP_Tradeskill_Plant_Scorchweed_000.m3", null, "Tradeskill_Plant_Scorchweed", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Serpentlily\\PRP_Tradeskill_Plant_Serpentlily_000.m3", null, "Tradeskill_Plant_Serpentlily", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Spikepetal\\PRP_Tradeskill_Plant_Spikepetal_000.m3", null, "Tradeskill_Plant_Spikepetal", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Spirovine\\PRP_Tradeskill_Plant_Spirovine_000.m3", null, "Tradeskill_Plant_Spirovine", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Stoutroot\\PRP_Tradeskill_Plant_Stoutroot_000.m3", null, "Tradeskill_Plant_Stoutroot", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Witherwood\\PRP_Tradeskill_Plant_Witherwood_000.m3", null, "Tradeskill_Plant_Witherwood", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Yellowbell\\PRP_Tradeskill_Plant_Yellowbell_000.m3", null, "Tradeskill_Plant_Yellowbell", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Auroria\\PRP_Tradeskill_Tree_Auroria_000.m3", null, "Tradeskill_Tree_Auroria", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\BulbyThickDecidious\\PRP_Tradeskill_Tree_BulbyThickDecidious_000.m3", null, "Tradeskill_Tree_BulbyThickDecidious", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\CelestionTreeNode\\PRP_Tree_CelestionTreeNode_Pale_000.m3", null, "Tradeskill_Tree_CelestionTree", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Coralus\\PRP_Tradeskill_Tree_Coralus_000.m3", null, "Tradeskill_Tree_Coralus", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Dreadmoore\\PRP_Tradeskill_Tree_Dreadmoore_000.m3", null, "Tradeskill_Tree_Dreadmoore", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Ellevar\\PRP_Tradeskill_Tree_Ellevar_000.m3", null, "Tradeskill_Tree_Ellevar", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Farside\\PRP_Tradeskill_Tree_Farside_000.m3", null, "Tradeskill_Tree_Farside", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Galeras\\PRP_Tradeskill_Tree_Galeras_000.m3", null, "Tradeskill_Tree_Galeras", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\HalonRing\\PRP_Tradeskill_Tree_HalonRing_000.m3", null, "Tradeskill_Tree_Halonring", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Invisible_Dead_Tree\\Invisible_Dead_Tree.m3", null, "Tradeskill_Tree_DeadTree", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Isigrol\\PRP_Tradeskill_Tree_Isigrol_000.m3", null, "Tradeskill_Tree_Isigrol", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Malgrave\\PRP_Tradeskill_Tree_Malgrave_000.m3", null, "Tradeskill_Tree_Malgrave", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Murkmire\\PRP_Tradeskill_Tree_Murkmire_000.m3", null, "Tradeskill_Tree_Murkmire", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\PointyPineThick\\PRP_Tradeskill_Tree_PointyPineTallThin_000.m3", null, "Tradeskill_Tree_PineThin", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\PointyPineThick\\PRP_Tradeskill_Tree_PointyPineThick_000.m3", null, "Tradeskill_Tree_PineThick", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Whitevale\\PRP_Tradeskill_Tree_Whitevale_000.m3", null, "Tradeskill_Tree_Whitevale", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Wilderrun\\PRP_Tradeskill_Tree_Wilderrun_000.m3", null, "Tradeskill_Tree_Wilderrun", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Aurin\\PRP_Platforms_AurinShopTeleport_001.m3", null, "AurinShopTeleport", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Aurin\\PRP_Platforms_AurinShopTeleport_NoRail_000.m3", null, "AurinShopTeleport_NoRail", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Aurin\\PRP_Platforms_AurinSmallFloating_000.m3", null, "AurinSmallFloating", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Aurin\\PRP_Platforms_AurinSmallFloating_NoRail_000.m3", null, "AurinSmallFloating_NoRail", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Chua\\PRP_Platfrom_LandingPad_Chua_001.m3", null, "LandingPad_Chua", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Defiance\\PRP_Platform_DefianceMilitary_001.m3", null, "Platform_DefianceMilitary", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Defiance\\PRP_Platfrom_LandingPad_Defiance_000.m3", null, "LandingPad_Defiance", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Drakken\\PRP_Platform_Drakken_CircularPlatform_000.m3", null, "Draken Platform", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Imperium\\PRP_Platform_ImperiumMilitary_001.m3", null, "Platform_ImperiumMilitary_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Imperium\\PRP_Platform_ImperiumMilitary_002.m3", null, "Platform_ImperiumMilitary_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Imperium\\PRP_Platform_ImperiumMilitary_003.m3", null, "Platform_ImperiumMilitary_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_CryoChamberRevivalPlatformArm_001.m3", null, "Platform_CryoChamberArm_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_CryoChamberRevivalPlatform_000.m3", null, "Cryochamber Platform", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Stormtalon_PellPlatformLargeBackingOnly_000.m3", null, "PellPlatForm_BackingOnly", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Stormtalon_PellPlatformLargeBaseOnly_000.m3", null, "PellPlatForm_BaseOnly", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Stormtalon_PellPlatformLarge_000.m3", null, "PellPlatForm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Protostar\\PRP_ProtostarElevatorBase_000.m3", null, "ProtostarElevator_Base", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Protostar\\PRP_ProtostarElevator_000.m3", null, "ProtostarElevator", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Protostar\\PRP_ProtostarPlatform_000.m3", null, "ProtostarPlatform", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Lantern\\Marauder\\PRP_RMC_Lantern_Fancy_001.m3", null, "Hanging Lamp (Fancy, Short)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\TotemBar\\PRP_PartyGraw_TotemBar_000.m3", null, "Tiki Bar", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\BossIndicator\\PRP_Walls_Generic_BossIndicator_Hexagon_000.m3", null, "Walls_BossIndicator_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\BossIndicator\\PRP_Walls_Generic_BossIndicator_Hexagon_001.m3", null, "Walls_BossIndicator_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\BossIndicator\\PRP_Walls_Generic_BossIndicator_Hexagon_30Degree_000.m3", null, "Walls_BossIndicator_30Degree", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\BossIndicator\\PRP_Walls_Generic_BossIndicator_Hexagon_30Degree_Left_000.m3", null, "Walls_BossIndicator_30Degree_Left", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\BossIndicator\\PRP_Walls_Generic_BossIndicator_Hexagon_30Degree_Right_000.m3", null, "Walls_BossIndicator_30Degree_Right", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\PRP_Brace_RetainingWallScrew_001.m3", null, "RetainingWall_Screw_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_000.m3", null, "Bamboo_Stalks_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Barrel_000.m3", null, "Bamboo_Stalks_Beige_Barrel", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Cut_000.m3", null, "Bamboo_Stalks_Beige_Cut", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Large_000.m3", null, "Bamboo_Stalks_Beige_Large_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Large_001.m3", null, "Bamboo_Stalks_Beige_Large_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Large_002.m3", null, "Bamboo_Stalks_Beige_Large_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Med_000.m3", null, "Bamboo_Stalks_Beige_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Med_001.m3", null, "Bamboo_Stalks_Beige_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Med_002.m3", null, "Bamboo_Stalks_Beige_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_All_000.m3", null, "Bamboo_Stalks_Beige_Pipe", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_000.m3", null, "Bamboo_Stalks_Beige_Curved_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_001.m3", null, "Bamboo_Stalks_Beige_Curved_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_002.m3", null, "Bamboo_Stalks_Beige_Curved_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_003.m3", null, "Bamboo_Stalks_Beige_Curved_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_004.m3", null, "Bamboo_Stalks_Beige_Curved_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Straight_000.m3", null, "Bamboo_Stalks_Beige_Straight", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Plank_000.m3", null, "Bamboo_Stalks_Beige_Plank", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Thin_000.m3", null, "Bamboo_Stalks_Beige_Thin_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Thin_001.m3", null, "Bamboo_Stalks_Beige_Thin_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Thin_002.m3", null, "Bamboo_Stalks_Beige_Thin_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Barrel_000.m3", null, "Bamboo_Stalks_Beige_Barrel", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Cut_000.m3", null, "Bamboo_Stalks_Purple_Cut", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Large_000.m3", null, "Bamboo_Stalks_Purple_Large_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Large_001.m3", null, "Bamboo_Stalks_Purple_Large_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Large_002.m3", null, "Bamboo_Stalks_Purple_Large_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Med_000.m3", null, "Bamboo_Stalks_Purple_Med_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Med_001.m3", null, "Bamboo_Stalks_Purple_Med_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Med_002.m3", null, "Bamboo_Stalks_Purple_Med_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_All_000.m3", null, "Bamboo_Stalks_Purple_Pipe", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_000.m3", null, "Bamboo_Stalks_Purple_Curved_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_001.m3", null, "Bamboo_Stalks_Purple_Curved_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_002.m3", null, "Bamboo_Stalks_Purple_Curved_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_003.m3", null, "Bamboo_Stalks_Purple_Curved_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_004.m3", null, "Bamboo_Stalks_Purple_Curved_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Straight_000.m3", null, "Bamboo_Stalks_Purple_Straight", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Plank_000.m3", null, "Bamboo_Stalks_Purple_Plank", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Thin_000.m3", null, "Bamboo_Stalks_Purple_Thin_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Thin_001.m3", null, "Bamboo_Stalks_Purple_Thin_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Thin_002.m3", null, "Bamboo_Stalks_Purple_Thin_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinDeckHalf_000.m3", null, "Walkways_AurinDeckHalf", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinDockEnd_000.m3", null, "Walkways_AurinDockEnd", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinDoubleEndLong_000.m3", null, "Walkways_AurinEndLong", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinDoubleEndShort_000.m3", null, "Walkways_AurinEndShort", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinExtension_000.m3", null, "Walkways_AurinExtension", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinPost_000.m3", null, "Walkways_AurinPost", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinRampSmall_000.m3", null, "Walkways_AurinRampSmall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinRampTall_000.m3", null, "Walkways_AurinRampTall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStairsSmall_000.m3", null, "Walkways_AurinStairsSmall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStairsTall_000.m3", null, "Walkways_AurinStairsTall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStraightBeam_000.m3", null, "Walkways_AurinStraightBeam", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStraight_000.m3", null, "Walkways_AurinStraight_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStraight_001.m3", null, "Walkways_AurinStraight_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinTIntersection_000.m3", null, "Walkways_AurinIntersection", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinTreeTrunkStairs_000.m3", null, "Walkways_AurinTrunkStairs", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinXRoad_000.m3", null, "Walkways_AurinXRoad", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_ClosedEndRound_000.m3", null, "Walkways_Chua_ClosedEndRound", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_ClosedEndRound_Wide_000.m3", null, "Walkways_Chua_ClosedEndRound_Wide", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_CoverSeams_001.m3", null, "Walkways_Chua_CoverSeams", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_CoverSeams_Wide_001.m3", null, "Walkways_Chua_CoverSeams_Wide", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Curved_000.m3", null, "Walkways_Chua_Curved", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Curved_Wide_000.m3", null, "Walkways_Chua_Wide_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Curved_Wide_001.m3", null, "Walkways_Chua_Wide_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_000.m3", null, "Walkways_Chua_Extension_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_001.m3", null, "Walkways_Chua_Extension_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_002.m3", null, "Walkways_Chua_Extension_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_003.m3", null, "Walkways_Chua_Extension_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_004.m3", null, "Walkways_Chua_Extension_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_005.m3", null, "Walkways_Chua_Extension_005", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_006.m3", null, "Walkways_Chua_Extension_006", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_RampLong_000.m3", null, "Walkways_Chua_RampLong", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_RampLong_Wide_000.m3", null, "Walkways_Chua_RampLong_Wide", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_RampShort_000.m3", null, "Walkways_Chua_RampShort", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Ramp_000.m3", null, "Walkways_Chua_Ramp", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Ramp_Wide_000.m3", null, "Walkways_Chua_Ramp_Wide", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_StraitWide_000.m3", null, "Walkways_Chua_StraitWide_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_StraitWide_001.m3", null, "Walkways_Chua_StraitWide_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_000.m3", null, "Walkways_Chua_Strait_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_001.m3", null, "Walkways_Chua_Strait_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_Short_000.m3", null, "Walkways_Chua_Strait_Short", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_Short_Wide_000.m3", null, "Walkways_Chua_Strait_Short_Wide_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_Short_Wide_001.m3", null, "Walkways_Chua_Strait_Short_Wide_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_TJunction_000.m3", null, "Walkways_Chua_TJunction", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_TJunction_Wide_000.m3", null, "Walkways_Chua_TJunctionWide_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_TJunction_Wide_001.m3", null, "Walkways_Chua_TJunctionWide_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_2Pillers_000.m3", null, "Walkways_Drakken_2Pillers", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_4way_000.m3", null, "Walkways_Drakken_4way", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Curved_000.m3", null, "Walkways_Drakken_Curved", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_GroundStairs_000.m3", null, "Walkways_Drakken_GroundStairs", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Piller_000.m3", null, "Walkways_Drakken_Piller", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Small_000.m3", null, "Walkways_Drakken_Small", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Stairs_000.m3", null, "Walkways_Drakken_Stairs", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Stairs_Small_000.m3", null, "Walkways_Drakken_Stairs_Small", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Strait_000.m3", null, "Walkways_Drakken_Strait_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Strait_001.m3", null, "Walkways_Drakken_Strait_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Strait_002.m3", null, "Walkways_Drakken_Strait_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Strait_003.m3", null, "Walkways_Drakken_Strait_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_FullBridge_Brown_000.m3", null, "Walkways_Dreadmoor_FullBridge_Brown", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayCurvedStairs_Brown_000.m3", null, "Walkways_Dreadmoor_CurvedStairs", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayStraightLong_Brown_000.m3", null, "Walkways_Dreadmoor_Long", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayStraightLong_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Long_Green", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayStraightShort_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Short_Green", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayStraightmedium_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Medium_Green", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Pell_DreadmoorWalkwayCurvedStairs_Brown_000.m3", null, "Walkways_Dreadmoor_CurvedStairs_Pell", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_SideWalk_DreadmoorStraight_Brown_001.m3", null, "Walkways_Dreadmoor_SideWalk", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWayStair_DreadmoorStraight_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Stair", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorCurved_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Curved", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorEndPlanks_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Endplanks_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorEndPlanks_GreenBrown_004.m3", null, "Walkways_Dreadmoor_Endplanks_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlank_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Plank_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlank_GreenBrown_001.m3", null, "Walkways_Dreadmoor_Plank_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlank_GreenBrown_003.m3", null, "Walkways_Dreadmoor_Plank_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlatformExtensionMed_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Platform_Extension_Medium", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlatformMed_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Platform_Medium_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlatformMed_GreenBrown_001.m3", null, "Walkways_Dreadmoor_Platform_Medium_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlatformSm_GreenBrown_000.m3", null, "Walkways_Dreadmoor_Platform_Small", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_CornerPost_001.m3", null, "Walkways_Imperium_Corner_Post", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_EndCap_001.m3", null, "Walkways_Imperium_EndCap", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_EntranceExit_001.m3", null, "Walkways_Imperium_EntranceExit", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_EntranceExit_noExtension_001.m3", null, "Walkways_Imperium_EntranceExit_NoExtension", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_EntranceExit_noExtension_No_Bracers_001.m3", null, "Walkways_Imperium_EntranceExit_Plain", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Extension_001.m3", null, "Walkways_Imperium_Extension", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Extension_NOrailing_001.m3", null, "Walkways_Imperium_Plain", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_MetalJunction_001.m3", null, "Walkways_Imperium_Junction", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Pillar_Fancy_000.m3", null, "Walkways_Imperium_Pillar_Fancy_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Pillar_Fancy_001.m3", null, "Walkways_Imperium_Pillar_Fancy_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Pillars_EndCap_001.m3", null, "Walkways_Imperium_Pillars_EndCap", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Pillars_Extension_001.m3", null, "Walkways_Imperium_Pillars_Extension", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Ramp_SHORT_001.m3", null, "Walkways_Imperium_Ramp_Short", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Ramp_TALL_001.m3", null, "Walkways_Imperium_Ramp_Tall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Stairs_90_LEFT_001.m3", null, "Walkways_Imperium_Stairs_Quarter_Left", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Stairs_QUARTER_001.m3", null, "Walkways_Imperium_Stairs_Quarter_Right", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Stairs_SHORT_001.m3", null, "Walkways_Imperium_Stairs_Short", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Stairs_TALL_001.m3", null, "Walkways_Imperium_Stairs_Tall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_TBone_001.m3", null, "Walkways_Imperium_T-Bone", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Turn_001.m3", null, "Walkways_Imperium_Turn", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_XRoads_001.m3", null, "Walkways_Imperium_Junction", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_t_Segment_001.m3", null, "Walkways_Imperium_T-Segment", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Walkways_Stairs_90_LEFT_Narrow_001.m3", null, "Walkways_Imperium_Quarter_Left_Narrow", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Walkways_Stairs_90_Right_Narrow_001.m3", null, "Walkways_Imperium_Quarter_Right_Narrow", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_FullBridge_000.m3", null, "Walkways_Pell_Full_Bridge", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwayCurvedDip_000.m3", null, "Walkways_Pell_Curved_Dip", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwayCurvedStairs_000.m3", null, "Walkways_Pell_Curved_Stairs", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwaySlopedRamp_000.m3", null, "Walkways_Pell_Sloped_Ramp", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwayStraightLong_000.m3", null, "Walkways_Pell_Straight_Long", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwayWoodPlank_000.m3", null, "Walkways_Pell_Wood_Plank", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Corner_000.m3", null, "Walkways_Protostar_Corner_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Corner_001.m3", null, "Walkways_Protostar_Corner_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Corner_002.m3", null, "Walkways_Protostar_Corner_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Corner_003.m3", null, "Walkways_Protostar_Corner_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Straight_000.m3", null, "Walkways_Protostar_Straight", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_SideWalk_SanctuaryCommonStraight_Brown_001.m3", null, "Walkways_Sanctuary_Sidewalk", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_SquirdStand_SanctuaryCommon_Rust_000.m3", null, "Walkways_Sanctuary_Squird_Stand", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WWStair_SCLeftDblWide_Brown_000.m3", null, "Walkways_Sanctuary_Stair_Wide_Left", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WWStair_SCRgtDblWide_Brown_000.m3", null, "Walkways_Sanctuary_Stair_Wide_Right", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WWStair_SCStraightDblWide_Brown_000.m3", null, "Walkways_Sanctuary_Straight_Wide_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WWStair_SCStraightDblWide_Brown_001.m3", null, "Walkways_Sanctuary_Straight_Wide_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonLeft_Brown_000.m3", null, "Walkways_Sanctuary_Stair_Left", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonRight_Brown_000.m3", null, "Walkways_Sanctuary_Stair_Right", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonStraight_Brown_000.m3", null, "Walkways_Sanctuary_Stair_Straight_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonStraight_Brown_001.m3", null, "Walkways_Sanctuary_Stair_Straight_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonStraight_Brown_002.m3", null, "Walkways_Sanctuary_Stair_Straight_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SCPlatformExtensionMed_Brown_000.m3", null, "Walkways_Sanctuary_Platform_Extension_Medium_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SCPlatformExtensionMed_Brown_001.m3", null, "Walkways_Sanctuary_Platform_Extension_Medium_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonCurved_Brown_000.m3", null, "Walkways_Sanctuary_Curved", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonEndPlanks_Brown_000.m3", null, "Walkways_Sanctuary_End_Planks", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlank_Brown_000.m3", null, "Walkways_Sanctuary_Plank_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlank_Brown_001.m3", null, "Walkways_Sanctuary_Plank_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlank_Brown_002.m3", null, "Walkways_Sanctuary_Plank_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlank_Brown_003.m3", null, "Walkways_Sanctuary_Plank_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlatformMed_Brown_000.m3", null, "Walkways_Sanctuary_Platform_Medium_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlatformMed_Brown_001.m3", null, "Walkways_Sanctuary_Platform_Medium_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonRailing_Brown_000.m3", null, "Walkways_Sanctuary_Railing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonStraight_Brown_000.m3", null, "Walkways_Sanctuary_Straight", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PrP_WalkWay_SanctuaryCommonPlatformSm_Brown_000.m3", null, "Walkways_Sanctuary_Platform_Small_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PrP_WalkWay_SanctuaryCommonPlatformSm_Brown_001.m3", null, "Walkways_Sanctuary_Platform_Small_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Curved_000.m3", null, "Walkways_Bamboo_Curved", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Curved_Ramp_LT_000.m3", null, "Walkways_Bamboo_Curved_(Descend)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Curved_Ramp_RT_000.m3", null, "Walkways_Bamboo_Curved_(Ascend)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Curved_000.m3", null, "Walkways_Bamboo_Wide_Curved", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Curved_LT_000.m3", null, "Walkways_Bamboo_Wide_Curved_(Left)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Curved_RT_000.m3", null, "Walkways_Bamboo_Wide_Curved_(Right)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_EXT_000.m3", null, "Walkways_Bamboo_Wide_Extension", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_EXT_4WAY_000.m3", null, "Walkways_Bamboo_Wide_Extension_Junction", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Long_000.m3", null, "Walkways_Bamboo_Wide_Long", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Long_Rail_000.m3", null, "Walkways_Bamboo_Wide_Long_Railing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Long_Ramp_000.m3", null, "Walkways_Bamboo_Wide_Long_Ramp", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Short_Ramp_000.m3", null, "Walkways_Bamboo_Wide_Ramp_Short", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_000.m3", null, "Walkways_Bamboo_Wide_Square", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_4WAY_000.m3", null, "Walkways_Bamboo_Wide_Square_Junction", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_Rail_000.m3", null, "Walkways_Bamboo_Wide_Square_Railing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_Tall_000.m3", null, "Walkways_Bamboo_Wide_Square_Tall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_Tall_4WAY_000.m3", null, "Walkways_Bamboo_Wide_Square_Tall_Junction", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_Tall_Rail_000.m3", null, "Walkways_Bamboo_Wide_Square_Tall_Railing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Long_000.m3", null, "Walkways_Bamboo_Long", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Long_Rail_000.m3", null, "Walkways_Bamboo_Long_Railing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Long_Ramp_000.m3", null, "Walkways_Bamboo_Long_Ramp", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Rail_000.m3", null, "Walkways_Bamboo_Railing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Short_Ramp_000.m3", null, "Walkways_Bamboo_Short_Ramp", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_000.m3", null, "Walkways_Bamboo_Square", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_4Way_000.m3", null, "Walkways_Bamboo_Square_Junction", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_Rail_000.m3", null, "Walkways_Bamboo_Square_Railing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_Tall_000.m3", null, "Walkways_Bamboo_Square_Tall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_Tall_4WAY_000.m3", null, "Walkways_Bamboo_Square_Tall_Junction", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_Tall_Rail_000.m3", null, "Walkways_Bamboo_Square_Tall_Railing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Imperium\\PRP_Sign_ImperiumPropaganda_000.m3", null, "Dominion Propaganda Screen", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderArrows_000.m3", null, "Sign_MarauderArrows_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderArrows_001.m3", null, "Sign_MarauderArrows_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderArrows_002.m3", null, "Sign_MarauderArrows_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderArrows_003.m3", null, "Sign_MarauderArrows_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Mine\\PRP_Sign_Mine_Entrance_001.m3", null, "Sign_Mine_Entrance", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Mine\\PRP_Sign_Mine_Entrance_Metal_001.m3", null, "Sign_Mine_Entrance_Metal", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_002.m3", null, "Pipes_Dreadmoore_002", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_004.m3", null, "Pipes_Dreadmoore_004", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_005.m3", null, "Pipes_Dreadmoore_005", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_006.m3", null, "Pipes_Dreadmoore_006", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_007.m3", null, "Pipes_Dreadmoore_007", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_008.m3", null, "Pipes_Dreadmoore_008", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_009.m3", null, "Pipes_Dreadmoore_009", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_010.m3", null, "Pipes_Dreadmoore_010", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_011.m3", null, "Pipes_Dreadmoore_011", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_012.m3", null, "Pipes_Dreadmoore_012", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_013.m3", null, "Pipes_Dreadmoore_013", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_014.m3", null, "Pipes_Dreadmoore_014", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_000.m3", null, "Wiggling Pipe (Warped)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_001.m3", null, "Wiggling Pipe (Twisted)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_002.m3", null, "Wiggling Pipe (Short)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_017.m3", null, "Pipes_Generic_016", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_018.m3", null, "Pipes_Generic_017", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_019.m3", null, "Pipes_Generic_018", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_020.m3", null, "Pipes_Generic_019", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_021.m3", null, "Pipes_Generic_020", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_022.m3", null, "Pipes_Generic_021", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_023.m3", null, "Pipes_Generic_022", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_000.m3", null, "Pipes_Generic_Connector_000", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_001.m3", null, "Pipes_Generic_Connector_001", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_002.m3", null, "Pipes_Generic_Connector_002", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_003.m3", null, "Pipes_Generic_Connector_003", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_004.m3", null, "Pipes_Generic_Connector_004", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_005.m3", null, "Pipes_Generic_Connector_005", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_006.m3", null, "Pipes_Generic_Connector_006", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_007.m3", null, "Pipes_Generic_Connector_007", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_008.m3", null, "Pipes_Generic_Connector_008", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_009.m3", null, "Pipes_Generic_Connector_009", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_010.m3", null, "Pipes_Generic_Connector_010", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_000.m3", null, "Pipes_Ikthian_000", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_001.m3", null, "Pipes_Ikthian_001", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_002.m3", null, "Pipes_Ikthian_002", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_003.m3", null, "Pipes_Ikthian_003", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_004.m3", null, "Pipes_Ikthian_004", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_Stacker_000.m3", null, "Pipes_Ikthian_Stacker", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_PipeBase_RMC_000.m3", null, "PipesBase_RMC", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipe_AirVent_RMC_000.m3", null, "Pipes_RMC_AirVent", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipe_ManHole_RMC_000.m3", null, "Pipes_RMC_ManHole", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_000.m3", null, "Pipes_RMC_LargeSegment_000", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_001.m3", null, "Pipes_RMC_LargeSegment_001", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_002.m3", null, "Pipes_RMC_LargeSegment_002", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_003.m3", null, "Pipes_RMC_LargeSegment_003", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_004.m3", null, "Pipes_RMC_LargeSegment_004", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_005.m3", null, "Pipes_RMC_LargeSegment_005", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_006.m3", null, "Pipes_RMC_LargeSegment_006", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_007.m3", null, "Pipes_RMC_LargeSegment_007", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_008.m3", null, "Pipes_RMC_LargeSegment_008", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_009.m3", null, "Pipes_RMC_LargeSegment_009", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_010.m3", null, "Pipes_RMC_LargeSegment_010", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_011.m3", null, "Pipes_RMC_LargeSegment_011", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_000.m3", null, "Pipes_RMC_LargePipe_000", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_001.m3", null, "Pipes_RMC_LargePipe_001", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_002.m3", null, "Pipes_RMC_LargePipe_002", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_001.m3", null, "Pipes_RMC_Valve_001", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_003.m3", null, "Pipes_RMC_Valve_003", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_004.m3", null, "Pipes_RMC_Valve_004", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_000.m3", null, "Pipes_Refinery_000", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_001.m3", null, "Pipes_Refinery_001", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_002.m3", null, "Pipes_Refinery_002", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_003.m3", null, "Pipes_Refinery_003", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_LongSegment_GreyBrown_000.m3", null, "Pipes_LongSegment_GreyBrown", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_MidSegment_GreyBrown_000.m3", null, "Pipes_MidSegment_Greybrown", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_Tap_GreyBrown_001.m3", null, "Pipes_Tap_GreyBrown", DecorCategory.Accents, false);
            AddGenericDecor("Art\\FX\\3D\\Splatter_Goo_Decal_GRN\\Splatter_Goo_Decal_02_GRN.m3", null, "Goo_Decal_02", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\3D\\Splatter_Goo_Decal_GRN\\Splatter_Goo_Decal_03_GRN.m3", null, "Goo_Decal_03", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\3D\\Splatter_Goo_Decal_GRN\\Splatter_Goo_Decal_04_GRN.m3", null, "Goo_Decal_04", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\3D\\Splatter_Goo_Decal_GRN\\Splatter_Goo_Decal_GRN.m3", null, "Goo_Decal_GRN", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\3D\\Spray_BB_BLE\\Spray_BB_BLE.m3", null, "Spray_BLE", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\3D\\Square_BB_BLE\\Square_BB_BLE.m3", null, "Square_BLE", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Ice_Ground\\Ice_Ground_Decal.m3", null, "Ice_Ground_Decal", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\Impacts\\Goo_Splatter_Decal_GRN\\Goo_Splatter_Decal_GRN.m3", null, "Goo_Splatter_Decal", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Buff\\Decal\\Decal_Elements\\Decal_Elements_5m_AQU.m3", null, "Buff_Decal_Elements", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Esper\\Graveyard\\Graveyard_SmokeyDecal_01_BLU.m3", null, "SmokeDecal_BLU", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Garr\\Vomit\\Garr_VomitDecal_90d_10mR_GRN_9.m3", null, "VomitDecal", DecorCategory.Beta, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Garr\\Vomit\\Garr_VomitDecal_90d_10mR_wBones_GRN_9.m3", null, "VomitDecal_Bones", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Constructed\\Lootpile\\PRP_Decal_LootPile_Generic_Gold_000.m3", null, "Decal_LootPile", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_00.m3", null, "Rock_BlastedJagged_00", DecorCategory.Rocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_01.m3", null, "Rock_BlastedJagged_01", DecorCategory.Rocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_02.m3", null, "Rock_BlastedJagged_02", DecorCategory.Rocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_03.m3", null, "Rock_BlastedJagged_03", DecorCategory.Rocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_04.m3", null, "Rock_BlastedJagged_04", DecorCategory.Rocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_05.m3", null, "Rock_BlastedJagged_05", DecorCategory.Rocks, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_06.m3", null, "Rock_BlastedJagged_06", DecorCategory.Rocks, false);
            AddGroundOption("Icescape", 1256, 1257);
            AddGroundOption("Celestion Moss 1", 137, 138);
            AddGroundOption("Celestion Moss 2", 137, 193);
            AddGroundOption("Tech Plate", 480, 359);
            AddGroundOption("Alien", 566, 857);
            AddGroundOption("Mossy Rock", 1222, 948);
            AddGroundOption("Wilderrun Cavern", 430, 422);
            AddGroundOption("Mystic Rock 1", 346, 645);
            AddGroundOption("Mystic Rock 2", 347, 766);
            AddGroundOption("Mystic Rock 3", 1250, 209);
            AddGroundOption("Gothic Meadow 1", 1034, 476);
            AddGroundOption("Gothic Meadow 2", 1034, 22);
            AddGroundOption("Galeras Meadow 2", 544, 757);
            AddGroundOption("Galeras Meadow 3", 1233, 757);
            AddGroundOption("Galeras Meadow 4", 757, 82);
            AddGroundOption("Galeras Muddy", 82, 83);
            AddGroundOption("Rocky", 589, 259);
            AddGroundOption("Rocky 2", 981, 525);
            AddGroundOption("Overgrown Temple", 249, 422);
            AddGroundOption("Verdant Rocks", 589, 422);
            AddGroundOption("SLIME TIME", 857, 928);
            AddGroundOption("Debris Seam 1", 340, 166);
            AddGroundOption("Debris Seam 2", 30, 166);
            AddGroundOption("Crystal Field 1", 44, 464);
            AddGroundOption("Halon Ring (Flowery)", 336, 1046);
            AddGroundOption("Chrome", 855, 856);
            AddGroundOption("Metal", 501, 572);
            AddGroundOption("Hexagons 2", 608, 921);
            AddGroundOption("Hexagons 5", 953, 856);
            AddGroundOption("Chronium Garden", 757, 856);

            uint param = AddCustomizationParameter(null, "Size", 1, 1, 1, 0, 0, 0, 0, 0, 0);
            AddCustomizationParameterMap(null, 4, 0, 128, param, 0, 0);

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

            List<string> file = new List<string>();
            foreach(var entry in language.Entries)
            {
                file.Add($"{entry.Id}: {entry.Text}");
            }
            File.WriteAllLines("../../../../Strings.txt", file);
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

        static GameTable.GameTable wallpaperInfo;
        static uint nextWallpaper = 0;

        static GameTable.GameTable worldLayer;
        static uint nextWorldLayer = 0;

        static GameTable.GameTable customizationParameter;
        static uint nextCustomizationParameter = 0;

        static GameTable.GameTable customizationParameterMap;
        static uint nextCustomizationParameterMap = 0;

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

            wallpaperInfo = new GameTable.GameTable();
            wallpaperInfo.Load("../../../../Tbl/HousingWallpaperInfo.tbl");
            nextWallpaper = GetMaxID(wallpaperInfo.Entries) + 1;

            worldLayer = new GameTable.GameTable();
            worldLayer.Load("../../../../Tbl/WorldLayer.tbl");
            nextWorldLayer = GetMaxID(worldLayer.Entries) + 1;

            customizationParameter = new GameTable.GameTable();
            customizationParameter.Load("../../../../Tbl/CustomizationParameter.tbl");
            nextCustomizationParameter = GetMaxID(customizationParameter.Entries) + 1;

            customizationParameterMap = new GameTable.GameTable();
            customizationParameterMap.Load("../../../../Tbl/CustomizationParameterMap.tbl");
            nextCustomizationParameterMap = GetMaxID(customizationParameterMap.Entries) + 1;

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

            wallpaperInfo.Save(baseFolder + "DB/HousingWallpaperInfo.tbl");

            /*customizationParameter.Save(baseFolder + "DB/CustomizationParameter.tbl");

            customizationParameterMap.Save(baseFolder + "DB/CustomizationParameterMap.tbl");*/

            worldLayer.Save(baseFolder + "DB/WorldLayer.tbl");

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
            ShelvesCases = 9,
            Cabinets = 10,
            CookwareBarware = 11,
            Plants = 12,
            Lighting = 13,
            Toys = 14,
            Rugs = 15,
            ToolsHardware = 16,
            WeaponsArmor = 17,
            DrapesCurtains = 18,
            Windows = 19,
            WallDecor = 20,
            Trees = 25,
            Fencing = 30,
            Food = 36,
            Books = 37,
            StatuesSculptures = 39,
            Audio = 41,
            BushesShrubbery = 42,
            Flowers = 43,
            Grasses = 44,
            Accents = 46,
            BannersFlags = 47,
            BuildingBlocks = 48,
            Fireplace = 49,
            Mannequins = 50,
            Pillows = 51,
            Special = 52,
            TravelPosters = 53,
            Trophy = 54,
            Traps = 55,
            Bathroom = 57,
            Turrets = 58,
            Doors = 59,
            Spaceship = 60,
            Hoverpark = 61,
            Rocks = 62,
            ParticleEffects = 63,
            CharactersCreatures = 64,
            Vehicles = 65,
            Beta = 66,
            Unknown = 67,
            Structures = 68,
            Decals = 69,
            LightSource = 70,
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

        static uint AddGenericDecor(string hookAsset, uint? id = null, string name = null, DecorCategory category = DecorCategory.Lighting, bool particleAlt = false, uint week = 0)
        {
            if(betaMode)
            {
                category = DecorCategory.Beta;
                name = "(BETA) " + name;
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
            if(week == 0)
            {
                week = 99;
            }
            if(week >= 100)
            {
                week += 1; // skip the 1 silver, when we get there.
            }
            entry.AddInteger(week); // cost
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

        static uint AddEmote(uint animationID, string command, string command2 = null, uint? id = null)
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
            entry.AddString(command ?? ""); // universalCommand00
            entry.AddString(command2 ?? ""); // universalCommand01

            return AddEntry(emotes, entry, ref nextEmoteID, id);
        }

        static uint AddWallpaper(uint? id, string name, uint cost, uint flags, uint unlockIndex, uint worldSkyID, uint soundZoneKitID, uint worldLayerID1, uint worldLayerID2)
        {
            if(betaMode)
            {
                name = "(BETA) " + name;
            }
            var entry = new GameTableEntry();
            entry.AddInteger(language.AddEntry(name)); // localizedTextID
            entry.AddInteger(cost); // cost
            entry.AddInteger(1); // costCurrencyID
            entry.AddInteger(0); // replaceableMaterialInfoID, for walls/ceilings/floors
            entry.AddInteger(worldSkyID); // worldSkyID
            entry.AddInteger(flags); // flags, can be 1, 4, 2, 8, 16
            entry.AddInteger(0); // prerequisiteIdUnlock
            entry.AddInteger(0); // prerequisiteIdUse
            entry.AddInteger(unlockIndex); // unlockIndex
            entry.AddInteger(soundZoneKitID); // soundZoneKitId
            entry.AddInteger(0); // worldLayerId00
            entry.AddInteger(worldLayerID1); // worldLayerId01
            entry.AddInteger(worldLayerID2); // worldLayerId02
            entry.AddInteger(0); // worldLayerId03
            entry.AddInteger(0); // accountItemIdUpsell

            return AddEntry(wallpaperInfo, entry, ref nextWallpaper, id);
        }

        static uint AddGroundOption(string name, uint worldLayerPrimary, uint worldLayerSecondary, uint? id = null, uint cost = 1)
        {
            return AddWallpaper(id, name, cost, 512, 270, 1, 0, worldLayerSecondary, worldLayerPrimary);
        }

        static GameTableEntry CopyEntry(GameTableEntry copied)
        {
            GameTableEntry newEntry = new GameTableEntry();
            foreach (var val in copied.Values)
            {
                GameTableValue copy = new GameTableValue(val.Type);
                copy.SetValue(val.Value);
                newEntry.Values.Add(copy);
            }
            return newEntry;
        }

        static void Overwrite(GameTableValue val, object overwrite)
        {
            if(overwrite != null)
            {
                val.SetValue(overwrite);
            }
        }

        static uint AddWorldLayer(uint id, string name, uint copiedID, float? heightScale, float? heightOffset, float? parallaxScale, float? parallaxOffset, float? metersPerTile, string colorTexture, string normalTexture, uint? averageColor, uint? materialType, uint? worldClutterID0, uint? worldClutterID1, uint? worldClutterID2, uint? worldClutterID3, float? specularPower, uint? emissiveGlow, float? scrollSpeed0, float? scrollSpeed1)
        {
            var copied = GetEntry(worldLayer, copiedID);
            var entry = CopyEntry(copied);
            Overwrite(entry.Values[1], name);
            Overwrite(entry.Values[2], heightScale);
            Overwrite(entry.Values[3], heightOffset);
            Overwrite(entry.Values[4], parallaxScale);
            Overwrite(entry.Values[5], parallaxOffset);
            Overwrite(entry.Values[6], metersPerTile);
            Overwrite(entry.Values[7], colorTexture);
            Overwrite(entry.Values[8], normalTexture);
            Overwrite(entry.Values[9], averageColor);
            Overwrite(entry.Values[10], 0u); // Projection
            Overwrite(entry.Values[11], materialType);
            Overwrite(entry.Values[12], worldClutterID0);
            Overwrite(entry.Values[13], worldClutterID1);
            Overwrite(entry.Values[14], worldClutterID2);
            Overwrite(entry.Values[15], worldClutterID3);
            Overwrite(entry.Values[16], specularPower);
            Overwrite(entry.Values[17], emissiveGlow);
            Overwrite(entry.Values[18], scrollSpeed0);
            Overwrite(entry.Values[19], scrollSpeed1);

            entry.Values.RemoveAt(0);

            return AddEntry(worldLayer, entry, ref nextWorldLayer, id);
        }

        static uint AddCustomizationParameter(uint? id, string name, float sclX, float sclY, float sclZ, float rotX, float rotY, float rotZ, float posX, float posY, float posZ)
        {
            var entry = new GameTableEntry();

            entry.AddInteger(language.AddEntry(name));
            entry.AddSingle(sclX);
            entry.AddSingle(sclY);
            entry.AddSingle(sclZ);
            entry.AddSingle(rotX);
            entry.AddSingle(rotY);
            entry.AddSingle(rotZ);
            entry.AddSingle(posX);
            entry.AddSingle(posY);
            entry.AddSingle(posZ);

            return AddEntry(customizationParameter, entry, ref nextCustomizationParameter, id);
        }

        static uint AddCustomizationParameterMap(uint? id, uint raceID, uint genderEnum, uint modelBoneID, uint customizationParameterID, uint dataOrder, uint flags)
        {
            var entry = new GameTableEntry();

            entry.AddInteger(raceID);
            entry.AddInteger(genderEnum);
            entry.AddInteger(modelBoneID);
            entry.AddInteger(customizationParameterID);
            entry.AddInteger(dataOrder);
            entry.AddInteger(flags);

            return AddEntry(customizationParameterMap, entry, ref nextCustomizationParameterMap, id);
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

        static GameTableEntry GetEntry(GameTable.GameTable table, uint id)
        {
            foreach (GameTableEntry entry in table.Entries)
            {
                if((uint) entry.Values[0].Value == id)
                {
                    return entry;
                }
            }
            return null;
        }
    }
}
