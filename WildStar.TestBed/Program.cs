using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using WildStar.TestBed.GameTable;

namespace WildStar.TestBed
{
    class Program
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        static List<Table> tables = new List<Table>();

        static void Main(string[] args)
        {
            MakeArchive();
            //TestArchiveWriting();
        }

        static uint NsfwsItemId_Top = 0u;
        static uint NsfwsItemDisplayId_Top = 0u;
        static uint NsfwsItemId_Bottom = 0u;
        static uint NsfwsItemDisplayId_Bottom = 0u;
        static void MakeArchive()
        {
            LoadTables();

            AddDecorType(DecorCategory.Beta, "Beta", "INT - Beta");
            AddDecorType(DecorCategory.Unknown, "Unknown", "INT - Unknown");
            AddDecorType(DecorCategory.Structures, "Structures", "INT - Structures");
            AddDecorType(DecorCategory.Decals, "Decals", "INT - Decals");
            AddDecorType(DecorCategory.LightSource, "Light Source", "INT - Light Source");
            AddDecorType(DecorCategory.NSFWS, "NSFWS", "INT - NSFWS");

            //CharacterCustomizationBreakingChanges();

            HousingPlugUnlocks();

            CharacterCustomizationChanges();

            uint startItem2Id = 92834;
            startItem2Id = AddWeaponItems(startItem2Id);

            startItem2Id = AddCreaturesMounts(startItem2Id);
            //no more new morphs/mounts past this line-- adding NPC decor only
            uint startCreature2ID = creature2.GetMaxID();


            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\CoolShift_LUT.tex", 18, "Cool-Shift");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\WarmShift_LUT.tex", 19, "Warm-Shift");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus25_LUT.tex", 20, "Hue-Shift, Minus 25 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus50_LUT.tex", 21, "Hue-Shift, Minus 50 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus75_LUT.tex", 22, "Hue-Shift, Minus 75 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus100_LUT.tex", 23, "Hue-Shift, Minus 100 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus125_LUT.tex", 24, "Hue-Shift, Minus 125 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Minus150_LUT.tex", 25, "Hue-Shift, Minus 150 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus25_LUT.tex", 26, "Hue-Shift, Plus 25 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus50_LUT.tex", 27, "Hue-Shift, Plus 50 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus75_LUT.tex", 28, "Hue-Shift, Plus 75 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus100_LUT.tex", 29, "Hue-Shift, Plus 100 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus125_LUT.tex", 30, "Hue-Shift, Plus 125 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus150_LUT.tex", 31, "Hue-Shift, Plus 150 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\HousingDecor\\HueShift_Plus180_LUT.tex", 32, "Hue-Shift, Plus 180 Degrees");
            AddColorShift("Art\\FX\\LutMaps\\Invert_000_LUT.tex", 33, "Invert");
            AddColorShift("Art\\FX\\LutMaps\\Desaturate_000_LUT.tex", 34, "Desaturate");
            AddColorShift("Art\\FX\\LutMaps\\Black_000_LUT.tex", 35, "Black");
            AddColorShift("Art\\FX\\LutMaps\\Blue_000_LUT.tex", 36, "Blue");
            AddColorShift("Art\\FX\\LutMaps\\Gold_000_LUT.tex", 37, "Gold");
            AddColorShift("Art\\FX\\LutMaps\\White_000_LUT.tex", 38, "White");



            AddEmoteSlashCommands();

            // Unlock all skies/grounds/musics.

            foreach (var entry in wallpaperInfo.table.Entries)
            {
                entry.Values[7].SetValue(0u);
                entry.Values[8].SetValue(0u);
            }

            // Update existing NPC decor with gizmo
            List<uint> vanillaNPCDecor = new List<uint>
            {
                2261,2262,2263,2264,2265,2266,2267,2268,2269,2270,2271,2272,2273,2274,2275,2276,2277,2278,2279,2280,2281,2282,2283,2284,2285,2286,2287,2288,2289,2290,2291,2292,2293,2300,2301,2302,2462,2463,2573,2574,2579,2580,2586,2587,2589,2590,2591,2593,2594,2606,2607,2614,2615,2630,2631,2632,2633,2650,2658,2662,2663,2664,2665,2666,2667,2669,2670,2671,2672,2673,2674,2675,2676,2677,2678,2679,2680,2681,2682,2683,2687,2688,2689,2693,2694,2695,2696,2909,2973,2974,2981,2982,2983,2984,2985,2986,2987,2988,2989,2990,2991,2992,2993,2994,2995,2996,2997,2998,2999,3000,3001,3002,3003,3004,3005,3006,3007,3008,3010,3011,3012,3013,3014,3015,3016,3099,3100,3101,3102,3103,3104,3105,3106,3107,3108,3109,3110,3111,3112,3113,3114,3116,3117,3118,3119,3120,3121,3122,3123,3124,3125,3126,3127,3128,3129,3130,3131,3132,3133,3140,3141,3142,3143,3144,3145,3194,3195,3219,3220,3221,3222,3223,3224,3225,3226,3227,3228,3229,3230,3232,3233,3234,3235,3248,3249,3250,3251,3252,3253,3254,3255,3256,3257,3258,3259,3260,3261,3262,3297,3298,3299,3351,3352,3353,3354,3355,3356,3357,3358,3359,3360,3361,3362,3363,3364,3365,3366,3394,3396,3403,3404,3405,3406,3407,3438,3439,3440,3441,3442,3443,3444,3445,3446,3447,3448,3449,3450,3471,3472,3473,3474,3475,3476,3477,3478,3479,3480,3481,3482,3483,3484,3485,3486,3494,3495,3496,3508,3510,3511,3512,3513,3514,3554,3565,3566,3567,3568,3569,3570,3571,3572,3573,3574,3575,3576,3577,3578,3579,3580,3581,3582,3583,3584,3585,3586,3594,3595,3596,3597,3598,3599,3600,3601,3602,3603,3604,3605,3606,3607,3615,3653,3654,3655,3656,3657,3658,3659,3660,3661,3662,3663,3664,3665,3666,3667,3668,3692,3693,3694,3695,3696,3697,3698
            };
            foreach (uint decorInfoId in vanillaNPCDecor)
            {
                var entry = decorInfo.GetEntry(decorInfoId);
                entry.Values[13].SetValue("Art\\FX\\Housing\\Decor_FXPlacer\\Decor_FXPlacer_000.m3"); // altEditAsset
            }

            foreach (var table in tables)
            {
                table.beta = false;
            }


            AddGenericDecor("Art\\Light\\LIT_Level_Up_Spotlight_000.m3", 86, 0, 3699, "Spot Light (Level Up)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Mask_Point_Med_AurinHanging.m3", 86, 0, 3700, "Point Light (Aurin Hanging Light)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Mask_Spotlight_Gate_000.m3", 86, 0, 3701, "Spot Light (Gate)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Hard.m3", 86, 0, 3702, "Point Light (Hard)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Hard_Bright.m3", 86, 0, 3703, "Point Light (Hard, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med.m3", 86, 0, 3704, "Point Light (Medium)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med_Bright.m3", 86, 0, 3705, "Point Light (Medium, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Med_Bright_Amb.m3", 86, 0, 3706, "Point Light (Medium, Bright Ambient)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft.m3", 86, 0, 3707, "Point Light (Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Bright.m3", 86, 0, 3708, "Point Light (Soft, Bright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Overbright.m3", 86, 0, 3709, "Point Light (Soft, Overbright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Point_Soft_Throb.m3", 86, 0, 3710, "Point Light (Soft, Throb)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Hard.m3", 86, 0, 3711, "Spot Light (Hard, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Med.m3", 86, 0, 3712, "Spot Light (Medium, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Rec_Soft.m3", 86, 0, 3713, "Spot Light (Soft, Rectangle)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Diffused_Overbright.m3", 86, 0, 3714, "Spot Light (Diffused, Overbright)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Hard.m3", 86, 0, 3715, "Spot Light (Hard)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Med.m3", 86, 0, 3716, "Spot Light (Medium)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_MedNarrow_Soft.m3", 86, 0, 3717, "Spot Light (Medium, Narrow Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Narrow_Med.m3", 86, 0, 3718, "Spot Light (Medium, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Narrow_Soft.m3", 86, 0, 3719, "Spot Light (Soft, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Soft.m3", 86, 0, 3720, "Spot Light (Soft)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Hard.m3", 86, 0, 3721, "Spot Light (Hard, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Med.m3", 86, 0, 3722, "Spot Light (Medium, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\LIT_Spot_Wide_Soft.m3", 86, 0, 3723, "Spot Light (Soft, Wide)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_DIR_Crystline_001.m3", 86, 0, 3724, "Directional Light (Crystal)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_DIR_SimpleNarrow_001.m3", 86, 0, 3725, "Directional Light (Simple, Narrow)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Cubic_Fire_001.m3", 86, 0, 3726, "Point Light (Fire Texture)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_Brazier.m3", 86, 0, 3727, "Point Light (Brazier)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Point_Med_LavaTube.m3", 86, 0, 3728, "Point Light (Lava Tube)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Branches_001.m3", 86, 0, 3729, "Spot Light (Branches)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Chain.m3", 86, 0, 3730, "Spot Light (Chain Texture)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001.m3", 86, 0, 3731, "Spot Light (Dappled Light)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_001_Short.m3", 86, 0, 3732, "Spot Light (Dappled Light, Short)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002.m3", 86, 0, 3733, "Spot Light (Dappled Light 2)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_DappledLight_002_Short.m3", 86, 0, 3734, "Spot Light (Dappled Light 2, Short)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Fire_001.m3", 86, 0, 3735, "Spot Light (Fire)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Grate.m3", 86, 0, 3736, "Spot Light (Grate)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Light\\Mask_LIT_Spot_Grate_Large.m3", 86, 0, 3737, "Spot Light (Grate, Large)", DecorCategory.LightSource, true, 1);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_002.m3", 1192, 0, 3738, "Hanging Cable (Long)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_Segmented_Short_003.m3", 1192, 0, 3739, "Hanging Cable (Longer)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\Segmented\\PRP_Cable_Generic_SegmentedLong_003.m3", 1192, 0, 3740, "Hanging Cable (Long, Drooping)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cable\\Generic\\PRP_Cable_Generic_Box_000.m3", 1192, 0, 3741, "Cable Socket", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_007.m3", 1192, 0, 3742, "Phial (Medium)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_008.m3", 1192, 0, 3743, "Potion Bottle", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\SanctuaryCommon\\PRP_Bottle_SCBarBottle_009.m3", 1192, 0, 3744, "Potion Bottle (Wide)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Bottle_Granok_Beer_000.m3", 1192, 0, 3745, "Beer Bottle (Granok)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\Granok\\PRP_Granok_BeerCan_Open_000.m3", 1192, 0, 3746, "Crushed Beer Can", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_001.m3", 1192, 0, 3747, "Beer Can (Protostar)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bottles\\PRP_ProtostarBeerCan_000.m3", 1192, 0, 3748, "Crushed Beer Can (Protostar)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Bar\\SanctuaryCommon\\PRP_Bar_DrinkMixer_Gold_000.m3", 1192, 0, 3749, "Drink Mixer", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\PRP_Debris_SmugglerFighterCrashed_VAR_LeftEngine_000.m3", 1192, 0, 3750, "Ruined Fighter Wing", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_000.m3", 1192, 0, 3751, "Metal Panel (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_001.m3", 1192, 0, 3752, "Metal Panel", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Coralus\\PRP_Coralus_Ship_MetalPlate_002.m3", 1192, 0, 3753, "Metal Panel (Uneven)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Debris\\Falkrin\\PRP_Debris_FalkrinMetalPlate_000.m3", 1192, 0, 3754, "Metal Scrap", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_000.m3", 1192, 0, 3755, "Granok Trailer", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\Granok\\PRP_Building_GranokTrailer_001.m3", 1192, 0, 3756, "Granok Trailer (Sandstone)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_000.m3", 1192, 0, 3757, "Junk Shack (Tall)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Building\\SanctuaryCommon\\PRP_Building_SCShack_Brown_001.m3", 1192, 0, 3758, "Junk Shack (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotArm_Rust_000.m3", 1192, 0, 3759, "Rusty Bot Arm", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotBody_Rust_000.m3", 1192, 0, 3760, "Rusty Bot Torso", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotHead_Rust_000.m3", 1192, 0, 3761, "Rusty Bot Head", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\BotParts\\PRP_BotParts_SaboteurbotLeg_Rust_000.m3", 1192, 0, 3762, "Rusty Bot Leg", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_000.m3", 1192, 0, 3763, "Metal Pipe Tower", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_001.m3", 1192, 0, 3764, "Large Metal Tank", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_002.m3", 1192, 0, 3765, "Metal Scaffolding (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Refinery\\PRP_Pipes_Refinery_003.m3", 1192, 0, 3766, "Metal Scaffolding ", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_002.m3", 1192, 0, 3767, "Dreadmoor Tube (Intersection)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_005.m3", 1192, 0, 3768, "Dreadmoor Tube (Straight)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_006.m3", 1192, 0, 3769, "Dreadmoor Tube (Narrowing, Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_007.m3", 1192, 0, 3770, "Dreadmoor Tube (Corner)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_008.m3", 1192, 0, 3771, "Dreadmoor Tube (Narrowing, Short)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_009.m3", 1192, 0, 3772, "Dreadmoor Tube (Narrowing, Curved)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_010.m3", 1192, 0, 3773, "Metal Support Beams", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_011.m3", 1192, 0, 3774, "Metal Support Beams (Double)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_013.m3", 1192, 0, 3775, "Metal Rod", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_014.m3", 1192, 0, 3776, "Faucet", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_000.m3", 1192, 0, 3777, "Crooked Pipe", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipe_ManHole_RMC_000.m3", 1192, 0, 3778, "Metal Pipe Cap", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_PipeBase_RMC_000.m3", 1192, 0, 3779, "Redmoon Ventilation Pipes", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_000.m3", 1192, 0, 3780, "Metal Tube (Curved)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_001.m3", 1192, 0, 3781, "Metal Tube", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_002.m3", 1192, 0, 3782, "Metal Tube (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_003.m3", 1192, 0, 3783, "Metal Tube (Corner)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_004.m3", 1192, 0, 3784, "Metal Pipe Moderator", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_005.m3", 1192, 0, 3785, "Chua Sphere", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_006.m3", 1192, 0, 3786, "Metal Tube (Reinforced)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_007.m3", 1192, 0, 3787, "Metal Tube (Cap)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_008.m3", 1192, 0, 3788, "Metal Tube (Short)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_009.m3", 1192, 0, 3789, "Chua Orb", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_010.m3", 1192, 0, 3790, "Chua Orb (Large)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKitSegment_011.m3", 1192, 0, 3791, "Chua Window", DecorCategory.Windows, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_002.m3", 1192, 0, 3792, "Tank (Chua, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_001.m3", 1192, 0, 3793, "Valve (Round)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_004.m3", 1192, 0, 3794, "Valve", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_Tap_GreyBrown_001.m3", 1192, 0, 3795, "Rusty Watertap", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Arkship\\PRP_Container_Arkship_RelicCrate_001.m3", 1192, 0, 3796, "Shipping Crate (Open)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Arkship\\PRP_Container_Arkship_RelicCrate_002.m3", 1192, 0, 3797, "Shipping Crate Lid", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Chua\\PRP_Chua_Container_002.m3", 1192, 0, 3798, "Chua Speaker", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Chua\\PRP_Chua_Container_003.m3", 1192, 0, 3799, "Tank (Chua, Small)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_000.m3", 1192, 0, 3800, "Metal Canister (Broken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_001.m3", 1192, 0, 3801, "Metal Canister (Damaged)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Toxic\\PRP_Ruin_ToxicContainers_002.m3", 1192, 0, 3802, "Metal Canister Fragment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Generic\\PRP_Container_Generic_Cannister_000.m3", 1192, 0, 3803, "Canister (Ornate)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Ikthian_ContainerBot_Boxy_001.m3", 1192, 0, 3804, "Treasure Chest (Ikthian, Open)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Container_PlasmaAquaLiquid_BlueYellow_000.m3", 1192, 0, 3805, "Plasma Canister (Ikthian)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Ikthian\\PRP_Container_PlasmaAquaLiquid_BlueYellow_001.m3", 1192, 0, 3806, "Plasma Canister (Ikthian, Broken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MachineGun\\Tribal\\PRP_Turret_Tribal_000.m3", 1192, 0, 3807, "Turret Barrel", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularShort_000.m3", 1192, 0, 3808, "Metal Beam", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularLong_000.m3", 1192, 0, 3809, "Metal Beam (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularLargeLong_000.m3", 1192, 0, 3810, "Metal Beam (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularBroken_001.m3", 1192, 0, 3811, "Metal Beam (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_MetalBeam_MineModularTFrame_000.m3", 1192, 0, 3812, "Metal Beam Pillar", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularShort_Brown_000.m3", 1192, 0, 3813, "Wooden Beam", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularLong_Brown_000.m3", 1192, 0, 3814, "Wooden Beam (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularLargeLong_Brown_000.m3", 1192, 0, 3815, "Wooden Beam (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularBroken_Brown_000.m3", 1192, 0, 3816, "Wooden Beam (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeam_MineModularTFrame_Brown_000.m3", 1192, 0, 3817, "Wooden Beam Pillar", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamConnector_MineModularMetal_Grey_001.m3", 1192, 0, 3818, "Metal Beam Connector", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamConnector_MineModularMetal_Grey_002.m3", 1192, 0, 3819, "Metal Beam Connector (2)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_000.m3", 1192, 0, 3820, "Hanging Wire (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_001.m3", 1192, 0, 3821, "Hanging Wire (Spiraling)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_002.m3", 1192, 0, 3822, "Hanging Wire (Coiled)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\PRP_WoodenBeamWire_MineModularHanging_Grey_003.m3", 1192, 0, 3823, "Hanging Wire", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ScienceInstruments\\General\\PRP_General_LargeMicroscope_000.m3", 1192, 0, 3824, "Microscope", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ScienceInstruments\\General\\PRP_General_SmallScanner_000.m3", 1192, 0, 3825, "Medical Scanner", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\PRP_ArkShip_Planter_007.m3", 1192, 0, 3826, "Robotic Arm Segment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\PRP_Bank_Atm_Generic_000.m3", 1192, 0, 3827, "ATM Machine", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Freebot\\PRP_Machinery_FreebotTransformer_Green_000.m3", 1192, 0, 3828, "Freebot Transformer", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Freebot\\PRP_Machinery_FreebotWelder_Green_000.m3", 1192, 0, 3829, "Freebot Welding Unit", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Machinery\\Chua\\PRP_Machinery_ChuaDrill_000.m3", 1192, 0, 3830, "Chua Drill Pod", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pillar\\Osun\\PRP_Pillar_OsunHead_000.m3", 1192, 0, 3831, "Osun Bust", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Pillar\\Algeroc\\PRP_StructuralPillar_AlgorocMineSupport_Brown_000.m3", 1192, 0, 3832, "Wooden Column", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\PRP_Weapon_TranquilizerRounds_000.m3", 1192, 0, 3833, "Tranquilizer Rounds", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_000.m3", 1192, 0, 3834, "Missile (Cluster)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_001.m3", 1192, 0, 3835, "Missile (Ballistic)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Weapon\\Missile\\PRP_Weapon_Missile_002.m3", 1192, 0, 3836, "Missile (Angry)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Television\\Pell\\PRP_Television_Pell_000.m3", 1192, 0, 3837, "Pell Monitor", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Barrel_000.m3", 1192, 0, 3838, "Cannon Barrel", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Barrel_001.m3", 1192, 0, 3839, "Cannon Barrel (Exile)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Defiance\\OrangeSilver_Parts\\PRP_Cannon_DefianceLarge_OrangeSilver_Shield_000.m3", 1192, 0, 3840, "Metal Panel (Exile Decal)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Cannon\\Imperium\\PRP_Turret_ImperiumMilitary_000.m3", 1192, 0, 3841, "Turret (Dominion)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_000.m3", 1192, 0, 3842, "Beaker and Vial", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_001.m3", 1192, 0, 3843, "Beaker (Empty)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Blue_000.m3", 1192, 0, 3844, "Beaker (Blue, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Blue_001.m3", 1192, 0, 3845, "Beaker (Blue)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Green_000.m3", 1192, 0, 3846, "Beaker (Green, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Green_001.m3", 1192, 0, 3847, "Beaker (Green)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Purple_000.m3", 1192, 0, 3848, "Beaker (Purple, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Purple_001.m3", 1192, 0, 3849, "Beaker (Purple)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Red_000.m3", 1192, 0, 3850, "Beaker (Red, Conical)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_Beaker_Red_001.m3", 1192, 0, 3851, "Beaker (Red)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ChemistrySet_000.m3", 1192, 0, 3852, "Chemistry Set", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ScrewDriver.m3", 1192, 0, 3853, "Screwdriver", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_SHookMetal_Gray_003.m3", 1192, 0, 3854, "Metal Hook", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\PRP_Tools_ToolCase_000.m3", 1192, 0, 3855, "Tool Case", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MinePileBundle_Red_000.m3", 1192, 0, 3856, "Wire Bundle", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MinePileBundle_Red_002.m3", 1192, 0, 3857, "Wire Bundle (Large)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Shelter\\PRP_Tools_shedgenericanimalshelter_brownrust_000.m3", 1192, 0, 3858, "Open Shed", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Pots_and_Pans\\PRP_Tools_PotsPans_000.m3", 1192, 0, 3859, "Empty Pot (Small)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\PRP_GearPile_Grey_000.m3", 1192, 0, 3860, "Gear Pile", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_LargeGear_000.m3", 1192, 0, 3861, "Freebot Gear (Large)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_LargeGear_001.m3", 1192, 0, 3862, "Freebot Gear (Large, Tight)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_MediumGear_000.m3", 1192, 0, 3863, "Freebot Gear (Jagged)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\gear\\RobotRuin\\PRP_Gear_RobotRuin_SmallGear_000.m3", 1192, 0, 3864, "Freebot Gear (Small)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Arkship_Tram_000.m3", 1192, 0, 3865, "Arkship Tram", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Imperium_White_000.m3", 1192, 0, 3866, "Lifter (with Handle)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Lifter\\PRP_Lifter_Imperium_White_001.m3", 1192, 0, 3867, "Lifter", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\House\\Pell\\Large\\PRP_PellHouse_Large_000.m3", 1192, 0, 3868, "Pell House (Large)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\House\\Pell\\Small\\PRP_PellHouse_Small_000.m3", 1192, 0, 3869, "Pell House (Small)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokCorner_000.m3", 1192, 0, 3870, "Granok Platform (Junction)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokLeftTurn_000.m3", 1192, 0, 3871, "Granok Stairs (Curved, Left)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokLongStairs_000.m3", 1192, 0, 3872, "Granok Stairs", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokPlatform_000.m3", 1192, 0, 3873, "Granok Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokRightTurn_000.m3", 1192, 0, 3874, "Granok Stairs (Curved, Right)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokShortStairs_000.m3", 1192, 0, 3875, "Granok Stairs & Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokStairs_000.m3", 1192, 0, 3876, "Granok Stairs (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_GranokStraight_000.m3", 1192, 0, 3877, "Granok Platform (Long)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_LargeWoodPlank_000.m3", 1192, 0, 3878, "Wooden Plank (Thick)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\Granok\\PRP_Scaffolding_Rope_000.m3", 1192, 0, 3879, "Hanging Rope", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_StraightPlatform_000.m3", 1192, 0, 3880, "Scaffold Catwalk (Segment, no Fence)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_StraightPlatform_001.m3", 1192, 0, 3881, "Scaffold Catwalk (Short, no Fence)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_TallSmallPlatform_000.m3", 1192, 0, 3882, "Scaffold Catwalk (Short, Single Fence)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Scaffolding\\PRP_Scaffolding_TallStraightPlatform_000.m3", 1192, 0, 3883, "Scaffold Catwalk (Medium, no Fence, Jutting Beams)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Desk\\Protostar\\PRP_Protostar_Desk_000.m3", 1192, 0, 3884, "Protostar Desk (Left)", DecorCategory.Tables, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Desk\\Protostar\\PRP_Protostar_Desk_001.m3", 1192, 0, 3885, "Protostar Desk (Right)", DecorCategory.Tables, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Defiance\\PRP_DefianceMilitary_TableControlPanel_000.m3", 1192, 0, 3886, "Data Panel (Exile)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Defiance\\PRP_DefianceMilitary_TableControlPanel_004.m3", 1192, 0, 3887, "Wall Panel (Exile, Inverted)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Marauder\\PRP_ControlPanel_Marauder_Platform_000.m3", 1192, 0, 3888, "Control Panel (Marauder)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Mechari\\PRP_mechari_iciinfocolumn_000.m3", 1192, 0, 3889, "Information Terminal (Mechari)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Osun\\PRP_ControlPanel_Osun_Lever_000.m3", 1192, 0, 3890, "Osun Lever", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Explorer_000.m3", 1192, 0, 3891, "Control Panel (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Base_Monitor_Standing_001.m3", 1192, 0, 3892, "Floor Panel (Dominion)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Screen_000.m3", 1192, 0, 3893, "Data Panel (Dominion)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\PRP_ControlPanel_Imperium_Screen_001.m3", 1192, 0, 3894, "Dominion Monitor", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_Antenna_Pell_000.m3", 1192, 0, 3895, "Antenna (Pell)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_003.m3", 1192, 0, 3896, "Pell-Tech Device (Large)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_004.m3", 1192, 0, 3897, "Pell-Tech Device (Medium)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Pell\\PRP_ControlPanel_Pell_005.m3", 1192, 0, 3898, "Pell-Tech Device (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_000.m3", 1192, 0, 3899, "Shiphand Console", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_MonitorOcular_000.m3", 1192, 0, 3900, "Shiphand Console (Ocular)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_MonitorSmallMid_000.m3", 1192, 0, 3901, "Shiphand Console (Small)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\ControlPanel\\Shiphand\\PRP_ControlPanel_ShipHand_SixButtonWallMonitor_000.m3", 1192, 0, 3902, "Control Panel (Shiphand)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\Pell\\PRP_Jar_Pell_000.m3", 1192, 0, 3903, "Dubious Jar", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\Imperium\\PRP_Jar_Imperium_000.m3", 1192, 0, 3904, "Dominion Pot", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jar\\PRP_Jar_SmugglerPearShaped_Red_000.m3", 1192, 0, 3905, "Jar (Ornate, Painted)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Jetpack\\Jetpack.m3", 1192, 0, 3906, "Jetpack", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_QuestJobBoard_000.m3", 1192, 0, 3907, "Job Board (Adventuring)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_000.m3", 1192, 0, 3908, "Job Board (Engineering)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_001.m3", 1192, 0, 3909, "Job Board Panel", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_002.m3", 1192, 0, 3910, "Job Board Pole", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_003.m3", 1192, 0, 3911, "Mechanicbot Pole", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\PRP_Tradeskill_JobBoard_004.m3", 1192, 0, 3912, "Job Board Panel (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\Weaponsmith\\PRP_Tradeskill_Weaponsmith_CraftingStation_000.m3", 1192, 0, 3913, "Crafting Station (Weapons)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tradeskill\\Generic\\PRP_Tradeskill_GenericTable_000.m3", 1192, 0, 3914, "Crafting Station", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Cap_000.m3", 1192, 0, 3915, "Eldan Circuit Cap", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Cap_001.m3", 1192, 0, 3916, "Eldan Circuit Cap (Advanced)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Tubes_000.m3", 1192, 0, 3917, "Eldan Pylon", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Circuit_Tubes_Technophage_000.m3", 1192, 0, 3918, "Eldan Pylon (Technophage)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Floors\\Eldan\\PRP_Floor_Pod_FuelRods_002.m3", 1192, 0, 3919, "Eldan Fuel Rod Cap", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Warplots\\PRP_Generator_Warplots_Widget_000.m3", 1192, 0, 3920, "Generator (Arkship)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Tribal\\PRP_Generator_Batteries_Tribal_000.m3", 1192, 0, 3921, "Fusion Battery", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\Tribal\\PRP_Generator_Tribal_000.m3", 1192, 0, 3922, "Generator (Simple)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Generator\\PRP_ArkShip_GeneratorSmall_000.m3", 1192, 0, 3923, "Generator (Small, Arkship)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Drakken\\PRP_Drakken_Spike_Barier_000.m3", 1192, 0, 3924, "Draken Weapons", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Legendary\\PRP_Quest_Legendary_Maiden_000.m3", 1192, 0, 3925, "Sword (Torine, Floating)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\PRP_Quest_Lore_Paper_000.m3", 1192, 0, 3926, "Paper Note (Aged)", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\PRP_Quest_Lore_Scroll_000.m3", 1192, 0, 3927, "Paper Scroll", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Lore\\prp_quest_lore_paper_001.m3", 1192, 0, 3928, "Paper Note (Simple)", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\JonnyCab\\PRP_JonnyCab_000.m3", 1192, 0, 3929, "TaxiBot", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\JonnyCab\\PRP_JonnyCab_001.m3", 1192, 0, 3930, "TaxiBot (Hologram)", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Taxi\\TaxiKiosk\\PRP_Taxi_Kiosk_000.m3", 1192, 0, 3931, "Taxi Kiosk", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_000.m3", 1192, 0, 3932, "Open Metal Crate (Empty)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_001.m3", 1192, 0, 3933, "Relic Crate", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_Content_004.m3", 1192, 0, 3934, "Science Crate", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Crate_small_Toys_001.m3", 1192, 0, 3935, "Toy Crate", DecorCategory.Toys, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_FinishLine_GroundChecker_000.m3", 1192, 0, 3936, "Finish Line", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_HandSnowFrozen_Blue_000.m3", 1192, 0, 3937, "Lost Arm (Frozen)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Hand_000.m3", 1192, 0, 3938, "Lost Arm", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_HousingJobBoard_000.m3", 1192, 0, 3939, "Job Board (Roofed)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_000.m3", 1192, 0, 3940, "Teleporter", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_Eldan_000.m3", 1192, 0, 3941, "Teleporter (Eldan)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Teleporter_Protostar_000.m3", 1192, 0, 3942, "Teleporter (Protostar)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\PRP_Quest_Vendor_Generic_000.m3", 1192, 0, 3943, "Vendor Terminal", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Crate\\PRP_Quest_Crate_Blue_000.m3", 1192, 0, 3944, "Metal Crate (Blue)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Quest\\Crate\\PRP_Quest_Crate_Gold_000.m3", 1192, 0, 3945, "Metal Crate (Golden)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_000.m3", 1192, 0, 3946, "Force Field", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_001.m3", 1192, 0, 3947, "Force Field (Low)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Forcefield_Red_Emissive_000.m3", 1192, 0, 3948, "Forcefield, Red", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Generic\\PRP_Door_Generic_Garage_000.m3", 1192, 0, 3949, "Garage Door (Wooden)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Cellar\\PRP_CellarDoor_SancCommonDoor_000.m3", 1192, 70052, 3950, "Cellar Door", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Drakken\\PRP_Door_DrakkenMetalGate_000.m3", 1192, 0, 3951, "Metal Gate (Draken)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_RobotSilo_000.m3", 1192, 0, 3952, "Eldan Silo Door", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_RobotSilo_Broken_000.m3", 1192, 0, 3953, "Eldan Silo Door (Broken)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_IrisEldanMicro_001.m3", 1192, 0, 3954, "Door (Eldan)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_LargeEldanDungeon_000.m3", 1192, 0, 3955, "Eldan Gate (Large)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Eldan\\PRP_Door_SmallEldanDungeon_000.m3", 1192, 0, 3956, "Eldan Gate (Small)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Ikthian\\PRP_Ikthian_Door_000.m3", 1192, 0, 3957, "Metal Door (Ikthian)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Imperium\\PRP_Door_ImperiumTower_Bottom_000.m3", 1192, 70052, 3958, "Door (Dominion, Tall)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Imperium\\PRP_Door_ImperiumTower_Top_000.m3", 1192, 70052, 3959, "Door (Dominion)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Marauder\\PRP_Door_CellDoorSML_000.m3", 1192, 0, 3960, "Door (Prison)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Marauder\\PRP_Door_RMC_Small_000.m3", 1192, 0, 3961, "Door (Marauder)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Minekit\\PRP_Door_AlgorocMineDoor_Brown_001.m3", 1192, 0, 3962, "Wooden Arch (Protostar)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Moodie\\PRP_Door_Frame_Moodie_002.m3", 86, 0, 3963, "Elevated Brazier (Moodie)", DecorCategory.Lighting, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Osun\\PRP_Door_Osun_B_000.m3", 1192, 0, 3964, "Osun Stone Panel", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Osun\\PRP_Door_Osun_B_CinematicInteraction.m3", 1192, 0, 3965, "Osun Face Carving", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\Protostar\\PRP_Door_Protostar_Metal_Large_000.m3", 1192, 0, 3966, "Garage Door (Protostar, Flat)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\ShipHand\\PRP_Shiphand_Door_000.m3", 1192, 0, 3967, "Metal Door (Shiphand)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Door\\ShipHand\\PRP_Shiphand_Door_Airlock_000.m3", 1192, 0, 3968, "Airlock (Shiphand)", DecorCategory.Doors, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Berserker_000.m3", 1192, 0, 3969, "Hoverboard (Berserker)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Berserker_Customization_000.m3", 1192, 0, 3970, "Hoverboard (Berserker, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Fang_000.m3", 1192, 0, 3971, "Hoverboard (Fang)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Fang_Customization_000.m3", 1192, 0, 3972, "Hoverboard (Fang, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_GoGo_000.m3", 1192, 0, 3973, "Hoverboard (GoGo)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_GoGo_Customization_000.m3", 1192, 0, 3974, "Hoverboard (GoGo, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Ringer_000.m3", 1192, 0, 3975, "Hoverboard (Ringer)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Ringer_Customization_000.m3", 1192, 0, 3976, "Hoverboard (Ringer, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Turbine_000.m3", 1192, 0, 3977, "Hoverboard (Turbine)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\Winterfest\\Hoverboard\\PRP_Turbine_Customization_000.m3", 1192, 0, 3978, "Hoverboard (Turbine, Flaired)", DecorCategory.Hoverpark, false, 2);
            AddGenericDecor("Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", 1192, 0, 3979, "Emblem (Dominion)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", 1192, 0, 3980, "Emblem (Exile)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_Bullseye_000.m3", 1192, 0, 3981, "Bullseye", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_Bullseye_001.m3", 1192, 0, 3982, "Bullseye (Charred)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_DarkspurSkull_000.m3", 1192, 0, 3983, "Decal (Darkspur)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Decals\\PRP_Misc_Decals_NuclearSign_000.m3", 1192, 0, 3984, "Decal (Nuclear)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Drakken\\PRP_MISC_DrakkenBonedStorage_000.m3", 1192, 0, 3985, "Ancestral Urn (Draken)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Drakken\\PRP_MISC_DrakkenSpikedFooty_000.m3", 1192, 0, 3986, "Metal Boot Tip (Draken)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Eldan\\Dome\\PRP_Eldan_AKA_Core_000.m3", 1192, 0, 3987, "Eldan Core", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Eldan\\Dome\\PRP_Eldan_Dome_Broken_000.m3", 1192, 0, 3988, "Eldan Dome (Broken)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_000.m3", 1192, 0, 3989, "Coconut", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_001.m3", 1192, 0, 3990, "Coconut (Opened)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_MISC_Food_coconut_003.m3", 1192, 0, 3991, "Coconut Pile", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_000.m3", 1192, 0, 3993, "Graffiti (Yellow-Violet Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_001.m3", 1192, 0, 3994, "Graffiti (Alien Head)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_002.m3", 1192, 0, 3995, "Graffiti (Yellow-Purple Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_003.m3", 1192, 0, 3996, "Graffiti (Teal Skull)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_004.m3", 1192, 0, 3997, "Graffiti (Green-White Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_005.m3", 1192, 0, 3998, "Graffiti (Magenta-Teal Text)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_MISC_Grafitti_Judge_Kain_000.m3", 1192, 0, 3999, "Graffiti (Judge Kain)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Grafitti\\PRP_Marauder_Grafitti_000.m3", 1192, 0, 4000, "Graffiti (Marauder)", DecorCategory.Decals, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_000.m3", 1192, 0, 4001, "Space Helm", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_001.m3", 1192, 0, 4002, "Space Helm (Draken)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_Bubble_002.m3", 1192, 0, 4003, "Space Helm (Grumpel)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Hat\\PRP_MISC_Hat_TopHat_000.m3", 1192, 0, 4004, "Fancy Top Hat", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\KiddiePool\\PRP_KiddiePool_000.m3", 1192, 0, 4005, "Kiddie Pool", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Camera_Generic_001.m3", 1192, 0, 4006, "Security Camera", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_DoorKnocker_Granok.m3", 1192, 0, 4007, "Door Knocker (Granok)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Arms_000.m3", 1192, 0, 4008, "Mechari Spare Arms", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Legs_000.m3", 1192, 0, 4009, "Mechari Spare Legs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Mechari_Parts_Torso_000.m3", 1192, 0, 4010, "Mechari Spare Torso", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Mechari_Head\\Mechari_Head_Female.m3", 1192, 0, 4011, "Mechari Head (Pink)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Mechari_Head\\PRP_Mechari_Head_Female_001.m3", 1192, 0, 4012, "Mechari Head (Red)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_MISC_PowerCell_000.m3", 1192, 0, 4013, "Power Cell", DecorCategory.Electronics, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\PRP_Poodad.m3", 1192, 0, 4014, "Poodad", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Tire\\PRP_Misc_Tire_001.m3", 1192, 0, 4015, "Tire (Hollow)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_000.m3", 1192, 0, 4016, "Plain Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_002.m3", 1192, 0, 4017, "Striped Towel (Vertical)", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_004.m3", 1192, 0, 4018, "Invoker Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Towels\\PRP_Towel_White_005.m3", 1192, 0, 4019, "Fancy Green Towel", DecorCategory.Bathroom, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers.m3", 1192, 0, 4020, "Stadium Seating (Large)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Cap.m3", 1192, 0, 4021, "Stadium Seating (Cap)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Half_000.m3", 1192, 0, 4022, "Stadium Seating", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Vindball\\Bleachers\\PRP_VindballBleachers_Half_001.m3", 1192, 0, 4023, "Stadium Seating (Uncapped)", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_000.m3", 1192, 0, 4024, "Ritual Pot (Pell, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_002.m3", 1192, 0, 4025, "Open Ritual Pot (Pell)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Container\\Pell\\PRP_Container_MetalRoundPell_Green_003.m3", 1192, 0, 4026, "Open Ritual Pot (Pell, Tall)", DecorCategory.Containers, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\WorldDestroyer_Head_Destroyed.m3", 1192, 0, 4027, "Annihilator Head (Destroyed)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSLeftHorn_000.m3", 1192, 0, 4028, "Cyclopean Horn (Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSLeftJaw_000.m3", 1192, 0, 4029, "Cyclopean Jaw (Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSRightHorn_000.m3", 1192, 0, 4030, "Cyclopean Horn (Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSRightJaw_000.m3", 1192, 0, 4031, "Cyclopean Jaw (Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GHSSkull_000.m3", 1192, 0, 4032, "Cyclopean Skull", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\WorldRuins\\GiantHornedSkull\\PRP_WorldRuin_GiantHornedSkull_000.m3", 1192, 0, 4033, "Cyclopean Horned Skull", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Bridge_A.m3", 1192, 0, 4034, "Osun Bridge", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Short_A.m3", 1192, 0, 4035, "Osun Tower (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Tall_A.m3", 1192, 0, 4036, "Osun Stone Tower (Adorned)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Connector_Tall_B.m3", 1192, 0, 4037, "Osun Stone Tower", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Detail_WolfHead_A.m3", 1192, 0, 4038, "Osun Wolf Tower", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Short_A.m3", 1192, 0, 4039, "Osun Gate", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Tall_A.m3", 1192, 0, 4040, "Osun Siege Gate ", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Gate_Tall_B.m3", 1192, 0, 4041, "Osun Siege Gate (Ramped)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Stairs_A.m3", 1192, 0, 4042, "Osun Stairs", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Stairs_B.m3", 1192, 0, 4043, "Osun Stairs (Wide)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_000.m3", 1192, 0, 4044, "Osun Walkway", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_A.m3", 1192, 0, 4045, "Osun Wall Segment (Slanted, In, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_B.m3", 1192, 0, 4046, "Osun Wall Segment (Slanted, In, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_C.m3", 1192, 0, 4047, "Osun Wall Segment (Slanted, Out, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_D.m3", 1192, 0, 4048, "Osun Wall Segment (Slanted, Out, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Curve_E.m3", 1192, 0, 4049, "Osun Wall Segment", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Double_A.m3", 1192, 0, 4050, "Osun Siege Wall", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_CurveDouble_A.m3", 1192, 0, 4051, "Osun Siege Wall (Curved, Inward)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_CurveDouble_B.m3", 1192, 0, 4052, "Osun Siege Wall (Curved, Outward)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Half_A.m3", 1192, 0, 4053, "Osun Siege Wall Trim", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_A.m3", 1192, 0, 4054, "Osun Wall (Low)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_B.m3", 1192, 0, 4055, "Osun Wall (Low, Ramp)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Short_C.m3", 1192, 0, 4056, "Osun Wall (Low, Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Wall_Tall_B.m3", 1192, 0, 4057, "Osun Wall (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit_Ruins\\PRP_Osun_Entrance_Small.m3", 1192, 0, 4058, "Osun Entrance", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder_weapons_000.m3", 1192, 0, 4059, "Rocket Launcher (Exile, Small)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_001.m3", 1192, 0, 4060, "Bone Pile", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_002.m3", 1192, 0, 4061, "Bone Pile (Double)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanBonePile_003.m3", 1192, 0, 4062, "Bone Pile (Elongated)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanSkeleton_Tan_000.m3", 1192, 0, 4063, "Skeleton (Hanging)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_Bones_HumanSkeleton_Tan_002.m3", 1192, 0, 4064, "Skull (Human, Screaming)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\HumanBones\\PRP_HumanSkull_003.m3", 1192, 0, 4065, "Skull (Human, Angry)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\Dinosaur\\PRP_Bones_Dinosaur_Skull_000.m3", 1192, 0, 4066, "Giant Skull (Dinosaur)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_000.m3", 1192, 0, 4067, "Skull (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_001.m3", 1192, 0, 4068, "Skull (Roc, Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_002.m3", 1192, 0, 4069, "Skeletal Jaw (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_003.m3", 1192, 0, 4070, "Giant Ribcage (Roc)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_004.m3", 1192, 0, 4071, "Ribcage Bridge", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_005.m3", 1192, 0, 4072, "Ribcage Ramp", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_006.m3", 1192, 0, 4073, "Giant Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_SkullJawBig_Tan_007.m3", 1192, 0, 4074, "Giant Jaw Fragment", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_DragonSkeleton_Jaw_Tan_000.m3", 1192, 0, 4075, "Dragon Skull (Jaw)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_DragonSkeleton_Skull_Tan_000.m3", 1192, 0, 4076, "Dragon Skull (Upper)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_EnvironmentHazard_Trap_000.m3", 1192, 0, 4077, "Rib Cluster", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_GirokSkullClean_Tan_000.m3", 1192, 0, 4078, "Skull (Girrok)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Hand_Large_Tan_000.m3", 1192, 0, 4079, "Giant Skeletal Hand", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegAnimalClean_Tan_000.m3", 1192, 0, 4080, "Bone", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegwithMeat_Tan_001.m3", 1192, 0, 4081, "Meaty Rib", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LegwithMeat_Tan_002.m3", 1192, 0, 4082, "Meaty Bone", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_LongBone_Large_Tan_000.m3", 1192, 0, 4083, "Bone (Massive)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_PumeraSkullClean_Tan_000.m3", 1192, 0, 4084, "Skull (Pumera)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RhinoSkull_Small_Tan_000.m3", 1192, 0, 4085, "Skull (Mammodin, Juvenile)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RhinoSkull_SquareHorn_Tan_000.m3", 1192, 0, 4086, "Skull (Mammodin, Adult)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_000.m3", 1192, 0, 4087, "Ribcage (Whole)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_001.m3", 1192, 0, 4088, "Ribcage (Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_002.m3", 1192, 0, 4089, "Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_004.m3", 1192, 0, 4090, "Ribs (Half, left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalClean_Tan_005.m3", 1192, 0, 4091, "Ribs (Half, right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Hide_Large_Tan_000.m3", 1192, 0, 4092, "Giant Ribcage (Spiny, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Hide_Large_Tan_001.m3", 1192, 0, 4093, "Giant Ribcage (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_000.m3", 1192, 0, 4094, "Giant Ribcage (Spiny)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_001.m3", 1192, 0, 4095, "Giant Ribcage (Half)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsAnimalOld_Large_Tan_002.m3", 1192, 0, 4096, "Giant Ribcage (Half, Collapsed)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibsEarthrender_Large_Tan_000.m3", 1192, 0, 4098, "Giant Ribcage (Earth-Render)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_000.m3", 1192, 0, 4099, "Ribcage (Whole, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_001.m3", 1192, 0, 4100, "Ribcage (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_002.m3", 1192, 0, 4101, "Ribs (Half, Fleshy)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithMeat_Tan_003.m3", 1192, 0, 4102, "Human Ribs", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_000.m3", 1192, 0, 4103, "Ribs (Half, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_001.m3", 1192, 0, 4104, "Ribcage (Half, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_RibwithTar_Tan_002.m3", 1192, 0, 4105, "Ribcage (Whole, Tar)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_SingleRib_Large_Tan_000.m3", 1192, 0, 4106, "Giant Rib", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Skull_BirdLikeWithTeath_Tan_000.m3", 1192, 0, 4107, "Skull (Giant Pirahna)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_Skull_RhinoWithTeath_Tan_000.m3", 1192, 0, 4108, "Skull (Rhino, Tusks)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_Bones_SpineAnimalClean_Tan_000.m3", 1192, 0, 4109, "Misplaced Spine", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_000.m3", 1192, 0, 4110, "Fishing Line", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_001.m3", 1192, 0, 4111, "Hanging Fish (Clustered)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_002.m3", 1192, 0, 4112, "Hanging Fish (Spread)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_003.m3", 1192, 0, 4113, "Fish Carcasses (Clustered)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_004.m3", 1192, 0, 4114, "Fish Carcasses (Spread)", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_005.m3", 1192, 0, 4115, "Fish Skeleton", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\AnimalBones\\PRP_AnimalBones_FishBones_Tan_006.m3", 1192, 0, 4116, "Fish Carcass", DecorCategory.CookwareBarware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_003.m3", 1192, 0, 4117, "Weapon Rack (Draken, Empty)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\ToolShed\\PRP_Tools_shedgenericwood_brownrust_000.m3", 1192, 0, 4118, "Tool Shed (Table)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\ToolShed\\PRP_Tools_shedgenericwood_brownrust_001.m3", 1192, 0, 4119, "Tool Shed", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\TorineDungeon\\PRP_Water_TorineDungeon_001.m3", 1192, 0, 4120, "Pool of Blood", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_OGE.m3", 1192, 0, 4121, "Lava Eruption (Line)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Lava_LinearEruption\\Lava_LinearEruption_noDecal_OGE.m3", 1192, 0, 4122, "Lava Eruption (Line, Scorching)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Impacts\\Lava_Splash\\Lava_Splash_OGE.m3", 1192, 0, 4123, "Lava Splash", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_10mR.m3", 1192, 0, 4124, "Lava Spring (Large)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringHeavy_5mR.m3", 1192, 0, 4125, "Lava Spring (Medium)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_10mR.m3", 1192, 0, 4126, "Lava Bubbles (Large, Ring)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_SpringRing_NoGeo_15mR.m3", 1192, 0, 4127, "Lava Bubbles (Medium, Ring)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_10mR.m3", 1192, 0, 4128, "Lava Pool (Large, Grounded)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_3mR.m3", 1192, 0, 4129, "Lava Pool (Small, Bubbling)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR.m3", 1192, 0, 4130, "Lava Pool (Medium)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_AQU.m3", 1192, 0, 4131, "Lava Pool (Medium, Teal)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_5mR_GLD.m3", 1192, 0, 4132, "Lava Pool (Medium, Gold)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_3mR.m3", 1192, 0, 4133, "Lava Bubbles (Small)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_5mR.m3", 1192, 0, 4134, "Lava Bubbles (Medium, Grounded)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGeo_NoGrndConst_5mR.m3", 1192, 0, 4135, "Lava Bubbles (Medium)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Spring\\Lava_Spring_NoGrndConst_10mR.m3", 1192, 0, 4136, "Lava Pool (Large)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Model\\OT\\Lava_Wave\\Lava_Wave.m3", 1192, 0, 4137, "Lava Bubbles (Violent, Line)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_Eruption_2mR_4mH_OGE.m3", 1192, 0, 4138, "Lava Burst (Scorching)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Eruption\\Lava_LinearEruption_2mR_4mH_NoDecal_OGE.m3", 1192, 0, 4139, "Lava Burst", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Model\\Props\\Lava_Geyser\\Lava_Geyser_OGE.m3", 1192, 0, 4140, "Lava Geyser", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Prop\\Dungeon\\Datascape\\LavaRock\\PRP_Datascape_LavaRock_000.m3", 1192, 0, 4141, "Volcanic Rock", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Islands\\PRP_SkymapIsland_Lava_Terrain_000.m3", 1192, 0, 4142, "Lava Terrain Slab", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_000.m3", 1192, 0, 4143, "Lavafall (Small)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_001.m3", 1192, 0, 4144, "Lavafall (Tall)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Lava\\PRP_Lava_Waterfall_Skullcano_002.m3", 1192, 0, 4145, "Lava Pool (Small)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_002.m3", 1192, 0, 4146, "Lava Blob", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_004.m3", 1192, 0, 4147, "Lava Chunk", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\Terrain\\_Skullcano\\Clutter\\Skullcano_Lava_Chunk_Tall_001.m3", 1192, 0, 4148, "Lava Blob (Tall)", DecorCategory.ParticleEffects, false, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood1n2\\Blood1n2.m3", 1192, 0, 4149, "Blood Magic (Pulsing)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_01.m3", 1192, 0, 4150, "Blood Magic", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Channels\\Siphon\\Siphon.m3", 1192, 0, 4151, "Blood Siphon", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Channels\\Siphon\\Siphon_12.m3", 1192, 0, 4152, "Orange Glow", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Double_Vertical\\Double_Vertical.m3", 1192, 0, 4153, "Blood Explosion", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Gib\\Gib_14.m3", 1192, 0, 4154, "Blood Burst (Messy)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Hit_Default\\Hit_Default_14.m3", 1192, 0, 4155, "Blood Burst", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Pumera_Pounce\\Pumera_Pounce_14.m3", 1192, 0, 4156, "Blood Spray (Intermediate)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Pumera_Pounce\\Pumera_Pounce_14_GRN.m3", 1192, 0, 4157, "Blood Spray (Intermediate, Green)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Slash_Horizontal\\Slash_Horizontal_14.m3", 1192, 0, 4158, "Blood Squirt", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Slash_Spray\\Slash_Spray.m3", 1192, 0, 4159, "Blood Spray (Intermediate, Large)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\Impacts\\Vulcarrion_Divebomb\\Vulcarrion_Divebomb_14.m3", 1192, 0, 4160, "Blood Burst (Small)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Default\\Default_14.m3", 1192, 0, 4161, "Gushing Blood (Messy)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Slash_Wound\\Slash_Wound.m3", 1192, 0, 4162, "Gushing Blood (Downward)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Spray_Vertical\\Spray_Vertical.m3", 1192, 0, 4163, "Blood Spray (Continuous)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Squirt_01\\Squirt_01_14.m3", 1192, 0, 4164, "Blood Squirt (Alternate)", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Water\\Ocean\\Water_Ocean_WaveCircle_000.m3", 1192, 0, 4165, "Water Surface", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Water\\Ocean\\Water_Ocean_WaveShoreline_000.m3", 1192, 0, 4166, "Ocean Waves", DecorCategory.ParticleEffects, true, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Corner_A.m3", 1192, 0, 4167, "Osun Walkway (Corner)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Curve_A.m3", 1192, 0, 4168, "Osun Walkway (Curved, Left)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Curve_B.m3", 1192, 0, 4169, "Osun Walkway (Curved, Right)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Long_A.m3", 1192, 0, 4170, "Osun Walkway (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Ramp_A.m3", 1192, 0, 4171, "Osun Ramp", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Short_A.m3", 1192, 0, 4172, "Osun Walkway (Short)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_SlopeLong_A.m3", 1192, 0, 4173, "Osun Sloped Walk way (Long)", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_SlopeShort_A.m3", 1192, 0, 4174, "Osun Sloped Walk way", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_A_000.m3", 1192, 0, 4175, "Osun Support Arch", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_B.m3", 1192, 0, 4176, "Osun Support Strut", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Osun\\Fort_Kit\\PRP_Osun_FortKit_Walkway_Support_C.m3", 1192, 0, 4177, "Osun Anvil Sculpture", DecorCategory.Structures, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Bones\\Elemental\\PRP_Bones_Elemental_000.m3", 1192, 0, 4178, "Elemental Remnants", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_ShortAxe_000.m3", 1192, 0, 4179, "Draken War Axe (Short)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_LongAxe_000.m3", 1192, 0, 4180, "Draken War Axe (Long)", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\Drakken\\PRP_WeaponRack_Drakken_Spear_000.m3", 1192, 0, 4181, "Serrated Spear", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\WeaponRack\\PRP_WeaponRack_ImperiumFreeStanding_Black_000.m3", 1192, 0, 4182, "Dominion Weapon Rack", DecorCategory.WeaponsArmor, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\PRP_Vending_GranokBeer_000.m3", 1192, 0, 4183, "Vending Machine (Granok Beer)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\AbilityVendor\\PRP_Vending_AbilityVendor_000.m3", 1192, 0, 4184, "BoxerBot", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vending\\Chua\\PRP_Building_ChuaShop_000.m3", 1192, 0, 4185, "Chua Shop", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Speaker\\Generic\\PRP_Speaker_Generic_Grey_000.m3", 1192, 0, 4186, "Speaker (Small)", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Speaker\\Marauder\\PRP_Speaker_MarauderSpeaker_000.m3", 1192, 0, 4187, "Speaker (Marauder)", DecorCategory.Audio, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_007.m3", 1192, 0, 4188, "Draken Horn (Curved, Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_008.m3", 1192, 0, 4189, "Draken Horn (Curved, Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_009.m3", 1192, 0, 4190, "Draken Horn (Painted, Left)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_010.m3", 1192, 0, 4191, "Draken Horn (Painted, Right)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_011.m3", 1192, 0, 4192, "Draken Horn (Painted, Short)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_012.m3", 1192, 0, 4193, "Draken Horn (Curved, Gilded)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Drakken_Horn_013.m3", 1192, 0, 4194, "Draken Horn (Gilded)", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Horn\\Drakken\\PRP_Horn_DrakkenLSupported_000.m3", 1192, 0, 4195, "Draken War Horn", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Book\\BookOfDominus\\PRP_Book_BookofDominus_000.m3", 1192, 0, 4196, "Invoker's Grimoire", DecorCategory.Books, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Fence\\Protostar\\PRP_Fence_ProtostarSpaceGeneric_003.m3", 1192, 0, 4197, "Metal Pole", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\CampFire\\PRP_CampFire_Generic_RedGrey_001.m3", 86, 0, 4198, "Campfire (Large)", DecorCategory.Lighting, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\CampFire\\PRP_CampFire_Generic_RedGrey_002.m3", 86, 0, 4199, "Bonfire", DecorCategory.Lighting, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Ship\\GeneralCargoShip\\PRP_Ship_GeneralCargoShip_000.m3", 1192, 0, 4200, "Piglet Ship", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Ship\\GeneralCargoShip\\PRP_Ship_GeneralCargoShip_001.m3", 1192, 0, 4201, "Piglet Ship (Dark)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Vent\\PRP_Vent_Big_RMC_000.m3", 1192, 0, 4202, "Redmoon Ship Vent", DecorCategory.Accents, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", 1192, 0, 4203, "Ship Tech Panel (Round)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_001.m3", 1192, 0, 4204, "Ship Tech Panel (Flat)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_002.m3", 1192, 0, 4205, "Ship Support Strut", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Engine_005.m3", 1192, 0, 4206, "Fighter Ship Engine", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Light_002.m3", 1192, 0, 4207, "Fighter Ship Light", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Left_002.m3", 1192, 0, 4208, "Fighter Ship Wing (Left)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Right_002.m3", 1192, 0, 4209, "Fighter Ship Wing (Right)", DecorCategory.Spaceship, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Water_GenericPool_000.m3", 1192, 0, 4210, "Hot Springs Pool (Bright)", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Water_Grimvault_Bubbles_000.m3", 1192, 0, 4211, "Glowing Purple Bubble", DecorCategory.Special, true, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\PRP_Waterfall_NPE_000.m3", 1192, 0, 4212, "Waterfall (Triple)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\SunkenShip\\PRP_Water_SunkenShip_000.m3", 1192, 0, 4213, "Pool (Hard-edged)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\TorineDungeon\\PRP_Water_TorineDungeon_000.m3", 1192, 0, 4214, "Pool (Oddly Shaped)", DecorCategory.Special, false, 2);
            AddGenericDecor("Art\\Structure\\Model\\Building_Kits\\Sanctuary_Common\\Galeras_Kit\\Windmill\\PRP_Building_SCGalerasWindmill_001.m3", 1192, 0, 4215, "Windmill Tower (Geleras)", DecorCategory.Structures, true, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\MedicalStation\\PRP_MedicalStation_FloatingMedCross_000.m3", 1192, 0, 4216, "Holographic Medical Sign", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\PellTech\\BrokenPieces\\PRP_PellTech_BrokenPiecesJunk_Aqua_000.m3", 1192, 0, 4217, "Pell-Tech Fragment", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\PellTech\\BrokenAntenna\\PRP_PellTech_BrokenAntenna_000.m3", 1192, 0, 4218, "Broken Antenna (Pell-Tech)", DecorCategory.ToolsHardware, false, 2);
            AddGenericDecor("Art\\Mount\\Hoverboard\\Hoverboard_Default\\HoverBoard_Default.m3", 1192, 0, 4219, "Hoverboard (Flux)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\DominionHoverBike\\Mount_DominionHoverBike.m3", 1192, 0, 4220, "Uniblade", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Flying\\Glider\\Mount_Glider_000.m3", 1192, 0, 4221, "Glider", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Flying\\Puffy_Cat\\PuffyCat.m3", 1192, 0, 4222, "Snarfelynx", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Ball\\Orbitron\\Mount_Ball_Orbitron_000.m3", 1192, 0, 4223, "Orbitron Frame", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Boat\\Mount_Vehicle_Boat.m3", 1192, 0, 4224, "Marauder Starsloop", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_ProtoStarEnforcer\\Mount_Vehicle_ProtoStarEnforcer.m3", 1192, 0, 4225, "Protostar Spiderbot", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Ground\\Vehicle_Skiff\\Mount_Vehicle_Skiff_Marauder.m3", 1192, 0, 4226, "Marauder Skiff", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Chua\\PRP_Mount_Chua_000.m3", 1192, 0, 4227, "Orbitron", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder.m3", 1192, 0, 4228, "Grinder (Exile)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DarkspurSpeeder.m3", 1192, 0, 4229, "Grinder (Darkspur)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Mount\\Speeder\\Mount_DefianceSpeeder\\Mount_DefianceSpeeder_001.m3", 1192, 0, 4230, "Grinder (Exile, Armed)", DecorCategory.Vehicles, false, 2);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Metal_Tech_000.m3", 1192, 0, 4231, "Metal Tech Platform", DecorCategory.BuildingBlocks, false, 2);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_Splatter_Decal\\Blood_Splatter_Decal.m3", 1192, 0, 4232, "Blood Splatter HoloDecal", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Red\\3D\\Blood_Splatter_Decal\\Blood_Splatter_Decal_GRN.m3", 1192, 0, 4233, "Blood Splatter HoloDecal (Green)", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Black\\OT\\Splatter_Decal\\Blood_Splatter_Decal_01.m3", 1192, 0, 4234, "Blood Splatter (Black)", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_01.m3", 1192, 0, 4235, "Blood Splatter", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_02.m3", 1192, 0, 4236, "Blood Stains", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\FX\\Blood\\Red\\OT\\Splatter_Decal\\Blood_Splatter_Decal_02_GRN.m3", 1192, 0, 4237, "Blood Stains (Green)", DecorCategory.Decals, true, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Tools\\Wires\\PRP_Wires_MineWoodBundle_Red_001.m3", 1192, 0, 4238, "Cable (Coiled, Empty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_Caustics.m3", 86, 0, 4239, "Point Light (Caustic, Animated)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Mask_Point_Med_LavaTube.m3", 86, 0, 4240, "Point Light (Lava Tube, Moving)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Hard_Bright_Pulse.m3", 86, 0, 4241, "Point Light (Bright, Slow Pulse)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Med_Flicker.m3", 86, 0, 4242, "Point Light (Bright, Flickering)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Anim\\LIT_Anim_Point_Med_Throb.m3", 86, 0, 4243, "Point Light (Fast Pulse)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Drusera_GlowCone_000.m3", 86, 0, 4244, "Volumetric Light (Column)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Rays_LongNarrow_000.m3", 86, 0, 4245, "Volumetric Light (Sphere)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Atmospherics\\LIT_Atmospherics_Rays_MediumWide_000.m3", 86, 0, 4246, "Volumetric Light (Sphere, Bright)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_20Man.m3", 86, 0, 4247, "Directional Light (Blue, Dappled)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_IcyPeak.m3", 86, 0, 4248, "Point Light (Bright, Dappled, Blue)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_IcyPeakPlatforms.m3", 86, 0, 4249, "Point Light (Bright, Pale Green)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_RMT_Shredder.m3", 86, 0, 4250, "Directional Light (Orange, Stops at Gizmo)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_Anim_Point_AuroriaAdventureFire_000.m3", 86, 0, 4251, "Point Light (Soft, Orange)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_Design_DatacoreElemental_Point_Med_000.m3", 86, 0, 4252, "Point Light (Soft, Pale Blue)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_Point_5m_Blue_000.m3", 86, 0, 4253, "Point Light (Soft, Blue)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_000.m3", 86, 0, 4254, "Spot Light (Ground Target, Highlight)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_001.m3", 86, 0, 4255, "Spot Light (Highlight)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_HeadLight_000.m3", 86, 0, 4256, "Spot Light (Volumetric, Flickering)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Light\\Design\\Light_HalonRing_RotatingAstroid_000.m3", 86, 0, 4257, "Spot Light (Search Light)", DecorCategory.LightSource, true, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Twisted_Climbing_Mossy\\PRP_Tree_Twisted_Climbing_Moss_Gray_001.m3", 1192, 0, 4258, "Verdant Climbing Tree", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Twisted_Climbing_Mossy\\PRP_Tree_Twisted_Climbing_Moss_Gray_002.m3", 1192, 0, 4259, "Verdant Climbing Tree (Clean)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_000.m3", 1192, 0, 4260, "Tree of Life", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentDefense_000.m3", 1192, 0, 4261, "Overgrown Exanite Orb", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentOffense_000.m3", 1192, 0, 4262, "Overgrown Exanite Spikes", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_ContentReward_000.m3", 1192, 0, 4263, "Overgrown Exanite Pillar", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_000.m3", 1192, 0, 4264, "Slimefall (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_001.m3", 1192, 0, 4265, "Slime Blob (Black, Large)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_002.m3", 1192, 0, 4266, "Slimefall (Black, Tall)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_003.m3", 1192, 0, 4267, "Slimefall (Black, Tall Vertical)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_004.m3", 1192, 0, 4268, "Slimefall (Black, Short Vertical)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_005.m3", 1192, 0, 4269, "Hanging Slime (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_006.m3", 1192, 0, 4270, "Hanging Slime (Black, Huge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_007.m3", 1192, 0, 4271, "Hanging Slimefall (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_008.m3", 1192, 0, 4272, "Slime Blob (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_009.m3", 1192, 0, 4273, "Slime Web", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\GeneticArchivesGoo\\PRP_Natural_GeneticArchivesGoo_Floor_000.m3", 1192, 0, 4274, "Slime Pool (Black)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Soulfrost\\PRP_Natural_Slime_SoulfrostFloor_000.m3", 1192, 0, 4275, "Soulfrost Pool", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMedium_GreenDark_000.m3", 1192, 0, 4276, "Skug Slime (Medium, Style 1)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMedium_GreenDark_001.m3", 1192, 0, 4277, "Skug Slime (Medium, Style 2)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_000.m3", 1192, 0, 4278, "Skug Slime (Mini, Style 1)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_001.m3", 1192, 0, 4279, "Skug Slime (Mini, Style 2)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_002.m3", 1192, 0, 4280, "Skug Slime (Mini, Style 3)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickMini_GreenDark_003.m3", 1192, 0, 4281, "Skug Slime (Mini, Style 4)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_000.m3", 1192, 0, 4282, "Skug Slime (Small, Style 1)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_001.m3", 1192, 0, 4283, "Skug Slime (Small, Style 2)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_002.m3", 1192, 0, 4284, "Skug Slime (Small, Style 3)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_003.m3", 1192, 0, 4285, "Skug Slime (Small, Style 4)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_004.m3", 1192, 0, 4286, "Skug Slime (Small, Style 5)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_005.m3", 1192, 0, 4287, "Skug Slime (Small, Style 6)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_006.m3", 1192, 0, 4288, "Skug Slime (Small, Style 7)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_007.m3", 1192, 0, 4289, "Skug Slime (Small, Style 8)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_008.m3", 1192, 0, 4290, "Skug Slime (Small, Style 9)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Skug\\PRP_Slime_SkugThickSmall_GreenDark_009.m3", 1192, 0, 4291, "Skug Slime (Small, Style 10)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_000.m3", 1192, 0, 4292, "Mud Cube", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_001.m3", 1192, 0, 4293, "Mud Cube (Tall)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Mud\\PRP_Slime_Mudcube_002.m3", 1192, 0, 4294, "Mud Cube (Wide)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_000.m3", 1192, 0, 4295, "Slimefall (Honey)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_001.m3", 1192, 0, 4296, "Slimefall (Honey, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_002.m3", 1192, 0, 4297, "Hanging Slime (Honey, Huge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_003.m3", 1192, 0, 4298, "Hanging Slime (Honey, Ledge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_004.m3", 1192, 0, 4299, "Hanging Slimefall (Honey)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_005.m3", 1192, 0, 4300, "Hanging Slime (Honey, Broad)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_006.m3", 1192, 0, 4301, "Hanging Slime (Honey, Large)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_007.m3", 1192, 0, 4302, "Slime Blob (Honey)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_008.m3", 1192, 0, 4303, "Hanging Slime (Honey, Drop)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_009.m3", 1192, 0, 4304, "Hanging Slime (Honey)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_010.m3", 1192, 0, 4305, "Hanging Slime (Honey, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_011.m3", 1192, 0, 4306, "Hanging Slime (Honey, Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_012.m3", 1192, 0, 4307, "Hanging Slime (Honey, Extra Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_013.m3", 1192, 0, 4308, "Hanging Slime (Honey, Thin)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_014.m3", 1192, 0, 4309, "Hanging Slime (Honey, Extra Long Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Honey_015.m3", 1192, 0, 4310, "Slime Blob (Honey, Small)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_000.m3", 1192, 0, 4311, "Slimefall (Tar)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_001.m3", 1192, 0, 4312, "Slimefall (Tar, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_002.m3", 1192, 0, 4313, "Slime Blob (Tar)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_003.m3", 1192, 0, 4314, "Hanging Slime (Tar, Drop)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_004.m3", 1192, 0, 4315, "Slime Blob (Tar, Small)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_005.m3", 1192, 0, 4316, "Hanging Slimefall (Tar)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_006.m3", 1192, 0, 4317, "Hanging Slime (Tar)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_007.m3", 1192, 0, 4318, "Hanging Slime (Tar, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_008.m3", 1192, 0, 4319, "Hanging Slime (Tar, Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_009.m3", 1192, 0, 4320, "Hanging Slime (Tar, Extra Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_010.m3", 1192, 0, 4321, "Hanging Slime (Tar, Thin)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\PRP_Natural_Slime_Tar_011.m3", 1192, 0, 4322, "Hanging Slime (Tar, Extra Long Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\Tar_PPL\\PRP_Natural_Slime_Tar_PPL_004.m3", 1192, 0, 4323, "Slime Blob (Purple, Small)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_000.m3", 1192, 0, 4324, "Slimefall (Tech)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_001.m3", 1192, 0, 4325, "Slimefall (Tech, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_002.m3", 1192, 0, 4326, "Hanging Slime (Tech, Huge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_004.m3", 1192, 0, 4327, "Hanging Slimefall (Tech)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_005.m3", 1192, 0, 4328, "Hanging Slime (Tech, Wide)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_006.m3", 1192, 0, 4329, "Hanging Slime (Tech, Large)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_007.m3", 1192, 0, 4330, "Slime Blob (Tech)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_008.m3", 1192, 0, 4331, "Hanging Slime (Tech, Drop)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_009.m3", 1192, 0, 4332, "Hanging Slime (Tech)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_011.m3", 1192, 0, 4333, "Hanging Slime (Tech, Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_012.m3", 1192, 0, 4334, "Hanging Slime (Tech, Extra Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_013.m3", 1192, 0, 4335, "Hanging Slime (Tech, Thin)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\Honey\\TechHoney\\PRP_Natural_Slime_Honey_Tech_014.m3", 1192, 0, 4336, "Hanging Slime (Tech, Extra Long Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_000.m3", 1192, 0, 4337, "Slimefall (Metal, Thick)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_001.m3", 1192, 0, 4338, "Slimefall (Metal, Tall)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_LiquidMetal_Waterfall_002.m3", 1192, 0, 4339, "Slimefall Pool (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_000.m3", 1192, 0, 4340, "Slimefall (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_001.m3", 1192, 0, 4341, "Slimefall (Metal, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_002.m3", 1192, 0, 4342, "Hanging Slime (Metal, Huge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_003.m3", 1192, 0, 4343, "Hanging Slime (Metal, Ledge)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_004.m3", 1192, 0, 4344, "Hanging Slimefall (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_005.m3", 1192, 0, 4345, "Hanging Slime (Metal, Wide)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_006.m3", 1192, 0, 4346, "Hanging Slime (Metal, Large)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_007.m3", 1192, 0, 4347, "Slime Blob (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_008.m3", 1192, 0, 4348, "Hanging Slime (Metal, Drop)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_009.m3", 1192, 0, 4349, "Hanging Slime (Metal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_010.m3", 1192, 0, 4350, "Hanging Slime (Metal, Split)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\LiquidMetal\\PRP_Natural_LiquidMetal_011.m3", 1192, 0, 4351, "Hanging Slime (Metal, Long)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_000.m3", 1192, 0, 4352, "Slimefall (Toxic, Thick)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_001.m3", 1192, 0, 4353, "Slimefall (Toxic, Horizontal)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Slime\\ToxicGoo\\PRP_Natural_Slime_ToxicGoo_Eldan_002.m3", 1192, 0, 4354, "Slimefall Pool (Toxic)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_Foam_000.m3", 1192, 0, 4355, "Foamy Waterfall", DecorCategory.ParticleEffects, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyerBot_All.m3", 1192, 0, 4356, "Annihilator Robot", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Structure\\Design_Layout\\Eastern\\Algeroc\\STR_Building_SCMedArmorShop_Tan_Background_AP_000.m3", 1192, 0, 4357, "Cozy Exile House (Armored)", DecorCategory.Structures, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Islands\\PRP_SkymapIsland_Water_Terrain_000.m3", 1192, 0, 4358, "Snowy Platform", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_Battlebot_Head_000.m3", 1192, 0, 4359, "Battlebot Head", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotCore_000.m3", 1192, 0, 4360, "Megadroid Core", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotFoot_Grey_000.m3", 1192, 0, 4361, "Megadroid Foot (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHangingWire_000.m3", 1192, 0, 4362, "MegaDroid Wire (Hanging)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHead_000.m3", 1192, 0, 4363, "Megadroid Head (Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHead_Grey_000.m3", 1192, 0, 4364, "Megadroid Head (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotHips_Grey_000.m3", 1192, 0, 4365, "Megadroid Hips (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftArm_000.m3", 1192, 0, 4366, "Megadroid Arm (Left, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftArm_Grey_000.m3", 1192, 0, 4367, "Megadroid Arm (Left, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLeg_Grey_000.m3", 1192, 0, 4368, "Megadroid Leg (Left, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerArm_000.m3", 1192, 0, 4369, "Megadroid Arm (Left, Lower, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerArm_Grey_000.m3", 1192, 0, 4370, "Megadroid Arm (Left, Lower, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftLowerLeg_Grey_000.m3", 1192, 0, 4371, "Megadroid Leg (Left, Lower, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperArm_000.m3", 1192, 0, 4372, "Megadroid Arm (Left, Upper, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperArm_Grey_000.m3", 1192, 0, 4373, "Megadroid Arm (Left, Upper, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotLeftUpperLeg_Grey_000.m3", 1192, 0, 4374, "Megadroid Leg (Left, Upper, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightArm_000.m3", 1192, 0, 4375, "Megadroid Arm (Right, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightArm_Grey_000.m3", 1192, 0, 4376, "Megadroid Arm (Right, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLeg_Grey_000.m3", 1192, 0, 4377, "Megadroid Leg (Right, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerArm_000.m3", 1192, 0, 4378, "Megadroid Arm (Right, Lower, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerArm_Grey_000.m3", 1192, 0, 4379, "Megadroid Arm (Right, Lower, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightLowerLeg_Grey_000.m3", 1192, 0, 4380, "Megadroid Leg (Right, Lower, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperArm_000.m3", 1192, 0, 4381, "Megadroid Arm (Right, Upper, Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperArm_Grey_000.m3", 1192, 0, 4382, "Megadroid Arm (Right, Upper, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotRightUpperLeg_Grey_000.m3", 1192, 0, 4383, "Megadroid Leg (Right, Upper, Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotShoulder_Grey_000.m3", 1192, 0, 4384, "Megadroid Shoulder (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotTorso_000.m3", 1192, 0, 4385, "Megadroid Torso (Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotTorso_Grey_000.m3", 1192, 0, 4386, "Megadroid Torso (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_000.m3", 1192, 0, 4387, "Megadroid (Rusty)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_Grey_000.m3", 1192, 0, 4388, "Megadroid (Grey)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWhole_Grey_001.m3", 1192, 0, 4389, "Megadroid (Grey, Active)", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\PRP_Ruin_RobotWire_000.m3", 1192, 0, 4390, "MegaDroid Wire", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Arm_000.m3", 1192, 0, 4391, "Warbot Arm", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Head_000.m3", 1192, 0, 4392, "Warbot Head", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Leg_000.m3", 1192, 0, 4393, "Warbot Leg", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Pauldron_000.m3", 1192, 0, 4394, "Warbot Pauldron", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\Ruined\\Warbot\\PRP_Robots_Ruined_Warbot_Torso_000.m3", 1192, 0, 4395, "Warbot Torso", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_Assorted_Metal_000.m3", 1192, 0, 4396, "Door Exile (Metal, Vault)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_Assorted_Stone_000.m3", 1192, 0, 4397, "Door Exile (Wood, Vintage)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_Assorted_wood_000.m3", 1192, 0, 4398, "Door Exile (Wood, Blue)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_SancCommon_001.m3", 1192, 0, 4399, "Exile Door (Metal, Green)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\PRP_Door_SancCommon_002.m3", 1192, 0, 4400, "Exile Door (Reinforced, Green)", DecorCategory.Doors, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Animated_AsteroidField_000.m3", 1192, 0, 4401, "Floating Rocks", DecorCategory.Rocks, true, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_000.m3", 1192, 0, 4402, "Asteroid Field (Large)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_001.m3", 1192, 0, 4403, "Asteroid Field (Double)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_002.m3", 1192, 0, 4404, "Asteroid Field (Scattered)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Quest_Farside_AsteroidField_003.m3", 1192, 0, 4405, "Asteroid Field (Small)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_000.m3", 1192, 0, 4406, "Rock Pillar (Massive, Leaning)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_001.m3", 1192, 0, 4407, "Rock Pillar (Straight)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_002.m3", 1192, 0, 4408, "Rock Pillar (Jagged)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_003.m3", 1192, 0, 4409, "Rock Pillar (Pointy)", DecorCategory.Rocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\CrumblingGround\\PRP_Rock_CrumblingGround_000.m3", 1192, 0, 4410, "Circular Stone Floor", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\CrumblingGround\\PRP_Rock_CrumblingGround_Eldan_000.m3", 1192, 0, 4411, "Circular Stone Floor (Eldan)", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Drusera\\PRP_Crystal_Drusera_000.m3", 1192, 0, 4412, "Genesis Prime", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlBag_Blue_000.m3", 1192, 0, 4413, "Bag of Pearls (Blue)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlBag_Pink_000.m3", 1192, 0, 4414, "Bag of Pearls (Pink)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_Blue_000.m3", 1192, 0, 4415, "Pearl Pile (Blue)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_Pink_000.m3", 1192, 0, 4416, "Pearl Pile (Pink)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_PearlPile_White_000.m3", 1192, 0, 4417, "Pearl Pile (White)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Blue_000.m3", 1192, 0, 4418, "Pearl (Blue)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Blue_FX_000.m3", 1192, 0, 4419, "Pearl (Blue, Glowing)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Green_FX_000.m3", 1192, 0, 4420, "Glowing Orb (Green)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_Pink_000.m3", 1192, 0, 4421, "Pearl (Pink)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\Pearls\\PRP_Crystals_Pearl_White_000.m3", 1192, 0, 4422, "Pearl (White)", DecorCategory.Toys, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Blue_000.m3", 1192, 0, 4423, "Mangrove_Blue", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Burnt_000.m3", 1192, 0, 4424, "Mangrove Tree (Burnt)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_000.m3", 1192, 0, 4425, "Mangrove Tree (Green)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_001.m3", 1192, 0, 4426, "Mangrove Tree (Green, Chubby)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_002.m3", 1192, 0, 4427, "Mangrove Tree (Green, Lanky)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Green_003.m3", 1192, 0, 4428, "Mangrove Tree (Green, Closed)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\PRP_Tree_Deciduous_RootyMangrove_Violet_000.m3", 1192, 0, 4429, "Mangrove Tree (Violet)", DecorCategory.Trees, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_Seed_000.m3", 1192, 0, 4430, "Eldan Tech Seed", DecorCategory.Plants, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Vent_000.m3", 1192, 0, 4431, "Redmoon Ventilation System", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Wind_Woosh_000.m3", 1192, 0, 4432, "Woosh", DecorCategory.ParticleEffects, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Wind_Woosh_001.m3", 1192, 0, 4433, "Woosh (Vortex)", DecorCategory.ParticleEffects, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_PoopPile_000.m3", 1192, 0, 4434, "Towering Bathroom Incident", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_PoopPile_Bubble_000.m3", 1192, 0, 4435, "Dung Bubble", DecorCategory.ParticleEffects, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\ShellarkTank\\PRP_RMT_Act2_ShellarkTank_000.m3", 1192, 0, 4436, "Redmoon Fish Tank", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\ShellarkTank\\PRP_RMT_Act2_ShellarkTank_Shellarks_000.m3", 1192, 0, 4437, "Shellarks", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Grill_000.m3", 1192, 0, 4438, "Grill", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Light_000.m3", 1192, 0, 4439, "Pirate Light", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Pipe_000.m3", 1192, 0, 4440, "Pirate Pipe", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Wok\\PRP_RMT_Act2_Pirate_Wok_000.m3", 1192, 0, 4441, "Wok", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\SteamVent\\PRP_RMT_SteamVent_000.m3", 1192, 0, 4442, "Redmoon Steam Vent", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Tesla_Device\\PRP_TeslaDevice_000.m3", 1192, 0, 4443, "Redmoon Tesla Device", DecorCategory.Electronics, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Bar\\PRP_RMT_Act2_Bar_001.m3", 1192, 0, 4444, "Redmoon Bar (Straight, Long)", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act2\\Bar\\PRP_RMT_Act2_Bar_002.m3", 1192, 0, 4445, "Redmoon Bar (Straight)", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\GlowingSkull\\PRP_RMT_GlowingSkull_000.m3", 1192, 0, 4446, "Skull (Glowing)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Comet\\PRP_RMT_Comet_000.m3", 1192, 0, 4447, "Comet", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Fan\\PRP_RMT_Fan_000.m3", 1192, 0, 4448, "Redmoon Fan", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_000.m3", 1192, 0, 4449, "Ship Hologram (Hopper)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_001.m3", 1192, 0, 4450, "Ship Hologram (Arkship)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_002.m3", 1192, 0, 4451, "Ship Hologram (Piglet)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\HologramShips\\PRP_RMT_HologramShips_003.m3", 1192, 0, 4452, "Ship Hologram (Crabber)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MedbayLight\\PRP_RMT_MedbayLight_000.m3", 86, 0, 4453, "Medical Light", DecorCategory.Lighting, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MogMog\\PRP_RMT_MogMog_000.m3", 1192, 0, 4454, "Mask of Mog Mog", DecorCategory.StatuesSculptures, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_000.m3", 1192, 0, 4455, "Morgue Drawer (Ornate)", DecorCategory.Containers, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_001.m3", 1192, 0, 4456, "Morgue Drawer (Ornate, Crooked)", DecorCategory.Containers, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_002.m3", 1192, 0, 4457, "Morgue Drawer (Ornate, Bent)", DecorCategory.Containers, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\MorgueDrawer\\PRP_RMT_MorgueDrawer_003.m3", 1192, 0, 4458, "Morgue Drawer (Simple)", DecorCategory.Containers, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_000.m3", 1192, 0, 4459, "Operating Storage Table", DecorCategory.Tables, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_001.m3", 1192, 0, 4460, "Operating Table", DecorCategory.Tables, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\OpertatingTable\\PRP_RMT_ACT3_OperatingTable_002.m3", 1192, 0, 4461, "Operating Table (Drainage Pipe)", DecorCategory.Tables, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\PASystem\\PRP_RMT_PASystem_000.m3", 1192, 0, 4462, "Redmoon Speaker System", DecorCategory.Audio, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Blue_000.m3", 1192, 0, 4463, "Planet: Cassus", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Cracked_000.m3", 1192, 0, 4464, "Planet: Aldinari", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Planet\\PRP_RMT_Planet_Tan_000.m3", 1192, 0, 4465, "Planet: Vulpes Nix", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Planet\\PRP_Planet_All_000.m3", 1192, 0, 4466, "Planet: Nexus (Rings, Farside, Pyra)", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Planet\\PRP_Planet_Farside_000.m3", 1192, 0, 4467, "Farside", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Planet\\PRP_Planet_Nebula.m3", 1192, 0, 4468, "Nebula", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Planet\\PRP_Planet_Nexus_000.m3", 1192, 0, 4469, "Planet: Nexus", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\PlantStand\\PRP_RMT_PlantStand_000.m3", 1192, 0, 4470, "Redmoon Plant Stand", DecorCategory.Plants, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Sun\\PRP_RMT_Sun_000.m3", 1192, 0, 4471, "Sun (Alpha Cassus)", DecorCategory.Special, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\Vine\\PRP_RMT_Vine_SmallThinLoose_001.m3", 1192, 0, 4472, "Hanging Vine (Small, Drooping)", DecorCategory.Plants, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Airlock_Wind_000.m3", 1192, 0, 4473, "Airlock Wind", DecorCategory.ParticleEffects, true, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Choppa_Blade_000.m3", 1192, 0, 4474, "Redmoon Fan Blades", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Choppa_TrashChuteRing_000.m3", 1192, 0, 4475, "Redmoon Fan Ring", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Decal_MarauderHead_Painted_000.m3", 1192, 0, 4476, "Metal Sigil (Redmoon, Painted)", DecorCategory.Accents, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Deck_Turret_000.m3", 1192, 0, 4477, "Redmoon Deck Turret", DecorCategory.WeaponsArmor, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Elevator_Platform_000.m3", 1192, 0, 4478, "Redmoon Elevator Platform", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_BossPlatform_Center_000.m3", 1192, 0, 4479, "Redmoon Metal Platform", DecorCategory.BuildingBlocks, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_Piston_000.m3", 1192, 0, 4480, "Engine Piston", DecorCategory.ToolsHardware, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Furnace_000.m3", 1192, 0, 4481, "Redmoon Furnace", DecorCategory.Structures, false, 3);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Grill_000.m3", 1192, 0, 4482, "Redmoon Grill", DecorCategory.CookwareBarware, false, 3);
            AddGenericDecor("Art\\Prop\\Natural\\Fog\\PRP_Fog_GroundCover_000.m3", 1192, 0, 4483, "Creeping Fog", DecorCategory.ParticleEffects, true, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Large_umberla_Pine\\PRP_Tree_LargeUmberla_LargePine_001.m3", 1192, 0, 4484, "Umbrella Pine (Violet)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Large_umberla_Pine\\PRP_Tree_LargeUmberla_MidPine_000.m3", 1192, 0, 4485, "Umbrella Pine (Lanky)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_000.m3", 1192, 0, 4486, "Life-Infused Tree", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_001.m3", 1192, 0, 4487, "Life-Infused Tree (Bushy)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\LifeInfused\\PRP_Tree_SkinnyTall_Yellow_Deciduous_LifeInfused_002.m3", 1192, 0, 4488, "Life-Infused Tree (Pointy)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_000.m3", 1192, 0, 4489, "Mangrove Tree (Yellow)", DecorCategory.Trees, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_000.m3", 1192, 0, 4490, "Green Swirly Rock (Flat)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_001.m3", 1192, 0, 4491, "Green Swirly Rock (Pointy)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_002.m3", 1192, 0, 4492, "Green Swirly Rock (Cross)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Large_003.m3", 1192, 0, 4493, "Green Swirly Rock (Teardrop)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_000.m3", 1192, 0, 4494, "Green Swirly Rock (Egg-Shaped)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_001.m3", 1192, 0, 4495, "Green Swirly Rock (Curved)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_002.m3", 1192, 0, 4496, "Green Swirly Rock (Concave)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Mid_003.m3", 1192, 0, 4497, "Green Swirly Rock (Ovoid)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_000.m3", 1192, 0, 4498, "Green Swirly Rock (Blob-Shaped)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_001.m3", 1192, 0, 4499, "Green Swirly Rock (Double)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_002.m3", 1192, 0, 4500, "Green Swirly Rock", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RoundSwirlCracks\\PRP_Rock_SwirlCracks_Small_003.m3", 1192, 0, 4501, "Green Swirly Rock (Struck)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Primal\\PRP_Rock_Primal_EarthCrystal_000.m3", 1192, 0, 4502, "Primal Earth Crystal", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_000.m3", 1192, 0, 4503, "Creepy Rock (Jagged, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_001.m3", 1192, 0, 4504, "Creepy Rock (Looming, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_002.m3", 1192, 0, 4505, "Creepy Rock (Balanced, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_003.m3", 1192, 0, 4506, "Creepy Rock (Claw-Shaped, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_004.m3", 1192, 0, 4507, "Creepy Rock (Pointy, Vines)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_000.m3", 1192, 0, 4508, "Creepy Rock (Jagged, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_001.m3", 1192, 0, 4509, "Creepy Rock (Looming, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_002.m3", 1192, 0, 4510, "Creepy Rock (Balanced, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_003.m3", 1192, 0, 4511, "Creepy Rock (Claw-Shaped, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Creepy_Wire_004.m3", 1192, 0, 4512, "Creepy Rock (Pointy, Wires)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_000.m3", 1192, 0, 4513, "Tall Rock (Style 1)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_001.m3", 1192, 0, 4514, "Tall Rock (Style 2)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_002.m3", 1192, 0, 4515, "Tall Rock (Style 3)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_003.m3", 1192, 0, 4516, "Tall Rock (Style 4)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Dreadmoor\\PRP_Rocks_Dreadmoor_Stonehenge_004.m3", 1192, 0, 4517, "Tall Rock (Style 5)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Whitevale_Crater\\PRP_Rock_Whitevale_Crater_000.m3", 1192, 0, 4518, "Floating Crater", DecorCategory.Special, false, 4);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_Turbulence_000.m3", 1192, 0, 4519, "Turbulence", DecorCategory.ParticleEffects, true, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_A.m3", 1192, 0, 4520, "Aurin Roof (Large, Purple)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_B.m3", 1192, 0, 4521, "Aurin Roof (Large, Blue)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_C.m3", 1192, 0, 4522, "Aurin Roof (Large, Pink)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Medium_D.m3", 1192, 0, 4523, "Aurin Roof (Large, Red)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_A.m3", 1192, 0, 4524, "Aurin Roof (Small, Pink)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_B.m3", 1192, 0, 4525, "Aurin Roof (Small, Blue)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Aurin\\PRP_Roof_Aurin_Small_C.m3", 1192, 0, 4526, "Aurin Roof (Small, Violet)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianMedium_A.m3", 1192, 0, 4527, "Cassian Roof (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianMedium_B.m3", 1192, 0, 4528, "Cassian Roof (Large, Curvy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianSmall_A.m3", 1192, 0, 4529, "Cassian Roof (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Cassian\\PRP_Roof_CassianSmall_B.m3", 1192, 0, 4530, "Cassian Roof (Small, Shingled)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_A.m3", 1192, 0, 4531, "Chua Roof Cap (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_B.m3", 1192, 0, 4532, "Chua Roof Cap (Large, Elaborate)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_ChuaMedium_C.m3", 1192, 0, 4533, "Chua Roof Cap (Large, Industrial)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_A.m3", 1192, 0, 4534, "Chua Roof Cap (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_B.m3", 1192, 0, 4535, "Chua Roof Cap (Small, Smoking)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Chua\\PRP_Roof_Chuasmall_C.m3", 1192, 0, 4536, "Chua Roof Cap (Small, Industrial)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Medium_A.m3", 1192, 0, 4537, "Draken Roof (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Medium_B.m3", 1192, 0, 4538, "Draken Roof (Large, Imposing)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Small_A.m3", 1192, 0, 4539, "Draken Roof (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Draken\\PRP_Roof_Draken_Small_B.m3", 1192, 0, 4540, "Draken Roof (Small, Imposing)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileMedium_A.m3", 1192, 0, 4541, "Exile Roof (Large, Veranda)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileMedium_B.m3", 1192, 0, 4542, "Exile Roof (Large, Pergola)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileSmall_A.m3", 1192, 0, 4543, "Exile Roof (Small, Rounded)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Exile\\PRP_Roof_ExileSmall_B.m3", 1192, 0, 4544, "Exile Roof (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_A.m3", 1192, 0, 4545, "Bird House (Hoogle)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_B.m3", 1192, 0, 4546, "Bird House (Leafy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Generic\\PRP_Roof_Bird_C.m3", 1192, 0, 4547, "Bird House (Bearded Hoogle)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokMedium_A.m3", 1192, 0, 4548, "Granok Roof (Double, Pipes)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokMedium_B.m3", 1192, 0, 4549, "Granok Roof (Double, Shingles)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_A.m3", 1192, 0, 4550, "Granok Roof (Small, Boulder)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_B.m3", 1192, 0, 4551, "Granok Roof (Small, Slanted)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Granok\\PRP_Roof_GranokSmall_C.m3", 1192, 0, 4552, "Granok Roof (Small, Shingled)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_A.m3", 1192, 0, 4553, "Osun Pinnacle (Statues)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_B.m3", 1192, 0, 4554, "Osun Pinnacle (Pointy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Roof\\Osun\\PRP_Roof_Osun_C.m3", 1192, 0, 4555, "Osun Pinnacle (Sword)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_A.m3", 1192, 0, 4556, "Wooden Ramp (Natural, Wide)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_B.m3", 1192, 0, 4557, "Aurin Stairs (Short)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_C.m3", 1192, 0, 4558, "Aurin Ramp", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_D.m3", 1192, 0, 4559, "Aurin Stairs (Short, Ornate)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_A.m3", 1192, 0, 4560, "Wooden Ramp (Natural, Long)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_B.m3", 1192, 0, 4561, "Aurin Stairs (Long)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_C.m3", 1192, 0, 4562, "Aurin Ramp (Wide)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Aurin\\PRP_Entry_Aurin_Medium_D.m3", 1192, 0, 4563, "Aurin Stairs (Long, Ornate)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_A.m3", 1192, 0, 4564, "Cassian Stone Stairs (Pointy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_C.m3", 1192, 0, 4565, "Cassian Entry (Large, Humble)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_ClosedBack_B.m3", 1192, 0, 4566, "Cassian Entry (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_A.m3", 1192, 0, 4567, "Cassian Stone Stairs (Round)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_C.m3", 1192, 0, 4568, "Cassian Entry (Cozy, Humble)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianSmall_ClosedBack_B.m3", 1192, 0, 4569, "Cassian Entry (Cozy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_A.m3", 1192, 0, 4570, "Metal Stairs (Chua)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_B.m3", 1192, 0, 4571, "Metal Stairs (Chua, Tanks)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Chua\\PRP_Entry_ChuaMedium_C.m3", 1192, 0, 4572, "Metal Stairs (Chua, Industrial)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_A.m3", 1192, 0, 4573, "Draken Entry (Large)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_B.m3", 1192, 0, 4574, "Draken Entry (Large, Chains)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Medium_C.m3", 1192, 0, 4575, "Draken Entry (Large, Mouth)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_A.m3", 1192, 0, 4576, "Draken Entry (Small)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_B.m3", 1192, 0, 4577, "Draken Entry (Small, Chains)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Draken\\PRP_Entry_Draken_Small_c.m3", 1192, 0, 4578, "Draken Entry (Small, Mouth)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_A.m3", 1192, 0, 4579, "Exile Entry Stairs (Small, Simple)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_B.m3", 1192, 0, 4580, "Exile Entry Stairs (Small, Sheltered)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_ExileSmall_C.m3", 1192, 0, 4581, "Exile Entry Stairs (Small, Wooden)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_A.m3", 1192, 0, 4582, "Exile Entry Stairs (Large, Pillars)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_B.m3", 1192, 0, 4583, "Exile Entry Stairs (Large, Simple)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Exile\\PRP_Entry_Exile_C.m3", 1192, 0, 4584, "Exile Entry Stairs (Large, Wooden)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_A.m3", 1192, 0, 4585, "Bird House Platform", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_B.m3", 1192, 0, 4586, "Bird House Platform (Fancy)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Generic\\PRP_Entry_Bird_C.m3", 1192, 0, 4587, "Bird House Platform (Gnarly)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_B_Clean.m3", 1192, 0, 4588, "Granok Entry (Large, Stone Archway)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_C_clean.m3", 1192, 0, 4589, "Granok Entry (Large, Stone Steps)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Space\\PRP_Entry_Space_Small_A.m3", 1192, 0, 4590, "Twisting Bridge", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Aurin\\PRP_Door_Aurin_A.m3", 1192, 0, 4591, "Aurin Door (Glowing)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Aurin\\PRP_Door_Aurin_C.m3", 1192, 0, 4592, "Aurin Door (Red)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Cassian\\PRP_Door_CassianMedium_A.m3", 1192, 0, 4593, "Cassian Door (Reinforced)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Cassian\\PRP_Door_CassianSmall_c.m3", 1192, 0, 4594, "Cassian Door (Luminai)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Chua\\PRP_Door_Chua_A.m3", 1192, 0, 4595, "Chua Door", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Chua\\PRP_Door_Chua_B.m3", 1192, 0, 4596, "Chua Door (Window)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Chua\\PRP_Door_Chua_C.m3", 1192, 0, 4597, "Chua Door (Spiral)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Draken\\PRP_Door_Draken_Medium_A.m3", 1192, 0, 4598, "Curtains (Draken)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Draken\\PRP_Door_Draken_Small_A.m3", 1192, 0, 4599, "Draken Door (Glowing)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Draken\\PRP_Door_Draken_Small_B.m3", 1192, 0, 4600, "Draken Door (Double)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Draken\\PRP_Door_Draken_Small_C.m3", 1192, 0, 4601, "Mouth Door", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_Bird_A.m3", 1192, 0, 4602, "Bird House Door (Overgrown)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_Bird_B.m3", 1192, 0, 4603, "Bird House Door (Wooden)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_Bird_C.m3", 1192, 0, 4604, "Bird House Door (Stone)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_BlackHole_A.m3", 1192, 0, 4605, "Black Hole", DecorCategory.Special, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Generic\\PRP_Door_Hatch_A.m3", 1192, 0, 4606, "Bunker Hatch", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Granok\\PRP_Door_Granok_A.m3", 1192, 0, 4607, "Granok Door", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Granok\\PRP_Door_Granok_B.m3", 1192, 0, 4608, "Granok Door (Round)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Osun\\PRP_Door_Osun_A.m3", 1192, 0, 4609, "Osun Door (Reinforced)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Osun\\PRP_Door_Osun_B.m3", 1192, 0, 4610, "Osun Door (Ornate)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Door\\Osun\\PRP_Door_Osun_C.m3", 1192, 0, 4611, "Osun Door (Face)", DecorCategory.BuildingBlocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_005.m3", 1192, 0, 4612, "Rock Pillar (Tapered)", DecorCategory.Rocks, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_000.m3", 1192, 0, 4613, "Crystal Formation (Green, Snowy)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_001.m3", 1192, 0, 4614, "Crystal Formation (Green,Floating)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_002.m3", 1192, 0, 4615, "Crystal Formation (Green)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_003.m3", 1192, 0, 4616, "Crystal Chunk (Green)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Green_004.m3", 1192, 0, 4617, "Floating Crystal Fragments", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Orange_002.m3", 1192, 0, 4618, "Crystal Cluster (Blue)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\RottersBelt\\PRP_Rock_RottersBeltCrystal_Orange_003.m3", 1192, 0, 4619, "Crystal Chunk (Blue)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_RED_000.m3", 1192, 0, 4620, "Floating Crystals (Red)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_001.m3", 1192, 0, 4621, "Blue Crystal (Blunt)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_002.m3", 1192, 0, 4622, "Blue Crystal (Pointy)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_crystal_RED_001.m3", 1192, 0, 4623, "Orange Crystal (Blunt)", DecorCategory.Accents, false, 4);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeraduneCanopy\\PRP_Roots_DeraduneCanopy_Leaf_000.m3", 1192, 0, 4624, "Big Leaf", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Canopy_Dead_RootyMangrove_Brown_000.m3", 1192, 0, 4625, "Mangrove Canopy (Yellow)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangroveFallen_Brown_001.m3", 1192, 0, 4626, "Mangrove Tree (Yellow, Fallen)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_001.m3", 1192, 0, 4627, "Mangrove Tree (Brown, Lanky)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_002.m3", 1192, 0, 4628, "Mangrove Tree (Brown)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Dead_RootyMangrove\\PRP_Tree_Dead_RootyMangrove_Brown_003.m3", 1192, 0, 4629, "Mangrove Tree (Brown, Closed)", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_000.m3", 1192, 0, 4630, "Obsidian Rock Stack", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_001.m3", 1192, 0, 4631, "Obsidian Rock Pillar", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_004.m3", 1192, 0, 4632, "Obsidian Rock Block", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_005.m3", 1192, 0, 4633, "Obsidian Rock Wall", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_007.m3", 1192, 0, 4634, "Obsidian Rock Pedestal", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_008.m3", 1192, 0, 4635, "Obsidian Rock Slope", DecorCategory.Rocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyerBot_Head.m3", 1192, 0, 4636, "Annihilator Head", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_JetPack.m3", 1192, 0, 4637, "Annihilator Jetpack", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Left_Arm.m3", 1192, 0, 4638, "Annihilator Arm (Left)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Left_Leg.m3", 1192, 0, 4639, "Annihilator Leg (Left))", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Right_Arm.m3", 1192, 0, 4640, "Annihilator Arm (Right)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Right_Leg.m3", 1192, 0, 4641, "Annihilator Leg (Right)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Torso_001.m3", 1192, 0, 4642, "Annihilator Torso (with Jetpack)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Waist.m3", 1192, 0, 4643, "Annihilator Waist", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\WorldDestroyer_CrimsonIsle_Destroyed.m3", 1192, 0, 4644, "Annihilator (Destroyed)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_B_Clean.m3", 1192, 0, 4645, "Granok Entry (Cozy, Awning Steps)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_Granok_A_Clean.m3", 1192, 0, 4646, "Granok Entry (Large, Rustic Threshold)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_000.m3", 1192, 0, 4647, "Elderoot Tree", DecorCategory.Trees, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeraduneCanopy\\PRP_Roots_DeraduneCanopy_BlueBall_000.m3", 1192, 0, 4648, "Aerophyl Bulb (Style 1)", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\Arch_Fat_Round\\PRP_Roots_ArchfatRound_Augmented_000.m3", 1192, 0, 4649, "Arching Root (Augmented)", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\Arch_Fat_Round\\PRP_Roots_ArchfatRound_GreenMossy_000.m3", 1192, 0, 4650, "Arching Root", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\Arch_Fat_Round\\PRP_Roots_ArchfatRound_Stairs_GreenMossy_000.m3", 1192, 0, 4651, "Aurin Mound Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Generic\\PRP_Platform_Generic_Pallet_Metal_000.m3", 1192, 0, 4652, "Metall Pallet", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Generic\\PRP_Platform_Generic_Pallet_Metal_001.m3", 1192, 0, 4653, "Metall Pallet (Plain)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platform_Eldan_Datascape_Airboss_000.m3", 1192, 0, 4654, "Massive Floating Platform (Eldan)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platform_Eldan_RobotSilo_000.m3", 1192, 0, 4655, "Platform (Eldan)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platform_Eldan_RobotSilo_Technophage_000.m3", 1192, 0, 4656, "Platform_RobotSilo_Phage", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platform_Eldan_RuinedEdge_000.m3", 1192, 0, 4657, "Ruined Eldan Tech Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Eldan\\PRP_Platforms_Eldan_Archon_Computer_000.m3", 1192, 0, 4658, "Eldan Supercomputer", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Granok\\PRP_Platfrom_LandingPad_Granok_000.m3", 1192, 0, 4659, "Landing Pad (Granok)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Osun\\PRP_Platform_Osun_BasePlatform_Round_001.m3", 1192, 0, 4660, "Osun Platform (Small)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Osun\\PRP_Platform_Osun_PlatformLarge_000.m3", 1192, 0, 4661, "Osun Tech Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Osun\\PRP_Platform_Osun_Platform_Wolfhead_Stairs_001.m3", 1192, 0, 4662, "Osun Wolfhead Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_CryoChamberRevivalPlatformArm_000.m3", 1192, 0, 4663, "Cryochamber Arm (Grasping)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_CryoChamberRevivalPlatformArm_Custom_000.m3", 1192, 0, 4664, "Cryochamber Arm (Magnetic)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Lantern\\Lopp\\PRP_Lantern_StringPostVarious_PostOnly_000.m3", 1192, 0, 4665, "Long Wooden Stick", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Lantern\\Drakken\\PRP_Lantern_Drakken_000.m3", 86, 0, 4666, "Brazier (Draken)", DecorCategory.Lighting, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Cup\\Chua\\PRP_Chua_Cup_002.m3", 1192, 0, 4667, "Chua Cup (Lid)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachBalls\\PRP_PartyGraw_BeachBall_000.m3", 1192, 0, 4668, "Beach Ball (Pentacolor)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachBalls\\PRP_PartyGraw_BeachBall_001.m3", 1192, 0, 4669, "Beach Ball (Hexacolor)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachBalls\\PRP_PartyGraw_BeachBall_002.m3", 1192, 0, 4670, "Beach Ball (Quadcolor)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachBalls\\PRP_PartyGraw_BeachBall_003.m3", 1192, 0, 4671, "Beach Ball (Pink)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachChairs\\PRP_PartyGraw_BeachChair_001.m3", 1192, 0, 4672, "Beach Chair", DecorCategory.Seating, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachUmbrella\\PRP_PartyGraw_BeachUmbrella_000.m3", 1192, 0, 4673, "Beach Parasol (Decorated)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachUmbrella\\PRP_PartyGraw_BeachUmbrella_001.m3", 1192, 0, 4674, "Beach Parasol", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BeachUmbrella\\PRP_PartyGraw_BeachUmbrella_002.m3", 1192, 0, 4675, "Beach Parasol (Closed)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Beer\\PRP_PartyGraw_Beer_000.m3", 1192, 0, 4676, "Beer Bottle (Protostar)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Beer\\PRP_PartyGraw_Beer_001.m3", 1192, 0, 4677, "Beer Can (Vind)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BirdPerches\\PRP_PartyGraw_BirdPerch_000.m3", 1192, 0, 4678, "Tribal Bird Perch", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BirdPerches\\PRP_PartyGraw_BirdPerch_001.m3", 1192, 0, 4679, "Bird Perch (Hanging)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\BirdPerches\\PRP_PartyGraw_BirdPerch_002.m3", 1192, 0, 4680, "Skull stick", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Cooler\\PRP_PartyGraw_Cooler_000.m3", 1192, 0, 4681, "Party Cooler", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\DJ\\PRP_PartyGraw_DJ_BoomBox_000.m3", 1192, 0, 4682, "Boombox", DecorCategory.Audio, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\DJ\\PRP_PartyGraw_DJ_DiscoBall_001.m3", 1192, 0, 4683, "Floating Discoball", DecorCategory.Electronics, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Drum\\PRP_Drum_Tribal_001.m3", 1192, 0, 4684, "Tribal Drum (Stocky)", DecorCategory.StatuesSculptures, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Fancy_Drinks\\PRP_PartyGraw_FancyDrink_000.m3", 1192, 0, 4685, "Tiki Mask Drink", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Fancy_Drinks\\PRP_PartyGraw_FancyDrink_001.m3", 1192, 0, 4686, "Tiki Skull Drink (Green)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Fancy_Drinks\\PRP_PartyGraw_FancyDrink_002.m3", 1192, 0, 4687, "Tiki Skull Drink (Red)", DecorCategory.CookwareBarware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\FishNets\\PRP_Holiday_PartyGraw_FishNet_000.m3", 1192, 0, 4688, "Fishing Net (Messy)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\FishNets\\PRP_Holiday_PartyGraw_FishNet_001.m3", 1192, 0, 4689, "Fishing Net (Damaged)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\FishNets\\PRP_Holiday_PartyGraw_FishNet_002.m3", 1192, 0, 4690, "Fishing Net (Untidy)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\FishNets\\PRP_Holiday_PartyGraw_FishNet_003.m3", 1192, 0, 4691, "Fishing Net (Plain)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\HangingDecor\\PRP_Holiday_PartyGraw_HangingDecor_Flower_000.m3", 1192, 0, 4692, "String Flowers", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\HangingDecor\\PRP_Holiday_PartyGraw_HangingDecor_Flower_001.m3", 1192, 0, 4693, "String Flowers (Long)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\HangingDecor\\PRP_Holiday_PartyGraw_HangingDecor_Flower_002.m3", 1192, 0, 4694, "String Flowers (Short)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\HangingDecor\\PRP_Holiday_PartyGraw_HangingDecor_Flower_Posts_000.m3", 1192, 0, 4695, "String Flowers (Posts)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_New_000.m3", 1192, 0, 4696, "Pool Ring (Blue)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_New_001.m3", 1192, 0, 4697, "Pool Ring (Green)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_New_002.m3", 1192, 0, 4698, "Pool Ring (Pink)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_Vind_000.m3", 1192, 0, 4699, "Pool Ring (Vind, Tan)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Innertube\\PRP_PartyGraw_Innertube_Vind_001.m3", 1192, 0, 4700, "Pool Ring (Vind, Brown)", DecorCategory.Toys, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\NeonSign\\PRP_PartyGraw_NeonSign_Body_000.m3", 1192, 0, 4701, "Neon Sign (Studrock, Beach)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\NeonSign\\PRP_PartyGraw_NeonSign_Head_000.m3", 1192, 0, 4702, "Neon Sign (Studrock, Head)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Plant\\PRP_PartyGraw_Plant_000.m3", 1192, 0, 4703, "Potted Tropical Plants (Tall)", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Plant\\PRP_PartyGraw_Plant_001.m3", 1192, 0, 4704, "Potted Tropical Plants (Short)", DecorCategory.Plants, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_000.m3", 1192, 0, 4705, "Scorecard (00)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_001.m3", 1192, 0, 4706, "Scorecard (01)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_002.m3", 1192, 0, 4707, "Scorecard (02)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_003.m3", 1192, 0, 4708, "Scorecard (03)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_004.m3", 1192, 0, 4709, "Scorecard (04)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_005.m3", 1192, 0, 4710, "Scorecard (05)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_006.m3", 1192, 0, 4711, "Scorecard (06)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_007.m3", 1192, 0, 4712, "Scorecard (07)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_008.m3", 1192, 0, 4713, "Scorecard (08)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_009.m3", 1192, 0, 4714, "Scorecard (09)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_010.m3", 1192, 0, 4715, "Scorecard (10)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Scorecard\\PRP_PartyGraw_Scorecard_011.m3", 1192, 0, 4716, "Scorecard (11)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_000.m3", 1192, 0, 4717, "Folded Beach Towel (Striped, Red)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_001.m3", 1192, 0, 4718, "Folded Beach Towel (Striped, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_002.m3", 1192, 0, 4719, "Folded Beach Towel (Striped, Grey)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_003.m3", 1192, 0, 4720, "Folded Beach Towel (Ornate, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_004.m3", 1192, 0, 4721, "Folded Beach Towel (Fancy, Magenta)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_005.m3", 1192, 0, 4722, "Folded Beach Towel (Ornate, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_FoldedTowel_006.m3", 1192, 0, 4723, "Folded Beach Towel (Fancy, Green)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_000.m3", 1192, 0, 4724, "Rolled Beach Towel (Striped, Red)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_001.m3", 1192, 0, 4725, "Rolled Beach Towel (Striped, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_002.m3", 1192, 0, 4726, "Rolled Beach Towel (Striped, Grey)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_003.m3", 1192, 0, 4727, "Rolled Beach Towel (Ornate, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_004.m3", 1192, 0, 4728, "Rolled Beach Towel (Fancy, Magenta)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_005.m3", 1192, 0, 4729, "Rolled Beach Towel (Ornate, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_RolledTowel_006.m3", 1192, 0, 4730, "Rolled Beach Towel (Fancy, Green)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_000.m3", 1192, 0, 4731, "Beach Towel (Striped, Red)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_001.m3", 1192, 0, 4732, "Beach Towel (Striped, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_002.m3", 1192, 0, 4733, "Beach Towel (Striped, Grey)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_003.m3", 1192, 0, 4734, "Beach Towel (Ornate, Yellow)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_004.m3", 1192, 0, 4735, "Beach Towel (Fancy, Magenta)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_005.m3", 1192, 0, 4736, "Beach Towel (Ornate, Blue)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\Towels\\PRP_PartyGraw_Towel_006.m3", 1192, 0, 4737, "Beach Towel (Fancy, Green)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\BuildingMaterials\\PRP_BuildingMaterials_Wood_000.m3", 1192, 0, 4738, "Pile of Planks", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Explorer\\PRP_PlayerPaths_Explorer_RadarDish_000.m3", 1192, 0, 4739, "Radar Dish (Standing)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Radar\\PRP_DefianceRadardish_000.m3", 1192, 0, 4740, "Radar Dish (Exile)", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Radar\\PRP_DefianceShieldGenerator_000.m3", 1192, 0, 4741, "Exile Shield Generator", DecorCategory.ToolsHardware, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Protostar\\PRP_Walls_Protostar_000.m3", 1192, 0, 4742, "Protostar Wall", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Protostar\\PRP_Walls_Protostar_Corner_120_000.m3", 1192, 0, 4743, "Protostar Wall Corner (120°, Sharp)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Protostar\\PRP_Walls_Protostar_Corner_90_000.m3", 1192, 0, 4744, "Protostar Wall Corner (90°, Rounded)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\PRP_Brace_RetainingWallPiston_000.m3", 1192, 0, 4745, "Retaining Piston (Fortified)", DecorCategory.Fencing, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\PRP_Brace_RetainingWallPiston_001.m3", 1192, 0, 4746, "Retaining Piston (Braced)", DecorCategory.Fencing, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\PRP_Brace_RetainingWallScrew_000.m3", 1192, 0, 4747, "Retaining Screw", DecorCategory.Fencing, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\WantedPost\\PRP_WantedPoster_000.m3", 1192, 0, 4748, "Wanted Posted (Bearded Chap)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\WantedPost\\PRP_WantedPoster_001.m3", 1192, 0, 4749, "Wanted Posted (Old Man)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\WantedPost\\PRP_WantedPoster_002.m3", 1192, 0, 4750, "Wanted Posted (Young Ruffian)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\WantedPost\\PRP_WantedPoster_003.m3", 1192, 0, 4751, "Wanted Posted (Rough Fellow)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Defiance\\PRP_PictureFrame_DefiancePoster_001.m3", 1192, 0, 4752, "Exile Poster (Raised Fists)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_HoloBase_Imperium_001.m3", 1192, 0, 4753, "Holographic Projector (Luminai)", DecorCategory.Electronics, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_001.m3", 1192, 0, 4754, "Stained Glass Hologram (Justice)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_002.m3", 1192, 0, 4755, "Stained Glass Hologram (Devotion)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_003.m3", 1192, 0, 4756, "Stained Glass Hologram (Strength)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_004.m3", 1192, 0, 4757, "Stained Glass Hologram (Courage)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_005.m3", 1192, 0, 4758, "Stained Glass Hologram (Purity)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Holo_Imperium_006.m3", 1192, 0, 4759, "Stained Glass Hologram (Knowledge)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_ImperiumPoster_006.m3", 1192, 0, 4760, "Dominion Poster (Mechari Head)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\Imperium\\PRP_PictureFrame_Imperium_Glow_000.m3", 1192, 0, 4761, "Stained Gllass Hologram (Glow)", DecorCategory.Special, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\PRP_PictureFrame_Blank_000.m3", 1192, 0, 4762, "Empty Picture Frame (Wide)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\PRP_PictureFrame_Blank_001.m3", 1192, 0, 4763, "Empty Picture Frame (Wide, Cassian)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\PRP_PictureFrame_Blank_002.m3", 1192, 0, 4764, "Empty Picture Frame (Tall, Cassian)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\PictureFrames\\PRP_PictureFrame_Blank_003.m3", 1192, 0, 4765, "Empty Picture Frame (Tall)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarContractBoard_000.m3", 1192, 0, 4766, "Protostar Contract Board", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarHorizontal_000.m3", 1192, 0, 4767, "Protostar Billboard (Wide)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarHorizontal_002.m3", 1192, 0, 4768, "Warning Sign (Protostar, Tall)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarRound_000.m3", 1192, 0, 4769, "Protostar Emblem", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarVertical_000.m3", 1192, 0, 4770, "Protostar Billboard (Tall, Advert)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarVertical_001.m3", 1192, 0, 4771, "Protostar Billboard (Tall, Loftite)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarVertical_002.m3", 1192, 0, 4772, "Protostar Billboard (Tall, Real Estate)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Aurin\\PRP_SignPost_AurinCurledHanging_002.m3", 1192, 0, 4773, "Aurin Signpost", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Chua\\PRP_Sign_Chua_ArrowGuideSign_001.m3", 1192, 0, 4774, "Arrow Guide (Chua)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Chua\\PRP_Sign_Chua_Signpost_000.m3", 1192, 0, 4775, "Signpost (Chua)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Defiance\\PRP_Defiance_Sign_004.m3", 1192, 0, 4776, "Signpost (Exile)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Defiance\\PRP_Defiance_Sign_Arrow_000.m3", 1192, 0, 4777, "Arrow Guide (Exile)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Drakken\\PRP_SignPost_Drakken_000.m3", 1192, 0, 4778, "Ornate Post (Draken)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Eldan\\PRP_Sign_Pod_Teleport_002.m3", 1192, 0, 4779, "Teleporter Sign (Eldan)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Generic\\NoticeBoard\\PRP_Sign_Generic_NoticeBoard_Dominion_000.m3", 1192, 0, 4780, "Notice Board (Dominion)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Generic\\PRP_Sign_Generic_Teleport_000.m3", 1192, 0, 4781, "Teleporter Sign", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_PinUp_RMC_000.m3", 1192, 0, 4782, "Pinup Poster (Draken Lady)", DecorCategory.WallDecor, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Mine\\PRP_Sign_Mine_000.m3", 1192, 0, 4783, "Mine Sign", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Murgh\\PRP_Sign_MurghCamp_001.m3", 1192, 0, 4784, "Suspended Cloth (Murgh)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Pell\\PRP_Sign_PellSignPost_000.m3", 1192, 0, 4785, "Banner (Pell)", DecorCategory.BannersFlags, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Pell\\PRP_Sign_PellSign_001.m3", 1192, 0, 4786, "Hanging Sign (Pell)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Pell\\PRP_Sign_PellSign_DreamCatcher_001.m3", 1192, 0, 4787, "Hanging Disc (Pell)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_BlankSign_OldWooden_000.m3", 1192, 0, 4788, "Shabby Notice Board (Wooden)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_GalerasTempestRefuge_000.m3", 1192, 0, 4789, "Sign (Tempest Refuge)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_Generic_POI_000.m3", 1192, 0, 4790, "Signpost (Floating)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_Generic_POI_Arrow_000.m3", 1192, 0, 4791, "Directional Sign (Style 1)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_Generic_POI_Arrow_001.m3", 1192, 0, 4792, "Directional Sign (Style 2)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_Generic_POI_Arrow_002.m3", 1192, 0, 4793, "Directional Sign (Style 3)", DecorCategory.Accents, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\PRP_Sign_RockStackRope_Gray_000.m3", 1192, 0, 4794, "Signpost (Granok)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Buzzbing\\PRP_BuzzbingHive_Piping_Small_001.m3", 1192, 0, 4795, "Honey Tank", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipe_Cap_000.m3", 1192, 0, 4796, "Chua Pipe Cap", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_000.m3", 1192, 0, 4797, "Chua Pipe", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_001.m3", 1192, 0, 4798, "Chua Pipe (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_002.m3", 1192, 0, 4799, "Chua Pipe (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_003.m3", 1192, 0, 4800, "Chua Pipe (Intersection)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_004.m3", 1192, 0, 4801, "Chua Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Chua\\PRP_Chua_Pipes_Stacker_000.m3", 1192, 0, 4802, "Chua Pipe Stacker", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Eldan\\PRP_Pipes_Eldan_000.m3", 1192, 0, 4803, "Eldan Pipe", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Eldan\\PRP_Pipes_Eldan_001.m3", 1192, 0, 4804, "Eldan Pipe (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Eldan\\PRP_Pipes_Eldan_002.m3", 1192, 0, 4805, "Eldan Pipe (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Eldan\\PRP_Pipes_Eldan_003.m3", 1192, 0, 4806, "Eldan Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_000.m3", 1192, 0, 4807, "Metal Pipe", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_001.m3", 1192, 0, 4808, "Metal Pipe (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_002.m3", 1192, 0, 4809, "Metal Pipe (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_004.m3", 1192, 0, 4810, "Metal Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_005.m3", 1192, 0, 4811, "Segmented Tube", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_006.m3", 1192, 0, 4812, "Segmented Tube (Short)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_007.m3", 1192, 0, 4813, "Metal Tube (Short)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_008.m3", 1192, 0, 4814, "Metal Tube (Medium)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_009.m3", 1192, 0, 4815, "Metal Tube (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_010.m3", 1192, 0, 4816, "Metal Tube (Elongated)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_011.m3", 1192, 0, 4817, "Segmented Tube (Bend)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_012.m3", 1192, 0, 4818, "Segmented Tube (Double-Bend)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_013.m3", 1192, 0, 4819, "Segmented Tube (Offset-Bend)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_014.m3", 1192, 0, 4820, "Segmented Tube (Long, Offset-Bend)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_015.m3", 1192, 0, 4821, "Segmented Tube (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_016.m3", 1192, 0, 4822, "Segmented Tube (Offset-Bend, Wide)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Pipes_000.m3", 1192, 0, 4823, "Lava Pipe ", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Pipes_001.m3", 1192, 0, 4824, "Lava Pipe (Long)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Pipes_002.m3", 1192, 0, 4825, "Lava Pipe (Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Pipes_004.m3", 1192, 0, 4826, "Lava Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Piping_Big_000.m3", 1192, 0, 4827, "Lava-Extraction Platform", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Heated\\PRP_Heated_Piping_Small_001.m3", 1192, 0, 4828, "Lava Tank", DecorCategory.BuildingBlocks, false, 5);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BoxyObsidianBlack\\PRP_Rock_BoxyObsidian_Black_002.m3", 1192, 0, 4829, "Obsidian Rock Column", DecorCategory.Rocks, false, 6);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_MistFX_000.m3", 1192, 0, 4830, "Mist Wall", DecorCategory.ParticleEffects, true, 6);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_MistFX_001.m3", 1192, 0, 4831, "Mist Wall (Soft, Blue)", DecorCategory.ParticleEffects, true, 6);
            AddGenericDecor("Art\\Water\\Waterfall\\Water_Waterfall_RippleFX_000.m3", 1192, 0, 4832, "Water Ripples", DecorCategory.ParticleEffects, true, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Elderoot\\PRP_Tree_Elderoot_Tentacles_000.m3", 1192, 0, 4833, "Wiggling Augmented Stump", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_Exanite_TreeofLifeGateDestroyed_000.m3", 1192, 0, 4834, "Overgrown Exanite Wall (Broken)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_Exanite_TreeofLifeGate_000.m3", 1192, 0, 4835, "Overgrown Exanite Wall", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_000.m3", 1192, 0, 4836, "Liferoot (Curved)", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_001.m3", 1192, 0, 4837, "Liferoot (Split)", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_002.m3", 1192, 0, 4838, "Liferoot (Pointy)", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_003.m3", 1192, 0, 4839, "Liferoot (Forked)", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\TreeofLife\\PRP_Tree_TreeofLife_Roots_004.m3", 1192, 0, 4840, "Liferoot (Gnarly)", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_000.m3", 1192, 0, 4841, "Mossy Root Archway", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_001.m3", 1192, 0, 4842, "Mossy Root Archway (Tapered Middle)", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_002.m3", 1192, 0, 4843, "Mossy Root Archway (with Offshoots)", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_003.m3", 1192, 0, 4844, "Mossy Root Offshoot", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeadBranchRoot\\PRP_Root_DreadmoorDeadBranch_GreenBrown_004.m3", 1192, 0, 4845, "Mossy Root Offshoot (Tripple)", DecorCategory.Trees, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeraduneCanopy\\PRP_Roots_DeraduneCanopy_BlueBall_001.m3", 1192, 0, 4846, "Aerophyl Bulb (Style 2)", DecorCategory.Plants, false, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Roots\\DeraduneCanopy\\PRP_Roots_DeraduneCanopy_BlueBall_002.m3", 1192, 0, 4847, "Aerophyl Bulb (Style 3)", DecorCategory.Plants, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Aurin\\PRP_Platforms_AurinShopTeleport_001.m3", 1192, 0, 4848, "Floating Aurin Platform (Stairs, Railing)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Aurin\\PRP_Platforms_AurinShopTeleport_NoRail_000.m3", 1192, 0, 4849, "Floating Aurin Platform (Stairs)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Aurin\\PRP_Platforms_AurinSmallFloating_000.m3", 1192, 0, 4850, "Floating Aurin Platform (Railing)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Aurin\\PRP_Platforms_AurinSmallFloating_NoRail_000.m3", 1192, 0, 4851, "Floating Aurin Platform", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Chua\\PRP_Platfrom_LandingPad_Chua_001.m3", 1192, 0, 4852, "Landing Pad (Chua)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Drakken\\PRP_Platform_Drakken_CircularPlatform_000.m3", 1192, 0, 4853, "Landing Pad (Draken)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_CryoChamberRevivalPlatform_000.m3", 1192, 0, 4854, "Cryochamber Platform", DecorCategory.ToolsHardware, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Stormtalon_PellPlatformLargeBackingOnly_000.m3", 1192, 0, 4855, "Pell Machine", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Stormtalon_PellPlatformLargeBaseOnly_000.m3", 1192, 0, 4856, "Pell Platform", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\PRP_Platform_Stormtalon_PellPlatformLarge_000.m3", 1192, 0, 4857, "Pell Platform (with Machine)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Protostar\\PRP_ProtostarElevatorBase_000.m3", 1192, 0, 4858, "Protostar Elevator Base", DecorCategory.ToolsHardware, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Protostar\\PRP_ProtostarElevator_000.m3", 1192, 0, 4859, "Protostar Elevator Platform", DecorCategory.ToolsHardware, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Lantern\\Marauder\\PRP_RMC_Lantern_Fancy_001.m3", 86, 0, 4860, "Hanging Lamp (Fancy, Short)", DecorCategory.Lighting, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Holiday\\PartyGraw\\TotemBar\\PRP_PartyGraw_TotemBar_000.m3", 1192, 0, 4861, "Tiki Bar", DecorCategory.CookwareBarware, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_2Pillers_000.m3", 1192, 0, 4862, "Draken Twin Pillars", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_4way_000.m3", 1192, 0, 4863, "Draken Walkway (Junction)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Curved_000.m3", 1192, 0, 4864, "Draken Walkway (Bend)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_GroundStairs_000.m3", 1192, 0, 4865, "Draken Stairs (Imposing)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Piller_000.m3", 1192, 0, 4866, "Draken Column", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Small_000.m3", 1192, 0, 4867, "Draken Walkway (Short)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Stairs_000.m3", 1192, 0, 4868, "Draken Stairs (Long)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Stairs_Small_000.m3", 1192, 0, 4869, "Draken Stairs (Short)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Strait_000.m3", 1192, 0, 4870, "Draken Walkway (Long)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Strait_001.m3", 1192, 0, 4871, "Draken Walkway", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Strait_002.m3", 1192, 0, 4872, "Draken Walkway (Reinforced)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Drakken\\PRP_Drakken_Walkways_Strait_003.m3", 1192, 0, 4873, "Draken Walkway (Adorned)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_SideWalk_SanctuaryCommonStraight_Brown_001.m3", 1192, 0, 4874, "Wooden Pallet", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Imperium\\PRP_Sign_ImperiumPropaganda_000.m3", 1192, 0, 4875, "Dominion Propaganda Screen", DecorCategory.Accents, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderArrows_000.m3", 1192, 0, 4876, "Guide Arrow (Triple)", DecorCategory.Accents, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderArrows_001.m3", 1192, 0, 4877, "Guide Arrow (Double)", DecorCategory.Accents, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderArrows_002.m3", 1192, 0, 4878, "Guide Arrow", DecorCategory.Accents, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderArrows_003.m3", 1192, 0, 4879, "Guide Arrow (Triple, Grey)", DecorCategory.Accents, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Sign\\Mine\\PRP_Sign_Mine_Entrance_Metal_001.m3", 1192, 0, 4880, "Sign (Mine, Metal)", DecorCategory.Accents, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_000.m3", 1192, 0, 4881, "Ikthian Pipe", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_001.m3", 1192, 0, 4882, "Ikthian Pipe (Long)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_002.m3", 1192, 0, 4883, "Ikthian Pipe (Curved)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_003.m3", 1192, 0, 4884, "Ikthian Pipe (T-Junction)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_004.m3", 1192, 0, 4885, "Ikthian Pipe (Long, Curved)", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Ikthian\\PRP_Ikthian_Pipes_Stacker_000.m3", 1192, 0, 4886, "Ikthian Pipe Stacker", DecorCategory.BuildingBlocks, false, 6);
            AddGenericDecor("Art\\FX\\Model\\AE\\Ice_Ground\\Ice_Ground_Decal.m3", 1192, 0, 4887, "Ice Crackle (Collision Texture)", DecorCategory.Decals, true, 6);
            AddGenericDecor("Art\\FX\\Model\\OT\\Buff\\Decal\\Decal_Elements\\Decal_Elements_5m_AQU.m3", 1192, 0, 4888, "Holographic Circle (Collision Animation)", DecorCategory.Decals, true, 6);
            AddGenericDecor("Art\\FX\\Model\\OT\\Esper\\Graveyard\\Graveyard_SmokeyDecal_01_BLU.m3", 1192, 0, 4889, "Shadowy Smoke (Collision Texture)", DecorCategory.Decals, true, 6);
            AddGenericDecor("Art\\FX\\Model\\OT\\Garr\\Vomit\\Garr_VomitDecal_90d_10mR_GRN_9.m3", 1192, 0, 4890, "Vomit Spray", DecorCategory.Decals, true, 6);
            AddGenericDecor("Art\\Prop\\Constructed\\Lootpile\\PRP_Decal_LootPile_Generic_Gold_000.m3", 1192, 0, 4891, "Treasure Pile", DecorCategory.Decals, true, 6);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_000.m3", 1192, 0, 4892, "Exanite Tree Root (Style 1)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_001.m3", 1192, 0, 4893, "Exanite Tree Root (Style 2)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_002.m3", 1192, 0, 4894, "Exanite Tree Root (Style 3)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_003.m3", 1192, 0, 4895, "Exanite Tree Root (Style 4)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_004.m3", 1192, 0, 4896, "Exanite Tree Root (Style 5)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_005.m3", 1192, 0, 4897, "Exanite Tree Root (Style 6)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_006.m3", 1192, 0, 4898, "Exanite Tree Root (Style 7)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_007.m3", 1192, 0, 4899, "Exanite Tree Root (Style 8)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_008.m3", 1192, 0, 4900, "Exanite Tree Root (Style 9)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\TreeofLife\\PRP_Tree_TreeofLife_Root_009.m3", 1192, 0, 4901, "Exanite Tree Root (Style 10)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Water\\Keepfish\\PRP_Water_Keepfish_000.m3", 1192, 0, 4902, "Water Surface (Keepfish, Double-Sided)", DecorCategory.Special, true, 7);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_000.m3", 1192, 0, 4903, "Waterfall Plunge (Forked, Abundant)", DecorCategory.ParticleEffects, false, 7);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_001.m3", 1192, 0, 4904, "Waterfall Plunge (Forked, Medium)", DecorCategory.ParticleEffects, false, 7);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneLargeWaterfall_Mist_000.m3", 1192, 0, 4905, "Waterfall Impact (Froth, Mist)", DecorCategory.ParticleEffects, true, 7);
            AddGenericDecor("Art\\Water\\Waterfall\\Deradune\\PRP_Waterfall_DeraduneSmallWaterfall_000.m3", 1192, 0, 4906, "Waterfall Plunge (Forked, Thin)", DecorCategory.ParticleEffects, false, 7);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_LargerTiered_000.m3", 1192, 0, 4907, "Waterfall Cascade (Composition)", DecorCategory.ParticleEffects, false, 7);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_TempleFalls_000.m3", 1192, 0, 4908, "Waterfall Cascade (Triple)", DecorCategory.ParticleEffects, false, 7);
            AddGenericDecor("Art\\Water\\Waterfall\\Wilderrun\\PRP_Waterfall_Wilderrun_TempleFalls_Corrupted_000.m3", 1192, 0, 4909, "Waterfall Cascade (Triple, Corrupted)", DecorCategory.ParticleEffects, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_004.m3", 1192, 0, 4910, "Rock Pillar (Concave)", DecorCategory.Rocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_006.m3", 1192, 0, 4911, "Rock Pillar (Irregular)", DecorCategory.Rocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\MoorRock\\PRP_Rock_MoorRock_007.m3", 1192, 0, 4912, "Rock Pillar (Squat)", DecorCategory.Rocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_000.m3", 1192, 0, 4913, "Loftite Crystal (Blade)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_001.m3", 1192, 0, 4914, "Loftite Crystal (Obelisk)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_002.m3", 1192, 0, 4915, "Loftite Crystal (Splinter, Stout)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_003.m3", 1192, 0, 4916, "Loftite Crystal (Splinter, Sleek)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_004.m3", 1192, 0, 4917, "Loftite Crystal (Splinter, Thin)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_005.m3", 1192, 0, 4918, "Loftite Crystal (Splinter) ", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystal_Blue_006.m3", 1192, 0, 4919, "Loftite Crystal (Small)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystals_Blue_000.m3", 1192, 0, 4920, "Loftite Crystal (Cluster, Stout)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Crystals\\PRP_Crystals_AlgorocMineCrystals_Blue_001.m3", 1192, 0, 4921, "Loftite Crystal (Cluster, Sleek)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_000.m3", 1192, 0, 4922, "Mangrove (Augmented)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_001.m3", 1192, 0, 4923, "Mangrove (Augmented, Chubby)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_002.m3", 1192, 0, 4924, "Mangrove (Augmented, Lanky)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tree\\Deciduous_RootyMangrove\\Augmented\\PRP_Tree_Deciduous_RootyMangrove_Augmented_Green_003.m3", 1192, 0, 4925, "Mangrove (Augmented, Open)", DecorCategory.Trees, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_000.m3", 1192, 0, 4926, "Exanite Fragment (Zig Zag)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_001.m3", 1192, 0, 4927, "Exanite Fragment (Jagged)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_002.m3", 1192, 0, 4928, "Exanite Fragment (Shard)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_003.m3", 1192, 0, 4929, "Exanite Fragment (Chunk)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\BrokenWall\\PRP_Rock_Exanite_BrokenWall_004.m3", 1192, 0, 4930, "Exanite Fragment (Thick)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_001.m3", 1192, 0, 4931, "Exanite Wall (Jagged)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_002.m3", 1192, 0, 4932, "Exanite Wall (Layered)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_004.m3", 1192, 0, 4933, "Exanite Wall (Overlapping)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_005.m3", 1192, 0, 4934, "Exanite Wall (Sturdy)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\Exanite_Wall\\PRP_Rock_Exanite_Wall_006.m3", 1192, 0, 4935, "Exanite Wall (Tall)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillarCap_Huge_000.m3", 1192, 0, 4937, "Exanite Platform (Hex, Iridescent Aura)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Large_000.m3", 1192, 0, 4938, "Exanite Pillar", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Pillar_001.m3", 1192, 0, 4939, "Exanite Pillar (Smooth)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_Platform_000.m3", 1192, 0, 4940, "Exanite Pillar (Stout, Iridescent Aura)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\Exanite\\PRP_Rock_ExanitePillar_SmallFloating_000.m3", 1192, 0, 4941, "Exanite Pillar (Floating, Iridescent Aura)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Vents_000.m3", 1192, 0, 4942, "Redmoon Maze", DecorCategory.Structures, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\PRP_RMT_Bathroom_Shower_Decals_Puddle_000.m3", 1192, 0, 4943, "Poop Splat", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Hand_000.m3", 1192, 0, 4944, "Poop Handprint (Left)", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Hand_001.m3", 1192, 0, 4945, "Poop Handprint (Right, Smeared)", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_LFoot_000.m3", 1192, 0, 4946, "Poop Footprint (Left, Smeared)", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_LFoot_001.m3", 1192, 0, 4947, "Poop Footprint (Left)", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_RFoot_000.m3", 1192, 0, 4948, "Poop Footprint (Right, Smeared)", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_RFoot_001.m3", 1192, 0, 4949, "Poop Footprint (Right)", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Smear_000.m3", 1192, 0, 4950, "Poop Smear", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Poop\\prp_rmt_bathroom_shower_decals_Trail_000.m3", 1192, 0, 4951, "Poop Footprint (Trail)", DecorCategory.Decals, true, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_003.m3", 1192, 0, 4952, "Redmoon Sewage Pipe (Wall-Mounted)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_004.m3", 1192, 0, 4953, "Redmoon Sewage Pipe (Siphon)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\Act3\\SewagePipes\\PRP_RMT_SewagePipes_005.m3", 1192, 0, 4954, "Redmoon Sewage Pipe (Crooked)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Compactor_Smasher_000.m3", 1192, 0, 4955, "Redmoon Compactor Smasher", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\RedMoonTerror\\PRP_RMT_Engine_BossPlatform_Side_000.m3", 1192, 0, 4956, "Redmoon Elevator Platform (Mini)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Growthshroom_GRN_000.m3", 1192, 0, 4957, "Mushroom (Green, Pair)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Growthshroom_GRN_001.m3", 1192, 0, 4958, "Mushroom (Green,Cluster)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Growthshroom_GRN_002.m3", 1192, 0, 4959, "Mushroom (Green, Teeming)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Harvestshroom_RED_000.m3", 1192, 0, 4960, "Mushroom (Red, Single)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Harvestshroom_RED_001.m3", 1192, 0, 4961, "Mushroom (Red, Double)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Harvestshroom_RED_002.m3", 1192, 0, 4962, "Mushroom (Red, Triple)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Renewshroom_BLU_000.m3", 1192, 0, 4963, "Mushroom (Blue, Single)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Renewshroom_BLU_001.m3", 1192, 0, 4964, "Mushroom (Blue, Triple)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Mushrooms\\PRP_Tradeskill_Mushrooms_Renewshroom_BLU_002.m3", 1192, 0, 4965, "Mushroom (Blue, Branching)", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Bladeleaf\\PRP_Tradeskill_Plant_Bladeleaf_000.m3", 1192, 0, 4966, "Bladeleaf Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\BloodBriar\\PRP_Tradeskill_Plant_BloodBriar_000.m3", 1192, 0, 4967, "Bloodbriar Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Candleflower\\PRP_Tradeskill_Plant_Candleflower_000.m3", 1192, 0, 4968, "Candleflower Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Clawblossom\\PRP_Tradeskill_Plant_Clowblossom_000.m3", 1192, 0, 4969, "Clawblossom Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Coralscale\\PRP_Tradeskill_Plant_Coralscale_000.m3", 1192, 0, 4970, "Coralscale Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Crowncorn\\PRP_Tradeskill_Plant_Crowncorn_000.m3", 1192, 0, 4971, "Crowncorn Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Devilspine\\PRP_Tradeskill_Plant_Devilspine_000.m3", 1192, 0, 4972, "Devilspine Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Faerybloom\\PRP_Tradeskill_Plant_Faerybloom_000.m3", 1192, 0, 4973, "Faerybloom Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Fiberstalk\\PRP_Tradeskill_Plant_Fiberstalk_000.m3", 1192, 0, 4974, "Fiberstalk Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Flamefrond\\PRP_Tradeskill_Plant_Flamefrond_000.m3", 1192, 0, 4975, "Flamefrond Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Glowmelon\\PRP_Tradeskill_Plant_Glowmelon_000.m3", 1192, 0, 4976, "Glowmelon Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Goldleaf\\PRP_Tradeskill_Plant_Goldleaf_000.m3", 1192, 0, 4977, "Goldleaf Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Grimgourd\\PRP_Tradeskill_Plant_Grimgourd_000.m3", 1192, 0, 4978, "Grimgourd Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Gunberry\\PRP_Tradeskill_Plant_Gunberry_000.m3", 1192, 0, 4979, "Gunberry Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Heartichoke\\PRP_Tradeskill_Plant_Heartichoke_000.m3", 1192, 0, 4980, "Heartichoke Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Honeywheat\\PRP_Tradeskill_Plant_Honeywheat_000.m3", 1192, 0, 4981, "Honeywheat Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Logicleaf\\PRP_Tradeskill_Plant_Logicleaf_000.m3", 1192, 0, 4982, "Logicleaf Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Mourningstar\\PRP_Tradeskill_Plant_Mourningstar_000.m3", 1192, 0, 4983, "Mourningstar Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Octopod\\PRP_Tradeskill_Plant_Octopod_000.m3", 1192, 0, 4984, "Octopod Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Pummelgranate\\PRP_Tradeskill_Plant_Pummelgranate_000.m3", 1192, 0, 4985, "Pummelgranate Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Scorchweed\\PRP_Tradeskill_Plant_Scorchweed_000.m3", 1192, 0, 4986, "Scorchweed Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Serpentlily\\PRP_Tradeskill_Plant_Serpentlily_000.m3", 1192, 0, 4987, "Serpentlily Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Spikepetal\\PRP_Tradeskill_Plant_Spikepetal_000.m3", 1192, 0, 4988, "Spikepetal Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Spirovine\\PRP_Tradeskill_Plant_Spirovine_000.m3", 1192, 0, 4989, "Spirovine Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Stoutroot\\PRP_Tradeskill_Plant_Stoutroot_000.m3", 1192, 0, 4990, "Stoutroot Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Witherwood\\PRP_Tradeskill_Plant_Witherwood_000.m3", 1192, 0, 4991, "Witherwood Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Plant\\Yellowbell\\PRP_Tradeskill_Plant_Yellowbell_000.m3", 1192, 0, 4992, "Yellowbell Plant", DecorCategory.Plants, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinDeckHalf_000.m3", 1192, 0, 4993, "Aurin Tree Platform", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinDockEnd_000.m3", 1192, 0, 4994, "Aurin Walkway (Arch)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinDoubleEndLong_000.m3", 1192, 0, 4995, "Aurin Walkway (Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinDoubleEndShort_000.m3", 1192, 0, 4996, "Aurin Walkway (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinExtension_000.m3", 1192, 0, 4997, "Aurin Walkway (Segment)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinPost_000.m3", 1192, 0, 4998, "Aurin Fence Post (Ornate)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinRampSmall_000.m3", 1192, 0, 4999, "Aurin Ramp (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinRampTall_000.m3", 1192, 0, 5000, "Aurin Ramp (Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStairsSmall_000.m3", 1192, 0, 5001, "Aurin Stairs (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStairsTall_000.m3", 1192, 0, 5002, "Aurin Stairs (Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStraightBeam_000.m3", 1192, 0, 5003, "Aurin Walkway (Arch, Style 2)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStraight_000.m3", 1192, 0, 5004, "Aurin Walkway (Long, Style 2)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinStraight_001.m3", 1192, 0, 5005, "Aurin Walkway (Long Segment)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinTIntersection_000.m3", 1192, 0, 5006, "Aurin Walkway (Tri Junction)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinTreeTrunkStairs_000.m3", 1192, 0, 5007, "Aurin Tree Stairs", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Aurin\\PRP_Walkways_AurinXRoad_000.m3", 1192, 0, 5008, "Aurin Walkway (Quad Junction)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_ClosedEndRound_000.m3", 1192, 0, 5009, "Chua Walkway (End)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_CoverSeams_001.m3", 1192, 0, 5010, "Chua Cover Panel", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_CoverSeams_Wide_001.m3", 1192, 0, 5011, "Chua Cover Panel (Wide)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Curved_000.m3", 1192, 0, 5012, "Chua Walkway (Curved)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Curved_Wide_000.m3", 1192, 0, 5013, "Chua Walkway (Curved, Wide)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Curved_Wide_001.m3", 1192, 0, 5014, "Chua Walkway (Curved, Wide, No lamps)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_000.m3", 1192, 0, 5015, "Chua Pipe Extension (Quad, Elaborate)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_001.m3", 1192, 0, 5016, "Chua Pipe Extension (Quad)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_002.m3", 1192, 0, 5017, "Chua Pipe Extension (Double, Twisted)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_003.m3", 1192, 0, 5018, "Chua Pipe Extension (Double, Parallel)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_004.m3", 1192, 0, 5019, "Chua Pipe Extension (Single, Bent)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_005.m3", 1192, 0, 5020, "Chua Pipe Extension (Single, Slanted)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Extension_006.m3", 1192, 0, 5021, "Chua Pipe Extension (Single, Twisted)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_RampLong_000.m3", 1192, 0, 5022, "Chua Ramp (Pipes)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_RampLong_Wide_000.m3", 1192, 0, 5023, "Chua Ramp (Pipes, Wide)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_RampShort_000.m3", 1192, 0, 5024, "Chua Ramp (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Ramp_000.m3", 1192, 0, 5025, "Chua Ramp", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Ramp_Wide_000.m3", 1192, 0, 5026, "Chua Ramp (Wide)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_StraitWide_000.m3", 1192, 0, 5027, "Chua Walkway (Wide)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_StraitWide_001.m3", 1192, 0, 5028, "Chua Walkway (Wide, No lamps)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_000.m3", 1192, 0, 5029, "Chua Walkway", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_001.m3", 1192, 0, 5030, "Chua Walkway (No supports)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_Short_000.m3", 1192, 0, 5031, "Chua Walkway (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_Short_Wide_000.m3", 1192, 0, 5032, "Chua Walkway (Short, Wide)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_Strait_Short_Wide_001.m3", 1192, 0, 5033, "Chua Walkway (Short, Wide, No lamps)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_TJunction_000.m3", 1192, 0, 5034, "Chua Walkway (Tri Junction)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_TJunction_Wide_000.m3", 1192, 0, 5035, "Chua Walkway (Tri Junction, Wide)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Chua\\PRP_Walkways_Chua_TJunction_Wide_001.m3", 1192, 0, 5036, "Chua Walkway (Tri Junction, Wide, No lamps)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_FullBridge_Brown_000.m3", 1192, 0, 5037, "Pell Boardwalk (Sinuous)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayCurvedStairs_Brown_000.m3", 1192, 0, 5038, "Pell Boardwalk (Stairs, Bend)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayStraightLong_Brown_000.m3", 1192, 0, 5039, "Pell Boardwalk (Long, Jutting)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayStraightLong_GreenBrown_000.m3", 1192, 0, 5040, "Pell Boardwalk (Long, Trimmed)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayStraightShort_GreenBrown_000.m3", 1192, 0, 5041, "Pell Boardwalk (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_Dreadmoor_WalkwayStraightmedium_GreenBrown_000.m3", 1192, 0, 5042, "Pell Boarewalk (Medium)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_SideWalk_DreadmoorStraight_Brown_001.m3", 1192, 0, 5043, "Scaffold Pallet (Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWayStair_DreadmoorStraight_GreenBrown_000.m3", 1192, 0, 5044, "Scaffold Stairs (Stubby, Long, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorCurved_GreenBrown_000.m3", 1192, 0, 5045, "Scaffold Stairs (Stubby, Curved, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorEndPlanks_GreenBrown_000.m3", 1192, 0, 5046, "Scaffold Planks (Quartet, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorEndPlanks_GreenBrown_004.m3", 1192, 0, 5047, "Scaffold Planks (Trio, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlank_GreenBrown_000.m3", 1192, 0, 5048, "Scaffold Plank (Short, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlank_GreenBrown_001.m3", 1192, 0, 5049, "Scaffold Plank (Medium, Fresh)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlank_GreenBrown_003.m3", 1192, 0, 5050, "Scaffold Plank (Long, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlatformExtensionMed_GreenBrown_000.m3", 1192, 0, 5051, "Scaffold Platform (Stubby, Wall-Mount, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlatformMed_GreenBrown_000.m3", 1192, 0, 5052, "Scaffold Platform (Stubby, with Ramp, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlatformMed_GreenBrown_001.m3", 1192, 0, 5053, "Scaffold Platform (Stubby, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Dreadmoor\\PRP_WalkWay_DreadmoorPlatformSm_GreenBrown_000.m3", 1192, 0, 5054, "Scaffold Catwalk (Stubby, Short, Green Tinge)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_CornerPost_001.m3", 1192, 0, 5055, "Dominion Corner Post", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_EndCap_001.m3", 1192, 0, 5056, "Dominion Bridge Pier (Endcap)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_EntranceExit_001.m3", 1192, 0, 5057, "Dominion Bridge Pier", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_EntranceExit_noExtension_001.m3", 1192, 0, 5058, "Dominion Bridge Pier (Platform)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Extension_001.m3", 1192, 0, 5059, "Dominion Bridge Pier (Extension)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Extension_NOrailing_001.m3", 1192, 0, 5060, "Dominion Bridge Pier (Extension, No Rail)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_MetalJunction_001.m3", 1192, 0, 5061, "Dominion Metal Strut", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Pillar_Fancy_000.m3", 1192, 0, 5062, "Dominion Pier Pillar", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Pillar_Fancy_001.m3", 1192, 0, 5063, "Dominion Pier Pillar (Double)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Pillars_EndCap_001.m3", 1192, 0, 5064, "Dominion Bridge Pier (Endcap Pillars)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Pillars_Extension_001.m3", 1192, 0, 5065, "Dominion Bridge Pier (Extension Pillars)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Ramp_TALL_001.m3", 1192, 0, 5066, "Dominion Ramp (Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Stairs_90_LEFT_001.m3", 1192, 0, 5067, "Dominion Stairs (Quarter, Left)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Stairs_TALL_001.m3", 1192, 0, 5068, "Dominion Stairs (Tall)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_TBone_001.m3", 1192, 0, 5069, "Dominion Bridge Pier (T-Junction)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_Turn_001.m3", 1192, 0, 5070, "Dominion Walkway (Elbow Junction)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_XRoads_001.m3", 1192, 0, 5071, "Dominion Walkway (Quad Junction)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Imperium_Walkways_t_Segment_001.m3", 1192, 0, 5072, "Dominion Walkway (Tri Junction)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Walkways_Stairs_90_LEFT_Narrow_001.m3", 1192, 0, 5073, "Dominion Stairs (Narrow Quarter, Left)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Imperium\\Imperium_Variants\\PRP_Walkways_Stairs_90_Right_Narrow_001.m3", 1192, 0, 5074, "Dominion Stairs (Narrow Quarter, Right)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_FullBridge_000.m3", 1192, 0, 5075, "Pell Boardwalk (Sinuous, Fenced)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwayCurvedDip_000.m3", 1192, 0, 5076, "Pell Boardwalk (Leaning Bend, Fenced)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwayCurvedStairs_000.m3", 1192, 0, 5077, "Pell Boardwalk (Stairs, Bend, with Fence)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwaySlopedRamp_000.m3", 1192, 0, 5078, "Pell Boardwalk (Ramp, Fenced)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwayStraightLong_000.m3", 1192, 0, 5079, "Pell Boardwalk (Long, Jutting, Fenced)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Pell\\PRP_Pell_WalkwayWoodPlank_000.m3", 1192, 0, 5080, "Pell Plank (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Corner_000.m3", 1192, 0, 5081, "Protostar Tile (Corner)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Corner_001.m3", 1192, 0, 5082, "Protostar Tile (Middle)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Corner_002.m3", 1192, 0, 5083, "Protostar Tile (Side)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Protostar\\PRP_Protostar_Walkway_Straight_000.m3", 1192, 0, 5084, "Protostar Tiles (Trio, Straight)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WWStair_SCLeftDblWide_Brown_000.m3", 1192, 0, 5085, "Scaffold Stairs (Wide, Left Turn)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WWStair_SCRgtDblWide_Brown_000.m3", 1192, 0, 5086, "Scaffold Stairs (Wide, Right Turn)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WWStair_SCStraightDblWide_Brown_000.m3", 1192, 0, 5087, "Scaffold Stairs (Wide, Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WWStair_SCStraightDblWide_Brown_001.m3", 1192, 0, 5088, "Scaffold Stairs (Wide, Low, Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonLeft_Brown_000.m3", 1192, 0, 5089, "Scaffold Stairs (Left Turn)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonRight_Brown_000.m3", 1192, 0, 5090, "Scaffold Stairs (Right Turn)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonStraight_Brown_000.m3", 1192, 0, 5091, "Scaffold Stairs (Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonStraight_Brown_001.m3", 1192, 0, 5092, "Scaffold Stairs (Low, Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWayStair_SanctuaryCommonStraight_Brown_002.m3", 1192, 0, 5093, "Scaffold Stairs (Tall, Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SCPlatformExtensionMed_Brown_000.m3", 1192, 0, 5094, "Scaffold Platform (Wall-Mount)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SCPlatformExtensionMed_Brown_001.m3", 1192, 0, 5095, "Scaffold Platform (no Supports)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonCurved_Brown_000.m3", 1192, 0, 5096, "Scaffold (Curved)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonEndPlanks_Brown_000.m3", 1192, 0, 5097, "Scaffold Planks (Quartet)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlank_Brown_000.m3", 1192, 0, 5098, "Scaffold Plank (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlank_Brown_001.m3", 1192, 0, 5099, "Scaffold Plank (Mediun, Style 1)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlank_Brown_002.m3", 1192, 0, 5100, "Scaffold Plank (Mediun, Style 2)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlank_Brown_003.m3", 1192, 0, 5101, "Scaffold Plank (Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlatformMed_Brown_000.m3", 1192, 0, 5102, "Scaffold Platform (with Short Ramp)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonPlatformMed_Brown_001.m3", 1192, 0, 5103, "Scaffold Platform", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonRailing_Brown_000.m3", 1192, 0, 5104, "Scaffold Fence", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PRP_WalkWay_SanctuaryCommonStraight_Brown_000.m3", 1192, 0, 5105, "Scaffold Catwalk (Half Height, Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PrP_WalkWay_SanctuaryCommonPlatformSm_Brown_000.m3", 1192, 0, 5106, "Scaffold Catwalk (Short, Single Fence)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\SanctuaryCommon\\PrP_WalkWay_SanctuaryCommonPlatformSm_Brown_001.m3", 1192, 0, 5107, "Scaffold Catwalk (Short, Single Fence, no Supports)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Curved_000.m3", 1192, 0, 5108, "Bamboo Walkway (Curved)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Curved_Ramp_LT_000.m3", 1192, 0, 5109, "Bamboo Ramp (Curved, Left)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Curved_Ramp_RT_000.m3", 1192, 0, 5110, "Bamboo Ramp (Curved, Right)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Curved_000.m3", 1192, 0, 5111, "Bamboo Walkway (Wide, Curved)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Curved_LT_000.m3", 1192, 0, 5112, "Bamboo Walkway (Wide, Curved Left)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Curved_RT_000.m3", 1192, 0, 5113, "Bamboo Walkway (Wide, Curved Right)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_EXT_000.m3", 1192, 0, 5114, "Bamboo Platform (Wide, Extended)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_EXT_4WAY_000.m3", 1192, 0, 5115, "Bamboo Platform (Wide, Extended, Thatched)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Long_000.m3", 1192, 0, 5116, "Bamboo Walkway (Wide, Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Long_Rail_000.m3", 1192, 0, 5117, "Bamboo Walkway (Wide, Long, Railing)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Long_Ramp_000.m3", 1192, 0, 5118, "Bamboo Ramp (Wide, Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Short_Ramp_000.m3", 1192, 0, 5119, "Bamboo Ramp (Wide, Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_000.m3", 1192, 0, 5120, "Bamboo Platform (Large)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_4WAY_000.m3", 1192, 0, 5121, "Bamboo Platform (Large, Thatched)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_Rail_000.m3", 1192, 0, 5122, "Bamboo Platform (Large, Railing)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_Tall_000.m3", 1192, 0, 5123, "Bamboo Walkway (Wide Segment)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_Tall_4WAY_000.m3", 1192, 0, 5124, "Bamboo Walkway (Wide Segment, Thatched)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_DBL_Square_Tall_Rail_000.m3", 1192, 0, 5125, "Bamboo Walkway (Wide Segment, Railing)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Long_000.m3", 1192, 0, 5126, "Bamboo Walkway (Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Long_Rail_000.m3", 1192, 0, 5127, "Bamboo Walkway (Long, Railing)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Long_Ramp_000.m3", 1192, 0, 5128, "Bamboo Ramp (Long)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Rail_000.m3", 1192, 0, 5129, "Bamboo Railing", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Short_Ramp_000.m3", 1192, 0, 5130, "Bamboo Ramp (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_000.m3", 1192, 0, 5131, "Bamboo Platform (Small)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_4Way_000.m3", 1192, 0, 5132, "Bamboo Platform (Small, Thatched)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_Rail_000.m3", 1192, 0, 5133, "Bamboo Platform (Small, Railing)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_Tall_000.m3", 1192, 0, 5134, "Bamboo Walkway (Segment)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_Tall_4WAY_000.m3", 1192, 0, 5135, "Bamboo Walkway (Segment, Thatched)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\WalkWays\\Tribal\\PRP_WalkWay_Bamboo_Square_Tall_Rail_000.m3", 1192, 0, 5136, "Bamboo Walkway (Segment, Railing)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_004.m3", 1192, 0, 5137, "Dreadmoor Tube (Angled)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_005.m3", 1192, 0, 5138, "Dreadmoor Tube (Straight)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_007.m3", 1192, 0, 5139, "Dreadmoor Tube (Corner)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Dreadmoore\\PRP_Pipes_Dreadmoore_012.m3", 1192, 0, 5140, "Valve", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_000.m3", 1192, 0, 5142, "Wiggling Pillar (Warped)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_001.m3", 1192, 0, 5143, "Wiggling Pillar (Twisted)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_BlackholeBridge_Pipes_002.m3", 1192, 0, 5144, "Wiggling Pillar (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_017.m3", 1192, 0, 5145, "Segmented Tube (Corner, Style 1)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_018.m3", 1192, 0, 5146, "Segmented Tube (Corner, Style 2)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_019.m3", 1192, 0, 5147, "Segmented Tube (Thick, Bendy)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_020.m3", 1192, 0, 5148, "Segmented Tube (Thick, Skewed)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_021.m3", 1192, 0, 5149, "Segmented Tube (Short Segment)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_022.m3", 1192, 0, 5150, "Segmented Tube (Long Segment)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_023.m3", 1192, 0, 5151, "Segmented Tube (Thick Segment)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_000.m3", 1192, 0, 5152, "Tube Connector (Rounded)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_001.m3", 1192, 0, 5153, "Tube Connector (Straight, Markings)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_002.m3", 1192, 0, 5154, "Tube Connector (Uneven)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_003.m3", 1192, 0, 5155, "Tube Connector (Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_004.m3", 1192, 0, 5156, "Tube Connector (Uneven, Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_005.m3", 1192, 0, 5157, "Tube Connector (Uneven, Markings)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_006.m3", 1192, 0, 5158, "Tube Connector (Uneven, Screwed)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_007.m3", 1192, 0, 5159, "Tube Connector (Short, Dark)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_008.m3", 1192, 0, 5160, "Tube Connector (Screwed, Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_009.m3", 1192, 0, 5161, "Tube Connector (Screwed)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\Generic\\PRP_Generic_Pipes_Connector_010.m3", 1192, 0, 5162, "Tube Connector (Rounded, Short)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipe_AirVent_RMC_000.m3", 1192, 0, 5163, "Metal Standing Pipe", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_000.m3", 1192, 0, 5164, "Chua Pod (Pipes)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_001.m3", 1192, 0, 5165, "Metal Tube (Wide Curve)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_LargePipeKit_002.m3", 1192, 0, 5166, "Chua Refinery", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\RedMoonCove\\PRP_Pipes_Valve_RMC_001.m3", 1192, 0, 5167, "Valve (Round)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_LongSegment_GreyBrown_000.m3", 1192, 0, 5168, "Copper Tubing (Valve)", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Pipes\\SanctuaryCommon\\PRP_Pipe_MidSegment_GreyBrown_000.m3", 1192, 0, 5169, "Copper Tubing", DecorCategory.BuildingBlocks, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_Holocrypt_000.m3", 1192, 0, 5170, "Holocrypt", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_AntiEntropicFluid_000.m3", 1192, 0, 5171, "Vial (Anti-Entropic Fluid)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_ArcBatteries_000.m3", 1192, 0, 5172, "Arc Battery", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_BankBox_000.m3", 1192, 0, 5173, "Bank Box", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_BuffBot_Generator.m3", 1192, 0, 5174, "Boost Station (Powered Down)", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_BuffStation_000.m3", 1192, 0, 5175, "Boost Station (Powered Up)", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_BuffStation_001.m3", 1192, 0, 5176, "Boost Station (Tween)", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_BuildAnim_2x2.m3", 1192, 0, 5177, "Construction Zone (Dusty)", DecorCategory.Structures, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Campfire_000.m3", 86, 0, 5178, "Campfire (Rocks, Small)", DecorCategory.Lighting, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Campfire_001.m3", 86, 0, 5179, "Campfire (Rocks, Medium)", DecorCategory.Lighting, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Campfire_002.m3", 86, 0, 5180, "Campfire (Rocks, Large)", DecorCategory.Lighting, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_CarbonRods_000.m3", 1192, 0, 5181, "Carbon Rods", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Crate_000.m3", 1192, 0, 5182, "Settler Crate (Closed)", DecorCategory.Containers, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Crate_001.m3", 1192, 0, 5183, "Settler Crate (Medkits)", DecorCategory.Containers, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Crate_002.m3", 1192, 0, 5184, "Settler Crate (Gears and Bars)", DecorCategory.Containers, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Crate_003.m3", 1192, 0, 5185, "Settler Crate (Eldan Scrap)", DecorCategory.Containers, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_DataPyramid_000.m3", 1192, 0, 5186, "Data Pyramid", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Depot_000.m3", 1192, 0, 5187, "Beacon Plug", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_EnergizedWater_000.m3", 1192, 0, 5188, "Vial (Energized Water)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_FuelCell.m3", 1192, 0, 5189, "Barrel (Skinny-Waisted, Orange)", DecorCategory.Containers, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_LightningRod_000.m3", 1192, 0, 5190, "Tesla Coil", DecorCategory.Electronics, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Mailbox_000.m3", 1192, 0, 5191, "Mailbox (Settler)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_MegaFreezon_000.m3", 1192, 0, 5192, "Freeze Gun", DecorCategory.WeaponsArmor, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_PowerBase_000.m3", 1192, 0, 5193, "Landing Post", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Shop_000.m3", 1192, 0, 5194, "Hovering Shop (Settler)", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Sign_POI_000.m3", 1192, 0, 5195, "Signpost (Floating, Green)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Sign_POI_Arrow_000.m3", 1192, 0, 5196, "Directional Sign (Green, Style 1)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Sign_POI_Arrow_001.m3", 1192, 0, 5197, "Directional Sign (Green, Style 2)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_Sign_POI_Arrow_002.m3", 1192, 0, 5198, "Directional Sign (Green, Style 3)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_SolarFuelCells_000.m3", 1192, 0, 5199, "Solar Dish", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_SupplyCapsule.m3", 1192, 0, 5200, "Supply Station (Empty)", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_TaxiSign_000.m3", 1192, 0, 5201, "Taxi Sign Pole", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_TechTotem_000.m3", 1192, 0, 5202, "Beacon (Settler)", DecorCategory.Electronics, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_VendingMachine_001.m3", 1192, 0, 5203, "Vending Machine (Supplies)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_VendorSign_000.m3", 1192, 0, 5204, "Protostar Billboard (Tall, ATM)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_WarpedMetal_000.m3", 1192, 0, 5205, "Scrap Pile (Metal)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\PRP_PlayerPaths_Settler_WeaponRack_000.m3", 1192, 0, 5206, "Dominion Weapon Rack (Stocked)", DecorCategory.WeaponsArmor, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Player_Paths\\Settler\\holograms\\PRP_PlayerPaths_Settler_HoloTent_001.m3", 1192, 0, 5207, "Holographic Tent Sign", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Bandit\\PRP_Tent_Bandit_000.m3", 1192, 0, 5208, "Tent (Leaf Camouflage)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Bandit\\PRP_Tent_Bandit_002.m3", 1192, 0, 5209, "Webbed Net", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\CarnivalBooth\\PRP_Tent_CarnivalBooth_000.m3", 1192, 0, 5210, "Carnival Stand", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\DAS\\PRP_DAS_TentDoor_000.m3", 1192, 0, 5211, "Wooden Door (Wire Grate)", DecorCategory.Doors, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\DAS\\PRP_DAS_Tent_000.m3", 1192, 0, 5212, "Tent (Explorers)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\DAS\\PRP_DAS_Tent_Open_000.m3", 1192, 0, 5213, "Tent (Explorers, Open)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Destroyed\\PRP_Tent_Destroyed_000.m3", 1192, 0, 5214, "Tent (Destroyed)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Dregg\\PRP_Tent_Dregg_001.m3", 1192, 0, 5215, "Tent (Dreg)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Imperium\\PRP_Tent_ImperiumLarge_001.m3", 1192, 0, 5216, "Tent (Dominion, Large)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Imperium\\PRP_Tent_ImperiumSmall_001.m3", 1192, 0, 5217, "Tent (Dominion, Small)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Lopp\\PRP_Lopp_House_001.m3", 1192, 0, 5218, "Lopp House (Netting)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Marauder\\PRP_Marauder_Tent_003.m3", 1192, 0, 5219, "Intel Station (Marauder, Graffitti)", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Marauder\\PRP_Tent_MarauderShieldPod_Rust_001.m3", 1192, 0, 5220, "Shield Pod (Plain)", DecorCategory.ToolsHardware, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\PRP_Tent_SmugglerLargeSteepled_Brown_000.m3", 1192, 0, 5221, "Tent (Smuggler, Large)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\PRP_Tent_SmugglerSmall_Brown_000.m3", 1192, 0, 5222, "Tent (Smuggler, Small)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Pell\\PRP_Tent_Pell_Metal_000.m3", 1192, 0, 5223, "Tent (Pell, Metal)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\SwordMaiden\\PRP_Tent_SwordMaiden_000.m3", 1192, 0, 5224, "Tent (Torine)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\SwordMaiden\\PRP_Tent_SwordMaiden_Decor_002.m3", 1192, 0, 5225, "Headdress (Torine, No Chimes)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\SwordMaiden\\PRP_Tent_SwordMaiden_Decor_004.m3", 1192, 0, 5226, "Emerald Sword (Torine, Simple)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Tents_Bone_Hide\\PRP_Tent_BoneHide_BrownTan_000.m3", 1192, 0, 5227, "Awning (Draken, Trapezoid)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Tents_Bone_Hide\\PRP_Tent_BoneHide_BrownTan_001.m3", 1192, 0, 5228, "Awning (Draken, Small)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Constructed\\Tents\\Tents_Bone_Hide\\PRP_Tent_BoneHide_BrownTan_002.m3", 1192, 0, 5229, "Awning (Draken, Arching)", DecorCategory.Accents, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\Torine\\Platforms\\PRP_TorineSanctuary_Platform_001.m3", 1192, 0, 5230, "Rock Platform (Stairs)", DecorCategory.Rocks, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\Torine\\Platforms\\PRP_TorineSanctuary_Platform_002.m3", 1192, 0, 5231, "Rock Platform (Hole)", DecorCategory.Rocks, false, 7);
            AddGenericDecor("Art\\Prop\\Dungeon\\Torine\\Platforms\\PRP_TorineSanctuary_Platform_003.m3", 1192, 0, 5232, "Rock Platform", DecorCategory.Rocks, false, 7);
            AddGenericDecor("Art\\Weather\\Temp\\Weather_Temp_Snow_White_000.m3", 1192, 0, 5233, "Snow Flurry", DecorCategory.ParticleEffects, true, 7);
            AddGenericDecor("Art\\Light\\Design\\BossFight\\LIT_Boss_NPE_Combat.m3", 86, 0, 5234, "Directional Light (Stops at Gizmo)", DecorCategory.LightSource, true, 8);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_002.m3", 86, 0, 5235, "Spot Light (Throb)", DecorCategory.LightSource, true, 8);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_Generic_003.m3", 86, 0, 5236, "Spot Light (Throb, Dim)", DecorCategory.LightSource, true, 8);
            AddGenericDecor("Art\\Light\\Design\\LIT_SpotLight_HeadLight_Brighter_000.m3", 86, 0, 5237, "Spot Light (Volumetric, Bright, Flickering)", DecorCategory.LightSource, true, 8);
            AddGenericDecor("Art\\FX\\Echo\\Earth_BRN\\Earth_BRN.m3", 1192, 0, 5238, "Mote of Earth", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Echo\\Fire_OGE\\Fire_OGE.m3", 1192, 0, 5239, "Mote of Fire", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Echo\\Shock_BLE\\Shock_BLE.m3", 1192, 0, 5240, "Mote of Air", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Echo\\Water_BLE\\Water_BLE.m3", 1192, 0, 5241, "Mote of Water", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Fire_FireRain\\Fire_FireRain_10m.m3", 1192, 0, 5242, "Fire Rain (Scorched Earth)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Fire_FireRain\\Fire_FireRain_SingleLarge.m3", 1192, 0, 5243, "Fire Rain (Single Strike)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Fire_FireRain\\Fire_FireRain_noDecalnGrdFX_10m.m3", 1192, 0, 5244, "Fire Rain", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Ice_Blizzard\\Ice_Blizzard_5m.m3", 1192, 0, 5245, "Snow Devil (Recurring)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Caster\\Ice_Blizzard\\Ice_Blizzard_Flurry_5m.m3", 1192, 0, 5246, "Snow Devil (Bursts)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Fire_OGE\\Fire_NoDecal_OGE.m3", 1192, 0, 5247, "Fire (Circular, Recurring)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Fire_OGE\\Fire_OGE.m3", 1192, 0, 5248, "Fire (Circular, Recurring, with Flare)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Fire_Trail\\Fire_Trail_Loop_OGE.m3", 1192, 0, 5249, "Fire Wall", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Fire_Trail\\Fire_Trail_OGE.m3", 1192, 0, 5250, "Fiery Eruption", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Test\\MMalley\\Test_Weapon_Orb_FireBall_Stationary.m3", 1192, 0, 5251, "Fireball (Blazing)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Test\\SLee\\3D\\TS_Fire_Ground.m3", 1192, 0, 5252, "Fire (Flame, Recurring)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Action\\Fire_Flame_OGE\\Fire_Flame_OGE.m3", 1192, 0, 5253, "Fire (Erupting)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Molotov_Fire_ORA\\Molotov_Fire_ORA.m3", 1192, 0, 5254, "Fire (Molotov, Recurring, with Flare)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Molotov_Fire_ORA\\Molotov_Fire_noDecal_ORA.m3", 1192, 0, 5255, "Fire (Molotov, Recurring)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\AE\\Probebot_Pell\\Probebot_Pell_LaserSweep_FireRing\\ProbeBot_Pell_LaserSweep_FireRing.m3", 1192, 0, 5256, "Fire (Circular, Sweep)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Caster\\Fire_OrbitingFlames\\Fire_OrbitingFlames_OGE.m3", 1192, 0, 5257, "Fire Anomaly", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_BallDual_OGE\\Fire_BallDual_3FL_OGE.m3", 1192, 0, 5258, "Fire Orbs (Duo, Sparkle)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_BallDual_OGE\\Fire_BallDual_OGE.m3", 1192, 0, 5259, "Fire Orbs (Duo, Bright)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_BallQuad_OGE\\Fire_BallQuad_3FL_OGE.m3", 1192, 0, 5260, "Fire Orbs (Four, Sparkle, Swirl)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_BallQuad_OGE\\Fire_BallQuad_OGE.m3", 1192, 0, 5261, "Fire Orbs (Four, Sparkle)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Ball\\Fire_Ball_GRN_12.m3", 1192, 0, 5262, "Fire Ball (Green)", DecorCategory.ParticleEffects, false, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Ball_OGE\\Fire_Ball_3FL_OGE_12.m3", 1192, 0, 5263, "Fire Mote", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Ball_OGE\\Fire_Ball_OGE_12.m3", 1192, 0, 5264, "Fire Ball", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_Flame_OGE\\Fire_Flame_OGE.m3", 1192, 0, 5265, "Fire (Erupting, Fast)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\Model\\Cast\\Fire_OrbitingFlames\\Fire_OrbitingFlames_OGE.m3", 1192, 0, 5266, "Fire Anomaly (Bright)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Robots\\WorldDestroyer_Destroyed\\PRP_WorldDestroyer_Torso_002.m3", 1192, 0, 5267, "Annihilator Torso", DecorCategory.ToolsHardware, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Cassian\\PRP_Entry_CassianMedium_B.m3", 1192, 0, 5268, "Entry Cassian (Large, Archless)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_A_Clean.m3", 1192, 0, 5269, "Entry Granok (Cozy, Sheltered Steps)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_C_Clean.m3", 1192, 0, 5270, "Entry Granok (Cozy, Rustic Threshold)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\Granok\\PRP_Entry_GranokSmall_D_Clean.m3", 1192, 0, 5271, "Entry Granok (Cozy, Stone Archway)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_A.m3", 1192, 0, 5272, "Entry Osun (Skull)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_B.m3", 1192, 0, 5273, "Entry Osun (Metal Banner)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\Entry\\OSUN\\PRP_Entry_Osun_C.m3", 1192, 0, 5274, "Entry Osun (Horns)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_000_Brown.m3", 1192, 0, 5275, "Tallflower Stump (Style 1)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_001_Brown.m3", 1192, 0, 5276, "Tallflower Stump (Style 2)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_002_Brown.m3", 1192, 0, 5277, "Tallflower Stump (Style 3)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_003_Brown.m3", 1192, 0, 5278, "Tallflower Stump (Style 4)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_004_Brown.m3", 1192, 0, 5279, "Tallflower Stump (Style 5)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_005_Brown.m3", 1192, 0, 5280, "Tallflower Stump (Style 6)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_006_Brown.m3", 1192, 0, 5281, "Tallflower Stump (Style 7)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_007_Brown.m3", 1192, 0, 5282, "Tallflower Stump (Style 8)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\FlowerStump_Tallthing_Thorny\\PRP_Stump_Tallthing_Torny_008_Brown.m3", 1192, 0, 5283, "Tallflower Stump (Style 9)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\PointyPine\\PRP_Stump_PointyPine_001.m3", 1192, 0, 5284, "Tree Stump (Razed)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\PointyPine\\PRP_Stump_PointyPine_002.m3", 1192, 0, 5285, "Tree Stump (Shortened)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\StandardPine\\PRP_Stump_BurntStandardPine_GreenGrey_000.m3", 1192, 0, 5286, "Tree Stump (Burnt, Wide)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\StandardPine\\PRP_Stump_BurntStandardPine_GreenGrey_001.m3", 1192, 0, 5287, "Tree Stump (Burnt, Narrow)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\Swirly_TwistedRoots_Large\\PRP_Stump_SwirlyTwisted_GreenGrey_000.m3", 1192, 0, 5288, "Tree Stump (Wide, Rooty, Smooth)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\Swirly_TwistedRoots_Large\\PRP_Stump_SwirlyTwisted_GreenGrey_Skinny_000.m3", 1192, 0, 5289, "Tree Stump (Medium, Rooty, Smooth)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\Swirly_TwistedRoots_Large\\PRP_Stump_SwirlyTwisted_RuffEdges_GreenGrey_000.m3", 1192, 0, 5290, "Tree Stump (Wide, Rooty, Frayed)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\Swirly_TwistedRoots_Large\\PRP_Stump_SwirlyTwisted_RuffEdges_GreenGrey_001.m3", 1192, 0, 5291, "Tree Stump (Medium, Block, Frayed)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Stump\\Swirly_TwistedRoots_Large\\PRP_Stump_SwirlyTwisted_RuffEdges_GreenGrey_002.m3", 1192, 0, 5292, "Tree Stump (Narrow, Cone, Frayed)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Engine_003.m3", 1192, 0, 5293, "Ship Parts (Nacelle)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Engine_004.m3", 1192, 0, 5294, "Ship Parts (Thruster, Dual)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Engine_Left_006.m3", 1192, 0, 5295, "Ship Parts (Thruster, Left)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Engine_Right_006.m3", 1192, 0, 5296, "Ship Parts (Thruster, Right)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Fin_002.m3", 1192, 0, 5297, "Ship Parts (Fin)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Hull_003.m3", 1192, 0, 5298, "Ship Parts (Hull)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Light_001.m3", 1192, 0, 5299, "Ship Parts (Tech-Viewport)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Weapon_001.m3", 1192, 0, 5300, "Ship Parts (Turret)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Window_000.m3", 1192, 0, 5301, "Ship Parts (Light, Cabochon)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Left_000.m3", 1192, 0, 5302, "Ship Parts (Wing. Crescent, Left)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Left_003.m3", 1192, 0, 5303, "Ship Parts (Wing, Fly, Left)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Left_004.m3", 1192, 0, 5304, "Ship Parts (Wing, Slab, Left)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Right_000.m3", 1192, 0, 5305, "Ship Parts (Wing, Crescent, Right)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Right_003.m3", 1192, 0, 5306, "Ship Parts (Wing, Fly, Right)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Wing_Right_004.m3", 1192, 0, 5307, "Ship Parts (Wing, Slab, Right)", DecorCategory.Spaceship, false, 8);
            AddGenericDecor("Art\\FX\\3D\\Splatter_Goo_Decal_GRN\\Splatter_Goo_Decal_02_GRN.m3", 1192, 0, 5308, "Goo Decal (Splatter Flash, Green)", DecorCategory.Decals, true, 8);
            AddGenericDecor("Art\\FX\\3D\\Splatter_Goo_Decal_GRN\\Splatter_Goo_Decal_03_GRN.m3", 1192, 0, 5309, "Goo Decal (Spray Flash, Green)", DecorCategory.Decals, true, 8);
            AddGenericDecor("Art\\FX\\3D\\Splatter_Goo_Decal_GRN\\Splatter_Goo_Decal_04_GRN.m3", 1192, 0, 5310, "Goo Decal (Diffuse Flash, Green)", DecorCategory.Decals, true, 8);
            AddGenericDecor("Art\\FX\\3D\\Spray_BB_BLE\\Spray_BB_BLE.m3", 1192, 0, 5311, "Energy Scatter (Ripple Flash)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\FX\\3D\\Square_BB_BLE\\Square_BB_BLE.m3", 1192, 0, 5312, "Logic Bit (Fade-In, Fade-Out)", DecorCategory.ParticleEffects, true, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_00.m3", 1192, 0, 5313, "Blasted Rock (Pointy)", DecorCategory.Rocks, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_01.m3", 1192, 0, 5314, "Blasted Rock (Boulder)", DecorCategory.Rocks, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_02.m3", 1192, 0, 5315, "Blasted Rock (Jagged)", DecorCategory.Rocks, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_03.m3", 1192, 0, 5316, "Blasted Rock (Fragment)", DecorCategory.Rocks, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_04.m3", 1192, 0, 5317, "Blasted Rock (Chunk)", DecorCategory.Rocks, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_05.m3", 1192, 0, 5318, "Blasted Rock (Barnacle)", DecorCategory.Rocks, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Rock\\BlastedJagged\\PRP_Rock_BlastedJagged_Black_06.m3", 1192, 0, 5319, "Blasted Rock (Cobble)", DecorCategory.Rocks, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Auroria\\PRP_Tradeskill_Tree_Auroria_000.m3", 1192, 0, 5320, "Stump (Peaked Elm, Auroria)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\BulbyThickDecidious\\PRP_Tradeskill_Tree_BulbyThickDecidious_000.m3", 1192, 0, 5321, "Stump (Savannah Palm, Deradune)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\CelestionTreeNode\\PRP_Tree_CelestionTreeNode_Pale_000.m3", 1192, 0, 5322, "Stump (Celestion Tree)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Coralus\\PRP_Tradeskill_Tree_Coralus_000.m3", 1192, 0, 5323, "Stump (Reef Palm, Coralus)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Dreadmoore\\PRP_Tradeskill_Tree_Dreadmoore_000.m3", 1192, 0, 5324, "Stump (Bog Willow, Dreadmoor)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Ellevar\\PRP_Tradeskill_Tree_Ellevar_000.m3", 1192, 0, 5325, "Stump (Blazing Pine, Ellevar)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Farside\\PRP_Tradeskill_Tree_Farside_000.m3", 1192, 0, 5326, "Stump (Logic Tree, Farside)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Galeras\\PRP_Tradeskill_Tree_Galeras_000.m3", 1192, 0, 5327, "Stump (Whimlarch Tree, Galeras)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\HalonRing\\PRP_Tradeskill_Tree_HalonRing_000.m3", 1192, 0, 5328, "Stump (Flatflower, Halon Ring)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Isigrol\\PRP_Tradeskill_Tree_Isigrol_000.m3", 1192, 0, 5329, "Stump (Grimgrove Tree, Corrupted)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Malgrave\\PRP_Tradeskill_Tree_Malgrave_000.m3", 1192, 0, 5330, "Stump (Drywood Tree, Malgrave)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Murkmire\\PRP_Tradeskill_Tree_Murkmire_000.m3", 1192, 0, 5331, "Stump (Grimgrove Tree, Deciduous)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\PointyPineThick\\PRP_Tradeskill_Tree_PointyPineTallThin_000.m3", 1192, 0, 5332, "Pine Tree (Azure)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\PointyPineThick\\PRP_Tradeskill_Tree_PointyPineThick_000.m3", 1192, 0, 5333, "Stump (Azure Ash Tree, Algoroc)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Whitevale\\PRP_Tradeskill_Tree_Whitevale_000.m3", 1192, 0, 5334, "Stump (Frosty Elm, Whitevale)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Natural\\Tradeskill\\Tree\\Wilderrun\\PRP_Tradeskill_Tree_Wilderrun_000.m3", 1192, 0, 5335, "Stump (Cerulean Palm, Wilderrun)", DecorCategory.Trees, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Imperium\\PRP_Platform_ImperiumMilitary_001.m3", 1192, 0, 5336, "Dais (Dominion)", DecorCategory.ToolsHardware, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Imperium\\PRP_Platform_ImperiumMilitary_002.m3", 1192, 0, 5337, "Buttress (Dominion)", DecorCategory.ToolsHardware, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Platforms\\Imperium\\PRP_Platform_ImperiumMilitary_003.m3", 1192, 0, 5338, "Military Platform (Dominion)", DecorCategory.ToolsHardware, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\BossIndicator\\PRP_Walls_Generic_BossIndicator_Hexagon_000.m3", 1192, 0, 5339, "Force Field (Single Guide)", DecorCategory.ParticleEffects, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\BossIndicator\\PRP_Walls_Generic_BossIndicator_Hexagon_001.m3", 1192, 0, 5340, "Force Field (Double Guides)", DecorCategory.ParticleEffects, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Walls\\Generic\\PRP_Brace_RetainingWallScrew_001.m3", 1192, 0, 5341, "Dowel Pin and Ring (Metal)", DecorCategory.ToolsHardware, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Barrel_000.m3", 1192, 0, 5342, "Bamboo Barrel (Beige)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Cut_000.m3", 1192, 0, 5343, "Bamboo Half (Beige)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Large_000.m3", 1192, 0, 5344, "Bamboo Tube (Beige, Long)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Large_001.m3", 1192, 0, 5345, "Bamboo Tube (Beige, Medium)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Large_002.m3", 1192, 0, 5346, "Bamboo Tube (Beige, Short)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Med_000.m3", 1192, 0, 5347, "Bamboo Pipe (Beige, Long)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Med_001.m3", 1192, 0, 5348, "Bamboo Pipe (Beige, Medium)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Med_002.m3", 1192, 0, 5349, "Bamboo Pipe (Beige, Short)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_All_000.m3", 1192, 0, 5350, "Bamboo Riveted (Beige, Composite)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_000.m3", 1192, 0, 5351, "Bamboo Riveted (Beige, Bent)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_001.m3", 1192, 0, 5352, "Bamboo Riveted (Beige, Bent, Stocky)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_002.m3", 1192, 0, 5353, "Bamboo Riveted (Beige, Zig-Zag)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_003.m3", 1192, 0, 5354, "Bamboo Curved (Beige)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Curved_004.m3", 1192, 0, 5355, "Bamboo Curved (Beige, Stocky)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Pipe_Straight_000.m3", 1192, 0, 5356, "Bamboo Riveted (Beige, Straight)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Plank_000.m3", 1192, 0, 5357, "Bamboo Deck (Beige)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Thin_000.m3", 1192, 0, 5358, "Bamboo Rod (Beige, Long)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Thin_001.m3", 1192, 0, 5359, "Bamboo Rod (Beige, Medium)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Beige_Thin_002.m3", 1192, 0, 5360, "Bamboo Rod (Beige, Short)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Barrel_000.m3", 1192, 0, 5361, "Bamboo Barrel (Purple)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Cut_000.m3", 1192, 0, 5362, "Bamboo Half (Purple)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Large_000.m3", 1192, 0, 5363, "Bamboo Tube (Purple, Long)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Large_001.m3", 1192, 0, 5364, "Bamboo Tube (Purple, Medium)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Large_002.m3", 1192, 0, 5365, "Bamboo Tube (Purple, Short)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Med_000.m3", 1192, 0, 5366, "Bamboo Pipe (Purple, Long)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Med_001.m3", 1192, 0, 5367, "Bamboo Pipe (Purple, Medium)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Med_002.m3", 1192, 0, 5368, "Bamboo Pipe (Purple, Short)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_All_000.m3", 1192, 0, 5369, "Bamboo Riveted (Purple, Composite)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_000.m3", 1192, 0, 5370, "Bamboo Riveted (Purple, Bent)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_001.m3", 1192, 0, 5371, "Bamboo Riveted (Purple, Bent, Stocky)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_002.m3", 1192, 0, 5372, "Bamboo Riveted (Purple, Zig-Zag)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_003.m3", 1192, 0, 5373, "Bamboo Cuved (Purple)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Curved_004.m3", 1192, 0, 5374, "Bamboo Curved (Purple, Stocky)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Pipe_Straight_000.m3", 1192, 0, 5375, "Bamboo Riveted (Purple, Straight)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Plank_000.m3", 1192, 0, 5376, "Bamboo Deck (Purple)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Thin_000.m3", 1192, 0, 5377, "Bamboo Rod (Purple, Long)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Thin_001.m3", 1192, 0, 5378, "Bamboo Rod (Purple, Medium)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Wooden_Beam\\Bamboo\\PRP_Bamboo_Stalks_Purple_Thin_002.m3", 1192, 0, 5379, "Bamboo Rod (Purple, Short)", DecorCategory.BuildingBlocks, false, 8);
            AddGenericDecor("Art\\Prop\\Constructed\\Light\\SanctuaryCommon\\PRP_Light_BarWallLamp_000_Bronze.m3", 2666, 0, 5719, "Glass Sconce (Orange, No Toggle)", DecorCategory.Lighting, false, 11);
            AddGenericDecor("Art\\Prop\\Constructed\\Light\\Aurin\\PRP_Light_AurinHangingLamp_001.m3", 2666, 0, 5720, "Hanging Lamp (Aurin, No Toggle)", DecorCategory.Lighting, false, 11);
            AddGenericDecor("Art\\Prop\\Constructed\\Light\\Aurin\\PRP_Light_Aurin_WallLamp_002.m3", 2666, 0, 5721, "Yellow Sconce (Aurin, No Toggle)", DecorCategory.Lighting, false, 11);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Candles\\PRP_GenericCandle_Yellow_006.m3", 2666, 0, 5722, "Candle (Short, No Toggle)", DecorCategory.Lighting, false, 11);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Candles\\PRP_GenericCandle_Yellow_007.m3", 2666, 0, 5723, "Candle (Tall, No Toggle)", DecorCategory.Lighting, false, 11);
            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Candles\\PRP_GenericCandle_Yellow_008.m3", 2666, 0, 5724, "Candle (Medium, No Toggle)", DecorCategory.Lighting, false, 11);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 1, "Torine Sister 1", "Torine Sister", null, 9740, 0, null, 0, 1.3f, null, null), 5380, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Sister (Style 1)", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 2, "Torine Sister 2", "Torine Sister", null, 9838, 0, null, 0, 1.3f, null, null), 5381, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Sister (Style 2)", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 3, "Torine Sister 3", "Torine Sister", null, 9839, 0, null, 0, 1.3f, null, null), 5382, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Sister (Style 3)", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 4, "Torine Sister 4", "Torine Sister", null, 10777, 0, null, 0, 1.3f, null, null), 5383, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Sister (Style 4)", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 5, "Torine Battlemaiden", "Torine Battlemaiden", null, 9838, 2351, null, 0, 1.3f, null, null), 5384, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Battlemaiden", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 6, "Torine Longclaw", "Torine Longclaw", null, 9838, 3361, null, 0, 1.3f, null, null), 5385, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Longclaw", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 7, "Torine Bladesister", "Torine Bladesister", null, 9740, 3, null, 0, 1.3f, null, null), 5386, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Bladesister", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 8, "Torine Sentinel", "Torine Sentinel", null, 9839, 3196, null, 0, 1.3f, null, null), 5387, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Sentinel", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 9, "Torine Lifecaller", "Torine Lifecaller", null, 10777, 144, null, 0, 1.5f, null, null), 5388, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Lifecaller", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 10, "Torine Raincaller", "Torine Raincaller", null, 9838, 144, null, 0, 1.3f, null, null), 5389, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Raincaller", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 11, "Torine Liferender", "Torine Liferender", null, 9839, 3486, null, 0, 1.5f, null, null), 5390, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Liferender", 10);
            AddNPCDecor(2606, AddCreature(73085, startCreature2ID + 12, "Torine Deathbringer", "Torine Deathbringer", null, 9839, 2351, null, 0, 1.5f, null, null), 5391, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Deathbringer", 10);
            AddNPCDecor(2606, AddCreature(69429, startCreature2ID + 13, "Torine Fastpaw", "Torine Fastpaw", null, null, null, null, 0, 1.1f, null, null), 5392, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Fastpaw", 10);
            AddNPCDecor(2606, AddCreature(69429, startCreature2ID + 14, "Torine Keenclaw", "Torine Keenclaw", null, null, null, null, 0, 1.5f, null, null), 5393, "Art\\Prop\\Constructed\\Banner\\Torine\\PRP_Banner_Torine_000.m3", "Torine Keenclaw", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 15, "Highborn Cassian Male 1", "Cassian Noble", 28323, 10106, 0, 0, 0, 1f, null, null), 5394, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 16, "Highborn Cassian Male 2", "Cassian Noble", 38818, 9695, 0, 0, 0, 1f, null, null), 5395, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 17, "Highborn Cassian Male 3", "Cassian Noble", 34859, 10105, 0, 0, 0, 1f, null, null), 5396, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Male, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 18, "Highborn Cassian Male 4", "Cassian Noble", 25049, 9695, 0, 0, 0, 1f, null, null), 5397, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Male, Style 4)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 19, "Highborn Cassian Male 5", "Cassian Noble", 36287, 9704, 0, 0, 0, 1f, null, null), 5398, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Male, Style 5)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 20, "Highborn Cassian Male 6", "Cassian Noble", 30880, 9694, 0, 0, 0, 1f, null, null), 5399, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Male, Style 6)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 21, "Highborn Cassian Male 7", "Cassian Noble", 30172, 8229, 0, 0, 0, 1f, null, null), 5400, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Male, Style 7)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 22, "Lowborn Cassian Male 1", "Cassian Commoner", 28300, 10250, 0, 0, 0, 1f, null, null), 5401, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 23, "Lowborn Cassian Male 2", "Cassian Commoner", 25809, 10110, 0, 0, 0, 1f, null, null), 5402, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 24, "Lowborn Cassian Male 3", "Cassian Commoner", 28260, 8755, 0, 0, 0, 1f, null, null), 5403, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Male, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 25, "Lowborn Cassian Male 4", "Cassian Commoner", 30597, 10533, 0, 0, 0, 1f, null, null), 5404, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Male, Style 4)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 26, "Lowborn Cassian Male 5", "Cassian Commoner", 30897, 8757, 0, 0, 0, 1f, null, null), 5405, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Male, Style 5)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 27, "Lowborn Cassian Male 6", "Cassian Commoner", 25653, 8754, 0, 0, 0, 1f, null, null), 5406, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Male, Style 6)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 28, "Lowborn Cassian Male 7", "Cassian Commoner", 28341, 9459, 0, 0, 0, 1f, null, null), 5407, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Male, Style 7)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 29, "Exiled Human Male 1", "Human Civilian", 28308, 8754, 0, 0, 0, 1f, null, null), 5408, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 30, "Exiled Human Male 2", "Human Civilian", 28349, 10250, 0, 0, 0, 1f, null, null), 5409, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 31, "Exiled Human Male 3", "Human Civilian", 29477, 8755, 0, 0, 0, 1f, null, null), 5410, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Male, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 32, "Exiled Human Male 4", "Human Civilian", 28033, 9931, 0, 0, 0, 1f, null, null), 5411, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Male, Style 4)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 33, "Exiled Human Male 5", "Human Civilian", 27346, 8211, 0, 0, 0, 1f, null, null), 5412, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Male, Style 5)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 34, "Exiled Human Male 6", "Human Civilian", 32799, 8757, 0, 0, 0, 1f, null, null), 5413, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Male, Style 6)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 35, "Exiled Human Male 7", "Human Civilian", 24796, 8758, 0, 0, 0, 1f, null, null), 5414, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Male, Style 7)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 36, "Highborn Cassian Female 1", "Cassian Noble", 30666, 8229, 0, 0, 0, 1f, null, null), 5415, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 37, "Highborn Cassian Female 2", "Cassian Noble", 30240, 9694, 0, 0, 0, 1f, null, null), 5416, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 38, "Highborn Cassian Female 3", "Cassian Noble", 34860, 10106, 0, 0, 0, 1f, null, null), 5417, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Female, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 39, "Highborn Cassian Female 4", "Cassian Noble", 29475, 9704, 0, 0, 0, 1f, null, null), 5418, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Female, Style 4)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 40, "Highborn Cassian Female 5", "Cassian Noble", 41300, 9695, 0, 0, 0, 1f, null, null), 5419, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Female, Style 5)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 41, "Highborn Cassian Female 6", "Cassian Noble", 28324, 10105, 0, 0, 0, 1f, null, null), 5420, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Female, Style 6)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 42, "Highborn Cassian Female 7", "Cassian Noble", 30599, 8496, 0, 0, 0, 1f, null, null), 5421, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian (Female, Style 7)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 43, "Lowborn Cassian Female 1", "Cassian Commoner", 34858, 10250, 0, 0, 0, 1f, null, null), 5422, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 44, "Lowborn Cassian Female 2", "Cassian Commoner", 28301, 10533, 0, 0, 0, 1f, null, null), 5423, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 45, "Lowborn Cassian Female 3", "Cassian Commoner", 30748, 9869, 0, 0, 0, 1f, null, null), 5424, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Female, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 46, "Lowborn Cassian Female 4", "Cassian Commoner", 31426, 8757, 0, 0, 0, 1f, null, null), 5425, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Female, Style 4)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 47, "Lowborn Cassian Female 5", "Cassian Commoner", 25336, 8754, 0, 0, 0, 1f, null, null), 5426, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Female, Style 5)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 48, "Lowborn Cassian Female 6", "Cassian Commoner", 34862, 9459, 0, 0, 0, 1f, null, null), 5427, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Female, Style 6)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 49, "Lowborn Cassian Female 7", "Cassian Commoner", 34870, 8416, 0, 0, 0, 1f, null, null), 5428, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian (Female, Style 7)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 50, "Exiled Human Female 1", "Human Civilian", 28309, 8758, 0, 0, 0, 1f, null, null), 5429, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 51, "Exiled Human Female 2", "Human Civilian", 30112, 10250, 0, 0, 0, 1f, null, null), 5430, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 52, "Exiled Human Female 3", "Human Civilian", 25887, 8416, 0, 0, 0, 1f, null, null), 5431, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Female, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 53, "Exiled Human Female 4", "Human Civilian", 30194, 8755, 0, 0, 0, 1f, null, null), 5432, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Female, Style 4)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 54, "Exiled Human Female 5", "Human Civilian", 30178, 9869, 0, 0, 0, 1f, null, null), 5433, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Female, Style 5)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 55, "Exiled Human Female 6", "Human Civilian", 27562, 8211, 0, 0, 0, 1f, null, null), 5434, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Female, Style 6)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 56, "Exiled Human Female 7", "Human Civilian", 25051, 8416, 0, 0, 0, 1f, null, null), 5435, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human (Female, Style 7)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 57, "Human Male Tradesman 1", "Tradesman", 28308, 9726, 0, 0, 0, 1f, null, null), 5436, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Tradesman (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 58, "Human Male Tradesman 2", "Tradesman", 28349, 9726, 0, 0, 0, 1f, null, null), 5437, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Tradesman (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 59, "Human Male Tradesman 3", "Tradesman", 29477, 9726, 0, 0, 0, 1f, null, null), 5438, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Tradesman (Male, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 60, "Cassian Male Tradesman 1", "Tradesman", 30897, 10505, 0, 0, 0, 1f, null, null), 5439, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Tradesman (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 61, "Cassian Male Tradesman 2", "Tradesman", 25653, 10505, 0, 0, 0, 1f, null, null), 5440, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Tradesman (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 62, "Cassian Male Tradesman 3", "Tradesman", 28341, 10505, 0, 0, 0, 1f, null, null), 5441, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Tradesman (Male, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 63, "Human Female Tradesman 1", "Tradesman", 28309, 9726, 0, 0, 0, 1f, null, null), 5442, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Tradesman (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 64, "Human Female Tradesman 2", "Tradesman", 30112, 9726, 0, 0, 0, 1f, null, null), 5443, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Tradesman (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 65, "Human Female Tradesman 3", "Tradesman", 25887, 9726, 0, 0, 0, 1f, null, null), 5444, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Tradesman (Female, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 66, "Cassian Female Tradesman 1", "Tradesman", 25336, 10505, 0, 0, 0, 1f, null, null), 5445, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Tradesman (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 67, "Cassian Female Tradesman 2", "Tradesman", 34862, 10505, 0, 0, 0, 1f, null, null), 5446, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Tradesman (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 68, "Cassian Female Tradesman 3", "Tradesman", 34870, 10505, 0, 0, 0, 1f, null, null), 5447, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Tradesman (Female, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 69, "Human Male Mechanic 1", "Mechanic", 27346, 9735, 39, 0, 0, 1f, null, null), 5448, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Mechanic (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 70, "Human Male Mechanic 2", "Mechanic", 32799, 9735, 39, 0, 0, 1f, null, null), 5449, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Mechanic (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 71, "Human Male Mechanic 3", "Mechanic", 24796, 9735, 39, 0, 0, 1f, null, null), 5450, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Mechanic (Male, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 72, "Human Female Mechanic 1", "Mechanic", 30178, 9735, 39, 0, 0, 1f, null, null), 5451, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Mechanic (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 73, "Human Female Mechanic 2", "Mechanic", 27562, 9735, 39, 0, 0, 1f, null, null), 5452, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Mechanic (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 74, "Human Female Mechanic 3", "Mechanic", 25051, 9735, 39, 0, 0, 1f, null, null), 5453, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Mechanic (Female, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 75, "Cassian Female Mechanic 1", "Mechanic", 34858, 9857, 39, 0, 0, 1f, null, null), 5454, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Mechanic (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 76, "Cassian Female Mechanic 2", "Mechanic", 28301, 9857, 39, 0, 0, 1f, null, null), 5455, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Mechanic (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 77, "Cassian Female Mechanic 3", "Mechanic", 30748, 9857, 39, 0, 0, 1f, null, null), 5456, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Mechanic (Female, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 78, "Cassian Male Mechanic 1", "Mechanic", 30897, 9857, 39, 0, 0, 1f, null, null), 5457, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Mechanic (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 79, "Cassian Male Mechanic 2", "Mechanic", 25653, 9857, 39, 0, 0, 1f, null, null), 5458, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Mechanic (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 80, "Cassian Male Mechanic 3", "Mechanic", 28341, 9857, 39, 0, 0, 1f, null, null), 5459, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Mechanic (Male, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 81, "Cassian Male Server 1", "Serving Staffer", 34859, 8466, 0, 0, 0, 1f, null, null), 5460, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Server (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 82, "Cassian Male Server 2", "Serving Staffer", 25049, 8466, 0, 0, 0, 1f, null, null), 5461, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Server (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 83, "Cassian Male Server 3", "Serving Staffer", 36287, 8466, 0, 0, 0, 1f, null, null), 5462, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Server (Male, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 84, "Cassian Female Server 1", "Serving Staffer", 34860, 8466, 0, 0, 0, 1f, null, null), 5463, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Server (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 85, "Cassian Female Server 2", "Serving Staffer", 29475, 8466, 0, 0, 0, 1f, null, null), 5464, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Server (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 86, "Cassian Female Server 3", "Serving Staffer", 41300, 8466, 0, 0, 0, 1f, null, null), 5465, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Server (Female, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 87, "Human Male Server 1", "Serving Staffer", 29477, 8379, 0, 0, 0, 1f, null, null), 5466, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Server (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 88, "Human Male Server 2", "Serving Staffer", 28033, 8379, 0, 0, 0, 1f, null, null), 5467, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Server (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 89, "Human Male Server 3", "Serving Staffer", 27346, 8379, 0, 0, 0, 1f, null, null), 5468, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Server (Male, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 90, "Human Female Server 1", "Serving Staffer", 25887, 8379, 0, 0, 0, 1f, null, null), 5469, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Server (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 91, "Human Female Server 2", "Serving Staffer", 30194, 8379, 0, 0, 0, 1f, null, null), 5470, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Server (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 92, "Human Female Server 3", "Serving Staffer", 30178, 8379, 0, 0, 0, 1f, null, null), 5471, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Server (Female, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 93, "Cassian Male Security Guard 1", "Security Guard", 28260, 8471, 149, 0, 0, 1f, null, null), 5472, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Security Guard (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 94, "Cassian Male Security Guard 2", "Security Guard", 30597, 8471, 149, 0, 0, 1f, null, null), 5473, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Security Guard (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 95, "Cassian Male Security Guard 3", "Security Guard", 30897, 8471, 149, 0, 0, 1f, null, null), 5474, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Security Guard (Male, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 96, "Cassian Female Security Guard 1", "Security Guard", 30748, 8471, 149, 0, 0, 1f, null, null), 5475, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Security Guard (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 97, "Cassian Female Security Guard 2", "Security Guard", 31426, 8471, 149, 0, 0, 1f, null, null), 5476, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Security Guard (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 98, "Cassian Female Security Guard 3", "Security Guard", 25336, 8471, 149, 0, 0, 1f, null, null), 5477, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Cassian Security Guard (Female, Style 3)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 99, "Human Male Security Guard 1", "Security Guard", 29477, 8659, 594, 0, 0, 1f, null, null), 5478, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Security Guard (Male, Style 1)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 100, "Human Male Security Guard 2", "Security Guard", 28033, 8659, 594, 0, 0, 1f, null, null), 5479, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Security Guard (Male, Style 2)", 10);
            AddNPCDecor(3548, AddCreature(75669, startCreature2ID + 101, "Human Male Security Guard 3", "Security Guard", 27346, 8659, 594, 0, 0, 1f, null, null), 5480, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Security Guard (Male, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 102, "Human Female Security Guard 1", "Security Guard", 25887, 8659, 594, 0, 0, 1f, null, null), 5481, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Security Guard (Female, Style 1)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 103, "Human Female Security Guard 2", "Security Guard", 30194, 8659, 594, 0, 0, 1f, null, null), 5482, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Security Guard (Female, Style 2)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 104, "Human Female Security Guard 3", "Security Guard", 30178, 8659, 594, 0, 0, 1f, null, null), 5483, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Human Security Guard (Female, Style 3)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 105, "Cassian Male Crimson Rifleman", "Crimson Rifleman", 39040, 10473, 149, 0, 0, 1f, null, null), 5484, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Rifleman (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 106, "Cassian Female Crimson Rifleman", "Crimson Rifleman", 41300, 10473, 149, 0, 0, 1f, null, null), 5485, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Rifleman (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 107, "Chua Crimson Rifleman", "Crimson Rifleman", 39047, 10473, 149, 0, 0, 1f, null, null), 5486, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Rifleman (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 108, "Draken Male Crimson Rifleman", "Crimson Rifleman", 39029, 10473, 149, 0, 0, 1f, null, null), 5487, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Rifleman (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 109, "Draken Female Crimson Rifleman", "Crimson Rifleman", 39025, 10473, 149, 0, 0, 1f, null, null), 5488, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Rifleman (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 110, "Mechari Male Crimson Rifleman", "Crimson Rifleman", 39049, 10473, 149, 0, 0, 1f, null, null), 5489, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Rifleman (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 111, "Mechari Female Crimson Rifleman", "Crimson Rifleman", 39050, 10473, 149, 0, 0, 1f, null, null), 5490, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Rifleman (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 112, "Cassian Male Crimson Blademaster", "Crimson Blademaster", 39040, 10473, 3209, 0, 0, 1f, null, null), 5491, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Blademaster (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 113, "Cassian Female Crimson Blademaster", "Crimson Blademaster", 39043, 10473, 3209, 0, 0, 1f, null, null), 5492, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Blademaster (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 114, "Chua Crimson Blademaster", "Crimson Blademaster", 26862, 10473, 3209, 0, 0, 1f, null, null), 5493, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Blademaster (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 115, "Draken Male Crimson Blademaster", "Crimson Blademaster", 39046, 10473, 3209, 0, 0, 1f, null, null), 5494, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Blademaster (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 116, "Draken Female Crimson Blademaster", "Crimson Blademaster", 39048, 10473, 3209, 0, 0, 1f, null, null), 5495, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Blademaster (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 117, "Mechari Male Crimson Blademaster", "Crimson Blademaster", 39049, 10473, 3209, 0, 0, 1f, null, null), 5496, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Blademaster (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 118, "Mechari Female Crimson Blademaster", "Crimson Blademaster", 39050, 10473, 3209, 0, 0, 1f, null, null), 5497, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Blademaster (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 119, "Cassian Male Crimson Infiltrator", "Crimson Infiltrator", 39040, 10473, 3599, 0, 0, 1f, null, null), 5498, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Infiltrator (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 120, "Cassian Female Crimson Infiltrator", "Crimson Infiltrator", 39043, 10473, 3599, 0, 0, 1f, null, null), 5499, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Infiltrator (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 121, "Chua Crimson Infiltrator", "Crimson Infiltrator", 29415, 10473, 3599, 0, 0, 1f, null, null), 5500, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Infiltrator (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 122, "Draken Male Crimson Infiltrator", "Crimson Infiltrator", 28270, 10473, 3599, 0, 0, 1f, null, null), 5501, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Infiltrator (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 123, "Draken Female Crimson Infiltrator", "Crimson Infiltrator", 25335, 10473, 3599, 0, 0, 1f, null, null), 5502, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Infiltrator (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 124, "Mechari Male Crimson Infiltrator", "Crimson Infiltrator", 39049, 10473, 3599, 0, 0, 1f, null, null), 5503, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Infiltrator (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 125, "Mechari Female Crimson Infiltrator", "Crimson Infiltrator", 39050, 10473, 3599, 0, 0, 1f, null, null), 5504, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Infiltrator (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 126, "Cassian Male Crimson Heavy", "Crimson Heavy", 39040, 10473, 3686, 0, 0, 1f, null, null), 5505, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Heavy (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 127, "Cassian Female Crimson Heavy", "Crimson Heavy", 41300, 10473, 3686, 0, 0, 1f, null, null), 5506, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Heavy (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 128, "Chua Crimson Heavy", "Crimson Heavy", 39625, 10473, 3686, 0, 0, 1f, null, null), 5507, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Heavy (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 129, "Draken Male Crimson Heavy", "Crimson Heavy", 28325, 10473, 3686, 0, 0, 1f, null, null), 5508, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Heavy (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 130, "Draken Female Crimson Heavy", "Crimson Heavy", 39027, 10473, 3686, 0, 0, 1f, null, null), 5509, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Heavy (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 131, "Mechari Male Crimson Heavy", "Crimson Heavy", 39049, 10473, 3686, 0, 0, 1f, null, null), 5510, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Heavy (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 132, "Mechari Female Crimson Heavy", "Crimson Heavy", 39050, 10473, 3686, 0, 0, 1f, null, null), 5511, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Heavy (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 133, "Cassian Male Crimson Specialist", "Crimson Specialist", 39040, 10473, 3289, 0, 0, 1f, null, null), 5512, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Specialist (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 134, "Cassian Female Crimson Specialist", "Crimson Specialist", 39043, 10473, 3289, 0, 0, 1f, null, null), 5513, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Specialist (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 135, "Chua Crimson Specialist", "Crimson Specialist", 41225, 10473, 3289, 0, 0, 1f, null, null), 5514, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Specialist (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 136, "Mechari Male Crimson Specialist", "Crimson Specialist", 39049, 10473, 3289, 0, 0, 1f, null, null), 5515, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Specialist (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 137, "Mechari Female Crimson Specialist", "Crimson Specialist", 39050, 10473, 3289, 0, 0, 1f, null, null), 5516, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Crimson Specialist (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 138, "Cassian Male Radiant Rifleman", "Radiant Rifleman", 39040, 9711, 149, 0, 0, 1f, null, null), 5517, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Rifleman (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 139, "Cassian Female Radiant Rifleman", "Radiant Rifleman", 34858, 9711, 149, 0, 0, 1f, null, null), 5518, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Rifleman (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 140, "Chua Radiant Rifleman", "Radiant Rifleman", 39047, 9711, 149, 0, 0, 1f, null, null), 5519, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Rifleman (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 141, "Draken Male Radiant Rifleman", "Radiant Rifleman", 39029, 9711, 149, 0, 0, 1f, null, null), 5520, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Rifleman (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 142, "Draken Female Radiant Rifleman", "Radiant Rifleman", 39025, 9711, 149, 0, 0, 1f, null, null), 5521, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Rifleman (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 143, "Mechari Male Radiant Rifleman", "Radiant Rifleman", 39049, 9711, 149, 0, 0, 1f, null, null), 5522, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Rifleman (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 144, "Mechari Female Radiant Rifleman", "Radiant Rifleman", 39050, 9711, 149, 0, 0, 1f, null, null), 5523, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Rifleman (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 145, "Cassian Male Radiant Blademaster", "Radiant Blademaster", 39040, 9711, 3209, 0, 0, 1f, null, null), 5524, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Blademaster (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 146, "Cassian Female Radiant Blademaster", "Radiant Blademaster", 39043, 9711, 3209, 0, 0, 1f, null, null), 5525, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Blademaster (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 147, "Chua Radiant Blademaster", "Radiant Blademaster", 26862, 9711, 3209, 0, 0, 1f, null, null), 5526, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Blademaster (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 148, "Draken Male Radiant Blademaster", "Radiant Blademaster", 39046, 9711, 3209, 0, 0, 1f, null, null), 5527, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Blademaster (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 149, "Draken Female Radiant Blademaster", "Radiant Blademaster", 39048, 9711, 3209, 0, 0, 1f, null, null), 5528, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Blademaster (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 150, "Mechari Male Radiant Blademaster", "Radiant Blademaster", 39049, 9711, 3209, 0, 0, 1f, null, null), 5529, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Blademaster (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 151, "Mechari Female Radiant Blademaster", "Radiant Blademaster", 39050, 9711, 3209, 0, 0, 1f, null, null), 5530, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Blademaster (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 152, "Cassian Male Radiant Infiltrator", "Radiant Infiltrator", 39040, 9711, 3599, 0, 0, 1f, null, null), 5531, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Infiltrator (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 153, "Cassian Female Radiant Infiltrator", "Radiant Infiltrator", 39043, 9711, 3599, 0, 0, 1f, null, null), 5532, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Infiltrator (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 154, "Chua Radiant Infiltrator", "Radiant Infiltrator", 29415, 9711, 3599, 0, 0, 1f, null, null), 5533, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Infiltrator (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 155, "Draken Male Radiant Infiltrator", "Radiant Infiltrator", 28270, 9711, 3599, 0, 0, 1f, null, null), 5534, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Infiltrator (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 156, "Draken Female Radiant Infiltrator", "Radiant Infiltrator", 25335, 9711, 3599, 0, 0, 1f, null, null), 5535, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Infiltrator (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 157, "Mechari Male Radiant Infiltrator", "Radiant Infiltrator", 39049, 9711, 3599, 0, 0, 1f, null, null), 5536, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Infiltrator (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 158, "Mechari Female Radiant Infiltrator", "Radiant Infiltrator", 39050, 9711, 3599, 0, 0, 1f, null, null), 5537, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Infiltrator (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 159, "Cassian Male Radiant Heavy", "Radiant Heavy", 39040, 9711, 3686, 0, 0, 1f, null, null), 5538, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Heavy (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 160, "Cassian Female Radiant Heavy", "Radiant Heavy", 41300, 9711, 3686, 0, 0, 1f, null, null), 5539, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Heavy (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 161, "Chua Radiant Heavy", "Radiant Heavy", 39625, 9711, 3686, 0, 0, 1f, null, null), 5540, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Heavy (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 162, "Draken Male Radiant Heavy", "Radiant Heavy", 28325, 9711, 3686, 0, 0, 1f, null, null), 5541, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Heavy (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 163, "Draken Female Radiant Heavy", "Radiant Heavy", 39027, 9711, 3686, 0, 0, 1f, null, null), 5542, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Heavy (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 164, "Mechari Male Radiant Heavy", "Radiant Heavy", 39049, 9711, 3686, 0, 0, 1f, null, null), 5543, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Heavy (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 165, "Mechari Female Radiant Heavy", "Radiant Heavy", 39050, 9711, 3686, 0, 0, 1f, null, null), 5544, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Heavy (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 166, "Cassian Male Radiant Specialist", "Radiant Specialist", 39040, 9711, 3289, 0, 0, 1f, null, null), 5545, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Specialist (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 167, "Cassian Female Radiant Specialist", "Radiant Specialist", 39043, 9711, 3289, 0, 0, 1f, null, null), 5546, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Specialist (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 168, "Chua Radiant Specialist", "Radiant Specialist", 41225, 9711, 3289, 0, 0, 1f, null, null), 5547, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Specialist (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 169, "Mechari Male Radiant Specialist", "Radiant Specialist", 39049, 9711, 3289, 0, 0, 1f, null, null), 5548, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Specialist (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 170, "Mechari Female Radiant Specialist", "Radiant Specialist", 39050, 9711, 3289, 0, 0, 1f, null, null), 5549, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Radiant Specialist (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 171, "Cassian Male Gold Rifleman", "Gold Rifleman", 39040, 10474, 149, 0, 0, 1f, null, null), 5550, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Rifleman (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 172, "Cassian Female Gold Rifleman", "Gold Rifleman", 34858, 10474, 149, 0, 0, 1f, null, null), 5551, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Rifleman (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 173, "Chua Gold Rifleman", "Gold Rifleman", 39047, 10474, 149, 0, 0, 1f, null, null), 5552, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Rifleman (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 174, "Draken Male Gold Rifleman", "Gold Rifleman", 39029, 10474, 149, 0, 0, 1f, null, null), 5553, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Rifleman (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 175, "Draken Female Gold Rifleman", "Gold Rifleman", 39025, 10474, 149, 0, 0, 1f, null, null), 5554, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Rifleman (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 176, "Mechari Male Gold Rifleman", "Gold Rifleman", 39049, 10474, 149, 0, 0, 1f, null, null), 5555, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Rifleman (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 177, "Mechari Female Gold Rifleman", "Gold Rifleman", 39050, 10474, 149, 0, 0, 1f, null, null), 5556, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Rifleman (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 178, "Cassian Male Gold Blademaster", "Gold Blademaster", 39040, 10474, 3209, 0, 0, 1f, null, null), 5557, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Blademaster (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 179, "Cassian Female Gold Blademaster", "Gold Blademaster", 39043, 10474, 3209, 0, 0, 1f, null, null), 5558, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Blademaster (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 180, "Chua Gold Blademaster", "Gold Blademaster", 26862, 10474, 3209, 0, 0, 1f, null, null), 5559, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Blademaster (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 181, "Draken Male Gold Blademaster", "Gold Blademaster", 39046, 10474, 3209, 0, 0, 1f, null, null), 5560, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Blademaster (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 182, "Draken Female Gold Blademaster", "Gold Blademaster", 39048, 10474, 3209, 0, 0, 1f, null, null), 5561, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Blademaster (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 183, "Mechari Male Gold Blademaster", "Gold Blademaster", 39049, 10474, 3209, 0, 0, 1f, null, null), 5562, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Blademaster (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 184, "Mechari Female Gold Blademaster", "Gold Blademaster", 39050, 10474, 3209, 0, 0, 1f, null, null), 5563, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Blademaster (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 185, "Cassian Male Gold Infiltrator", "Gold Infiltrator", 39040, 10474, 3599, 0, 0, 1f, null, null), 5564, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Infiltrator (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 186, "Cassian Female Gold Infiltrator", "Gold Infiltrator", 39043, 10474, 3599, 0, 0, 1f, null, null), 5565, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Infiltrator (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 187, "Chua Gold Infiltrator", "Gold Infiltrator", 29415, 10474, 3599, 0, 0, 1f, null, null), 5566, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Infiltrator (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 188, "Draken Male Gold Infiltrator", "Gold Infiltrator", 28270, 10474, 3599, 0, 0, 1f, null, null), 5567, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Infiltrator (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 189, "Draken Female Gold Infiltrator", "Gold Infiltrator", 25335, 10474, 3599, 0, 0, 1f, null, null), 5568, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Infiltrator (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 190, "Mechari Male Gold Infiltrator", "Gold Infiltrator", 39049, 10474, 3599, 0, 0, 1f, null, null), 5569, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Infiltrator (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 191, "Mechari Female Gold Infiltrator", "Gold Infiltrator", 39050, 10474, 3599, 0, 0, 1f, null, null), 5570, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Infiltrator (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 192, "Cassian Male Gold Heavy", "Gold Heavy", 39040, 10474, 3686, 0, 0, 1f, null, null), 5571, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Heavy (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 193, "Cassian Female Gold Heavy", "Gold Heavy", 41300, 10474, 3686, 0, 0, 1f, null, null), 5572, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Heavy (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 194, "Chua Gold Heavy", "Gold Heavy", 39625, 10474, 3686, 0, 0, 1f, null, null), 5573, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Heavy (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 195, "Draken Male Gold Heavy", "Gold Heavy", 28325, 10474, 3686, 0, 0, 1f, null, null), 5574, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Heavy (Draken, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 196, "Draken Female Gold Heavy", "Gold Heavy", 39027, 10474, 3686, 0, 0, 1f, null, null), 5575, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Heavy (Draken, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 197, "Mechari Male Gold Heavy", "Gold Heavy", 39049, 10474, 3686, 0, 0, 1f, null, null), 5576, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Heavy (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 198, "Mechari Female Gold Heavy", "Gold Heavy", 39050, 10474, 3686, 0, 0, 1f, null, null), 5577, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Heavy (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 199, "Cassian Male Gold Specialist", "Gold Specialist", 39040, 10474, 3289, 0, 0, 1f, null, null), 5578, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Specialist (Cassian, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 200, "Cassian Female Gold Specialist", "Gold Specialist", 39043, 10474, 3289, 0, 0, 1f, null, null), 5579, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Specialist (Cassian, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 201, "Chua Gold Specialist", "Gold Specialist", 41225, 10474, 3289, 0, 0, 1f, null, null), 5580, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Specialist (Chua)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 202, "Mechari Male Gold Specialist", "Gold Specialist", 39049, 10474, 3289, 0, 0, 1f, null, null), 5581, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Specialist (Mechari, Male)", 10);
            AddNPCDecor(3549, AddCreature(75670, startCreature2ID + 203, "Mechari Female Gold Specialist", "Gold Specialist", 39050, 10474, 3289, 0, 0, 1f, null, null), 5582, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Gold Specialist (Mechari, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 204, "Aurin Male FCON Trooper", "FCON Trooper", 39036, 9673, 594, 0, 0, 1f, null, null), 5583, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Trooper (Aurin, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 205, "Aurin Female FCON Trooper", "FCON Trooper", 39037, 9673, 594, 0, 0, 1f, null, null), 5584, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Trooper (Aurin, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 206, "Human Male FCON Trooper", "FCON Trooper", 39039, 9673, 594, 0, 0, 1f, null, null), 5585, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Trooper (Human, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 207, "Human Female FCON Trooper", "FCON Trooper", 39038, 9673, 594, 0, 0, 1f, null, null), 5586, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Trooper (Human, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 208, "Granok Male FCON Trooper", "FCON Trooper", 39045, 9673, 594, 0, 0, 1f, null, null), 5587, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Trooper (Granok, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 209, "Granok Female FCON Trooper", "FCON Trooper", 39041, 9673, 594, 0, 0, 1f, null, null), 5588, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Trooper (Granok, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 210, "Mordesh Male FCON Trooper", "FCON Trooper", 39042, 9673, 594, 0, 0, 1f, null, null), 5589, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Trooper (Mordesh, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 211, "Mordesh Female FCON Trooper", "FCON Trooper", 39044, 9673, 594, 0, 0, 1f, null, null), 5590, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Trooper (Mordesh, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 212, "Human Male FCON Destroyer", "FCON Destroyer", 41217, 9673, 3495, 0, 0, 1f, null, null), 5591, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Destroyer (Human, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 213, "Human Female FCON Destroyer", "FCON Destroyer", 41218, 9673, 3495, 0, 0, 1f, null, null), 5592, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Destroyer (Human, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 214, "Granok Male FCON Destroyer", "FCON Destroyer", 41219, 9673, 3495, 0, 0, 1f, null, null), 5593, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Destroyer (Granok, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 215, "Granok Female FCON Destroyer", "FCON Destroyer", 41222, 9673, 3495, 0, 0, 1f, null, null), 5594, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Destroyer (Granok, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 216, "Mordesh Male FCON Destroyer", "FCON Destroyer", 41223, 9673, 3495, 0, 0, 1f, null, null), 5595, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Destroyer (Mordesh, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 217, "Mordesh Female FCON Destroyer", "FCON Destroyer", 41224, 9673, 3495, 0, 0, 1f, null, null), 5596, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Destroyer (Mordesh, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 218, "Human Male FCON Harasser", "FCON Harasser", 39607, 9673, 3618, 0, 0, 1f, null, null), 5597, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Harasser (Human, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 219, "Human Female FCON Harasser", "FCON Harasser", 39610, 9673, 3618, 0, 0, 1f, null, null), 5598, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Harasser (Human, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 220, "Mordesh Male FCON Harasser", "FCON Harasser", 39614, 9673, 3618, 0, 0, 1f, null, null), 5599, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Harasser (Mordesh, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 221, "Mordesh Female FCON Harasser", "FCON Harasser", 39613, 9673, 3618, 0, 0, 1f, null, null), 5600, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Harasser (Mordesh, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 222, "Aurin Male FCON Harasser", "FCON Harasser", 39609, 9673, 3618, 0, 0, 1f, null, null), 5601, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Harasser (Aurin, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 223, "Aurin Female FCON Harasser", "FCON Harasser", 39611, 9673, 3618, 0, 0, 1f, null, null), 5602, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Harasser (Aurin, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 224, "Human Male FCON Shocktrooper", "FCON Shocktrooper", 41209, 9673, 3679, 0, 0, 1f, null, null), 5603, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Shocktrooper (Human, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 225, "Human Female FCON Shocktrooper", "FCON Shocktrooper", 41147, 9673, 3679, 0, 0, 1f, null, null), 5604, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Shocktrooper (Human, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 226, "Aurin Male FCON Shocktrooper", "FCON Shocktrooper", 41150, 9673, 3679, 0, 0, 1f, null, null), 5605, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Shocktrooper (Aurin, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 227, "Aurin Female FCON Shocktrooper", "FCON Shocktrooper", 41213, 9673, 3679, 0, 0, 1f, null, null), 5606, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Shocktrooper (Aurin, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 228, "Granok Male FCON Shocktrooper", "FCON Shocktrooper", 39608, 9673, 3679, 0, 0, 1f, null, null), 5607, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Shocktrooper (Granok, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 229, "Granok Female FCON Shocktrooper", "FCON Shocktrooper", 39612, 9673, 3679, 0, 0, 1f, null, null), 5608, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Shocktrooper (Granok, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 230, "Mordesh Male FCON Shocktrooper", "FCON Shocktrooper", 41152, 9673, 3679, 0, 0, 1f, null, null), 5609, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Shocktrooper (Mordesh, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 231, "Mordesh Female FCON Shocktrooper", "FCON Shocktrooper", 41153, 9673, 3679, 0, 0, 1f, null, null), 5610, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Shocktrooper (Mordesh, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 232, "Human Male FCON Medic", "FCON Medic", 41301, 9673, 3665, 0, 0, 1f, null, null), 5611, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Medic (Human, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 233, "Human Female FCON Medic", "FCON Medic", 41300, 9673, 3665, 0, 0, 1f, null, null), 5612, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Medic (Human, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 234, "Granok Male FCON Medic", "FCON Medic", 41219, 9673, 3665, 0, 0, 1f, null, null), 5613, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Medic (Granok, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 235, "Granok Female FCON Medic", "FCON Medic", 41303, 9673, 3665, 0, 0, 1f, null, null), 5614, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Medic (Granok, Female)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 236, "Mordesh Male FCON Medic", "FCON Medic", 32694, 9673, 3665, 0, 0, 1f, null, null), 5615, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Medic (Mordesh, Male)", 10);
            AddNPCDecor(3549, AddCreature(75669, startCreature2ID + 237, "Mordesh Female FCON Medic", "FCON Medic", 28292, 9673, 3665, 0, 0, 1f, null, null), 5616, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "FCON Medic (Mordesh, Female)", 10);
            AddNPCDecor(2666, AddCreature(69430, startCreature2ID + 238, "Chua-Enhanced Pumera", "Chua-Enhanced Pumera", null, null, null, 0, 0, 1f, null, null), 5617, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Chua-Enhanced", 10);
            AddNPCDecor(2666, AddCreature(69421, startCreature2ID + 239, "Frosted Pumera", "Frosted Pumera", null, null, null, 0, 0, 1f, null, null), 5618, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Frosted", 10);
            AddNPCDecor(2666, AddCreature(69424, startCreature2ID + 240, "Golden Pumera", "Golden Pumera", null, null, null, 0, 0, 1f, null, null), 5619, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Golden", 10);
            AddNPCDecor(2666, AddCreature(69417, startCreature2ID + 241, "Grey Pumera", "Grey Pumera", null, null, null, 0, 0, 1f, null, null), 5620, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Grey", 10);
            AddNPCDecor(2666, AddCreature(69423, startCreature2ID + 242, "Magenta Pumera", "Magenta Pumera", null, null, null, 0, 0, 1f, null, null), 5621, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Magenta", 10);
            AddNPCDecor(2666, AddCreature(69420, startCreature2ID + 243, "Maroon Pumera", "Maroon Pumera", null, null, null, 0, 0, 1f, null, null), 5622, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Maroon", 10);
            AddNPCDecor(2666, AddCreature(69427, startCreature2ID + 244, "Sabertooth Pumera", "Sabertooth Pumera", null, null, null, 0, 0, 1f, null, null), 5623, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Sabertooth", 10);
            AddNPCDecor(2666, AddCreature(69422, startCreature2ID + 245, "Sienna Pumera", "Sienna Pumera", null, null, null, 0, 0, 1f, null, null), 5624, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Sienna", 10);
            AddNPCDecor(2666, AddCreature(69418, startCreature2ID + 246, "Snowy Pumera", "Snowy Pumera", null, null, null, 0, 0, 1f, null, null), 5625, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Snowy", 10);
            AddNPCDecor(2666, AddCreature(69428, startCreature2ID + 247, "Snowstripe Pumera", "Snowstripe Pumera", null, null, null, 0, 0, 1f, null, null), 5626, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Snowstripe", 10);
            AddNPCDecor(2666, AddCreature(69426, startCreature2ID + 248, "Steely Pumera", "Steely Pumera", null, null, null, 0, 0, 1f, null, null), 5627, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Steely", 10);
            AddNPCDecor(2666, AddCreature(69419, startCreature2ID + 249, "Tawny Pumera", "Tawny Pumera", null, null, null, 0, 0, 1f, null, null), 5628, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Tawny", 10);
            AddNPCDecor(2666, AddCreature(69425, startCreature2ID + 250, "Whitevale Pumera", "Whitevale Pumera", null, null, null, 0, 0, 1f, null, null), 5629, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Pumera, Whitevale", 10);
            AddNPCDecor(2666, AddCreature(69407, startCreature2ID + 251, "Black Dagun", "Black Dagun", null, null, null, 0, 0, 1f, null, null), 5630, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dagun, Black", 10);
            AddNPCDecor(2666, AddCreature(69407, startCreature2ID + 252, "Grim Dagun", "Grim Dagun", 31444, null, null, 0, 0, 1f, null, null), 5631, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dagun, Grim", 10);
            AddNPCDecor(2666, AddCreature(69411, startCreature2ID + 253, "Purple Dagun", "Purple Dagun", null, null, null, 0, 0, 1f, null, null), 5632, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dagun, Purple", 10);
            AddNPCDecor(2666, AddCreature(69410, startCreature2ID + 254, "Silver Dagun", "Silver Dagun", null, null, null, 0, 0, 1f, null, null), 5633, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dagun, Silver", 10);
            AddNPCDecor(2666, AddCreature(69409, startCreature2ID + 255, "Spacefaring Dagun", "Spacefaring Dagun", null, null, null, 0, 0, 1f, null, null), 5634, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dagun, Spacefaring", 10);
            AddNPCDecor(2666, AddCreature(73296, startCreature2ID + 256, "White Dagun", "White Dagun", null, null, null, 0, 0, 1f, null, null), 5635, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dagun, White", 10);
            AddNPCDecor(2666, AddCreature(69449, startCreature2ID + 257, "Purple Ravenok", "Ravenok", null, null, null, 0, 0, 1f, null, null), 5636, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Ravenok, Purple", 10);
            AddNPCDecor(2666, AddCreature(69450, startCreature2ID + 258, "Steel Blue Ravenok", "Ravenok", null, null, null, 0, 0, 1f, null, null), 5637, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Ravenok, Steel Blue", 10);
            AddNPCDecor(2666, AddCreature(69453, startCreature2ID + 259, "Teal Ravenok", "Ravenok", null, null, null, 0, 0, 1f, null, null), 5638, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Ravenok, Teal", 10);
            AddNPCDecor(2666, AddCreature(69454, startCreature2ID + 260, "Golden Ravenok", "Ravenok", null, null, null, 0, 0, 1f, null, null), 5639, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Ravenok, Golden", 10);
            AddNPCDecor(2666, AddCreature(69456, startCreature2ID + 261, "Snowy Ravenok", "Ravenok", null, null, null, 0, 0, 1f, null, null), 5640, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Ravenok, Snowy", 10);
            AddNPCDecor(2666, AddCreature(69449, startCreature2ID + 262, "Purple Pollonok", "Pollonok", null, null, null, 0, 0, 0.2f, null, null), 5641, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Pollonok, Purple", 10);
            AddNPCDecor(2666, AddCreature(69450, startCreature2ID + 263, "Steel Blue Pollonok", "Pollonok", null, null, null, 0, 0, 0.2f, null, null), 5642, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Pollonok, Steel Blue", 10);
            AddNPCDecor(2666, AddCreature(69453, startCreature2ID + 264, "Teal Pollonok", "Pollonok", null, null, null, 0, 0, 0.2f, null, null), 5643, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Pollonok, Teal", 10);
            AddNPCDecor(2666, AddCreature(69454, startCreature2ID + 265, "Golden Pollonok", "Pollonok", null, null, null, 0, 0, 0.2f, null, null), 5644, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Pollonok, Golden", 10);
            AddNPCDecor(2666, AddCreature(69456, startCreature2ID + 266, "Snowy Pollonok", "Pollonok", null, null, null, 0, 0, 0.2f, null, null), 5645, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Pollonok, Snowy", 10);
            AddNPCDecor(2666, AddCreature(75981, startCreature2ID + 267, "Brown Roan Bull", "Roan Bull", 23914, null, null, 0, 0, 1f, null, null), 5646, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Roan Bull, Brown", 10);
            AddNPCDecor(2666, AddCreature(75981, startCreature2ID + 268, "Brown Roan Cow", "Roan Cow", 24049, null, null, 0, 0, 1f, null, null), 5647, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Roan Cow, Brown", 10);
            AddNPCDecor(2666, AddCreature(75981, startCreature2ID + 269, "Grey Roan Bull", "Roan Bull", 24075, null, null, 0, 0, 1f, null, null), 5648, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Roan Bull, Grey", 10);
            AddNPCDecor(2666, AddCreature(75977, startCreature2ID + 270, "White Rowsdower", "Rowsdower", null, null, null, 0, 0, 1f, null, null), 5649, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Rowsdower, White", 10);
            AddNPCDecor(2666, AddCreature(48437, startCreature2ID + 271, "Demonic Rowsdower", "Demonic Rowsdower", null, null, null, 0, 0, 1f, null, null), 5650, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Rowsdower, Demonic", 10);
            AddNPCDecor(2666, AddCreature(69475, startCreature2ID + 272, "Pink Rowsdower", "Rowsdower", null, null, null, 0, 0, 1f, null, null), 5651, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Rowsdower, Pink", 10);
            AddNPCDecor(2666, AddCreature(69412, startCreature2ID + 273, "Blue Jabbit", "Jabbit", null, null, null, 0, 0, 1f, null, null), 5652, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Jabbit, Blue", 10);
            AddNPCDecor(2666, AddCreature(69413, startCreature2ID + 274, "Brown Jabbit", "Jabbit", null, null, null, 0, 0, 1f, null, null), 5653, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Jabbit, Brown", 10);
            AddNPCDecor(2666, AddCreature(69414, startCreature2ID + 275, "Grey Jabbit", "Jabbit", null, null, null, 0, 0, 1f, null, null), 5654, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Jabbit, Grey", 10);
            AddNPCDecor(2666, AddCreature(27250, startCreature2ID + 276, "Slank", "Slank", null, null, null, 0, 0, 1f, null, null), 5655, "Art\\Prop\\Constructed\\Trough\\SanctuaryCommon\\PRP_Trough_SanctuaryCommonHay_Brown_000.m3", "Slank", 10);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 277, "Brown Pell 1", "Pell Villager", 25018, null, 0, 0, 0, 1f, null, null), 5656, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 278, "Brown Pell 2", "Pell Villager", 23908, null, 0, 0, 0, 1f, null, null), 5657, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 279, "Brown Pell 3", "Pell Villager", 25019, null, 0, 0, 0, 1f, null, null), 5658, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 280, "Brown Pell 4", "Pell Villager", 25020, null, 0, 0, 0, 1f, null, null), 5659, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 281, "Armored Brown Pell 1", "Pell Villager", 25021, null, 0, 0, 0, 1f, null, null), 5660, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 282, "Armored Brown Pell 2", "Pell Villager", 25022, null, 0, 0, 0, 1f, null, null), 5661, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 283, "Armored Brown Pell 3", "Pell Villager", 25023, null, 0, 0, 0, 1f, null, null), 5662, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 284, "Armored Brown Pell 4", "Pell Villager", 25024, null, 0, 0, 0, 1f, null, null), 5663, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 285, "Grey Pell 1", "Pell Villager", 29333, null, 0, 0, 0, 1f, null, null), 5664, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 286, "Grey Pell 2", "Pell Villager", 29327, null, 0, 0, 0, 1f, null, null), 5665, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 287, "Grey Pell 3", "Pell Villager", 26284, null, 0, 0, 0, 1f, null, null), 5666, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 288, "Grey Pell 4", "Pell Villager", 41182, null, 0, 0, 0, 1f, null, null), 5667, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 289, "Armored Grey Pell 1", "Pell Villager", 29328, null, 0, 0, 0, 1f, null, null), 5668, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 290, "Armored Grey Pell 2", "Pell Villager", 29329, null, 0, 0, 0, 1f, null, null), 5669, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 291, "Armored Grey Pell 3", "Pell Villager", 31034, null, 0, 0, 0, 1f, null, null), 5670, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 292, "Armored Grey Pell 4", "Pell Villager", 31036, null, 0, 0, 0, 1f, null, null), 5671, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 293, "Pell High Priest 1", "Pell High Priest", 30115, null, 2091, 0, 0, 0.6f, null, null), 5672, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 294, "Pell High Priest 2", "Pell High Priest", 30117, null, 2090, 0, 0, 0.6f, null, null), 5673, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 295, "Pell High Priest 3", "Pell High Priest", 30116, null, 144, 0, 0, 0.6f, null, null), 5674, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 296, "Pell High Priest 1a", "Pell High Priest", 39308, null, 2091, 0, 0, 0.6f, null, null), 5675, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 1a)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 297, "Pell High Priest 2a", "Pell High Priest", 39311, null, 2090, 0, 0, 0.6f, null, null), 5676, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 2a)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 298, "Pell High Priest 3a", "Pell High Priest", 39310, null, 144, 0, 0, 0.6f, null, null), 5677, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 3a)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 299, "Pell High Priest White 1", "Pell High Priest", 39102, null, 2091, 0, 0, 0.6f, null, null), 5678, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest, White (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 300, "Pell High Priest White 2", "Pell High Priest", 39101, null, 2090, 0, 0, 0.6f, null, null), 5679, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest, White (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 301, "Pell High Priest White 3", "Pell High Priest", 39104, null, 144, 0, 0, 0.6f, null, null), 5680, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest, White (Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 302, "Pell High Priest Dark 1", "Pell High Priest", 41331, null, 2091, 0, 0, 0.6f, null, null), 5681, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest, Dark", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 303, "Elemental Air", "Air Elemental", 27263, null, null, 0, 0, 0.75f, null, null), 5682, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Air", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 304, "Elemental Earth", "Earth Elemental", 27396, null, null, 0, 0, 0.75f, null, null), 5683, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Earth", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 305, "Elemental Fire", "Fire Elemental", 27398, null, null, 0, 0, 0.75f, null, null), 5684, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Fire", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 306, "Elemental Life", "Life Elemental", 27397, null, null, 0, 0, 0.75f, null, null), 5685, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Life", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 307, "Elemental Logic", "Logic Elemental", 27399, null, null, 0, 0, 0.75f, null, null), 5686, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Logic", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 308, "Elemental Soulfrost", "Soulfrost Elemental", 41314, null, null, 0, 0, 0.75f, null, null), 5687, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Soulfrost", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 309, "Elemental Water", "Water Elemental", 27395, null, null, 0, 0, 0.75f, null, null), 5688, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Water", 11);
            AddNPCDecor(2666, AddCreature(52508, startCreature2ID + 310, "Elemental Air Sprite", "Vortex Sprite", null, null, null, 0, 0, 1f, 24723, 219), 5689, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Air Sprite", 11);
            AddNPCDecor(2666, AddCreature(52507, startCreature2ID + 311, "Elemental Earth Sprite", "Geode Sprite", null, null, null, 0, 0, 1f, 24723, 219), 5690, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Earth Sprite", 11);
            AddNPCDecor(2666, AddCreature(52505, startCreature2ID + 312, "Elemental Fire Sprite", "Blaze Sprite", null, null, null, 0, 0, 1f, 24723, 219), 5691, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Fire Sprite", 11);
            AddNPCDecor(2666, AddCreature(52508, startCreature2ID + 313, "Elemental Life Sprite", "Esprit Sprite", null, null, null, 0, 0, 1f, 24723, 219), 5692, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Life Sprite", 11);
            AddNPCDecor(2666, AddCreature(52510, startCreature2ID + 314, "Elemental Logic Sprite", "Daemon Sprite", null, null, null, 0, 0, 1f, 24723, 219), 5693, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Logic Sprite", 11);
            AddNPCDecor(2666, AddCreature(52506, startCreature2ID + 315, "Elemental Water Sprite", "Torrent Sprite", null, null, null, 0, 0, 1f, 24723, 219), 5694, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elemental, Water Sprite", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 316, "Greater Elemental Air", "Greater Air Elemental", 27263, null, null, 0, 0, 1f, null, null), 5695, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Greater Elemental, Air", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 317, "Greater Elemental Earth", "Greater Earth Elemental", 27396, null, null, 0, 0, 1f, null, null), 5696, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Greater Elemental, Earth", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 318, "Greater Elemental Fire", "Greater Fire Elemental", 27398, null, null, 0, 0, 1f, null, null), 5697, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Greater Elemental, Fire", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 319, "Greater Elemental Life", "Greater Life Elemental", 27397, null, null, 0, 0, 1f, null, null), 5698, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Greater Elemental, Life", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 320, "Greater Elemental Logic", "Greater Logic Elemental", 27399, null, null, 0, 0, 1f, null, null), 5699, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Greater Elemental, Logic", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 321, "Greater Elemental Soulfrost", "Greater Soulfrost Elemental", 41314, null, null, 0, 0, 1f, null, null), 5700, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Greater Elemental, Soulfrost", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 322, "Greater Elemental Water", "Greater Water Elemental", 27395, null, null, 0, 0, 1f, null, null), 5701, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Greater Elemental, Water", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 323, "Elder Elemental Air", "Elder Air Elemental", 27263, null, null, 0, 0, 1.25f, null, null), 5702, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elder Elemental, Air", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 324, "Elder Elemental Earth", "Elder Earth Elemental", 27396, null, null, 0, 0, 1.25f, null, null), 5703, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elder Elemental, Earth", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 325, "Elder Elemental Fire", "Elder Fire Elemental", 27398, null, null, 0, 0, 1.25f, null, null), 5704, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elder Elemental, Fire", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 326, "Elder Elemental Life", "Elder Life Elemental", 27397, null, null, 0, 0, 1.25f, null, null), 5705, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elder Elemental, Life", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 327, "Elder Elemental Logic", "Elder Logic Elemental", 27399, null, null, 0, 0, 1.25f, null, null), 5706, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elder Elemental, Logic", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 328, "Elder Elemental Soulfrost", "Elder Soulfrost Elemental", 41314, null, null, 0, 0, 1.25f, null, null), 5707, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elder Elemental, Soulfrost", 11);
            AddNPCDecor(2666, AddCreature(73086, startCreature2ID + 329, "Elder Elemental Water", "Elder Water Elemental", 27395, null, null, 0, 0, 1.25f, null, null), 5708, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Elder Elemental, Water", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 330, "Brown Pell Hammer-Guard", "Pell Hammer-Guard", 25024, null, 2092, 0, 0, 1f, null, null), 5709, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Brown", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 331, "Brown Pell Arcanist", "Pell Arcanist", 25021, null, 1612, 0, 0, 1f, null, null), 5710, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Brown", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 332, "Brown Pell Ritualist", "Pell Ritualist", 25019, null, 2090, 0, 0, 1f, null, null), 5711, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Brown", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 333, "Brown Pell Summoner", "Pell Summoner", 23908, null, 2091, 0, 0, 1f, null, null), 5712, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Brown", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 334, "Brown Pell Blade-Guard", "Pell Blade-Guard", 25023, null, 2089, 0, 0, 1f, null, null), 5713, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Brown", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 335, "Grey Pell Hammer-Guard", "Pell Hammer-Guard", 31036, null, 2092, 0, 0, 1f, null, null), 5714, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Grey", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 336, "Grey Pell Arcanist", "Pell Arcanist", 29328, null, 1612, 0, 0, 1f, null, null), 5715, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Grey", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 337, "Grey Pell Ritualist", "Pell Ritualist", 29333, null, 2090, 0, 0, 1f, null, null), 5716, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Grey", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 338, "Grey Pell Summoner", "Pell Summoner", 29327, null, 2091, 0, 0, 1f, null, null), 5717, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Grey", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 339, "Grey Pell Blade-Guard", "Pell Blade-Guard", 31034, null, 2089, 0, 0, 1f, null, null), 5718, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Grey", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 340, "Brown Pell Hammer-Guard", "Pell Hammer-Guard", 25024, null, 2092, 21797, 151, 1f, null, null), 5725, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Brown (Alert)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 341, "Brown Pell Arcanist", "Pell Arcanist", 25021, null, 1612, 17875, 151, 1f, null, null), 5726, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Brown (Alert)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 342, "Brown Pell Ritualist", "Pell Ritualist", 25019, null, 2090, 25402, 6008, 1f, null, null), 5727, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Brown (Channeling)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 343, "Brown Pell Summoner", "Pell Summoner", 23908, null, 2091, 23547, 6069, 1f, null, null), 5728, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Brown (Channeling)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 344, "Brown Pell Blade-Guard", "Pell Blade-Guard", 25023, null, 2089, 17728, 151, 1f, null, null), 5729, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Brown (Alert)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 345, "Grey Pell Hammer-Guard", "Pell Hammer-Guard", 31036, null, 2092, 21839, 151, 1f, null, null), 5730, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Grey (Alert)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 346, "Grey Pell Arcanist", "Pell Arcanist", 29328, null, 1612, 17725, 151, 1f, null, null), 5731, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Grey (Alert)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 347, "Grey Pell Ritualist", "Pell Ritualist", 29333, null, 2090, 17761, 6008, 1f, null, null), 5732, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Grey (Channeling)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 348, "Grey Pell Summoner", "Pell Summoner", 29327, null, 2091, 25403, 6069, 1f, null, null), 5733, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Grey (Channeling)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 349, "Grey Pell Blade-Guard", "Pell Blade-Guard", 31034, null, 2089, 21574, 151, 1f, null, null), 5734, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Grey (Alert)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 350, "Pellbot", "Pellbot", 27275, 0, 0, 0, 0, 1f, null, null), 5735, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pellbot", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 351, "Draken Male Civilian 1", "Draken Civilian", 39029, 9891, 0, 0, 0, 1f, null, null), 5736, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 352, "Draken Male Civilian 2", "Draken Civilian", 39046, 8576, 0, 0, 0, 1f, null, null), 5737, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 353, "Draken Male Civilian 3", "Draken Civilian", 28270, 8477, 0, 0, 0, 1f, null, null), 5738, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 354, "Draken Male Civilian 4", "Draken Civilian", 28325, 10250, 0, 0, 0, 1f, null, null), 5739, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 355, "Draken Male Civilian 5", "Draken Civilian", 28359, 9869, 0, 0, 0, 1f, null, null), 5740, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 356, "Draken Male Civilian 6", "Draken Civilian", 28295, 9459, 0, 0, 0, 1f, null, null), 5741, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 357, "Draken Male Civilian 7", "Draken Civilian", 36304, 9695, 0, 0, 0, 1f, null, null), 5742, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 358, "Draken Female Civilian 1", "Draken Civilian", 39025, 9891, 0, 0, 0, 1f, null, null), 5743, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 359, "Draken Female Civilian 2", "Draken Civilian", 39048, 8576, 0, 0, 0, 1f, null, null), 5744, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 360, "Draken Female Civilian 3", "Draken Civilian", 25335, 8477, 0, 0, 0, 1f, null, null), 5745, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 361, "Draken Female Civilian 4", "Draken Civilian", 39027, 10250, 0, 0, 0, 1f, null, null), 5746, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 362, "Draken Female Civilian 5", "Draken Civilian", 25363, 9869, 0, 0, 0, 1f, null, null), 5747, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 363, "Draken Female Civilian 6", "Draken Civilian", 26893, 9695, 0, 0, 0, 1f, null, null), 5748, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 364, "Draken Female Civilian 7", "Draken Civilian", 34446, 9459, 0, 0, 0, 1f, null, null), 5749, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 365, "Aurin Male Civilian 1", "Aurin Civilian", 39036, 8758, 0, 0, 0, 1f, null, null), 5750, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 366, "Aurin Male Civilian 2", "Aurin Civilian", 39609, 8416, 0, 0, 0, 1f, null, null), 5751, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 367, "Aurin Male Civilian 3", "Aurin Civilian", 41150, 8755, 0, 0, 0, 1f, null, null), 5752, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 368, "Aurin Male Civilian 4", "Aurin Civilian", 30179, 9869, 0, 0, 0, 1f, null, null), 5753, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 369, "Aurin Male Civilian 5", "Aurin Civilian", 34948, 8211, 0, 0, 0, 1f, null, null), 5754, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 370, "Aurin Male Civilian 6", "Aurin Civilian", 32751, 9931, 0, 0, 0, 1f, null, null), 5755, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 371, "Aurin Male Civilian 7", "Aurin Civilian", 28319, 9704, 0, 0, 0, 1f, null, null), 5756, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 372, "Aurin Female Civilian 1", "Aurin Civilian", 39037, 8416, 0, 0, 0, 1f, null, null), 5757, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 373, "Aurin Female Civilian 2", "Aurin Civilian", 39611, 8758, 0, 0, 0, 1f, null, null), 5758, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 374, "Aurin Female Civilian 3", "Aurin Civilian", 41213, 8755, 0, 0, 0, 1f, null, null), 5759, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 375, "Aurin Female Civilian 4", "Aurin Civilian", 34949, 8211, 0, 0, 0, 1f, null, null), 5760, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 376, "Aurin Female Civilian 5", "Aurin Civilian", 38231, 9869, 0, 0, 0, 1f, null, null), 5761, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 377, "Aurin Female Civilian 6", "Aurin Civilian", 36300, 9704, 0, 0, 0, 1f, null, null), 5762, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 378, "Aurin Female Civilian 7", "Aurin Civilian", 33161, 9931, 0, 0, 0, 1f, null, null), 5763, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 379, "Mechari Male Civilian 1", "Mechari Civilian", 41229, 10310, 0, 0, 0, 1f, null, null), 5764, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 380, "Mechari Male Civilian 2", "Mechari Civilian", 29552, 10250, 0, 0, 0, 1f, null, null), 5765, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 381, "Mechari Male Civilian 3", "Mechari Civilian", 28346, 9694, 0, 0, 0, 1f, null, null), 5766, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 382, "Mechari Male Civilian 4", "Mechari Civilian", 28827, 8496, 0, 0, 0, 1f, null, null), 5767, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 383, "Mechari Male Civilian 5", "Mechari Civilian", 28330, 9695, 0, 0, 0, 1f, null, null), 5768, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 384, "Mechari Male Civilian 6", "Mechari Civilian", 28312, 10533, 0, 0, 0, 1f, null, null), 5769, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 385, "Mechari Male Civilian 7", "Mechari Civilian", 38821, 8229, 0, 0, 0, 1f, null, null), 5770, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 386, "Mechari Female Civilian 1", "Mechari Civilian", 41230, 8229, 0, 0, 0, 1f, null, null), 5771, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 387, "Mechari Female Civilian 2", "Mechari Civilian", 31745, 8496, 0, 0, 0, 1f, null, null), 5772, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 388, "Mechari Female Civilian 3", "Mechari Civilian", 32482, 9695, 0, 0, 0, 1f, null, null), 5773, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 389, "Mechari Female Civilian 4", "Mechari Civilian", 28331, 10250, 0, 0, 0, 1f, null, null), 5774, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 390, "Mechari Female Civilian 5", "Mechari Civilian", 28313, 9694, 0, 0, 0, 1f, null, null), 5775, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 391, "Mechari Female Civilian 6", "Mechari Civilian", 34856, 10533, 0, 0, 0, 1f, null, null), 5776, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 392, "Mechari Female Civilian 7", "Mechari Civilian", 32971, 10310, 0, 0, 0, 1f, null, null), 5777, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 393, "Highborn Cassian Male Chairsit 1", "Cassian Noble", 28323, 10106, 0, 0, 7707, 1f, null, null), 5778, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 394, "Highborn Cassian Male Chairsit 2", "Cassian Noble", 38818, 9695, 0, 0, 7707, 1f, null, null), 5779, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 395, "Highborn Cassian Male Chairsit 3", "Cassian Noble", 34859, 10105, 0, 0, 7707, 1f, null, null), 5780, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 396, "Highborn Cassian Male Chairsit 4", "Cassian Noble", 25049, 9695, 0, 0, 7707, 1f, null, null), 5781, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 397, "Highborn Cassian Male Chairsit 5", "Cassian Noble", 36287, 9704, 0, 0, 7707, 1f, null, null), 5782, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 398, "Highborn Cassian Male Chairsit 6", "Cassian Noble", 30880, 9694, 0, 0, 7707, 1f, null, null), 5783, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 399, "Highborn Cassian Male Chairsit 7", "Cassian Noble", 30172, 8229, 0, 0, 7707, 1f, null, null), 5784, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 400, "Lowborn Cassian Male Chairsit 1", "Cassian Commoner", 28300, 10250, 0, 0, 7707, 1f, null, null), 5785, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 401, "Lowborn Cassian Male Chairsit 2", "Cassian Commoner", 25809, 10110, 0, 0, 7707, 1f, null, null), 5786, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 402, "Lowborn Cassian Male Chairsit 3", "Cassian Commoner", 28260, 8755, 0, 0, 7707, 1f, null, null), 5787, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 403, "Lowborn Cassian Male Chairsit 4", "Cassian Commoner", 30597, 10533, 0, 0, 7707, 1f, null, null), 5788, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 404, "Lowborn Cassian Male Chairsit 5", "Cassian Commoner", 30897, 8757, 0, 0, 7707, 1f, null, null), 5789, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 405, "Lowborn Cassian Male Chairsit 6", "Cassian Commoner", 25653, 8754, 0, 0, 7707, 1f, null, null), 5790, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 406, "Lowborn Cassian Male Chairsit 7", "Cassian Commoner", 28341, 9459, 0, 0, 7707, 1f, null, null), 5791, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 407, "Exiled Human Male Chairsit 1", "Human Civilian", 28308, 8754, 0, 0, 7707, 1f, null, null), 5792, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 408, "Exiled Human Male Chairsit 2", "Human Civilian", 28349, 10250, 0, 0, 7707, 1f, null, null), 5793, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 409, "Exiled Human Male Chairsit 3", "Human Civilian", 29477, 8755, 0, 0, 7707, 1f, null, null), 5794, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 410, "Exiled Human Male Chairsit 4", "Human Civilian", 28033, 9931, 0, 0, 7707, 1f, null, null), 5795, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 411, "Exiled Human Male Chairsit 5", "Human Civilian", 27346, 8211, 0, 0, 7707, 1f, null, null), 5796, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 412, "Exiled Human Male Chairsit 6", "Human Civilian", 32799, 8757, 0, 0, 7707, 1f, null, null), 5797, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 413, "Exiled Human Male Chairsit 7", "Human Civilian", 24796, 8758, 0, 0, 7707, 1f, null, null), 5798, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 414, "Highborn Cassian Female Chairsit 1", "Cassian Noble", 30666, 8229, 0, 0, 7707, 1f, null, null), 5799, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 415, "Highborn Cassian Female Chairsit 2", "Cassian Noble", 30240, 9694, 0, 0, 7707, 1f, null, null), 5800, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 416, "Highborn Cassian Female Chairsit 3", "Cassian Noble", 34860, 10106, 0, 0, 7707, 1f, null, null), 5801, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 417, "Highborn Cassian Female Chairsit 4", "Cassian Noble", 29475, 9704, 0, 0, 7707, 1f, null, null), 5802, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 418, "Highborn Cassian Female Chairsit 5", "Cassian Noble", 41300, 9695, 0, 0, 7707, 1f, null, null), 5803, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 419, "Highborn Cassian Female Chairsit 6", "Cassian Noble", 28324, 10105, 0, 0, 7707, 1f, null, null), 5804, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 420, "Highborn Cassian Female Chairsit 7", "Cassian Noble", 30599, 8496, 0, 0, 7707, 1f, null, null), 5805, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Highborn Cassian, Chair Sit (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 421, "Lowborn Cassian Female Chairsit 1", "Cassian Commoner", 34858, 10250, 0, 0, 7707, 1f, null, null), 5806, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 422, "Lowborn Cassian Female Chairsit 2", "Cassian Commoner", 28301, 10533, 0, 0, 7707, 1f, null, null), 5807, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 423, "Lowborn Cassian Female Chairsit 3", "Cassian Commoner", 30748, 9869, 0, 0, 7707, 1f, null, null), 5808, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 424, "Lowborn Cassian Female Chairsit 4", "Cassian Commoner", 31426, 8757, 0, 0, 7707, 1f, null, null), 5809, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 425, "Lowborn Cassian Female Chairsit 5", "Cassian Commoner", 25336, 8754, 0, 0, 7707, 1f, null, null), 5810, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 426, "Lowborn Cassian Female Chairsit 6", "Cassian Commoner", 34862, 9459, 0, 0, 7707, 1f, null, null), 5811, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 427, "Lowborn Cassian Female Chairsit 7", "Cassian Commoner", 34870, 8416, 0, 0, 7707, 1f, null, null), 5812, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Lowborn Cassian, Chair Sit (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 428, "Exiled Human Female Chairsit 1", "Human Civilian", 28309, 8758, 0, 0, 7707, 1f, null, null), 5813, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 429, "Exiled Human Female Chairsit 2", "Human Civilian", 30112, 10250, 0, 0, 7707, 1f, null, null), 5814, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 430, "Exiled Human Female Chairsit 3", "Human Civilian", 25887, 8416, 0, 0, 7707, 1f, null, null), 5815, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 431, "Exiled Human Female Chairsit 4", "Human Civilian", 30194, 8755, 0, 0, 7707, 1f, null, null), 5816, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 432, "Exiled Human Female Chairsit 5", "Human Civilian", 30178, 9869, 0, 0, 7707, 1f, null, null), 5817, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 433, "Exiled Human Female Chairsit 6", "Human Civilian", 27562, 8211, 0, 0, 7707, 1f, null, null), 5818, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 434, "Exiled Human Female Chairsit 7", "Human Civilian", 25051, 8416, 0, 0, 7707, 1f, null, null), 5819, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Exiled Human, Chair Sit (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 435, "Draken Male Civilian Chairsit 1", "Draken Civilian", 39029, 9891, 0, 0, 7707, 1f, null, null), 5820, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 436, "Draken Male Civilian Chairsit 2", "Draken Civilian", 39046, 8576, 0, 0, 7707, 1f, null, null), 5821, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 437, "Draken Male Civilian Chairsit 3", "Draken Civilian", 28270, 8477, 0, 0, 7707, 1f, null, null), 5822, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 438, "Draken Male Civilian Chairsit 4", "Draken Civilian", 28325, 10250, 0, 0, 7707, 1f, null, null), 5823, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 439, "Draken Male Civilian Chairsit 5", "Draken Civilian", 28359, 9869, 0, 0, 7707, 1f, null, null), 5824, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 440, "Draken Male Civilian Chairsit 6", "Draken Civilian", 28295, 9459, 0, 0, 7707, 1f, null, null), 5825, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 441, "Draken Male Civilian Chairsit 7", "Draken Civilian", 36304, 9695, 0, 0, 7707, 1f, null, null), 5826, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 442, "Draken Female Civilian Chairsit 1", "Draken Civilian", 39025, 9891, 0, 0, 7707, 1f, null, null), 5827, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 443, "Draken Female Civilian Chairsit 2", "Draken Civilian", 39048, 8576, 0, 0, 7707, 1f, null, null), 5828, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 444, "Draken Female Civilian Chairsit 3", "Draken Civilian", 25335, 8477, 0, 0, 7707, 1f, null, null), 5829, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 445, "Draken Female Civilian Chairsit 4", "Draken Civilian", 39027, 10250, 0, 0, 7707, 1f, null, null), 5830, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 446, "Draken Female Civilian Chairsit 5", "Draken Civilian", 25363, 9869, 0, 0, 7707, 1f, null, null), 5831, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 447, "Draken Female Civilian Chairsit 6", "Draken Civilian", 26893, 9695, 0, 0, 7707, 1f, null, null), 5832, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 448, "Draken Female Civilian Chairsit 7", "Draken Civilian", 34446, 9459, 0, 0, 7707, 1f, null, null), 5833, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Civilian, Chair Sit (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 449, "Aurin Male Civilian Chairsit 1", "Aurin Civilian", 39036, 8758, 0, 0, 7707, 1f, null, null), 5834, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 450, "Aurin Male Civilian Chairsit 2", "Aurin Civilian", 39609, 8416, 0, 0, 7707, 1f, null, null), 5835, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 451, "Aurin Male Civilian Chairsit 3", "Aurin Civilian", 41150, 8755, 0, 0, 7707, 1f, null, null), 5836, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 452, "Aurin Male Civilian Chairsit 4", "Aurin Civilian", 30179, 9869, 0, 0, 7707, 1f, null, null), 5837, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 453, "Aurin Male Civilian Chairsit 5", "Aurin Civilian", 34948, 8211, 0, 0, 7707, 1f, null, null), 5838, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 454, "Aurin Male Civilian Chairsit 6", "Aurin Civilian", 32751, 9931, 0, 0, 7707, 1f, null, null), 5839, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 455, "Aurin Male Civilian Chairsit 7", "Aurin Civilian", 28319, 9704, 0, 0, 7707, 1f, null, null), 5840, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 456, "Aurin Female Civilian Chairsit 1", "Aurin Civilian", 39037, 8416, 0, 0, 7707, 1f, null, null), 5841, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 457, "Aurin Female Civilian Chairsit 2", "Aurin Civilian", 39611, 8758, 0, 0, 7707, 1f, null, null), 5842, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 458, "Aurin Female Civilian Chairsit 3", "Aurin Civilian", 41213, 8755, 0, 0, 7707, 1f, null, null), 5843, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 459, "Aurin Female Civilian Chairsit 4", "Aurin Civilian", 34949, 8211, 0, 0, 7707, 1f, null, null), 5844, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 460, "Aurin Female Civilian Chairsit 5", "Aurin Civilian", 38231, 9869, 0, 0, 7707, 1f, null, null), 5845, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 461, "Aurin Female Civilian Chairsit 6", "Aurin Civilian", 36300, 9704, 0, 0, 7707, 1f, null, null), 5846, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 462, "Aurin Female Civilian Chairsit 7", "Aurin Civilian", 33161, 9931, 0, 0, 7707, 1f, null, null), 5847, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Civilian, Chair Sit (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 463, "Mechari Male Civilian Chairsit 1", "Mechari Civilian", 41229, 10310, 0, 0, 7707, 1f, null, null), 5848, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 464, "Mechari Male Civilian Chairsit 2", "Mechari Civilian", 29552, 10250, 0, 0, 7707, 1f, null, null), 5849, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 465, "Mechari Male Civilian Chairsit 3", "Mechari Civilian", 28346, 9694, 0, 0, 7707, 1f, null, null), 5850, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 466, "Mechari Male Civilian Chairsit 4", "Mechari Civilian", 28827, 8496, 0, 0, 7707, 1f, null, null), 5851, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 467, "Mechari Male Civilian Chairsit 5", "Mechari Civilian", 28330, 9695, 0, 0, 7707, 1f, null, null), 5852, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Male, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 468, "Mechari Male Civilian Chairsit 6", "Mechari Civilian", 28312, 10533, 0, 0, 7707, 1f, null, null), 5853, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Male, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 469, "Mechari Male Civilian Chairsit 7", "Mechari Civilian", 38821, 8229, 0, 0, 7707, 1f, null, null), 5854, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Male, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 470, "Mechari Female Civilian Chairsit 1", "Mechari Civilian", 41230, 8229, 0, 0, 7707, 1f, null, null), 5855, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 471, "Mechari Female Civilian Chairsit 2", "Mechari Civilian", 31745, 8496, 0, 0, 7707, 1f, null, null), 5856, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 472, "Mechari Female Civilian Chairsit 3", "Mechari Civilian", 32482, 9695, 0, 0, 7707, 1f, null, null), 5857, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 473, "Mechari Female Civilian Chairsit 4", "Mechari Civilian", 28331, 10250, 0, 0, 7707, 1f, null, null), 5858, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Female, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 474, "Mechari Female Civilian Chairsit 5", "Mechari Civilian", 28313, 9694, 0, 0, 7707, 1f, null, null), 5859, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Female, Style 5)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 475, "Mechari Female Civilian Chairsit 6", "Mechari Civilian", 34856, 10533, 0, 0, 7707, 1f, null, null), 5860, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Female, Style 6)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 476, "Mechari Female Civilian Chairsit 7", "Mechari Civilian", 32971, 10310, 0, 0, 7707, 1f, null, null), 5861, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Civilian, Chair Sit (Female, Style 7)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 477, "Draken Male Tradesman 1", "Tradesman", 39029, 10505, 0, 0, 0, 1f, null, null), 5862, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Tradesman (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 478, "Draken Male Tradesman 2", "Tradesman", 39046, 10505, 0, 0, 0, 1f, null, null), 5863, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Tradesman (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 479, "Draken Male Tradesman 3", "Tradesman", 28270, 10505, 0, 0, 0, 1f, null, null), 5864, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Tradesman (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 480, "Draken Female Tradesman 1", "Tradesman", 25363, 10505, 0, 0, 0, 1f, null, null), 5865, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Tradesman (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 481, "Draken Female Tradesman 2", "Tradesman", 26893, 10505, 0, 0, 0, 1f, null, null), 5866, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Tradesman (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 482, "Draken Female Tradesman 3", "Tradesman", 34446, 10505, 0, 0, 0, 1f, null, null), 5867, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Tradesman (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 483, "Aurin Male Tradesman 1", "Tradesman", 30179, 9726, 0, 0, 0, 1f, null, null), 5868, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Tradesman (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 484, "Aurin Male Tradesman 2", "Tradesman", 34948, 9726, 0, 0, 0, 1f, null, null), 5869, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Tradesman (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 485, "Aurin Male Tradesman 3", "Tradesman", 32751, 9726, 0, 0, 0, 1f, null, null), 5870, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Tradesman (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 486, "Aurin Female Tradesman 1", "Tradesman", 39037, 9726, 0, 0, 0, 1f, null, null), 5871, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Tradesman (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 487, "Aurin Female Tradesman 2", "Tradesman", 39611, 9726, 0, 0, 0, 1f, null, null), 5872, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Tradesman (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 488, "Aurin Female Tradesman 3", "Tradesman", 41213, 9726, 0, 0, 0, 1f, null, null), 5873, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Tradesman (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 489, "Mechari Male Tradesman 1", "Tradesman", 28346, 10505, 0, 0, 0, 1f, null, null), 5874, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Tradesman (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 490, "Mechari Male Tradesman 2", "Tradesman", 28827, 10505, 0, 0, 0, 1f, null, null), 5875, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Tradesman (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 491, "Mechari Male Tradesman 3", "Tradesman", 28330, 10505, 0, 0, 0, 1f, null, null), 5876, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Tradesman (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 492, "Mechari Female Tradesman 1", "Tradesman", 41230, 10505, 0, 0, 0, 1f, null, null), 5877, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Tradesman (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 493, "Mechari Female Tradesman 2", "Tradesman", 28331, 10505, 0, 0, 0, 1f, null, null), 5878, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Tradesman (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 494, "Mechari Female Tradesman 3", "Tradesman", 34856, 10505, 0, 0, 0, 1f, null, null), 5879, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Tradesman (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 495, "Draken Male Mechanic 1", "Mechanic", 39029, 9857, 39, 0, 0, 1f, null, null), 5880, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Mechanic (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 496, "Draken Male Mechanic 2", "Mechanic", 39046, 9857, 39, 0, 0, 1f, null, null), 5881, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Mechanic (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 497, "Draken Male Mechanic 3", "Mechanic", 28270, 9857, 39, 0, 0, 1f, null, null), 5882, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Mechanic (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 498, "Draken Female Mechanic 1", "Mechanic", 25363, 9857, 39, 0, 0, 1f, null, null), 5883, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Mechanic (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 499, "Draken Female Mechanic 2", "Mechanic", 26893, 9857, 39, 0, 0, 1f, null, null), 5884, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Mechanic (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 500, "Draken Female Mechanic 3", "Mechanic", 34446, 9857, 39, 0, 0, 1f, null, null), 5885, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Mechanic (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 501, "Aurin Male Mechanic 1", "Mechanic", 30179, 9735, 39, 0, 0, 1f, null, null), 5886, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Mechanic (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 502, "Aurin Male Mechanic 2", "Mechanic", 34948, 9735, 39, 0, 0, 1f, null, null), 5887, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Mechanic (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 503, "Aurin Male Mechanic 3", "Mechanic", 32751, 9735, 39, 0, 0, 1f, null, null), 5888, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Mechanic (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 504, "Aurin Female Mechanic 1", "Mechanic", 39037, 9735, 39, 0, 0, 1f, null, null), 5889, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Mechanic (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 505, "Aurin Female Mechanic 2", "Mechanic", 39611, 9735, 39, 0, 0, 1f, null, null), 5890, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Mechanic (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 506, "Aurin Female Mechanic 3", "Mechanic", 41213, 9735, 39, 0, 0, 1f, null, null), 5891, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Mechanic (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 507, "Mechari Male Mechanic 1", "Mechanic", 28346, 9857, 39, 0, 0, 1f, null, null), 5892, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Mechanic (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 508, "Mechari Male Mechanic 2", "Mechanic", 28827, 9857, 39, 0, 0, 1f, null, null), 5893, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Mechanic (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 509, "Mechari Male Mechanic 3", "Mechanic", 28330, 9857, 39, 0, 0, 1f, null, null), 5894, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Mechanic (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 510, "Mechari Female Mechanic 1", "Mechanic", 41230, 9857, 39, 0, 0, 1f, null, null), 5895, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Mechanic (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 511, "Mechari Female Mechanic 2", "Mechanic", 28331, 9857, 39, 0, 0, 1f, null, null), 5896, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Mechanic (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 512, "Mechari Female Mechanic 3", "Mechanic", 34856, 9857, 39, 0, 0, 1f, null, null), 5897, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Mechanic (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 513, "Draken Male Security Guard 1", "Security Guard", 39029, 8471, 149, 0, 0, 1f, null, null), 5898, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Security Guard (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 514, "Draken Male Security Guard 2", "Security Guard", 39046, 8471, 149, 0, 0, 1f, null, null), 5899, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Security Guard (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 515, "Draken Male Security Guard 3", "Security Guard", 28270, 8471, 149, 0, 0, 1f, null, null), 5900, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Security Guard (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 516, "Draken Female Security Guard 1", "Security Guard", 25363, 8471, 149, 0, 0, 1f, null, null), 5901, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Security Guard (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 517, "Draken Female Security Guard 2", "Security Guard", 26893, 8471, 149, 0, 0, 1f, null, null), 5902, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Security Guard (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 518, "Draken Female Security Guard 3", "Security Guard", 34446, 8471, 149, 0, 0, 1f, null, null), 5903, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Security Guard (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 519, "Aurin Male Security Guard 1", "Security Guard", 30179, 8659, 594, 0, 0, 1f, null, null), 5904, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Security Guard (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 520, "Aurin Male Security Guard 2", "Security Guard", 34948, 8659, 594, 0, 0, 1f, null, null), 5905, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Security Guard (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 521, "Aurin Male Security Guard 3", "Security Guard", 32751, 8659, 594, 0, 0, 1f, null, null), 5906, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Security Guard (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 522, "Aurin Female Security Guard 1", "Security Guard", 39037, 8659, 594, 0, 0, 1f, null, null), 5907, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Security Guard (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 523, "Aurin Female Security Guard 2", "Security Guard", 39611, 8659, 594, 0, 0, 1f, null, null), 5908, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Security Guard (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 524, "Aurin Female Security Guard 3", "Security Guard", 41213, 8659, 594, 0, 0, 1f, null, null), 5909, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Security Guard (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 525, "Mechari Male Security Guard 1", "Security Guard", 28346, 8471, 149, 0, 0, 1f, null, null), 5910, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Security Guard (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 526, "Mechari Male Security Guard 2", "Security Guard", 28827, 8471, 149, 0, 0, 1f, null, null), 5911, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Security Guard (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 527, "Mechari Male Security Guard 3", "Security Guard", 28330, 8471, 149, 0, 0, 1f, null, null), 5912, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Security Guard (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 528, "Mechari Female Security Guard 1", "Security Guard", 41230, 8471, 149, 0, 0, 1f, null, null), 5913, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Security Guard (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 529, "Mechari Female Security Guard 2", "Security Guard", 28331, 8471, 149, 0, 0, 1f, null, null), 5914, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Security Guard (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 530, "Mechari Female Security Guard 3", "Security Guard", 34856, 8471, 149, 0, 0, 1f, null, null), 5915, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Security Guard (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 531, "Draken Male Server 1", "Serving Staffer", 39029, 8466, 0, 0, 0, 1f, null, null), 5916, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Server (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 532, "Draken Male Server 2", "Serving Staffer", 39046, 8466, 0, 0, 0, 1f, null, null), 5917, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Server (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 533, "Draken Male Server 3", "Serving Staffer", 28270, 8466, 0, 0, 0, 1f, null, null), 5918, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Server (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 534, "Draken Female Server 1", "Serving Staffer", 25363, 8466, 0, 0, 0, 1f, null, null), 5919, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Server (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 535, "Draken Female Server 2", "Serving Staffer", 26893, 8466, 0, 0, 0, 1f, null, null), 5920, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Server (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 536, "Draken Female Server 3", "Serving Staffer", 34446, 8466, 0, 0, 0, 1f, null, null), 5921, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Draken Server (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 537, "Aurin Male Server 1", "Serving Staffer", 30179, 8379, 0, 0, 0, 1f, null, null), 5922, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Server (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 538, "Aurin Male Server 2", "Serving Staffer", 34948, 8379, 0, 0, 0, 1f, null, null), 5923, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Server (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 539, "Aurin Male Server 3", "Serving Staffer", 32751, 8379, 0, 0, 0, 1f, null, null), 5924, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Server (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 540, "Aurin Female Server 1", "Serving Staffer", 39037, 8379, 0, 0, 0, 1f, null, null), 5925, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Server (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 541, "Aurin Female Server 2", "Serving Staffer", 39611, 8379, 0, 0, 0, 1f, null, null), 5926, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Server (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 542, "Aurin Female Server 3", "Serving Staffer", 41213, 8379, 0, 0, 0, 1f, null, null), 5927, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Aurin Server (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 543, "Mechari Male Server 1", "Serving Staffer", 28346, 8466, 0, 0, 0, 1f, null, null), 5928, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Server (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 544, "Mechari Male Server 2", "Serving Staffer", 28827, 8466, 0, 0, 0, 1f, null, null), 5929, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Server (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 545, "Mechari Male Server 3", "Serving Staffer", 28330, 8466, 0, 0, 0, 1f, null, null), 5930, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Server (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 546, "Mechari Female Server 1", "Serving Staffer", 41230, 8466, 0, 0, 0, 1f, null, null), 5931, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Server (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 547, "Mechari Female Server 2", "Serving Staffer", 28331, 8466, 0, 0, 0, 1f, null, null), 5932, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Server (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 548, "Mechari Female Server 3", "Serving Staffer", 34856, 8466, 0, 0, 0, 1f, null, null), 5933, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Mechari Server (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 549, "Falkrin Red Male 1", "Falkrin Villager", 25338, 0, 0, 0, 0, 1f, null, null), 5934, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Red (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 550, "Falkrin Red Male 2", "Falkrin Villager", 25339, 0, 0, 0, 0, 1f, null, null), 5935, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Red (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 551, "Falkrin Red Male 3", "Falkrin Villager", 25340, 0, 0, 0, 0, 1f, null, null), 5936, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Red (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 552, "Armored Falkrin Red Male 1", "Falkrin Villager", 25341, 0, 0, 0, 0, 1f, null, null), 5937, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Red (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 553, "Armored Falkrin Red Male 2", "Falkrin Villager", 25342, 0, 0, 0, 0, 1f, null, null), 5938, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Red (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 554, "Armored Falkrin Red Male 3", "Falkrin Villager", 25343, 0, 0, 0, 0, 1f, null, null), 5939, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Red (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 555, "Armored Falkrin Red Male 4", "Falkrin Villager", 25344, 0, 0, 0, 0, 1f, null, null), 5940, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Red (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 556, "Falkrin Purple Male 1", "Falkrin Villager", 25086, 0, 0, 0, 0, 1f, null, null), 5941, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Purple (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 557, "Falkrin Purple Male 2", "Falkrin Villager", 31323, 0, 0, 0, 0, 1f, null, null), 5942, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Purple (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 558, "Falkrin Purple Male 3", "Falkrin Villager", 31314, 0, 0, 0, 0, 1f, null, null), 5943, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Purple (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 559, "Armored Falkrin Purple Male 1", "Falkrin Villager", 31312, 0, 0, 0, 0, 1f, null, null), 5944, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Purple (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 560, "Armored Falkrin Purple Male 2", "Falkrin Villager", 31315, 0, 0, 0, 0, 1f, null, null), 5945, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Purple (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 561, "Armored Falkrin Purple Male 3", "Falkrin Villager", 31336, 0, 0, 0, 0, 1f, null, null), 5946, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Purple (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 562, "Armored Falkrin Purple Male 4", "Falkrin Villager", 31324, 0, 0, 0, 0, 1f, null, null), 5947, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Purple (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 563, "Falkrin Golden Male 1", "Falkrin Villager", 31322, 0, 0, 0, 0, 1f, null, null), 5948, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Golden (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 564, "Falkrin Golden Male 2", "Falkrin Villager", 31321, 0, 0, 0, 0, 1f, null, null), 5949, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Golden (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 565, "Falkrin Golden Male 3", "Falkrin Villager", 31320, 0, 0, 0, 0, 1f, null, null), 5950, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Golden (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 566, "Armored Falkrin Golden Male 1", "Falkrin Villager", 31319, 0, 0, 0, 0, 1f, null, null), 5951, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Golden (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 567, "Armored Falkrin Golden Male 2", "Falkrin Villager", 31318, 0, 0, 0, 0, 1f, null, null), 5952, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Golden (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 568, "Armored Falkrin Golden Male 3", "Falkrin Villager", 31317, 0, 0, 0, 0, 1f, null, null), 5953, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Golden (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 569, "Armored Falkrin Golden Male 4", "Falkrin Villager", 31316, 0, 0, 0, 0, 1f, null, null), 5954, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Golden (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 570, "Falkrin Golden Female 1", "Falkrin Villager", 30935, 0, 0, 0, 0, 1f, null, null), 5955, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Golden (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 571, "Falkrin Golden Female 2", "Falkrin Villager", 30932, 0, 0, 0, 0, 1f, null, null), 5956, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Golden (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 572, "Falkrin Golden Female 3", "Falkrin Villager", 30934, 0, 0, 0, 0, 1f, null, null), 5957, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Golden (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 573, "Armored Falkrin Golden Female 1", "Falkrin Villager", 30930, 0, 0, 0, 0, 1f, null, null), 5958, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Golden (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 574, "Armored Falkrin Golden Female 2", "Falkrin Villager", 30931, 0, 0, 0, 0, 1f, null, null), 5959, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Golden (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 575, "Armored Falkrin Golden Female 3", "Falkrin Villager", 30933, 0, 0, 0, 0, 1f, null, null), 5960, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Golden (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 576, "Falkrin Grey Male 1", "Falkrin Villager", 25083, 0, 0, 0, 0, 1f, null, null), 5961, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Grey (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 577, "Falkrin Grey Male 2", "Falkrin Villager", 25085, 0, 0, 0, 0, 1f, null, null), 5962, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Grey (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 578, "Falkrin Grey Male 3", "Falkrin Villager", 31313, 0, 0, 0, 0, 1f, null, null), 5963, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Grey (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 579, "Armored Falkrin Grey Male 1", "Falkrin Villager", 31334, 0, 0, 0, 0, 1f, null, null), 5964, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Grey (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 580, "Armored Falkrin Grey Male 2", "Falkrin Villager", 31335, 0, 0, 0, 0, 1f, null, null), 5965, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Grey (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 581, "Armored Falkrin Grey Male 3", "Falkrin Villager", 31333, 0, 0, 0, 0, 1f, null, null), 5966, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Grey (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 582, "Armored Falkrin Grey Male 4", "Falkrin Villager", 31326, 0, 0, 0, 0, 1f, null, null), 5967, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Grey (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 583, "Falkrin Brown Male 1", "Falkrin Villager", 25084, 0, 0, 0, 0, 1f, null, null), 5968, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Brown (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 584, "Falkrin Brown Male 2", "Falkrin Villager", 31332, 0, 0, 0, 0, 1f, null, null), 5969, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Brown (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 585, "Falkrin Brown Male 3", "Falkrin Villager", 31331, 0, 0, 0, 0, 1f, null, null), 5970, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Brown (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 586, "Armored Falkrin Brown Male 1", "Falkrin Villager", 31329, 0, 0, 0, 0, 1f, null, null), 5971, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Brown (Male, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 587, "Armored Falkrin Brown Male 2", "Falkrin Villager", 31330, 0, 0, 0, 0, 1f, null, null), 5972, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Brown (Male, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 588, "Armored Falkrin Brown Male 3", "Falkrin Villager", 31328, 0, 0, 0, 0, 1f, null, null), 5973, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Brown (Male, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 589, "Armored Falkrin Brown Male 4", "Falkrin Villager", 31327, 0, 0, 0, 0, 1f, null, null), 5974, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Brown (Male, Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 590, "Falkrin White Female 1", "Falkrin Villager", 30953, 0, 0, 0, 0, 1f, null, null), 5975, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, White (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 591, "Falkrin White Female 2", "Falkrin Villager", 30952, 0, 0, 0, 0, 1f, null, null), 5976, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, White (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 592, "Falkrin White Female 3", "Falkrin Villager", 30948, 0, 0, 0, 0, 1f, null, null), 5977, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, White (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 593, "Armored Falkrin White Female 1", "Falkrin Villager", 30949, 0, 0, 0, 0, 1f, null, null), 5978, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, White (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 594, "Armored Falkrin White Female 2", "Falkrin Villager", 30950, 0, 0, 0, 0, 1f, null, null), 5979, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, White (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 595, "Armored Falkrin White Female 3", "Falkrin Villager", 30951, 0, 0, 0, 0, 1f, null, null), 5980, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, White (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 596, "Falkrin Purple Female 1", "Falkrin Villager", 30941, 0, 0, 0, 0, 1f, null, null), 5981, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Purple (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 597, "Falkrin Purple Female 2", "Falkrin Villager", 30937, 0, 0, 0, 0, 1f, null, null), 5982, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Purple (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 598, "Falkrin Purple Female 3", "Falkrin Villager", 30938, 0, 0, 0, 0, 1f, null, null), 5983, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Purple (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 599, "Armored Falkrin Purple Female 1", "Falkrin Villager", 30939, 0, 0, 0, 0, 1f, null, null), 5984, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Purple (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 600, "Armored Falkrin Purple Female 2", "Falkrin Villager", 30936, 0, 0, 0, 0, 1f, null, null), 5985, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Purple (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 601, "Armored Falkrin Purple Female 3", "Falkrin Villager", 30940, 0, 0, 0, 0, 1f, null, null), 5986, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Purple (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 602, "Falkrin Grey Female 1", "Falkrin Villager", 30947, 0, 0, 0, 0, 1f, null, null), 5987, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Grey (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 603, "Falkrin Grey Female 2", "Falkrin Villager", 30943, 0, 0, 0, 0, 1f, null, null), 5988, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Grey (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 604, "Falkrin Grey Female 3", "Falkrin Villager", 30942, 0, 0, 0, 0, 1f, null, null), 5989, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Grey (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 605, "Armored Falkrin Grey Female 1", "Falkrin Villager", 30944, 0, 0, 0, 0, 1f, null, null), 5990, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Grey (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 606, "Armored Falkrin Grey Female 2", "Falkrin Villager", 30945, 0, 0, 0, 0, 1f, null, null), 5991, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Grey (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 607, "Armored Falkrin Grey Female 3", "Falkrin Villager", 30946, 0, 0, 0, 0, 1f, null, null), 5992, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Grey (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 608, "Falkrin Brown Female 1", "Falkrin Villager", 25456, 0, 0, 0, 0, 1f, null, null), 5993, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Brown (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 609, "Falkrin Brown Female 2", "Falkrin Villager", 25457, 0, 0, 0, 0, 1f, null, null), 5994, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Brown (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 610, "Falkrin Brown Female 3", "Falkrin Villager", 25458, 0, 0, 0, 0, 1f, null, null), 5995, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Falkrin, Brown (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 611, "Armored Falkrin Brown Female 1", "Falkrin Villager", 25459, 0, 0, 0, 0, 1f, null, null), 5996, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Brown (Female, Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 612, "Armored Falkrin Brown Female 2", "Falkrin Villager", 25460, 0, 0, 0, 0, 1f, null, null), 5997, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Brown (Female, Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 613, "Armored Falkrin Brown Female 3", "Falkrin Villager", 25461, 0, 0, 0, 0, 1f, null, null), 5998, "Art\\Prop\\Constructed\\Banner\\Falkrin\\PRP_Falkrin_FeatheredBanner_001.m3", "Armored Falkrin, Brown (Female, Style 3)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 614, "Battlebot Blue", "Battlebot", 26057, 0, 0, 0, 0, 1f, null, null), 5999, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Battlebot, Blue", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 615, "Battlebot Darkspur", "Darkspur Goonbot", 27584, 0, 0, 0, 0, 1f, null, null), 6000, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Battlebot, Darkspur", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 616, "Battlebot Dominion", "Dominion Battlebot", 27587, 0, 0, 0, 0, 1f, null, null), 6001, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Battlebot, Dominion", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 617, "Battlebot Exile", "Exile Battlebot", 27800, 0, 0, 0, 0, 1f, null, null), 6002, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Battlebot, Exile", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 618, "Battlebot Grey", "Battlebot", 23896, 0, 0, 0, 0, 1f, null, null), 6003, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Battlebot, Grey", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 619, "Battlebot Protostar", "Protostar Blitzbot", 26061, 0, 0, 0, 0, 1f, null, null), 6004, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Battlebot, Protostar", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 620, "Battlebot Red", "Battlebot", 34565, 0, 0, 0, 0, 1f, null, null), 6005, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Battlebot, Red", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 621, "Drillbot Protostar", "Protostar Drillbot", 23910, 0, 0, 0, 0, 1f, null, null), 6006, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Drillbot, Protostar", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 622, "Drillbot Yellow", "Drillbot", 28569, 0, 0, 0, 0, 1f, null, null), 6007, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Drillbot, Yellow", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 623, "Probebot Bronze", "Probebot", 23909, 0, 0, 0, 0, 1f, null, null), 6008, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Probebot, Bronze", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 624, "Probebot Blue", "Probebot", 26064, 0, 0, 0, 0, 1f, null, null), 6009, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Probebot, Blue", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 625, "Probebot Purple", "Probebot", 26055, 0, 0, 0, 0, 1f, null, null), 6010, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Probebot, Purple", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 626, "Servebot Bronze", "Servebot", 23915, 0, 0, 0, 0, 1f, null, null), 6011, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Servebot, Bronze", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 627, "Servebot Green", "Servebot", 26052, 0, 0, 0, 0, 1f, null, null), 6012, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Servebot, Green", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 628, "Servebot Protostar", "Protostar Servebot", 26062, 0, 0, 0, 0, 1f, null, null), 6013, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Servebot, Protostar", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 629, "Smackbot Bronze", "Smackbot", 26051, 0, 0, 0, 0, 1f, null, null), 6014, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Smackbot, Bronze", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 630, "Smackbot Grey", "Smackbot", 26063, 0, 0, 0, 0, 1f, null, null), 6015, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Smackbot, Grey", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 631, "Smackbot Silver", "Smackbot", 23895, 0, 0, 0, 0, 1f, null, null), 6016, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Smackbot, Silver", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 632, "Utilitybot Medic", "Medicbot", 27822, 0, 0, 0, 0, 1f, null, null), 6017, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Utilitybot, Medic", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 633, "Utilitybot Protostar", "Protostar Utilitybot", 23911, 0, 0, 0, 0, 1f, null, null), 6018, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Utilitybot, Protostar", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 634, "Utilitybot Red", "Utilitybot", 26053, 0, 0, 0, 0, 1f, null, null), 6019, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "Utilitybot, Red", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 635, "Protostar Employee", "Protostar Employee", 23926, 0, 0, 0, 0, 1f, null, null), 6020, "Art\\Prop\\Constructed\\Sign\\Protostar\\PRP_Sign_ProtostarVertical_000.m3", "Protostar Employee", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 636, "Grumpel Civilian", "Grumpel Civilian", 23936, 0, 0, 0, 0, 1f, null, null), 6021, "Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", "Grumpel Civilian", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 637, "Male Blue Ekose", "Ekose Civilian", 30994, 0, 0, 0, 0, 1f, null, null), 6022, "Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", "Ekose Civilian, Male (Blue)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 638, "Male Green Ekose", "Ekose Civilian", 30993, 0, 0, 0, 0, 1f, null, null), 6023, "Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", "Ekose Civilian, Male (Green)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 639, "Male Red Ekose", "Ekose Civilian", 23925, 0, 0, 0, 0, 1f, null, null), 6024, "Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", "Ekose Civilian, Male (Red)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 640, "Male Yellow Ekose", "Ekose Civilian", 30995, 0, 0, 0, 0, 1f, null, null), 6025, "Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", "Ekose Civilian, Male (Yellow)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 641, "Female Ekose", "Ekose Civilian", 23924, 0, 0, 0, 0, 1f, null, null), 6026, "Art\\Prop\\Housing\\Decor\\ShipParts\\PRP_ShipParts_Connector_000.m3", "Ekose Civilian, Female", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 642, "Shellark", "Shellark", 24207, 0, 0, 0, 163, 1f, null, null), 6027, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, Shellark", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 643, "Sunfish", "Sunfish", 24069, 0, 0, 0, 0, 1f, null, null), 6028, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, Sunfish", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 644, "Goldfish 1", "Goldfish", 34594, 0, 0, 0, 0, 1f, null, null), 6029, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, Goldfish (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 645, "Goldfish 2", "Goldfish", 34593, 0, 0, 0, 0, 1f, null, null), 6030, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, Goldfish (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 646, "Green Pirahna", "Pirahna", 25527, 0, 0, 0, 0, 1f, null, null), 6031, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, Pirahna (Green)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 647, "Purple Pirahna", "Pirahna", 25528, 0, 0, 0, 0, 1f, null, null), 6032, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, Pirahna (Purple)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 648, "Blue Pirahna", "Pirahna", 25529, 0, 0, 0, 0, 1f, null, null), 6033, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, Pirahna (Blue)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 649, "Chaar", "Chaar", 25058, 0, 0, 0, 0, 1f, null, null), 6034, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, Chaar", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 650, "Fish School", "School of Fish", 30047, 0, 0, 0, 0, 1f, null, null), 6035, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Fish, School", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 651, "Green Garr", "Green Garr", 28831, 0, 0, 0, 0, 1f, null, null), 6036, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Garr, Green", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 652, "Olive Garr", "Olive Garr", 31144, 0, 0, 0, 0, 1f, null, null), 6037, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Garr, Olive", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 653, "Red Garr", "Red Garr", 24011, 0, 0, 0, 0, 1f, null, null), 6038, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Garr, Red", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 654, "Dominion Patrol Garr", "Dominion Patrol Garr", 28793, 0, 0, 0, 0, 1f, null, null), 6039, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Garr, Dominion Patrol", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 655, "Green Garr Floating", "Green Garr", 28831, 0, 0, 0, 163, 1f, null, null), 6040, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Garr, Green (Floating)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 656, "Olive Garr Floating", "Olive Garr", 31144, 0, 0, 0, 163, 1f, null, null), 6041, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Garr, Olive (Floating)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 657, "Red Garr Floating", "Red Garr", 24011, 0, 0, 0, 163, 1f, null, null), 6042, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Garr, Red (Floating)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 658, "Dominion Patrol Garr Floating", "Dominion Patrol Garr", 28793, 0, 0, 0, 163, 1f, null, null), 6043, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Garr, Dominion Patrol (Floating)", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 659, "Exile Hound", "Exile Hound", 28431, 0, 0, 0, 0, 1f, null, null), 6044, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dagun, Exile Hound", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 660, "Black Girrok", "Black Girrok", 24140, 0, 0, 0, 0, 1f, null, null), 6045, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Girrok, Black", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 661, "Brown Girrok", "Brown Girrok", 24139, 0, 0, 0, 0, 1f, null, null), 6046, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Girrok, Brown", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 662, "Purple Girrok", "Purple Girrok", 24994, 0, 0, 0, 0, 1f, null, null), 6047, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Girrok, Purple", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 663, "Purplestripe Girrok", "Purplestripe Girrok", 24995, 0, 0, 0, 0, 1f, null, null), 6048, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Girrok, Purplestripe", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 664, "Scarred Girrok", "Scarred Girrok", 25000, 0, 0, 0, 0, 1f, null, null), 6049, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Girrok, Scarred", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 665, "White Girrok", "White Girrok", 31145, 0, 0, 0, 0, 1f, null, null), 6050, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Girrok, White", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 666, "Blue Dawngrazer", "Blue Dawngrazer", 26655, 0, 0, 0, 0, 1f, null, null), 6051, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dawngrazer, Blue", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 667, "Brown Dawngrazer", "Brown Dawngrazer", 25374, 0, 0, 0, 0, 1f, null, null), 6052, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dawngrazer, Brown", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 668, "Grey Dawngrazer", "Grey Dawngrazer", 25551, 0, 0, 0, 0, 1f, null, null), 6053, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dawngrazer, Grey", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 669, "Tan Dawngrazer", "Tan Dawngrazer", 25552, 0, 0, 0, 0, 1f, null, null), 6054, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dawngrazer, Tan", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 670, "White Dawngrazer", "White Dawngrazer", 24065, 0, 0, 0, 0, 1f, null, null), 6055, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dawngrazer, White", 11);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 671, "Zebra Dawngrazer", "Zebra Dawngrazer", 31412, 0, 0, 0, 0, 1f, null, null), 6056, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "Dawngrazer, Zebra", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 672, "Fire Pell 1", "Pell Villager", 31053, 0, 0, 0, 0, 1f, null, null), 6057, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 673, "Fire Pell 2", "Pell Villager", 31039, 0, 0, 0, 0, 1f, null, null), 6058, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 674, "Fire Pell 3", "Pell Villager", 31042, 0, 0, 0, 0, 1f, null, null), 6059, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 675, "Fire Pell 4", "Pell Villager", 31044, 0, 0, 0, 0, 1f, null, null), 6060, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 676, "Armored fire Pell 1", "Pell Villager", 31046, 0, 0, 0, 0, 1f, null, null), 6061, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 1)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 677, "Armored fire Pell 2", "Pell Villager", 31041, 0, 0, 0, 0, 1f, null, null), 6062, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 2)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 678, "Armored fire Pell 3", "Pell Villager", 31040, 0, 0, 0, 0, 1f, null, null), 6063, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 3)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 679, "Armored fire Pell 4", "Pell Villager", 31043, 0, 0, 0, 0, 1f, null, null), 6064, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 4)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 680, "Fire Pell priest 1", "Pell High Priest", 34646, 0, 2091, 0, 0, 0.6f, null, null), 6065, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 1b)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 681, "Fire Pell priest 2", "Pell High Priest", 34647, 0, 2090, 0, 0, 0.6f, null, null), 6066, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 2b)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 682, "Fire Pell priest 3", "Pell High Priest", 34648, 0, 144, 0, 0, 0.6f, null, null), 6067, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell High Priest (Style 3b)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 683, "White Pell Hammer-Guard", "Pell Hammer-Guard", 31043, null, 2092, 0, 0, 1f, null, null), 6068, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, White", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 684, "White Pell Arcanist", "Pell Arcanist", 31046, null, 1612, 0, 0, 1f, null, null), 6069, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, White", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 685, "White Pell Ritualist", "Pell Ritualist", 31042, null, 2090, 0, 0, 1f, null, null), 6070, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, White", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 686, "White Pell Summoner", "Pell Summoner", 31039, null, 2091, 0, 0, 1f, null, null), 6071, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, White", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 687, "White Pell Blade-Guard", "Pell Blade-Guard", 31040, null, 2089, 0, 0, 1f, null, null), 6072, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, White", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 688, "White Pell Hammer-Guard", "Pell Hammer-Guard", 31043, null, 2092, 21571, 151, 1f, null, null), 6073, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, White (Alert)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 689, "White Pell Arcanist", "Pell Arcanist", 31046, null, 1612, 21571, 151, 1f, null, null), 6074, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, White (Alert)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 690, "White Pell Ritualist", "Pell Ritualist", 31042, null, 2090, 21571, 6008, 1f, null, null), 6075, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, White (Channeling)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 691, "White Pell Summoner", "Pell Summoner", 31039, null, 2091, 25402, 6069, 1f, null, null), 6076, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, White (Channeling)", 11);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 692, "White Pell Blade-Guard", "Pell Blade-Guard", 31040, null, 2089, 17728, 151, 1f, null, null), 6077, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, White (Alert)", 11);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 693, "Granok Male 1", "Granok Civilian", 28351, 9931, 0, 0, 0, 1f, null, null), 6078, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 694, "Granok Male 2", "Granok Civilian", 26330, 9720, 0, 0, 0, 1f, null, null), 6079, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 695, "Granok Male 3", "Granok Civilian", 24358, 9869, 0, 0, 0, 1f, null, null), 6080, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 696, "Granok Male 4", "Granok Civilian", 25162, 9459, 0, 0, 0, 1f, null, null), 6081, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Male, Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 697, "Granok Male 5", "Granok Civilian", 24081, 8477, 0, 0, 0, 1f, null, null), 6082, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Male, Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 698, "Granok Male 6", "Granok Civilian", 24438, 9928, 0, 0, 0, 1f, null, null), 6083, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Male, Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 699, "Granok Male 7", "Granok Civilian", 24715, 8757, 0, 0, 0, 1f, null, null), 6084, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Male, Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 700, "Granok Female 1", "Granok Civilian", 34764, 8416, 0, 0, 0, 1f, null, null), 6085, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 701, "Granok Female 2", "Granok Civilian", 41222, 9720, 0, 0, 0, 1f, null, null), 6086, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 702, "Granok Female 3", "Granok Civilian", 39612, 9869, 0, 0, 0, 1f, null, null), 6087, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 703, "Granok Female 4", "Granok Civilian", 41303, 9459, 0, 0, 0, 1f, null, null), 6088, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Female, Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 704, "Granok Female 5", "Granok Civilian", 28040, 8477, 0, 0, 0, 1f, null, null), 6089, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Female, Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 705, "Granok Female 6", "Granok Civilian", 36055, 9928, 0, 0, 0, 1f, null, null), 6090, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Female, Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 706, "Granok Female 7", "Granok Civilian", 34766, 8757, 0, 0, 0, 1f, null, null), 6091, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian (Female, Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 707, "Granok Male Chair Sit 1", "Granok Civilian", 28351, 9931, 0, 0, 7707, 1f, null, null), 6092, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 708, "Granok Male Chair Sit 2", "Granok Civilian", 26330, 9720, 0, 0, 7707, 1f, null, null), 6093, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 709, "Granok Male Chair Sit 3", "Granok Civilian", 24358, 9869, 0, 0, 7707, 1f, null, null), 6094, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 710, "Granok Male Chair Sit 4", "Granok Civilian", 25162, 9459, 0, 0, 7707, 1f, null, null), 6095, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Male, Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 711, "Granok Male Chair Sit 5", "Granok Civilian", 24081, 8477, 0, 0, 7707, 1f, null, null), 6096, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Male, Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 712, "Granok Male Chair Sit 6", "Granok Civilian", 24438, 9928, 0, 0, 7707, 1f, null, null), 6097, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Male, Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 713, "Granok Male Chair Sit 7", "Granok Civilian", 24715, 8757, 0, 0, 7707, 1f, null, null), 6098, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Male, Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 714, "Granok Female Chair Sit 1", "Granok Civilian", 34764, 8416, 0, 0, 7707, 1f, null, null), 6099, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 715, "Granok Female Chair Sit 2", "Granok Civilian", 41222, 9720, 0, 0, 7707, 1f, null, null), 6100, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 716, "Granok Female Chair Sit 3", "Granok Civilian", 39612, 9869, 0, 0, 7707, 1f, null, null), 6101, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 717, "Granok Female Chair Sit 4", "Granok Civilian", 41303, 9459, 0, 0, 7707, 1f, null, null), 6102, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Female, Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 718, "Granok Female Chair Sit 5", "Granok Civilian", 28040, 8477, 0, 0, 7707, 1f, null, null), 6103, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Female, Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 719, "Granok Female Chair Sit 6", "Granok Civilian", 36055, 9928, 0, 0, 7707, 1f, null, null), 6104, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Female, Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 720, "Granok Female Chair Sit 7", "Granok Civilian", 34766, 8757, 0, 0, 7707, 1f, null, null), 6105, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Civilian, Chair Sit (Female, Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 721, "Chua 1", "Chua Civilian", 38970, 10250, 0, 0, 0, 1f, null, null), 6106, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Chua Civilian (Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 722, "Chua 2", "Chua Civilian", 36026, 8496, 0, 0, 0, 1f, null, null), 6107, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "Chua Civilian (Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 723, "Chua 3", "Chua Civilian", 36027, 8477, 0, 0, 0, 1f, null, null), 6108, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "Chua Civilian (Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 724, "Chua 4", "Chua Civilian", 38819, 8229, 0, 0, 0, 1f, null, null), 6109, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "Chua Civilian (Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 725, "Chua 5", "Chua Civilian", 30442, 8416, 0, 0, 0, 1f, null, null), 6110, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "Chua Civilian (Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 726, "Chua 6", "Chua Civilian", 30344, 9694, 0, 0, 0, 1f, null, null), 6111, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "Chua Civilian (Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 727, "Chua 7", "Chua Civilian", 30857, 10533, 0, 0, 0, 1f, null, null), 6112, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m9", "Chua Civilian (Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 728, "Chua Chair Sit 1", "Chua Civilian", 38970, 10250, 0, 0, 7707, 1f, null, null), 6113, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Chua Civilian, Chair Sit (Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 729, "Chua Chair Sit 2", "Chua Civilian", 36026, 8496, 0, 0, 7707, 1f, null, null), 6114, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "Chua Civilian, Chair Sit (Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 730, "Chua Chair Sit 3", "Chua Civilian", 36027, 8477, 0, 0, 7707, 1f, null, null), 6115, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "Chua Civilian, Chair Sit (Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 731, "Chua Chair Sit 4", "Chua Civilian", 38819, 8229, 0, 0, 7707, 1f, null, null), 6116, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "Chua Civilian, Chair Sit (Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 732, "Chua Chair Sit 5", "Chua Civilian", 30442, 8416, 0, 0, 7707, 1f, null, null), 6117, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "Chua Civilian, Chair Sit (Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 733, "Chua Chair Sit 6", "Chua Civilian", 30344, 9694, 0, 0, 7707, 1f, null, null), 6118, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "Chua Civilian, Chair Sit (Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 734, "Chua Chair Sit 7", "Chua Civilian", 30857, 10533, 0, 0, 7707, 1f, null, null), 6119, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m9", "Chua Civilian, Chair Sit (Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 735, "Mordesh Male 1", "Mordesh Civilian", 26016, 9928, 0, 0, 0, 1f, null, null), 6120, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 736, "Mordesh Male 2", "Mordesh Civilian", 28355, 8758, 0, 0, 0, 1f, null, null), 6121, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 737, "Mordesh Male 3", "Mordesh Civilian", 31867, 8755, 0, 0, 0, 1f, null, null), 6122, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 738, "Mordesh Male 4", "Mordesh Civilian", 39614, 9694, 0, 0, 0, 1f, null, null), 6123, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Male, Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 739, "Mordesh Male 5", "Mordesh Civilian", 35001, 8757, 0, 0, 0, 1f, null, null), 6124, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Male, Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 740, "Mordesh Male 6", "Mordesh Civilian", 35002, 10533, 0, 0, 0, 1f, null, null), 6125, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Male, Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 741, "Mordesh Male 7", "Mordesh Civilian", 34899, 10667, 0, 0, 0, 1f, null, null), 6126, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Male, Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 742, "Mordesh Female 1", "Mordesh Civilian", 41224, 9928, 0, 0, 0, 1f, null, null), 6127, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 743, "Mordesh Female 2", "Mordesh Civilian", 41142, 8758, 0, 0, 0, 1f, null, null), 6128, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 744, "Mordesh Female 3", "Mordesh Civilian", 33190, 9694, 0, 0, 0, 1f, null, null), 6129, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 745, "Mordesh Female 4", "Mordesh Civilian", 34816, 8755, 0, 0, 0, 1f, null, null), 6130, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Female, Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 746, "Mordesh Female 5", "Mordesh Civilian", 40919, 8757, 0, 0, 0, 1f, null, null), 6131, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Female, Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 747, "Mordesh Female 6", "Mordesh Civilian", 36298, 10533, 0, 0, 0, 1f, null, null), 6132, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Female, Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 748, "Mordesh Female 7", "Mordesh Civilian", 41153, 10667, 0, 0, 0, 1f, null, null), 6133, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian (Female, Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 749, "Mordesh Male Chair Sit 1", "Mordesh Civilian", 26016, 9928, 0, 0, 7707, 1f, null, null), 6134, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 750, "Mordesh Male Chair Sit 2", "Mordesh Civilian", 28355, 8758, 0, 0, 7707, 1f, null, null), 6135, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 751, "Mordesh Male Chair Sit 3", "Mordesh Civilian", 31867, 8755, 0, 0, 7707, 1f, null, null), 6136, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 752, "Mordesh Male Chair Sit 4", "Mordesh Civilian", 39614, 9694, 0, 0, 7707, 1f, null, null), 6137, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Male, Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 753, "Mordesh Male Chair Sit 5", "Mordesh Civilian", 35001, 8757, 0, 0, 7707, 1f, null, null), 6138, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Male, Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 754, "Mordesh Male Chair Sit 6", "Mordesh Civilian", 35002, 10533, 0, 0, 7707, 1f, null, null), 6139, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Male, Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 755, "Mordesh Male Chair Sit 7", "Mordesh Civilian", 34899, 10667, 0, 0, 7707, 1f, null, null), 6140, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Male, Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 756, "Mordesh Female Chair Sit 1", "Mordesh Civilian", 41224, 9928, 0, 0, 7707, 1f, null, null), 6141, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 757, "Mordesh Female Chair Sit 2", "Mordesh Civilian", 41142, 8758, 0, 0, 7707, 1f, null, null), 6142, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 758, "Mordesh Female Chair Sit 3", "Mordesh Civilian", 33190, 9694, 0, 0, 7707, 1f, null, null), 6143, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 759, "Mordesh Female Chair Sit 4", "Mordesh Civilian", 34816, 8755, 0, 0, 7707, 1f, null, null), 6144, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Female, Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 760, "Mordesh Female Chair Sit 5", "Mordesh Civilian", 40919, 8757, 0, 0, 7707, 1f, null, null), 6145, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Female, Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 761, "Mordesh Female Chair Sit 6", "Mordesh Civilian", 36298, 10533, 0, 0, 7707, 1f, null, null), 6146, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Female, Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 762, "Mordesh Female Chair Sit 7", "Mordesh Civilian", 41153, 10667, 0, 0, 7707, 1f, null, null), 6147, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Civilian, Chair Sit (Female, Style 7)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 763, "Granok Tradesman Male 1", "Tradesman", 28351, 9726, 0, 0, 0, 1f, null, null), 6148, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Tradesman (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 764, "Granok Tradesman Male 2", "Tradesman", 26330, 9726, 0, 0, 0, 1f, null, null), 6149, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Tradesman (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 765, "Granok Tradesman Male 3", "Tradesman", 24358, 9726, 0, 0, 0, 1f, null, null), 6150, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Tradesman (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 766, "Granok Tradesman Female 1", "Tradesman", 34764, 9726, 0, 0, 0, 1f, null, null), 6151, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Tradesman (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 767, "Granok Tradesman Female 2", "Tradesman", 41222, 9726, 0, 0, 0, 1f, null, null), 6152, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Tradesman (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 768, "Granok Tradesman Female 3", "Tradesman", 39612, 9726, 0, 0, 0, 1f, null, null), 6153, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Tradesman (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 769, "Chua Tradesman 1", "Tradesman", 38970, 10505, 0, 0, 0, 1f, null, null), 6154, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Chua Tradesman (Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 770, "Chua Tradesman 2", "Tradesman", 36026, 10505, 0, 0, 0, 1f, null, null), 6155, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "Chua Tradesman (Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 771, "Chua Tradesman 3", "Tradesman", 36027, 10505, 0, 0, 0, 1f, null, null), 6156, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "Chua Tradesman (Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 772, "Chua Tradesman 4", "Tradesman", 38819, 10505, 0, 0, 0, 1f, null, null), 6157, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "Chua Tradesman (Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 773, "Chua Tradesman 5", "Tradesman", 30442, 10505, 0, 0, 0, 1f, null, null), 6158, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "Chua Tradesman (Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 774, "Chua Tradesman 6", "Tradesman", 30344, 10505, 0, 0, 0, 1f, null, null), 6159, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "Chua Tradesman (Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 775, "Mordesh Tradesman Male 1", "Tradesman", 26016, 9726, 0, 0, 0, 1f, null, null), 6160, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Tradesman (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 776, "Mordesh Tradesman Male 2", "Tradesman", 28355, 9726, 0, 0, 0, 1f, null, null), 6161, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Tradesman (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 777, "Mordesh Tradesman Male 3", "Tradesman", 31867, 9726, 0, 0, 0, 1f, null, null), 6162, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Tradesman (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 778, "Mordesh Tradesman Female 1", "Tradesman", 41224, 9726, 0, 0, 0, 1f, null, null), 6163, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Tradesman (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 779, "Mordesh Tradesman Female 2", "Tradesman", 41142, 9726, 0, 0, 0, 1f, null, null), 6164, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Tradesman (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 780, "Mordesh Tradesman Female 3", "Tradesman", 33190, 9726, 0, 0, 0, 1f, null, null), 6165, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Tradesman (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 781, "Granok Mechanic Male 1", "Mechanic", 24081, 9735, 39, 0, 0, 1f, null, null), 6166, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Mechanic (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 782, "Granok Mechanic Male 2", "Mechanic", 24438, 9735, 39, 0, 0, 1f, null, null), 6167, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Mechanic (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 783, "Granok Mechanic Male 3", "Mechanic", 24715, 9735, 39, 0, 0, 1f, null, null), 6168, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Mechanic (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 784, "Granok Mechanic Female 1", "Mechanic", 28040, 9735, 39, 0, 0, 1f, null, null), 6169, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Mechanic (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 785, "Granok Mechanic Female 2", "Mechanic", 36055, 9735, 39, 0, 0, 1f, null, null), 6170, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Mechanic (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 786, "Granok Mechanic Female 3", "Mechanic", 34766, 9735, 39, 0, 0, 1f, null, null), 6171, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Mechanic (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 787, "Chua Mechanic 1", "Mechanic", 36026, 10110, 39, 0, 0, 1f, null, null), 6172, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "Chua Mechanic (Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 788, "Chua Mechanic 2", "Mechanic", 36027, 10110, 39, 0, 0, 1f, null, null), 6173, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "Chua Mechanic (Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 789, "Chua Mechanic 3", "Mechanic", 38819, 10110, 39, 0, 0, 1f, null, null), 6174, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "Chua Mechanic (Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 790, "Chua Mechanic 4", "Mechanic", 30442, 10110, 39, 0, 0, 1f, null, null), 6175, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "Chua Mechanic (Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 791, "Chua Mechanic 5", "Mechanic", 30344, 10110, 39, 0, 0, 1f, null, null), 6176, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "Chua Mechanic (Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 792, "Chua Mechanic 6", "Mechanic", 30857, 10110, 39, 0, 0, 1f, null, null), 6177, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m9", "Chua Mechanic (Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 793, "Mordesh Mechanic Male 1", "Mechanic", 35001, 9735, 39, 0, 0, 1f, null, null), 6178, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Mechanic (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 794, "Mordesh Mechanic Male 2", "Mechanic", 35002, 9735, 39, 0, 0, 1f, null, null), 6179, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Mechanic (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 795, "Mordesh Mechanic Male 3", "Mechanic", 34899, 9735, 39, 0, 0, 1f, null, null), 6180, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Mechanic (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 796, "Mordesh Mechanic Female 1", "Mechanic", 40919, 9735, 39, 0, 0, 1f, null, null), 6181, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Mechanic (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 797, "Mordesh Mechanic Female 2", "Mechanic", 36298, 9735, 39, 0, 0, 1f, null, null), 6182, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Mechanic (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 798, "Mordesh Mechanic Female 3", "Mechanic", 41153, 9735, 39, 0, 0, 1f, null, null), 6183, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Mechanic (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 799, "Granok Security Guard Male 1", "Security Guard", 24358, 8659, 594, 0, 0, 1f, null, null), 6184, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Security Guard (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 800, "Granok Security Guard Male 2", "Security Guard", 25162, 8659, 594, 0, 0, 1f, null, null), 6185, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Security Guard (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 801, "Granok Security Guard Male 3", "Security Guard", 24081, 8659, 594, 0, 0, 1f, null, null), 6186, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Security Guard (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 802, "Granok Security Guard Female 1", "Security Guard", 39612, 8659, 594, 0, 0, 1f, null, null), 6187, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Security Guard (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 803, "Granok Security Guard Female 2", "Security Guard", 41303, 8659, 594, 0, 0, 1f, null, null), 6188, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Security Guard (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 804, "Granok Security Guard Female 3", "Security Guard", 28040, 8659, 594, 0, 0, 1f, null, null), 6189, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Security Guard (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 805, "Chua Security Guard 1", "Security Guard", 38970, 8471, 149, 0, 0, 1f, null, null), 6190, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Chua Security Guard (Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 806, "Chua Security Guard 2", "Security Guard", 36026, 8471, 149, 0, 0, 1f, null, null), 6191, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "Chua Security Guard (Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 807, "Chua Security Guard 3", "Security Guard", 36027, 8471, 149, 0, 0, 1f, null, null), 6192, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "Chua Security Guard (Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 808, "Chua Security Guard 4", "Security Guard", 38819, 8471, 149, 0, 0, 1f, null, null), 6193, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "Chua Security Guard (Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 809, "Chua Security Guard 5", "Security Guard", 30442, 8471, 149, 0, 0, 1f, null, null), 6194, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "Chua Security Guard (Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 810, "Chua Security Guard 6", "Security Guard", 30344, 8471, 149, 0, 0, 1f, null, null), 6195, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "Chua Security Guard (Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 811, "Mordesh Security Guard Male 1", "Security Guard", 31867, 8659, 594, 0, 0, 1f, null, null), 6196, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Security Guard (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 812, "Mordesh Security Guard Male 2", "Security Guard", 39614, 8659, 594, 0, 0, 1f, null, null), 6197, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Security Guard (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 813, "Mordesh Security Guard Male 3", "Security Guard", 35001, 8659, 594, 0, 0, 1f, null, null), 6198, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Security Guard (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 814, "Mordesh Security Guard Female 1", "Security Guard", 33190, 8659, 594, 0, 0, 1f, null, null), 6199, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Security Guard (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 815, "Mordesh Security Guard Female 2", "Security Guard", 34816, 8659, 594, 0, 0, 1f, null, null), 6200, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Security Guard (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 816, "Mordesh Security Guard Female 3", "Security Guard", 40919, 8659, 594, 0, 0, 1f, null, null), 6201, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Security Guard (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 817, "Granok Server Male 1", "Serving Staffer", 28351, 8379, 0, 0, 0, 1f, null, null), 6202, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Server (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 818, "Granok Server Male 2", "Serving Staffer", 26330, 8379, 0, 0, 0, 1f, null, null), 6203, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Server (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 819, "Granok Server Male 3", "Serving Staffer", 24358, 8379, 0, 0, 0, 1f, null, null), 6204, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Server (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 820, "Granok Server Female 1", "Serving Staffer", 34764, 8379, 0, 0, 0, 1f, null, null), 6205, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Server (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 821, "Granok Server Female 2", "Serving Staffer", 41222, 8379, 0, 0, 0, 1f, null, null), 6206, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Server (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 822, "Granok Server Female 3", "Serving Staffer", 39612, 8379, 0, 0, 0, 1f, null, null), 6207, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Granok Server (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 823, "Chua Server 1", "Serving Staffer", 38970, 8466, 0, 0, 0, 1f, null, null), 6208, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "Chua Server (Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 824, "Chua Server 2", "Serving Staffer", 36026, 8466, 0, 0, 0, 1f, null, null), 6209, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "Chua Server (Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 825, "Chua Server 3", "Serving Staffer", 36027, 8466, 0, 0, 0, 1f, null, null), 6210, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "Chua Server (Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 826, "Chua Server 4", "Serving Staffer", 38819, 8466, 0, 0, 0, 1f, null, null), 6211, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "Chua Server (Style 4)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 827, "Chua Server 5", "Serving Staffer", 30442, 8466, 0, 0, 0, 1f, null, null), 6212, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "Chua Server (Style 5)", 12);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 828, "Chua Server 6", "Serving Staffer", 30344, 8466, 0, 0, 0, 1f, null, null), 6213, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "Chua Server (Style 6)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 829, "Mordesh Server Male 1", "Serving Staffer", 26016, 8379, 0, 0, 0, 1f, null, null), 6214, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Server (Male, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 830, "Mordesh Server Male 2", "Serving Staffer", 28355, 8379, 0, 0, 0, 1f, null, null), 6215, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Server (Male, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 831, "Mordesh Server Male 3", "Serving Staffer", 31867, 8379, 0, 0, 0, 1f, null, null), 6216, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Server (Male, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 832, "Mordesh Server Female 1", "Serving Staffer", 41224, 8379, 0, 0, 0, 1f, null, null), 6217, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Server (Female, Style 1)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 833, "Mordesh Server Female 2", "Serving Staffer", 41142, 8379, 0, 0, 0, 1f, null, null), 6218, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Server (Female, Style 2)", 12);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 834, "Mordesh Server Female 3", "Serving Staffer", 33190, 8379, 0, 0, 0, 1f, null, null), 6219, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "Mordesh Server (Female, Style 3)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 835, "White Pell 1a", "Pell Villager", 42477, 0, 0, 0, 0, 1f, null, null), 6220, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 1a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 836, "White Pell 2a", "Pell Villager", 42478, 0, 0, 0, 0, 1f, null, null), 6221, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 2a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 837, "White Pell 3a", "Pell Villager", 42479, 0, 0, 0, 0, 1f, null, null), 6222, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 3a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 838, "Armored White Pell 1a", "Pell Villager", 42480, 0, 0, 0, 0, 1f, null, null), 6223, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 1a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 839, "Armored White Pell 2a", "Pell Villager", 42481, 0, 0, 0, 0, 1f, null, null), 6224, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 2a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 840, "Armored White Pell 3a", "Pell Villager", 42482, 0, 0, 0, 0, 1f, null, null), 6225, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 3a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 841, "Armored White Pell 4a", "Pell Villager", 42483, 0, 0, 0, 0, 1f, null, null), 6226, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 4a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 842, "White Pell 1b", "Pell Villager", 42484, 0, 0, 0, 0, 1f, null, null), 6227, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 1b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 843, "White Pell 2b", "Pell Villager", 42485, 0, 0, 0, 0, 1f, null, null), 6228, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 2b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 844, "White Pell 3b", "Pell Villager", 42486, 0, 0, 0, 0, 1f, null, null), 6229, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, White (Style 3b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 845, "Armored White Pell 1b", "Pell Villager", 42487, 0, 0, 0, 0, 1f, null, null), 6230, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 1b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 846, "Armored White Pell 2b", "Pell Villager", 42488, 0, 0, 0, 0, 1f, null, null), 6231, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 2b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 847, "Armored White Pell 3b", "Pell Villager", 42489, 0, 0, 0, 0, 1f, null, null), 6232, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 3b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 848, "Armored White Pell 4b", "Pell Villager", 42490, 0, 0, 0, 0, 1f, null, null), 6233, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, White (Style 4b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 849, "Brown Pell 1a", "Pell Villager", 42491, 0, 0, 0, 0, 1f, null, null), 6234, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 1a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 850, "Brown Pell 2a", "Pell Villager", 42492, 0, 0, 0, 0, 1f, null, null), 6235, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 2a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 851, "Brown Pell 3a", "Pell Villager", 42493, 0, 0, 0, 0, 1f, null, null), 6236, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 3a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 852, "Brown Pell 4a", "Pell Villager", 42494, 0, 0, 0, 0, 1f, null, null), 6237, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 4a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 853, "Armored Brown Pell 1a", "Pell Villager", 42495, 0, 0, 0, 0, 1f, null, null), 6238, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 1a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 854, "Armored Brown Pell 2a", "Pell Villager", 42496, 0, 0, 0, 0, 1f, null, null), 6239, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 2a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 855, "Armored Brown Pell 3a", "Pell Villager", 42497, 0, 0, 0, 0, 1f, null, null), 6240, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 3a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 856, "Armored Brown Pell 4a", "Pell Villager", 42498, 0, 0, 0, 0, 1f, null, null), 6241, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 4a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 857, "Brown Pell 1b", "Pell Villager", 42499, 0, 0, 0, 0, 1f, null, null), 6242, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 1b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 858, "Brown Pell 2b", "Pell Villager", 42500, 0, 0, 0, 0, 1f, null, null), 6243, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 2b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 859, "Brown Pell 3b", "Pell Villager", 42501, 0, 0, 0, 0, 1f, null, null), 6244, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 3b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 860, "Brown Pell 4b", "Pell Villager", 42502, 0, 0, 0, 0, 1f, null, null), 6245, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Brown (Style 4b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 861, "Armored Brown Pell 1b", "Pell Villager", 42503, 0, 0, 0, 0, 1f, null, null), 6246, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 1b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 862, "Armored Brown Pell 2b", "Pell Villager", 42504, 0, 0, 0, 0, 1f, null, null), 6247, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 2b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 863, "Armored Brown Pell 3b", "Pell Villager", 42505, 0, 0, 0, 0, 1f, null, null), 6248, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 3b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 864, "Armored Brown Pell 4b", "Pell Villager", 42506, 0, 0, 0, 0, 1f, null, null), 6249, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Brown (Style 4b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 865, "Grey Pell 1a", "Pell Villager", 42507, 0, 0, 0, 0, 1f, null, null), 6250, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 1a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 866, "Grey Pell 2a", "Pell Villager", 42508, 0, 0, 0, 0, 1f, null, null), 6251, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 2a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 867, "Grey Pell 3a", "Pell Villager", 42509, 0, 0, 0, 0, 1f, null, null), 6252, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 3a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 868, "Grey Pell 4a", "Pell Villager", 42510, 0, 0, 0, 0, 1f, null, null), 6253, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 4a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 869, "Armored Grey Pell 1a", "Pell Villager", 42511, 0, 0, 0, 0, 1f, null, null), 6254, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 1a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 870, "Armored Grey Pell 2a", "Pell Villager", 42512, 0, 0, 0, 0, 1f, null, null), 6255, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 2a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 871, "Armored Grey Pell 3a", "Pell Villager", 42513, 0, 0, 0, 0, 1f, null, null), 6256, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 3a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 872, "Armored Grey Pell 4a", "Pell Villager", 42514, 0, 0, 0, 0, 1f, null, null), 6257, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 4a)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 873, "Grey Pell 1b", "Pell Villager", 42515, 0, 0, 0, 0, 1f, null, null), 6258, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 1b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 874, "Grey Pell 2b", "Pell Villager", 42516, 0, 0, 0, 0, 1f, null, null), 6259, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 2b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 875, "Grey Pell 3b", "Pell Villager", 42517, 0, 0, 0, 0, 1f, null, null), 6260, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 3b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 876, "Grey Pell 4b", "Pell Villager", 42518, 0, 0, 0, 0, 1f, null, null), 6261, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell, Grey (Style 4b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 877, "Armored Grey Pell 1b", "Pell Villager", 42519, 0, 0, 0, 0, 1f, null, null), 6262, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 1b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 878, "Armored Grey Pell 2b", "Pell Villager", 42520, 0, 0, 0, 0, 1f, null, null), 6263, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 2b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 879, "Armored Grey Pell 3b", "Pell Villager", 42521, 0, 0, 0, 0, 1f, null, null), 6264, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 3b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 880, "Armored Grey Pell 4b", "Pell Villager", 42522, 0, 0, 0, 0, 1f, null, null), 6265, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Armored Pell, Grey (Style 4b)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 881, "White Pell Hammer-Guard A", "Pell Hammer-Guard", 42483, null, 2092, 0, 0, 1f, null, null), 6266, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, White (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 882, "White Pell Arcanist A", "Pell Arcanist", 42480, null, 1612, 0, 0, 1f, null, null), 6267, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, White (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 883, "White Pell Ritualist A", "Pell Ritualist", 42477, null, 2090, 0, 0, 1f, null, null), 6268, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, White (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 884, "White Pell Summoner A", "Pell Summoner", 42478, null, 2091, 0, 0, 1f, null, null), 6269, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, White (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 885, "White Pell Blade-Guard A", "Pell Blade-Guard", 42482, null, 2089, 0, 0, 1f, null, null), 6270, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, White (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 886, "White Pell Hammer-Guard A", "Pell Hammer-Guard", 42483, null, 2092, 21797, 151, 1f, null, null), 6271, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, White (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 887, "White Pell Arcanist A", "Pell Arcanist", 42480, null, 1612, 21797, 151, 1f, null, null), 6272, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, White (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 888, "White Pell Ritualist A", "Pell Ritualist", 42477, null, 2090, 25402, 6008, 1f, null, null), 6273, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, White (Channeling, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 889, "White Pell Summoner A", "Pell Summoner", 42478, null, 2091, 23547, 6069, 1f, null, null), 6274, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, White (Channeling, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 890, "White Pell Blade-Guard A", "Pell Blade-Guard", 42482, null, 2089, 17728, 151, 1f, null, null), 6275, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, White (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 891, "White Pell Hammer-Guard B", "Pell Hammer-Guard", 42490, null, 2092, 0, 0, 1f, null, null), 6276, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, White (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 892, "White Pell Arcanist B", "Pell Arcanist", 42487, null, 1612, 0, 0, 1f, null, null), 6277, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, White (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 893, "White Pell Ritualist B", "Pell Ritualist", 42484, null, 2090, 0, 0, 1f, null, null), 6278, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, White (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 894, "White Pell Summoner B", "Pell Summoner", 42485, null, 2091, 0, 0, 1f, null, null), 6279, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, White (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 895, "White Pell Blade-Guard B", "Pell Blade-Guard", 42489, null, 2089, 0, 0, 1f, null, null), 6280, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, White (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 896, "White Pell Hammer-Guard B", "Pell Hammer-Guard", 42490, null, 2092, 21839, 151, 1f, null, null), 6281, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, White (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 897, "White Pell Arcanist B", "Pell Arcanist", 42487, null, 1612, 21839, 151, 1f, null, null), 6282, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, White (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 898, "White Pell Ritualist B", "Pell Ritualist", 42484, null, 2090, 17761, 6008, 1f, null, null), 6283, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, White (Channeling, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 899, "White Pell Summoner B", "Pell Summoner", 42485, null, 2091, 25403, 6069, 1f, null, null), 6284, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, White (Channeling, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 900, "White Pell Blade-Guard B", "Pell Blade-Guard", 42489, null, 2089, 17725, 151, 1f, null, null), 6285, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, White (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 901, "Brown Pell Hammer-Guard A", "Pell Hammer-Guard", 42498, null, 2092, 0, 0, 1f, null, null), 6286, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Brown (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 902, "Brown Pell Arcanist A", "Pell Arcanist", 42495, null, 1612, 0, 0, 1f, null, null), 6287, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Brown (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 903, "Brown Pell Ritualist A", "Pell Ritualist", 42493, null, 2090, 0, 0, 1f, null, null), 6288, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Brown (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 904, "Brown Pell Summoner A", "Pell Summoner", 42492, null, 2091, 0, 0, 1f, null, null), 6289, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Brown (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 905, "Brown Pell Blade-Guard A", "Pell Blade-Guard", 42498, null, 2089, 0, 0, 1f, null, null), 6290, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Brown (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 906, "Brown Pell Hammer-Guard A", "Pell Hammer-Guard", 42498, null, 2092, 21839, 151, 1f, null, null), 6291, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Brown (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 907, "Brown Pell Arcanist A", "Pell Arcanist", 42495, null, 1612, 17725, 151, 1f, null, null), 6292, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Brown (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 908, "Brown Pell Ritualist A", "Pell Ritualist", 42493, null, 2090, 17761, 6008, 1f, null, null), 6293, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Brown (Channeling, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 909, "Brown Pell Summoner A", "Pell Summoner", 42492, null, 2091, 25403, 6069, 1f, null, null), 6294, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Brown (Channeling, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 910, "Brown Pell Blade-Guard A", "Pell Blade-Guard", 42498, null, 2089, 21574, 151, 1f, null, null), 6295, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Brown (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 911, "Brown Pell Hammer-Guard B", "Pell Hammer-Guard", 42506, null, 2092, 0, 0, 1f, null, null), 6296, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Brown (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 912, "Brown Pell Arcanist B", "Pell Arcanist", 42503, null, 1612, 0, 0, 1f, null, null), 6297, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Brown (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 913, "Brown Pell Ritualist B", "Pell Ritualist", 42501, null, 2090, 0, 0, 1f, null, null), 6298, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Brown (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 914, "Brown Pell Summoner B", "Pell Summoner", 42500, null, 2091, 0, 0, 1f, null, null), 6299, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Brown (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 915, "Brown Pell Blade-Guard B", "Pell Blade-Guard", 42505, null, 2089, 0, 0, 1f, null, null), 6300, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Brown (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 916, "Brown Pell Hammer-Guard B", "Pell Hammer-Guard", 42506, null, 2092, 21571, 151, 1f, null, null), 6301, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Brown (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 917, "Brown Pell Arcanist B", "Pell Arcanist", 42503, null, 1612, 21571, 151, 1f, null, null), 6302, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Brown (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 918, "Brown Pell Ritualist B", "Pell Ritualist", 42501, null, 2090, 21571, 6008, 1f, null, null), 6303, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Brown (Channeling, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 919, "Brown Pell Summoner B", "Pell Summoner", 42500, null, 2091, 25402, 6069, 1f, null, null), 6304, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Brown (Channeling, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 920, "Brown Pell Blade-Guard B", "Pell Blade-Guard", 42505, null, 2089, 17728, 151, 1f, null, null), 6305, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Brown (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 921, "Grey Pell Hammer-Guard A", "Pell Hammer-Guard", 42514, null, 2092, 0, 0, 1f, null, null), 6306, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Grey (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 922, "Grey Pell Arcanist A", "Pell Arcanist", 42511, null, 1612, 0, 0, 1f, null, null), 6307, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Grey (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 923, "Grey Pell Ritualist A", "Pell Ritualist", 42509, null, 2090, 0, 0, 1f, null, null), 6308, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Grey (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 924, "Grey Pell Summoner A", "Pell Summoner", 42508, null, 2091, 0, 0, 1f, null, null), 6309, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Grey (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 925, "Grey Pell Blade-Guard A", "Pell Blade-Guard", 42513, null, 2089, 0, 0, 1f, null, null), 6310, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Grey (Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 926, "Grey Pell Hammer-Guard A", "Pell Hammer-Guard", 42514, null, 2092, 21797, 151, 1f, null, null), 6311, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Grey (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 927, "Grey Pell Arcanist A", "Pell Arcanist", 42511, null, 1612, 17875, 151, 1f, null, null), 6312, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Grey (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 928, "Grey Pell Ritualist A", "Pell Ritualist", 42509, null, 2090, 25402, 6008, 1f, null, null), 6313, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Grey (Channeling, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 929, "Grey Pell Summoner A", "Pell Summoner", 42508, null, 2091, 23547, 6069, 1f, null, null), 6314, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Grey (Channeling, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 930, "Grey Pell Blade-Guard A", "Pell Blade-Guard", 42513, null, 2089, 17875, 151, 1f, null, null), 6315, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Grey (Alert, Style A)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 931, "Grey Pell Hammer-Guard B", "Pell Hammer-Guard", 42522, null, 2092, 0, 0, 1f, null, null), 6316, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Grey (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 932, "Grey Pell Arcanist B", "Pell Arcanist", 42519, null, 1612, 0, 0, 1f, null, null), 6317, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Grey (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 933, "Grey Pell Ritualist B", "Pell Ritualist", 42517, null, 2090, 0, 0, 1f, null, null), 6318, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Grey (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 934, "Grey Pell Summoner B", "Pell Summoner", 42516, null, 2091, 0, 0, 1f, null, null), 6319, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Grey (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 935, "Grey Pell Blade-Guard B", "Pell Blade-Guard", 42521, null, 2089, 0, 0, 1f, null, null), 6320, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Grey (Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 936, "Grey Pell Hammer-Guard B", "Pell Hammer-Guard", 42522, null, 2092, 21571, 151, 1f, null, null), 6321, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Hammer-Guard, Grey (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 937, "Grey Pell Arcanist B", "Pell Arcanist", 42519, null, 1612, 21571, 151, 1f, null, null), 6322, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Arcanist, Grey (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 938, "Grey Pell Ritualist B", "Pell Ritualist", 42517, null, 2090, 21571, 6008, 1f, null, null), 6323, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Ritualist, Grey (Channeling, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 939, "Grey Pell Summoner B", "Pell Summoner", 42516, null, 2091, 25402, 6069, 1f, null, null), 6324, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Summoner, Grey (Channeling, Style B)", 12);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 940, "Grey Pell Blade-Guard B", "Pell Blade-Guard", 42521, null, 2089, 17728, 151, 1f, null, null), 6325, "Art\\Prop\\Constructed\\PellTech\\HangingFlagTrack\\PRP_PellTech_HangingFlagTrack_Aqua_000.m3", "Pell Blade-Guard, Grey (Alert, Style B)", 12);
            AddNPCDecor(2666, AddCreature(69490, startCreature2ID + 941, "Black Chompacabra", "Chompacabra", null, null, null, 0, 0, 1f, null, null), 6326, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Chompacabra, Black", 13);
            AddNPCDecor(2666, AddCreature(69489, startCreature2ID + 942, "Blue Chompacabra", "Chompacabra", null, null, null, 0, 0, 1f, null, null), 6327, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Chompacabra, Blue", 13);
            AddNPCDecor(2666, AddCreature(69486, startCreature2ID + 943, "Dusty Chompacabra", "Chompacabra", null, null, null, 0, 0, 1f, null, null), 6328, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Chompacabra, Dusty", 13);
            AddNPCDecor(2666, AddCreature(69487, startCreature2ID + 944, "Ginger Chompacabra", "Chompacabra", null, null, null, 0, 0, 1f, null, null), 6329, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Chompacabra, Ginger", 13);
            AddNPCDecor(2666, AddCreature(69483, startCreature2ID + 945, "Orange Chompacabra", "Chompacabra", null, null, null, 0, 0, 1f, null, null), 6330, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Chompacabra, Orange", 13);
            AddNPCDecor(2666, AddCreature(69485, startCreature2ID + 946, "Tawny Chompacabra", "Chompacabra", null, null, null, 0, 0, 1f, null, null), 6331, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Chompacabra, Tawny", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 947, "White Chompacabra", "Chompacabra", 27367, null, 0, 0, 0, 1f, null, null), 6332, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Chompacabra, White", 13);
            AddNPCDecor(2666, AddCreature(69492, startCreature2ID + 948, "Blue Darkspur Chompacabra", "Darkspur Chompacabra", null, null, null, 0, 0, 1f, null, null), 6333, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Darkspur Chompacabra, Blue", 13);
            AddNPCDecor(2666, AddCreature(69488, startCreature2ID + 949, "Tawny Darkspur Chompacabra", "Darkspur Chompacabra", null, null, null, 0, 0, 1f, null, null), 6334, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Darkspur Chompacabra, Tawny", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 950, "Black Malverine", "Black Malverine", 31161, null, 0, 0, 0, 1f, null, null), 6335, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Malverine, Black", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 951, "Golden Malverine", "Golden Malverine", 24277, null, 0, 0, 0, 1f, null, null), 6336, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Malverine, Golden", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 952, "Purple Malverine", "Purple Malverine", 28710, null, 0, 0, 0, 1f, null, null), 6337, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Malverine, Purple", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 953, "White Malverine", "White Malverine", 31146, null, 0, 0, 0, 1f, null, null), 6338, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Malverine, White", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 954, "Brown Canimid", "Brown Canimid", 31096, null, 0, 0, 0, 1f, null, null), 6339, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Canimid, Brown", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 955, "Grey Canimid", "Grey Canimid", 31095, null, 0, 0, 0, 1f, null, null), 6340, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Canimid, Grey", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 956, "Red Canimid", "Red Canimid", 24166, null, 0, 0, 0, 1f, null, null), 6341, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Canimid, Red", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 957, "Smoke Canimid", "Smoke Canimid", 31093, null, 0, 0, 0, 1f, null, null), 6342, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Canimid, Smoke", 13);
            AddNPCDecor(2666, AddCreature(69566, startCreature2ID + 958, "Dune Scrab", "Dune Scrab", null, null, null, 0, 0, 1f, null, null), 6343, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Scrab, Dune", 13);
            AddNPCDecor(2666, AddCreature(69567, startCreature2ID + 959, "Crimson Scrab", "Crimson Scrab", null, null, null, 0, 0, 1f, null, null), 6344, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Scrab, Crimson", 13);
            AddNPCDecor(2666, AddCreature(69568, startCreature2ID + 960, "Dreg Scrab", "Dreg Scrab", null, null, null, 0, 0, 1f, null, null), 6345, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Scrab, Dreg", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 961, "Silvershell Scrab", "Silvershell Scrab", 37676, null, 0, 0, 0, 1f, null, null), 6346, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Scrab, Silvershell", 13);
            AddNPCDecor(2666, AddCreature(69530, startCreature2ID + 962, "Honeyhive Buzzbing", "Honeyhive Buzzbing", null, null, null, 0, 0, 1f, null, null), 6347, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Honeyhive", 13);
            AddNPCDecor(2666, AddCreature(69531, startCreature2ID + 963, "Blue Honeyhive Buzzbing", "Blue Honeyhive Buzzbing", null, null, null, 0, 0, 1f, null, null), 6348, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Blue Honeyhive", 13);
            AddNPCDecor(2666, AddCreature(69534, startCreature2ID + 964, "Grey Buzzbing", "Grey Buzzbing", null, null, null, 0, 0, 1f, null, null), 6349, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Grey", 13);
            AddNPCDecor(2666, AddCreature(69535, startCreature2ID + 965, "Purple Buzzbing", "Purple Buzzbing", null, null, null, 0, 0, 1f, null, null), 6350, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Purple", 13);
            AddNPCDecor(2666, AddCreature(69536, startCreature2ID + 966, "Alien Buzzbing", "Alien Buzzbing", null, null, null, 0, 0, 1f, null, null), 6351, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Alien", 13);
            AddNPCDecor(2666, AddCreature(69537, startCreature2ID + 967, "Goldjacket Buzzbing", "Goldjacket Buzzbing", null, null, null, 0, 0, 1f, null, null), 6352, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Goldjacket", 13);
            AddNPCDecor(2666, AddCreature(69540, startCreature2ID + 968, "Chua-Enhanced Buzzbing", "Chua-Enhanced Buzzbing", null, null, null, 0, 0, 1f, null, null), 6353, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Chua-Enhanced", 13);
            AddNPCDecor(2666, AddCreature(69541, startCreature2ID + 969, "Goldshell Buzzbing", "Goldshell Buzzbing", null, null, null, 0, 0, 1f, null, null), 6354, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Goldshell", 13);
            AddNPCDecor(2666, AddCreature(69542, startCreature2ID + 970, "Silvershell Buzzbing", "Silvershell Buzzbing", null, null, null, 0, 0, 1f, null, null), 6355, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Silvershell", 13);
            AddNPCDecor(2666, AddCreature(69538, startCreature2ID + 971, "Bumble Buzzbing", "Bumble Buzzbing", null, null, null, 0, 0, 1f, null, null), 6356, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Buzzbing, Bumble", 13);
            AddNPCDecor(2666, AddCreature(69609, startCreature2ID + 972, "Gold Spider", "Gold Spider", null, null, null, 0, 0, 1f, null, null), 6357, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Spider, Gold", 13);
            AddNPCDecor(2666, AddCreature(69610, startCreature2ID + 973, "BlackRed Spider", "Black Spider", null, null, null, 0, 0, 1f, null, null), 6358, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Spider, Black/Red", 13);
            AddNPCDecor(2666, AddCreature(75520, startCreature2ID + 974, "BlackGreen Spider", "Black Spider", null, null, null, 0, 0, 1f, null, null), 6359, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Spider, Black/Green", 13);
            AddNPCDecor(2666, AddCreature(69613, startCreature2ID + 975, "Silvershell Spider", "Silvershell Spider", null, null, null, 0, 0, 1f, null, null), 6360, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Spider, Silvershell", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 976, "Green Stemdragon", "Green Stemdragon", 23919, null, 0, 0, 0, 1f, null, null), 6361, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Stemdragon, Green", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 977, "Red Stemdragon", "Red Stemdragon", 31151, null, 0, 0, 0, 1f, null, null), 6362, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Stemdragon, Red", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 978, "Logicleaf Stemdragon", "Logicleaf Stemdragon", 37763, null, 0, 0, 0, 1f, null, null), 6363, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Stemdragon, Logicleaf", 13);
            AddNPCDecor(2666, AddCreature(75887, startCreature2ID + 979, "Primeval Stemdragon", "Primeval Stemdragon", null, null, 0, 0, 0, 1f, null, null), 6364, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Stemdragon, Primeval", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 980, "Brown Gorganoth", "Brown Gorganoth", 23905, null, 0, 0, 0, 1f, null, null), 6365, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Gorganoth, Brown", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 981, "Dreg Gorganoth", "Dreg Gorganoth", 29048, null, 0, 0, 0, 1f, null, null), 6366, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Gorganoth, Dreg", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 982, "Undead Gorganoth", "Undead Gorganoth", 28409, null, 0, 23443, 0, 1f, null, null), 6367, "Art\\Prop\\Constructed\\PictureFrames\\Drakken\\PRP_PictureFrame_Drakken_006.m3", "!NEW! Undead Gorganoth", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 983, "Squirg Gorganoth", "Squirg Gorganoth", 36087, null, 0, 0, 0, 1f, null, null), 6368, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Gorganoth, Squirg", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 984, "White Gorganoth", "White Gorganoth", 34430, null, 0, 0, 0, 1f, null, null), 6369, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Gorganoth, White", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 985, "Strain Brute", "Strain Brute", 32310, null, 6597, 0, 0, 1f, null, null), 6370, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Brute", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 986, "Technophage Brute", "Technophage Brute", 34729, null, 6597, 0, 0, 1f, null, null), 6371, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Brute, Technophage", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 987, "Strain Corruptor", "Strain Corruptor", 30985, null, 0, 0, 0, 1f, null, null), 6372, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Corruptor", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 988, "Technophage Corruptor", "Technophage Corruptor", 34717, null, 0, 0, 0, 1f, null, null), 6373, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Corruptor, Technophage", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 989, "Strain Crawler", "Strain Crawler", 24216, null, 0, 0, 0, 1f, null, null), 6374, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Crawler", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 990, "Strain Mauler", "Strain Mauler", 30326, null, 0, 0, 0, 1f, null, null), 6375, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mauler", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 991, "Technophage Mauler", "Technophage Mauler", 34695, null, 0, 0, 0, 1f, null, null), 6376, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mauler, Technophage", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 992, "Strain Peep", "Strain Peep", 31396, null, 0, 0, 0, 1f, null, null), 6377, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Peep", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 993, "Strain Ravager", "Strain Ravager", 24341, null, 0, 0, 0, 1f, null, null), 6378, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Ravager", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 994, "Technophage Ravager", "Technophage Ravager", 34748, null, 0, 0, 0, 1f, null, null), 6379, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Ravager, Technophage", 13);
            AddNPCDecor(2666, AddCreature(69491, startCreature2ID + 995, "Strain Chompacabra", "Strain Chompacabra", null, null, 0, 0, 0, 1f, null, null), 6380, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Chompacabra", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 996, "Strain Malverine", "Strain Malverine", 31595, null, 0, 0, 0, 1f, null, null), 6381, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Malverine", 13);
            AddNPCDecor(2666, AddCreature(69571, startCreature2ID + 997, "Strain Scrab", "Strain Scrab", null, null, null, 0, 0, 1f, null, null), 6382, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Scrab", 13);
            AddNPCDecor(2666, AddCreature(69539, startCreature2ID + 998, "Strain Buzzbing", "Strain Buzzbing", null, null, null, 0, 0, 1f, null, null), 6383, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Buzzbing", 13);
            AddNPCDecor(2666, AddCreature(69612, startCreature2ID + 999, "Strain Spider", "Strain Spider", null, null, null, 0, 0, 1f, null, null), 6384, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Spider", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1000, "Strain Stemdragon", "Strain Stemdragon", 31609, null, 0, 0, 0, 1f, null, null), 6385, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Stemdragon", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1001, "Strain Pumera", "Strain Pumera", 31799, null, null, 0, 0, 1f, null, null), 6386, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Pumera", 13);
            AddNPCDecor(2666, AddCreature(69408, startCreature2ID + 1002, "Strain Dagun", "Strain Dagun", null, null, null, 0, 0, 1f, null, null), 6387, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Dagun", 13);
            AddNPCDecor(2666, AddCreature(69405, startCreature2ID + 1003, "Strain Dawngrazer", "Strain Dawngrazer", null, null, null, 0, 0, 1f, null, null), 6388, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Dawngrazer", 13);
            AddNPCDecor(2666, AddCreature(69523, startCreature2ID + 1004, "Strain Garr", "Strain Garr", null, null, null, 0, 0, 1f, null, null), 6389, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Garr", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1005, "Strain Girrok", "Strain Girrok", 31665, null, 0, 0, 0, 1f, null, null), 6390, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Girrok", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1006, "Strain Pell High Priest", "Strain Pell High Priest", 31829, null, 144, 0, 0, 1f, null, null), 6391, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Pell High Priest", 13);
            AddNPCDecor(2666, AddCreature(69416, startCreature2ID + 1007, "Strain Jabbit", "Strain Jabbit", null, null, null, 0, 0, 1f, null, null), 6392, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Jabbit", 13);
            AddNPCDecor(2666, AddCreature(69457, startCreature2ID + 1008, "Strain Ravenok", "Strain Ravenok", null, null, null, 0, 0, 1f, null, null), 6393, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Ravenok", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1009, "Technophage Skurge", "Technophage Skurge", 24016, null, 0, 0, 0, 1f, null, null), 6394, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Skurge, Technophage", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1010, "Skeledroid Girrok", "Skeledroid Girrok", 31130, null, 0, 0, 0, 1f, null, null), 6395, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Skeledroid Girrok", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1011, "Undead Girrok", "Undead Girrok", 27608, null, 0, 23443, 0, 1f, null, null), 6396, "Art\\Prop\\Constructed\\PictureFrames\\Drakken\\PRP_PictureFrame_Drakken_006.m3", "!NEW! Undead Girrok", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1012, "Augmented Pell 1", "Augmented Pell", 24192, null, 0, 0, 0, 1f, null, null), 6397, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Pell", 13);
            AddNPCDecor(2666, AddCreature(69455, startCreature2ID + 1013, "Augmented Ravenok", "Augmented Ravenok", null, null, null, 0, 0, 1f, null, null), 6398, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Ravenok", 13);
            AddNPCDecor(2666, AddCreature(69474, startCreature2ID + 1014, "Augmented Rowsdower", "Augmented Rowsdower", null, null, null, 0, 0, 1f, null, null), 6399, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Rowsdower", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1015, "Augmented Gorganoth", "Augmented Gorganoth", 31451, null, 0, 0, 0, 1f, null, null), 6400, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Gorganoth", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1016, "Skeledroid Gorganoth", "Skeledroid Gorganoth", 31132, null, 0, 0, 0, 1f, null, null), 6401, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Skeledroid Gorganoth", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1017, "Augmented Stemdragon", "Augmented Stemdragon", 30837, null, 0, 0, 0, 1f, null, null), 6402, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Stemdragon", 13);
            AddNPCDecor(2666, AddCreature(69611, startCreature2ID + 1018, "Augmented Spider", "Augmented Spider", null, null, null, 0, 0, 1f, null, null), 6403, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Spider", 13);
            AddNPCDecor(2666, AddCreature(69532, startCreature2ID + 1019, "Augmented Buzzbing", "Augmented Buzzbing", null, null, null, 0, 0, 1f, null, null), 6404, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Buzzbing", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1020, "Augmented Canimid", "Augmented Canimid", 26650, null, 0, 0, 0, 1f, null, null), 6405, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Canimid", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1021, "Augmented Canimid Red 1", "Augmented Canimid", 26648, null, 0, 0, 0, 1f, null, null), 6406, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Canimid, Red (Style 1)", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1022, "Augmented Canimid Red 2", "Augmented Canimid", 26649, null, 0, 0, 0, 1f, null, null), 6407, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Canimid, Red (Style 2)", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1023, "Augmented Malverine", "Augmented Malverine", 30733, null, 0, 0, 0, 1f, null, null), 6408, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Malverine", 13);
            AddNPCDecor(2666, AddCreature(69415, startCreature2ID + 1024, "Augmented Jabbit", "Augmented Jabbit", null, null, null, 0, 0, 1f, null, null), 6409, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Jabbit", 13);
            AddNPCDecor(2666, AddCreature(69431, startCreature2ID + 1025, "Augmented Pumera", "Augmented Pumera", null, null, null, 0, 0, 1f, null, null), 6410, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Pumera", 13);
            AddNPCDecor(2666, AddCreature(69521, startCreature2ID + 1026, "Augmented Garr", "Augmented Garr", null, null, null, 0, 0, 1f, null, null), 6411, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Garr", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1027, "Zombodroid Gorganoth", "Zombodroid Gorganoth", 31451, null, 0, 23443, 0, 1f, null, null), 6412, "Art\\Prop\\Constructed\\PictureFrames\\Drakken\\PRP_PictureFrame_Drakken_006.m3", "!NEW! Zombodroid Gorganoth", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1028, "Zombodroid Canimid", "Zombodroid Canimid", 26650, null, 0, 23443, 0, 1f, null, null), 6413, "Art\\Prop\\Constructed\\PictureFrames\\Drakken\\PRP_PictureFrame_Drakken_006.m3", "!NEW! Zombodroid Canimid", 13);
            AddNPCDecor(2666, AddCreature(69455, startCreature2ID + 1029, "Zombodroid Ravenok", "Zombodroid Ravenok", null, null, null, 23443, 0, 1f, null, null), 6414, "Art\\Prop\\Constructed\\PictureFrames\\Drakken\\PRP_PictureFrame_Drakken_006.m3", "!NEW! Zombodroid Ravenok", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1030, "Undead Humanoid", "Undead Humanoid", 28277, 9832, 0, 23443, 0, 1f, null, null), 6415, "Art\\Prop\\Constructed\\PictureFrames\\Drakken\\PRP_PictureFrame_Drakken_006.m3", "!NEW! Undead Humanoid", 13);
            AddNPCDecor(2666, AddCreature(73308, startCreature2ID + 1031, "Skeledroid Humanoid", "Skeledroid", 23894, 9831, 0, 0, 0, 1f, null, null), 6416, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Skeledroid Humanoid", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1032, "Augmented Mordesh Male 1", "Augmented Mordesh", 26016, 9479, 0, 0, 0, 1f, null, null), 6417, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mordesh (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1033, "Augmented Mordesh Male 2", "Augmented Mordesh", 28355, 9479, 0, 0, 0, 1f, null, null), 6418, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mordesh (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1034, "Augmented Mordesh Male 3", "Augmented Mordesh", 31867, 9479, 0, 0, 0, 1f, null, null), 6419, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mordesh (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1035, "Augmented Mordesh Female 1", "Augmented Mordesh", 41224, 9479, 0, 0, 0, 1f, null, null), 6420, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mordesh (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1036, "Augmented Mordesh Female 2", "Augmented Mordesh", 41142, 9479, 0, 0, 0, 1f, null, null), 6421, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mordesh (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1037, "Augmented Mordesh Female 3", "Augmented Mordesh", 33190, 9479, 0, 0, 0, 1f, null, null), 6422, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mordesh (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1038, "Augmented Granok Male 1", "Augmented Granok", 28351, 9479, 0, 0, 0, 1f, null, null), 6423, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Granok (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1039, "Augmented Granok Male 2", "Augmented Granok", 26330, 9479, 0, 0, 0, 1f, null, null), 6424, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Granok (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1040, "Augmented Granok Male 3", "Augmented Granok", 24358, 9479, 0, 0, 0, 1f, null, null), 6425, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Granok (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1041, "Augmented Granok Female 1", "Augmented Granok", 34764, 9479, 0, 0, 0, 1f, null, null), 6426, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Granok (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1042, "Augmented Granok Female 2", "Augmented Granok", 41222, 9479, 0, 0, 0, 1f, null, null), 6427, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Granok (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1043, "Augmented Granok Female 3", "Augmented Granok", 39612, 9479, 0, 0, 0, 1f, null, null), 6428, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Granok (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1044, "Augmented Chua 1", "Augmented Chua", 38970, 9479, 0, 0, 0, 1f, null, null), 6429, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Chua (Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1045, "Augmented Chua 2", "Augmented Chua", 36026, 9479, 0, 0, 0, 1f, null, null), 6430, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Chua (Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1046, "Augmented Chua 3", "Augmented Chua", 36027, 9479, 0, 0, 0, 1f, null, null), 6431, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Chua (Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1047, "Augmented Chua 4", "Augmented Chua", 38819, 9479, 0, 0, 0, 1f, null, null), 6432, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Chua (Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1048, "Augmented Chua 5", "Augmented Chua", 30442, 9479, 0, 0, 0, 1f, null, null), 6433, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Chua (Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1049, "Augmented Chua 6", "Augmented Chua", 30344, 9479, 0, 0, 0, 1f, null, null), 6434, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Chua (Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1050, "Augmented Draken Male 1", "Augmented Draken", 39029, 9479, 0, 0, 0, 1f, null, null), 6435, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Draken (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1051, "Augmented Draken Male 2", "Augmented Draken", 39046, 9479, 0, 0, 0, 1f, null, null), 6436, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Draken (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1052, "Augmented Draken Male 3", "Augmented Draken", 28270, 9479, 0, 0, 0, 1f, null, null), 6437, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Draken (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1053, "Augmented Draken Female 1", "Augmented Draken", 39025, 9479, 0, 0, 0, 1f, null, null), 6438, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Draken (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1054, "Augmented Draken Female 2", "Augmented Draken", 39048, 9479, 0, 0, 0, 1f, null, null), 6439, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Draken (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1055, "Augmented Draken Female 3", "Augmented Draken", 25335, 9479, 0, 0, 0, 1f, null, null), 6440, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Draken (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1056, "Augmented Aurin Male 1", "Augmented Aurin", 39036, 9479, 0, 0, 0, 1f, null, null), 6441, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Aurin (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1057, "Augmented Aurin Male 2", "Augmented Aurin", 39609, 9479, 0, 0, 0, 1f, null, null), 6442, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Aurin (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1058, "Augmented Aurin Male 3", "Augmented Aurin", 41150, 9479, 0, 0, 0, 1f, null, null), 6443, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Aurin (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1059, "Augmented Aurin Female 1", "Augmented Aurin", 39037, 9479, 0, 0, 0, 1f, null, null), 6444, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Aurin (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1060, "Augmented Aurin Female 2", "Augmented Aurin", 39611, 9479, 0, 0, 0, 1f, null, null), 6445, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Aurin (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1061, "Augmented Aurin Female 3", "Augmented Aurin", 41213, 9479, 0, 0, 0, 1f, null, null), 6446, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Aurin (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1062, "Augmented Cassian Male 1", "Augmented Cassian", 28323, 9479, 0, 0, 0, 1f, null, null), 6447, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Cassian (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1063, "Augmented Cassian Male 2", "Augmented Cassian", 38818, 9479, 0, 0, 0, 1f, null, null), 6448, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Cassian (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1064, "Augmented Cassian Male 3", "Augmented Cassian", 34859, 9479, 0, 0, 0, 1f, null, null), 6449, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Cassian (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1065, "Augmented Cassian Female 1", "Augmented Cassian", 29475, 9479, 0, 0, 0, 1f, null, null), 6450, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Cassian (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1066, "Augmented Cassian Female 2", "Augmented Cassian", 41300, 9479, 0, 0, 0, 1f, null, null), 6451, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Cassian (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1067, "Augmented Cassian Female 3", "Augmented Cassian", 28324, 9479, 0, 0, 0, 1f, null, null), 6452, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Cassian (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1068, "Augmented Human Male 1", "Augmented Human", 28308, 9479, 0, 0, 0, 1f, null, null), 6453, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Human (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1069, "Augmented Human Male 2", "Augmented Human", 28349, 9479, 0, 0, 0, 1f, null, null), 6454, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Human (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1070, "Augmented Human Male 3", "Augmented Human", 29477, 9479, 0, 0, 0, 1f, null, null), 6455, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Human (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1071, "Augmented Human Female 1", "Augmented Human", 28309, 9479, 0, 0, 0, 1f, null, null), 6456, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Human (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1072, "Augmented Human Female 2", "Augmented Human", 30112, 9479, 0, 0, 0, 1f, null, null), 6457, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Human (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1073, "Augmented Human Female 3", "Augmented Human", 25887, 9479, 0, 0, 0, 1f, null, null), 6458, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Human (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1074, "Strain Mordesh Male 1", "Strain-Corrupted Mordesh", 26016, 10206, 0, 0, 0, 1f, null, null), 6459, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mordesh (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1075, "Strain Mordesh Male 2", "Strain-Corrupted Mordesh", 28355, 10206, 0, 0, 0, 1f, null, null), 6460, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mordesh (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1076, "Strain Mordesh Male 3", "Strain-Corrupted Mordesh", 31867, 10206, 0, 0, 0, 1f, null, null), 6461, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mordesh (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1077, "Strain Mordesh Female 1", "Strain-Corrupted Mordesh", 41224, 10206, 0, 0, 0, 1f, null, null), 6462, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mordesh (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1078, "Strain Mordesh Female 2", "Strain-Corrupted Mordesh", 41142, 10206, 0, 0, 0, 1f, null, null), 6463, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mordesh (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1079, "Strain Mordesh Female 3", "Strain-Corrupted Mordesh", 33190, 10206, 0, 0, 0, 1f, null, null), 6464, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mordesh (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1080, "Strain Granok Male 1", "Strain-Corrupted Granok", 28351, 10206, 0, 0, 0, 1f, null, null), 6465, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Granok (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1081, "Strain Granok Male 2", "Strain-Corrupted Granok", 26330, 10206, 0, 0, 0, 1f, null, null), 6466, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Granok (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1082, "Strain Granok Male 3", "Strain-Corrupted Granok", 24358, 10206, 0, 0, 0, 1f, null, null), 6467, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Granok (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1083, "Strain Granok Female 1", "Strain-Corrupted Granok", 34764, 10206, 0, 0, 0, 1f, null, null), 6468, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Granok (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1084, "Strain Granok Female 2", "Strain-Corrupted Granok", 41222, 10206, 0, 0, 0, 1f, null, null), 6469, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Granok (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1085, "Strain Granok Female 3", "Strain-Corrupted Granok", 39612, 10206, 0, 0, 0, 1f, null, null), 6470, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Granok (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1086, "Strain Chua 1", "Strain-Corrupted Chua", 38970, 10206, 0, 0, 0, 1f, null, null), 6471, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Chua (Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1087, "Strain Chua 2", "Strain-Corrupted Chua", 36026, 10206, 0, 0, 0, 1f, null, null), 6472, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Chua (Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1088, "Strain Chua 3", "Strain-Corrupted Chua", 36027, 10206, 0, 0, 0, 1f, null, null), 6473, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Chua (Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1089, "Strain Chua 4", "Strain-Corrupted Chua", 38819, 10206, 0, 0, 0, 1f, null, null), 6474, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Chua (Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1090, "Strain Chua 5", "Strain-Corrupted Chua", 30442, 10206, 0, 0, 0, 1f, null, null), 6475, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Chua (Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1091, "Strain Chua 6", "Strain-Corrupted Chua", 30344, 10206, 0, 0, 0, 1f, null, null), 6476, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Chua (Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1092, "Strain Draken Male 1", "Strain-Corrupted Draken", 39029, 10206, 0, 0, 0, 1f, null, null), 6477, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Draken (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1093, "Strain Draken Male 2", "Strain-Corrupted Draken", 39046, 10206, 0, 0, 0, 1f, null, null), 6478, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Draken (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1094, "Strain Draken Male 3", "Strain-Corrupted Draken", 28270, 10206, 0, 0, 0, 1f, null, null), 6479, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Draken (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1095, "Strain Draken Female 1", "Strain-Corrupted Draken", 39025, 10206, 0, 0, 0, 1f, null, null), 6480, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Draken (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1096, "Strain Draken Female 2", "Strain-Corrupted Draken", 39048, 10206, 0, 0, 0, 1f, null, null), 6481, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Draken (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1097, "Strain Draken Female 3", "Strain-Corrupted Draken", 25335, 10206, 0, 0, 0, 1f, null, null), 6482, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Draken (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1098, "Strain Aurin Male 1", "Strain-Corrupted Aurin", 39036, 10206, 0, 0, 0, 1f, null, null), 6483, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Aurin (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1099, "Strain Aurin Male 2", "Strain-Corrupted Aurin", 39609, 10206, 0, 0, 0, 1f, null, null), 6484, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Aurin (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1100, "Strain Aurin Male 3", "Strain-Corrupted Aurin", 41150, 10206, 0, 0, 0, 1f, null, null), 6485, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Aurin (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1101, "Strain Aurin Female 1", "Strain-Corrupted Aurin", 39037, 10206, 0, 0, 0, 1f, null, null), 6486, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Aurin (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1102, "Strain Aurin Female 2", "Strain-Corrupted Aurin", 39611, 10206, 0, 0, 0, 1f, null, null), 6487, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Aurin (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1103, "Strain Aurin Female 3", "Strain-Corrupted Aurin", 41213, 10206, 0, 0, 0, 1f, null, null), 6488, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Aurin (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1104, "Strain Cassian Male 1", "Strain-Corrupted Cassian", 28323, 10206, 0, 0, 0, 1f, null, null), 6489, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Cassian (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1105, "Strain Cassian Male 2", "Strain-Corrupted Cassian", 38818, 10206, 0, 0, 0, 1f, null, null), 6490, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Cassian (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1106, "Strain Cassian Male 3", "Strain-Corrupted Cassian", 34859, 10206, 0, 0, 0, 1f, null, null), 6491, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Cassian (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1107, "Strain Cassian Female 1", "Strain-Corrupted Cassian", 29475, 10206, 0, 0, 0, 1f, null, null), 6492, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Cassian (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1108, "Strain Cassian Female 2", "Strain-Corrupted Cassian", 41300, 10206, 0, 0, 0, 1f, null, null), 6493, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Cassian (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1109, "Strain Cassian Female 3", "Strain-Corrupted Cassian", 28324, 10206, 0, 0, 0, 1f, null, null), 6494, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Cassian (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1110, "Strain Human Male 1", "Strain-Corrupted Human", 28308, 10206, 0, 0, 0, 1f, null, null), 6495, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Human (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1111, "Strain Human Male 2", "Strain-Corrupted Human", 28349, 10206, 0, 0, 0, 1f, null, null), 6496, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Human (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1112, "Strain Human Male 3", "Strain-Corrupted Human", 29477, 10206, 0, 0, 0, 1f, null, null), 6497, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Human (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1113, "Strain Human Female 1", "Strain-Corrupted Human", 28309, 10206, 0, 0, 0, 1f, null, null), 6498, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Human (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1114, "Strain Human Female 2", "Strain-Corrupted Human", 30112, 10206, 0, 0, 0, 1f, null, null), 6499, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Human (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1115, "Strain Human Female 3", "Strain-Corrupted Human", 25887, 10206, 0, 0, 0, 1f, null, null), 6500, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Human (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1116, "Augmented Mechari Male 1", "Augmented Mechari", 41229, 9479, 0, 0, 0, 1f, null, null), 6501, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mechari (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1117, "Augmented Mechari Male 2", "Augmented Mechari", 29552, 9479, 0, 0, 0, 1f, null, null), 6502, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mechari (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1118, "Augmented Mechari Male 3", "Augmented Mechari", 28346, 9479, 0, 0, 0, 1f, null, null), 6503, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mechari (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1119, "Augmented Mechari Female 1", "Augmented Mechari", 41230, 9479, 0, 0, 0, 1f, null, null), 6504, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mechari (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1120, "Augmented Mechari Female 2", "Augmented Mechari", 31745, 9479, 0, 0, 0, 1f, null, null), 6505, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mechari (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1121, "Augmented Mechari Female 3", "Augmented Mechari", 32482, 9479, 0, 0, 0, 1f, null, null), 6506, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Augmented Mechari (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1122, "Strain Mechari Male 1", "Strain-Corrupted Mechari", 41229, 10206, 0, 0, 0, 1f, null, null), 6507, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mechari (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1123, "Strain Mechari Male 2", "Strain-Corrupted Mechari", 29552, 10206, 0, 0, 0, 1f, null, null), 6508, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mechari (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1124, "Strain Mechari Male 3", "Strain-Corrupted Mechari", 28346, 10206, 0, 0, 0, 1f, null, null), 6509, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mechari (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1125, "Strain Mechari Female 1", "Strain-Corrupted Mechari", 41230, 10206, 0, 0, 0, 1f, null, null), 6510, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mechari (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1126, "Strain Mechari Female 2", "Strain-Corrupted Mechari", 31745, 10206, 0, 0, 0, 1f, null, null), 6511, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mechari (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1127, "Strain Mechari Female 3", "Strain-Corrupted Mechari", 32482, 10206, 0, 0, 0, 1f, null, null), 6512, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Strain Mechari (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1128, "Highborn Cassian Male Floorsit 1", "Cassian Noble", 28323, 10106, 0, 0, 1467, 1f, null, null), 6513, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1129, "Highborn Cassian Male Floorsit 2", "Cassian Noble", 38818, 9695, 0, 0, 1467, 1f, null, null), 6514, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1130, "Highborn Cassian Male Floorsit 3", "Cassian Noble", 34859, 10105, 0, 0, 1467, 1f, null, null), 6515, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1131, "Highborn Cassian Male Floorsit 4", "Cassian Noble", 25049, 9695, 0, 0, 1467, 1f, null, null), 6516, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1132, "Highborn Cassian Male Floorsit 5", "Cassian Noble", 36287, 9704, 0, 0, 1467, 1f, null, null), 6517, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1133, "Highborn Cassian Male Floorsit 6", "Cassian Noble", 30880, 9694, 0, 0, 1467, 1f, null, null), 6518, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1134, "Highborn Cassian Male Floorsit 7", "Cassian Noble", 30172, 8229, 0, 0, 1467, 1f, null, null), 6519, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1135, "Lowborn Cassian Male Floorsit 1", "Cassian Commoner", 28300, 10250, 0, 0, 1467, 1f, null, null), 6520, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1136, "Lowborn Cassian Male Floorsit 2", "Cassian Commoner", 25809, 10110, 0, 0, 1467, 1f, null, null), 6521, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1137, "Lowborn Cassian Male Floorsit 3", "Cassian Commoner", 28260, 8755, 0, 0, 1467, 1f, null, null), 6522, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1138, "Lowborn Cassian Male Floorsit 4", "Cassian Commoner", 30597, 10533, 0, 0, 1467, 1f, null, null), 6523, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1139, "Lowborn Cassian Male Floorsit 5", "Cassian Commoner", 30897, 8757, 0, 0, 1467, 1f, null, null), 6524, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1140, "Lowborn Cassian Male Floorsit 6", "Cassian Commoner", 25653, 8754, 0, 0, 1467, 1f, null, null), 6525, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1141, "Lowborn Cassian Male Floorsit 7", "Cassian Commoner", 28341, 9459, 0, 0, 1467, 1f, null, null), 6526, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1142, "Exiled Human Male Floorsit 1", "Human Civilian", 28308, 8754, 0, 0, 1467, 1f, null, null), 6527, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1143, "Exiled Human Male Floorsit 2", "Human Civilian", 28349, 10250, 0, 0, 1467, 1f, null, null), 6528, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1144, "Exiled Human Male Floorsit 3", "Human Civilian", 29477, 8755, 0, 0, 1467, 1f, null, null), 6529, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1145, "Exiled Human Male Floorsit 4", "Human Civilian", 28033, 9931, 0, 0, 1467, 1f, null, null), 6530, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1146, "Exiled Human Male Floorsit 5", "Human Civilian", 27346, 8211, 0, 0, 1467, 1f, null, null), 6531, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1147, "Exiled Human Male Floorsit 6", "Human Civilian", 32799, 8757, 0, 0, 1467, 1f, null, null), 6532, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1148, "Exiled Human Male Floorsit 7", "Human Civilian", 24796, 8758, 0, 0, 1467, 1f, null, null), 6533, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1149, "Highborn Cassian Female Floorsit 1", "Cassian Noble", 30666, 8229, 0, 0, 1467, 1f, null, null), 6534, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1150, "Highborn Cassian Female Floorsit 2", "Cassian Noble", 30240, 9694, 0, 0, 1467, 1f, null, null), 6535, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1151, "Highborn Cassian Female Floorsit 3", "Cassian Noble", 34860, 10106, 0, 0, 1467, 1f, null, null), 6536, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1152, "Highborn Cassian Female Floorsit 4", "Cassian Noble", 29475, 9704, 0, 0, 1467, 1f, null, null), 6537, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1153, "Highborn Cassian Female Floorsit 5", "Cassian Noble", 41300, 9695, 0, 0, 1467, 1f, null, null), 6538, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1154, "Highborn Cassian Female Floorsit 6", "Cassian Noble", 28324, 10105, 0, 0, 1467, 1f, null, null), 6539, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1155, "Highborn Cassian Female Floorsit 7", "Cassian Noble", 30599, 8496, 0, 0, 1467, 1f, null, null), 6540, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Floor Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1156, "Lowborn Cassian Female Floorsit 1", "Cassian Commoner", 34858, 10250, 0, 0, 1467, 1f, null, null), 6541, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1157, "Lowborn Cassian Female Floorsit 2", "Cassian Commoner", 28301, 10533, 0, 0, 1467, 1f, null, null), 6542, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1158, "Lowborn Cassian Female Floorsit 3", "Cassian Commoner", 30748, 9869, 0, 0, 1467, 1f, null, null), 6543, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1159, "Lowborn Cassian Female Floorsit 4", "Cassian Commoner", 31426, 8757, 0, 0, 1467, 1f, null, null), 6544, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1160, "Lowborn Cassian Female Floorsit 5", "Cassian Commoner", 25336, 8754, 0, 0, 1467, 1f, null, null), 6545, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1161, "Lowborn Cassian Female Floorsit 6", "Cassian Commoner", 34862, 9459, 0, 0, 1467, 1f, null, null), 6546, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1162, "Lowborn Cassian Female Floorsit 7", "Cassian Commoner", 34870, 8416, 0, 0, 1467, 1f, null, null), 6547, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Floor Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1163, "Exiled Human Female Floorsit 1", "Human Civilian", 28309, 8758, 0, 0, 1467, 1f, null, null), 6548, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1164, "Exiled Human Female Floorsit 2", "Human Civilian", 30112, 10250, 0, 0, 1467, 1f, null, null), 6549, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1165, "Exiled Human Female Floorsit 3", "Human Civilian", 25887, 8416, 0, 0, 1467, 1f, null, null), 6550, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1166, "Exiled Human Female Floorsit 4", "Human Civilian", 30194, 8755, 0, 0, 1467, 1f, null, null), 6551, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1167, "Exiled Human Female Floorsit 5", "Human Civilian", 30178, 9869, 0, 0, 1467, 1f, null, null), 6552, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1168, "Exiled Human Female Floorsit 6", "Human Civilian", 27562, 8211, 0, 0, 1467, 1f, null, null), 6553, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1169, "Exiled Human Female Floorsit 7", "Human Civilian", 25051, 8416, 0, 0, 1467, 1f, null, null), 6554, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Floor Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1170, "Draken Male Civilian Floorsit 1", "Draken Civilian", 39029, 9891, 0, 0, 1467, 1f, null, null), 6555, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1171, "Draken Male Civilian Floorsit 2", "Draken Civilian", 39046, 8576, 0, 0, 1467, 1f, null, null), 6556, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1172, "Draken Male Civilian Floorsit 3", "Draken Civilian", 28270, 8477, 0, 0, 1467, 1f, null, null), 6557, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1173, "Draken Male Civilian Floorsit 4", "Draken Civilian", 28325, 10250, 0, 0, 1467, 1f, null, null), 6558, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1174, "Draken Male Civilian Floorsit 5", "Draken Civilian", 28359, 9869, 0, 0, 1467, 1f, null, null), 6559, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1175, "Draken Male Civilian Floorsit 6", "Draken Civilian", 28295, 9459, 0, 0, 1467, 1f, null, null), 6560, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1176, "Draken Male Civilian Floorsit 7", "Draken Civilian", 36304, 9695, 0, 0, 1467, 1f, null, null), 6561, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1177, "Draken Female Civilian Floorsit 1", "Draken Civilian", 39025, 9891, 0, 0, 1467, 1f, null, null), 6562, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1178, "Draken Female Civilian Floorsit 2", "Draken Civilian", 39048, 8576, 0, 0, 1467, 1f, null, null), 6563, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1179, "Draken Female Civilian Floorsit 3", "Draken Civilian", 25335, 8477, 0, 0, 1467, 1f, null, null), 6564, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1180, "Draken Female Civilian Floorsit 4", "Draken Civilian", 39027, 10250, 0, 0, 1467, 1f, null, null), 6565, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1181, "Draken Female Civilian Floorsit 5", "Draken Civilian", 25363, 9869, 0, 0, 1467, 1f, null, null), 6566, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1182, "Draken Female Civilian Floorsit 6", "Draken Civilian", 26893, 9695, 0, 0, 1467, 1f, null, null), 6567, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1183, "Draken Female Civilian Floorsit 7", "Draken Civilian", 34446, 9459, 0, 0, 1467, 1f, null, null), 6568, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Floor Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1184, "Aurin Male Civilian Floorsit 1", "Aurin Civilian", 39036, 8758, 0, 0, 1467, 1f, null, null), 6569, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1185, "Aurin Male Civilian Floorsit 2", "Aurin Civilian", 39609, 8416, 0, 0, 1467, 1f, null, null), 6570, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1186, "Aurin Male Civilian Floorsit 3", "Aurin Civilian", 41150, 8755, 0, 0, 1467, 1f, null, null), 6571, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1187, "Aurin Male Civilian Floorsit 4", "Aurin Civilian", 30179, 9869, 0, 0, 1467, 1f, null, null), 6572, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1188, "Aurin Male Civilian Floorsit 5", "Aurin Civilian", 34948, 8211, 0, 0, 1467, 1f, null, null), 6573, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1189, "Aurin Male Civilian Floorsit 6", "Aurin Civilian", 32751, 9931, 0, 0, 1467, 1f, null, null), 6574, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1190, "Aurin Male Civilian Floorsit 7", "Aurin Civilian", 28319, 9704, 0, 0, 1467, 1f, null, null), 6575, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1191, "Aurin Female Civilian Floorsit 1", "Aurin Civilian", 39037, 8416, 0, 0, 1467, 1f, null, null), 6576, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1192, "Aurin Female Civilian Floorsit 2", "Aurin Civilian", 39611, 8758, 0, 0, 1467, 1f, null, null), 6577, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1193, "Aurin Female Civilian Floorsit 3", "Aurin Civilian", 41213, 8755, 0, 0, 1467, 1f, null, null), 6578, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1194, "Aurin Female Civilian Floorsit 4", "Aurin Civilian", 34949, 8211, 0, 0, 1467, 1f, null, null), 6579, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1195, "Aurin Female Civilian Floorsit 5", "Aurin Civilian", 38231, 9869, 0, 0, 1467, 1f, null, null), 6580, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1196, "Aurin Female Civilian Floorsit 6", "Aurin Civilian", 36300, 9704, 0, 0, 1467, 1f, null, null), 6581, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1197, "Aurin Female Civilian Floorsit 7", "Aurin Civilian", 33161, 9931, 0, 0, 1467, 1f, null, null), 6582, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Floor Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1198, "Mechari Male Civilian Floorsit 1", "Mechari Civilian", 41229, 10310, 0, 0, 1467, 1f, null, null), 6583, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1199, "Mechari Male Civilian Floorsit 2", "Mechari Civilian", 29552, 10250, 0, 0, 1467, 1f, null, null), 6584, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1200, "Mechari Male Civilian Floorsit 3", "Mechari Civilian", 28346, 9694, 0, 0, 1467, 1f, null, null), 6585, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1201, "Mechari Male Civilian Floorsit 4", "Mechari Civilian", 28827, 8496, 0, 0, 1467, 1f, null, null), 6586, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1202, "Mechari Male Civilian Floorsit 5", "Mechari Civilian", 28330, 9695, 0, 0, 1467, 1f, null, null), 6587, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1203, "Mechari Male Civilian Floorsit 6", "Mechari Civilian", 28312, 10533, 0, 0, 1467, 1f, null, null), 6588, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1204, "Mechari Male Civilian Floorsit 7", "Mechari Civilian", 38821, 8229, 0, 0, 1467, 1f, null, null), 6589, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1205, "Mechari Female Civilian Floorsit 1", "Mechari Civilian", 41230, 8229, 0, 0, 1467, 1f, null, null), 6590, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1206, "Mechari Female Civilian Floorsit 2", "Mechari Civilian", 31745, 8496, 0, 0, 1467, 1f, null, null), 6591, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1207, "Mechari Female Civilian Floorsit 3", "Mechari Civilian", 32482, 9695, 0, 0, 1467, 1f, null, null), 6592, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1208, "Mechari Female Civilian Floorsit 4", "Mechari Civilian", 28331, 10250, 0, 0, 1467, 1f, null, null), 6593, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1209, "Mechari Female Civilian Floorsit 5", "Mechari Civilian", 28313, 9694, 0, 0, 1467, 1f, null, null), 6594, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1210, "Mechari Female Civilian Floorsit 6", "Mechari Civilian", 34856, 10533, 0, 0, 1467, 1f, null, null), 6595, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1211, "Mechari Female Civilian Floorsit 7", "Mechari Civilian", 32971, 10310, 0, 0, 1467, 1f, null, null), 6596, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Floor Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1212, "Highborn Cassian Male Taxisit 1", "Cassian Noble", 28323, 10106, 0, 0, 7592, 1f, null, null), 6597, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1213, "Highborn Cassian Male Taxisit 2", "Cassian Noble", 38818, 9695, 0, 0, 7592, 1f, null, null), 6598, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1214, "Highborn Cassian Male Taxisit 3", "Cassian Noble", 34859, 10105, 0, 0, 7592, 1f, null, null), 6599, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1215, "Highborn Cassian Male Taxisit 4", "Cassian Noble", 25049, 9695, 0, 0, 7592, 1f, null, null), 6600, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1216, "Highborn Cassian Male Taxisit 5", "Cassian Noble", 36287, 9704, 0, 0, 7592, 1f, null, null), 6601, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1217, "Highborn Cassian Male Taxisit 6", "Cassian Noble", 30880, 9694, 0, 0, 7592, 1f, null, null), 6602, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1218, "Highborn Cassian Male Taxisit 7", "Cassian Noble", 30172, 8229, 0, 0, 7592, 1f, null, null), 6603, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1219, "Lowborn Cassian Male Taxisit 1", "Cassian Commoner", 28300, 10250, 0, 0, 7592, 1f, null, null), 6604, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1220, "Lowborn Cassian Male Taxisit 2", "Cassian Commoner", 25809, 10110, 0, 0, 7592, 1f, null, null), 6605, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1221, "Lowborn Cassian Male Taxisit 3", "Cassian Commoner", 28260, 8755, 0, 0, 7592, 1f, null, null), 6606, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1222, "Lowborn Cassian Male Taxisit 4", "Cassian Commoner", 30597, 10533, 0, 0, 7592, 1f, null, null), 6607, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1223, "Lowborn Cassian Male Taxisit 5", "Cassian Commoner", 30897, 8757, 0, 0, 7592, 1f, null, null), 6608, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1224, "Lowborn Cassian Male Taxisit 6", "Cassian Commoner", 25653, 8754, 0, 0, 7592, 1f, null, null), 6609, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1225, "Lowborn Cassian Male Taxisit 7", "Cassian Commoner", 28341, 9459, 0, 0, 7592, 1f, null, null), 6610, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1226, "Exiled Human Male Taxisit 1", "Human Civilian", 28308, 8754, 0, 0, 7592, 1f, null, null), 6611, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1227, "Exiled Human Male Taxisit 2", "Human Civilian", 28349, 10250, 0, 0, 7592, 1f, null, null), 6612, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1228, "Exiled Human Male Taxisit 3", "Human Civilian", 29477, 8755, 0, 0, 7592, 1f, null, null), 6613, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1229, "Exiled Human Male Taxisit 4", "Human Civilian", 28033, 9931, 0, 0, 7592, 1f, null, null), 6614, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1230, "Exiled Human Male Taxisit 5", "Human Civilian", 27346, 8211, 0, 0, 7592, 1f, null, null), 6615, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1231, "Exiled Human Male Taxisit 6", "Human Civilian", 32799, 8757, 0, 0, 7592, 1f, null, null), 6616, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1232, "Exiled Human Male Taxisit 7", "Human Civilian", 24796, 8758, 0, 0, 7592, 1f, null, null), 6617, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1233, "Highborn Cassian Female Taxisit 1", "Cassian Noble", 30666, 8229, 0, 0, 7592, 1f, null, null), 6618, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1234, "Highborn Cassian Female Taxisit 2", "Cassian Noble", 30240, 9694, 0, 0, 7592, 1f, null, null), 6619, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1235, "Highborn Cassian Female Taxisit 3", "Cassian Noble", 34860, 10106, 0, 0, 7592, 1f, null, null), 6620, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1236, "Highborn Cassian Female Taxisit 4", "Cassian Noble", 29475, 9704, 0, 0, 7592, 1f, null, null), 6621, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1237, "Highborn Cassian Female Taxisit 5", "Cassian Noble", 41300, 9695, 0, 0, 7592, 1f, null, null), 6622, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1238, "Highborn Cassian Female Taxisit 6", "Cassian Noble", 28324, 10105, 0, 0, 7592, 1f, null, null), 6623, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1239, "Highborn Cassian Female Taxisit 7", "Cassian Noble", 30599, 8496, 0, 0, 7592, 1f, null, null), 6624, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Taxi Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1240, "Lowborn Cassian Female Taxisit 1", "Cassian Commoner", 34858, 10250, 0, 0, 7592, 1f, null, null), 6625, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1241, "Lowborn Cassian Female Taxisit 2", "Cassian Commoner", 28301, 10533, 0, 0, 7592, 1f, null, null), 6626, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1242, "Lowborn Cassian Female Taxisit 3", "Cassian Commoner", 30748, 9869, 0, 0, 7592, 1f, null, null), 6627, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1243, "Lowborn Cassian Female Taxisit 4", "Cassian Commoner", 31426, 8757, 0, 0, 7592, 1f, null, null), 6628, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1244, "Lowborn Cassian Female Taxisit 5", "Cassian Commoner", 25336, 8754, 0, 0, 7592, 1f, null, null), 6629, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1245, "Lowborn Cassian Female Taxisit 6", "Cassian Commoner", 34862, 9459, 0, 0, 7592, 1f, null, null), 6630, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1246, "Lowborn Cassian Female Taxisit 7", "Cassian Commoner", 34870, 8416, 0, 0, 7592, 1f, null, null), 6631, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Taxi Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1247, "Exiled Human Female Taxisit 1", "Human Civilian", 28309, 8758, 0, 0, 7592, 1f, null, null), 6632, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1248, "Exiled Human Female Taxisit 2", "Human Civilian", 30112, 10250, 0, 0, 7592, 1f, null, null), 6633, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1249, "Exiled Human Female Taxisit 3", "Human Civilian", 25887, 8416, 0, 0, 7592, 1f, null, null), 6634, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1250, "Exiled Human Female Taxisit 4", "Human Civilian", 30194, 8755, 0, 0, 7592, 1f, null, null), 6635, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1251, "Exiled Human Female Taxisit 5", "Human Civilian", 30178, 9869, 0, 0, 7592, 1f, null, null), 6636, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1252, "Exiled Human Female Taxisit 6", "Human Civilian", 27562, 8211, 0, 0, 7592, 1f, null, null), 6637, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1253, "Exiled Human Female Taxisit 7", "Human Civilian", 25051, 8416, 0, 0, 7592, 1f, null, null), 6638, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Taxi Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1254, "Draken Male Civilian Taxisit 1", "Draken Civilian", 39029, 9891, 0, 0, 7592, 1f, null, null), 6639, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1255, "Draken Male Civilian Taxisit 2", "Draken Civilian", 39046, 8576, 0, 0, 7592, 1f, null, null), 6640, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1256, "Draken Male Civilian Taxisit 3", "Draken Civilian", 28270, 8477, 0, 0, 7592, 1f, null, null), 6641, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1257, "Draken Male Civilian Taxisit 4", "Draken Civilian", 28325, 10250, 0, 0, 7592, 1f, null, null), 6642, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1258, "Draken Male Civilian Taxisit 5", "Draken Civilian", 28359, 9869, 0, 0, 7592, 1f, null, null), 6643, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1259, "Draken Male Civilian Taxisit 6", "Draken Civilian", 28295, 9459, 0, 0, 7592, 1f, null, null), 6644, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1260, "Draken Male Civilian Taxisit 7", "Draken Civilian", 36304, 9695, 0, 0, 7592, 1f, null, null), 6645, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1261, "Draken Female Civilian Taxisit 1", "Draken Civilian", 39025, 9891, 0, 0, 7592, 1f, null, null), 6646, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1262, "Draken Female Civilian Taxisit 2", "Draken Civilian", 39048, 8576, 0, 0, 7592, 1f, null, null), 6647, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1263, "Draken Female Civilian Taxisit 3", "Draken Civilian", 25335, 8477, 0, 0, 7592, 1f, null, null), 6648, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1264, "Draken Female Civilian Taxisit 4", "Draken Civilian", 39027, 10250, 0, 0, 7592, 1f, null, null), 6649, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1265, "Draken Female Civilian Taxisit 5", "Draken Civilian", 25363, 9869, 0, 0, 7592, 1f, null, null), 6650, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1266, "Draken Female Civilian Taxisit 6", "Draken Civilian", 26893, 9695, 0, 0, 7592, 1f, null, null), 6651, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1267, "Draken Female Civilian Taxisit 7", "Draken Civilian", 34446, 9459, 0, 0, 7592, 1f, null, null), 6652, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Taxi Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1268, "Aurin Male Civilian Taxisit 1", "Aurin Civilian", 39036, 8758, 0, 0, 7592, 1f, null, null), 6653, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1269, "Aurin Male Civilian Taxisit 2", "Aurin Civilian", 39609, 8416, 0, 0, 7592, 1f, null, null), 6654, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1270, "Aurin Male Civilian Taxisit 3", "Aurin Civilian", 41150, 8755, 0, 0, 7592, 1f, null, null), 6655, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1271, "Aurin Male Civilian Taxisit 4", "Aurin Civilian", 30179, 9869, 0, 0, 7592, 1f, null, null), 6656, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1272, "Aurin Male Civilian Taxisit 5", "Aurin Civilian", 34948, 8211, 0, 0, 7592, 1f, null, null), 6657, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1273, "Aurin Male Civilian Taxisit 6", "Aurin Civilian", 32751, 9931, 0, 0, 7592, 1f, null, null), 6658, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1274, "Aurin Male Civilian Taxisit 7", "Aurin Civilian", 28319, 9704, 0, 0, 7592, 1f, null, null), 6659, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1275, "Aurin Female Civilian Taxisit 1", "Aurin Civilian", 39037, 8416, 0, 0, 7592, 1f, null, null), 6660, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1276, "Aurin Female Civilian Taxisit 2", "Aurin Civilian", 39611, 8758, 0, 0, 7592, 1f, null, null), 6661, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1277, "Aurin Female Civilian Taxisit 3", "Aurin Civilian", 41213, 8755, 0, 0, 7592, 1f, null, null), 6662, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1278, "Aurin Female Civilian Taxisit 4", "Aurin Civilian", 34949, 8211, 0, 0, 7592, 1f, null, null), 6663, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1279, "Aurin Female Civilian Taxisit 5", "Aurin Civilian", 38231, 9869, 0, 0, 7592, 1f, null, null), 6664, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1280, "Aurin Female Civilian Taxisit 6", "Aurin Civilian", 36300, 9704, 0, 0, 7592, 1f, null, null), 6665, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1281, "Aurin Female Civilian Taxisit 7", "Aurin Civilian", 33161, 9931, 0, 0, 7592, 1f, null, null), 6666, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Taxi Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1282, "Mechari Male Civilian Taxisit 1", "Mechari Civilian", 41229, 10310, 0, 0, 7592, 1f, null, null), 6667, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1283, "Mechari Male Civilian Taxisit 2", "Mechari Civilian", 29552, 10250, 0, 0, 7592, 1f, null, null), 6668, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1284, "Mechari Male Civilian Taxisit 3", "Mechari Civilian", 28346, 9694, 0, 0, 7592, 1f, null, null), 6669, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1285, "Mechari Male Civilian Taxisit 4", "Mechari Civilian", 28827, 8496, 0, 0, 7592, 1f, null, null), 6670, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1286, "Mechari Male Civilian Taxisit 5", "Mechari Civilian", 28330, 9695, 0, 0, 7592, 1f, null, null), 6671, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1287, "Mechari Male Civilian Taxisit 6", "Mechari Civilian", 28312, 10533, 0, 0, 7592, 1f, null, null), 6672, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1288, "Mechari Male Civilian Taxisit 7", "Mechari Civilian", 38821, 8229, 0, 0, 7592, 1f, null, null), 6673, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1289, "Mechari Female Civilian Taxisit 1", "Mechari Civilian", 41230, 8229, 0, 0, 7592, 1f, null, null), 6674, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1290, "Mechari Female Civilian Taxisit 2", "Mechari Civilian", 31745, 8496, 0, 0, 7592, 1f, null, null), 6675, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1291, "Mechari Female Civilian Taxisit 3", "Mechari Civilian", 32482, 9695, 0, 0, 7592, 1f, null, null), 6676, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1292, "Mechari Female Civilian Taxisit 4", "Mechari Civilian", 28331, 10250, 0, 0, 7592, 1f, null, null), 6677, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1293, "Mechari Female Civilian Taxisit 5", "Mechari Civilian", 28313, 9694, 0, 0, 7592, 1f, null, null), 6678, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1294, "Mechari Female Civilian Taxisit 6", "Mechari Civilian", 34856, 10533, 0, 0, 7592, 1f, null, null), 6679, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1295, "Mechari Female Civilian Taxisit 7", "Mechari Civilian", 32971, 10310, 0, 0, 7592, 1f, null, null), 6680, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Taxi Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1296, "Chua Floor Sit 1", "Chua Civilian", 38970, 10250, 0, 0, 1467, 1f, null, null), 6681, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Civilian, Floor Sit (Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1297, "Chua Floor Sit 2", "Chua Civilian", 36026, 8496, 0, 0, 1467, 1f, null, null), 6682, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "!NEW! Chua Civilian, Floor Sit (Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1298, "Chua Floor Sit 3", "Chua Civilian", 36027, 8477, 0, 0, 1467, 1f, null, null), 6683, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "!NEW! Chua Civilian, Floor Sit (Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1299, "Chua Floor Sit 4", "Chua Civilian", 38819, 8229, 0, 0, 1467, 1f, null, null), 6684, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "!NEW! Chua Civilian, Floor Sit (Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1300, "Chua Floor Sit 5", "Chua Civilian", 30442, 8416, 0, 0, 1467, 1f, null, null), 6685, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "!NEW! Chua Civilian, Floor Sit (Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1301, "Chua Floor Sit 6", "Chua Civilian", 30344, 9694, 0, 0, 1467, 1f, null, null), 6686, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "!NEW! Chua Civilian, Floor Sit (Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1302, "Chua Floor Sit 7", "Chua Civilian", 30857, 10533, 0, 0, 1467, 1f, null, null), 6687, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m9", "!NEW! Chua Civilian, Floor Sit (Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1303, "Granok Male Floor Sit 1", "Granok Civilian", 28351, 9931, 0, 0, 1467, 1f, null, null), 6688, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1304, "Granok Male Floor Sit 2", "Granok Civilian", 26330, 9720, 0, 0, 1467, 1f, null, null), 6689, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1305, "Granok Male Floor Sit 3", "Granok Civilian", 24358, 9869, 0, 0, 1467, 1f, null, null), 6690, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1306, "Granok Male Floor Sit 4", "Granok Civilian", 25162, 9459, 0, 0, 1467, 1f, null, null), 6691, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1307, "Granok Male Floor Sit 5", "Granok Civilian", 24081, 8477, 0, 0, 1467, 1f, null, null), 6692, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1308, "Granok Male Floor Sit 6", "Granok Civilian", 24438, 9928, 0, 0, 1467, 1f, null, null), 6693, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1309, "Granok Male Floor Sit 7", "Granok Civilian", 24715, 8757, 0, 0, 1467, 1f, null, null), 6694, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1310, "Granok Female Floor Sit 1", "Granok Civilian", 34764, 8416, 0, 0, 1467, 1f, null, null), 6695, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1311, "Granok Female Floor Sit 2", "Granok Civilian", 41222, 9720, 0, 0, 1467, 1f, null, null), 6696, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1312, "Granok Female Floor Sit 3", "Granok Civilian", 39612, 9869, 0, 0, 1467, 1f, null, null), 6697, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1313, "Granok Female Floor Sit 4", "Granok Civilian", 41303, 9459, 0, 0, 1467, 1f, null, null), 6698, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1314, "Granok Female Floor Sit 5", "Granok Civilian", 28040, 8477, 0, 0, 1467, 1f, null, null), 6699, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1315, "Granok Female Floor Sit 6", "Granok Civilian", 36055, 9928, 0, 0, 1467, 1f, null, null), 6700, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1316, "Granok Female Floor Sit 7", "Granok Civilian", 34766, 8757, 0, 0, 1467, 1f, null, null), 6701, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Floor Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1317, "Chua Taxi Sit 1", "Chua Civilian", 38970, 10250, 0, 0, 7592, 1f, null, null), 6702, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Civilian, Taxi Sit (Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1318, "Chua Taxi Sit 2", "Chua Civilian", 36026, 8496, 0, 0, 7592, 1f, null, null), 6703, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "!NEW! Chua Civilian, Taxi Sit (Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1319, "Chua Taxi Sit 3", "Chua Civilian", 36027, 8477, 0, 0, 7592, 1f, null, null), 6704, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "!NEW! Chua Civilian, Taxi Sit (Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1320, "Chua Taxi Sit 4", "Chua Civilian", 38819, 8229, 0, 0, 7592, 1f, null, null), 6705, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "!NEW! Chua Civilian, Taxi Sit (Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1321, "Chua Taxi Sit 5", "Chua Civilian", 30442, 8416, 0, 0, 7592, 1f, null, null), 6706, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "!NEW! Chua Civilian, Taxi Sit (Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1322, "Chua Taxi Sit 6", "Chua Civilian", 30344, 9694, 0, 0, 7592, 1f, null, null), 6707, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "!NEW! Chua Civilian, Taxi Sit (Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1323, "Chua Taxi Sit 7", "Chua Civilian", 30857, 10533, 0, 0, 7592, 1f, null, null), 6708, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m9", "!NEW! Chua Civilian, Taxi Sit (Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1324, "Granok Male Taxi Sit 1", "Granok Civilian", 28351, 9931, 0, 0, 7592, 1f, null, null), 6709, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Male, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1325, "Granok Male Taxi Sit 2", "Granok Civilian", 26330, 9720, 0, 0, 7592, 1f, null, null), 6710, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Male, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1326, "Granok Male Taxi Sit 3", "Granok Civilian", 24358, 9869, 0, 0, 7592, 1f, null, null), 6711, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Male, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1327, "Granok Male Taxi Sit 4", "Granok Civilian", 25162, 9459, 0, 0, 7592, 1f, null, null), 6712, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Male, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1328, "Granok Male Taxi Sit 5", "Granok Civilian", 24081, 8477, 0, 0, 7592, 1f, null, null), 6713, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Male, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1329, "Granok Male Taxi Sit 6", "Granok Civilian", 24438, 9928, 0, 0, 7592, 1f, null, null), 6714, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Male, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1330, "Granok Male Taxi Sit 7", "Granok Civilian", 24715, 8757, 0, 0, 7592, 1f, null, null), 6715, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Male, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1331, "Granok Female Taxi Sit 1", "Granok Civilian", 34764, 8416, 0, 0, 7592, 1f, null, null), 6716, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Female, Style 1)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1332, "Granok Female Taxi Sit 2", "Granok Civilian", 41222, 9720, 0, 0, 7592, 1f, null, null), 6717, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Female, Style 2)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1333, "Granok Female Taxi Sit 3", "Granok Civilian", 39612, 9869, 0, 0, 7592, 1f, null, null), 6718, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Female, Style 3)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1334, "Granok Female Taxi Sit 4", "Granok Civilian", 41303, 9459, 0, 0, 7592, 1f, null, null), 6719, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Female, Style 4)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1335, "Granok Female Taxi Sit 5", "Granok Civilian", 28040, 8477, 0, 0, 7592, 1f, null, null), 6720, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Female, Style 5)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1336, "Granok Female Taxi Sit 6", "Granok Civilian", 36055, 9928, 0, 0, 7592, 1f, null, null), 6721, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Female, Style 6)", 13);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1337, "Granok Female Taxi Sit 7", "Granok Civilian", 34766, 8757, 0, 0, 7592, 1f, null, null), 6722, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Taxi Sit (Female, Style 7)", 13);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1338, "Highborn Cassian Male Dance1 1", "Cassian Noble", 28323, 10106, 0, 0, 7749, 1f, null, null), 6723, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1339, "Highborn Cassian Male Dance1 2", "Cassian Noble", 38818, 9695, 0, 0, 7749, 1f, null, null), 6724, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1340, "Highborn Cassian Male Dance1 3", "Cassian Noble", 34859, 10105, 0, 0, 7749, 1f, null, null), 6725, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1341, "Highborn Cassian Male Dance1 4", "Cassian Noble", 25049, 9695, 0, 0, 7749, 1f, null, null), 6726, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1342, "Highborn Cassian Male Dance1 5", "Cassian Noble", 36287, 9704, 0, 0, 7749, 1f, null, null), 6727, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1343, "Highborn Cassian Male Dance1 6", "Cassian Noble", 30880, 9694, 0, 0, 7749, 1f, null, null), 6728, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1344, "Highborn Cassian Male Dance1 7", "Cassian Noble", 30172, 8229, 0, 0, 7749, 1f, null, null), 6729, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1345, "Lowborn Cassian Male Dance1 1", "Cassian Commoner", 28300, 10250, 0, 0, 7749, 1f, null, null), 6730, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1346, "Lowborn Cassian Male Dance1 2", "Cassian Commoner", 25809, 10110, 0, 0, 7749, 1f, null, null), 6731, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1347, "Lowborn Cassian Male Dance1 3", "Cassian Commoner", 28260, 8755, 0, 0, 7749, 1f, null, null), 6732, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1348, "Lowborn Cassian Male Dance1 4", "Cassian Commoner", 30597, 10533, 0, 0, 7749, 1f, null, null), 6733, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1349, "Lowborn Cassian Male Dance1 5", "Cassian Commoner", 30897, 8757, 0, 0, 7749, 1f, null, null), 6734, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1350, "Lowborn Cassian Male Dance1 6", "Cassian Commoner", 25653, 8754, 0, 0, 7749, 1f, null, null), 6735, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1351, "Lowborn Cassian Male Dance1 7", "Cassian Commoner", 28341, 9459, 0, 0, 7749, 1f, null, null), 6736, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1352, "Exiled Human Male Dance1 1", "Human Civilian", 28308, 8754, 0, 0, 7749, 1f, null, null), 6737, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1353, "Exiled Human Male Dance1 2", "Human Civilian", 28349, 10250, 0, 0, 7749, 1f, null, null), 6738, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1354, "Exiled Human Male Dance1 3", "Human Civilian", 29477, 8755, 0, 0, 7749, 1f, null, null), 6739, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1355, "Exiled Human Male Dance1 4", "Human Civilian", 28033, 9931, 0, 0, 7749, 1f, null, null), 6740, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1356, "Exiled Human Male Dance1 5", "Human Civilian", 27346, 8211, 0, 0, 7749, 1f, null, null), 6741, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1357, "Exiled Human Male Dance1 6", "Human Civilian", 32799, 8757, 0, 0, 7749, 1f, null, null), 6742, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1358, "Exiled Human Male Dance1 7", "Human Civilian", 24796, 8758, 0, 0, 7749, 1f, null, null), 6743, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1359, "Highborn Cassian Female Dance1 1", "Cassian Noble", 30666, 8229, 0, 0, 7749, 1f, null, null), 6744, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1360, "Highborn Cassian Female Dance1 2", "Cassian Noble", 30240, 9694, 0, 0, 7749, 1f, null, null), 6745, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1361, "Highborn Cassian Female Dance1 3", "Cassian Noble", 34860, 10106, 0, 0, 7749, 1f, null, null), 6746, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1362, "Highborn Cassian Female Dance1 4", "Cassian Noble", 29475, 9704, 0, 0, 7749, 1f, null, null), 6747, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1363, "Highborn Cassian Female Dance1 5", "Cassian Noble", 41300, 9695, 0, 0, 7749, 1f, null, null), 6748, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1364, "Highborn Cassian Female Dance1 6", "Cassian Noble", 28324, 10105, 0, 0, 7749, 1f, null, null), 6749, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1365, "Highborn Cassian Female Dance1 7", "Cassian Noble", 30599, 8496, 0, 0, 7749, 1f, null, null), 6750, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 1 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1366, "Lowborn Cassian Female Dance1 1", "Cassian Commoner", 34858, 10250, 0, 0, 7749, 1f, null, null), 6751, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1367, "Lowborn Cassian Female Dance1 2", "Cassian Commoner", 28301, 10533, 0, 0, 7749, 1f, null, null), 6752, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1368, "Lowborn Cassian Female Dance1 3", "Cassian Commoner", 30748, 9869, 0, 0, 7749, 1f, null, null), 6753, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1369, "Lowborn Cassian Female Dance1 4", "Cassian Commoner", 31426, 8757, 0, 0, 7749, 1f, null, null), 6754, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1370, "Lowborn Cassian Female Dance1 5", "Cassian Commoner", 25336, 8754, 0, 0, 7749, 1f, null, null), 6755, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1371, "Lowborn Cassian Female Dance1 6", "Cassian Commoner", 34862, 9459, 0, 0, 7749, 1f, null, null), 6756, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1372, "Lowborn Cassian Female Dance1 7", "Cassian Commoner", 34870, 8416, 0, 0, 7749, 1f, null, null), 6757, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 1 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1373, "Exiled Human Female Dance1 1", "Human Civilian", 28309, 8758, 0, 0, 7749, 1f, null, null), 6758, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1374, "Exiled Human Female Dance1 2", "Human Civilian", 30112, 10250, 0, 0, 7749, 1f, null, null), 6759, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1375, "Exiled Human Female Dance1 3", "Human Civilian", 25887, 8416, 0, 0, 7749, 1f, null, null), 6760, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1376, "Exiled Human Female Dance1 4", "Human Civilian", 30194, 8755, 0, 0, 7749, 1f, null, null), 6761, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1377, "Exiled Human Female Dance1 5", "Human Civilian", 30178, 9869, 0, 0, 7749, 1f, null, null), 6762, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1378, "Exiled Human Female Dance1 6", "Human Civilian", 27562, 8211, 0, 0, 7749, 1f, null, null), 6763, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1379, "Exiled Human Female Dance1 7", "Human Civilian", 25051, 8416, 0, 0, 7749, 1f, null, null), 6764, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 1 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1380, "Draken Male Civilian Dance1 1", "Draken Civilian", 39029, 9891, 0, 0, 7749, 1f, null, null), 6765, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1381, "Draken Male Civilian Dance1 2", "Draken Civilian", 39046, 8576, 0, 0, 7749, 1f, null, null), 6766, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1382, "Draken Male Civilian Dance1 3", "Draken Civilian", 28270, 8477, 0, 0, 7749, 1f, null, null), 6767, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1383, "Draken Male Civilian Dance1 4", "Draken Civilian", 28325, 10250, 0, 0, 7749, 1f, null, null), 6768, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1384, "Draken Male Civilian Dance1 5", "Draken Civilian", 28359, 9869, 0, 0, 7749, 1f, null, null), 6769, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1385, "Draken Male Civilian Dance1 6", "Draken Civilian", 28295, 9459, 0, 0, 7749, 1f, null, null), 6770, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1386, "Draken Male Civilian Dance1 7", "Draken Civilian", 36304, 9695, 0, 0, 7749, 1f, null, null), 6771, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1387, "Draken Female Civilian Dance1 1", "Draken Civilian", 39025, 9891, 0, 0, 7749, 1f, null, null), 6772, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1388, "Draken Female Civilian Dance1 2", "Draken Civilian", 39048, 8576, 0, 0, 7749, 1f, null, null), 6773, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1389, "Draken Female Civilian Dance1 3", "Draken Civilian", 25335, 8477, 0, 0, 7749, 1f, null, null), 6774, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1390, "Draken Female Civilian Dance1 4", "Draken Civilian", 39027, 10250, 0, 0, 7749, 1f, null, null), 6775, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1391, "Draken Female Civilian Dance1 5", "Draken Civilian", 25363, 9869, 0, 0, 7749, 1f, null, null), 6776, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1392, "Draken Female Civilian Dance1 6", "Draken Civilian", 26893, 9695, 0, 0, 7749, 1f, null, null), 6777, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1393, "Draken Female Civilian Dance1 7", "Draken Civilian", 34446, 9459, 0, 0, 7749, 1f, null, null), 6778, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 1 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1394, "Aurin Male Civilian Dance1 1", "Aurin Civilian", 39036, 8758, 0, 0, 7749, 1f, null, null), 6779, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1395, "Aurin Male Civilian Dance1 2", "Aurin Civilian", 39609, 8416, 0, 0, 7749, 1f, null, null), 6780, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1396, "Aurin Male Civilian Dance1 3", "Aurin Civilian", 41150, 8755, 0, 0, 7749, 1f, null, null), 6781, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1397, "Aurin Male Civilian Dance1 4", "Aurin Civilian", 30179, 9869, 0, 0, 7749, 1f, null, null), 6782, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1398, "Aurin Male Civilian Dance1 5", "Aurin Civilian", 34948, 8211, 0, 0, 7749, 1f, null, null), 6783, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1399, "Aurin Male Civilian Dance1 6", "Aurin Civilian", 32751, 9931, 0, 0, 7749, 1f, null, null), 6784, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1400, "Aurin Male Civilian Dance1 7", "Aurin Civilian", 28319, 9704, 0, 0, 7749, 1f, null, null), 6785, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1401, "Aurin Female Civilian Dance1 1", "Aurin Civilian", 39037, 8416, 0, 0, 7749, 1f, null, null), 6786, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1402, "Aurin Female Civilian Dance1 2", "Aurin Civilian", 39611, 8758, 0, 0, 7749, 1f, null, null), 6787, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1403, "Aurin Female Civilian Dance1 3", "Aurin Civilian", 41213, 8755, 0, 0, 7749, 1f, null, null), 6788, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1404, "Aurin Female Civilian Dance1 4", "Aurin Civilian", 34949, 8211, 0, 0, 7749, 1f, null, null), 6789, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1405, "Aurin Female Civilian Dance1 5", "Aurin Civilian", 38231, 9869, 0, 0, 7749, 1f, null, null), 6790, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1406, "Aurin Female Civilian Dance1 6", "Aurin Civilian", 36300, 9704, 0, 0, 7749, 1f, null, null), 6791, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1407, "Aurin Female Civilian Dance1 7", "Aurin Civilian", 33161, 9931, 0, 0, 7749, 1f, null, null), 6792, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 1 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1408, "Mechari Male Civilian Dance1 1", "Mechari Civilian", 41229, 10310, 0, 0, 7749, 1f, null, null), 6793, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1409, "Mechari Male Civilian Dance1 2", "Mechari Civilian", 29552, 10250, 0, 0, 7749, 1f, null, null), 6794, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1410, "Mechari Male Civilian Dance1 3", "Mechari Civilian", 28346, 9694, 0, 0, 7749, 1f, null, null), 6795, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1411, "Mechari Male Civilian Dance1 4", "Mechari Civilian", 28827, 8496, 0, 0, 7749, 1f, null, null), 6796, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1412, "Mechari Male Civilian Dance1 5", "Mechari Civilian", 28330, 9695, 0, 0, 7749, 1f, null, null), 6797, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1413, "Mechari Male Civilian Dance1 6", "Mechari Civilian", 28312, 10533, 0, 0, 7749, 1f, null, null), 6798, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1414, "Mechari Male Civilian Dance1 7", "Mechari Civilian", 38821, 8229, 0, 0, 7749, 1f, null, null), 6799, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1415, "Mechari Female Civilian Dance1 1", "Mechari Civilian", 41230, 8229, 0, 0, 7749, 1f, null, null), 6800, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1416, "Mechari Female Civilian Dance1 2", "Mechari Civilian", 31745, 8496, 0, 0, 7749, 1f, null, null), 6801, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1417, "Mechari Female Civilian Dance1 3", "Mechari Civilian", 32482, 9695, 0, 0, 7749, 1f, null, null), 6802, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1418, "Mechari Female Civilian Dance1 4", "Mechari Civilian", 28331, 10250, 0, 0, 7749, 1f, null, null), 6803, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1419, "Mechari Female Civilian Dance1 5", "Mechari Civilian", 28313, 9694, 0, 0, 7749, 1f, null, null), 6804, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1420, "Mechari Female Civilian Dance1 6", "Mechari Civilian", 34856, 10533, 0, 0, 7749, 1f, null, null), 6805, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1421, "Mechari Female Civilian Dance1 7", "Mechari Civilian", 32971, 10310, 0, 0, 7749, 1f, null, null), 6806, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 1 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1422, "Chua Dance1 1", "Chua Civilian", 38970, 10250, 0, 0, 7749, 1f, null, null), 6807, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Civilian, Dance 1 (Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1423, "Chua Dance1 2", "Chua Civilian", 36026, 8496, 0, 0, 7749, 1f, null, null), 6808, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "!NEW! Chua Civilian, Dance 1 (Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1424, "Chua Dance1 3", "Chua Civilian", 36027, 8477, 0, 0, 7749, 1f, null, null), 6809, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "!NEW! Chua Civilian, Dance 1 (Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1425, "Chua Dance1 4", "Chua Civilian", 38819, 8229, 0, 0, 7749, 1f, null, null), 6810, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "!NEW! Chua Civilian, Dance 1 (Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1426, "Chua Dance1 5", "Chua Civilian", 30442, 8416, 0, 0, 7749, 1f, null, null), 6811, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "!NEW! Chua Civilian, Dance 1 (Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1427, "Chua Dance1 6", "Chua Civilian", 30344, 9694, 0, 0, 7749, 1f, null, null), 6812, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "!NEW! Chua Civilian, Dance 1 (Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1428, "Chua Dance1 7", "Chua Civilian", 30857, 10533, 0, 0, 7749, 1f, null, null), 6813, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m9", "!NEW! Chua Civilian, Dance 1 (Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1429, "Granok Male Dance1 1", "Granok Civilian", 28351, 9931, 0, 0, 7749, 1f, null, null), 6814, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1430, "Granok Male Dance1 2", "Granok Civilian", 26330, 9720, 0, 0, 7749, 1f, null, null), 6815, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1431, "Granok Male Dance1 3", "Granok Civilian", 24358, 9869, 0, 0, 7749, 1f, null, null), 6816, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1432, "Granok Male Dance1 4", "Granok Civilian", 25162, 9459, 0, 0, 7749, 1f, null, null), 6817, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1433, "Granok Male Dance1 5", "Granok Civilian", 24081, 8477, 0, 0, 7749, 1f, null, null), 6818, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1434, "Granok Male Dance1 6", "Granok Civilian", 24438, 9928, 0, 0, 7749, 1f, null, null), 6819, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1435, "Granok Male Dance1 7", "Granok Civilian", 24715, 8757, 0, 0, 7749, 1f, null, null), 6820, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1436, "Granok Female Dance1 1", "Granok Civilian", 34764, 8416, 0, 0, 7749, 1f, null, null), 6821, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1437, "Granok Female Dance1 2", "Granok Civilian", 41222, 9720, 0, 0, 7749, 1f, null, null), 6822, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1438, "Granok Female Dance1 3", "Granok Civilian", 39612, 9869, 0, 0, 7749, 1f, null, null), 6823, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1439, "Granok Female Dance1 4", "Granok Civilian", 41303, 9459, 0, 0, 7749, 1f, null, null), 6824, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1440, "Granok Female Dance1 5", "Granok Civilian", 28040, 8477, 0, 0, 7749, 1f, null, null), 6825, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1441, "Granok Female Dance1 6", "Granok Civilian", 36055, 9928, 0, 0, 7749, 1f, null, null), 6826, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1442, "Granok Female Dance1 7", "Granok Civilian", 34766, 8757, 0, 0, 7755, 1f, null, null), 6827, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 1 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1443, "Highborn Cassian Male Dance2 1", "Cassian Noble", 28323, 10106, 0, 0, 7755, 1f, null, null), 6828, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1444, "Highborn Cassian Male Dance2 2", "Cassian Noble", 38818, 9695, 0, 0, 7755, 1f, null, null), 6829, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1445, "Highborn Cassian Male Dance2 3", "Cassian Noble", 34859, 10105, 0, 0, 7755, 1f, null, null), 6830, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1446, "Highborn Cassian Male Dance2 4", "Cassian Noble", 25049, 9695, 0, 0, 7755, 1f, null, null), 6831, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1447, "Highborn Cassian Male Dance2 5", "Cassian Noble", 36287, 9704, 0, 0, 7755, 1f, null, null), 6832, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1448, "Highborn Cassian Male Dance2 6", "Cassian Noble", 30880, 9694, 0, 0, 7755, 1f, null, null), 6833, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1449, "Highborn Cassian Male Dance2 7", "Cassian Noble", 30172, 8229, 0, 0, 7755, 1f, null, null), 6834, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1450, "Lowborn Cassian Male Dance2 1", "Cassian Commoner", 28300, 10250, 0, 0, 7755, 1f, null, null), 6835, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1451, "Lowborn Cassian Male Dance2 2", "Cassian Commoner", 25809, 10110, 0, 0, 7755, 1f, null, null), 6836, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1452, "Lowborn Cassian Male Dance2 3", "Cassian Commoner", 28260, 8755, 0, 0, 7755, 1f, null, null), 6837, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1453, "Lowborn Cassian Male Dance2 4", "Cassian Commoner", 30597, 10533, 0, 0, 7755, 1f, null, null), 6838, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1454, "Lowborn Cassian Male Dance2 5", "Cassian Commoner", 30897, 8757, 0, 0, 7755, 1f, null, null), 6839, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1455, "Lowborn Cassian Male Dance2 6", "Cassian Commoner", 25653, 8754, 0, 0, 7755, 1f, null, null), 6840, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1456, "Lowborn Cassian Male Dance2 7", "Cassian Commoner", 28341, 9459, 0, 0, 7755, 1f, null, null), 6841, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1457, "Exiled Human Male Dance2 1", "Human Civilian", 28308, 8754, 0, 0, 7755, 1f, null, null), 6842, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1458, "Exiled Human Male Dance2 2", "Human Civilian", 28349, 10250, 0, 0, 7755, 1f, null, null), 6843, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1459, "Exiled Human Male Dance2 3", "Human Civilian", 29477, 8755, 0, 0, 7755, 1f, null, null), 6844, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1460, "Exiled Human Male Dance2 4", "Human Civilian", 28033, 9931, 0, 0, 7755, 1f, null, null), 6845, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1461, "Exiled Human Male Dance2 5", "Human Civilian", 27346, 8211, 0, 0, 7755, 1f, null, null), 6846, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1462, "Exiled Human Male Dance2 6", "Human Civilian", 32799, 8757, 0, 0, 7755, 1f, null, null), 6847, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1463, "Exiled Human Male Dance2 7", "Human Civilian", 24796, 8758, 0, 0, 7755, 1f, null, null), 6848, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1464, "Highborn Cassian Female Dance2 1", "Cassian Noble", 30666, 8229, 0, 0, 7755, 1f, null, null), 6849, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1465, "Highborn Cassian Female Dance2 2", "Cassian Noble", 30240, 9694, 0, 0, 7755, 1f, null, null), 6850, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1466, "Highborn Cassian Female Dance2 3", "Cassian Noble", 34860, 10106, 0, 0, 7755, 1f, null, null), 6851, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1467, "Highborn Cassian Female Dance2 4", "Cassian Noble", 29475, 9704, 0, 0, 7755, 1f, null, null), 6852, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1468, "Highborn Cassian Female Dance2 5", "Cassian Noble", 41300, 9695, 0, 0, 7755, 1f, null, null), 6853, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1469, "Highborn Cassian Female Dance2 6", "Cassian Noble", 28324, 10105, 0, 0, 7755, 1f, null, null), 6854, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1470, "Highborn Cassian Female Dance2 7", "Cassian Noble", 30599, 8496, 0, 0, 7755, 1f, null, null), 6855, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Highborn Cassian, Dance 2 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1471, "Lowborn Cassian Female Dance2 1", "Cassian Commoner", 34858, 10250, 0, 0, 7755, 1f, null, null), 6856, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1472, "Lowborn Cassian Female Dance2 2", "Cassian Commoner", 28301, 10533, 0, 0, 7755, 1f, null, null), 6857, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1473, "Lowborn Cassian Female Dance2 3", "Cassian Commoner", 30748, 9869, 0, 0, 7755, 1f, null, null), 6858, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1474, "Lowborn Cassian Female Dance2 4", "Cassian Commoner", 31426, 8757, 0, 0, 7755, 1f, null, null), 6859, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1475, "Lowborn Cassian Female Dance2 5", "Cassian Commoner", 25336, 8754, 0, 0, 7755, 1f, null, null), 6860, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1476, "Lowborn Cassian Female Dance2 6", "Cassian Commoner", 34862, 9459, 0, 0, 7755, 1f, null, null), 6861, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1477, "Lowborn Cassian Female Dance2 7", "Cassian Commoner", 34870, 8416, 0, 0, 7755, 1f, null, null), 6862, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Lowborn Cassian, Dance 2 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1478, "Exiled Human Female Dance2 1", "Human Civilian", 28309, 8758, 0, 0, 7755, 1f, null, null), 6863, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1479, "Exiled Human Female Dance2 2", "Human Civilian", 30112, 10250, 0, 0, 7755, 1f, null, null), 6864, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1480, "Exiled Human Female Dance2 3", "Human Civilian", 25887, 8416, 0, 0, 7755, 1f, null, null), 6865, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1481, "Exiled Human Female Dance2 4", "Human Civilian", 30194, 8755, 0, 0, 7755, 1f, null, null), 6866, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1482, "Exiled Human Female Dance2 5", "Human Civilian", 30178, 9869, 0, 0, 7755, 1f, null, null), 6867, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1483, "Exiled Human Female Dance2 6", "Human Civilian", 27562, 8211, 0, 0, 7755, 1f, null, null), 6868, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1484, "Exiled Human Female Dance2 7", "Human Civilian", 25051, 8416, 0, 0, 7755, 1f, null, null), 6869, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Exiled Human, Dance 2 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1485, "Draken Male Civilian Dance2 1", "Draken Civilian", 39029, 9891, 0, 0, 7755, 1f, null, null), 6870, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1486, "Draken Male Civilian Dance2 2", "Draken Civilian", 39046, 8576, 0, 0, 7755, 1f, null, null), 6871, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1487, "Draken Male Civilian Dance2 3", "Draken Civilian", 28270, 8477, 0, 0, 7755, 1f, null, null), 6872, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1488, "Draken Male Civilian Dance2 4", "Draken Civilian", 28325, 10250, 0, 0, 7755, 1f, null, null), 6873, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1489, "Draken Male Civilian Dance2 5", "Draken Civilian", 28359, 9869, 0, 0, 7755, 1f, null, null), 6874, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1490, "Draken Male Civilian Dance2 6", "Draken Civilian", 28295, 9459, 0, 0, 7755, 1f, null, null), 6875, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1491, "Draken Male Civilian Dance2 7", "Draken Civilian", 36304, 9695, 0, 0, 7755, 1f, null, null), 6876, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1492, "Draken Female Civilian Dance2 1", "Draken Civilian", 39025, 9891, 0, 0, 7755, 1f, null, null), 6877, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1493, "Draken Female Civilian Dance2 2", "Draken Civilian", 39048, 8576, 0, 0, 7755, 1f, null, null), 6878, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1494, "Draken Female Civilian Dance2 3", "Draken Civilian", 25335, 8477, 0, 0, 7755, 1f, null, null), 6879, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1495, "Draken Female Civilian Dance2 4", "Draken Civilian", 39027, 10250, 0, 0, 7755, 1f, null, null), 6880, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1496, "Draken Female Civilian Dance2 5", "Draken Civilian", 25363, 9869, 0, 0, 7755, 1f, null, null), 6881, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1497, "Draken Female Civilian Dance2 6", "Draken Civilian", 26893, 9695, 0, 0, 7755, 1f, null, null), 6882, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1498, "Draken Female Civilian Dance2 7", "Draken Civilian", 34446, 9459, 0, 0, 7755, 1f, null, null), 6883, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Civilian, Dance 2 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1499, "Aurin Male Civilian Dance2 1", "Aurin Civilian", 39036, 8758, 0, 0, 7755, 1f, null, null), 6884, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1500, "Aurin Male Civilian Dance2 2", "Aurin Civilian", 39609, 8416, 0, 0, 7755, 1f, null, null), 6885, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1501, "Aurin Male Civilian Dance2 3", "Aurin Civilian", 41150, 8755, 0, 0, 7755, 1f, null, null), 6886, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1502, "Aurin Male Civilian Dance2 4", "Aurin Civilian", 30179, 9869, 0, 0, 7755, 1f, null, null), 6887, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1503, "Aurin Male Civilian Dance2 5", "Aurin Civilian", 34948, 8211, 0, 0, 7755, 1f, null, null), 6888, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1504, "Aurin Male Civilian Dance2 6", "Aurin Civilian", 32751, 9931, 0, 0, 7755, 1f, null, null), 6889, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1505, "Aurin Male Civilian Dance2 7", "Aurin Civilian", 28319, 9704, 0, 0, 7755, 1f, null, null), 6890, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1506, "Aurin Female Civilian Dance2 1", "Aurin Civilian", 39037, 8416, 0, 0, 7755, 1f, null, null), 6891, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1507, "Aurin Female Civilian Dance2 2", "Aurin Civilian", 39611, 8758, 0, 0, 7755, 1f, null, null), 6892, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1508, "Aurin Female Civilian Dance2 3", "Aurin Civilian", 41213, 8755, 0, 0, 7755, 1f, null, null), 6893, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1509, "Aurin Female Civilian Dance2 4", "Aurin Civilian", 34949, 8211, 0, 0, 7755, 1f, null, null), 6894, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1510, "Aurin Female Civilian Dance2 5", "Aurin Civilian", 38231, 9869, 0, 0, 7755, 1f, null, null), 6895, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1511, "Aurin Female Civilian Dance2 6", "Aurin Civilian", 36300, 9704, 0, 0, 7755, 1f, null, null), 6896, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1512, "Aurin Female Civilian Dance2 7", "Aurin Civilian", 33161, 9931, 0, 0, 7755, 1f, null, null), 6897, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Civilian, Dance 2 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1513, "Mechari Male Civilian Dance2 1", "Mechari Civilian", 41229, 10310, 0, 0, 7755, 1f, null, null), 6898, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1514, "Mechari Male Civilian Dance2 2", "Mechari Civilian", 29552, 10250, 0, 0, 7755, 1f, null, null), 6899, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1515, "Mechari Male Civilian Dance2 3", "Mechari Civilian", 28346, 9694, 0, 0, 7755, 1f, null, null), 6900, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1516, "Mechari Male Civilian Dance2 4", "Mechari Civilian", 28827, 8496, 0, 0, 7755, 1f, null, null), 6901, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1517, "Mechari Male Civilian Dance2 5", "Mechari Civilian", 28330, 9695, 0, 0, 7755, 1f, null, null), 6902, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1518, "Mechari Male Civilian Dance2 6", "Mechari Civilian", 28312, 10533, 0, 0, 7755, 1f, null, null), 6903, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1519, "Mechari Male Civilian Dance2 7", "Mechari Civilian", 38821, 8229, 0, 0, 7755, 1f, null, null), 6904, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1520, "Mechari Female Civilian Dance2 1", "Mechari Civilian", 41230, 8229, 0, 0, 7755, 1f, null, null), 6905, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1521, "Mechari Female Civilian Dance2 2", "Mechari Civilian", 31745, 8496, 0, 0, 7755, 1f, null, null), 6906, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1522, "Mechari Female Civilian Dance2 3", "Mechari Civilian", 32482, 9695, 0, 0, 7755, 1f, null, null), 6907, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1523, "Mechari Female Civilian Dance2 4", "Mechari Civilian", 28331, 10250, 0, 0, 7755, 1f, null, null), 6908, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1524, "Mechari Female Civilian Dance2 5", "Mechari Civilian", 28313, 9694, 0, 0, 7755, 1f, null, null), 6909, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1525, "Mechari Female Civilian Dance2 6", "Mechari Civilian", 34856, 10533, 0, 0, 7755, 1f, null, null), 6910, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1526, "Mechari Female Civilian Dance2 7", "Mechari Civilian", 32971, 10310, 0, 0, 7755, 1f, null, null), 6911, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Civilian, Dance 2 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1527, "Chua Dance2 1", "Chua Civilian", 38970, 10250, 0, 0, 7755, 1f, null, null), 6912, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Civilian, Dance 2 (Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1528, "Chua Dance2 2", "Chua Civilian", 36026, 8496, 0, 0, 7755, 1f, null, null), 6913, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m4", "!NEW! Chua Civilian, Dance 2 (Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1529, "Chua Dance2 3", "Chua Civilian", 36027, 8477, 0, 0, 7755, 1f, null, null), 6914, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m5", "!NEW! Chua Civilian, Dance 2 (Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1530, "Chua Dance2 4", "Chua Civilian", 38819, 8229, 0, 0, 7755, 1f, null, null), 6915, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m6", "!NEW! Chua Civilian, Dance 2 (Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1531, "Chua Dance2 5", "Chua Civilian", 30442, 8416, 0, 0, 7755, 1f, null, null), 6916, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m7", "!NEW! Chua Civilian, Dance 2 (Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1532, "Chua Dance2 6", "Chua Civilian", 30344, 9694, 0, 0, 7755, 1f, null, null), 6917, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m8", "!NEW! Chua Civilian, Dance 2 (Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1533, "Chua Dance2 7", "Chua Civilian", 30857, 10533, 0, 0, 7755, 1f, null, null), 6918, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m9", "!NEW! Chua Civilian, Dance 2 (Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1534, "Granok Male Dance2 1", "Granok Civilian", 28351, 9931, 0, 0, 7755, 1f, null, null), 6919, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1535, "Granok Male Dance2 2", "Granok Civilian", 26330, 9720, 0, 0, 7755, 1f, null, null), 6920, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1536, "Granok Male Dance2 3", "Granok Civilian", 24358, 9869, 0, 0, 7755, 1f, null, null), 6921, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1537, "Granok Male Dance2 4", "Granok Civilian", 25162, 9459, 0, 0, 7755, 1f, null, null), 6922, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1538, "Granok Male Dance2 5", "Granok Civilian", 24081, 8477, 0, 0, 7755, 1f, null, null), 6923, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1539, "Granok Male Dance2 6", "Granok Civilian", 24438, 9928, 0, 0, 7755, 1f, null, null), 6924, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1540, "Granok Male Dance2 7", "Granok Civilian", 24715, 8757, 0, 0, 7755, 1f, null, null), 6925, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1541, "Granok Female Dance2 1", "Granok Civilian", 34764, 8416, 0, 0, 7755, 1f, null, null), 6926, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1542, "Granok Female Dance2 2", "Granok Civilian", 41222, 9720, 0, 0, 7755, 1f, null, null), 6927, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1543, "Granok Female Dance2 3", "Granok Civilian", 39612, 9869, 0, 0, 7755, 1f, null, null), 6928, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1544, "Granok Female Dance2 4", "Granok Civilian", 41303, 9459, 0, 0, 7755, 1f, null, null), 6929, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1545, "Granok Female Dance2 5", "Granok Civilian", 28040, 8477, 0, 0, 7755, 1f, null, null), 6930, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1546, "Granok Female Dance2 6", "Granok Civilian", 36055, 9928, 0, 0, 7755, 1f, null, null), 6931, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1547, "Granok Female Dance2 7", "Granok Civilian", 34766, 8757, 0, 0, 7755, 1f, null, null), 6932, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Civilian, Dance 2 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1548, "Exile Repairbot", "Repair Bot", 29791, 0, 0, 0, 0, 1f, null, null), 6933, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Engineer Repair Bot, Blue", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1549, "Exile Artillerybot", "Artillery Bot", 30104, 0, 0, 0, 0, 1f, null, null), 6934, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Engineer Artillery Bot, Blue", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1550, "Exile Diminisherbot", "Diminisher Bot", 30103, 0, 0, 0, 0, 1f, null, null), 6935, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Engineer Diminisher Bot, Blue", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1551, "Exile Bruiserbot", "Bruiser Bot", 29907, 0, 0, 0, 0, 1f, null, null), 6936, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Engineer Bruiser Bot, Blue", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1552, "Dominion Repairbot", "Repair Bot", 34662, 0, 0, 0, 0, 1f, null, null), 6937, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Engineer Repair Bot, Red", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1553, "Dominion Artillerybot", "Artillery Bot", 34663, 0, 0, 0, 0, 1f, null, null), 6938, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Engineer Artillery Bot, Red", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1554, "Dominion Diminisherbot", "Diminisher Bot", 34660, 0, 0, 0, 0, 1f, null, null), 6939, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Engineer Diminisher Bot, Red", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1555, "Dominion Bruiserbot", "Bruiser Bot", 34661, 0, 0, 0, 0, 1f, null, null), 6940, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Engineer Bruiser Bot, Red", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1556, "Scanbot 1", "Scanbot", 25599, 0, 0, 0, 0, 1f, null, null), 6941, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Scientist Scanbot (Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1557, "Scanbot 2", "Scanbot", 27621, 0, 0, 0, 0, 1f, null, null), 6942, "Art\\Prop\\Constructed\\gear\\PRP_Gear_LargeGear_000.m3", "!NEW! Scientist Scanbot (Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1558, "Blue Hookfoot", "Hookfoot", 28606, 0, 0, 0, 0, 1f, null, null), 6943, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Hookfoot, Blue", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1559, "Violet Hookfoot", "Hookfoot", 37702, 0, 0, 0, 0, 1f, null, null), 6944, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Hookfoot, Violet", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1560, "Augmented Hookfoot", "Augmented Hookfoot", 31090, 0, 0, 0, 0, 1f, null, null), 6945, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Hookfoot, Augmented", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1561, "Blue Splorg", "Splorg", 24473, 0, 0, 0, 0, 1f, null, null), 6946, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Splorg, Blue", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1562, "Violet Splorg", "Splorg", 31424, 0, 0, 0, 0, 1f, null, null), 6947, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Splorg, Violet", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1563, "Teal Splorg", "Splorg", 31425, 0, 0, 0, 0, 1f, null, null), 6948, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Splorg, Teal", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1564, "Dynamite Splorg", "Dynamite Splorg", 30719, 0, 0, 0, 0, 1f, null, null), 6949, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Splorg, Dynamite", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1565, "Pink Squirg", "Squirg Squishling", 30718, 0, 0, 0, 0, 1f, null, null), 6950, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Squishling, Pink", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1566, "Blue Squirg", "Squirg Squishling", 31613, 0, 0, 0, 0, 1f, null, null), 6951, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Squishling, Blue", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1567, "Peach Squirg", "Squirg Squishling", 24218, 0, 0, 0, 0, 1f, null, null), 6952, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Squishling, Peach", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1568, "Strain Squirg", "Strain-Corrupted Squishling", 31274, 0, 0, 0, 0, 1f, null, null), 6953, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Squirg Squishling, Strain", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1569, "Squirg Legionnaire Cassian M", "Squirg Legionnaire", 28293, 10196, 149, 0, 0, 1f, null, null), 6954, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Legionnaire, Cassian (Male)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1570, "Squirg Trooper Human M", "Squirg Trooper", 28293, 10194, 594, 0, 0, 1f, null, null), 6955, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Trooper, Human (Male)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1571, "Squirg Legionnaire Cassian F", "Squirg Legionnaire", 28294, 10196, 149, 0, 0, 1f, null, null), 6956, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Legionnaire, Cassian (Female)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1572, "Squirg Trooper Human F", "Squirg Trooper", 28286, 10194, 594, 0, 0, 1f, null, null), 6957, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Trooper, Human (Female)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1573, "Squirg Zombie Granok M", "Squirg Zombie", 27801, 9545, 0, 0, 0, 1f, null, null), 6958, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Zombie, Granok (Male)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1574, "Squirg Attack Garr", "Squirg Attack Garr", 31612, 0, 0, 0, 0, 1f, null, null), 6959, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Attack Garr", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1575, "Squirg Attack Hound", "Squirg Attack Hound", 31611, 0, 0, 0, 0, 1f, null, null), 6960, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Attack Hound", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1576, "Squirg Queen", "Squirg Queen", 31739, 0, 0, 0, 0, 1f, null, null), 6961, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Squirg Queen", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1577, "Lavender Jellibolli", "Lavender Jellibolli", 24196, 0, 0, 0, 0, 1f, null, null), 6962, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Jelliboli, Lavender", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1578, "Jelliboli Polyp", "Jelliboli Polyp", 34566, 0, 0, 0, 0, 1f, null, null), 6963, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Jelliboli Polyp", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1579, "Sunfire Jellibolli", "Sunfire Jellibolli", 37688, 0, 0, 0, 0, 1f, null, null), 6964, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Jellibolli, Sunfire", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1580, "Pinkfin Steamglider", "Pinkfin Steamglider", 24190, 0, 0, 0, 0, 1f, null, null), 6965, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Steamglider, Pinkfin", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1581, "Greenfin Steamglider", "Greenfin Steamglider", 25727, 0, 0, 0, 0, 1f, null, null), 6966, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Steamglider, Greenfin", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1582, "Strain Steamglider", "Strain Steamglider", 31307, 0, 0, 0, 0, 1f, null, null), 6967, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Steamglider, Strain", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1583, "Yellowfin Steamglider", "Yellowfin Steamglider", 31409, 0, 0, 0, 0, 1f, null, null), 6968, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Steamglider, Yellowfin", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1584, "Tealfin Steamglider", "Tealfin Steamglider", 31408, 0, 0, 0, 0, 1f, null, null), 6969, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Steamglider, Tealfin", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1585, "Sunset Steamglider", "Sunset Steamglider", 25725, 0, 0, 0, 0, 1f, null, null), 6970, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Steamglider, Sunset", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1586, "Sunrise Steamglider", "Sunrise Steamglider", 31407, 0, 0, 0, 0, 1f, null, null), 6971, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Steamglider, Sunrise", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1587, "Moonglow Steamglider", "Moonglow Steamglider", 25726, 0, 0, 0, 0, 1f, null, null), 6972, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Steamglider, Moonglow", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1588, "Browncap Rootbrute", "Browncap Rootbrute", 24275, 0, 0, 0, 0, 1f, null, null), 6973, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Rootbrute, Browncap", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1589, "Snowcap Rootbrute", "Snowcap Rootbrute", 25735, 0, 0, 0, 0, 1f, null, null), 6974, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Rootbrute, Snowcap", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1590, "Firecap Rootbrute", "Firecap Rootbrute", 25737, 0, 0, 0, 0, 1f, null, null), 6975, "Art\\Prop\\Constructed\\Busts\\SanctuaryCommon\\PRP_Bust_SkullwithTusks_Ivory_001.m3", "!NEW! Rootbrute, Firecap", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1591, "Augmented Rootbrute", "Augmented Rootbrute", 30387, 0, 0, 0, 0, 1f, null, null), 6976, "Art\\Prop\\Dungeon\\Exolabs\\GreenTube_Medium\\PRP_Exolabs_GreenTube_Medium.m3", "!NEW! Rootbrute, Augmented", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1592, "Strain Rootbrute", "Strain-Corrupted Rootbrute", 31660, 0, 0, 0, 0, 1f, null, null), 6977, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Rootbrute, Strain", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1593, "White Terminite", "White Terminite", 24278, 0, 0, 0, 0, 1f, null, null), 6978, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Terminite, White", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1594, "Brown Terminite", "Brown Terminite", 25508, 0, 0, 0, 0, 1f, null, null), 6979, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Terminite, Brown", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1595, "Grey Terminite", "Grey Terminite", 25510, 0, 0, 0, 0, 1f, null, null), 6980, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Terminite, Grey", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1596, "Alien Terminite", "Alien Terminite", 28043, 0, 0, 0, 0, 1f, null, null), 6981, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Terminite, Alien", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1597, "Green Fraz", "Green Fraz", 24340, 0, 0, 0, 0, 1f, null, null), 6982, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Fraz, Green", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1598, "Grey Fraz", "Grey Fraz", 25462, 0, 0, 0, 0, 1f, null, null), 6983, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Fraz, Grey", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1599, "Strain Fraz", "Strain-Corrupted Fraz", 31270, 0, 0, 0, 0, 1f, null, null), 6984, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Fraz, Strain", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1600, "Green Frizlet", "Green Frizlet", 24439, 0, 0, 0, 0, 1f, null, null), 6985, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Frizlet, Green", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1601, "Grey Frizlet", "Grey Frizlet", 28575, 0, 0, 0, 0, 1f, null, null), 6986, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Frizlet, Grey", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1602, "Strain Frizlet", "Strain Frizlet", 31359, 0, 0, 0, 0, 1f, null, null), 6987, "Art\\Prop\\Natural\\Strain\\Eyestalks\\PRP_Strain_EyeStalks_000.m3", "!NEW! Frizlet, Strain", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1603, "Red Frizlet", "Red Frizlet", 34564, 0, 0, 0, 0, 1f, null, null), 6988, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Frizlet, Red", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1604, "Violet Skug", "Skug", 24096, 0, 0, 0, 0, 1f, null, null), 6989, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Skug, Violet", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1605, "Pink Skug", "Skug", 23917, 0, 0, 0, 0, 1f, null, null), 6990, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Skug, Pink", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1606, "Alien Skug Queen", "Skug Queen", 28063, 0, 0, 0, 0, 1f, null, null), 6991, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Skug Queen, Alien", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1607, "Pink Skug Queen", "Skug Queen", 23918, 0, 0, 0, 0, 1f, null, null), 6992, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Skug Queen, Pink", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1608, "Skug Larva", "Skug Larva", 37793, 0, 0, 0, 0, 1f, null, null), 6993, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Skug Larva", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1609, "Orbitog", "Orbitog", 31441, 0, 0, 0, 0, 1f, null, null), 6994, "Art\\Prop\\Natural\\Rock\\Astroid\\PRP_Rock_Asteroid_HalonRing_002.m3", "!NEW! Orbitog", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1715, "Mordesh Dance1 Male 1", "Mordesh Civilian", 26016, 9928, 0, 0, 7749, 1f, null, null), 7100, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1716, "Mordesh Dance1 Male 2", "Mordesh Civilian", 28355, 8758, 0, 0, 7749, 1f, null, null), 7101, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1717, "Mordesh Dance1 Male 3", "Mordesh Civilian", 31867, 8755, 0, 0, 7749, 1f, null, null), 7102, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1718, "Mordesh Dance1 Male 4", "Mordesh Civilian", 39614, 9694, 0, 0, 7749, 1f, null, null), 7103, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1719, "Mordesh Dance1 Male 5", "Mordesh Civilian", 35001, 8757, 0, 0, 7749, 1f, null, null), 7104, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1720, "Mordesh Dance1 Male 6", "Mordesh Civilian", 35002, 10533, 0, 0, 7749, 1f, null, null), 7105, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1721, "Mordesh Dance1 Male 7", "Mordesh Civilian", 34899, 10667, 0, 0, 7749, 1f, null, null), 7106, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1722, "Mordesh Dance1 Female 1", "Mordesh Civilian", 41224, 9928, 0, 0, 7749, 1f, null, null), 7107, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1723, "Mordesh Dance1 Female 2", "Mordesh Civilian", 41142, 8758, 0, 0, 7749, 1f, null, null), 7108, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1724, "Mordesh Dance1 Female 3", "Mordesh Civilian", 33190, 9694, 0, 0, 7749, 1f, null, null), 7109, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1725, "Mordesh Dance1 Female 4", "Mordesh Civilian", 34816, 8755, 0, 0, 7749, 1f, null, null), 7110, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1726, "Mordesh Dance1 Female 5", "Mordesh Civilian", 40919, 8757, 0, 0, 7749, 1f, null, null), 7111, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1727, "Mordesh Dance1 Female 6", "Mordesh Civilian", 36298, 10533, 0, 0, 7749, 1f, null, null), 7112, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1728, "Mordesh Dance1 Female 7", "Mordesh Civilian", 41153, 10667, 0, 0, 7749, 1f, null, null), 7113, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 1  (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1729, "Mordesh Male Dance1 1", "Mordesh Civilian", 26016, 9928, 0, 0, 7755, 1f, null, null), 7114, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1730, "Mordesh Male Dance1 2", "Mordesh Civilian", 28355, 8758, 0, 0, 7755, 1f, null, null), 7115, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1731, "Mordesh Male Dance1 3", "Mordesh Civilian", 31867, 8755, 0, 0, 7755, 1f, null, null), 7116, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1732, "Mordesh Male Dance1 4", "Mordesh Civilian", 39614, 9694, 0, 0, 7755, 1f, null, null), 7117, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1733, "Mordesh Male Dance1 5", "Mordesh Civilian", 35001, 8757, 0, 0, 7755, 1f, null, null), 7118, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1734, "Mordesh Male Dance1 6", "Mordesh Civilian", 35002, 10533, 0, 0, 7755, 1f, null, null), 7119, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1735, "Mordesh Male Dance1 7", "Mordesh Civilian", 34899, 10667, 0, 0, 7755, 1f, null, null), 7120, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1736, "Mordesh Female Dance1 1", "Mordesh Civilian", 41224, 9928, 0, 0, 7755, 1f, null, null), 7121, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1737, "Mordesh Female Dance1 2", "Mordesh Civilian", 41142, 8758, 0, 0, 7755, 1f, null, null), 7122, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1738, "Mordesh Female Dance1 3", "Mordesh Civilian", 33190, 9694, 0, 0, 7755, 1f, null, null), 7123, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1739, "Mordesh Female Dance1 4", "Mordesh Civilian", 34816, 8755, 0, 0, 7755, 1f, null, null), 7124, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1740, "Mordesh Female Dance1 5", "Mordesh Civilian", 40919, 8757, 0, 0, 7755, 1f, null, null), 7125, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1741, "Mordesh Female Dance1 6", "Mordesh Civilian", 36298, 10533, 0, 0, 7755, 1f, null, null), 7126, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1742, "Mordesh Female Dance1 7", "Mordesh Civilian", 41153, 10667, 0, 0, 7755, 1f, null, null), 7127, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Dance 2 (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1743, "Mordesh Floorsit Male 1", "Mordesh Civilian", 26016, 9928, 0, 0, 1467, 1f, null, null), 7128, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1744, "Mordesh Floorsit Male 2", "Mordesh Civilian", 28355, 8758, 0, 0, 1467, 1f, null, null), 7129, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1745, "Mordesh Floorsit Male 3", "Mordesh Civilian", 31867, 8755, 0, 0, 1467, 1f, null, null), 7130, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1746, "Mordesh Floorsit Male 4", "Mordesh Civilian", 39614, 9694, 0, 0, 1467, 1f, null, null), 7131, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1747, "Mordesh Floorsit Male 5", "Mordesh Civilian", 35001, 8757, 0, 0, 1467, 1f, null, null), 7132, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1748, "Mordesh Floorsit Male 6", "Mordesh Civilian", 35002, 10533, 0, 0, 1467, 1f, null, null), 7133, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1749, "Mordesh Floorsit Male 7", "Mordesh Civilian", 34899, 10667, 0, 0, 1467, 1f, null, null), 7134, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1750, "Mordesh Floorsit Female 1", "Mordesh Civilian", 41224, 9928, 0, 0, 1467, 1f, null, null), 7135, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1751, "Mordesh Floorsit Female 2", "Mordesh Civilian", 41142, 8758, 0, 0, 1467, 1f, null, null), 7136, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1752, "Mordesh Floorsit Female 3", "Mordesh Civilian", 33190, 9694, 0, 0, 1467, 1f, null, null), 7137, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1753, "Mordesh Floorsit Female 4", "Mordesh Civilian", 34816, 8755, 0, 0, 1467, 1f, null, null), 7138, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1754, "Mordesh Floorsit Female 5", "Mordesh Civilian", 40919, 8757, 0, 0, 1467, 1f, null, null), 7139, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1755, "Mordesh Floorsit Female 6", "Mordesh Civilian", 36298, 10533, 0, 0, 1467, 1f, null, null), 7140, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1756, "Mordesh Floorsit Female 7", "Mordesh Civilian", 41153, 10667, 0, 0, 1467, 1f, null, null), 7141, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Floor Sit  (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1757, "Mordesh Male Taxisit 1", "Mordesh Civilian", 26016, 9928, 0, 0, 7592, 1f, null, null), 7142, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1758, "Mordesh Male Taxisit 2", "Mordesh Civilian", 28355, 8758, 0, 0, 7592, 1f, null, null), 7143, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1759, "Mordesh Male Taxisit 3", "Mordesh Civilian", 31867, 8755, 0, 0, 7592, 1f, null, null), 7144, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1760, "Mordesh Male Taxisit 4", "Mordesh Civilian", 39614, 9694, 0, 0, 7592, 1f, null, null), 7145, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1761, "Mordesh Male Taxisit 5", "Mordesh Civilian", 35001, 8757, 0, 0, 7592, 1f, null, null), 7146, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1762, "Mordesh Male Taxisit 6", "Mordesh Civilian", 35002, 10533, 0, 0, 7592, 1f, null, null), 7147, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1763, "Mordesh Male Taxisit 7", "Mordesh Civilian", 34899, 10667, 0, 0, 7592, 1f, null, null), 7148, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1764, "Mordesh Female Taxisit 1", "Mordesh Civilian", 41224, 9928, 0, 0, 7592, 1f, null, null), 7149, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1765, "Mordesh Female Taxisit 2", "Mordesh Civilian", 41142, 8758, 0, 0, 7592, 1f, null, null), 7150, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1766, "Mordesh Female Taxisit 3", "Mordesh Civilian", 33190, 9694, 0, 0, 7592, 1f, null, null), 7151, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1767, "Mordesh Female Taxisit 4", "Mordesh Civilian", 34816, 8755, 0, 0, 7592, 1f, null, null), 7152, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1768, "Mordesh Female Taxisit 5", "Mordesh Civilian", 40919, 8757, 0, 0, 7592, 1f, null, null), 7153, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1769, "Mordesh Female Taxisit 6", "Mordesh Civilian", 36298, 10533, 0, 0, 7592, 1f, null, null), 7154, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1770, "Mordesh Female Taxisit 7", "Mordesh Civilian", 41153, 10667, 0, 0, 7592, 1f, null, null), 7155, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Civilian, Taxi Sit (Female, Style 7)", 14);
            AddWorldLayer(1288, "Fallow_Ground", 105, 3, 0, 0, 0, 4, "Art\\Terrain\\Plant\\Terrain_Plant_CropLeafy_Green_000_Color.tex", "Art\\Terrain\\Plant\\Terrain_Plant_CropLeafy_Green_000_Normal.tex", null, 8, 23, 0, 111, 112, 0, 0, 0, 0);
            AddWorldLayer(1289, "Rocky_2_Secondary", 981, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            AddWorldLayer(1290, null, 476, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            AddWorldLayer(1291, null, 359, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
            AddWorldLayer(1292, "Alien_Flora", 658, 3, 0, -0.5f, 0, 16, "Art\\Terrain\\_HalonRing\\Terrain_Rock_MoonSlime_YellowGreen_000_Color.tex", "Art\\Terrain\\_HalonRing\\Terrain_Rock_MoonSlime_YellowGreen_000_Normal.tex", 2134927481, 1, 0, 313, 0, 0, 0, 4291676874, 0, 0);
            AddWorldLayer(1293, "Alien_Flora2", 271, 3, 0, 0, 0, 8, "Art\\Terrain\\_HalonRing\\Terrain_Rock_MoonSlime_YellowGreen_001_Color.tex", "Art\\Terrain\\_HalonRing\\Terrain_Rock_MoonSlime_YellowGreen_000_Normal.tex", 2139378479, 1, 308, 306, 307, 0, 0, 0, 0, 0);
            AddWorldLayer(1294, "Alien_Dust", 336, 2, 1, 0, 0, 32, "Art\\Terrain\\_HalonRing\\Terrain_Rock_AsteroidDust_BlueGrey_000_Color.tex", "Art\\Terrain\\_HalonRing\\Terrain_Rock_AsteroidDust_BlueGrey_000_Normal.tex", 2152557177, 10, 396, 0, 0, 0, 0, 0, 0, 0);
            AddWorldLayer(1295, "Murkmire_Roots", 902, 3, 0, 0, 0, 8, "Art\\Terrain\\Roots\\Terrain_Roots_WitheredDirt_GreyBrown_000_Color.tex", "Art\\Terrain\\Roots\\Terrain_Roots_WitheredDirt_GreyBrown_000_Normal.tex", 2150968604, 7, 197, 0, 0, 0, 0, 0, 0, 0);
            AddWorldLayer(1296, "Grimvault_Dunes", 902, 0.5f, 0.5f, 0, 0, 8, "Art\\Terrain\\_Grimvault\\terrain_sand_idealized_000_color.tex", "Art\\Terrain\\_Grimvault\\terrain_sand_idealized_000_normal.tex", 2138667619, 7, 189, 0, 179, 0, 0, 0, 0, 0);
            AddWorldLayer(1297, "Murkmire_Dark_Mud", 186, 1, 0, -2, -1, 8, "Art\\Terrain\\Mud\\Terrain_Mud_NastyCracked_BrownDark_000_Color.tex", "Art\\Terrain\\Mud\\Terrain_Mud_NastyCracked_BrownDark_000_Normal.tex", 2151100444, 17, 0, 122, 0, 0, 0, 0, 0, 0);
            AddWorldLayer(1298, "Murkmire_Swamp_Moss", 184, 3, 0, 0, 0, 4, "Art\\Terrain\\Plant\\Terrain_Plant_PodMushroomNasty_BrownOlive_000_Color.tex", "Art\\Terrain\\Plant\\Terrain_Plant_PodMushroomNasty_BrownOlive_000_Normal.tex", 2153073937, 8, 0, 40, 0, 0, 0, 0, 0, 0);
            AddWorldLayer(1299, "Purple_Shroom_Moss", 296, 1, 0.2f, 0.3f, 0, 16, "Art\\Terrain\\_Dreadmoor\\Terrain_Moss_SmallPlants_Dreadmoor_000_Color.tex", "Art\\Terrain\\_Dreadmoor\\Terrain_Moss_LargeBubblySmallPlants_Green_000_Normal.tex", 1784169334, 5, 0, 305, 0, 0, 0, 0, 0, 0);
            AddWorldLayer(1300, "Black_Organic_Shrooms", 666, 1, 0, 0, 0, 8, "Art\\Terrain\\_Grimvault\\Corrupted_BlackOrganic_001_color.tex", "Art\\Terrain\\_Grimvault\\corrupted_blackorganic_001_dxtnormal.tex", 2133270572, 5, 0, 323, 0, 0, 0, 0, 0, 0);
            AddGroundOption("The Floor Is Lava", 579, 580, 286, 5);
            AddGroundOption("Volcanic", 580, 579, 287, 5);
            AddGroundOption("Arcterra", 991, 1159, 288, 5);
            AddGroundOption("Ice Rubble", 1158, 458, 289, 5);
            AddGroundOption("Ice Drift", 1257, 1256, 290, 5);
            AddGroundOption("Desolation", 24, 260, 291, 5);
            AddGroundOption("Galeras Meadow", 757, 544, 292, 5);
            AddGroundOption("Paved", 1079, 1079, 293, 5);
            AddGroundOption("Runed Temple Floor", 249, 250, 294, 5);
            AddGroundOption("Overgrown Pavement", 1079, 422, 295, 5);
            AddGroundOption("Sleeping Volcano", 580, 422, 296, 5);
            AddGroundOption("Hot and Cold", 1257, 579, 297, 5);
            AddGroundOption("Crystal Field (Yellow in Grass)", 105, 893, 298, 5);
            AddGroundOption("Crystal Field (Blue in Dirt)", 894, 464, 299, 5);
            AddGroundOption("Halon Ring", 336, 1172, 300, 5);
            AddGroundOption("Tech", 299, 484, 301, 5);
            AddGroundOption("Eldan Hexagons", 608, 608, 302, 5);
            AddGroundOption("Eldan Hexagons (Corrupted)", 921, 921, 303, 5);
            AddGroundOption("Metal Hexagons", 953, 953, 304, 5);
            AddGroundOption("Scorched Rock", 580, 1250, 305, 5);
            AddGroundOption("Verdant Rocks", 589, 422, 306, 6);
            AddGroundOption("Wilderrun Cavern", 430, 422, 307, 6);
            AddGroundOption("Galeras Valley", 82, 83, 308, 6);
            AddGroundOption("Rocky", 589, 259, 309, 6);
            AddGroundOption("Overgrown Temple", 249, 422, 310, 6);
            AddGroundOption("Chrome", 855, 856, 311, 6);
            AddGroundOption("Chronium Garden", 757, 856, 312, 6);
            AddGroundOption("Desert Sigils", 347, 766, 313, 7);
            AddGroundOption("Amethyst Meadow", 1034, 1290, 314, 7);
            AddGroundOption("Galeras Prairie", 544, 757, 315, 7);
            AddGroundOption("Galeras Field", 1233, 757, 316, 7);
            AddGroundOption("Galeras Steppe", 757, 82, 317, 7);
            AddGroundOption("Marble Barrens", 1289, 525, 318, 7);
            AddGroundOption("Metal", 501, 572, 319, 7);
            AddGroundOption("Gildgrass Moor", 711, 184, 320, 7);
            AddGroundOption("Heath and Rime", 1172, 1256, 321, 8);
            AddGroundOption("Chronium Heath", 1172, 856, 322, 8);
            AddGroundOption("Borellian Flora", 1292, 1294, 323, 9);
            AddGroundOption("Mycelium Meadow", 1293, 818, 324, 9);
            AddGroundOption("Grimvault Scrub", 810, 809, 325, 9);
            AddGroundOption("Grimvault Chaparral", 219, 810, 326, 9);
            AddGroundOption("Grimvault Basin", 1296, 903, 327, 9);
            AddGroundOption("Wild Wheat Country", 101, 195, 328, 9);
            AddGroundOption("Obsidian Lowland", 195, 106, 329, 9);
            AddGroundOption("Pine Barrens", 45, 514, 330, 9);
            AddGroundOption("Dreadmoor Mudflat", 257, 251, 331, 9);
            AddGroundOption("Dreadmoor Hammock", 261, 251, 332, 9);
            AddGroundOption("Dreadmoor Pasture", 252, 253, 333, 9);
            AddGroundOption("Murkmire Highland", 192, 1295, 334, 9);
            AddGroundOption("Crimson Badlands", 621, 276, 335, 9);
            AddGroundOption("Coralus Dunegrass", 748, 750, 336, 9);
            AddGroundOption("Coralus Brush", 751, 752, 337, 9);
            AddGroundOption("Coralus Jungle", 750, 751, 338, 9);
            AddGroundOption("Blurple Wondershrooms", 1299, 1300, 339, 9);
            AddGroundOption("Windswept Tundra", 991, 1172, 340, 9);
            AddEmote(7834, "lounge1", "lounge", 433);
            AddEmote(7835, "lounge2", null, 434);
            AddEmote(6665, "coffin", null, 435);
            AddEmote(2022, null, null, 436);
            AddEmote(2023, null, null, 437);
            AddEmote(2024, null, null, 438);
            AddEmote(2025, null, null, 439);
            AddEmote(2026, null, null, 440);
            AddEmote(2027, null, null, 441);
            AddEmote(2028, null, null, 442);
            AddEmote(2029, null, null, 443);
            AddEmote(2030, null, null, 444);
            AddEmote(2031, null, null, 445);
            AddEmote(2036, null, null, 446);
            AddEmote(884, "channeling4", null, 447);
            AddEmote(6690, null, null, 448);
            AddEmote(5911, null, null, 449);
            AddEmote(5683, "npcstance1", "npcstance", 450);
            AddEmote(5686, "npcstance2", null, 451);
            AddEmote(6221, null, null, 452);
            AddEmote(6222, null, null, 453);
            AddEmote(5548, null, null, 454);
            AddEmote(7391, null, null, 455);
            AddEmote(5513, null, null, 456);
            AddEmote(1368, null, null, 457);
            AddEmote(1370, null, null, 458);
            AddEmote(5517, null, null, 459);
            AddEmote(6762, "channeling8", null, 460);
            AddEmote(4982, null, null, 461);
            AddEmote(4983, null, null, 462);
            AddEmote(5534, null, null, 463);
            AddEmote(7525, null, null, 464);
            AddEmote(1300, null, null, 465);
            AddEmote(1301, null, null, 466);
            AddEmote(1305, null, null, 467);
            AddEmote(1306, null, null, 468);
            AddEmote(889, "readycombat2", null, 469);
            AddEmote(575, null, null, 470);
            AddEmote(7561, "hoverboard", null, 471);

            startItem2Id = AddSFWItems(startItem2Id);

            SaveTables("../../../../TblNormal/");

            startItem2Id = DoNSFWSItemDisplays(startItem2Id);

            SaveTables("../../../../TblNSFWS/");

            // BETA YOLO MOOOODE
            betaMode = true;

            foreach (var table in tables)
            {
                table.beta = true;
            }

            AddSwimsuitOutfits();

            AddGenericDecor("Art\\Prop\\Constructed\\MISC\\Food\\PRP_SpaceTaco_Hologram_000.m3", 86, 0, 3992, "Hologram (Taco) - GLITCH CHECK ONLY", DecorCategory.Beta, false, 2);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1610, "NSFWS Mordesh Male 1", "Mordesh Civilian", 26016, 13173, 0, 0, 1467, 1f, null, null), 6995, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1611, "NSFWS Mordesh Male 2", "Mordesh Civilian", 28355, 13173, 0, 0, 7834, 1f, null, null), 6996, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1612, "NSFWS Mordesh Male 3", "Mordesh Civilian", 31867, 13173, 0, 0, 7835, 1f, null, null), 6997, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1613, "NSFWS Mordesh Male 4", "Mordesh Civilian", 39614, 13173, 0, 0, 7836, 1f, null, null), 6998, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1614, "NSFWS Mordesh Male 5", "Mordesh Civilian", 35001, 13173, 0, 0, 6663, 1f, null, null), 6999, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1615, "NSFWS Mordesh Male 6", "Mordesh Civilian", 35002, 13173, 0, 0, 1628, 1f, null, null), 7000, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1616, "NSFWS Mordesh Male 7", "Mordesh Civilian", 34899, 13173, 0, 0, 5439, 1f, null, null), 7001, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1617, "NSFWS Mordesh Female 1", "Mordesh Civilian", 41224, 13173, 0, 0, 1467, 1f, null, null), 7002, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1618, "NSFWS Mordesh Female 2", "Mordesh Civilian", 41142, 13173, 0, 0, 7834, 1f, null, null), 7003, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1619, "NSFWS Mordesh Female 3", "Mordesh Civilian", 33190, 13173, 0, 0, 7835, 1f, null, null), 7004, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1620, "NSFWS Mordesh Female 4", "Mordesh Civilian", 34816, 13173, 0, 0, 7836, 1f, null, null), 7005, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1621, "NSFWS Mordesh Female 5", "Mordesh Civilian", 40919, 13173, 0, 0, 6663, 1f, null, null), 7006, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1622, "NSFWS Mordesh Female 6", "Mordesh Civilian", 36298, 13173, 0, 0, 1628, 1f, null, null), 7007, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1623, "NSFWS Mordesh Female 7", "Mordesh Civilian", 41153, 13173, 0, 0, 5439, 1f, null, null), 7008, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mordesh (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1624, "NSFWS Granok Male 1", "Granok Civilian", 28351, 13173, 0, 0, 1467, 1f, null, null), 7009, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1625, "NSFWS Granok Male 2", "Granok Civilian", 26330, 13173, 0, 0, 7834, 1f, null, null), 7010, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1626, "NSFWS Granok Male 3", "Granok Civilian", 24358, 13173, 0, 0, 7835, 1f, null, null), 7011, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1627, "NSFWS Granok Male 4", "Granok Civilian", 25162, 13173, 0, 0, 7836, 1f, null, null), 7012, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1628, "NSFWS Granok Male 5", "Granok Civilian", 24081, 13173, 0, 0, 6663, 1f, null, null), 7013, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1629, "NSFWS Granok Male 6", "Granok Civilian", 24438, 13173, 0, 0, 1628, 1f, null, null), 7014, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1630, "NSFWS Granok Male 7", "Granok Civilian", 24715, 13173, 0, 0, 5439, 1f, null, null), 7015, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1631, "NSFWS Granok Female 1", "Granok Civilian", 34764, 13173, 0, 0, 1467, 1f, null, null), 7016, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1632, "NSFWS Granok Female 2", "Granok Civilian", 41222, 13173, 0, 0, 7834, 1f, null, null), 7017, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1633, "NSFWS Granok Female 3", "Granok Civilian", 39612, 13173, 0, 0, 7835, 1f, null, null), 7018, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1634, "NSFWS Granok Female 4", "Granok Civilian", 41303, 13173, 0, 0, 7836, 1f, null, null), 7019, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1635, "NSFWS Granok Female 5", "Granok Civilian", 28040, 13173, 0, 0, 6663, 1f, null, null), 7020, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1636, "NSFWS Granok Female 6", "Granok Civilian", 36055, 13173, 0, 0, 1628, 1f, null, null), 7021, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1637, "NSFWS Granok Female 7", "Granok Civilian", 34766, 13173, 0, 0, 5439, 1f, null, null), 7022, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Granok (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1638, "NSFWS Chua 1", "Chua Civilian", 38970, 13173, 0, 0, 1467, 1f, null, null), 7023, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Chua (Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1639, "NSFWS Chua 2", "Chua Civilian", 36026, 13173, 0, 0, 7834, 1f, null, null), 7024, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Chua (Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1640, "NSFWS Chua 3", "Chua Civilian", 36027, 13173, 0, 0, 7835, 1f, null, null), 7025, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Chua (Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1641, "NSFWS Chua 4", "Chua Civilian", 38819, 13173, 0, 0, 7836, 1f, null, null), 7026, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Chua (Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1642, "NSFWS Chua 5", "Chua Civilian", 30442, 13173, 0, 0, 6663, 1f, null, null), 7027, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Chua (Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1643, "NSFWS Chua 6", "Chua Civilian", 30344, 13173, 0, 0, 1628, 1f, null, null), 7028, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Chua (Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1644, "NSFWS Chua 7", "Chua Civilian", 30857, 13173, 0, 0, 5439, 1f, null, null), 7029, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Chua (Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1645, "NSFWS Draken Male 1", "Draken Civilian", 39029, 13173, 0, 0, 1467, 1f, null, null), 7030, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1646, "NSFWS Draken Male 2", "Draken Civilian", 39046, 13173, 0, 0, 7834, 1f, null, null), 7031, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1647, "NSFWS Draken Male 3", "Draken Civilian", 28270, 13173, 0, 0, 7835, 1f, null, null), 7032, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1648, "NSFWS Draken Male 4", "Draken Civilian", 28325, 13173, 0, 0, 7836, 1f, null, null), 7033, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1649, "NSFWS Draken Male 5", "Draken Civilian", 28359, 13173, 0, 0, 6663, 1f, null, null), 7034, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1650, "NSFWS Draken Male 6", "Draken Civilian", 28295, 13173, 0, 0, 1628, 1f, null, null), 7035, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1651, "NSFWS Draken Male 7", "Draken Civilian", 36304, 13173, 0, 0, 5439, 1f, null, null), 7036, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1652, "NSFWS Draken Female 1", "Draken Civilian", 39025, 13173, 0, 0, 1467, 1f, null, null), 7037, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1653, "NSFWS Draken Female 2", "Draken Civilian", 39048, 13173, 0, 0, 7834, 1f, null, null), 7038, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1654, "NSFWS Draken Female 3", "Draken Civilian", 25335, 13173, 0, 0, 7835, 1f, null, null), 7039, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1655, "NSFWS Draken Female 4", "Draken Civilian", 39027, 13173, 0, 0, 7836, 1f, null, null), 7040, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1656, "NSFWS Draken Female 5", "Draken Civilian", 25363, 13173, 0, 0, 6663, 1f, null, null), 7041, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1657, "NSFWS Draken Female 6", "Draken Civilian", 26893, 13173, 0, 0, 1628, 1f, null, null), 7042, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1658, "NSFWS Draken Female 7", "Draken Civilian", 34446, 13173, 0, 0, 5439, 1f, null, null), 7043, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Draken (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1659, "NSFWS Aurin Male 1", "Aurin Civilian", 39036, 13173, 0, 0, 1467, 1f, null, null), 7044, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1660, "NSFWS Aurin Male 2", "Aurin Civilian", 39609, 13173, 0, 0, 7834, 1f, null, null), 7045, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1661, "NSFWS Aurin Male 3", "Aurin Civilian", 41150, 13173, 0, 0, 7835, 1f, null, null), 7046, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1662, "NSFWS Aurin Male 4", "Aurin Civilian", 30179, 13173, 0, 0, 7836, 1f, null, null), 7047, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1663, "NSFWS Aurin Male 5", "Aurin Civilian", 34948, 13173, 0, 0, 6663, 1f, null, null), 7048, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1664, "NSFWS Aurin Male 6", "Aurin Civilian", 32751, 13173, 0, 0, 1628, 1f, null, null), 7049, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1665, "NSFWS Aurin Male 7", "Aurin Civilian", 28319, 13173, 0, 0, 5439, 1f, null, null), 7050, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1666, "NSFWS Aurin Female 1", "Aurin Civilian", 39037, 13173, 0, 0, 1467, 1f, null, null), 7051, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1667, "NSFWS Aurin Female 2", "Aurin Civilian", 39611, 13173, 0, 0, 7834, 1f, null, null), 7052, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1668, "NSFWS Aurin Female 3", "Aurin Civilian", 41213, 13173, 0, 0, 7835, 1f, null, null), 7053, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1669, "NSFWS Aurin Female 4", "Aurin Civilian", 34949, 13173, 0, 0, 7836, 1f, null, null), 7054, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1670, "NSFWS Aurin Female 5", "Aurin Civilian", 38231, 13173, 0, 0, 6663, 1f, null, null), 7055, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1671, "NSFWS Aurin Female 6", "Aurin Civilian", 36300, 13173, 0, 0, 1628, 1f, null, null), 7056, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1672, "NSFWS Aurin Female 7", "Aurin Civilian", 33161, 13173, 0, 0, 5439, 1f, null, null), 7057, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Aurin (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1673, "NSFWS Mechari Male 1", "Mechari Civilian", 41229, 13173, 0, 0, 1467, 1f, null, null), 7058, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1674, "NSFWS Mechari Male 2", "Mechari Civilian", 29552, 13173, 0, 0, 7834, 1f, null, null), 7059, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1675, "NSFWS Mechari Male 3", "Mechari Civilian", 28346, 13173, 0, 0, 7835, 1f, null, null), 7060, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1676, "NSFWS Mechari Male 4", "Mechari Civilian", 28827, 13173, 0, 0, 7836, 1f, null, null), 7061, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1677, "NSFWS Mechari Male 5", "Mechari Civilian", 28330, 13173, 0, 0, 6663, 1f, null, null), 7062, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1678, "NSFWS Mechari Male 6", "Mechari Civilian", 28312, 13173, 0, 0, 1628, 1f, null, null), 7063, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1679, "NSFWS Mechari Male 7", "Mechari Civilian", 38821, 13173, 0, 0, 5439, 1f, null, null), 7064, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1680, "NSFWS Mechari Female 1", "Mechari Civilian", 41230, 13173, 0, 0, 1467, 1f, null, null), 7065, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1681, "NSFWS Mechari Female 2", "Mechari Civilian", 31745, 13173, 0, 0, 7834, 1f, null, null), 7066, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1682, "NSFWS Mechari Female 3", "Mechari Civilian", 32482, 13173, 0, 0, 7835, 1f, null, null), 7067, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1683, "NSFWS Mechari Female 4", "Mechari Civilian", 28331, 13173, 0, 0, 7836, 1f, null, null), 7068, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1684, "NSFWS Mechari Female 5", "Mechari Civilian", 28313, 13173, 0, 0, 6663, 1f, null, null), 7069, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1685, "NSFWS Mechari Female 6", "Mechari Civilian", 34856, 13173, 0, 0, 1628, 1f, null, null), 7070, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1686, "NSFWS Mechari Female 7", "Mechari Civilian", 32971, 13173, 0, 0, 5439, 1f, null, null), 7071, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Mechari (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1687, "NSFWS Cassian Male 1", "Cassian Noble", 28323, 13173, 0, 0, 1467, 1f, null, null), 7072, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1688, "NSFWS Cassian Male 2", "Cassian Noble", 38818, 13173, 0, 0, 7834, 1f, null, null), 7073, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1689, "NSFWS Cassian Male 3", "Cassian Noble", 34859, 13173, 0, 0, 7835, 1f, null, null), 7074, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1690, "NSFWS Cassian Male 4", "Cassian Commoner", 25809, 13173, 0, 0, 7836, 1f, null, null), 7075, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1691, "NSFWS Cassian Male 5", "Cassian Commoner", 28260, 13173, 0, 0, 6663, 1f, null, null), 7076, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1692, "NSFWS Cassian Male 6", "Cassian Commoner", 30597, 13173, 0, 0, 1628, 1f, null, null), 7077, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1693, "NSFWS Cassian Male 7", "Cassian Commoner", 30897, 13173, 0, 0, 5439, 1f, null, null), 7078, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1694, "NSFWS Cassian Female 1", "Cassian Noble", 29475, 13173, 0, 0, 1467, 1f, null, null), 7079, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1695, "NSFWS Cassian Female 2", "Cassian Noble", 41300, 13173, 0, 0, 7834, 1f, null, null), 7080, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1696, "NSFWS Cassian Female 3", "Cassian Noble", 28324, 13173, 0, 0, 7835, 1f, null, null), 7081, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1697, "NSFWS Cassian Female 4", "Cassian Noble", 30599, 13173, 0, 0, 7836, 1f, null, null), 7082, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1698, "NSFWS Cassian Female 5", "Cassian Commoner", 34858, 13173, 0, 0, 6663, 1f, null, null), 7083, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1699, "NSFWS Cassian Female 6", "Cassian Commoner", 28301, 13173, 0, 0, 1628, 1f, null, null), 7084, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1700, "NSFWS Cassian Female 7", "Cassian Commoner", 30748, 13173, 0, 0, 5439, 1f, null, null), 7085, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Cassian (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1701, "NSFWS Human Male 1", "Human Civilian", 28308, 13173, 0, 0, 1467, 1f, null, null), 7086, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1702, "NSFWS Human Male 2", "Human Civilian", 28349, 13173, 0, 0, 7834, 1f, null, null), 7087, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1703, "NSFWS Human Male 3", "Human Civilian", 29477, 13173, 0, 0, 7835, 1f, null, null), 7088, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1704, "NSFWS Human Male 4", "Human Civilian", 28033, 13173, 0, 0, 7836, 1f, null, null), 7089, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1705, "NSFWS Human Male 5", "Human Civilian", 27346, 13173, 0, 0, 6663, 1f, null, null), 7090, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1706, "NSFWS Human Male 6", "Human Civilian", 32799, 13173, 0, 0, 1628, 1f, null, null), 7091, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1707, "NSFWS Human Male 7", "Human Civilian", 24796, 13173, 0, 0, 5439, 1f, null, null), 7092, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1708, "NSFWS Human Female 1", "Human Civilian", 28309, 13173, 0, 0, 1467, 1f, null, null), 7093, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1709, "NSFWS Human Female 2", "Human Civilian", 30112, 13173, 0, 0, 7834, 1f, null, null), 7094, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1710, "NSFWS Human Female 3", "Human Civilian", 25887, 13173, 0, 0, 7835, 1f, null, null), 7095, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1711, "NSFWS Human Female 4", "Human Civilian", 30194, 13173, 0, 0, 7836, 1f, null, null), 7096, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1712, "NSFWS Human Female 5", "Human Civilian", 30178, 13173, 0, 0, 6663, 1f, null, null), 7097, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1713, "NSFWS Human Female 6", "Human Civilian", 27562, 13173, 0, 0, 1628, 1f, null, null), 7098, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1714, "NSFWS Human Female 7", "Human Civilian", 25051, 13173, 0, 0, 5439, 1f, null, null), 7099, "Art\\Prop\\Constructed\\Sign\\Marauder\\PRP_Sign_MarauderDrakkenBar_000.m3", "!NEW! (NSFWS) Canoodling Human (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1771, "Sunbathing Mordesh Male 1", "Sunbather", 26016, 13175, 0, 0, 0, 1f, null, null), 7156, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1772, "Sunbathing Mordesh Male 2", "Sunbather", 28355, 13177, 0, 0, 0, 1f, null, null), 7157, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1773, "Sunbathing Mordesh Male 3", "Sunbather", 31867, 13179, 0, 0, 0, 1f, null, null), 7158, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1774, "Sunbathing Mordesh Male 4", "Sunbather", 39614, 13181, 0, 0, 0, 1f, null, null), 7159, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1775, "Sunbathing Mordesh Male 5", "Sunbather", 35001, 13181, 0, 0, 0, 1f, null, null), 7160, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1776, "Sunbathing Mordesh Male 6", "Sunbather", 35002, 13185, 0, 0, 0, 1f, null, null), 7161, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1777, "Sunbathing Mordesh Male 7", "Sunbather", 34899, 13175, 0, 0, 0, 1f, null, null), 7162, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1778, "Sunbathing Mordesh Female 1", "Sunbather", 41224, 13174, 0, 0, 0, 1f, null, null), 7163, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1779, "Sunbathing Mordesh Female 2", "Sunbather", 41142, 13178, 0, 0, 0, 1f, null, null), 7164, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1780, "Sunbathing Mordesh Female 3", "Sunbather", 33190, 13176, 0, 0, 0, 1f, null, null), 7165, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1781, "Sunbathing Mordesh Female 4", "Sunbather", 34816, 13180, 0, 0, 0, 1f, null, null), 7166, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1782, "Sunbathing Mordesh Female 5", "Sunbather", 40919, 13184, 0, 0, 0, 1f, null, null), 7167, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1783, "Sunbathing Mordesh Female 6", "Sunbather", 36298, 13182, 0, 0, 0, 1f, null, null), 7168, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75540, startCreature2ID + 1784, "Sunbathing Mordesh Female 7", "Sunbather", 41153, 13174, 0, 0, 0, 1f, null, null), 7169, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Mordesh Sunbather (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1785, "Sunbathing Granok Male 1", "Sunbather", 28351, 13175, 0, 0, 0, 1f, null, null), 7170, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1786, "Sunbathing Granok Male 2", "Sunbather", 26330, 13177, 0, 0, 0, 1f, null, null), 7171, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1787, "Sunbathing Granok Male 3", "Sunbather", 24358, 13179, 0, 0, 0, 1f, null, null), 7172, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1788, "Sunbathing Granok Male 4", "Sunbather", 25162, 13181, 0, 0, 0, 1f, null, null), 7173, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1789, "Sunbathing Granok Male 5", "Sunbather", 24081, 13181, 0, 0, 0, 1f, null, null), 7174, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1790, "Sunbathing Granok Male 6", "Sunbather", 24438, 13175, 0, 0, 0, 1f, null, null), 7175, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1791, "Sunbathing Granok Male 7", "Sunbather", 24715, 13185, 0, 0, 0, 1f, null, null), 7176, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1792, "Sunbathing Granok Female 1", "Sunbather", 34764, 13174, 0, 0, 0, 1f, null, null), 7177, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1793, "Sunbathing Granok Female 2", "Sunbather", 41222, 13176, 0, 0, 0, 1f, null, null), 7178, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1794, "Sunbathing Granok Female 3", "Sunbather", 39612, 13178, 0, 0, 0, 1f, null, null), 7179, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1795, "Sunbathing Granok Female 4", "Sunbather", 41303, 13180, 0, 0, 0, 1f, null, null), 7180, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1796, "Sunbathing Granok Female 5", "Sunbather", 28040, 13182, 0, 0, 0, 1f, null, null), 7181, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1797, "Sunbathing Granok Female 6", "Sunbather", 36055, 13184, 0, 0, 0, 1f, null, null), 7182, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75536, startCreature2ID + 1798, "Sunbathing Granok Female 7", "Sunbather", 34766, 13174, 0, 0, 0, 1f, null, null), 7183, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Granok Sunbather (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1799, "Sunbathing Chua 1", "Sunbather", 38970, 13175, 0, 0, 0, 1f, null, null), 7184, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Sunbather (Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1800, "Sunbathing Chua 2", "Sunbather", 36026, 13177, 0, 0, 0, 1f, null, null), 7185, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Sunbather (Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1801, "Sunbathing Chua 3", "Sunbather", 36027, 13179, 0, 0, 0, 1f, null, null), 7186, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Sunbather (Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1802, "Sunbathing Chua 4", "Sunbather", 38819, 13181, 0, 0, 0, 1f, null, null), 7187, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Sunbather (Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1803, "Sunbathing Chua 5", "Sunbather", 30442, 13181, 0, 0, 0, 1f, null, null), 7188, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Sunbather (Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1804, "Sunbathing Chua 6", "Sunbather", 30344, 13185, 0, 0, 0, 1f, null, null), 7189, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Sunbather (Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75544, startCreature2ID + 1805, "Sunbathing Chua 7", "Sunbather", 30857, 13175, 0, 0, 0, 1f, null, null), 7190, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Chua Sunbather (Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1806, "Sunbathing Draken Male 1", "Sunbather", 39029, 13175, 0, 0, 0, 1f, null, null), 7191, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1807, "Sunbathing Draken Male 2", "Sunbather", 39046, 13177, 0, 0, 0, 1f, null, null), 7192, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1808, "Sunbathing Draken Male 3", "Sunbather", 28270, 13179, 0, 0, 0, 1f, null, null), 7193, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1809, "Sunbathing Draken Male 4", "Sunbather", 28325, 13181, 0, 0, 0, 1f, null, null), 7194, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1810, "Sunbathing Draken Male 5", "Sunbather", 28359, 13181, 0, 0, 0, 1f, null, null), 7195, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1811, "Sunbathing Draken Male 6", "Sunbather", 28295, 13185, 0, 0, 0, 1f, null, null), 7196, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1812, "Sunbathing Draken Male 7", "Sunbather", 36304, 13175, 0, 0, 0, 1f, null, null), 7197, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1813, "Sunbathing Draken Female 1", "Sunbather", 39025, 13174, 0, 0, 0, 1f, null, null), 7198, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1814, "Sunbathing Draken Female 2", "Sunbather", 39048, 13176, 0, 0, 0, 1f, null, null), 7199, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1815, "Sunbathing Draken Female 3", "Sunbather", 25335, 13178, 0, 0, 0, 1f, null, null), 7200, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1816, "Sunbathing Draken Female 4", "Sunbather", 39027, 13180, 0, 0, 0, 1f, null, null), 7201, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1817, "Sunbathing Draken Female 5", "Sunbather", 25363, 13182, 0, 0, 0, 1f, null, null), 7202, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1818, "Sunbathing Draken Female 6", "Sunbather", 26893, 13184, 0, 0, 0, 1f, null, null), 7203, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75546, startCreature2ID + 1819, "Sunbathing Draken Female 7", "Sunbather", 34446, 13174, 0, 0, 0, 1f, null, null), 7204, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Draken Sunbather (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1820, "Sunbathing Aurin Male 1", "Sunbather", 39036, 13175, 0, 0, 0, 1f, null, null), 7205, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1821, "Sunbathing Aurin Male 2", "Sunbather", 39609, 13177, 0, 0, 0, 1f, null, null), 7206, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1822, "Sunbathing Aurin Male 3", "Sunbather", 41150, 13179, 0, 0, 0, 1f, null, null), 7207, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1823, "Sunbathing Aurin Male 4", "Sunbather", 30179, 13181, 0, 0, 0, 1f, null, null), 7208, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1824, "Sunbathing Aurin Male 5", "Sunbather", 34948, 13181, 0, 0, 0, 1f, null, null), 7209, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1825, "Sunbathing Aurin Male 6", "Sunbather", 32751, 13185, 0, 0, 0, 1f, null, null), 7210, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1826, "Sunbathing Aurin Male 7", "Sunbather", 28319, 13175, 0, 0, 0, 1f, null, null), 7211, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1827, "Sunbathing Aurin Female 1", "Sunbather", 39037, 13174, 0, 0, 0, 1f, null, null), 7212, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1828, "Sunbathing Aurin Female 2", "Sunbather", 39611, 13176, 0, 0, 0, 1f, null, null), 7213, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1829, "Sunbathing Aurin Female 3", "Sunbather", 41213, 13178, 0, 0, 0, 1f, null, null), 7214, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1830, "Sunbathing Aurin Female 4", "Sunbather", 34949, 13180, 0, 0, 0, 1f, null, null), 7215, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1831, "Sunbathing Aurin Female 5", "Sunbather", 38231, 13182, 0, 0, 0, 1f, null, null), 7216, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1832, "Sunbathing Aurin Female 6", "Sunbather", 36300, 13174, 0, 0, 0, 1f, null, null), 7217, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75538, startCreature2ID + 1833, "Sunbathing Aurin Female 7", "Sunbather", 33161, 13184, 0, 0, 0, 1f, null, null), 7218, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Aurin Sunbather (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1834, "Sunbathing Mechari Male 1", "Sunbather", 41229, 13175, 0, 0, 0, 1f, null, null), 7219, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1835, "Sunbathing Mechari Male 2", "Sunbather", 29552, 13177, 0, 0, 0, 1f, null, null), 7220, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1836, "Sunbathing Mechari Male 3", "Sunbather", 28346, 13179, 0, 0, 0, 1f, null, null), 7221, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1837, "Sunbathing Mechari Male 4", "Sunbather", 28827, 13181, 0, 0, 0, 1f, null, null), 7222, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1838, "Sunbathing Mechari Male 5", "Sunbather", 28330, 13181, 0, 0, 0, 1f, null, null), 7223, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1839, "Sunbathing Mechari Male 6", "Sunbather", 28312, 13185, 0, 0, 0, 1f, null, null), 7224, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1840, "Sunbathing Mechari Male 7", "Sunbather", 38821, 13175, 0, 0, 0, 1f, null, null), 7225, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1841, "Sunbathing Mechari Female 1", "Sunbather", 41230, 13174, 0, 0, 0, 1f, null, null), 7226, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1842, "Sunbathing Mechari Female 2", "Sunbather", 31745, 13176, 0, 0, 0, 1f, null, null), 7227, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1843, "Sunbathing Mechari Female 3", "Sunbather", 32482, 13178, 0, 0, 0, 1f, null, null), 7228, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1844, "Sunbathing Mechari Female 4", "Sunbather", 28331, 13180, 0, 0, 0, 1f, null, null), 7229, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1845, "Sunbathing Mechari Female 5", "Sunbather", 28313, 13182, 0, 0, 0, 1f, null, null), 7230, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1846, "Sunbathing Mechari Female 6", "Sunbather", 34856, 13184, 0, 0, 0, 1f, null, null), 7231, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75885, startCreature2ID + 1847, "Sunbathing Mechari Female 7", "Sunbather", 32971, 13174, 0, 0, 0, 1f, null, null), 7232, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Mechari Sunbather (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1848, "Sunbathing Cassian Male 1", "Sunbather", 28323, 13175, 0, 0, 0, 1f, null, null), 7233, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1849, "Sunbathing Cassian Male 2", "Sunbather", 38818, 13177, 0, 0, 0, 1f, null, null), 7234, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1850, "Sunbathing Cassian Male 3", "Sunbather", 34859, 13179, 0, 0, 0, 1f, null, null), 7235, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1851, "Sunbathing Cassian Male 4", "Sunbather", 25809, 13181, 0, 0, 0, 1f, null, null), 7236, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1852, "Sunbathing Cassian Male 5", "Sunbather", 28260, 13181, 0, 0, 0, 1f, null, null), 7237, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1853, "Sunbathing Cassian Male 6", "Sunbather", 30597, 13185, 0, 0, 0, 1f, null, null), 7238, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1854, "Sunbathing Cassian Male 7", "Sunbather", 30897, 13175, 0, 0, 0, 1f, null, null), 7239, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1855, "Sunbathing Cassian Female 1", "Sunbather", 29475, 13174, 0, 0, 0, 1f, null, null), 7240, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1856, "Sunbathing Cassian Female 2", "Sunbather", 41300, 13176, 0, 0, 0, 1f, null, null), 7241, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1857, "Sunbathing Cassian Female 3", "Sunbather", 28324, 13178, 0, 0, 0, 1f, null, null), 7242, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1858, "Sunbathing Cassian Female 4", "Sunbather", 30599, 13180, 0, 0, 0, 1f, null, null), 7243, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1859, "Sunbathing Cassian Female 5", "Sunbather", 34858, 13182, 0, 0, 0, 1f, null, null), 7244, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1860, "Sunbathing Cassian Female 6", "Sunbather", 28301, 13184, 0, 0, 0, 1f, null, null), 7245, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1861, "Sunbathing Cassian Female 7", "Sunbather", 30748, 13174, 0, 0, 0, 1f, null, null), 7246, "Art\\Prop\\Icons\\Faction_Icons\\Dominion\\PRP_Icon_Faction_dominion_000.m3", "!NEW! Cassian Sunbather (Female, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1862, "Sunbathing Human Male 1", "Sunbather", 28308, 13175, 0, 0, 0, 1f, null, null), 7247, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Male, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1863, "Sunbathing Human Male 2", "Sunbather", 28349, 13177, 0, 0, 0, 1f, null, null), 7248, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Male, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1864, "Sunbathing Human Male 3", "Sunbather", 29477, 13179, 0, 0, 0, 1f, null, null), 7249, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Male, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1865, "Sunbathing Human Male 4", "Sunbather", 28033, 13181, 0, 0, 0, 1f, null, null), 7250, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Male, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1866, "Sunbathing Human Male 5", "Sunbather", 27346, 13181, 0, 0, 0, 1f, null, null), 7251, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Male, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1867, "Sunbathing Human Male 6", "Sunbather", 32799, 13185, 0, 0, 0, 1f, null, null), 7252, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Male, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75669, startCreature2ID + 1868, "Sunbathing Human Male 7", "Sunbather", 24796, 13175, 0, 0, 0, 1f, null, null), 7253, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Male, Style 7)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1869, "Sunbathing Human Female 1", "Sunbather", 28309, 13174, 0, 0, 0, 1f, null, null), 7254, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Female, Style 1)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1870, "Sunbathing Human Female 2", "Sunbather", 30112, 13176, 0, 0, 0, 1f, null, null), 7255, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Female, Style 2)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1871, "Sunbathing Human Female 3", "Sunbather", 25887, 13178, 0, 0, 0, 1f, null, null), 7256, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Female, Style 3)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1872, "Sunbathing Human Female 4", "Sunbather", 30194, 13180, 0, 0, 0, 1f, null, null), 7257, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Female, Style 4)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1873, "Sunbathing Human Female 5", "Sunbather", 30178, 13182, 0, 0, 0, 1f, null, null), 7258, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Female, Style 5)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1874, "Sunbathing Human Female 6", "Sunbather", 27562, 13184, 0, 0, 0, 1f, null, null), 7259, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Female, Style 6)", 14);
            AddNPCDecor(2666, AddCreature(75670, startCreature2ID + 1875, "Sunbathing Human Female 7", "Sunbather", 25051, 13174, 0, 0, 0, 1f, null, null), 7260, "Art\\Prop\\Icons\\Faction_Icons\\Exile\\PRP_Icon_Faction_exile_000.m3", "!NEW! Human Sunbather (Female, Style 7)", 14);
            AddGroundOption("Icescape", 1256, 1257, null, 1);
            AddGroundOption("Celestion Moss 1", 137, 138, null, 1);
            AddGroundOption("Celestion Moss 2", 137, 193, null, 1);
            AddGroundOption("Tech Plate", 480, 1291, null, 1);
            AddGroundOption("Alien", 566, 857, null, 1);
            AddGroundOption("Mossy Rock", 1222, 948, null, 1);
            AddGroundOption("Mystic Rock 1", 346, 645, null, 1);
            AddGroundOption("Mystic Rock 3", 1250, 209, null, 1);
            AddGroundOption("Gothic Meadow", 1034, 22, null, 1);
            AddGroundOption("SLIME TIME", 857, 928, null, 1);
            AddGroundOption("Debris Seam 1", 340, 166, null, 1);
            AddGroundOption("Debris Seam 2", 30, 166, null, 1);
            AddGroundOption("Crystal Field 1", 44, 464, null, 1);
            AddGroundOption("Halon Ring (Flowery)", 336, 1046, null, 1);
            AddGroundOption("Hexagons 2", 608, 921, null, 1);
            AddGroundOption("Hexagons 5", 953, 856, null, 1);
            AddGroundOption("GroundTest", 105, 184, null, 1);
            AddGroundOption("Murkmire Fen", 1298, 1297, null, null);

            AddTestGroundOptions();

            //AddTestNPCDecorOptions();

            /*uint param = AddCustomizationParameter(null, "Size", 1, 1, 1, 0, 0, 0, 0, 0, 0);
            AddCustomizationParameterMap(null, 4, 0, 128, param, 0, 0);*/

            SaveTables("../../../../TblBeta/");
            CopyTables("../../../../TblBeta/", "../../../../TblServer/");

            List<string> file = new List<string>();
            foreach (var entry in language.Entries)
            {
                file.Add($"{entry.Id}: {entry.Text}");
            }
            File.WriteAllLines("../../../../Strings.txt", file);
        }

        static void AddTestGroundOptions()
        {
           //jazzy's scratch sheet
        }
        static void AddTestNPCDecorOptions()
        {
            //jazzy's scratch sheet

            AddNPCDecor(2974, 75666, 5380, "Art\\Prop\\Constructed\\Banner\\Pell\\PRP_Banner_PellTech_Water_000.m3", "Winterfury Storm-Singer", 99);
            AddNPCDecor(2974, 75667, 5381, "Art\\Prop\\Constructed\\Banner\\Pell\\PRP_Banner_PellTech_Water_000.m3", "Winterfury Acolyte", 99);
            AddNPCDecor(2974, 75668, 5382, "Art\\Prop\\Constructed\\Banner\\Pell\\PRP_Banner_PellTech_Water_000.m3", "Winterfury Snow-Stalker", 99);

            uint startCreature2ID = creature2.GetMaxID();
            uint startDecorInfoID = decorInfo.GetMaxID();

            
        }


        static void AddSwimsuitOutfits()
        {
            uint startCreature2OutfitInfoId = creature2OutfitInfo.GetMaxID();
            uint startOutfitGroupId = creature2OutfitGroupEntry.GetMaxID();
            //000A
            uint swimsuitOutfitId00A_F = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId+1, startOutfitGroupId+1, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId+1, 8669, 8663), 1);
            Console.WriteLine("swimsuitOutfitId00A_F = " + swimsuitOutfitId00A_F);
            uint swimsuitOutfitId00A_M = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId+2, startOutfitGroupId+2, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId+2, 8663), 1);
            Console.WriteLine("swimsuitOutfitId00A_M = " + swimsuitOutfitId00A_M);
            //000B
            uint swimsuitOutfitId00B_F = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 3, startOutfitGroupId + 3, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 3, 8670, 8664), 1);
            Console.WriteLine("swimsuitOutfitId00B_F = " + swimsuitOutfitId00B_F);
            uint swimsuitOutfitId00B_M = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 4, startOutfitGroupId + 4, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 4, 8664), 1);
            Console.WriteLine("swimsuitOutfitId00B_M = " + swimsuitOutfitId00B_M);
            //000C
            uint swimsuitOutfitId00C_F = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 5, startOutfitGroupId + 5, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 5, 8671, 8665), 1);
            Console.WriteLine("swimsuitOutfitId00C_F = " + swimsuitOutfitId00C_F);
            uint swimsuitOutfitId00C_M = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 6, startOutfitGroupId + 6, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 6, 8665), 1);
            Console.WriteLine("swimsuitOutfitId00C_M = " + swimsuitOutfitId00C_M);
            //000D
            uint swimsuitOutfitId00D_F = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 7, startOutfitGroupId + 7, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 7, 8672, 8666), 1);
            Console.WriteLine("swimsuitOutfitId00D_F = " + swimsuitOutfitId00D_F);
            uint swimsuitOutfitId00D_M = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 8, startOutfitGroupId + 8, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 8, 8666), 1);
            Console.WriteLine("swimsuitOutfitId00D_M = " + swimsuitOutfitId00D_M);
            //000E
            uint swimsuitOutfitId00E_F = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 9, startOutfitGroupId + 9, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 9, 8673, 8667), 1);
            Console.WriteLine("swimsuitOutfitId00E_F = " + swimsuitOutfitId00E_F);
            uint swimsuitOutfitId00E_M = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 10, startOutfitGroupId + 10, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 10, 0, 8667), 1);
            Console.WriteLine("swimsuitOutfitId00E_M = " + swimsuitOutfitId00E_M);
            //000F
            uint swimsuitOutfitId00F_F = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 11, startOutfitGroupId + 11, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 11, 8674, 8668), 1);
            Console.WriteLine("swimsuitOutfitId00F_F = " + swimsuitOutfitId00F_F);
            uint swimsuitOutfitId00F_M = AddCreatureOutfitGroupEntry(8170, startOutfitGroupId + 12, startOutfitGroupId + 12, AddCreatureOutfitInfo(10232, startCreature2OutfitInfoId + 12, 8668), 1);
            Console.WriteLine("swimsuitOutfitId00F_M = " + swimsuitOutfitId00F_M);
        }
        

        static uint AddSFWItems(uint startItem2Id)
        {
            uint itemDisplayStartId = itemDisplay.GetMaxID();

            // Create chest entry
            var  itemDisplayEntry_Top = itemDisplay.CopyEntry(8669); // copy swimsuit top display
            itemDisplayEntry_Top.Values.RemoveAt(0);
            uint itemDisplayEntryId_Top = itemDisplay.AddEntry(itemDisplayEntry_Top, itemDisplayStartId+1);
            itemDisplayStartId++;

            var item2Entry_Top = item2.CopyEntry(44791); // copy arcane chest item
            item2Entry_Top.Values[10].SetValue(itemDisplayEntryId_Top);
            item2Entry_Top.Values[44].SetValue(language.AddEntry("(NSFWS) Emperor's Shirt"));
            item2Entry_Top.Values.RemoveAt(0);
            uint item2EntryId_Top = item2.AddEntry(item2Entry_Top, startItem2Id + 1);
            startItem2Id++;

            NsfwsItemId_Top = item2EntryId_Top;
            NsfwsItemDisplayId_Top = itemDisplayEntryId_Top;
            

            // Create pants entry
            var itemDisplayEntry_Bottom = itemDisplay.CopyEntry(8663); // copy swimsuit bottom display
            itemDisplayEntry_Bottom.Values.RemoveAt(0);
            uint itemDisplayEntryId_Bottom = itemDisplay.AddEntry(itemDisplayEntry_Bottom, itemDisplayStartId+1);
            itemDisplayStartId++;

            var item2Entry_Bottom = item2.CopyEntry(44792); // copy arcane pants item
            item2Entry_Bottom.Values[10].SetValue(itemDisplayEntryId_Bottom);
            item2Entry_Bottom.Values[44].SetValue(language.AddEntry("(NSFWS) Emperor's Pants"));
            item2Entry_Bottom.Values.RemoveAt(0);
            uint item2EntryId_Bottom = item2.AddEntry(item2Entry_Bottom, startItem2Id + 1);
            startItem2Id++;

            NsfwsItemId_Bottom = item2EntryId_Bottom;
            NsfwsItemDisplayId_Bottom = itemDisplayEntryId_Bottom;

            Console.WriteLine("NsfwsItemDisplayId_Top = " + NsfwsItemDisplayId_Top + "  NsfwsItemDisplayId_Bottom = " + NsfwsItemDisplayId_Bottom);

            //Create OutfitInfo Entry
            uint startCreature2OutfitInfoId = creature2OutfitInfo.GetMaxID();
            var outfitInfoEntry = creature2OutfitInfo.CopyEntry(8572);
            outfitInfoEntry.Values[1].SetValue(NsfwsItemDisplayId_Top);
            outfitInfoEntry.Values[2].SetValue(NsfwsItemDisplayId_Bottom);
            outfitInfoEntry.Values.RemoveAt(0);
            uint NsfwsOutfitInfoId = creature2OutfitInfo.AddEntry(outfitInfoEntry, startCreature2OutfitInfoId + 1);
            startCreature2OutfitInfoId++;

            //Create OutfitGroup entry
            uint startOutfitGroupId = creature2OutfitGroupEntry.GetMaxID();
            var outfitGroupEntry = creature2OutfitGroupEntry.CopyEntry(9267);
            outfitGroupEntry.Values[1].SetValue(startOutfitGroupId + 1);
            outfitGroupEntry.Values[2].SetValue(NsfwsOutfitInfoId);
            outfitGroupEntry.Values.RemoveAt(0);
            uint NsfwsOutfitGroupId = creature2OutfitGroupEntry.AddEntry(outfitGroupEntry, startOutfitGroupId + 1);
            startOutfitGroupId++;

            Console.WriteLine("NsfwsOutfitInfoId = " + NsfwsOutfitInfoId + "  NsfwsOutfitGroupId = " + NsfwsOutfitGroupId);

            return startItem2Id;
        }
        static uint DoNSFWSItemDisplays(uint startItem2Id)
        {
            // change chest display entry
            var itemDisplayEntry_Top = itemDisplay.GetEntry(NsfwsItemDisplayId_Top);
            itemDisplayEntry_Top.Values[14].SetValue(0u);
            itemDisplayEntry_Top.Values[16].SetValue(0u);
            itemDisplayEntry_Top.Values[19].SetValue(0u);
            itemDisplayEntry_Top.Values[20].SetValue(0u);
            itemDisplayEntry_Top.Values[23].SetValue("");
            itemDisplayEntry_Top.Values[24].SetValue("");
            itemDisplayEntry_Top.Values[42].SetValue(0u);

            // change pants display entry
            var itemDisplayEntry_Bottom = itemDisplay.GetEntry(NsfwsItemDisplayId_Bottom);
            itemDisplayEntry_Bottom.Values[14].SetValue(0u);
            itemDisplayEntry_Bottom.Values[16].SetValue(0u);
            itemDisplayEntry_Bottom.Values[19].SetValue(0u);
            itemDisplayEntry_Bottom.Values[20].SetValue(0u);
            itemDisplayEntry_Bottom.Values[23].SetValue("");
            itemDisplayEntry_Bottom.Values[24].SetValue("");
            itemDisplayEntry_Bottom.Values[42].SetValue(0u);

            return startItem2Id;
        }


        static void AddEmoteSlashCommands()
        {
            // Add /commands to existing emotes

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

            foreach (var entry in emotes.table.Entries)
            {
                uint id = (uint)entry.Values[0].Value;
                if (EmoteLibrary.TryGetValue(id, out var tuple))
                {
                    entry.Values[24].SetValue(tuple.Item1 ?? "");
                    entry.Values[25].SetValue(tuple.Item2 ?? "");
                }
            }
        }

        static void HousingPlugUnlocks()
        {
            foreach (var entry in housingPlugItem.table.Entries)
            {
                uint id = (uint)entry.Values[0].Value;
                /*if(id == 557)
                {*/
                entry.Values[14].SetValue((uint)0);
                entry.Values[15].SetValue((uint)0);
                entry.Values[16].SetValue((uint)0);

                entry.Values[23].SetValue((uint)0);

                entry.Values[27].SetValue((uint)0);
                entry.Values[28].SetValue((uint)0);
                entry.Values[29].SetValue((uint)0);
                entry.Values[30].SetValue((uint)0);
                // flags is 8
                //}
            }
        }

        static void CharacterCustomizationBreakingChanges()
        {
            // share hair, faces, facial hair and jewelry between cassians and exile humans
            // DO NOT ADD NEW LABEL-VALUES TO THEM BEFORE THIS
            cch.MoveEntriesToLabel(1, -1, 24, 3);
            cch.MoveEntriesToLabel(1, -1, 23, 3);

            cch.MoveEntriesToLabel(1, -1, 22, 1);
            cch.MoveEntriesToLabel(1, -1, 21, 1);

            cch.MoveEntriesToLabel(1, -1, 20, 5);
            cch.MoveEntriesToLabel(1, -1, 19, 5);

            cch.MoveEntriesToLabel(1, -1, 16, 15);
            characterCustomizationLabel.GetEntry(15).Values[2].SetValue(0u);
        }

        static void CharacterCustomizationChanges()
        {
            uint startID;
            uint startLV;
            uint step;
            List<uint> list;
            // Change some customization colours.

            uint push1 = 9106; // tracks itemDisplayIDs for push 1, do not use after push 1.
            uint push2 = 9805; // tracks itemDisplayIDs for push 2, do not use after push 2.
            uint push3 = 10270;

            //Push 1 ****************************************************************************************************
            // aurin female
            // hair
            cch.AddColourOption(itemDisplay, 4, 1, 4, 109, 3, 11, push1 + 0, push1 + 17); // red (draken red hair)
            cch.AddColourOption(itemDisplay, 4, 1, 4, 55, 3, 12, push1 + 17, push1 + 34); // brown (aurin f brown skin)
            cch.AddColourOption(itemDisplay, 4, 1, 4, 48, 3, 13, push1 + 34, push1 + 51); // hot pink (mordesh hot pink hair)
            cch.AddColourOption(itemDisplay, 4, 1, 4, 80, 3, 14, push1 + 51, push1 + 68); // umber (mordesh dark purple hair)
            cch.AddColourOption(itemDisplay, 4, 1, 4, 49, 3, 15, push1 + 68, push1 + 85); // light purple (mordesh light purple hair)
            cch.AddColourOption(itemDisplay, 4, 1, 4, 90, 3, 16, push1 + 85, push1 + 102); // aqua (mordesh teal eye)
            cch.AddColourOption(itemDisplay, 4, 1, 4, 85, 3, 17, push1 + 102, push1 + 119); // swamp green (makes a grey-brown; mordesh swamp yellow skin)
            push1 = push1 + 17 * 7;

            // skin
            startID = push1;
            startLV = 11;
            step = 8;
            // Mordesh female skin colours
            list = new List<uint> { 126, 127, 128, 129, 130, 131, 132, 133, 134, 135 };
            foreach (uint id in list)
            {
                cch.AddColourOption(itemDisplay, 4, 1, 2, id, 2, startLV, startID, startID + step);
                startLV += 1;
                startID += step;
            }
            push1 = push1 + 8 * 10;
            cch.AddColourOption(itemDisplay, 4, 1, 2, 85, 2, 21, push1 + 0, push1 + 8); // swamp green (mordesh swamp yellow skin)
            cch.AddColourOption(itemDisplay, 4, 1, 2, 80, 2, 22, push1 + 8, push1 + 16); // dark purple (mordesh dark purple hair)
            push1 = push1 + 8 * 2;

            // Draken female
            startID = push1;
            startLV = 7;
            step = 6;
            // Mordesh male skin as hair
            list = new List<uint> { 81, 82, 83, 84, 86, 87, 88, 89 };
            foreach (uint id in list)
            {
                cch.AddColourOption(itemDisplay, 5, 1, 4, id, 2, startLV, startID, startID + step);
                startLV += 1;
                startID += step;
            }
            push1 = push1 + 6 * 8;
            // hair
            cch.AddColourOption(itemDisplay, 5, 1, 4, 5, 2, 15, push1 + 0, push1 + 6); // brown (aurin f brown skin)
            cch.AddColourOption(itemDisplay, 5, 1, 4, 49, 2, 16, push1 + 6, push1 + 12); // light purple (mordesh light purple hair)
            cch.AddColourOption(itemDisplay, 5, 1, 4, 90, 2, 17, push1 + 12, push1 + 18); // aqua (mordesh teal eye)
            cch.AddColourOption(itemDisplay, 5, 1, 4, 80, 2, 18, push1 + 18, push1 + 24); // umber (mordesh dark purple hair)
            cch.AddColourOption(itemDisplay, 5, 1, 4, 94, 2, 19, push1 + 24, push1 + 30); // orange (mordesh orange eye)
            cch.AddColourOption(itemDisplay, 5, 1, 4, 85, 2, 20, push1 + 30, push1 + 36); // swamp green (makes a grey-brown; mordesh swamp yellow skin)
            cch.AddColourOption(itemDisplay, 5, 1, 4, 48, 2, 21, push1 + 36, push1 + 42); // hot pink (mordesh hot pink hair)
            push1 = push1 + 6 * 7;

            // Mechari female
            startID = push1;
            startLV = 12;
            step = 15;
            // Mordesh female skins
            list = new List<uint> { 126, 127, 128, 129, 130, 131, 132, 134, 135 };
            foreach (uint id in list)
            {
                cch.AddColourOption(itemDisplay, 12, 1, 2, id, 3, startLV, startID, startID + step);
                startLV += 1;
                startID += step;
            }
            push1 = push1 + 15 * 9;
            // skin
            cch.AddColourOption(itemDisplay, 12, 1, 2, 55, 3, 21, push1 + 0, push1 + 15); // brown (aurin f brown skin)
            cch.AddColourOption(itemDisplay, 12, 1, 2, 80, 3, 22, push1 + 15, push1 + 30); // dark purple (mordesh dark purple hair)
            cch.AddColourOption(itemDisplay, 12, 1, 2, 49, 3, 23, push1 + 30, push1 + 45); // light purple (mordesh light purple hair)
            cch.AddColourOption(itemDisplay, 12, 1, 2, 48, 3, 24, push1 + 45, push1 + 60); // hot pink (mordesh hot pink hair)
            push1 = push1 + 15 * 4;

            // Mordesh female
            startID = push1;
            startLV = 13;
            step = 9;
            // Male to female skin
            list = new List<uint> { 80, 81, 82, 83, 84, 85, 86, 87, 88, 89 };
            foreach (uint id in list)
            {
                cch.AddColourOption(itemDisplay, 16, 1, 2, id, 3, startLV, startID, startID + step);
                startLV += 1;
                startID += step;
            }
            push1 = push1 + 9 * 10;
            // skin
            cch.AddColourOption(itemDisplay, 16, 1, 2, 55, 3, 23, push1, push1 + 9); // brown (aurin f brown skin)
            push1 = push1 + 9 * 1;

            // Mordesh male
            startID = push1;
            startLV = 13;
            step = 9;
            // Female to male skin
            list = new List<uint> { 126, 127, 128, 129, 130, 131, 132, 133, 134, 135 };
            foreach (uint id in list)
            {
                cch.AddColourOption(itemDisplay, 16, 0, 2, id, 3, startLV, startID, startID + step);
                startLV += 1;
                startID += step;
            }
            push1 = push1 + 9 * 10;
            // skin
            cch.AddColourOption(itemDisplay, 16, 0, 2, 55, 3, 23); // brown (aurin f brown skin)
            push1 = push1 + 9 * 1;
            //Push 1 ends at ID: 9804


            //Push 2 ****************************************************************************************************
            //Mechari female
            //hair
            list = new List<uint> { 126, 127, 128, 129, 130, 131, 132, 133, 134, 135,
                                    80, 81, 82, 83, 84, 85, 86, 87, 88, 89}; // mordesh M & F skin colors
            startID = push2;
            startLV = 13;
            step = 21;
            foreach (uint id in list)
            {
                cch.AddColourOption(itemDisplay, 12, 1, 14, id, 2, startLV, startID, startID + step);
                startLV += 1;
                startID += step;
            }
            push2 = push2 + 21 * 20;

            //Mordesh female
            //hair
            cch.AddColourOption(itemDisplay, 16, 1, 4, 55, 3, 24, push2 + 0, push2 + 10); // brown (aurin f brown skin)
            cch.AddColourOption(itemDisplay, 16, 1, 4, 94, 3, 25, push2 + 10, push2 + 20); // orange (mordesh orange eyes)
            cch.AddColourOption(itemDisplay, 16, 1, 4, 85, 2, 26, push2 + 20, push2 + 30); // swamp green (makes a grey-brown; mordesh swamp yellow skin)
            push2 = push2 + 10 * 3;
            //Mordesh male
            //hair
            cch.AddColourOption(itemDisplay, 16, 0, 4, 55, 3, 27, push2 + 0, push2 + 5); // brown (aurin f brown skin)
            cch.AddColourOption(itemDisplay, 16, 0, 4, 94, 3, 28, push2 + 5, push2 + 10); // orange (mordesh orange eyes)
            cch.AddColourOption(itemDisplay, 16, 0, 4, 85, 2, 29, push2 + 10, push2 + 15); // swamp green (makes a grey-brown; mordesh swamp yellow skin)
            push2 = push2 + 5 * 3;

            //AddBodyTypes(push3, push3 + 28);
            AddBodyTypes(push3, push3 + 10);
        }

        static void AddBodyTypes(uint startID, uint endID)
        {
            //float[] values = { 0.5f, 1.5f, 2.0f, 2.5f, 3.0f };
            float[] values = { 0.5f, 1.5f};
            uint[] anims = { 260, 261, 262, 263, 264, 265 };
            uint labelValue = 101;
            foreach (float value in values)
            {
                foreach (uint anim in anims)
                {
                    if(value.Equals(0.5f) && (anim == 260 || anim == 261))
                    {
                        continue;
                    }
                    cch.AddBodyType(itemDisplay, 7280, anim, value, 10, labelValue, startID);
                    labelValue += 1;
                    startID += 1;
                }
            }
            if (startID != endID)
            {
                throw new ArgumentException("AddBodyTypes range did not match amount added.");
            }
        }

        static uint AddWeaponItems(uint startID)
        {
            List<(uint, uint, string)> list = new List<(uint, uint, string)>
            {
                // Type: Hammer
                (632, startID++, "Generic Hammer 1"),
                (572, startID++, "Generic Hammer 2"),
                (7156, startID++, "Generic Hammer 3"),
                (633, startID++, "Grund Hammer"),
                (2245, startID++, "Osun Hammer 1"),
                (7157, startID++, "Osun Hammer 2"),
                (7952, startID++, "Osun Hammer 3"),
                (6597, startID++, "Phage Hammer"),

                // Type: Mace
                (8639, startID++, "Moodie Cleaver"),
                (6970, startID++, "Murgh Mace 1"),
                (6969, startID++, "Murgh Mace 2"),
                (2092, startID++, "Pell Mace"),
                
                // Type: Misc
                (602, startID++, "Bone"),
                (1588, startID++, "Glowstick"),
                (1343, startID++, "Mug"),
                (3400, startID++, "Plank"),
                (684, startID++, "Shovel"),
                (8051, startID++, "Sandwich"),
                (7829, startID++, "Drumstick"),

                // Type: Rifle
                (5393, startID++, "Bazooka"),
                (4869, startID++, "Crossbow"),
                (3049, startID++, "Fish Cannon"),
                (2332, startID++, "Flamer"),
                (4793, startID++, "Large Flashlight"),
                (6588, startID++, "Freeze Rifle"),
                (3161, startID++, "Laser Saw"),
                (1946, startID++, "Laser Pickaxe"),
                (149, startID++, "Plasma Rifle"),
                (3138, startID++, "Relic Blaster"),
                (21, startID++, "Sniper Rifle"),

                // Type: Scythe
                (184, startID++, "Generic Scythe 1"),
                (588, startID++, "Generic Scythe 2"),
                (589, startID++, "Generic Scythe 3"),

                // Type: Staff
                (8029, startID++, "Long Fan"),
                (464, startID++, "Generic Staff 1"),
                (465, startID++, "Generic Staff 2"),
                (144, startID++, "Generic Staff 3"),
                (1611, startID++, "Generic Staff 4"),
                (1612, startID++, "Generic Staff 5"),
                (1613, startID++, "Generic Staff 6"),
                (1614, startID++, "Generic Staff 7"),
                (1615, startID++, "Generic Staff 8"),
                (8019, startID++, "Ikthian Stafff"),
                (7837, startID++, "Laveka's Staff"),
                (595, startID++, "Lopp Staff"),
                (2333, startID++, "Osun Staff 1"),
                (3071, startID++, "Osun Staff 2"),
                (7951, startID++, "Osun Glaive 1"),
                (7816, startID++, "Osun Glaive 2"),
                (2090, startID++, "Pell Staff 1"),
                (2091, startID++, "Pell Staff 2"),
                (79, startID++, "Skeech Staff 1"),
                (7290, startID++, "Skeech Staff 2"),

                // Type: Sword 1H
                (1, startID++, "Cross Sword"),
                (6972, startID++, "Falkrin 1H Sword"),
                (612, startID++, "Generic 1H Sword 1"),
                (145, startID++, "Generic 1H Sword 2"),
                (2089, startID++, "Pell Sword"),
                (2386, startID++, "Torohawk Sword"),

                // Type: Sword 2H
                (7018, startID++, "Corrupted Sword"),
                (6968, startID++, "Exile Sword"),
                (2093, startID++, "Falkrin 2H Sword 1"),
                (6967, startID++, "Falkrin 2H Sword 2"),
                (30, startID++, "Generic 2H Sword 1"),
                (12, startID++, "Generic 2H Sword 2"),

                // Type: Wrench
                (39, startID++, "Small Wrench"),
                (147, startID++, "Big Wrench"),
                (1617, startID++, "Ikthian Wrench"),
            };
            foreach (var id in list)
            {
                var entry = item2.CopyEntry(74762);
                entry.Values[12].SetValue(0u);
                entry.Values[10].SetValue(id.Item1);
                entry.Values[44].SetValue(language.AddEntry(id.Item3));
                entry.Values.RemoveAt(0);
                item2.AddEntry(entry, id.Item2);
            }
            return startID;
        }

        static uint AddCreaturesMounts(uint startItem2Id)
        {
            //GetMaxID is NOT returning the highest ID currently in these tables...
            uint startCreature2ID = creature2.GetMaxID() + 1000;
            uint startCreature2DisplayGroupID = 41453 + 1000;
            uint startCreature2DisplayGroupEntryID = creature2DisplayGroupEntry.GetMaxID() + 1000;
            uint startCreature2DisplayInfoID = creature2DisplayInfo.GetMaxID() + 1000;

            // Type: Riding Pumera
            // (Texture, Name, Creature2 ID, Creature2DisplayGroup ID, Creature2DisplayGroupEntry ID, Creature2DisplayInfo ID)
            List<(string, string, uint, uint, uint, uint)> ridingPumera = new List<(string, string, uint, uint, uint, uint)>
            {
                ("Art\\Creature\\Pumera\\CRT_Pumera_B_Color.tex", "Riding Pumera (Tawny)", startCreature2ID, startCreature2DisplayGroupID, startCreature2DisplayGroupEntryID, startCreature2DisplayInfoID),
                ("Art\\Creature\\Pumera\\CRT_Pumera_Exotic_01_Color.tex", "Riding Pumera (Sienna)", startCreature2ID+1, startCreature2DisplayGroupID+1, startCreature2DisplayGroupEntryID+1, startCreature2DisplayInfoID+1),
                ("Art\\Creature\\Pumera\\CRT_Pumera_Exotic_02_Color.tex", "Riding Pumera (Magenta)", startCreature2ID+2, startCreature2DisplayGroupID+2, startCreature2DisplayGroupEntryID+2, startCreature2DisplayInfoID+2),
                ("Art\\Creature\\Pumera\\CRT_Pumera_Exotic_03_Color.tex", "Riding Pumera (Golden)", startCreature2ID+3, startCreature2DisplayGroupID+3, startCreature2DisplayGroupEntryID+3, startCreature2DisplayInfoID+3),
                ("Art\\Creature\\Pumera\\CRT_Pumera_A_Color.tex", "Riding Pumera (Maroon)", startCreature2ID+4, startCreature2DisplayGroupID+4, startCreature2DisplayGroupEntryID+4, startCreature2DisplayInfoID+4),
                ("Art\\Creature\\Pumera\\CRT_Pumera_C_Color.tex", "Riding Pumera (Snowy)", startCreature2ID+5, startCreature2DisplayGroupID+5, startCreature2DisplayGroupEntryID+5, startCreature2DisplayInfoID+5),
                ("Art\\Creature\\Pumera\\CRT_Pumera_Icy_02_color.tex", "Riding Pumera (Snow Stripe)", startCreature2ID+6, startCreature2DisplayGroupID+6, startCreature2DisplayGroupEntryID+6, startCreature2DisplayInfoID+6),
                ("Art\\Creature\\Pumera\\CRT_Pumera_Icy_03_color.tex", "Riding Pumera (Steely)", startCreature2ID+7, startCreature2DisplayGroupID+7, startCreature2DisplayGroupEntryID+7, startCreature2DisplayInfoID+7),
                ("Art\\Creature\\Pumera\\CRT_Pumera_Icy_01_color.tex", "Riding Pumera (Whitevale)", startCreature2ID+8, startCreature2DisplayGroupID+8, startCreature2DisplayGroupEntryID+8, startCreature2DisplayInfoID+8),
            };
            foreach (var row in ridingPumera) {
                // Create Display Info
                var displayInfoEntry = creature2DisplayInfo.CopyEntry(38342); // Copy generic Grey Pumera mount display info
                displayInfoEntry.Values[3].SetValue(row.Item1); //switch assetTexture00 to the given texture path
                displayInfoEntry.Values.RemoveAt(0);
                creature2DisplayInfo.AddEntry(displayInfoEntry, row.Item6);
                

                // Create Display Group Entry
                var displayGroupEntry = creature2DisplayGroupEntry.CopyEntry(44325); // Copy generic Grey Pumera mount display group entry
                displayGroupEntry.Values[1].SetValue(row.Item4); //creature2DisplayGroupId
                displayGroupEntry.Values[2].SetValue(row.Item6); //creature2DisplayInfoId
                displayGroupEntry.Values.RemoveAt(0);
                creature2DisplayGroupEntry.AddEntry(displayGroupEntry, row.Item5);


                // Create Creature2
                var entry = creature2.CopyEntry(73213); // Copy generic Grey Pumera mount
                entry.Values[2].SetValue(row.Item2); //description
                uint localizedTextIdName = language.AddEntry(row.Item2);
                entry.Values[3].SetValue(localizedTextIdName); //localizedTextIdName
                entry.Values[10].SetValue(row.Item4); //creature2DisplayGroupId
                entry.Values.RemoveAt(0);
                creature2.AddEntry(entry, row.Item3);

                // Do Item/Spell stuff for the mount unlock
                
                uint copySpell4BaseId_Unlock = 62733u; // Striped Torine pumera unlock spell
                uint copySpell4BaseId_Summon = 62732u; // Striped Torine pumera summon spell
                uint copySpell4Id_Unlock = 87660u; // Striped Torine pumera unlock spell
                uint copySpell4Id_Summon = 87659u; // Striped Torine pumera summon spell
                uint copyItem2Id = 91368u; // Striped Torine pumera item
                uint copyItemSpecialId = 10002u; // Striped Torine pumera item special
                startItem2Id = AddSpellsItemForMount(startItem2Id, row.Item3, row.Item2, localizedTextIdName, copySpell4BaseId_Unlock, copySpell4BaseId_Summon, copySpell4Id_Unlock, copySpell4Id_Summon, copyItem2Id, copyItemSpecialId);
                
            }
            startCreature2ID += 9;
            startCreature2DisplayGroupID += 9;
            startCreature2DisplayGroupEntryID += 9;
            startCreature2DisplayInfoID += 9;

            
            // Type: Equirin
            // (Texture, Name, Creature2 ID, Creature2DisplayGroup ID, Creature2DisplayGroupEntry ID, Creature2DisplayInfo ID, Normal)
            List<(string, string, uint, uint, uint, uint, string)> equirin = new List<(string, string, uint, uint, uint, uint, string)>
            {
                ("Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\mount_creature_horse_equivar_000b_color.tex", "Equirin (Blue)", startCreature2ID, startCreature2DisplayGroupID, startCreature2DisplayGroupEntryID, startCreature2DisplayInfoID, "Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\Mount_Creature_Horse_Equivar_000_normal.tex"),
                ("Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\mount_creature_horse_equivar_moss_000_color.tex", "Equirin (Verdant)", startCreature2ID+1, startCreature2DisplayGroupID+1, startCreature2DisplayGroupEntryID+1, startCreature2DisplayInfoID+1, "Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\Mount_Creature_Horse_Equivar_000_normal.tex"),
                ("Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\mount_creature_horse_equivar_000c_color.tex", "Equirin (Green)", startCreature2ID+2, startCreature2DisplayGroupID+2, startCreature2DisplayGroupEntryID+2, startCreature2DisplayInfoID+2, "Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\Mount_Creature_Horse_Equivar_000_normal.tex"),
                ("Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\mount_creature_horse_equivar_000a_color.tex", "Equirin (Purple)", startCreature2ID+3, startCreature2DisplayGroupID+3, startCreature2DisplayGroupEntryID+3, startCreature2DisplayInfoID+3, "Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\Mount_Creature_Horse_Equivar_000_normal.tex"),
                ("Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\mount_creature_horse_equivar_variant_BlackWhite_000_color.tex", "Equirin (Obsidian)", startCreature2ID+4, startCreature2DisplayGroupID+4, startCreature2DisplayGroupEntryID+4, startCreature2DisplayInfoID+4, "Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\mount_creature_horse_equivar_variant_blackwhite_000_normal.tex"),
                ("Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\mount_creature_horse_equivar_variant_rock_000_color.tex", "Equirin (Luminous)", startCreature2ID+5, startCreature2DisplayGroupID+5, startCreature2DisplayGroupEntryID+5, startCreature2DisplayInfoID+5, "Art\\Mount\\Ground\\Creature_Horse\\Equivar\\Textures\\mount_creature_horse_equivar_variant_rock_000_normal.tex"),
            };
            foreach (var row in equirin)
            {
                // Create Display Info
                var displayInfoEntry = creature2DisplayInfo.CopyEntry(37424); // Copy generic Horned Equivar display info
                displayInfoEntry.Values[3].SetValue(row.Item1); //switch assetTexture00 to the given texture path
                displayInfoEntry.Values[4].SetValue(row.Item7); //switch assetTexture01 to the given normal path
                displayInfoEntry.Values[9].SetValue(1u); //modelTextureId00
                displayInfoEntry.Values[10].SetValue(2u); //modelTextureId01
                displayInfoEntry.Values.RemoveAt(0);
                creature2DisplayInfo.AddEntry(displayInfoEntry, row.Item6);


                // Create Display Group Entry
                var displayGroupEntry = creature2DisplayGroupEntry.CopyEntry(43267); // Copy generic Horned Equivar mount display group entry
                displayGroupEntry.Values[1].SetValue(row.Item4); //creature2DisplayGroupId
                displayGroupEntry.Values[2].SetValue(row.Item6); //creature2DisplayInfoId
                displayGroupEntry.Values.RemoveAt(0);
                creature2DisplayGroupEntry.AddEntry(displayGroupEntry, row.Item5);


                // Create Creature2
                var entry = creature2.CopyEntry(71476); // Copy generic Horned Equivar mount
                entry.Values[2].SetValue(row.Item2); //description
                entry.Values[3].SetValue(language.AddEntry(row.Item2)); //localizedTextIdName
                entry.Values[10].SetValue(row.Item4); //creature2DisplayGroupId
                entry.Values.RemoveAt(0);
                creature2.AddEntry(entry, row.Item3);
            }
            startCreature2ID += 6;
            startCreature2DisplayGroupID += 6;
            startCreature2DisplayGroupEntryID += 6;
            startCreature2DisplayInfoID += 6;


            // Type: Trask
            // (Texture, Name, Creature2 ID, Creature2DisplayGroup ID, Creature2DisplayGroupEntry ID, Creature2DisplayInfo ID)
            List<(string, string, uint, uint, uint, uint)> trask = new List<(string, string, uint, uint, uint, uint)>
            {
                ("Art\\Mount\\Cat_Preset\\Mount_Eshara\\EsharaMount_Green_Color.tex", "Trask (Blue)", startCreature2ID, startCreature2DisplayGroupID, startCreature2DisplayGroupEntryID, startCreature2DisplayInfoID),
                ("Art\\Mount\\Cat_Preset\\Mount_Eshara\\EsharaMount_Red_Color.tex", "Trask (Red)", startCreature2ID+1, startCreature2DisplayGroupID+1, startCreature2DisplayGroupEntryID+1, startCreature2DisplayInfoID+1),
                ("Art\\Mount\\Cat_Preset\\Mount_Eshara\\EsharaMount_yellow_Color.tex", "Trask (Yellow)", startCreature2ID+2, startCreature2DisplayGroupID+2, startCreature2DisplayGroupEntryID+2, startCreature2DisplayInfoID+2),
                ("Art\\Mount\\Cat_Preset\\Mount_Eshara\\EsharaMount_black_Color.tex", "Trask (Black)", startCreature2ID+3, startCreature2DisplayGroupID+3, startCreature2DisplayGroupEntryID+3, startCreature2DisplayInfoID+3),
            };
            foreach (var row in trask)
            {
                // Create Display Info
                var displayInfoEntry = creature2DisplayInfo.CopyEntry(21981); // Copy generic Trask display info
                displayInfoEntry.Values[3].SetValue(row.Item1); //switch assetTexture00 to the given texture path
                displayInfoEntry.Values.RemoveAt(0);
                creature2DisplayInfo.AddEntry(displayInfoEntry, row.Item6);


                // Create Display Group Entry
                var displayGroupEntry = creature2DisplayGroupEntry.CopyEntry(21994); // Copy generic Trask display group entry
                displayGroupEntry.Values[1].SetValue(row.Item4); //creature2DisplayGroupId
                displayGroupEntry.Values[2].SetValue(row.Item6); //creature2DisplayInfoId
                displayGroupEntry.Values.RemoveAt(0);
                creature2DisplayGroupEntry.AddEntry(displayGroupEntry, row.Item5);


                // Create Creature2
                var entry = creature2.CopyEntry(5212); // Copy generic Trask
                entry.Values[2].SetValue(row.Item2); //description
                entry.Values[3].SetValue(language.AddEntry(row.Item2)); //localizedTextIdName
                entry.Values[10].SetValue(row.Item4); //creature2DisplayGroupId
                entry.Values.RemoveAt(0);
                creature2.AddEntry(entry, row.Item3);
            }
            startCreature2ID += 4;
            startCreature2DisplayGroupID += 4;
            startCreature2DisplayGroupEntryID += 4;
            startCreature2DisplayInfoID += 4;


            // Type: Riding Girrok
            // (Texture, Name, Creature2 ID, Creature2DisplayGroup ID, Creature2DisplayGroupEntry ID, Creature2DisplayInfo ID)
            List<(string, string, uint, uint, uint, uint, string)> ridingGirrok = new List<(string, string, uint, uint, uint, uint, string)>
            {
                ("Art\\Creature\\Girok\\Girok_A_Color.tex", "Riding Girrok (Black)", startCreature2ID, startCreature2DisplayGroupID, startCreature2DisplayGroupEntryID, startCreature2DisplayInfoID, "Art\\Creature\\Girok\\Girok_Normal.tex"),
                ("Art\\Creature\\Girok\\Textures\\Girok_B_White_Color.tex", "Riding Girrok (White)", startCreature2ID+1, startCreature2DisplayGroupID+1, startCreature2DisplayGroupEntryID+1, startCreature2DisplayInfoID+1, "Art\\Creature\\Girok\\Girok_Normal.tex"),
                ("Art\\Creature\\Girok\\Girok_B_Color.tex", "Riding Girrok (Purple)", startCreature2ID+2, startCreature2DisplayGroupID+2, startCreature2DisplayGroupEntryID+2, startCreature2DisplayInfoID+2, "Art\\Creature\\Girok\\Girok_Normal.tex"),
                ("Art\\Creature\\Girok\\Girok_Boss_Color.tex", "Riding Girrok (Scarred)", startCreature2ID+3, startCreature2DisplayGroupID+3, startCreature2DisplayGroupEntryID+3, startCreature2DisplayInfoID+3, "Art\\Creature\\Girok\\Girok_Boss_Normal.tex"),
                ("Art\\Creature\\Girok\\Textures\\Girok_C_Color.tex", "Riding Girrok (Purple Stripe)", startCreature2ID+4, startCreature2DisplayGroupID+4, startCreature2DisplayGroupEntryID+4, startCreature2DisplayInfoID+4, "Art\\Creature\\Girok\\Girok_Normal.tex"),
            };
            foreach (var row in ridingGirrok)
            {
                // Create Display Info
                var displayInfoEntry = creature2DisplayInfo.CopyEntry(38343); // Copy generic Girrok mount display info
                displayInfoEntry.Values[3].SetValue(row.Item1); //switch assetTexture00 to the given texture path
                displayInfoEntry.Values[4].SetValue(row.Item7); //switch assetTexture01 to the given normal path
                displayInfoEntry.Values[9].SetValue(1u); //modelTextureId00
                displayInfoEntry.Values[10].SetValue(2u); //modelTextureId01
                displayInfoEntry.Values.RemoveAt(0);
                creature2DisplayInfo.AddEntry(displayInfoEntry, row.Item6);


                // Create Display Group Entry
                var displayGroupEntry = creature2DisplayGroupEntry.CopyEntry(44326); // Copy generic Girrok mount display group entry
                displayGroupEntry.Values[1].SetValue(row.Item4); //creature2DisplayGroupId
                displayGroupEntry.Values[2].SetValue(row.Item6); //creature2DisplayInfoId
                displayGroupEntry.Values.RemoveAt(0);
                creature2DisplayGroupEntry.AddEntry(displayGroupEntry, row.Item5);


                // Create Creature2
                var entry = creature2.CopyEntry(73222); // Copy generic Girrok mount
                entry.Values[2].SetValue(row.Item2); //description
                entry.Values[3].SetValue(language.AddEntry(row.Item2)); //localizedTextIdName
                entry.Values[10].SetValue(row.Item4); //creature2DisplayGroupId
                entry.Values.RemoveAt(0);
                creature2.AddEntry(entry, row.Item3);
            }
            startCreature2ID += 5;
            startCreature2DisplayGroupID += 5;
            startCreature2DisplayGroupEntryID += 5;
            startCreature2DisplayInfoID += 5;

            //Pell experiments ******************************************************************************************************************
            //copiedDisplayInfoID, displayInfoId, modelAssetPath, textureAssetPath1, normalAssetPath1, textureAssetPath2, normalAssetPath2, copiedDisplayGroupEntryId,
            //displayGroupEntryId, displayGroupId, copiedCreature2Id, creature2Id, description, name
            List<(uint, uint, string, string, string, string, string, uint, uint, uint, uint, uint, string, string)> pellClothingSwap = new List<(uint, uint, string, string, string, string, string, uint, uint, uint, uint, uint, string, string)>
            {
                //White Pell - Default Armorset
                (32831, startCreature2DisplayInfoID, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID, startCreature2DisplayGroupID, 37326, startCreature2ID, "White Pell 1a", "Pell Villager"),
                (32830, startCreature2DisplayInfoID+1, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Cultist\\Pell_Cultist_Color.tex", "Art\\Creature\\Pell\\Pell_Cultist\\Pell_Cultist_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+1, startCreature2DisplayGroupID+1, 37326, startCreature2ID+1, "White Pell 2a", "Pell Villager"),
                (32836, startCreature2DisplayInfoID+2, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+2, startCreature2DisplayGroupID+2, 37326, startCreature2ID+2, "White Pell 3a", "Pell Villager"),
                (32837, startCreature2DisplayInfoID+3, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+3, startCreature2DisplayGroupID+3, 37326, startCreature2ID+3, "Armored White Pell 1a", "Pell Villager"),
                (32838, startCreature2DisplayInfoID+4, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+4, startCreature2DisplayGroupID+4, 37326, startCreature2ID+4, "Armored White Pell 2a", "Pell Villager"),
                (32839, startCreature2DisplayInfoID+5, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+5, startCreature2DisplayGroupID+5, 37326, startCreature2ID+5, "Armored White Pell 3a", "Pell Villager"),
                (32840, startCreature2DisplayInfoID+6, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+6, startCreature2DisplayGroupID+6, 37326, startCreature2ID+6, "Armored White Pell 4a", "Pell Villager"),
                //White Pell - Water/Air Armorset
                (32831, startCreature2DisplayInfoID+7, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+7, startCreature2DisplayGroupID+7, 37326, startCreature2ID+7, "White Pell 1b", "Pell Villager"),
                (32830, startCreature2DisplayInfoID+8, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_CultistWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_CultistWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+8, startCreature2DisplayGroupID+8, 37326, startCreature2ID+8, "White Pell 2b", "Pell Villager"),
                (32836, startCreature2DisplayInfoID+9, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+9, startCreature2DisplayGroupID+9, 37326, startCreature2ID+9, "White Pell 3b", "Pell Villager"),
                (32837, startCreature2DisplayInfoID+10, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+10, startCreature2DisplayGroupID+10, 37326, startCreature2ID+10, "Armored White Pell 1b", "Pell Villager"),
                (32838, startCreature2DisplayInfoID+11, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+11, startCreature2DisplayGroupID+11, 37326, startCreature2ID+11, "Armored White Pell 2b", "Pell Villager"),
                (32839, startCreature2DisplayInfoID+12, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+12, startCreature2DisplayGroupID+12, 37326, startCreature2ID+12, "Armored White Pell 3b", "Pell Villager"),
                (32840, startCreature2DisplayInfoID+13, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\crt_pell_fire_color.tex", "Art\\Creature\\Pell\\crt_pell_fire_normal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+13, startCreature2DisplayGroupID+13, 37326, startCreature2ID+13, "Armored White Pell 4b", "Pell Villager"),
                //Brown Pell - Water/Air Armorset
                (22431, startCreature2DisplayInfoID+14, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+14, startCreature2DisplayGroupID+14, 37326, startCreature2ID+14, "Brown Pell 1a", "Pell Villager"),
                (21321, startCreature2DisplayInfoID+15, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_CultistWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_CultistWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+15, startCreature2DisplayGroupID+15, 37326, startCreature2ID+15, "Brown Pell 2a", "Pell Villager"),
                (22432, startCreature2DisplayInfoID+16, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+16, startCreature2DisplayGroupID+16, 37326, startCreature2ID+16, "Brown Pell 3a", "Pell Villager"),
                (22433, startCreature2DisplayInfoID+17, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+17, startCreature2DisplayGroupID+17, 37326, startCreature2ID+17, "Brown Pell 4a", "Pell Villager"),
                (22434, startCreature2DisplayInfoID+18, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+18, startCreature2DisplayGroupID+18, 37326, startCreature2ID+18, "Armored Brown Pell 1a", "Pell Villager"),
                (22435, startCreature2DisplayInfoID+19, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+19, startCreature2DisplayGroupID+19, 37326, startCreature2ID+19, "Armored Brown Pell 2a", "Pell Villager"),
                (22436, startCreature2DisplayInfoID+20, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+20, startCreature2DisplayGroupID+20, 37326, startCreature2ID+20, "Armored Brown Pell 3a", "Pell Villager"),
                (22437, startCreature2DisplayInfoID+21, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_Pell_WarriorWater_Normal.tex", 37197, startCreature2DisplayGroupEntryID+21, startCreature2DisplayGroupID+21, 37326, startCreature2ID+21, "Armored Brown Pell 4a", "Pell Villager"),
                //Brown Pell - Fire Armorset
                (22431, startCreature2DisplayInfoID+22, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+22, startCreature2DisplayGroupID+22, 37326, startCreature2ID+22, "Brown Pell 1b", "Pell Villager"),
                (21321, startCreature2DisplayInfoID+23, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Cultist\\pell_fire_cultist_color.tex", "Art\\Creature\\Pell\\Pell_Cultist\\pell_fire_cultist_normal.tex", 37197, startCreature2DisplayGroupEntryID+23, startCreature2DisplayGroupID+23, 37326, startCreature2ID+23, "Brown Pell 2b", "Pell Villager"),
                (22432, startCreature2DisplayInfoID+24, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+24, startCreature2DisplayGroupID+24, 37326, startCreature2ID+24, "Brown Pell 3b", "Pell Villager"),
                (22433, startCreature2DisplayInfoID+25, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+25, startCreature2DisplayGroupID+25, 37326, startCreature2ID+25, "Brown Pell 4b", "Pell Villager"),
                (22434, startCreature2DisplayInfoID+26, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+26, startCreature2DisplayGroupID+26, 37326, startCreature2ID+26, "Armored Brown Pell 1b", "Pell Villager"),
                (22435, startCreature2DisplayInfoID+27, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+27, startCreature2DisplayGroupID+27, 37326, startCreature2ID+27, "Armored Brown Pell 2b", "Pell Villager"),
                (22436, startCreature2DisplayInfoID+28, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+28, startCreature2DisplayGroupID+28, 37326, startCreature2ID+28, "Armored Brown Pell 3b", "Pell Villager"),
                (22437, startCreature2DisplayInfoID+29, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\CRT_Pell_Color.tex", "Art\\Creature\\Pell\\crt_pell_dxtnormal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+29, startCreature2DisplayGroupID+29, 37326, startCreature2ID+29, "Armored Brown Pell 4b", "Pell Villager"),
                //Grey Pell - Default Armorset
                (27136, startCreature2DisplayInfoID+30, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+30, startCreature2DisplayGroupID+30, 37326, startCreature2ID+30, "Grey Pell 1a", "Pell Villager"),
                (27135, startCreature2DisplayInfoID+31, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Cultist\\Pell_Cultist_Color.tex", "Art\\Creature\\Pell\\Pell_Cultist\\Pell_Cultist_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+31, startCreature2DisplayGroupID+31, 37326, startCreature2ID+31, "Grey Pell 2a", "Pell Villager"),
                (27138, startCreature2DisplayInfoID+32, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+32, startCreature2DisplayGroupID+32, 37326, startCreature2ID+32, "Grey Pell 3a", "Pell Villager"),
                (27137, startCreature2DisplayInfoID+33, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+33, startCreature2DisplayGroupID+33, 37326, startCreature2ID+33, "Grey Pell 4a", "Pell Villager"),
                (27139, startCreature2DisplayInfoID+34, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+34, startCreature2DisplayGroupID+34, 37326, startCreature2ID+34, "Armored Grey Pell 1a", "Pell Villager"),
                (27140, startCreature2DisplayInfoID+35, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+35, startCreature2DisplayGroupID+35, 37326, startCreature2ID+35, "Armored Grey Pell 2a", "Pell Villager"),
                (28616, startCreature2DisplayInfoID+36, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+36, startCreature2DisplayGroupID+36, 37326, startCreature2ID+36, "Armored Grey Pell 3a", "Pell Villager"),
                (28617, startCreature2DisplayInfoID+37, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Battle_dxtNormal.tex", 37197, startCreature2DisplayGroupEntryID+37, startCreature2DisplayGroupID+37, 37326, startCreature2ID+37, "Armored Grey Pell 4a", "Pell Villager"),
                //Grey Pell - Fire Armorset
                (27136, startCreature2DisplayInfoID+38, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+38, startCreature2DisplayGroupID+38, 37326, startCreature2ID+38, "Grey Pell 1b", "Pell Villager"),
                (27135, startCreature2DisplayInfoID+39, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Cultist\\pell_fire_cultist_color.tex", "Art\\Creature\\Pell\\Pell_Cultist\\pell_fire_cultist_normal.tex", 37197, startCreature2DisplayGroupEntryID+39, startCreature2DisplayGroupID+39, 37326, startCreature2ID+39, "Grey Pell 2b", "Pell Villager"),
                (27138, startCreature2DisplayInfoID+40, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+40, startCreature2DisplayGroupID+40, 37326, startCreature2ID+40, "Grey Pell 3b", "Pell Villager"),
                (27137, startCreature2DisplayInfoID+41, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+41, startCreature2DisplayGroupID+41, 37326, startCreature2ID+41, "Grey Pell 4b", "Pell Villager"),
                (27139, startCreature2DisplayInfoID+42, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+42, startCreature2DisplayGroupID+42, 37326, startCreature2ID+42, "Armored Grey Pell 1b", "Pell Villager"),
                (27140, startCreature2DisplayInfoID+43, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+43, startCreature2DisplayGroupID+43, 37326, startCreature2ID+43, "Armored Grey Pell 2b", "Pell Villager"),
                (28616, startCreature2DisplayInfoID+44, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+44, startCreature2DisplayGroupID+44, 37326, startCreature2ID+44, "Armored Grey Pell 3b", "Pell Villager"),
                (28617, startCreature2DisplayInfoID+45, "Art\\Creature\\Pell\\Pell_Base\\Pell_Base.m3", "Art\\Creature\\Pell\\Pell_Water\\Textures\\CRT_PellWater_Color.tex", "Art\\Creature\\Pell\\Pell_Water\\Textures\\crt_pellwater_normal.tex", "Art\\Creature\\Pell\\Pell_Battle\\Pell_Fire_Battle_Color.tex", "Art\\Creature\\Pell\\Pell_Battle\\pell_fire_battle_normal.tex", 37197, startCreature2DisplayGroupEntryID+45, startCreature2DisplayGroupID+45, 37326, startCreature2ID+45, "Armored Grey Pell 4b", "Pell Villager"),
            };
            foreach (var row in pellClothingSwap)
            {
                uint newDisplayInfoId = AddDisplayInfoEntry(row.Item1, row.Item2, row.Item3, row.Item4, row.Item5, row.Item6, row.Item7);
                AddDisplayGroupEntry(row.Item8, row.Item9, row.Item10, newDisplayInfoId);
                uint newCreatureId = AddCreature(row.Item11, row.Item12, row.Item13, row.Item14, row.Item10);
                Console.WriteLine(row.Item13 + " creature2Id = " + newCreatureId + " displayGroupId = " + row.Item10);
            }
            startCreature2ID += 7;
            startCreature2DisplayGroupID += 7;
            startCreature2DisplayGroupEntryID += 7;
            startCreature2DisplayInfoID += 7;

            return startItem2Id;
        }

        
        static uint AddSpellsItemForMount(uint startItem2Id, uint creature2Id, string description, uint localizedTextIdName, uint copySpell4BaseId_Unlock, uint copySpell4BaseId_Summon, uint copySpell4Id_Unlock, uint copySpell4Id_Summon, uint copyItem2Id, uint copyItemSpecialId)
        {
            /*
            // Create Spell4Base for unlock spell
            var entry_spell4Base_Unlock = spell4Base.CopyEntry(copySpell4BaseId_Unlock);
            entry_spell4Base_Unlock.Values[1].SetValue(localizedTextIdName);
            entry_spell4Base_Unlock.Values.RemoveAt(0);
            uint newSpell4BaseId_Unlock = spell4Base.AddEntry(entry_spell4Base_Unlock);

            // Create Spell4 for unlock spell
            var entry_spell4_Unlock = spell4.CopyEntry(copySpell4Id_Unlock);
            entry_spell4_Unlock.Values[1].SetValue("Unlock Spell - " + description);
            entry_spell4_Unlock.Values[2].SetValue(newSpell4BaseId_Unlock);
            entry_spell4_Unlock.Values[29].SetValue(localizedTextIdName); //localizedTextIdActionBarTooltip
            entry_spell4_Unlock.Values.RemoveAt(0);
            uint newSpell4Id_Unlock = spell4.AddEntry(entry_spell4_Unlock);

            // Create ItemSpecial for unlock
            var entry_itemSpecial_Unlock = itemSpecial.CopyEntry(copyItemSpecialId);
            entry_itemSpecial_Unlock.Values[4].SetValue(newSpell4Id_Unlock); //spell4IdOnActivate
            entry_itemSpecial_Unlock.Values.RemoveAt(0);
            uint newItemSpecialId_Unlock = itemSpecial.AddEntry(entry_itemSpecial_Unlock);

            // Create Item2 for unlock
            var entry_item2_Unlock = item2.CopyEntry(copyItem2Id);
            entry_item2_Unlock.Values[5].SetValue(newItemSpecialId_Unlock);
            entry_item2_Unlock.Values[44].SetValue(localizedTextIdName);
            entry_item2_Unlock.Values.RemoveAt(0);
            startItem2Id++;
            item2.AddEntry(entry_item2_Unlock, startItem2Id);
            */


            // Create Spell4Base for summon spell
            /*var entry_spell4Base_Summon = spell4Base.CopyEntry(copySpell4BaseId_Summon);
            entry_spell4Base_Summon.Values[1].SetValue(localizedTextIdName);
            entry_spell4Base_Summon.Values.RemoveAt(0);
            uint newSpell4BaseId_Summon = spell4Base.AddEntry(entry_spell4Base_Summon);

            // Create Spell4 for summon spell
            var entry_spell4_Summon = spell4.CopyEntry(copySpell4Id_Summon);
            entry_spell4_Summon.Values[1].SetValue("Summon Spell - " + description);
            entry_spell4_Summon.Values[2].SetValue(newSpell4BaseId_Summon);
            entry_spell4_Summon.Values[29].SetValue(localizedTextIdName); //localizedTextIdActionBarTooltip
            entry_spell4_Summon.Values[60].SetValue(localizedTextIdName); //localizedTextIdCasterIconSpellText
            entry_spell4_Summon.Values.RemoveAt(0);
            uint newSpell4Id_Summon = spell4.AddEntry(entry_spell4_Summon);*/


            return startItem2Id;
        }
        

        static void TestArchiveWriting()
        {
            AddAllTables("../../../../Tbl/");
            LoadTables();
            SaveTables("../../../../TblTest/");
        }

        static bool betaMode = false;

        static Table spell4Base = AddTable("Spell4Base");
        static Table spell4 = AddTable("Spell4");
        static Table hookAssets = AddTable("HookAsset", true);
        static Table decorInfo = AddTable("HousingDecorInfo");
        static Table decorType = AddTable("HousingDecorType");
        static Table colorShift = AddTable("ColorShift");
        static Table emotes = AddTable("Emotes");
        static Table wallpaperInfo = AddTable("HousingWallpaperInfo");
        static Table worldLayer = AddTable("WorldLayer", true);
        static Table customizationParameter = AddTable("CustomizationParameter", false, false);
        static Table customizationParameterMap = AddTable("CustomizationParameterMap", false, false);
        static Table characterCustomization = AddTable("CharacterCustomization", false);
        static Table characterCustomizationLabel = AddTable("CharacterCustomizationLabel", true);
        static Table characterCustomizationSelection = AddTable("CharacterCustomizationSelection", false);
        static CharacterCustomizationHandler cch = new CharacterCustomizationHandler();
        static Table creature2DisplayInfo = AddTable("Creature2DisplayInfo");
        static Table creature2DisplayGroupEntry = AddTable("Creature2DisplayGroupEntry");
        static Table creature2 = AddTable("Creature2");
        static Table housingPlugItem = AddTable("HousingPlugItem");
        //static Table dyeColorRamp = AddTable("DyeColorRamp");
        static Table itemColorSet = AddTable("ItemColorSet");
        static Table itemDisplay = AddTable("ItemDisplay");
        //static Table itemSpecial = AddTable("ItemSpecial");
        static Table item2 = AddTable("Item2");
        static Table creature2OutfitInfo = AddTable("Creature2OutfitInfo");
        static Table creature2OutfitGroupEntry = AddTable("Creature2OutfitGroupEntry");
        static TextTable.TextTable language = null;


        public static Table AddTable(string name, bool requireID = false, bool doSave = true)
        {
            Table table = new Table(name, doSave, requireID);
            tables.Add(table);
            return table;
        }

        public static void LoadTables()
        {
            foreach (var table in tables)
            {
                table.Load("../../../../Tbl/");
            }
            language = new TextTable.TextTable();
            language.Load("../../../../Tbl/en-US.bin");
            cch.Load(characterCustomization, characterCustomizationLabel, characterCustomizationSelection);
        }

        public static void SaveTables(string baseFolder)
        {
            Directory.CreateDirectory(baseFolder + "DB");
            foreach (var table in tables)
            {
                table.Save(baseFolder + "DB/");
            }

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

        public static void AddAllTables(string baseFolder)
        {
            List<string> names = new List<string>();
            foreach (var name in Directory.GetFiles(baseFolder, "*.tbl", SearchOption.AllDirectories))
            {
                names.Add(Path.GetFileNameWithoutExtension(name));
            }
            List<string> tableNames = new List<string>();
            foreach (var table in tables)
            {
                tableNames.Add(table.name);
            }
            names.RemoveAll(s => tableNames.Contains(s));

            List<string> cantWrite = new List<string>
            {
                "ItemRuneSlotRandomization",
                "MapZoneLevelBand",
                "MatchingMapPrerequisite",
                "PublicEventUnitPropertyModifier",
                "SoundReplaceDescription",
                "SoundReplace",
                "WordFilterAlt",
            };
            names.RemoveAll(s => cantWrite.Contains(s));

            foreach (var name in names)
            {
                AddTable(name);
            }
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
            NSFWS = 71,
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

            uint id = hookAssets.nextEntry;
            hookAssets.AddEntry(entry, id);
            return id;
        }

        static uint GetColorSet(uint col1, uint col2 = 0, uint col3 = 0)
        {
            GameTableEntry entry = itemColorSet.table.Entries.Where(e =>
                e.Values[1].GetValue<uint>() == col1 &&
                e.Values[2].GetValue<uint>() == col2 &&
                e.Values[3].GetValue<uint>() == col3
            ).FirstOrDefault();
            if (entry == null)
            {
                entry = Table.CopyEntry(itemColorSet.table.Entries[0]);
                entry.Values[1].SetValue(col1);
                entry.Values[2].SetValue(col2);
                entry.Values[3].SetValue(col3);
                entry.Values.RemoveAt(0);
                return itemColorSet.AddEntry(entry, itemColorSet.nextEntry);
            }
            return entry.Values[0].GetValue<uint>();
        }

        static void AddDecorType(DecorCategory id, string name, string luaString)
        {
            var entry = new GameTableEntry();
            entry.AddInteger(language.AddEntry(name));
            entry.AddString(luaString);

            decorType.AddEntry(entry, (uint)id);
        }

        static void AddGenericDecor(string hookAsset, uint copiedID, uint? creature2ID = null, uint? id = null, string name = null, DecorCategory? category = null, bool particleAlt = false, uint week = 0)
        {
            if (betaMode)
            {
                category = DecorCategory.Beta;
                name = "(BETA) " + name;
            }
            var entry = Table.CopyEntry(decorInfo.GetEntry(copiedID));
            if (category != null)
                entry.Values[1].SetValue((uint)category); // housingDecorTypeId

            entry.Values[3].SetValue(language.AddEntry(name ?? hookAsset)); // localizedTextIdName
            entry.Values[5].SetValue(AddHookAsset(hookAsset)); // hookAssetId
            if (week == 0)
            {
                week = 99;
            }
            if (week >= 100)
            {
                week += 1; // skip the 1 silver, when we get there.
            }
            entry.Values[6].SetValue(week); // cost
            entry.Values[7].SetValue(1u); // costCurrencyTypeId
            if (creature2ID != null)
                entry.Values[8].SetValue(creature2ID); // creature2IdActiveProp
            entry.Values[9].SetValue(0u); // prerequisiteIdUnlock
            entry.Values[12].SetValue(""); // altPreviewAsset
            if (particleAlt)
            {
                entry.Values[13].SetValue("Art\\FX\\Housing\\Decor_FXPlacer\\Decor_FXPlacer_000.m3"); // altEditAsset
            }
            else
            {
                entry.Values[13].SetValue("");
            }
            entry.Values[14].SetValue(0.2f); // min scale
            entry.Values[15].SetValue(8f); // max scale

            entry.Values.RemoveAt(0); // ID gets re-added

            decorInfo.AddEntry(entry, id);
        }

        static void AddNPCDecor(uint copiedID, uint? creature2ID = null,  uint? id = null, string altPreviewAsset = null, string name = null, uint week = 0)
        {
            DecorCategory category;
            if (betaMode)
            {
                category = DecorCategory.Beta;
                name = "(BETA) " + name;
            } 
            else
            {
                category = DecorCategory.CharactersCreatures; // always use for NPC decor
            }

            var entry = Table.CopyEntry(decorInfo.GetEntry(copiedID));
            entry.Values[3].SetValue(language.AddEntry(name)); // localizedTextIdName
            entry.Values[1].SetValue((uint)category); // housingDecorTypeId
            entry.Values[4].SetValue(0u); // flags

            uint hookAsset = 2152; // seems to be the same for all NPC decor
            entry.Values[5].SetValue(hookAsset); // hookAssetId
            if (week == 0)
            {
                week = 99;
            }
            if (week >= 100)
            {
                week += 1; // skip the 1 silver, when we get there.
            }
            entry.Values[6].SetValue(week); // cost
            entry.Values[7].SetValue(1u); // costCurrencyTypeId
            if (creature2ID != null)
            {
                entry.Values[8].SetValue(creature2ID); // creature2IdActiveProp
            } 
            else
            {
                throw new ArgumentException("Creature2 ID must not be null!");
            }
                
            entry.Values[9].SetValue(0u); // prerequisiteIdUnlock
            entry.Values[12].SetValue(altPreviewAsset); // altPreviewAsset
            entry.Values[13].SetValue("Art\\FX\\Housing\\Decor_FXPlacer\\Decor_FXPlacer_000.m3"); // altEditAsset - always use for NPC decor
            entry.Values[14].SetValue(0.2f); // min scale
            entry.Values[15].SetValue(8f); // max scale

            entry.Values.RemoveAt(0); // ID gets re-added

            decorInfo.AddEntry(entry, id);
        }

        static uint AddDisplayInfoEntry(uint copiedID, uint id, string modelAssetPath, string textureAssetPath1, string normalAssetPath1, 
            string textureAssetPath2 = null, string normalAssetPath2 = null, string textureAssetPath3 = null, string normalAssetPath3 = null,
            uint? raceId = null, uint? sex = null, uint? itemDisplayId00 = null, uint? itemDisplayId01 = null, uint? itemDisplayId02 = null, 
            uint? itemDisplayId03 = null, uint? itemDisplayId04 = null, uint? itemDisplayId05 = null, uint? itemDisplayId06 = null, uint? itemDisplayId07 = null)
        {
            var entry = Table.CopyEntry(creature2DisplayInfo.GetEntry(copiedID));

            entry.Values[2].SetValue(modelAssetPath); // assetPath
            entry.Values[3].SetValue(textureAssetPath1); // assetTexture00
            entry.Values[4].SetValue(normalAssetPath1); // assetTexture01
            if (textureAssetPath2 != null)
                entry.Values[5].SetValue(textureAssetPath2); // assetTexture02
            if (normalAssetPath2 != null)
                entry.Values[6].SetValue(normalAssetPath2); // assetTexture03
            if (textureAssetPath3 != null)
                entry.Values[7].SetValue(textureAssetPath3); // assetTexture04
            if (normalAssetPath3 != null)
                entry.Values[8].SetValue(normalAssetPath3); // assetTexture05
            if (raceId != null)
                entry.Values[38].SetValue(raceId); // raceId
            if (sex != null)
                entry.Values[39].SetValue(sex); // sex
            if (itemDisplayId00 != null)
                entry.Values[40].SetValue(itemDisplayId00); // itemDisplayId00
            if (itemDisplayId01 != null)
                entry.Values[41].SetValue(itemDisplayId01); // itemDisplayId01
            if (itemDisplayId02 != null)
                entry.Values[42].SetValue(itemDisplayId02); // itemDisplayId02
            if (itemDisplayId03 != null)
                entry.Values[43].SetValue(itemDisplayId03); // itemDisplayId03
            if (itemDisplayId04 != null)
                entry.Values[44].SetValue(itemDisplayId04); // itemDisplayId04
            if (itemDisplayId05 != null)
                entry.Values[45].SetValue(itemDisplayId05); // itemDisplayId05
            if (itemDisplayId06 != null)
                entry.Values[46].SetValue(itemDisplayId06); // itemDisplayId06
            if (itemDisplayId07 != null)
                entry.Values[47].SetValue(itemDisplayId07); // itemDisplayId07

            entry.Values.RemoveAt(0); // ID gets re-added
            return creature2DisplayInfo.AddEntry(entry, id);
        }
        static uint AddDisplayGroupEntry(uint copiedID, uint id, uint displayGroupId, uint displayInfoId, uint? weight = null)
        {
            var entry = Table.CopyEntry(creature2DisplayGroupEntry.GetEntry(copiedID));

            entry.Values[1].SetValue(displayGroupId); // creature2DisplayGroupId
            entry.Values[2].SetValue(displayInfoId); // creature2DisplayInfoId
            if (weight != null)
                entry.Values[3].SetValue(weight); // weight

            entry.Values.RemoveAt(0); // ID gets re-added
            return creature2DisplayGroupEntry.AddEntry(entry, id);
        }
        static uint AddCreature(uint copiedID, uint id, string description = null, string name = null, uint? displayGroupId = null, uint? outfitGroupId = null, 
            uint? equipItemDisplayId = null, uint? spellVisualId = null, uint? animationId = null, float? modelScale = null, uint? flags = null, uint? factionId = null)
        {
            var entry = Table.CopyEntry(creature2.GetEntry(copiedID));

            if (name != null)
                entry.Values[3].SetValue(language.AddEntry(name)); // localizedTextIdName
            if (description != null)
                entry.Values[2].SetValue(description); // description
            if (displayGroupId != null)
                entry.Values[10].SetValue(displayGroupId); // displayGroupId
            if (outfitGroupId != null)
                entry.Values[11].SetValue(outfitGroupId); // outfitGroupId
            if (equipItemDisplayId != null)
                entry.Values[105].SetValue(equipItemDisplayId); // itemIdDisplayItemRight
            if (spellVisualId != null)
                entry.Values[150].SetValue(spellVisualId); // spell4VisualGroupIdAttached
            if (animationId != null)
                entry.Values[156].SetValue(animationId); // modelSequenceIdAnimationPriority00
            if (modelScale != null)
                entry.Values[13].SetValue(modelScale); // modelScale
            if (flags != null)
                entry.Values[83].SetValue(flags); // flags
            if (factionId != null)
                entry.Values[99].SetValue(factionId); // factionId

            entry.Values.RemoveAt(0); // ID gets re-added
            return creature2.AddEntry(entry, id);
        }
        static uint AddCreatureOutfitInfo(uint copiedID, uint id, uint? itemDisplayId00 = null, uint? itemDisplayId01 = null, uint? itemDisplayId02 = null, uint? itemDisplayId03 = null,
            uint? itemDisplayId04 = null, uint? itemDisplayId05 = null, uint? itemColorSetId00 = null, uint? itemColorSetId01 = null, uint? itemColorSetId02 = null,
            uint? itemColorSetId03 = null, uint? itemColorSetId04 = null, uint? itemColorSetId05 = null)
        {
            var entry = Table.CopyEntry(creature2OutfitInfo.GetEntry(copiedID));

            if (itemDisplayId00 != null)
                entry.Values[1].SetValue(itemDisplayId00); // itemDisplayId00
            if (itemDisplayId01 != null)
                entry.Values[2].SetValue(itemDisplayId01); // itemDisplayId01
            if (itemDisplayId02 != null)
                entry.Values[3].SetValue(itemDisplayId02); // itemDisplayId02
            if (itemDisplayId03 != null)
                entry.Values[4].SetValue(itemDisplayId03); // itemDisplayId03
            if (itemDisplayId04 != null)
                entry.Values[5].SetValue(itemDisplayId04); // itemDisplayId04
            if (itemDisplayId05 != null)
                entry.Values[6].SetValue(itemDisplayId05); // itemDisplayId05
            if (itemColorSetId00 != null)
                entry.Values[7].SetValue(itemColorSetId00); // itemColorSetId00
            if (itemColorSetId01 != null)
                entry.Values[8].SetValue(itemColorSetId01); // itemColorSetId01
            if (itemColorSetId02 != null)
                entry.Values[9].SetValue(itemColorSetId02); // itemColorSetId02
            if (itemColorSetId03 != null)
                entry.Values[10].SetValue(itemColorSetId03); // itemColorSetId03
            if (itemColorSetId04 != null)
                entry.Values[11].SetValue(itemColorSetId04); // itemColorSetId04
            if (itemColorSetId05 != null)
                entry.Values[12].SetValue(itemColorSetId05); // itemColorSetId05

            entry.Values.RemoveAt(0); // ID gets re-added
            return creature2OutfitInfo.AddEntry(entry, id);
        }
        static uint AddCreatureOutfitGroupEntry(uint copiedID, uint id, uint? creature2OutfitGroupId = null, uint? creature2OutfitInfoId = null, uint? weight = null)
        {
            var entry = Table.CopyEntry(creature2OutfitGroupEntry.GetEntry(copiedID));

            if (creature2OutfitGroupId != null)
                entry.Values[1].SetValue(creature2OutfitGroupId); // creature2OutfitGroupId
            if (creature2OutfitInfoId != null)
                entry.Values[2].SetValue(creature2OutfitInfoId); // creature2OutfitInfoId
            if (weight != null)
                entry.Values[3].SetValue(weight); // weight

            entry.Values.RemoveAt(0); // ID gets re-added
            return creature2OutfitGroupEntry.AddEntry(entry, id);
        }

        static void AddColorShift(string colorShiftAsset, uint? id, string name = null)
        {
            var entry = new GameTableEntry();
            entry.AddString(colorShiftAsset); // Asset path
            if (name != null)
            {
                entry.AddInteger(language.AddEntry(name)); // localizedtextid
            }
            else
            {
                entry.AddInteger(language.AddEntry(colorShiftAsset)); // localizedtextid
            }
            entry.AddString("BasicSprites:Grey"); // preview swatch icon

            colorShift.AddEntry(entry, id);
        }

        static void AddEmote(uint animationID, string command, string command2 = null, uint? id = null)
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

            emotes.AddEntry(entry, id);
        }

        static void AddWallpaper(uint? id, string name, uint? cost, uint flags, uint unlockIndex, uint worldSkyID, uint soundZoneKitID, uint worldLayerID1, uint worldLayerID2)
        {
            if (betaMode)
            {
                name = "(BETA) " + name;
            }
            var entry = new GameTableEntry();
            entry.AddInteger(language.AddEntry(name)); // localizedTextID
            entry.AddInteger(cost ?? 99); // cost
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

            wallpaperInfo.AddEntry(entry, id);
        }

        static void AddGroundOption(string name, uint worldLayerPrimary, uint worldLayerSecondary, uint? id = null, uint? cost = null)
        {
            GameTableEntry layer = worldLayer.GetEntry(worldLayerPrimary);
            if (layer == null)
            {
                throw new ArgumentException("Worldlayer does not exist in table yet!");
            }
            layer = worldLayer.GetEntry(worldLayerSecondary);
            if (layer == null)
            {
                throw new ArgumentException("Worldlayer does not exist in table yet!");
            }
            AddWallpaper(id, name, cost, 512, 270, 1, 0, worldLayerSecondary, worldLayerPrimary);
        }

        static void Overwrite(GameTableValue val, object overwrite)
        {
            if (overwrite != null)
            {
                val.SetValue(overwrite);
            }
        }

        static void AddWorldLayer(uint id, string name, uint copiedID, float? heightScale, float? heightOffset, float? parallaxScale, float? parallaxOffset, float? metersPerTile, string colorTexture, string normalTexture, uint? averageColor, uint? materialType, uint? worldClutterID0, uint? worldClutterID1, uint? worldClutterID2, uint? worldClutterID3, float? specularPower, uint? emissiveGlow, float? scrollSpeed0, float? scrollSpeed1)
        {
            var copied = worldLayer.GetEntry(copiedID);
            var entry = Table.CopyEntry(copied);
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

            worldLayer.AddEntry(entry, id);
        }

        static void AddCustomizationParameter(uint? id, string name, float sclX, float sclY, float sclZ, float rotX, float rotY, float rotZ, float posX, float posY, float posZ)
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

            customizationParameter.AddEntry(entry, id);
        }

        static void AddCustomizationParameterMap(uint? id, uint raceID, uint genderEnum, uint modelBoneID, uint customizationParameterID, uint dataOrder, uint flags)
        {
            var entry = new GameTableEntry();

            entry.AddInteger(raceID);
            entry.AddInteger(genderEnum);
            entry.AddInteger(modelBoneID);
            entry.AddInteger(customizationParameterID);
            entry.AddInteger(dataOrder);
            entry.AddInteger(flags);

            customizationParameterMap.AddEntry(entry, id);
        }

        /*
        private GameTableEntry MakeDyeColorRamp(uint rampIndex, uint flags, uint id)
        {
            GameTableEntry e = dyeColorRamp.CopyEntry(170u); //Copies aurin F brown skin color

            uint newId = 0u;
            if (id <= 0u)
            {
                uint maxId = dyeColorRamp.GetMaxID();
                newId = maxId++;
            }
            else
            {
                newId = id;
            }

            e.Values[1].SetValue(flags);
            e.Values[3].SetValue(rampIndex);
            e.Values.RemoveAt(0);
            dyeColorRamp.AddEntry(e, newId);

            return e;
        }

        private GameTableEntry MakeItemColorSet(GameTableEntry dyeColorRampId, uint id)
        {
            GameTableEntry e = itemColorSet.CopyEntry(24u); //Copies aurin F brown skin color

            uint newId = 0u;
            if (id <= 0u)
            {
                uint maxId = dyeColorRamp.GetMaxID();
                newId = maxId++;
            }
            else
            {
                newId = id;
            }

            e.Values[1].SetValue(dyeColorRampId);
            e.Values.RemoveAt(0);
            dyeColorRamp.AddEntry(e, newId);

            return e;
        }
        */
    }
}
