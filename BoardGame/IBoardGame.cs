﻿using System.Collections.Generic;

namespace BoardGameChardalasEmmanouil
{
    internal interface IBoardGame
    {
        IBoard Board { get; }
        List<IPawn> Pawns { get; }

        void SetupBoard(IEnumerable<string> settings);
        void Play();
        string Result();
    }
}