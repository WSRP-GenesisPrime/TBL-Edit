using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WildStar.GameTable;

namespace WildStar.TableTool
{
    class CharacterCustomizationHandler
    {
        protected Table characterCustomizationTable = null;
        protected Table characterCustomizationLabelTable = null;
        protected Table characterCustomizationSelectionTable = null;

        protected Dictionary<(uint, uint), DataRow> selectionMap = null;
        protected Dictionary<(uint, uint), List<DataRow>> customizationsByRaceGender = null;

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
            selectionMap = new Dictionary<(uint, uint), DataRow>();
            foreach (DataRow entry in characterCustomizationSelectionTable.table.Rows)
            {
                uint label = (uint)entry[1];
                uint value = (uint)entry[2];
                selectionMap.TryAdd((label, value), entry);
            }
        }

        public void buildCustomizationsByRaceGenderMap()
        {
            customizationsByRaceGender = new Dictionary<(uint, uint), List<DataRow>>();
            foreach (DataRow entry in characterCustomizationTable.table.Rows)
            {
                uint race = (uint)entry[1];
                uint gender = (uint)entry[2];
                if (!customizationsByRaceGender.TryGetValue((race, gender), out List<DataRow> entries))
                {
                    entries = new List<DataRow>();
                    customizationsByRaceGender.Add((race, gender), entries);
                }
                entries.Add(entry);
            }
        }

        public void AddSelectionEntry(uint label, uint value)
        {
            if (!selectionMap.ContainsKey((label, value)))
            {
                DataRow entry = characterCustomizationSelectionTable.NewEntry(characterCustomizationSelectionTable.nextEntry);
                entry[1] = label;
                entry[2] = value;
                entry[3] = 644245094400000ul;
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

        public void MoveEntriesToLabel(IEnumerable<DataRow> list, uint oldLabel, uint newLabel)
        {
            bool found = true;
            while (found)
            {
                found = false;

                uint matchedLabelValue = 0;

                foreach (var entry in list)
                {
                    uint label1 = (uint)entry[6];
                    uint label2 = (uint)entry[7];
                    uint labelValue1 = (uint)entry[8];
                    uint labelValue2 = (uint)entry[9];

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

        private void MoveEntriesToLabel(IEnumerable<DataRow> list, uint matchedLabel, uint matchedLabelValue, uint newLabel)
        {
            // Find free labelValue
            HashSet<uint> usedValues = new HashSet<uint>();
            foreach (var entry in list)
            {
                if ((uint)entry[6] == newLabel)
                {
                    usedValues.Add((uint)entry[8]);
                }
                if ((uint)entry[7] == newLabel)
                {
                    usedValues.Add((uint)entry[9]);
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
                uint label1 = (uint)entry[6];
                uint label2 = (uint)entry[7];
                uint labelValue1 = (uint)entry[8];
                uint labelValue2 = (uint)entry[9];

                if (label1 == matchedLabel)
                {
                    if (labelValue1 == matchedLabelValue)
                    {
                        entry[6] = newLabel;
                        entry[8] = newValue;
                    }
                }
                else if (label2 == matchedLabel)
                {
                    if (labelValue2 == matchedLabelValue)
                    {
                        entry[7] = newLabel;
                        entry[9] = newValue;
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
                if ((uint)entry[6] == label)
                {
                    usedValues.Add((uint)entry[8]);
                }
                if ((uint)entry[7] == label)
                {
                    usedValues.Add((uint)entry[9]);
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
                if ((uint)entry[6] == label)
                {
                    if ((uint)entry[8] == labelValue) return false;
                }
                if ((uint)entry[7] == label)
                {
                    if ((uint)entry[9] == labelValue) return false;
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
                uint label1 = (uint)entry[6];
                uint label2 = (uint)entry[7];
                uint labelValue1 = (uint)entry[8];
                uint labelValue2 = (uint)entry[9];
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
            DataRow entryToCopy = itemDisplay.GetEntry(itemDisplayIDToCopy);
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
                uint label1 = (uint)entry[6];
                uint label2 = (uint)entry[7];
                uint labelValue1 = (uint)entry[8];
                uint labelValue2 = (uint)entry[9];
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

        private DataRow MakeColourOption(Table itemDisplay, DataRow entryToCopy, uint colourID, int offset, uint newLabelValue, uint displayID)
        {
            uint copyID = (uint)entryToCopy[4];
            DataRow ide = itemDisplay.CopyEntry(copyID, displayID);
            ide[38] = colourID;

            return MakeCustomizationOptionFromDisplayID(displayID, entryToCopy, offset, newLabelValue);
        }

        private uint MakeBodyTypeItemDisplay(Table itemDisplay, DataRow entryToCopy, uint modelPoseID, float modelPoseBlend, uint displayID)
        {
            DataRow ide = itemDisplay.CopyEntry(entryToCopy, displayID);
            ide[40] = modelPoseID;
            ide[41] = modelPoseBlend;

            return displayID;
        }

        private DataRow MakeCustomizationOptionFromDisplayID(uint newDisplayID, DataRow entryToCopy, int offset, uint newLabelValue)
        {
            DataRow e = characterCustomizationTable.CopyEntry(entryToCopy, characterCustomizationTable.nextEntry);
            e[8 + offset] = newLabelValue;
            e[4] = newDisplayID;
            return e;
        }
    }
}
