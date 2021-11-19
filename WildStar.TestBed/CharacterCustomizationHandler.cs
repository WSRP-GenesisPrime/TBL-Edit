using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildStar.TestBed.GameTable;

namespace WildStar.TestBed
{
    class CharacterCustomizationHandler
    {
        protected Table characterCustomizationTable = null;
        protected Table characterCustomizationLabelTable = null;
        protected Table characterCustomizationSelectionTable = null;

        protected Dictionary<(uint, uint), GameTableEntry> selectionMap = null;
        protected Dictionary<(uint, uint), List<GameTableEntry>> customizationsByRaceGender = null;

        public void Load(Table characterCustomizationTable, Table characterCustomizationLabelTable, Table characterCustomizationSelectionTable)
        {
            this.characterCustomizationTable = characterCustomizationTable;
            this.characterCustomizationLabelTable = characterCustomizationLabelTable;
            this.characterCustomizationSelectionTable = characterCustomizationSelectionTable;

            buildSelectionMap();

            buildCustomizationsByRaceGenderMap();
        }

        public void buildSelectionMap()
        {
            selectionMap = new Dictionary<(uint, uint), GameTableEntry>();
            foreach (var entry in characterCustomizationSelectionTable.table.Entries)
            {
                uint label = entry.Values[1].GetValue<uint>();
                uint value = entry.Values[2].GetValue<uint>();
                selectionMap.TryAdd((label, value), entry);
            }
        }

        public void buildCustomizationsByRaceGenderMap()
        {
            customizationsByRaceGender = new Dictionary<(uint, uint), List<GameTableEntry>>();
            foreach (var entry in characterCustomizationTable.table.Entries)
            {
                uint race = entry.Values[1].GetValue<uint>();
                uint gender = entry.Values[2].GetValue<uint>();
                if (!customizationsByRaceGender.TryGetValue((race, gender), out List<GameTableEntry> entries))
                {
                    entries = new List<GameTableEntry>();
                    customizationsByRaceGender.Add((race, gender), entries);
                }
                entries.Add(entry);
            }
        }

        public void AddSelectionEntry(uint label, uint value)
        {
            if (!selectionMap.ContainsKey((label, value)))
            {
                GameTableEntry entry = new GameTableEntry();
                entry.AddInteger(label);
                entry.AddInteger(value);
                entry.Values.Add(new GameTableValue(GameTable.Static.DataType.Long));
                entry.Values[2].SetValue(644245094400000ul);
                characterCustomizationSelectionTable.AddEntry(entry);
                selectionMap.Add((label, value), entry);
            }
        }

        public void MoveEntriesToLabel(int raceID, int genderID, uint oldLabel, uint newLabel)
        {
            foreach (var list in customizationsByRaceGender.Where(l => (l.Key.Item1 == raceID || raceID < 0) && (l.Key.Item2 == genderID || genderID < 0)))
            {
                MoveEntriesToLabel(list.Value, oldLabel, newLabel);
            }
        }

        public void MoveEntriesToLabel(IEnumerable<GameTableEntry> list, uint oldLabel, uint newLabel)
        {
            bool found = true;
            while (found)
            {
                found = false;

                uint matchedLabelValue = 0;

                foreach (var entry in list)
                {
                    uint label1 = entry.Values[6].GetValue<uint>();
                    uint label2 = entry.Values[7].GetValue<uint>();
                    uint labelValue1 = entry.Values[8].GetValue<uint>();
                    uint labelValue2 = entry.Values[9].GetValue<uint>();

                    if (label1 == oldLabel)
                    {
                        matchedLabelValue = labelValue1;
                        found = true;
                        break;
                    }
                    else if (label2 == oldLabel)
                    {
                        matchedLabelValue = labelValue2;
                        found = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (found)
                {
                    MoveEntriesToLabel(list, oldLabel, matchedLabelValue, newLabel);
                }
            }
        }

        private void MoveEntriesToLabel(IEnumerable<GameTableEntry> list, uint matchedLabel, uint matchedLabelValue, uint newLabel)
        {
            // Find free labelValue
            HashSet<uint> usedValues = new HashSet<uint>();
            foreach (var entry in list)
            {
                if (entry.Values[6].GetValue<uint>() == newLabel)
                {
                    usedValues.Add(entry.Values[8].GetValue<uint>());
                }
                if (entry.Values[7].GetValue<uint>() == newLabel)
                {
                    usedValues.Add(entry.Values[9].GetValue<uint>());
                }
            }
            uint newValue = 0;
            while (usedValues.Contains(newValue))
            {
                newValue++;
            }
            AddSelectionEntry(newLabel, newValue);

            foreach (var entry in list)
            {
                uint label1 = entry.Values[6].GetValue<uint>();
                uint label2 = entry.Values[7].GetValue<uint>();
                uint labelValue1 = entry.Values[8].GetValue<uint>();
                uint labelValue2 = entry.Values[9].GetValue<uint>();

                if (label1 == matchedLabel)
                {
                    if (labelValue1 == matchedLabelValue)
                    {
                        entry.Values[6].SetValue(newLabel);
                        entry.Values[8].SetValue(newValue);
                    }
                }
                else if (label2 == matchedLabel)
                {
                    if (labelValue2 == matchedLabelValue)
                    {
                        entry.Values[7].SetValue(newLabel);
                        entry.Values[9].SetValue(newValue);
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        public uint GetFreeLabelValue(uint race, uint gender, uint label)
        {
            if (!customizationsByRaceGender.TryGetValue((race, gender), out var list))
            {
                throw new ArgumentOutOfRangeException();
            }
            // Find free labelValue
            HashSet<uint> usedValues = new HashSet<uint>();
            foreach (var entry in list)
            {
                if (entry.Values[6].GetValue<uint>() == label)
                {
                    usedValues.Add(entry.Values[8].GetValue<uint>());
                }
                if (entry.Values[7].GetValue<uint>() == label)
                {
                    usedValues.Add(entry.Values[9].GetValue<uint>());
                }
            }
            uint newValue = 1;
            while (usedValues.Contains(newValue))
            {
                newValue++;
            }
            AddSelectionEntry(label, newValue);
            return newValue;
        }

        public void AddColourOption(Table itemDisplay, uint race, uint gender, uint label, uint colourID, uint colourToCopy)
        {
            if (!customizationsByRaceGender.TryGetValue((race, gender), out var list))
            {
                return;
            }
            uint newValue = GetFreeLabelValue(race, gender, label);
            AddSelectionEntry(label, newValue);

            for(int i = 0; i < list.Count; ++i)
            {
                var entry = list[i];
                uint label1 = entry.Values[6].GetValue<uint>();
                uint label2 = entry.Values[7].GetValue<uint>();
                uint labelValue1 = entry.Values[8].GetValue<uint>();
                uint labelValue2 = entry.Values[9].GetValue<uint>();

                if (label1 == label)
                {
                    if (labelValue1 == colourToCopy)
                    {
                        list.Add(MakeColourOption(itemDisplay, entry, colourID, 0, newValue));
                    }
                }
                else if (label2 == label)
                {
                    if (labelValue2 == colourToCopy)
                    {
                        list.Add(MakeColourOption(itemDisplay, entry, colourID, 1, newValue));
                    }
                }
            }
        }

        private GameTableEntry MakeColourOption(Table itemDisplay, GameTableEntry entry, uint colourID, int offset, uint newLabelValue)
        {
            uint itemDisplayID = entry.Values[4].GetValue<uint>();
            GameTableEntry ide = itemDisplay.CopyEntry(itemDisplayID);
            ide.Values[38].SetValue(colourID);
            ide.Values.RemoveAt(0);
            uint newDisplayID = itemDisplay.AddEntry(ide, itemDisplay.nextEntry);
            
            GameTableEntry e = Table.CopyEntry(entry);
            e.Values[8 + offset].SetValue(newLabelValue);
            e.Values[4].SetValue(newDisplayID);
            e.Values.RemoveAt(0);
            characterCustomizationTable.AddEntry(e);
            return e;
        }
    }
}
