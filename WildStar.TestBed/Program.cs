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


            AddEmote(7834, "lounge1", "lounge");
            AddEmote(7835, "lounge2");

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


            AddGenericDecor("Art\\Light\\LIT_Level_Up_Spotlight_000.m3", 3699, "!NEW! Spot Light (Level Up)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Mask_Point_Med_AurinHanging.m3", 3700, "!NEW! Point Light (Aurin Hanging Light)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Mask_Spotlight_Gate_000.m3", 3701, "!NEW! Spot Light (Gate)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Hard.m3", 3702, "!NEW! Point Light (Hard)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Hard_Bright.m3", 3703, "!NEW! Point Light (Hard, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med.m3", 3704, "!NEW! Point Light (Medium)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med_Bright.m3", 3705, "!NEW! Point Light (Medium, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med_Bright_Amb.m3", 3706, "!NEW! Point Light (Medium, Bright Ambient)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft.m3", 3707, "!NEW! Point Light (Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Bright.m3", 3708, "!NEW! Point Light (Soft, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Overbright.m3", 3709, "!NEW! Point Light (Soft, Overbright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Throb.m3", 3710, "!NEW! Point Light (Soft, Throb)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Hard.m3", 3711, "!NEW! Spot Light (Hard, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Med.m3", 3712, "!NEW! Spot Light (Medium, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Soft.m3", 3713, "!NEW! Spot Light (Soft, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Diffused_Overbright.m3", 3714, "!NEW! Spot Light (Diffused, Overbright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Hard.m3", 3715, "!NEW! Spot Light (Hard)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Med.m3", 3716, "!NEW! Spot Light (Medium)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_MedNarrow_Soft.m3", 3717, "!NEW! Spot Light (Medium, Narrow Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Narrow_Med.m3", 3718, "!NEW! Spot Light (Medium, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Narrow_Soft.m3", 3719, "!NEW! Spot Light (Soft, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Soft.m3", 3720, "!NEW! Spot Light (Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Hard.m3", 3721, "!NEW! Spot Light (Hard, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Med.m3", 3722, "!NEW! Spot Light (Medium, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Soft.m3", 3723, "!NEW! Spot Light (Soft, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_DIR_Crystline_001.m3", 3724, "!NEW! Directional Light (Crystal)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_DIR_SimpleNarrow_001.m3", 3725, "!NEW! Directional Light (Simple, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Cubic_Fire_001.m3", 3726, "!NEW! Point Light (Fire Texture)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_Brazier.m3", 3727, "!NEW! Point Light (Brazier)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_LavaTube.m3", 3728, "!NEW! Point Light (Lava Tube)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Branches_001.m3", 3729, "!NEW! Spot Light (Branches)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Chain.m3", 3730, "!NEW! Spot Light (Chain Texture)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001.m3", 3731, "!NEW! Spot Light (Dappled Light)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001_Short.m3", 3732, "!NEW! Spot Light (Dappled Light, Short)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002.m3", 3733, "!NEW! Spot Light (Dappled Light 2)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002_Short.m3", 3734, "!NEW! Spot Light (Dappled Light 2, Short)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Fire_001.m3", 3735, "!NEW! Spot Light (Fire)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Grate.m3", 3736, "!NEW! Spot Light (Grate)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Grate_Large.m3", 3737, "!NEW! Spot Light (Grate, Large)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_002.m3", 3738, "!NEW! Hanging Cable (Long)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_003.m3", 3739, "!NEW! Hanging Cable (Longer)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_SegmentedLong_003.m3", 3740, "!NEW! Hanging Cable (Long, Drooping)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\PRP_Cable_Generic_Box_000.m3", 3741, "!NEW! Cable Socket", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_007.m3", 3742, "!NEW! Phial (Medium)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_008.m3", 3743, "!NEW! Potion Bottle", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_009.m3", 3744, "!NEW! Potion Bottle (Wide)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Bottle_Granok_Beer_000.m3", 3745, "!NEW! Beer Bottle (Granok)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Granok_BeerCan_Open_000.m3", 3746, "!NEW! Crushed Beer Can", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_001.m3", 3747, "!NEW! Beer Can (Protostar)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_000.m3", 3748, "!NEW! Crushed Beer Can (Protostar)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bar\\SanctuaryCommon\\PRP_Bar_DrinkMixer_Gold_000.m3", 3749, "!NEW! Drink Mixer", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\PRP_Debris_SmugglerFighterCrashed_VAR_LeftEngine_000.m3", 3750, "!NEW! Ruined Fighter Wing", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_000.m3", 3751, "!NEW! Metal Panel (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_001.m3", 3752, "!NEW! Metal Panel", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_002.m3", 3753, "!NEW! Metal Panel (Uneven)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Falkrin\\PRP_Debris_FalkrinMetalPlate_000.m3", 3754, "!NEW! Metal Scrap", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_000.m3", 3755, "!NEW! Granok Trailer", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_001.m3", 3756, "!NEW! Granok Trailer (Sandstone)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_000.m3", 3757, "!NEW! Junk Shack (Tall)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_001.m3", 3758, "!NEW! Junk Shack (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotArm_Rust_000.m3", 3759, "!NEW! Rusty Bot Arm", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotBody_Rust_000.m3", 3760, "!NEW! Rusty Bot Torso", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotHead_Rust_000.m3", 3761, "!NEW! Rusty Bot Head", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotLeg_Rust_000.m3", 3762, "!NEW! Rusty Bot Leg", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_000.m3", 3763, "!NEW! Metal Pipe Tower", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_001.m3", 3764, "!NEW! Large Metal Tank", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_002.m3", 3765, "!NEW! Metal Scaffolding (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_003.m3", 3766, "!NEW! Metal Scaffolding ", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_002.m3", 3767, "!NEW! Metal Pipe Interesection", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_005.m3", 3768, "!NEW! Metal Pipe Segment", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_006.m3", 3769, "!NEW! Metal Pipe (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_007.m3", 3770, "!NEW! Metal Pipe (Thin, Curved)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_008.m3", 3771, "!NEW! Metal Pipe (Short)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_009.m3", 3772, "!NEW! Metal Pipe (Curved)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_010.m3", 3773, "!NEW! Metal Support Beams", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_011.m3", 3774, "!NEW! Metal Support Beams (Double)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_013.m3", 3775, "!NEW! Metal Rod", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_014.m3", 3776, "!NEW! Faucet", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_000.m3", 3777, "!NEW! Crooked Pipe", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipe_ManHole_RMC_000.m3", 3778, "!NEW! Metal Pipe Cap", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_PipeBase_RMC_000.m3", 3779, "!NEW! Redmoon Ventilation Pipes", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_000.m3", 3780, "!NEW! Metal Tube (Curved)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_001.m3", 3781, "!NEW! Metal Tube", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_002.m3", 3782, "!NEW! Metal Tube (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_003.m3", 3783, "!NEW! Metal Tube (Corner)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_004.m3", 3784, "!NEW! Metal Pipe Moderator", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_005.m3", 3785, "!NEW! Chua Sphere", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_006.m3", 3786, "!NEW! Metal Tube (Reinforced)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_007.m3", 3787, "!NEW! Metal Tube (Cap)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_008.m3", 3788, "!NEW! Metal Tube (Short)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_009.m3", 3789, "!NEW! Chua Orb", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_010.m3", 3790, "!NEW! Chua Orb (Large)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_011.m3", 3791, "!NEW! Chua Window", DecorCategory.Windows, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_002.m3", 3792, "!NEW! Tank (Chua, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_001.m3", 3793, "!NEW! Valve (Round)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_004.m3", 3794, "!NEW! Valve", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_Tap_GreyBrown_001.m3", 3795, "!NEW! Rusty Watertap", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Arkship\\PRP_Container_Arkship_RelicCrate_001.m3", 3796, "!NEW! Shipping Crate (Open)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Arkship\\PRP_Container_Arkship_RelicCrate_002.m3", 3797, "!NEW! Shipping Crate Lid", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Chua\\PRP_Chua_Container_002.m3", 3798, "!NEW! Chua Speaker", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Chua\\PRP_Chua_Container_003.m3", 3799, "!NEW! Tank (Chua, Small)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_000.m3", 3800, "!NEW! Metal Canister (Damaged)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_001.m3", 3801, "!NEW! Metal Canister (Broken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_002.m3", 3802, "!NEW! Metal Fragment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Generic\\PRP_Container_Generic_Cannister_000.m3", 3803, "!NEW! Canister (Ornate)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Ikthian_ContainerBot_Boxy_001.m3", 3804, "!NEW! Treasure Chest (Ikthian, Open)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Container_PlasmaAquaLiquid_BlueYellow_000.m3", 3805, "!NEW! Plasma Canister (Ikthian)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Container_PlasmaAquaLiquid_BlueYellow_001.m3", 3806, "!NEW! Plasma Canister (Ikthian, Broken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MachineGun\\Tribal\\PRP_Turret_Tribal_000.m3", 3807, "!NEW! Turret Barrel", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularShort_000.m3", 3808, "!NEW! Metal Beam", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularLong_000.m3", 3809, "!NEW! Metal Beam (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularLargeLong_000.m3", 3810, "!NEW! Metal Beam (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularBroken_001.m3", 3811, "!NEW! Metal Beam (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularTFrame_000.m3", 3812, "!NEW! Metal Beam Pillar", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularShort_Brown_000.m3", 3813, "!NEW! Wooden Beam", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularLong_Brown_000.m3", 3814, "!NEW! Wooden Beam (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularLargeLong_Brown_000.m3", 3815, "!NEW! Wooden Beam (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularBroken_Brown_000.m3", 3816, "!NEW! Wooden Beam (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularTFrame_Brown_000.m3", 3817, "!NEW! Wooden Beam Pillar", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamConnector_MineModularMetal_Grey_001.m3", 3818, "!NEW! Metal Beam Connector", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamConnector_MineModularMetal_Grey_002.m3", 3819, "!NEW! Metal Beam Connector (2)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_000.m3", 3820, "!NEW! Hanging Wire (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_001.m3", 3821, "!NEW! Hanging Wire (Spiraling)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_002.m3", 3822, "!NEW! Hanging Wire (Coiled)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_003.m3", 3823, "!NEW! Hanging Wire", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ScienceInstruments\\General\\PRP_General_LargeMicroscope_000.m3", 3824, "!NEW! Microscope", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ScienceInstruments\\General\\PRP_General_SmallScanner_000.m3", 3825, "!NEW! Medical Scanner", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\PRP_ArkShip_Planter_007.m3", 3826, "!NEW! Robotic Arm Segment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\PRP_Bank_Atm_Generic_000.m3", 3827, "!NEW! ATM Machine", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Freebot\\PRP_Machinery_FreebotTransformer_Green_000.m3", 3828, "!NEW! Freebot Transformer", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Freebot\\PRP_Machinery_FreebotWelder_Green_000.m3", 3829, "!NEW! Freebot Welding Unit", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Chua\\PRP_Machinery_ChuaDrill_000.m3", 3830, "!NEW! Chua Drill Pod", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pillar\\Osun\\PRP_Pillar_OsunHead_000.m3", 3831, "!NEW! Osun Bust", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pillar\\Algeroc\\PRP_StructuralPillar_AlgorocMineSupport_Brown_000.m3", 3832, "!NEW! Wooden Column", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\PRP_Weapon_TranquilizerRounds_000.m3", 3833, "!NEW! Tranquilizer Rounds", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_000.m3", 3834, "!NEW! Missile (Cluster)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_001.m3", 3835, "!NEW! Missile (Ballistic)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_002.m3", 3836, "!NEW! Missile (Angry)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Television\\Pell\\PRP_Television_Pell_000.m3", 3837, "!NEW! Pell Monitor", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Barrel_000.m3", 3838, "!NEW! Cannon Barrel", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Barrel_001.m3", 3839, "!NEW! Cannon Barrel (Exile)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Shield_000.m3", 3840, "!NEW! Metal Panel (Exile Decal)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Imperium\\PRP_Turret_ImperiumMilitary_000.m3", 3841, "!NEW! Turret (Dominion)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_000.m3", 3842, "!NEW! Beaker and Vial", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_001.m3", 3843, "!NEW! Beaker (Empty)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Blue_000.m3", 3844, "!NEW! Beaker (Blue, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Blue_001.m3", 3845, "!NEW! Beaker (Blue)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Green_000.m3", 3846, "!NEW! Beaker (Green, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Green_001.m3", 3847, "!NEW! Beaker (Green)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Purple_000.m3", 3848, "!NEW! Beaker (Purple, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Purple_001.m3", 3849, "!NEW! Beaker (Purple)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Red_000.m3", 3850, "!NEW! Beaker (Red, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Red_001.m3", 3851, "!NEW! Beaker (Red)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ChemistrySet_000.m3", 3852, "!NEW! Chemistry Set", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ScrewDriver.m3", 3853, "!NEW! Screwdriver", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_SHookMetal_Gray_003.m3", 3854, "!NEW! Metal Hook", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ToolCase_000.m3", 3855, "!NEW! Tool Case", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MinePileBundle_Red_000.m3", 3856, "!NEW! Wire Bundle", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MinePileBundle_Red_002.m3", 3857, "!NEW! Wire Bundle (Large)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Shelter\\PRP_Tools_shedgenericanimalshelter_brownrust_000.m3", 3858, "!NEW! Open Shed", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Pots_and_Pans\\PRP_Tools_PotsPans_000.m3", 3859, "!NEW! Empty Pot (Small)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\PRP_GearPile_Grey_000.m3", 3860, "!NEW! Gear Pile", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_LargeGear_000.m3", 3861, "!NEW! Freebot Gear (Large)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_LargeGear_001.m3", 3862, "!NEW! Freebot Gear (Large, Tight)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_MediumGear_000.m3", 3863, "!NEW! Freebot Gear (Jagged)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_SmallGear_000.m3", 3864, "!NEW! Freebot Gear (Small)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Arkship_Tram_000.m3", 3865, "!NEW! Arkship Tram", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Imperium_White_000.m3", 3866, "!NEW! Lifter (Handle)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Imperium_White_001.m3", 3867, "!NEW! Lifter", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\House\\Pell\\Large\\PRP_PellHouse_Large_000.m3", 3868, "!NEW! Pell House (Large)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\House\\Pell\\Small\\PRP_PellHouse_Small_000.m3", 3869, "!NEW! Pell House (Small)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokCorner_000.m3", 3870, "!NEW! Granok Platform (Junction)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokLeftTurn_000.m3", 3871, "!NEW! Granok Stairs (Curved, Left)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokLongStairs_000.m3", 3872, "!NEW! Granok Stairs", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokPlatform_000.m3", 3873, "!NEW! Granok Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokRightTurn_000.m3", 3874, "!NEW! Granok Stairs (Curved, Right)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokShortStairs_000.m3", 3875, "!NEW! Granok Stairs & Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokStairs_000.m3", 3876, "!NEW! Granok Stairs (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokStraight_000.m3", 3877, "!NEW! Granok Platform (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_LargeWoodPlank_000.m3", 3878, "!NEW! Wooden Plank (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_Rope_000.m3", 3879, "!NEW! Hanging Rope", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_StraightPlatform_000.m3", 3880, "!NEW! Elevated Platform (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_StraightPlatform_001.m3", 3881, "!NEW! Elevated Platform (Short)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_TallSmallPlatform_000.m3", 3882, "!NEW! Elevated Platform (Short, End)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_TallStraightPlatform_000.m3", 3883, "!NEW! Elevated Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Desk\\Protostar\\PRP_Protostar_Desk_000.m3", 3884, "!NEW! Protostar Desk (Left)", DecorCategory.Tables, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Desk\\Protostar\\PRP_Protostar_Desk_001.m3", 3885, "!NEW! Protostar Desk (Right)", DecorCategory.Tables, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Defiance\\PRP_DefianceMilitary_TableControlPanel_000.m3", 3886, "!NEW! Data Panel (Exile)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Defiance\\PRP_DefianceMilitary_TableControlPanel_004.m3", 3887, "!NEW! Wall Panel (Exile, Inverted)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Marauder\\PRP_ControlPanel_Marauder_Platform_000.m3", 3888, "!NEW! Control Panel (Marauder)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Mechari\\PRP_mechari_iciinfocolumn_000.m3", 3889, "!NEW! Information Terminal (Mechari)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Osun\\PRP_ControlPanel_Osun_Lever_000.m3", 3890, "!NEW! Osun Lever", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Explorer_000.m3", 3891, "!NEW! Control Panel (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Base_Monitor_Standing_001.m3", 3892, "!NEW! Floor Panel (Dominion)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Screen_000.m3", 3893, "!NEW! Data Panel (Dominion)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Screen_001.m3", 3894, "!NEW! Dominion Monitor", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_Antenna_Pell_000.m3", 3895, "!NEW! Antenna (Pell)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_003.m3", 3896, "!NEW! Pell-Tech Device (Large)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_004.m3", 3897, "!NEW! Pell-Tech Device (Medium)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_005.m3", 3898, "!NEW! Pell-Tech Device (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_000.m3", 3899, "!NEW! Shiphand Console", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_MonitorOcular_000.m3", 3900, "!NEW! Shiphand Console (Ocular)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_MonitorSmallMid_000.m3", 3901, "!NEW! Shiphand Console (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_SixButtonWallMonitor_000.m3", 3902, "!NEW! Control Panel (Shiphand)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\Pell\\PRP_Jar_Pell_000.m3", 3903, "!NEW! Dubious Jar", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\Imperium\\PRP_Jar_Imperium_000.m3", 3904, "!NEW! Dominion Pot", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\PRP_Jar_SmugglerPearShaped_Red_000.m3", 3905, "!NEW! Jar (Ornate, Painted)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jetpack\\Jetpack.m3", 3906, "!NEW! Jetpack", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_QuestJobBoard_000.m3", 3907, "!NEW! Job Board (Adventuring)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_000.m3", 3908, "!NEW! Job Board (Engineering)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_001.m3", 3909, "!NEW! Job Board Panel", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_002.m3", 3910, "!NEW! Job Board Pole", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_003.m3", 3911, "!NEW! Mechanicbot Pole", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_004.m3", 3912, "!NEW! Job Board Panel (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\Weaponsmith\\PRP_Tradeskill_Weaponsmith_CraftingStation_000.m3", 3913, "!NEW! Crafting Station (Weapons)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\Generic\\PRP_Tradeskill_GenericTable_000.m3", 3914, "!NEW! Crafting Station", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Cap_000.m3", 3915, "!NEW! Eldan Circuit Cap", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Cap_001.m3", 3916, "!NEW! Eldan Circuit Cap (Advanced)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Tubes_000.m3", 3917, "!NEW! Eldan Pylon", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Tubes_Technophage_000.m3", 3918, "!NEW! Eldan Pylon (Technophage)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Pod_FuelRods_002.m3", 3919, "!NEW! Eldan Fuel Rod Cap", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Warplots\\PRP_Generator_Warplots_Widget_000.m3", 3920, "!NEW! Generator (Arkship)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Tribal\\PRP_Generator_Batteries_Tribal_000.m3", 3921, "!NEW! Fusion Battery", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Tribal\\PRP_Generator_Tribal_000.m3", 3922, "!NEW! Generator (Simple)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\PRP_ArkShip_GeneratorSmall_000.m3", 3923, "!NEW! Generator (Small, Arkship)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Drakken\\PRP_Drakken_Spike_Barier_000.m3", 3924, "!NEW! Draken Weapons", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Legendary\\PRP_Quest_Legendary_Maiden_000.m3", 3925, "!NEW! Sword (Torine, Floating)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\PRP_Quest_Lore_Paper_000.m3", 3926, "!NEW! Paper Note (Aged)", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\PRP_Quest_Lore_Scroll_000.m3", 3927, "!NEW! Paper Scroll", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\prp_quest_lore_paper_001.m3", 3928, "!NEW! Paper Note (Simple)", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\JonnyCab\\PRP_JonnyCab_000.m3", 3929, "!NEW! TaxiBot", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\JonnyCab\\PRP_JonnyCab_001.m3", 3930, "!NEW! TaxiBot (Hologram)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\TaxiKiosk\\PRP_Taxi_Kiosk_000.m3", 3931, "!NEW! Taxi Kiosk", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_000.m3", 3932, "!NEW! Open Metal Crate (Empty)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_001.m3", 3933, "!NEW! Relic Crate", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_004.m3", 3934, "!NEW! Science Crate", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_small_Toys_001.m3", 3935, "!NEW! Toy Crate", DecorCategory.Toys, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_FinishLine_GroundChecker_000.m3", 3936, "!NEW! Finish Line", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_HandSnowFrozen_Blue_000.m3", 3937, "!NEW! Lost Arm (Frozen)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Hand_000.m3", 3938, "!NEW! Lost Arm", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_HousingJobBoard_000.m3", 3939, "!NEW! Job Board (Roofed)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_000.m3", 3940, "!NEW! Teleporter", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_Eldan_000.m3", 3941, "!NEW! Teleporter (Eldan)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_Protostar_000.m3", 3942, "!NEW! Teleporter (Protostar)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Vendor_Generic_000.m3", 3943, "!NEW! Vendor Terminal", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Crate\\PRP_Quest_Crate_Blue_000.m3", 3944, "!NEW! Metal Crate (Blue)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Crate\\PRP_Quest_Crate_Gold_000.m3", 3945, "!NEW! Metal Crate (Golden)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_000.m3", 3946, "!NEW! Force Field", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_001.m3", 3947, "!NEW! Force Field (Low)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_Red_Emissive_000.m3", 3948, "!NEW! Forcefield, Red", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Garage_000.m3", 3949, "!NEW! Garage Door (Wooden)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Cellar\\PRP_CellarDoor_SancCommonDoor_000.m3", 3950, "!NEW! Cellar Door", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Drakken\\PRP_Door_DrakkenMetalGate_000.m3", 3951, "!NEW! Metal Gate (Draken)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_RobotSilo_000.m3", 3952, "!NEW! Eldan Silo Door", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_RobotSilo_Broken_000.m3", 3953, "!NEW! Eldan Silo Door (Broken)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_IrisEldanMicro_001.m3", 3954, "!NEW! Door (Eldan)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_LargeEldanDungeon_000.m3", 3955, "!NEW! Eldan Gate (Large)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_SmallEldanDungeon_000.m3", 3956, "!NEW! Eldan Gate (Small)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Ikthian\\PRP_Ikthian_Door_000.m3", 3957, "!NEW! Metal Door (Ikthian)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Imperium\\PRP_Door_ImperiumTower_Bottom_000.m3", 3958, "!NEW! Dominion Church Door, Style 1", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Imperium\\PRP_Door_ImperiumTower_Top_000.m3", 3959, "!NEW! Dominion Church Door, Style 2", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Marauder\\PRP_Door_CellDoorSML_000.m3", 3960, "!NEW! Door (Prison)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Marauder\\PRP_Door_RMC_Small_000.m3", 3961, "!NEW! Door (Marauder)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Minekit\\PRP_Door_AlgorocMineDoor_Brown_001.m3", 3962, "!NEW! Wooden Arch (Protostar)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Moodie\\PRP_Door_Frame_Moodie_002.m3", 3963, "!NEW! Elevated Brazier (Moodie)", DecorCategory.Lighting, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Osun\\PRP_Door_Osun_B_000.m3", 3964, "!NEW! Osun Stone Panel", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Osun\\PRP_Door_Osun_B_CinematicInteraction.m3", 3965, "!NEW! Osun Face Carving", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Protostar\\PRP_Door_Protostar_Metal_Large_000.m3", 3966, "!NEW! Garage Door (Protostar, Flat)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\ShipHand\\PRP_Shiphand_Door_000.m3", 3967, "!NEW! Metal Door (Shiphand)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\ShipHand\\PRP_Shiphand_Door_Airlock_000.m3", 3968, "!NEW! Airlock (Shiphand)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Berserker_000.m3", 3969, "!NEW! Hoverboard (Berserker)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Berserker_Customization_000.m3", 3970, "!NEW! Hoverboard (Berserker, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Fang_000.m3", 3971, "!NEW! Hoverboard (Fang)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Fang_Customization_000.m3", 3972, "!NEW! Hoverboard (Fang, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_GoGo_000.m3", 3973, "!NEW! Hoverboard (GoGo)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_GoGo_Customization_000.m3", 3974, "!NEW! Hoverboard (GoGo, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Ringer_000.m3", 3975, "!NEW! Hoverboard (Ringer)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Ringer_Customization_000.m3", 3976, "!NEW! Hoverboard (Ringer, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Turbine_000.m3", 3977, "!NEW! Hoverboard (Turbine)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Turbine_Customization_000.m3", 3978, "!NEW! Hoverboard (Turbine, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", 3979, "!NEW! Emblem (Dominion)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", 3980, "!NEW! Emblem (Exile)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_Bullseye_000.m3", 3981, "!NEW! Decal (Bullseye)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_Bullseye_001.m3", 3982, "!NEW! Decal (Bullseye 2)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_DarkspurSkull_000.m3", 3983, "!NEW! Decal (Darkspur)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_NuclearSign_000.m3", 3984, "!NEW! Decal (Nuclear)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Drakken\\PRP_MISC_DrakkenBonedStorage_000.m3", 3985, "!NEW! Ancestral Urn (Draken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Drakken\\PRP_MISC_DrakkenSpikedFooty_000.m3", 3986, "!NEW! Metal Boot Tip (Draken)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Eldan\\Dome\\PRP_Eldan_AKA_Core_000.m3", 3987, "!NEW! Eldan Core", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Eldan\\Dome\\PRP_Eldan_Dome_Broken_000.m3", 3988, "!NEW! Eldan Dome (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_000.m3", 3989, "!NEW! Coconut", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_001.m3", 3990, "!NEW! Coconut (Opened)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_003.m3", 3991, "!NEW! Coconut Pile", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_000.m3", 3993, "!NEW! Graffiti (Yellow-Violet Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_001.m3", 3994, "!NEW! Graffiti (Alien Head)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_002.m3", 3995, "!NEW! Graffiti (Yellow-Purple Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_003.m3", 3996, "!NEW! Graffiti (Teal Skull)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_004.m3", 3997, "!NEW! Graffiti (Green-White Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_005.m3", 3998, "!NEW! Graffiti (Magenta-Teal Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_Judge_Kain_000.m3", 3999, "!NEW! Graffiti (Judge Kain)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_Marauder_Grafitti_000.m3", 4000, "!NEW! Graffiti (Marauder)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_000.m3", 4001, "!NEW! Space Helm", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_001.m3", 4002, "!NEW! Space Helm (Draken)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_002.m3", 4003, "!NEW! Space Helm (Grumpel)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_TopHat_000.m3", 4004, "!NEW! Fancy Top Hat", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\KiddiePool\\PRP_KiddiePool_000.m3", 4005, "!NEW! Kiddie Pool", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Camera_Generic_001.m3", 4006, "!NEW! Security Camera", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_DoorKnocker_Granok.m3", 4007, "!NEW! Door Knocker (Granok)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Arms_000.m3", 4008, "!NEW! Mechari Spare Arms", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Legs_000.m3", 4009, "!NEW! Mechari Spare Legs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Torso_000.m3", 4010, "!NEW! Mechari Spare Torso", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Mechari_Head\\Mechari_Head_Female.m3", 4011, "!NEW! Mechari Head (Pink)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Mechari_Head\\PRP_Mechari_Head_Female_001.m3", 4012, "!NEW! Mechari Head (Red)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_MISC_PowerCell_000.m3", 4013, "!NEW! Power Cell", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Poodad.m3", 4014, "!NEW! Poodad", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Tire\\PRP_Misc_Tire_001.m3", 4015, "!NEW! Tire (Hollow)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_000.m3", 4016, "!NEW! Plain Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_002.m3", 4017, "!NEW! Striped Towel (Vertical)", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_004.m3", 4018, "!NEW! Invoker Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_005.m3", 4019, "!NEW! Fancy Green Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers.m3", 4020, "!NEW! Stadium Seating (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Cap.m3", 4021, "!NEW! Stadium Seating (Cap)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Half_000.m3", 4022, "!NEW! Stadium Seating", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Half_001.m3", 4023, "!NEW! Stadium Seating (Uncapped)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_000.m3", 4024, "!NEW! Ritual Pot (Pell, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_002.m3", 4025, "!NEW! Open Ritual Pot (Pell)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_003.m3", 4026, "!NEW! Open Ritual Pot (Pell, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\WorldDestroyer_Head_Destroyed.m3", 4027, "!NEW! Annihilator Head (Destroyed)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSLeftHorn_000.m3", 4028, "!NEW! Cyclopean Horn (Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSLeftJaw_000.m3", 4029, "!NEW! Cyclopean Jaw (Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSRightHorn_000.m3", 4030, "!NEW! Cyclopean Horn (Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSRightJaw_000.m3", 4031, "!NEW! Cyclopean Jaw (Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSSkull_000.m3", 4032, "!NEW! Cyclopean Skull", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GiantHornedSkull_000.m3", 4033, "!NEW! Cyclopean Horned Skull", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Bridge_A.m3", 4034, "!NEW! Osun Bridge", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Short_A.m3", 4035, "!NEW! Osun Tower (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Tall_A.m3", 4036, "!NEW! Osun Stone Tower (Adorned)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Tall_B.m3", 4037, "!NEW! Osun Stone Tower", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Detail_WolfHead_A.m3", 4038, "!NEW! Osun Wolf Tower", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Short_A.m3", 4039, "!NEW! Osun Gate", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Tall_A.m3", 4040, "!NEW! Osun Siege Gate ", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Tall_B.m3", 4041, "!NEW! Osun Siege Gate (Ramped)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Stairs_A.m3", 4042, "!NEW! Osun Stairs", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Stairs_B.m3", 4043, "!NEW! Osun Stairs (Wide)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_000.m3", 4044, "!NEW! Osun Walkway", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_A.m3", 4045, "!NEW! Osun Wall Segment (Slanted, In, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_B.m3", 4046, "!NEW! Osun Wall Segment (Slanted, In, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_C.m3", 4047, "!NEW! Osun Wall Segment (Slanted, Out, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_D.m3", 4048, "!NEW! Osun Wall Segment (Slanted, Out, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_E.m3", 4049, "!NEW! Osun Wall Segment", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Double_A.m3", 4050, "!NEW! Osun Siege Wall", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_CurveDouble_A.m3", 4051, "!NEW! Osun Siege Wall (Curved, Inward)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_CurveDouble_B.m3", 4052, "!NEW! Osun Siege Wall (Curved, Outward)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Half_A.m3", 4053, "!NEW! Osun Siege Wall Trim", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_A.m3", 4054, "!NEW! Osun Wall (Low)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_B.m3", 4055, "!NEW! Osun Wall (Low, Ramp)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_C.m3", 4056, "!NEW! Osun Wall (Low, Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Tall_B.m3", 4057, "!NEW! Osun Wall (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit_Ruins\\PRP_Osun_Entrance_Small.m3", 4058, "!NEW! Osun Entrance", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder_weapons_000.m3", 4059, "!NEW! Rocket Launcher (Exile, Small)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_001.m3", 4060, "!NEW! Bone Pile", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_002.m3", 4061, "!NEW! Bone Pile (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_003.m3", 4062, "!NEW! Bone Pile (Elongated)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanSkeleton_Tan_000.m3", 4063, "!NEW! Skeleton (Hanging)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanSkeleton_Tan_002.m3", 4064, "!NEW! Skull (Human, Screaming)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_HumanSkull_003.m3", 4065, "!NEW! Skull (Human, Angry)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\Dinosaur\\PRP_Bones_Dinosaur_Skull_000.m3", 4066, "!NEW! Giant Skull (Dinosaur)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_000.m3", 4067, "!NEW! Skull (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_001.m3", 4068, "!NEW! Skull (Roc, Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_002.m3", 4069, "!NEW! Skeletal Jaw (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_003.m3", 4070, "!NEW! Giant Ribcage (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_004.m3", 4071, "!NEW! Ribcage Bridge", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_005.m3", 4072, "!NEW! Ribcage Ramp", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_006.m3", 4073, "!NEW! Giant Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_007.m3", 4074, "!NEW! Giant Jaw Fragment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_DragonSkeleton_Jaw_Tan_000.m3", 4075, "!NEW! Dragon Skull (Jaw)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_DragonSkeleton_Skull_Tan_000.m3", 4076, "!NEW! Dragon Skull (Upper)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_EnvironmentHazard_Trap_000.m3", 4077, "!NEW! Rib Cluster", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_GirokSkullClean_Tan_000.m3", 4078, "!NEW! Skull (Girrok)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Hand_Large_Tan_000.m3", 4079, "!NEW! Giant Skeletal Hand", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegAnimalClean_Tan_000.m3", 4080, "!NEW! Bone", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegwithMeat_Tan_001.m3", 4081, "!NEW! Meaty Rib", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegwithMeat_Tan_002.m3", 4082, "!NEW! Meaty Bone", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LongBone_Large_Tan_000.m3", 4083, "!NEW! Bone (Massive)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_PumeraSkullClean_Tan_000.m3", 4084, "!NEW! Skull (Pumera)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RhinoSkull_Small_Tan_000.m3", 4085, "!NEW! Skull (Mammodin, Juvenile)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RhinoSkull_SquareHorn_Tan_000.m3", 4086, "!NEW! Skull (Mammodin, Adult)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_000.m3", 4087, "!NEW! Ribcage (Whole)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_001.m3", 4088, "!NEW! Ribcage (Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_002.m3", 4089, "!NEW! Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_004.m3", 4090, "!NEW! Ribs (Half, left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_005.m3", 4091, "!NEW! Ribs (Half, right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Hide_Large_Tan_000.m3", 4092, "!NEW! Giant Ribcage (Spiny, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Hide_Large_Tan_001.m3", 4093, "!NEW! Giant Ribcage (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_000.m3", 4094, "!NEW! Giant Ribcage (Spiny)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_001.m3", 4095, "!NEW! Giant Ribcage (Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_002.m3", 4096, "!NEW! Giant Ribcage (Half, Collapsed)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_hide_Large_Tan_000.m3", 4097, "!NEW! Giant Ribcage (Spiny, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsEarthrender_Large_Tan_000.m3", 4098, "!NEW! Giant Ribcage (Earth-Render)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_000.m3", 4099, "!NEW! Ribcage (Whole, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_001.m3", 4100, "!NEW! Ribcage (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_002.m3", 4101, "!NEW! Ribs (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_003.m3", 4102, "!NEW! Human Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_000.m3", 4103, "!NEW! Ribs (Half, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_001.m3", 4104, "!NEW! Ribcage (Half, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_002.m3", 4105, "!NEW! Ribcage (Whole, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_SingleRib_Large_Tan_000.m3", 4106, "!NEW! Giant Rib", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Skull_BirdLikeWithTeath_Tan_000.m3", 4107, "!NEW! Skull (Giant Pirahna)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Skull_RhinoWithTeath_Tan_000.m3", 4108, "!NEW! Skull (Rhino, Tusks)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_SpineAnimalClean_Tan_000.m3", 4109, "!NEW! Misplaced Spine", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_000.m3", 4110, "!NEW! Fishing Line", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_001.m3", 4111, "!NEW! Hanging Fish (Clustered)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_002.m3", 4112, "!NEW! Hanging Fish (Spread)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_003.m3", 4113, "!NEW! Fish Carcasses (Clustered)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_004.m3", 4114, "!NEW! Fish Carcasses (Spread)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_005.m3", 4115, "!NEW! Fish Skeleton", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_006.m3", 4116, "!NEW! Fish Carcass", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_003.m3", 4117, "!NEW! Weapon Rack (Draken, Empty)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\ToolShed\\PRP_Tools_shedgenericwood_brownrust_000.m3", 4118, "!NEW! Tool Shed (Table)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\ToolShed\\PRP_Tools_shedgenericwood_brownrust_001.m3", 4119, "!NEW! Tool Shed", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\TorineDungeon\\PRP_Water_TorineDungeon_001.m3", 4120, "!NEW! Pool of Blood", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_OGE.m3", 4121, "!NEW! Lava Eruption (Line)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_noDecal_OGE.m3", 4122, "!NEW! Lava Eruption (Line, Scorching)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Impacts\\Lava_Splash\\Lava_Splash_OGE.m3", 4123, "!NEW! Lava Splash", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_10mR.m3", 4124, "!NEW! Lava Spring (Large)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_5mR.m3", 4125, "!NEW! Lava Spring (Medium)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_10mR.m3", 4126, "!NEW! Lava Bubbles (Large, Ring)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_15mR.m3", 4127, "!NEW! Lava Bubbles (Medium, Ring)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_10mR.m3", 4128, "!NEW! Lava Pool (Large, Grounded)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_3mR.m3", 4129, "!NEW! Lava Pool (Small, Bubbling)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR.m3", 4130, "!NEW! Lava Pool (Medium)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_AQU.m3", 4131, "!NEW! Lava Pool (Medium, Teal)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_GLD.m3", 4132, "!NEW! Lava Pool (Medium, Gold)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_3mR.m3", 4133, "!NEW! Lava Bubbles (Small)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_5mR.m3", 4134, "!NEW! Lava Bubbles (Medium, Grounded)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_NoGrndConst_5mR.m3", 4135, "!NEW! Lava Bubbles (Medium)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGrndConst_10mR.m3", 4136, "!NEW! Lava Pool (Large)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Wave\\Lava_Wave.m3", 4137, "!NEW! Lava Bubbles (Violent, Line)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_Eruption_2mR_4mH_OGE.m3", 4138, "!NEW! Lava Burst (Scorching)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_LinearEruption_2mR_4mH_NoDecal_OGE.m3", 4139, "!NEW! Lava Burst", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Geyser\\Lava_Geyser_OGE.m3", 4140, "!NEW! Lava Geyser", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Prop\\Dungeon\\Datascape\\LavaRock\\PRP_Datascape_LavaRock_000.m3", 4141, "!NEW! Volcanic Rock", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Islands\\PRP_SkymapIsland_Lava_Terrain_000.m3", 4142, "!NEW! Lava Terrain Slab", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_000.m3", 4143, "!NEW! Lavafall (Small)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_001.m3", 4144, "!NEW! Lavafall (Tall)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_002.m3", 4145, "!NEW! Lava Pool (Small)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_002.m3", 4146, "!NEW! Lava Blob", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_004.m3", 4147, "!NEW! Lava Chunk", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_Tall_001.m3", 4148, "!NEW! Lava Blob (Tall)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood1n2\\Blood1n2.m3", 4149, "!NEW! Blood Magic (Pulsing)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_01.m3", 4150, "!NEW! Blood Magic", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Channels\\Siphon\\Siphon.m3", 4151, "!NEW! Blood Siphon", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Channels\\Siphon\\Siphon_12.m3", 4152, "!NEW! Orange Glow", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Double_Vertical\\Double_Vertical.m3", 4153, "!NEW! Blood Explosion", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Gib\\Gib_14.m3", 4154, "!NEW! Blood Burst (Messy)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Hit_Default\\Hit_Default_14.m3", 4155, "!NEW! Blood Burst", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Pumera_Pounce\\Pumera_Pounce_14.m3", 4156, "!NEW! Blood Spray (Intermediate)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Pumera_Pounce\\Pumera_Pounce_14_GRN.m3", 4157, "!NEW! Blood Spray (Intermediate, Green)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Slash_Horizontal\\Slash_Horizontal_14.m3", 4158, "!NEW! Blood Squirt", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Slash_Spray\\Slash_Spray.m3", 4159, "!NEW! Blood Spray (Intermediate, Large)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Vulcarrion_Divebomb\\Vulcarrion_Divebomb_14.m3", 4160, "!NEW! Blood Burst (Small)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Default\\Default_14.m3", 4161, "!NEW! Gushing Blood (Messy)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Slash_Wound\\Slash_Wound.m3", 4162, "!NEW! Gushing Blood (Downward)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Spray_Vertical\\Spray_Vertical.m3", 4163, "!NEW! Blood Spray (Continuous)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Squirt_01\\Squirt_01_14.m3", 4164, "!NEW! Blood Squirt (Alternate)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Water\\Ocean\\Water_Ocean_WaveCircle_000.m3", 4165, "!NEW! Water Surface", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Water\\Ocean\\Water_Ocean_WaveShoreline_000.m3", 4166, "!NEW! Ocean Waves", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Corner_A.m3", 4167, "!NEW! Osun Walkway (Corner)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Curve_A.m3", 4168, "!NEW! Osun Walkway (Curved, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Curve_B.m3", 4169, "!NEW! Osun Walkway (Curved, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Long_A.m3", 4170, "!NEW! Osun Walkway (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Ramp_A.m3", 4171, "!NEW! Osun Ramp", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Short_A.m3", 4172, "!NEW! Osun Walkway (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_SlopeLong_A.m3", 4173, "!NEW! Osun Sloped Walk way (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_SlopeShort_A.m3", 4174, "!NEW! Osun Sloped Walk way", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_A_000.m3", 4175, "!NEW! Osun Support Arch", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_B.m3", 4176, "!NEW! Osun Support Strut", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_C.m3", 4177, "!NEW! Osun Anvil Sculpture", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\Elemental\\PRP_Bones_Elemental_000.m3", 4178, "!NEW! Elemental Remnants", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_ShortAxe_000.m3", 4179, "!NEW! Draken War Axe (Short)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_ShortAxe_001.m3", 4180, "!NEW! Draken War Axe (Long)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_Spear_000.m3", 4181, "!NEW! Serrated Spear", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\PRP_WeaponRack_ImperiumFreeStanding_Black_000.m3", 4182, "!NEW! Dominion Weapon Rack", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\PRP_Vending_GranokBeer_000.m3", 4183, "!NEW! Vending Machine (Granok Beer)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\AbilityVendor\\PRP_Vending_AbilityVendor_000.m3", 4184, "!NEW! BoxerBot", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\Chua\\PRP_Building_ChuaShop_000.m3", 4185, "!NEW! Chua Shop", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Speaker\\Generic\\PRP_Speaker_Generic_Grey_000.m3", 4186, "!NEW! Speaker (Small)", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Speaker\\Marauder\\PRP_Speaker_MarauderSpeaker_000.m3", 4187, "!NEW! Speaker (Marauder)", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_007.m3", 4188, "!NEW! Draken Horn (Curved, Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_008.m3", 4189, "!NEW! Draken Horn (Curved, Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_009.m3", 4190, "!NEW! Draken Horn (Painted, Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_010.m3", 4191, "!NEW! Draken Horn (Painted, Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_011.m3", 4192, "!NEW! Draken Horn (Painted, Short)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_012.m3", 4193, "!NEW! Draken Horn (Curved, Gilded)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_013.m3", 4194, "!NEW! Draken Horn (Gilded)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Horn_DrakkenLSupported_000.m3", 4195, "!NEW! Draken War Horn", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Book\\BookOfDominus\\PRP_Book_BookofDominus_000.m3", 4196, "!NEW! Invoker's Grimoire", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Fence\\Protostar\\PRP_Fence_ProtostarSpaceGeneric_003.m3", 4197, "!NEW! Metal Pole", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\CampFire\\PRP_CampFire_Generic_RedGrey_001.m3", 4198, "!NEW! Campfire (Large)", DecorCategory.Lighting, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\CampFire\\PRP_CampFire_Generic_RedGrey_002.m3", 4199, "!NEW! Bonfire", DecorCategory.Lighting, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Ship\\GeneralCargoShip\\PRP_Ship_GeneralCargoShip_000.m3", 4200, "!NEW! Piglet Ship", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Ship\\GeneralCargoShip\\PRP_Ship_GeneralCargoShip_001.m3", 4201, "!NEW! Piglet Ship (Dark)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vent\\PRP_Vent_Big_RMC_000.m3", 4202, "!NEW! Redmoon Ship Vent", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", 4203, "!NEW! Ship Tech Panel (Round)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_001.m3", 4204, "!NEW! Ship Tech Panel (Flat)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_002.m3", 4205, "!NEW! Ship Support Strut", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Engine_005.m3", 4206, "!NEW! Fighter Ship Engine", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Light_002.m3", 4207, "!NEW! Fighter Ship Light", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Left_002.m3", 4208, "!NEW! Fighter Ship Wing (Left)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Right_002.m3", 4209, "!NEW! Fighter Ship Wing (Right)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Water_GenericPool_000.m3", 4210, "!NEW! Hot Springs Pool (Bright)", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Water_Grimvault_Bubbles_000.m3", 4211, "!NEW! Glowing Purple Bubble", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Waterfall_NPE_000.m3", 4212, "!NEW! Waterfall (Triple)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\SunkenShip\\PRP_Water_SunkenShip_000.m3", 4213, "!NEW! Pool (Hard-edged)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\TorineDungeon\\PRP_Water_TorineDungeon_000.m3", 4214, "!NEW! Pool (Oddly Shaped)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Sanctuary_Common\\Galeras_Kit\\Windmill\\PRP_Building_SCGalerasWindmill_001.m3", 4215, "!NEW! Windmill Tower (Geleras)", DecorCategory.Structures, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MedicalStation\\PRP_MedicalStation_FloatingMedCross_000.m3", 4216, "!NEW! Holographic Medical Sign", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\PellTech\\BrokenPieces\\PRP_PellTech_BrokenPiecesJunk_Aqua_000.m3", 4217, "!NEW! Pell-Tech Fragment", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\PellTech\\BrokenAntenna\\PRP_PellTech_BrokenAntenna_000.m3", 4218, "!NEW! Broken Antenna (Pell-Tech)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Mount\\Hoverboard\\Hoverboard_Default\\HoverBoard_Default.m3", 4219, "!NEW! Hoverboard (Flux)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\DominionHoverBike\\Mount_DominionHoverBike.m3", 4220, "!NEW! Uniblade", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Flying\\Glider\\Mount_Glider_000.m3", 4221, "!NEW! Glider", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Flying\\Puffy_Cat\\PuffyCat.m3", 4222, "!NEW! Snarfelynx", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Ball\\Orbitron\\Mount_Ball_Orbitron_000.m3", 4223, "!NEW! Orbitron Frame", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Boat\\Mount_Vehicle_Boat.m3", 4224, "!NEW! Marauder Starsloop", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_ProtoStarEnforcer\\Mount_Vehicle_ProtoStarEnforcer.m3", 4225, "!NEW! Protostar Spiderbot", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Skiff\\Mount_Vehicle_Skiff_Marauder.m3", 4226, "!NEW! Marauder Skiff", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Chua\\PRP_Mount_Chua_000.m3", 4227, "!NEW! Orbitron", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder.m3", 4228, "!NEW! Grinder (Exile)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DarkspurSpeeder.m3", 4229, "!NEW! Grinder (Darkspur)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder_001.m3", 4230, "!NEW! Grinder (Exile, Armed)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Metal_Tech_000.m3", 4231, "!NEW! Metal Tech Platform", DecorCategory.BuildingBlocks, false, 2);


            SaveTables("../../../../TblNormal/");

            // BETA YOLO MOOOODE
            betaMode = true;


            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_Splatter_Decal\\Blood_Splatter_Decal.m3", 4232, "Blood Splatter HoloDecal", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_Splatter_Decal\\Blood_Splatter_Decal_GRN.m3", 4233, "Blood Splatter HoloDecal (Green)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Black\\OT\\Splatter_Decal\\Blood_Splatter_Decal_01.m3", 4234, "Blood Splatter (Black)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_01.m3", 4235, "Blood Splatter", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_02.m3", 4236, "Blood Stains", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_02_GRN.m3", 4237, "Blood Stains (Green)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MineWoodBundle_Red_001.m3", 4238, "Cable (Coiled, Empty)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_Caustics.m3", 4239, "Point Light (Caustic, Animated)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_LavaTube.m3", 4240, "Point Light (Lava Tube, Moving)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Hard_Bright_Pulse.m3", 4241, "Point Light (Bright, Slow Pulse)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Med_Flicker.m3", 4242, "Point Light (Bright, Flickering)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Med_Throb.m3", 4243, "Point Light (Fast Pulse)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Drusera_GlowCone_000.m3", 4244, "Volumetric Light (Column)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Rays_LongNarrow_000.m3", 4245, "Volumetric Light (Sphere)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Rays_MediumWide_000.m3", 4246, "Volumetric Light (Sphere, Bright)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_20Man.m3", 4247, "Directional Light (Blue, Dappled)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_IcyPeak.m3", 4248, "Point Light (Bright, Dappled, Blue)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_IcyPeakPlatforms.m3", 4249, "Point Light (Bright, Pale Green)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_RMT_Shredder.m3", 4250, "Directional Light (Orange, Stops at Gizmo)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_Anim_Point_AuroriaAdventureFire_000.m3", 4251, "Point Light (Soft, Orange)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_Design_DatacoreElemental_Point_Med_000.m3", 4252, "Point Light (Soft, Pale Blue)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_Point_5m_Blue_000.m3", 4253, "Point Light (Soft, Blue)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_000.m3", 4254, "Spot Light (Ground Target, Highlight)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_001.m3", 4255, "Spot Light (Highlight)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_HeadLight_000.m3", 4256, "Spot Light (Volumetric, Flickering)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\Light_HalonRing_RotatingAstroid_000.m3", 4257, "Spot Light (Search Light)", DecorCategory.LightSource, true);
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
            AddGenericDecor("Art\\Prop\\Natural\\Fog\\PRP_Fog_GroundCover_000.m3", null, "Fog_Groundcover", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Twisted_Climbing_Mossy\\PRP_Tree_Twisted_Climbing_Moss_Gray_000.m3", null, "Climbing Tree_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Twisted_Climbing_Mossy\\PRP_Tree_Twisted_Climbing_Moss_Gray_001.m3", null, "Climbing Tree_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Twisted_Climbing_Mossy\\PRP_Tree_Twisted_Climbing_Moss_Gray_002.m3", null, "Climbing Tree_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Large_umberla_Pine\\PRP_Tree_LargeUmberla_LargePine_000.m3", null, "UmbrellaPineLarge_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Large_umberla_Pine\\PRP_Tree_LargeUmberla_LargePine_001.m3", null, "UmbrellaPineLarge_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Large_umberla_Pine\\PRP_Tree_LargeUmberla_LargePine_002.m3", null, "UmbrellaPineLarge_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Large_umberla_Pine\\PRP_Tree_LargeUmberla_MidPine_000.m3", null, "UmbrellaPineMid", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_000.m3", null, "Tree_LifeInfused", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_001.m3", null, "Tree_LifeInfused", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_002.m3", null, "Tree_LifeInfused", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_000.m3", null, "Tree of Life", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentDefense_000.m3", null, "TreeofLife_CD", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentOffense_000.m3", null, "TreeofLife_CO", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentReward_000.m3", null, "TreeofLife_CR", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_000.m3", null, "TreeofLife_Root_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_001.m3", null, "TreeofLife_Root_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_002.m3", null, "TreeofLife_Root_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_003.m3", null, "TreeofLife_Root_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_004.m3", null, "TreeofLife_Root_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_005.m3", null, "TreeofLife_Root_005", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_006.m3", null, "TreeofLife_Root_006", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_007.m3", null, "TreeofLife_Root_007", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_008.m3", null, "TreeofLife_Root_008", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_009.m3", null, "TreeofLife_Root_009", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Canopy_Dead_RootyMangrove_Brown_000.m3", null, "Mangrove_Brown_Canopy", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangroveFallen_Brown_001.m3", null, "Mangrove_Brown_Fallen", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_000.m3", null, "Mangrove_Brown_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_001.m3", null, "Mangrove_Brown_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_002.m3", null, "Mangrove_Brown_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_003.m3", null, "Mangrove_Brown_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_004.m3", null, "Mangrove_Brown_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_000.m3", null, "Rock_Swirl_L_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_001.m3", null, "Rock_Swirl_L_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_002.m3", null, "Rock_Swirl_L_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_003.m3", null, "Rock_Swirl_L_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_000.m3", null, "Rock_Swirl_M_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_001.m3", null, "Rock_Swirl_M_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_002.m3", null, "Rock_Swirl_M_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_003.m3", null, "Rock_Swirl_M_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_000.m3", null, "Rock_Swirl_S_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_001.m3", null, "Rock_Swirl_S_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_002.m3", null, "Rock_Swirl_S_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_003.m3", null, "Rock_Swirl_S_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_000.m3", null, "Rock_Obsidian_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_001.m3", null, "Rock_Obsidian_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_002.m3", null, "Rock_Obsidian_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_004.m3", null, "Rock_Obsidian_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_005.m3", null, "Rock_Obsidian_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_006.m3", null, "Rock_Obsidian_005", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_007.m3", null, "Rock_Obsidian_006", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_008.m3", null, "Rock_Obsidian_007", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Primal\\PRP_Rock_Primal_EarthCrystal_000.m3", null, "Primal Earth Crystal", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_000.m3", null, "Rocks_Creepy_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_001.m3", null, "Rocks_Creepy_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_002.m3", null, "Rocks_Creepy_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_003.m3", null, "Rocks_Creepy_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_004.m3", null, "Rocks_Creepy_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_000.m3", null, "Rocks_Wire_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_001.m3", null, "Rocks_Wire_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_002.m3", null, "Rocks_Wire_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_003.m3", null, "Rocks_Wire_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_004.m3", null, "Rocks_Wire_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_000.m3", null, "Rocks_Stonehenge_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_001.m3", null, "Rocks_Stonehenge_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_002.m3", null, "Rocks_Stonehenge_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_003.m3", null, "Rocks_Stonehenge_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_004.m3", null, "Rocks_Stonehenge_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Whitevale_Crater\\PRP_Rock_Whitevale_Crater_000.m3", null, "Floating Crater", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_000.m3", null, "Slimefall (Black)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_001.m3", null, "Slime Blob (Black, Large)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_002.m3", null, "Slimefall (Black, Tall)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_003.m3", null, "Slimefall (Black, Tall Vertical)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_004.m3", null, "Slimefall (Black, Short Vertical)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_005.m3", null, "Hanging Slime (Black)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_006.m3", null, "Hanging Slime (Black, Huge)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_007.m3", null, "Hanging Slimefall (Black)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_008.m3", null, "Slime Blob (Black)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_009.m3", null, "Slime Web", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_Floor_000.m3", null, "Slime Pool (Black)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Soulfrost\\PRP_Natural_Slime_SoulfrostFloor_000.m3", null, "Soulfrost_Floor", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMedium_GreenDark_000.m3", null, "Skug Slime (Medium, Style 1)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMedium_GreenDark_001.m3", null, "Skug Slime (Medium, Style 2)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_000.m3", null, "Skug Slime (Mini, Style 1)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_001.m3", null, "Skug Slime (Mini, Style 2)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_002.m3", null, "Skug Slime (Mini, Style 3)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_003.m3", null, "Skug Slime (Mini, Style 4)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_000.m3", null, "Skug Slime (Small, Style 1)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_001.m3", null, "Skug Slime (Small, Style 2)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_002.m3", null, "Skug Slime (Small, Style 3)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_003.m3", null, "Skug Slime (Small, Style 4)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_004.m3", null, "Skug Slime (Small, Style 5)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_005.m3", null, "Skug Slime (Small, Style 6)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_006.m3", null, "Skug Slime (Small, Style 7)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_007.m3", null, "Skug Slime (Small, Style 8)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_008.m3", null, "Skug Slime (Small, Style 9)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_009.m3", null, "Skug Slime (Small, Style 10)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_000.m3", null, "MudCube_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_001.m3", null, "MudCube_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_002.m3", null, "MudCube_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_000.m3", null, "Slimefall (Honey)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_001.m3", null, "Slimefall (Honey, Split)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_002.m3", null, "Hanging Slime (Honey, Huge)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_003.m3", null, "Hanging Slime (Honey, Ledge)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_004.m3", null, "Hanging Slimefall (Honey)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_005.m3", null, "Hanging Slime (Honey, Broad)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_006.m3", null, "Hanging Slime (Honey, Large)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_007.m3", null, "Slime Blob (Honey)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_008.m3", null, "Hanging Slime (Honey, Drop)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_009.m3", null, "Hanging Slime (Honey)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_010.m3", null, "Hanging Slime (Honey, Split)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_011.m3", null, "Hanging Slime (Honey, Long)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_012.m3", null, "Hanging Slime (Honey, Extra Long)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_013.m3", null, "Hanging Slime (Honey, Thin)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_014.m3", null, "Hanging Slime (Honey, Extra Long Split)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_015.m3", null, "Slime Blob (Honey, Small)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_000.m3", null, "Slime_Tar_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_001.m3", null, "Slime_Tar_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_002.m3", null, "Slime_Tar_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_003.m3", null, "Slime_Tar_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_004.m3", null, "Slime_Tar_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_005.m3", null, "Slime_Tar_005", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_006.m3", null, "Slime_Tar_006", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_007.m3", null, "Slime_Tar_007", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_008.m3", null, "Slime_Tar_008", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_009.m3", null, "Slime_Tar_009", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_010.m3", null, "Slime_Tar_010", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_011.m3", null, "Slime_Tar_011", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\Tar_PPL\\PRP_Natural_Slime_Tar_PPL_004.m3", null, "Slime Blob (Purple, Small)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_000.m3", null, "Slimefall (Tech)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_001.m3", null, "Slimefall (Tech, Split)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_002.m3", null, "Hanging Slime (Tech, Huge)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_004.m3", null, "Hanging Slimefall (Tech)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_005.m3", null, "Hanging Slime (Tech, Wide)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_006.m3", null, "Hanging Slime (Tech, Large)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_007.m3", null, "Slime Blob (Tech)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_008.m3", null, "Hanging Slime (Tech, Drop)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_009.m3", null, "Hanging Slime (Tech)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_011.m3", null, "Hanging Slime (Tech, Long)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_012.m3", null, "Hanging Slime (Tech, Extra Long)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_013.m3", null, "Hanging Slime (Tech, Thin)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_014.m3", null, "Hanging Slime (Tech, Extra Long Split)", DecorCategory.Accents, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_000.m3", null, "LiquidM_Waterfall_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_001.m3", null, "LiquidM_Waterfall_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_002.m3", null, "LiquidM_Waterfall_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_000.m3", null, "LiquidM_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_001.m3", null, "LiquidM_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_002.m3", null, "LiquidM_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_003.m3", null, "LiquidM_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_004.m3", null, "LiquidM_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_005.m3", null, "LiquidM_005", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_006.m3", null, "LiquidM_006", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_007.m3", null, "LiquidM_007", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_008.m3", null, "LiquidM_008", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_009.m3", null, "LiquidM_009", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_010.m3", null, "LiquidM_010", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_011.m3", null, "LiquidM_011", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_000.m3", null, "Slime_Toxic_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_001.m3", null, "Slime_Toxic_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_002.m3", null, "Slime_Toxic_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\Keepfish\\PRP_Water_Keepfish_000.m3", null, "Water_Keepfish", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_000.m3", null, "DeraduneLargeWaterfall_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_001.m3", null, "DeraduneLargeWaterfall_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_Mist_000.m3", null, "DeraduneLargeWaterfall_Mist", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneSmallWaterfall_000.m3", null, "DeraduneSmallWaterfall", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_Foam_000.m3", null, "Foam", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_MistFX_000.m3", null, "MistFX_000", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_MistFX_001.m3", null, "MistFX_001", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_RippleFX_000.m3", null, "RippleFX", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_SplashFX_000.m3", null, "SplashFX", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_Turbulence_000.m3", null, "Turbulence", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_000.m3", null, "Water_Wilderrun_LargeTiered_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_001.m3", null, "Water_Wilderrun_LargeTiered_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_002.m3", null, "Water_Wilderrun_LargeTiered_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_003.m3", null, "Water_Wilderrun_LargeTiered_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_004.m3", null, "Water_Wilderrun_LargeTiered_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_TempleFalls_000.m3", null, "Water_Wilderrun_TempleFalls_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_TempleFalls_Corrupted_000.m3", null, "Water_Wilderrun_TempleFalls_Corrupted", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyerBot_All.m3", null, "Annihilator Robot", DecorCategory.Special, false);
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
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_OrbitingFlames\\Fire_OrbitingFlames_OGE.m3", null, "Caster\\Fire_Orbiting", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Structure\\Design_Layout\\Eastern\\Algeroc\\STR_Building_SCMedArmorShop_Tan_Background_AP_000.m3", null, "Cozy Exile House (Armored)", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Islands\\PRP_SkymapIsland_Water_Terrain_000.m3", null, "Ice Terrain Slab", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_Battlebot_Head_000.m3", null, "Battlebot_Head", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotCore_000.m3", null, "RobotCore", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotFoot_Grey_000.m3", null, "RobotFoot_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHangingWire_000.m3", null, "RobotHangingWire", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHead_000.m3", null, "RobotHead", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHead_Grey_000.m3", null, "RobotHead_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHips_Grey_000.m3", null, "RobotHips_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftArm_000.m3", null, "RobotLeftArm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftArm_Grey_000.m3", null, "RobotLeftArm_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLeg_Grey_000.m3", null, "RobotLeftLeg_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerArm_000.m3", null, "RobotLeftLowerArm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerArm_Grey_000.m3", null, "RobotLeftLowerArm_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerLeg_Grey_000.m3", null, "RobotLeftLowerLeg_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperArm_000.m3", null, "RobotLeftUpperArm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperArm_Grey_000.m3", null, "RobotLeftUpperArm_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperLeg_Grey_000.m3", null, "RobotLeftUpperLeg_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightArm_000.m3", null, "RobotRightArm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightArm_Grey_000.m3", null, "RobotRightArm_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLeg_Grey_000.m3", null, "RobotRightLeg_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerArm_000.m3", null, "RobotRightLowerArm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerArm_Grey_000.m3", null, "RobotRightLowerArm_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerLeg_Grey_000.m3", null, "RobotRightLowerLeg_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperArm_000.m3", null, "RobotRightUpperArm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperArm_Grey_000.m3", null, "RobotRightUpperArm_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperLeg_Grey_000.m3", null, "RobotRightUpperLeg_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotShoulder_Grey_000.m3", null, "RobotShoulder_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotTorso_000.m3", null, "RobotTorso", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotTorso_Grey_000.m3", null, "RobotTorso_Grey", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_000.m3", null, "RobotWhole", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_Grey_000.m3", null, "RobotWhole_Grey_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_Grey_001.m3", null, "RobotWhole_Grey_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWire_000.m3", null, "RobotWire", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Arm_000.m3", null, "Warbot_Arm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Head_000.m3", null, "Warbot_Head", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Leg_000.m3", null, "Warbot_Leg", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Pauldron_000.m3", null, "Warbot_Pauldron", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Torso_000.m3", null, "Warbot_Torso", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyerBot_Head.m3", null, "Destroyer_Head", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_JetPack.m3", null, "Destroyer_JetPack", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Left_Arm.m3", null, "Destroyer_Left_Arm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Left_Leg.m3", null, "Destroyer_Left_Leg", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Right_Arm.m3", null, "Destroyer_Right_Arm", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Right_Leg.m3", null, "Destroyer_Right_Leg", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Torso_001.m3", null, "Destroyer_Torso_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Torso_002.m3", null, "Destroyer_Torso_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Waist.m3", null, "Destroyer_Waist", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\WorldDestroyer_CrimsonIsle_Destroyed.m3", null, "Destroyer_Destroyed", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_A.m3", null, "Roof_Aurin_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_B.m3", null, "Roof_Aurin_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_C.m3", null, "Roof_Aurin_Medium_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_D.m3", null, "Roof_Aurin_Medium_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_A.m3", null, "Roof_Aurin_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_B.m3", null, "Roof_Aurin_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_C.m3", null, "Roof_Aurin_Small_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianMedium_A.m3", null, "Roof_Cassian_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianMedium_B.m3", null, "Roof_Cassian_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianSmall_A.m3", null, "Roof_Cassian_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianSmall_B.m3", null, "Roof_Cassian_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_A.m3", null, "Roof_Chua_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_B.m3", null, "Roof_Chua_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_C.m3", null, "Roof_Chua_Medium_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_A.m3", null, "Roof_Chua_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_B.m3", null, "Roof_Chua_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_C.m3", null, "Roof_Chua_Small_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Medium_A.m3", null, "Roof_Draken_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Medium_B.m3", null, "Roof_Draken_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Small_A.m3", null, "Roof_Draken_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Small_B.m3", null, "Roof_Draken_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileMedium_A.m3", null, "Roof_Exile_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileMedium_B.m3", null, "Roof_Exile_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileSmall_A.m3", null, "Roof_Exile_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileSmall_B.m3", null, "Roof_Exile_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_A.m3", null, "Roof_Bird_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_B.m3", null, "Roof_Bird_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_C.m3", null, "Roof_Bird_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokMedium_A.m3", null, "Roof_Granok_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokMedium_B.m3", null, "Roof_Granok_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_A.m3", null, "Roof_Granok_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_B.m3", null, "Roof_Granok_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_C.m3", null, "Roof_Granok_Small_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_A.m3", null, "Roof_Osun_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_B.m3", null, "Roof_Osun_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_C.m3", null, "Roof_Osun_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_A.m3", null, "Entry_Aurin_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_B.m3", null, "Entry_Aurin_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_C.m3", null, "Entry_Aurin_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_D.m3", null, "Entry_Aurin_D", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_A.m3", null, "Entry_Aurin_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_B.m3", null, "Entry_Aurin_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_C.m3", null, "Entry_Aurin_Medium_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_D.m3", null, "Entry_Aurin_Medium_D", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_A.m3", null, "Entry_Cassian_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_B.m3", null, "Entry_Cassian_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_C.m3", null, "Entry_Cassian_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_ClosedBack_B.m3", null, "Entry_Cassian_ClosedBack", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_A.m3", null, "Entry_Cassian_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_B.m3", null, "Entry_Cassian_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_C.m3", null, "Entry_Cassian_Small_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_ClosedBack_B.m3", null, "Entry_Cassian_Small_ClosedBack", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_A.m3", null, "Entry_Chua_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_B.m3", null, "Entry_Chua_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_C.m3", null, "Entry_Chua_Medium_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_Chuasmall_A.m3", null, "Entry_Chua_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_Chuasmall_B.m3", null, "Entry_Chua_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_Chuasmall_C.m3", null, "Entry_Chua_Small_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_A.m3", null, "Entry_Draken_Medium_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_B.m3", null, "Entry_Draken_Medium_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_C.m3", null, "Entry_Draken_Medium_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_A.m3", null, "Entry_Draken_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_B.m3", null, "Entry_Draken_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_c.m3", null, "Entry_Draken_Small_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_A.m3", null, "Entry_Exile_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_B.m3", null, "Entry_Exile_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_C.m3", null, "Entry_Exile_Small_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_A.m3", null, "Entry_Exile_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_B.m3", null, "Entry_Exile_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_C.m3", null, "Entry_Exile_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_A.m3", null, "Entry_Bird_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_B.m3", null, "Entry_Bird_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_C.m3", null, "Entry_Bird_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_A.m3", null, "Entry_Granok_Small_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_A_Clean.m3", null, "Entry_Granok_Small_A_Clean", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_B.m3", null, "Entry_Granok_Small_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_B_Clean.m3", null, "Entry_Granok_Small_B_Clean", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_C.m3", null, "Entry_Granok_Small_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_C_Clean.m3", null, "Entry_Granok_Small_C_Clean", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_D.m3", null, "Entry_Granok_Small_D", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_D_Clean.m3", null, "Entry_Granok_Small_D_Clean", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_A.m3", null, "Entry_Granok_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_A_Clean.m3", null, "Entry_Granok_A_Clean", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_B.m3", null, "Entry_Granok_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_B_Clean.m3", null, "Entry_Granok_B_Clean", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_C.m3", null, "Entry_Granok_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_C_clean.m3", null, "Entry_Granok_C_Clean", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_A.m3", null, "Entry_Osun_A", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_B.m3", null, "Entry_Osun_B", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_C.m3", null, "Entry_Osun_C", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Space\\PRP_Entry_Space_Small_A.m3", null, "Entry_Space", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Animated_AsteroidField_000.m3", null, "AsteroidField_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_000.m3", null, "AsteroidField_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_001.m3", null, "AsteroidField_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_002.m3", null, "AsteroidField_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_003.m3", null, "AsteroidField_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_000.m3", null, "MoorRock_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_001.m3", null, "MoorRock_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_002.m3", null, "MoorRock_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_003.m3", null, "MoorRock_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_004.m3", null, "MoorRock_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_005.m3", null, "MoorRock_005", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_006.m3", null, "MoorRock_006", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_007.m3", null, "MoorRock_007", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_000.m3", null, "RottersBeltCrystal_Green_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_001.m3", null, "RottersBeltCrystal_Green_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_002.m3", null, "RottersBeltCrystal_Green_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_003.m3", null, "RottersBeltCrystal_Green_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_004.m3", null, "RottersBeltCrystal_Green_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Orange_002.m3", null, "RottersBeltCrystal_Orange_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Orange_003.m3", null, "RottersBeltCrystal_Orange_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\CrumblingGround\\PRP_Rock_CrumblingGround_000.m3", null, "Rock_CrumblingGround", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\CrumblingGround\\PRP_Rock_CrumblingGround_Eldan_000.m3", null, "Rock_CrumblingGround_Eldan", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Drusera\\PRP_Crystal_Drusera_000.m3", null, "Crystal_Druser", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_000.m3", null, "AlgorocMineCrystal_Blue_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_001.m3", null, "AlgorocMineCrystal_Blue_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_002.m3", null, "AlgorocMineCrystal_Blue_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_003.m3", null, "AlgorocMineCrystal_Blue_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_004.m3", null, "AlgorocMineCrystal_Blue_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_005.m3", null, "AlgorocMineCrystal_Blue_005", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_006.m3", null, "AlgorocMineCrystal_Blue_006", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystals_Blue_000.m3", null, "AlgorocMineCrystal_Blue_007", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystals_Blue_001.m3", null, "AlgorocMineCrystal_Blue_008", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_RED_000.m3", null, "Crystals_Red", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_001.m3", null, "Crystal_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_002.m3", null, "crystal_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_RED_001.m3", null, "crystal_red", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlBag_Blue_000.m3", null, "PearlBag_Blue", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlBag_Pink_000.m3", null, "PearlBag_Pink", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_Blue_000.m3", null, "PearlPile_Blue", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_Pink_000.m3", null, "PearlPile_Pink", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_White_000.m3", null, "PearlPile_White", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Blue_000.m3", null, "Pearl_Blue", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Blue_FX_000.m3", null, "Pearl_Blue_FX", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Green_FX_000.m3", null, "Pearl_Green", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Pink_000.m3", null, "Pearl_Pink", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_White_000.m3", null, "Pearl_White", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_000.m3", null, "Mangrove_Augmented_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_001.m3", null, "Mangrove_Augmented_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_002.m3", null, "Mangrove_Augmented_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_003.m3", null, "Mangrove_Augmented_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Blue_000.m3", null, "Mangrove_Blue", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Burnt_000.m3", null, "Mangrove_Burnt", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_000.m3", null, "Mangrove_Green", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_001.m3", null, "Mangrove_Green", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_002.m3", null, "Mangrove_Green", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_003.m3", null, "Mangrove_Green", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Purple_000.m3", null, "Mangrove_Purple", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Teal_000.m3", null, "Mangrove_Teal", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Violet_000.m3", null, "Mangrove_Violet", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_000.m3", null, "Elderoot", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_Seed_000.m3", null, "Elderoot_Seed", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_Tentacles_000.m3", null, "Elderoot_Tentacles", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_000.m3", null, "Exanite_Brokenwall_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_001.m3", null, "Exanite_Brokenwall_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_002.m3", null, "Exanite_Brokenwall_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_003.m3", null, "Exanite_Brokenwall_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_004.m3", null, "Exanite_Brokenwall_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_Exanite_TreeofLifeGateDestroyed_000.m3", null, "Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_Exanite_TreeofLifeGateDestroyed_000.m3", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_Exanite_TreeofLifeGate_000.m3", null, "TreeofLifeGateDestroyed", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_001.m3", null, "TreeofLifeGate", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_002.m3", null, "Exanite_Wall_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_003.m3", null, "Exanite_Wall_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_004.m3", null, "Exanite_Wall_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_005.m3", null, "Exanite_Wall_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_006.m3", null, "Exanite_Wall_005", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_Illium_001.m3", null, "Exanite_Wall_Illium", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillarCap_Huge_000.m3", null, "ExanitePillarCap_Huge", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillarCap_Large_000.m3", null, "ExanitePillarCap_Large", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Large_000.m3", null, "ExanitePillar_Large", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Pillar_001.m3", null, "ExanitePillar_Pillar", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Platform_000.m3", null, "ExanitePillar_Platform", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_SmallFloating_000.m3", null, "ExanitePillar_SmallFloating", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Vent_000.m3", null, "RMT_Vent", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Vents_000.m3", null, "RMT_Vents", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Wind_Woosh_000.m3", null, "RMT_Woosh_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Wind_Woosh_001.m3", null, "RMT_Woosh_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_PoopPile_000.m3", null, "PoopPile", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_PoopPile_Bubble_000.m3", null, "PoopPile_Bubble", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_Shower_Decals_Puddle_000.m3", null, "Shower_Decals_Puddle", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Hand_000.m3", null, "Shower_Decals_Hand_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Hand_001.m3", null, "Shower_Decals_Hand_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_LFoot_000.m3", null, "Shower_Decals_LFoot_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_LFoot_001.m3", null, "Shower_Decals_LFoot_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_RFoot_000.m3", null, "Shower_Decals_RFoot_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_RFoot_001.m3", null, "Shower_Decals_RFoot_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Smear_000.m3", null, "Shower_Decals_Smear", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Trail_000.m3", null, "Shower_Decals_Trail", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\ShellarkTank\\PRP_RMT_Act2_ShellarkTank_000.m3", null, "ShellarkTank", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\ShellarkTank\\PRP_RMT_Act2_ShellarkTank_Shellarks_000.m3", null, "Shellark", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Grill_000.m3", null, "Pirate_Grill", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Light_000.m3", null, "Pirate_Light", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Pipe_000.m3", null, "Pirate_Pipe", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Wok_000.m3", null, "Pirate_Wok", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\AsteroidBelt\\PRP_RMT_AsteroidBelt_Arc_000.m3", null, "RMT_AsteroidBelt", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\SquidPlant\\PRP_RMT_Act2_SquidPlant_000.m3", null, "RMT_Squidplant", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\SteamVent\\PRP_RMT_SteamVent_000.m3", null, "RMT_SteamVent", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Tesla_Device\\PRP_TeslaDevice_000.m3", null, "TeslaDevice", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Bar\\PRP_RMT_Act2_Bar_001.m3", null, "RMT_Bar_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Bar\\PRP_RMT_Act2_Bar_002.m3", null, "RMT_Bar_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\GlowingSkull\\PRP_RMT_GlowingSkull_000.m3", null, "RMT_GlowingSkull", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Comet\\PRP_RMT_Comet_000.m3", null, "RMT_Comet", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Fan\\PRP_RMT_Fan_000.m3", null, "RMT_Fan", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_000.m3", null, "RMT_HologramShips_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_001.m3", null, "RMT_HologramShips_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_002.m3", null, "RMT_HologramShips_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_003.m3", null, "RMT_HologramShips_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MedbayLight\\PRP_RMT_MedbayLight_000.m3", null, "MedbayLight", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MogMog\\PRP_RMT_MogMog_000.m3", null, "MogMog", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_000.m3", null, "MorgueDrawer_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_001.m3", null, "MorgueDrawer_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_002.m3", null, "MorgueDrawer_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_003.m3", null, "MorgueDrawer_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_000.m3", null, "OperatingTable_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_001.m3", null, "OperatingTable_001", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_002.m3", null, "OperatingTable_002", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\PASystem\\PRP_RMT_PASystem_000.m3", null, "RMT_PASystem", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Pipe\\PRP_RMT_Act3_Pipe_000.m3", null, "RMT_Act3_Pipe_000", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Blue_000.m3", null, "Planet_Blue", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Cracked_000.m3", null, "Planet_Cracked", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Tan_000.m3", null, "Planet_Tan", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\PlantStand\\PRP_RMT_PlantStand_000.m3", null, "RMT_PlantStand", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_003.m3", null, "RMT_SewagePipes_003", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_004.m3", null, "RMT_SewagePipes_004", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_005.m3", null, "RMT_SewagePipes_005", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Sun\\PRP_RMT_Sun_000.m3", null, "The Sun", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Vine\\PRP_RMT_Vine_SmallThinLoose_001.m3", null, "Vine_SmallThinLoose", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Airlock_Wind_000.m3", null, "Airlock_Wind", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_ChainPulley_000.m3", null, "RMT_ChainPulley", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Choppa_Blade_000.m3", null, "Choppa_Blade", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Choppa_TrashChuteRing_000.m3", null, "Choppa_TrashChuteRing", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Choppa_TrashDoor_000.m3", null, "Choppa_TrashDoor", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Compactor_Smasher_000.m3", null, "Compactor_Smasher", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Decal_MarauderHead_Metal_000.m3", null, "Decal_MarauderHead_Metal", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Decal_MarauderHead_Painted_000.m3", null, "Decal_MarauderHead_Painted", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Deck_Turret_000.m3", null, "Deck_Turret", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Elevator_Platform_000.m3", null, "Elevator_Platform", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_BossPlatform_Center_000.m3", null, "Engine_BossPlatform_Center", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_BossPlatform_Side_000.m3", null, "Engine_BossPlatform_Side", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_FlamePillar_000.m3", null, "Engine_FlamePillar", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_Piston_000.m3", null, "Engine_PIston", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Furnace_000.m3", null, "RMT_Furnace", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Grill_000.m3", null, "RMT_Grill", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Lavaka_Grill_000.m3", null, "Lavaka_Grill", DecorCategory.Beta, false);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Lavaka_IncineratorPit_000.m3", null, "Lavaka_IncineratorPit", DecorCategory.Beta, false);


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
