﻿using System;

namespace WildStar.TestBed.TextTable
{
    public class TextTableEntry
    {
        public uint Id { get; }
        public string Text { get; }

        /// <summary>
        /// 
        /// </summary>
        public TextTableEntry(uint id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
