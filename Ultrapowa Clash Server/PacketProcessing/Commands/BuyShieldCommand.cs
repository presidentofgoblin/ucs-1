﻿using System.IO;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing
{
    //Commande 0x20A
    internal class BuyShieldCommand : Command
    {
        public BuyShieldCommand(BinaryReader br)
        {
            ShieldId = br.ReadUInt32WithEndian(); //= shieldId - 0x01312D00;
            Unknown1 = br.ReadUInt32WithEndian();
        }

        //00 00 02 0A 01 31 2D 02 00 00 2A EA

        public uint ShieldId { get; set; }

        public uint Unknown1 { get; set; }

        public override void Execute(Level level)
        {
        }
    }
}