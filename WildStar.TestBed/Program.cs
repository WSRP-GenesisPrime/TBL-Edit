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


            AddGenericDecor("Art\\Light\\LIT_Level_Up_Spotlight_000.m3", 3699, "Spot Light (Level Up)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Mask_Point_Med_AurinHanging.m3", 3700, "Point Light (Aurin Hanging Light)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Mask_Spotlight_Gate_000.m3", 3701, "Spot Light (Gate)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Hard.m3", 3702, "Point Light (Hard)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Hard_Bright.m3", 3703, "Point Light (Hard, Bright)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Med.m3", 3704, "Point Light (Medium)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Med_Bright.m3", 3705, "Point Light (Medium, Bright)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Med_Bright_Amb.m3", 3706, "Point Light (Medium, Bright Ambient)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft.m3", 3707, "Point Light (Soft)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Bright.m3", 3708, "Point Light (Soft, Bright)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Overbright.m3", 3709, "Point Light (Soft, Overbright)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Throb.m3", 3710, "Point Light (Soft, Throb)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Rec_Hard.m3", 3711, "Spot Light (Hard, Rectangle)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Rec_Med.m3", 3712, "Spot Light (Medium, Rectangle)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Rec_Soft.m3", 3713, "Spot Light (Soft, Rectangle)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Diffused_Overbright.m3", 3714, "Spot Light (Diffused, Overbright)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Hard.m3", 3715, "Spot Light (Hard)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Med.m3", 3716, "Spot Light (Medium)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_MedNarrow_Soft.m3", 3717, "Spot Light (Medium, Narrow Soft)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Narrow_Med.m3", 3718, "Spot Light (Medium, Narrow)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Narrow_Soft.m3", 3719, "Spot Light (Soft, Narrow)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Soft.m3", 3720, "Spot Light (Soft)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Hard.m3", 3721, "Spot Light (Hard, Wide)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Med.m3", 3722, "Spot Light (Medium, Wide)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Soft.m3", 3723, "Spot Light (Soft, Wide)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_DIR_Crystline_001.m3", 3724, "Directional Light (Crystal)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_DIR_SimpleNarrow_001.m3", 3725, "Directional Light (Simple, Narrow)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Cubic_Fire_001.m3", 3726, "Point Light (Fire Texture)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_Brazier.m3", 3727, "Point Light (Brazier)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_LavaTube.m3", 3728, "Point Light (Lava Tube)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Branches_001.m3", 3729, "Spot Light (Branches)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Chain.m3", 3730, "Spot Light (Chain Texture)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001.m3", 3731, "Spot Light (Dappled Light)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001_Short.m3", 3732, "Spot Light (Dappled Light, Short)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002.m3", 3733, "Spot Light (Dappled Light 2)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002_Short.m3", 3734, "Spot Light (Dappled Light 2, Short)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Fire_001.m3", 3735, "Spot Light (Fire)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Grate.m3", 3736, "Spot Light (Grate)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Grate_Large.m3", 3737, "Spot Light (Grate, Large)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_002.m3", 3738, "Hanging Cable (Long)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_003.m3", 3739, "Hanging Cable (Longer)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_SegmentedLong_003.m3", 3740, "Hanging Cable (Long, Drooping)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\PRP_Cable_Generic_Box_000.m3", 3741, "Cable Socket", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_007.m3", 3742, "Phial (Medium)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_008.m3", 3743, "Potion Bottle", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_009.m3", 3744, "Potion Bottle (Wide)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Bottle_Granok_Beer_000.m3", 3745, "Beer Bottle (Granok)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Granok_BeerCan_Open_000.m3", 3746, "Crushed Beer Can", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_001.m3", 3747, "Beer Can (Protostar)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_000.m3", 3748, "Crushed Beer Can (Protostar)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Bar\\SanctuaryCommon\\PRP_Bar_DrinkMixer_Gold_000.m3", 3749, "Drink Mixer", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\PRP_Debris_SmugglerFighterCrashed_VAR_LeftEngine_000.m3", 3750, "Ruined Fighter Wing", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_000.m3", 3751, "Metal Panel (Thick)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_001.m3", 3752, "Metal Panel", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_002.m3", 3753, "Metal Panel (Uneven)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Falkrin\\PRP_Debris_FalkrinMetalPlate_000.m3", 3754, "Metal Scrap", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_000.m3", 3755, "Granok Trailer", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_001.m3", 3756, "Granok Trailer (Sandstone)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_000.m3", 3757, "Junk Shack (Tall)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_001.m3", 3758, "Junk Shack (Short)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotArm_Rust_000.m3", 3759, "Rusty Bot Arm", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotBody_Rust_000.m3", 3760, "Rusty Bot Torso", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotHead_Rust_000.m3", 3761, "Rusty Bot Head", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotLeg_Rust_000.m3", 3762, "Rusty Bot Leg", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_000.m3", 3763, "Metal Pipe Tower", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_001.m3", 3764, "Large Metal Tank", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_002.m3", 3765, "Metal Scaffolding", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_003.m3", 3766, "Metal Scaffolding", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_002.m3", 3767, "Metal Pipe Interesection", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_005.m3", 3768, "Metal Pipe Segment", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_006.m3", 3769, "Metal Pipe (Long)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_007.m3", 3770, "Metal Pipe (Thin, Curved)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_008.m3", 3771, "Metal Pipe (Short)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_009.m3", 3772, "Metal Pipe (Curved)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_010.m3", 3773, "Metal Support Beams", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_011.m3", 3774, "Metal Support Beams", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_013.m3", 3775, "Metal Rod", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_014.m3", 3776, "Faucet", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_000.m3", 3777, "Crooked Pipe", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipe_ManHole_RMC_000.m3", 3778, "Metal Pipe Cap", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_PipeBase_RMC_000.m3", 3779, "Redmoon Ventilation Pipes", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_000.m3", 3780, "Metal Tube (Curved)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_001.m3", 3781, "Metal Tube", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_002.m3", 3782, "Metal Tube (Thick)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_003.m3", 3783, "Metal Tube (Corner)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_004.m3", 3784, "Metal Pipe Moderator", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_005.m3", 3785, "Chua Sphere", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_006.m3", 3786, "Metal Tube (Reinforced)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_007.m3", 3787, "Metal Tube (Cap)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_008.m3", 3788, "Metal Tube (Short)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_009.m3", 3789, "Chua Orb", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_010.m3", 3790, "Chua Orb (Large)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_011.m3", 3791, "Chua Window", DecorCategory.Windows, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_002.m3", 3792, "Tank (Chua, Tall)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_001.m3", 3793, "Valve (Round)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_004.m3", 3794, "Valve", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_Tap_GreyBrown_001.m3", 3795, "Rusty Watertap", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Arkship\\PRP_Container_Arkship_RelicCrate_001.m3", 3796, "Shipping Crate (Open)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Arkship\\PRP_Container_Arkship_RelicCrate_002.m3", 3797, "Shipping Crate Lid", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Chua\\PRP_Chua_Container_002.m3", 3798, "Chua Speaker", DecorCategory.Audio, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Chua\\PRP_Chua_Container_003.m3", 3799, "Tank (Chua, Small)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_000.m3", 3800, "Metal Canister (Damaged)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_001.m3", 3801, "Metal Canister (Broken)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_002.m3", 3802, "Metal Fragment", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Generic\\PRP_Container_Generic_Cannister_000.m3", 3803, "Canister (Ornate)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Ikthian_ContainerBot_Boxy_001.m3", 3804, "Treasure Chest (Ikthian, Open)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Container_PlasmaAquaLiquid_BlueYellow_000.m3", 3805, "Plasma Canister (Ikthian)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Container_PlasmaAquaLiquid_BlueYellow_001.m3", 3806, "Plasma Canister (Ikthian, Broken)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MachineGun\\Tribal\\PRP_Turret_Tribal_000.m3", 3807, "Turret Barrel", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularShort_000.m3", 3808, "Metal Beam", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularLong_000.m3", 3809, "Metal Beam (Long)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularLargeLong_000.m3", 3810, "Metal Beam (Large)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularBroken_001.m3", 3811, "Metal Beam (Broken)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularTFrame_000.m3", 3812, "Metal Beam Pillar", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularShort_Brown_000.m3", 3813, "Wooden Beam", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularLong_Brown_000.m3", 3814, "Wooden Beam (Long)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularLargeLong_Brown_000.m3", 3815, "Wooden Beam (Large)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularBroken_Brown_000.m3", 3816, "Wooden Beam (Broken)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularTFrame_Brown_000.m3", 3817, "Wooden Beam Pillar", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamConnector_MineModularMetal_Grey_001.m3", 3818, "Metal Beam Connector", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamConnector_MineModularMetal_Grey_002.m3", 3819, "Metal Beam Connector (2)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_000.m3", 3820, "Hanging Wire (Double)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_001.m3", 3821, "Hanging Wire (Spiraling)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_002.m3", 3822, "Hanging Wire (Coiled)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_003.m3", 3823, "Hanging Wire", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ScienceInstruments\\General\\PRP_General_LargeMicroscope_000.m3", 3824, "Microscope", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ScienceInstruments\\General\\PRP_General_SmallScanner_000.m3", 3825, "Medical Scanner", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\PRP_ArkShip_Planter_007.m3", 3826, "Robotic Arm Segment", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\PRP_Bank_Atm_Generic_000.m3", 3827, "ATM Machine", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Freebot\\PRP_Machinery_FreebotTransformer_Green_000.m3", 3828, "Freebot Transformer", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Freebot\\PRP_Machinery_FreebotWelder_Green_000.m3", 3829, "Freebot Welding Unit", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Chua\\PRP_Machinery_ChuaDrill_000.m3", 3830, "Chua Drill Pod", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pillar\\Osun\\PRP_Pillar_OsunHead_000.m3", 3831, "Osun Bust", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Pillar\\Algeroc\\PRP_StructuralPillar_AlgorocMineSupport_Brown_000.m3", 3832, "Wooden Column", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\PRP_Weapon_TranquilizerRounds_000.m3", 3833, "Tranquilizer Rounds", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_000.m3", 3834, "Missile (Cluster)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_001.m3", 3835, "Missile (Ballistic)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_002.m3", 3836, "Missile (Angry)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Television\\Pell\\PRP_Television_Pell_000.m3", 3837, "Pell Monitor", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Barrel_000.m3", 3838, "Cannon Barrel", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Barrel_001.m3", 3839, "Cannon Barrel (Exile)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Shield_000.m3", 3840, "Metal Panel (Exile Decal)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Imperium\\PRP_Turret_ImperiumMilitary_000.m3", 3841, "Turret (Dominion)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_000.m3", 3842, "Beaker and Vial", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_001.m3", 3843, "Beaker (Empty)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Blue_000.m3", 3844, "Beaker (Blue, Conical)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Blue_001.m3", 3845, "Beaker (Blue)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Green_000.m3", 3846, "Beaker (Green, Conical)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Green_001.m3", 3847, "Beaker (Green)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Purple_000.m3", 3848, "Beaker (Purple, Conical)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Purple_001.m3", 3849, "Beaker (Purple)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Red_000.m3", 3850, "Beaker (Red, Conical)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Red_001.m3", 3851, "Beaker (Red)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ChemistrySet_000.m3", 3852, "Chemistry Set", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ScrewDriver.m3", 3853, "Screwdriver", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_SHookMetal_Gray_003.m3", 3854, "Metal Hook", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ToolCase_000.m3", 3855, "Tool Case", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MinePileBundle_Red_000.m3", 3856, "Wire Bundle", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MinePileBundle_Red_002.m3", 3857, "Wire Bundle (Large)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Shelter\\PRP_Tools_shedgenericanimalshelter_brownrust_000.m3", 3858, "Open Shed", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Pots_and_Pans\\PRP_Tools_PotsPans_000.m3", 3859, "Empty Pot (Small)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\PRP_GearPile_Grey_000.m3", 3860, "Gear Pile", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_LargeGear_000.m3", 3861, "Freebot Gear (Large)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_LargeGear_001.m3", 3862, "Freebot Gear (Large, Tight)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_MediumGear_000.m3", 3863, "Freebot Gear (Jagged)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_SmallGear_000.m3", 3864, "Freebot Gear (Small)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Arkship_Tram_000.m3", 3865, "Arkship Tram", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Imperium_White_000.m3", 3866, "Lifter (Handle)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Imperium_White_001.m3", 3867, "Lifter", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\House\\Pell\\Large\\PRP_PellHouse_Large_000.m3", 3868, "Pell House (Large)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\House\\Pell\\Small\\PRP_PellHouse_Small_000.m3", 3869, "Pell House (Small)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokCorner_000.m3", 3870, "Granok Platform (Junction)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokLeftTurn_000.m3", 3871, "Granok Stairs (Curved, Left)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokLongStairs_000.m3", 3872, "Granok Stairs", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokPlatform_000.m3", 3873, "Granok Platform", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokRightTurn_000.m3", 3874, "Granok Stairs (Curved, Right)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokShortStairs_000.m3", 3875, "Granok Stairs & Platform", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokStairs_000.m3", 3876, "Granok Stairs (Long)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokStraight_000.m3", 3877, "Granok Platform (Long)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_LargeWoodPlank_000.m3", 3878, "Wooden Plank (Thick)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_Rope_000.m3", 3879, "Hanging Rope", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_StraightPlatform_000.m3", 3880, "Elevated Platform (Long)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_StraightPlatform_001.m3", 3881, "Elevated Platform (Short)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_TallSmallPlatform_000.m3", 3882, "Elevated Platform (Short, End)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_TallStraightPlatform_000.m3", 3883, "Elevated Platform", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Desk\\Protostar\\PRP_Protostar_Desk_000.m3", 3884, "Protostar Desk (Left)", DecorCategory.Tables, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Desk\\Protostar\\PRP_Protostar_Desk_001.m3", 3885, "Protostar Desk (Right)", DecorCategory.Tables, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Defiance\\PRP_DefianceMilitary_TableControlPanel_000.m3", 3886, "Data Panel (Exile)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Defiance\\PRP_DefianceMilitary_TableControlPanel_004.m3", 3887, "Wall Panel (Exile, Inverted)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Marauder\\PRP_ControlPanel_Marauder_Platform_000.m3", 3888, "Control Panel (Marauder)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Mechari\\PRP_mechari_iciinfocolumn_000.m3", 3889, "Information Terminal (Mechari)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Osun\\PRP_ControlPanel_Osun_Lever_000.m3", 3890, "Osun Lever", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Explorer_000.m3", 3891, "Control Panel (Small)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Base_Monitor_Standing_001.m3", 3892, "Floor Panel (Dominion)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Screen_000.m3", 3893, "Data Panel (Dominion)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Screen_001.m3", 3894, "Dominion Monitor", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_Antenna_Pell_000.m3", 3895, "Antenna (Pell)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_003.m3", 3896, "Pell-Tech Device (Large)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_004.m3", 3897, "Pell-Tech Device (Medium)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_005.m3", 3898, "Pell-Tech Device (Small)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_000.m3", 3899, "Shiphand Console", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_MonitorOcular_000.m3", 3900, "Shiphand Console (Ocular)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_MonitorSmallMid_000.m3", 3901, "Shiphand Console (Small)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_SixButtonWallMonitor_000.m3", 3902, "Control Panel (Shiphand)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\Pell\\PRP_Jar_Pell_000.m3", 3903, "Dubious Jar", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\Imperium\\PRP_Jar_Imperium_000.m3", 3904, "Dominion Pot", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\PRP_Jar_SmugglerPearShaped_Red_000.m3", 3905, "Jar (Ornate, Painted)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Jetpack\\Jetpack.m3", 3906, "Jetpack", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_QuestJobBoard_000.m3", 3907, "Job Board (Adventuring)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_000.m3", 3908, "Job Board (Engineering)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_001.m3", 3909, "Job Board Panel", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_002.m3", 3910, "Job Board Pole", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_003.m3", 3911, "Mechanicbot Pole", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_004.m3", 3912, "Job Board Panel (Double)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\Weaponsmith\\PRP_Tradeskill_Weaponsmith_CraftingStation_000.m3", 3913, "Crafting Station (Weapons)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\Generic\\PRP_Tradeskill_GenericTable_000.m3", 3914, "Crafting Station", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Cap_000.m3", 3915, "Eldan Circuit Cap", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Cap_001.m3", 3916, "Eldan Circuit Cap (Advanced)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Tubes_000.m3", 3917, "Eldan Pylon", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Tubes_Technophage_000.m3", 3918, "Eldan Pylon (Technophage)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Pod_FuelRods_002.m3", 3919, "Eldan Fuel Rod Cap", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Warplots\\PRP_Generator_Warplots_Widget_000.m3", 3920, "Generator (Arkship)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Tribal\\PRP_Generator_Batteries_Tribal_000.m3", 3921, "Fusion Battery", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Tribal\\PRP_Generator_Tribal_000.m3", 3922, "Generator (Simple)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\PRP_ArkShip_GeneratorSmall_000.m3", 3923, "Generator (Small, Arkship)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Drakken\\PRP_Drakken_Spike_Barier_000.m3", 3924, "Draken Weapons", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Legendary\\PRP_Quest_Legendary_Maiden_000.m3", 3925, "Sword (Torine, Floating)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\PRP_Quest_Lore_Paper_000.m3", 3926, "Paper Note (Aged)", DecorCategory.Books, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\PRP_Quest_Lore_Scroll_000.m3", 3927, "Paper Scroll", DecorCategory.Books, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\prp_quest_lore_paper_001.m3", 3928, "Paper Note (Simple)", DecorCategory.Books, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\JonnyCab\\PRP_JonnyCab_000.m3", 3929, "TaxiBot", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\JonnyCab\\PRP_JonnyCab_001.m3", 3930, "TaxiBot (Hologram)", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\TaxiKiosk\\PRP_Taxi_Kiosk_000.m3", 3931, "Taxi Kiosk", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_000.m3", 3932, "Open Metal Crate (Empty)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_001.m3", 3933, "Relic Crate", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_004.m3", 3934, "Science Crate", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_small_Toys_001.m3", 3935, "Toy Crate", DecorCategory.Toys, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_FinishLine_GroundChecker_000.m3", 3936, "Finish Line", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_HandSnowFrozen_Blue_000.m3", 3937, "Lost Arm (Frozen)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Hand_000.m3", 3938, "Lost Arm", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_HousingJobBoard_000.m3", 3939, "Job Board (Roofed)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_000.m3", 3940, "Teleporter", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_Eldan_000.m3", 3941, "Teleporter (Eldan)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_Protostar_000.m3", 3942, "Teleporter (Protostar)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Vendor_Generic_000.m3", 3943, "Vendor Terminal", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Crate\\PRP_Quest_Crate_Blue_000.m3", 3944, "Metal Crate (Blue)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Crate\\PRP_Quest_Crate_Gold_000.m3", 3945, "Metal Crate (Golden)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_000.m3", 3946, "Force Field", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_001.m3", 3947, "Force Field (Low)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_Red_Emissive_000.m3", 3948, "Forcefield, Red", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Garage_000.m3", 3949, "Garage Door (Wooden)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Cellar\\PRP_CellarDoor_SancCommonDoor_000.m3", 3950, "Cellar Door", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Drakken\\PRP_Door_DrakkenMetalGate_000.m3", 3951, "Metal Gate (Draken)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_RobotSilo_000.m3", 3952, "Eldan Silo Door", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_RobotSilo_Broken_000.m3", 3953, "Eldan Silo Door (Broken)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_IrisEldanMicro_001.m3", 3954, "Door (Eldan)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_LargeEldanDungeon_000.m3", 3955, "Eldan Gate (Large)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_SmallEldanDungeon_000.m3", 3956, "Eldan Gate (Small)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Ikthian\\PRP_Ikthian_Door_000.m3", 3957, "Metal Door (Ikthian)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Imperium\\PRP_Door_ImperiumTower_Bottom_000.m3", 3958, "Dominion Church Door, Style 1", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Imperium\\PRP_Door_ImperiumTower_Top_000.m3", 3959, "Dominion Church Door, Style 2", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Marauder\\PRP_Door_CellDoorSML_000.m3", 3960, "Door (Prison)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Marauder\\PRP_Door_RMC_Small_000.m3", 3961, "Door (Marauder)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Minekit\\PRP_Door_AlgorocMineDoor_Brown_001.m3", 3962, "Wooden Arch (Protostar)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Moodie\\PRP_Door_Frame_Moodie_002.m3", 3963, "Elevated Brazier (Moodie)", DecorCategory.Lighting, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Osun\\PRP_Door_Osun_B_000.m3", 3964, "Osun Stone Panel", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Osun\\PRP_Door_Osun_B_CinematicInteraction.m3", 3965, "Osun Face Carving", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Protostar\\PRP_Door_Protostar_Metal_Large_000.m3", 3966, "Garage Door (Protostar, Flat)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\ShipHand\\PRP_Shiphand_Door_000.m3", 3967, "Metal Door (Shiphand)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\ShipHand\\PRP_Shiphand_Door_Airlock_000.m3", 3968, "Airlock (Shiphand)", DecorCategory.Doors, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Berserker_000.m3", 3969, "Hoverboard (Berserker)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Berserker_Customization_000.m3", 3970, "Hoverboard (Berserker, Flaired)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Fang_000.m3", 3971, "Hoverboard (Fang)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Fang_Customization_000.m3", 3972, "Hoverboard (Fang, Flaired)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_GoGo_000.m3", 3973, "Hoverboard (GoGo)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_GoGo_Customization_000.m3", 3974, "Hoverboard (GoGo, Flaired)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Ringer_000.m3", 3975, "Hoverboard (Ringer)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Ringer_Customization_000.m3", 3976, "Hoverboard (Ringer, Flaired)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Turbine_000.m3", 3977, "Hoverboard (Turbine)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Turbine_Customization_000.m3", 3978, "Hoverboard (Turbine, Flaired)", DecorCategory.Hoverpark, false);
            AddGenericDecor("Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", 3979, "Emblem (Dominion)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", 3980, "Emblem (Exile)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_Bullseye_000.m3", 3981, "Decal (Bullseye)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_Bullseye_001.m3", 3982, "Decal (Bullseye 2)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_DarkspurSkull_000.m3", 3983, "Decal (Darkspur)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_NuclearSign_000.m3", 3984, "Decal (Nuclear)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Drakken\\PRP_MISC_DrakkenBonedStorage_000.m3", 3985, "Ancestral Urn (Draken)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Drakken\\PRP_MISC_DrakkenSpikedFooty_000.m3", 3986, "Metal Boot Tip (Draken)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Eldan\\Dome\\PRP_Eldan_AKA_Core_000.m3", 3987, "Eldan Core", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Eldan\\Dome\\PRP_Eldan_Dome_Broken_000.m3", 3988, "Eldan Dome (Broken)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_000.m3", 3989, "Coconut", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_001.m3", 3990, "Coconut (Opened)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_003.m3", 3991, "Coconut Pile", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_000.m3", 3993, "Graffiti (Yellow-Violet Text)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_001.m3", 3994, "Graffiti (Alien Head)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_002.m3", 3995, "Graffiti (Yellow-Purple Text)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_003.m3", 3996, "Graffiti (Teal Skull)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_004.m3", 3997, "Graffiti (Green-White Text)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_005.m3", 3998, "Graffiti (Magenta-Teal Text)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_Judge_Kain_000.m3", 3999, "Graffiti (Judge Kain)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_Marauder_Grafitti_000.m3", 4000, "Graffiti (Marauder)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_000.m3", 4001, "Space Helm", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_001.m3", 4002, "Space Helm (Draken)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_002.m3", 4003, "Space Helm (Grumpel)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_TopHat_000.m3", 4004, "Fancy Top Hat", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\KiddiePool\\PRP_KiddiePool_000.m3", 4005, "Kiddie Pool", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Camera_Generic_001.m3", 4006, "Security Camera", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_DoorKnocker_Granok.m3", 4007, "Door Knocker (Granok)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Arms_000.m3", 4008, "Mechari Spare Arms", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Legs_000.m3", 4009, "Mechari Spare Legs", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Torso_000.m3", 4010, "Mechari Spare Torso", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Mechari_Head\\Mechari_Head_Female.m3", 4011, "Mechari Head (Pink)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Mechari_Head\\PRP_Mechari_Head_Female_001.m3", 4012, "Mechari Head (Red)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_MISC_PowerCell_000.m3", 4013, "Power Cell", DecorCategory.Electronics, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Poodad.m3", 4014, "Poodad", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Tire\\PRP_Misc_Tire_001.m3", 4015, "Tire (Hollow)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_000.m3", 4016, "Plain Towel", DecorCategory.Bathroom, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_002.m3", 4017, "Striped Towel (Vertical)", DecorCategory.Bathroom, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_004.m3", 4018, "Invoker Towel", DecorCategory.Bathroom, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_005.m3", 4019, "Fancy Green Towel", DecorCategory.Bathroom, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers.m3", 4020, "Stadium Seating (Large)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Cap.m3", 4021, "Stadium Seating (Cap)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Half_000.m3", 4022, "Stadium Seating", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Half_001.m3", 4023, "Stadium Seating (Uncapped)", DecorCategory.BuildingBlocks, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_000.m3", 4024, "Ritual Pot (Pell, Tall)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_002.m3", 4025, "Open Ritual Pot (Pell)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_003.m3", 4026, "Open Ritual Pot (Pell, Tall)", DecorCategory.Containers, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\WorldDestroyer_Head_Destroyed.m3", 4027, "Annihilator Head (Destroyed)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSLeftHorn_000.m3", 4028, "Cyclopean Horn (Left)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSLeftJaw_000.m3", 4029, "Cyclopean Jaw (Left)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSRightHorn_000.m3", 4030, "Cyclopean Horn (Right)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSRightJaw_000.m3", 4031, "Cyclopean Jaw (Right)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSSkull_000.m3", 4032, "Cyclopean Skull", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GiantHornedSkull_000.m3", 4033, "Cyclopean Horned Skull", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Bridge_A.m3", 4034, "Osun Bridge", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Short_A.m3", 4035, "Osun Tower (Short)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Tall_A.m3", 4036, "Osun Stone Tower (Adorned)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Tall_B.m3", 4037, "Osun Stone Tower", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Detail_WolfHead_A.m3", 4038, "Osun Wolf Tower", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Short_A.m3", 4039, "Osun Gate", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Tall_A.m3", 4040, "Osun Siege Gate ", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Tall_B.m3", 4041, "Osun Siege Gate (Ramped)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Stairs_A.m3", 4042, "Osun Stairs", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Stairs_B.m3", 4043, "Osun Stairs (Wide)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_000.m3", 4044, "Osun Walkway", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_A.m3", 4045, "Osun Wall Segment (Slanted, In, Right)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_B.m3", 4046, "Osun Wall Segment (Slanted, In, Left)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_C.m3", 4047, "Osun Wall Segment (Slanted, Out, Right)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_D.m3", 4048, "Osun Wall Segment (Slanted, Out, Left)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_E.m3", 4049, "Osun Wall Segment", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Double_A.m3", 4050, "Osun Siege Wall", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_CurveDouble_A.m3", 4051, "Osun Siege Wall (Curved, Inward)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_CurveDouble_B.m3", 4052, "Osun Siege Wall (Curved, Outward)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Half_A.m3", 4053, "Osun Siege Wall Trim", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_A.m3", 4054, "Osun Wall (Low)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_B.m3", 4055, "Osun Wall (Low, Ramp)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_C.m3", 4056, "Osun Wall (Low, Short)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Tall_B.m3", 4057, "Osun Wall (Long)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit_Ruins\\PRP_Osun_Entrance_Small.m3", 4058, "Osun Entrance", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder_weapons_000.m3", 4059, "Rocket Launcher (Exile, Small)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_001.m3", 4060, "Bone Pile", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_002.m3", 4061, "Bone Pile (Double)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_003.m3", 4062, "Bone Pile (Elongated)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanSkeleton_Tan_000.m3", 4063, "Skeleton (Hanging)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanSkeleton_Tan_002.m3", 4064, "Skull (Human, Screaming)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_HumanSkull_003.m3", 4065, "Skull (Human, Angry)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\Dinosaur\\PRP_Bones_Dinosaur_Skull_000.m3", 4066, "Giant Skull (Dinosaur)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_000.m3", 4067, "Skull (Roc)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_001.m3", 4068, "Skull (Roc, Half)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_002.m3", 4069, "Skeletal Jaw (Roc)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_003.m3", 4070, "Giant Ribcage (Roc)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_004.m3", 4071, "Ribcage Bridge", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_005.m3", 4072, "Ribcage Ramp", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_006.m3", 4073, "Giant Ribs", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_007.m3", 4074, "Giant Jaw Fragment", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_DragonSkeleton_Jaw_Tan_000.m3", 4075, "Dragon Skull (Jaw)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_DragonSkeleton_Skull_Tan_000.m3", 4076, "Dragon Skull (Upper)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_EnvironmentHazard_Trap_000.m3", 4077, "Rib Cluster", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_GirokSkullClean_Tan_000.m3", 4078, "Skull (Girrok)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Hand_Large_Tan_000.m3", 4079, "Giant Skeletal Hand", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegAnimalClean_Tan_000.m3", 4080, "Bone", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegwithMeat_Tan_001.m3", 4081, "Meaty Rib", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegwithMeat_Tan_002.m3", 4082, "Meaty Bone", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LongBone_Large_Tan_000.m3", 4083, "Bone (Massive)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_PumeraSkullClean_Tan_000.m3", 4084, "Skull (Pumera)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RhinoSkull_Small_Tan_000.m3", 4085, "Skull (Mammodin, Juvenile)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RhinoSkull_SquareHorn_Tan_000.m3", 4086, "Skull (Mammodin, Adult)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_000.m3", 4087, "Ribcage (Whole)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_001.m3", 4088, "Ribcage (Half)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_002.m3", 4089, "Ribs", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_004.m3", 4090, "Ribs (Half, left)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_005.m3", 4091, "Ribs (Half, right)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Hide_Large_Tan_000.m3", 4092, "Giant Ribcage (Spiny, Fleshy)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Hide_Large_Tan_001.m3", 4093, "Giant Ribcage (Half, Fleshy)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_000.m3", 4094, "Giant Ribcage (Spiny)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_001.m3", 4095, "Giant Ribcage (Half)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_002.m3", 4096, "Giant Ribcage (Half, Collapsed)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_hide_Large_Tan_000.m3", 4097, "Giant Ribcage (Spiny, Fleshy)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsEarthrender_Large_Tan_000.m3", 4098, "Giant Ribcage (Earth-Render)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_000.m3", 4099, "Ribcage (Whole, Fleshy)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_001.m3", 4100, "Ribcage (Half, Fleshy)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_002.m3", 4101, "Ribs (Half, Fleshy)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_003.m3", 4102, "Human Ribs", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_000.m3", 4103, "Ribs (Half, Tar)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_001.m3", 4104, "Ribcage (Half, Tar)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_002.m3", 4105, "Ribcage (Whole, Tar)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_SingleRib_Large_Tan_000.m3", 4106, "Giant Rib", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Skull_BirdLikeWithTeath_Tan_000.m3", 4107, "Skull (Giant Pirahna)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Skull_RhinoWithTeath_Tan_000.m3", 4108, "Skull (Rhino, Tusks)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_SpineAnimalClean_Tan_000.m3", 4109, "Misplaced Spine", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_000.m3", 4110, "Fishing Line", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_001.m3", 4111, "Hanging Fish (Clustered)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_002.m3", 4112, "Hanging Fish (Spread)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_003.m3", 4113, "Fish Carcasses (Clustered)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_004.m3", 4114, "Fish Carcasses (Spread)", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_005.m3", 4115, "Fish Skeleton", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_006.m3", 4116, "Fish Carcass", DecorCategory.CookwareBarware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_003.m3", 4117, "Weapon Rack (Draken, Empty)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\ToolShed\\PRP_Tools_shedgenericwood_brownrust_000.m3", 4118, "Tool Shed (Table)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\ToolShed\\PRP_Tools_shedgenericwood_brownrust_001.m3", 4119, "Tool Shed", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\TorineDungeon\\PRP_Water_TorineDungeon_001.m3", 4120, "Pool of Blood", DecorCategory.Special, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_OGE.m3", 4121, "Lava Eruption (Line)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_noDecal_OGE.m3", 4122, "Lava Eruption (Line, Scorching)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\Impacts\\Lava_Splash\\Lava_Splash_OGE.m3", 4123, "Lava Splash", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_10mR.m3", 4124, "Lava Spring (Large)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_5mR.m3", 4125, "Lava Spring (Medium)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_10mR.m3", 4126, "Lava Bubbles (Large, Ring)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_15mR.m3", 4127, "Lava Bubbles (Medium, Ring)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_10mR.m3", 4128, "Lava Pool (Large, Grounded)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_3mR.m3", 4129, "Lava Pool (Small, Bubbling)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR.m3", 4130, "Lava Pool (Medium)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_AQU.m3", 4131, "Lava Pool (Medium, Teal)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_GLD.m3", 4132, "Lava Pool (Medium, Gold)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_3mR.m3", 4133, "Lava Bubbles (Small)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_5mR.m3", 4134, "Lava Bubbles (Medium, Grounded)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_NoGrndConst_5mR.m3", 4135, "Lava Bubbles (Medium)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGrndConst_10mR.m3", 4136, "Lava Pool (Large)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Wave\\Lava_Wave.m3", 4137, "Lava Bubbles (Violent, Line)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_Eruption_2mR_4mH_OGE.m3", 4138, "Lava Burst (Scorching)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_LinearEruption_2mR_4mH_NoDecal_OGE.m3", 4139, "Lava Burst", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Geyser\\Lava_Geyser_OGE.m3", 4140, "Lava Geyser", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Prop\\Dungeon\\Datascape\\LavaRock\\PRP_Datascape_LavaRock_000.m3", 4141, "Volcanic Rock", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Prop\\Housing\\Islands\\PRP_SkymapIsland_Lava_Terrain_000.m3", 4142, "Lava Terrain Slab", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_000.m3", 4143, "Lavafall (Small)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_001.m3", 4144, "Lavafall (Tall)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_002.m3", 4145, "Lava Pool (Small)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_002.m3", 4146, "Lava Blob", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_004.m3", 4147, "Lava Chunk", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_Tall_001.m3", 4148, "Lava Blob (Tall)", DecorCategory.ParticleEffects, false);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood1n2\\Blood1n2.m3", 4149, "Blood Magic (Pulsing)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_01.m3", 4150, "Blood Magic", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Channels\\Siphon\\Siphon.m3", 4151, "Blood Siphon", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Channels\\Siphon\\Siphon_12.m3", 4152, "Orange Glow", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Double_Vertical\\Double_Vertical.m3", 4153, "Blood Explosion", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Gib\\Gib_14.m3", 4154, "Blood Burst (Messy)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Hit_Default\\Hit_Default_14.m3", 4155, "Blood Burst", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Pumera_Pounce\\Pumera_Pounce_14.m3", 4156, "Blood Spray (Intermediate)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Pumera_Pounce\\Pumera_Pounce_14_GRN.m3", 4157, "Blood Spray (Intermediate, Green)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Slash_Horizontal\\Slash_Horizontal_14.m3", 4158, "Blood Squirt", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Slash_Spray\\Slash_Spray.m3", 4159, "Blood Spray (Intermediate, Large)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Vulcarrion_Divebomb\\Vulcarrion_Divebomb_14.m3", 4160, "Blood Burst (Small)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Default\\Default_14.m3", 4161, "Gushing Blood (Messy)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Slash_Wound\\Slash_Wound.m3", 4162, "Gushing Blood (Downward)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Spray_Vertical\\Spray_Vertical.m3", 4163, "Blood Spray (Continuous)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Squirt_01\\Squirt_01_14.m3", 4164, "Blood Squirt (Alternate)", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Ocean\\Water_Ocean_WaveCircle_000.m3", 4165, "Water Surface", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Water\\Ocean\\Water_Ocean_WaveShoreline_000.m3", 4166, "Ocean Waves", DecorCategory.ParticleEffects, true);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Corner_A.m3", 4167, "Osun Walkway (Corner)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Curve_A.m3", 4168, "Osun Walkway (Curved, Left)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Curve_B.m3", 4169, "Osun Walkway (Curved, Right)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Long_A.m3", 4170, "Osun Walkway (Long)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Ramp_A.m3", 4171, "Osun Ramp", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Short_A.m3", 4172, "Osun Walkway (Short)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_SlopeLong_A.m3", 4173, "Osun Sloped Walk way (Long)", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_SlopeShort_A.m3", 4174, "Osun Sloped Walk way", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_A_000.m3", 4175, "Osun Support Arch", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_B.m3", 4176, "Osun Support Strut", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_C.m3", 4177, "Osun Anvil Sculpture", DecorCategory.Structures, false);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\Elemental\\PRP_Bones_Elemental_000.m3", 4178, "Elemental Remnants", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_ShortAxe_000.m3", 4179, "Draken War Axe (Short)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_ShortAxe_001.m3", 4180, "Draken War Axe (Long)", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_Spear_000.m3", 4181, "Serrated Spear", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\PRP_WeaponRack_ImperiumFreeStanding_Black_000.m3", 4182, "Dominion Weapon Rack", DecorCategory.WeaponsArmor, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\PRP_Vending_GranokBeer_000.m3", 4183, "Vending Machine (Granok Beer)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\AbilityVendor\\PRP_Vending_AbilityVendor_000.m3", 4184, "BoxerBot", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\Chua\\PRP_Building_ChuaShop_000.m3", 4185, "Chua Shop", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Speaker\\Generic\\PRP_Speaker_Generic_Grey_000.m3", 4186, "Speaker (Small)", DecorCategory.Audio, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Speaker\\Marauder\\PRP_Speaker_MarauderSpeaker_000.m3", 4187, "Speaker (Marauder)", DecorCategory.Audio, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_007.m3", 4188, "Draken Horn (Curved, Right)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_008.m3", 4189, "Draken Horn (Curved, Left)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_009.m3", 4190, "Draken Horn (Painted, Left)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_010.m3", 4191, "Draken Horn (Painted, Right)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_011.m3", 4192, "Draken Horn (Painted, Short)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_012.m3", 4193, "Draken Horn (Curved, Gilded)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_013.m3", 4194, "Draken Horn (Gilded)", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Horn_DrakkenLSupported_000.m3", 4195, "Draken War Horn", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Book\\BookOfDominus\\PRP_Book_BookofDominus_000.m3", 4196, "Invoker's Grimoire", DecorCategory.Books, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Fence\\Protostar\\PRP_Fence_ProtostarSpaceGeneric_003.m3", 4197, "Metal Pole", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\CampFire\\PRP_CampFire_Generic_RedGrey_001.m3", 4198, "Campfire (Large)", DecorCategory.Lighting, true);
            AddGenericDecor("Art\\Prop\\Constructed\\CampFire\\PRP_CampFire_Generic_RedGrey_002.m3", 4199, "Bonfire", DecorCategory.Lighting, true);
            AddGenericDecor("Art\\Prop\\Constructed\\Ship\\GeneralCargoShip\\PRP_Ship_GeneralCargoShip_000.m3", 4200, "Piglet Ship", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Ship\\GeneralCargoShip\\PRP_Ship_GeneralCargoShip_001.m3", 4201, "Piglet Ship (Dark)", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Vent\\PRP_Vent_Big_RMC_000.m3", 4202, "Redmoon Ship Vent", DecorCategory.Accents, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", 4203, "Ship Tech Panel (Round)", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_001.m3", 4204, "Ship Tech Panel (Flat)", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_002.m3", 4205, "Ship Support Strut", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Engine_005.m3", 4206, "Fighter Ship Engine", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Light_002.m3", 4207, "Fighter Ship Light", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Left_002.m3", 4208, "Fighter Ship Wing (Left)", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Right_002.m3", 4209, "Fighter Ship Wing (Right)", DecorCategory.Spaceship, false);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Water_GenericPool_000.m3", 4210, "Hot Springs Pool (Bright)", DecorCategory.Special, true);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Water_Grimvault_Bubbles_000.m3", 4211, "Glowing Purple Bubble", DecorCategory.Special, true);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Waterfall_NPE_000.m3", 4212, "Waterfall (Triple)", DecorCategory.Special, false);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\SunkenShip\\PRP_Water_SunkenShip_000.m3", 4213, "Pool (Hard-edged)", DecorCategory.Special, false);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\TorineDungeon\\PRP_Water_TorineDungeon_000.m3", 4214, "Pool (Oddly Shaped)", DecorCategory.Special, false);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Sanctuary_Common\\Galeras_Kit\\Windmill\\PRP_Building_SCGalerasWindmill_001.m3", 4215, "Windmill Tower (Geleras)", DecorCategory.Structures, true);
            AddGenericDecor("Art\\Prop\\Constructed\\MedicalStation\\PRP_MedicalStation_FloatingMedCross_000.m3", 4216, "Holographic Medical Sign", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\PellTech\\BrokenPieces\\PRP_PellTech_BrokenPiecesJunk_Aqua_000.m3", 4217, "Pell-Tech Fragment", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Prop\\Constructed\\PellTech\\BrokenAntenna\\PRP_PellTech_BrokenAntenna_000.m3", 4218, "Broken Antenna (Pell-Tech)", DecorCategory.ToolsHardware, false);
            AddGenericDecor("Art\\Mount\\Hoverboard\\Hoverboard_Default\\HoverBoard_Default.m3", 4219, "Hoverboard (Flux)", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\DominionHoverBike\\Mount_DominionHoverBike.m3", 4220, "Uniblade", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Flying\\Glider\\Mount_Glider_000.m3", 4221, "Glider", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Flying\\Puffy_Cat\\PuffyCat.m3", 4222, "Snarfelynx", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Ball\\Orbitron\\Mount_Ball_Orbitron_000.m3", 4223, "Orbitron Frame", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Boat\\Mount_Vehicle_Boat.m3", 4224, "Marauder Starsloop", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_ProtoStarEnforcer\\Mount_Vehicle_ProtoStarEnforcer.m3", 4225, "Protostar Spiderbot", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Skiff\\Mount_Vehicle_Skiff_Marauder.m3", 4226, "Marauder Skiff", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Chua\\PRP_Mount_Chua_000.m3", 4227, "Orbitron", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder.m3", 4228, "Grinder (Exile)", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DarkspurSpeeder.m3", 4229, "Grinder (Darkspur)", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder_001.m3", 4230, "Grinder (Exile, Armed)", DecorCategory.Vehicles, false);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Metal_Tech_000.m3", 4231, "Metal Tech Platform", DecorCategory.BuildingBlocks, false);


            SaveTables("../../../../TblNormal/");

            // BETA YOLO MOOOODE
            betaMode = true;


            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_Caustics.m3", null, "Point Light (Caustic, Animated)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_LavaTube.m3", null, "Point Light (Lava Tube, Moving)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Hard_Bright_Pulse.m3", null, "Point Light (Bright, Slow Pulse)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Med_Flicker.m3", null, "Point Light (Bright, Flickering)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Med_Throb.m3", null, "Point Light (Fast Pulse)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Drusera_GlowCone_000.m3", null, "Volumetric Light (Column)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Rays_LongNarrow_000.m3", null, "Volumetric Light (Sphere)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Rays_MediumWide_000.m3", null, "Volumetric Light (Sphere, Bright)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_20Man.m3", null, "Directional Light (Blue, Dappled)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_IcyPeak.m3", null, "Point Light (Bright, Dappled, Blue)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_IcyPeakPlatforms.m3", null, "Point Light (Bright, Pale Green)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_RMT_Shredder.m3", null, "Directional Light (Orange, Stops at Gizmo)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_Anim_Point_AuroriaAdventureFire_000.m3", null, "Point Light (Soft, Orange)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_Design_DatacoreElemental_Point_Med_000.m3", null, "Point Light (Soft, Pale Blue)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_Point_5m_Blue_000.m3", null, "Point Light (Soft, Blue)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_000.m3", null, "Spot Light (Ground Target, Highlight)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_001.m3", null, "Spot Light (Highlight)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_HeadLight_000.m3", null, "Spot Light (Volumetric, Flickering)", DecorCategory.LightSource, true);
            AddGenericDecor("Art\\Light\\Design\\Light_HalonRing_RotatingAstroid_000.m3", null, "Spot Light (Search Light)", DecorCategory.LightSource, true);
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
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_Splatter_Decal\\Blood_Splatter_Decal.m3", null, "Blood Splatter HoloDecal", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_Splatter_Decal\\Blood_Splatter_Decal_GRN.m3", null, "Blood Splatter HoloDecal (Green)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Black\\OT\\Splatter_Decal\\Blood_Splatter_Decal_01.m3", null, "Blood Splatter (Black)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_01.m3", null, "Blood Splatter", DecorCategory.Decals, true);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_02_GRN.m3", null, "Blood Stains (Green)", DecorCategory.Decals, true);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MineWoodBundle_Red_001.m3", null, "Cable (Coiled, Empty)", DecorCategory.ToolsHardware, false);
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
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_000.m3", null, "Slime_Genetic_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_001.m3", null, "Slime_Genetic_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_002.m3", null, "Slime_Genetic_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_003.m3", null, "Slime_Genetic_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_004.m3", null, "Slime_Genetic_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_005.m3", null, "Slime_Genetic_005", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_006.m3", null, "Slime_Genetic_006", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_007.m3", null, "Slime_Genetic_007", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_008.m3", null, "Slime_Genetic_008", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_009.m3", null, "Slime_Genetic_009", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_Floor_000.m3", null, "Slime_Genetic_Floor", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Soulfrost\\PRP_Natural_Slime_SoulfrostFloor_000.m3", null, "Soulfrost_Floor", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMedium_GreenDark_000.m3", null, "Slime_Skug_Me_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMedium_GreenDark_001.m3", null, "Slime_Skug_Me_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_000.m3", null, "Slime_Skug_Mi_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_001.m3", null, "Slime_Skug_Mi_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_002.m3", null, "Slime_Skug_Mi_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_003.m3", null, "Slime_Skug_Mi_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_000.m3", null, "Slime_Skug_S_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_001.m3", null, "Slime_Skug_S_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_002.m3", null, "Slime_Skug_S_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_003.m3", null, "Slime_Skug_S_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_004.m3", null, "Slime_Skug_S_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_005.m3", null, "Slime_Skug_S_005", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_006.m3", null, "Slime_Skug_S_006", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_007.m3", null, "Slime_Skug_S_007", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_008.m3", null, "Slime_Skug_S_008", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_009.m3", null, "Slime_Skug_S_009", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_000.m3", null, "MudCube_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_001.m3", null, "MudCube_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_002.m3", null, "MudCube_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_000.m3", null, "Slime_Honey_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_001.m3", null, "Slime_Honey_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_002.m3", null, "Slime_Honey_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_003.m3", null, "Slime_Honey_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_004.m3", null, "Slime_Honey_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_005.m3", null, "Slime_Honey_005", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_006.m3", null, "Slime_Honey_006", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_007.m3", null, "Slime_Honey_007", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_008.m3", null, "Slime_Honey_008", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_009.m3", null, "Slime_Honey_009", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_010.m3", null, "Slime_Honey_010", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_011.m3", null, "Slime_Honey_011", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_012.m3", null, "Slime_Honey_012", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_013.m3", null, "Slime_Honey_013", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_014.m3", null, "Slime_Honey_014", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_015.m3", null, "Slime_Honey_015", DecorCategory.Beta, true);
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
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\Tar_PPL\\PRP_Natural_Slime_Tar_PPL_004.m3", null, "Slime_HoneyTech_000", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_000.m3", null, "Slime_HoneyTech_001", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_001.m3", null, "Slime_HoneyTech_002", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_002.m3", null, "Slime_HoneyTech_003", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_004.m3", null, "Slime_HoneyTech_004", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_005.m3", null, "Slime_HoneyTech_005", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_006.m3", null, "Slime_HoneyTech_006", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_007.m3", null, "Slime_HoneyTech_007", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_008.m3", null, "Slime_HoneyTech_008", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_009.m3", null, "Slime_HoneyTech_009", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_011.m3", null, "Slime_HoneyTech_010", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_012.m3", null, "Slime_HoneyTech_011", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_013.m3", null, "Slime_HoneyTech_012", DecorCategory.Beta, true);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_014.m3", null, "Slime_HoneyTech_013", DecorCategory.Beta, true);
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
