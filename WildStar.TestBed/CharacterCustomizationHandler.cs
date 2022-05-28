using System;
using System.Collections.Generic;
using System.Linq;
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
                characterCustomizationSelectionTable.AddEntry(entry, characterCustomizationSelectionTable.nextEntry);
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

        public bool IsLabelValueFree(uint race, uint gender, uint label, uint labelValue)
        {
            if (!customizationsByRaceGender.TryGetValue((race, gender), out var list))
            {
                throw new ArgumentOutOfRangeException();
            }
            foreach (var entry in list)
            {
                if (entry.Values[6].GetValue<uint>() == label)
                {
                    if (entry.Values[8].GetValue<uint>() == labelValue) return false;
                }
                if (entry.Values[7].GetValue<uint>() == label)
                {
                    if (entry.Values[9].GetValue<uint>() == labelValue) return false;
                }
            }
            return true;
        }

        public void AddColourOption(Table itemDisplay, uint race, uint gender, uint label, uint colourID, uint colourToCopy, uint newLabelValue = 0, uint displayIDStart = 0, uint displayIDEnd = 0)
        {
            if (!customizationsByRaceGender.TryGetValue((race, gender), out var list))
            {
                return;
            }
            if (newLabelValue == 0)
            {
                newLabelValue = GetFreeLabelValue(race, gender, label);
            }
            else
            {
                if(!IsLabelValueFree(race, gender, label, newLabelValue))
                {
                    throw new ArgumentException("Label-value isn't free!");
                }
                AddSelectionEntry(label, newLabelValue);
            }
            if(displayIDStart == 0)
            {
                displayIDStart = itemDisplay.GetMaxID() + 1;
            }

            for(int i = 0; i < list.Count; ++i)
            {
                var entry = list[i];
                uint label1 = entry.Values[6].GetValue<uint>();
                uint label2 = entry.Values[7].GetValue<uint>();
                uint labelValue1 = entry.Values[8].GetValue<uint>();
                uint labelValue2 = entry.Values[9].GetValue<uint>();
                int offset = 0;
                bool found = false;

                if (label1 == label)
                {
                    if (labelValue1 == colourToCopy)
                    {
                        offset = 0;
                        found = true;
                    }
                }
                else if (label2 == label)
                {
                    if (labelValue2 == colourToCopy)
                    {
                        offset = 1;
                        found = true;
                    }
                }

                if(found)
                {
                    if(itemDisplay.GetEntry(displayIDStart) != null)
                    {
                        throw new ArgumentException("DisplayID range isn't free!");
                    }
                    list.Add(MakeColourOption(itemDisplay, entry, colourID, offset, newLabelValue, displayIDStart));
                    displayIDStart += 1;
                }
            }
            if(displayIDStart != displayIDEnd && displayIDEnd != 0)
            {
                throw new ArgumentException("DisplayID range did not match actual number of added itemDisplays!");
            }
        }

        public void AddBodyType(Table itemDisplay, uint itemDisplayIDToCopy, uint modelPoseID, float modelPoseBlend, uint bodyTypeToCopy, uint newLabelValue = 0, uint newItemDisplayID = 0)
        {
            GameTableEntry entryToCopy = itemDisplay.GetEntry(itemDisplayIDToCopy);
            uint itemDisplayID = MakeBodyTypeItemDisplay(itemDisplay, entryToCopy, modelPoseID, modelPoseBlend, newItemDisplayID);
            uint[] races = { 1, 3, 4, 5, 12, 13, 16 };
            foreach (uint race in races)
            {
                for(uint gender = 0; gender < (race == 13? 1 : 2); gender ++)
                {
                    AddBodyType(race, gender, itemDisplayID, bodyTypeToCopy, newLabelValue);
                }
            }
        }

        public void AddBodyType(uint race, uint gender, uint itemDisplayID, uint bodyTypeToCopy, uint newLabelValue = 0)
        {
            const uint label = 25;
            if (!customizationsByRaceGender.TryGetValue((race, gender), out var list))
            {
                return;
            }
            if (newLabelValue == 0)
            {
                newLabelValue = GetFreeLabelValue(race, gender, label);
            }
            else
            {
                if (!IsLabelValueFree(race, gender, label, newLabelValue))
                {
                    throw new ArgumentException("Label-value isn't free!");
                }
                AddSelectionEntry(label, newLabelValue);
            }

            for (int i = 0; i < list.Count; ++i)
            {
                var entry = list[i];
                uint label1 = entry.Values[6].GetValue<uint>();
                uint label2 = entry.Values[7].GetValue<uint>();
                uint labelValue1 = entry.Values[8].GetValue<uint>();
                uint labelValue2 = entry.Values[9].GetValue<uint>();
                int offset = 0;
                bool found = false;

                if (label1 == label)
                {
                    if (labelValue1 == bodyTypeToCopy)
                    {
                        offset = 0;
                        found = true;
                    }
                }
                else if (label2 == label)
                {
                    if (labelValue2 == bodyTypeToCopy)
                    {
                        offset = 1;
                        found = true;
                    }
                }

                if (found)
                {
                    list.Add(MakeCustomizationOptionFromDisplayID(itemDisplayID, entry, offset, newLabelValue));
                    return;
                }
            }
        }

        private GameTableEntry MakeColourOption(Table itemDisplay, GameTableEntry entryToCopy, uint colourID, int offset, uint newLabelValue, uint displayID)
        {
            uint itemDisplayID = entryToCopy.Values[4].GetValue<uint>();
            GameTableEntry ide = itemDisplay.CopyEntry(itemDisplayID);
            ide.Values[38].SetValue(colourID);
            ide.Values.RemoveAt(0);
            uint newDisplayID = itemDisplay.AddEntry(ide, displayID);

            return MakeCustomizationOptionFromDisplayID(newDisplayID, entryToCopy, offset, newLabelValue);
        }

        private uint MakeBodyTypeItemDisplay(Table itemDisplay, GameTableEntry entryToCopy, uint modelPoseID, float modelPoseBlend, uint displayID)
        {
            GameTableEntry ide = Table.CopyEntry(entryToCopy);
            ide.Values[40].SetValue(modelPoseID);
            ide.Values[41].SetValue(modelPoseBlend);
            ide.Values.RemoveAt(0);
            uint newDisplayID = itemDisplay.AddEntry(ide, displayID);

            return newDisplayID;
        }

        private GameTableEntry MakeCustomizationOptionFromDisplayID(uint newDisplayID, GameTableEntry entryToCopy, int offset, uint newLabelValue)
        {
            GameTableEntry e = Table.CopyEntry(entryToCopy);
            e.Values[8 + offset].SetValue(newLabelValue);
            e.Values[4].SetValue(newDisplayID);
            e.Values.RemoveAt(0);
            characterCustomizationTable.AddEntry(e, characterCustomizationTable.nextEntry);
            return e;
        }
    }
}
