using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WildStar.GameTable;
using WildStar.GameTable.IO;

namespace TableToolsTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReadWriteTables()
        {
            foreach (var name in Directory.GetFiles("../../../../Tbl/", "*.tbl", SearchOption.AllDirectories))
            {
                string tablename = Path.GetFileNameWithoutExtension(name);
                if (!knownBad.Contains(tablename))
                    TestSpecificFile(tablename);
            }
        }

        public static List<string> knownBad = new List<string>()
        {
            "ItemRuneSlotRandomization", // These contain no entries
            "MapZoneLevelBand",
            "MatchingMapPrerequisite",
            "PublicEventUnitPropertyModifier",
            "SoundReplace",
            "SoundReplaceDescription",
            "TradeskillTier",
            "WordFilterAlt"
        };

        //[Test]
        public void TestUsedFiles()
        {
            TestSpecificFile("CharacterCustomization");
            TestSpecificFile("CharacterCustomizationLabel");
            TestSpecificFile("CharacterCustomizationSelection");
            TestSpecificFile("ColorShift");
            TestSpecificFile("Creature2");
            TestSpecificFile("Creature2DisplayGroupEntry");
            TestSpecificFile("Creature2DisplayInfo");
            TestSpecificFile("Emotes");
            TestSpecificFile("HookAsset");
            TestSpecificFile("HousingDecorInfo");
            TestSpecificFile("HousingDecorType");
            TestSpecificFile("HousingPlugItem");
            TestSpecificFile("HousingWallpaperInfo");
            TestSpecificFile("Item2");
            TestSpecificFile("ItemColorSet");
            TestSpecificFile("ItemDisplay");
            TestSpecificFile("Spell4");
            TestSpecificFile("Spell4Base");
            TestSpecificFile("WorldLayer");
        }

        //[Test]
        public void TestStringFile()
        {
            TestSpecificFile("BindPoint");
            TestSpecificFile("AccountItemCooldownGroup");
        }

        public void TestSpecificFile(string tablename, string basepath = "../../../../")
        {
            GameTable table = new GameTable();
            table.Load(basepath + tablename + ".tbl");
            table.Save(basepath + tablename + ".tbl");
            FileStream original = new FileStream(basepath + "Tbl/" + tablename + ".tbl", FileMode.Open);
            FileStream written = new FileStream(basepath + "TblTest/" + tablename + ".tbl", FileMode.Open);
            areStreamsEqual(original, written);
        }

        public static void areStreamsEqual(Stream stream1, Stream stream2)
        {
            stream1.Position = 0;
            stream2.Position = 0;
            Assert.AreEqual(stream1.Length, stream2.Length);

            int position = 0;

            byte[] buf1 = new byte[10000];
            byte[] buf2 = new byte[10000];

            while (position < stream1.Length)
            {
                int amount = (int)stream1.Length - position;
                if (amount > 10000)
                {
                    amount = 10000;
                }

                stream1.Read(buf1, 0, amount);
                stream2.Read(buf2, 0, amount);
                position += amount;

                Assert.IsTrue(Enumerable.SequenceEqual(buf1, buf2));
            }
        }
    }
}