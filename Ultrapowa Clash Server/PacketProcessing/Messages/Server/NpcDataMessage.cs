﻿using System.Collections.Generic;
using System.Text;
using Ionic.Zlib;
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing
{
    //Packet 24133
    internal class NpcDataMessage : Message
    {
        public NpcDataMessage(Client client, Level level, AttackNpcMessage cnam) : base(client)
        {
            SetMessageType(24133);

            Player = level;

            JsonBase = ObjectManager.NpcLevels[cnam.LevelId - 0x01036640];

            LevelId = cnam.LevelId;
        }

        public string JsonBase { get; set; }

        public int LevelId { get; set; }

        public Level Player { get; set; }

        public override void Encode()
        {
            var data = new List<byte>();

            data.AddInt32(0);
            data.AddInt32(JsonBase.Length);
            data.AddRange(Encoding.ASCII.GetBytes(JsonBase));
            data.AddRange(Player.GetPlayerAvatar().Encode());
            data.AddInt32(0);
            data.AddInt32(LevelId);

            byte[] home2 =
            {
                /*0x00, 0x00, 0x03, 0x55, 0x25, 0x0F, 0x00, 0x00,*/ 0x78, 0x9C, 0x9D, 0x57, 0x4B, 0x6F, 0xE2,
                0x30, 0x10, 0xFE, 0x2F, 0x39, 0x67, 0xA5, 0xD8, 0x4E, 0xC2, 0xE3, 0xB8, 0x5D, 0xED, 0x69, 0x4F, 0xDB,
                0xD5, 0x5E, 0x2A, 0x64, 0x19, 0xE2, 0x42, 0xB4, 0xC6, 0x8E, 0x12, 0x07, 0x8A, 0xAA, 0xFE, 0xF7, 0x1D,
                0xC7, 0x03, 0x24, 0x88, 0xAA, 0x36, 0x8D, 0x0A, 0xF8, 0xF1, 0x8D, 0xE7, 0xF1, 0xCD, 0x64, 0xFC, 0x9E,
                0x08, 0x5D, 0xB5, 0xA6, 0xAE, 0xF8, 0x46, 0xD5, 0x52, 0xDB, 0x64, 0x69, 0xDB, 0x5E, 0xA6, 0x89, 0xD8,
                0xD8, 0xFA, 0x20, 0xB9, 0x12, 0x27, 0xD3, 0xC3, 0x64, 0x96, 0x26, 0xFE, 0x27, 0xEF, 0xAC, 0xB0, 0x32,
                0x59, 0xBE, 0x64, 0xE9, 0xE5, 0x59, 0xA5, 0xC9, 0xBA, 0xAF, 0x55, 0x55, 0xEB, 0x6D, 0x07, 0x2B, 0xEF,
                0x49, 0x25, 0xAC, 0x48, 0x96, 0x24, 0x73, 0x7F, 0x04, 0x90, 0x07, 0x95, 0x2C, 0x69, 0x9A, 0xBC, 0xC1,
                0x27, 0x0C, 0x4F, 0xF0, 0x05, 0xF2, 0x76, 0xCD, 0x20, 0xB6, 0x95, 0xDB, 0x64, 0xF9, 0x2A, 0x54, 0x27,
                0x3F, 0xD2, 0x29, 0x32, 0x9F, 0x22, 0xB3, 0x01, 0x49, 0xCA, 0x3B, 0x48, 0xF7, 0xBB, 0xE3, 0xB6, 0xDE,
                0x83, 0x62, 0xD9, 0xAD, 0x98, 0x0C, 0xC5, 0x64, 0x5E, 0x4C, 0xE9, 0xC5, 0x2C, 0xD2, 0xA4, 0xD7, 0xB5,
                0x75, 0xFA, 0xBE, 0xE4, 0xB8, 0x8F, 0x66, 0x2B, 0x30, 0xA5, 0xB3, 0xA6, 0x15, 0x5B, 0xC9, 0xED, 0xA9,
                0x91, 0x03, 0xEA, 0x2B, 0x45, 0x49, 0x31, 0x39, 0x81, 0xCC, 0x83, 0x4D, 0x24, 0xF9, 0x54, 0xB7, 0x62,
                0x40, 0x32, 0x1A, 0xE0, 0x9C, 0xF9, 0x14, 0xC9, 0xBC, 0x55, 0x2C, 0x5A, 0x5B, 0x44, 0xD2, 0x3C, 0xE0,
                0x4C, 0x8A, 0x48, 0x32, 0xB1, 0xB3, 0x88, 0x0D, 0x08, 0x43, 0x31, 0xF0, 0xBD, 0x31, 0xBA, 0xB3, 0xDC,
                0x3A, 0xCD, 0x67, 0xD9, 0x65, 0xC8, 0xA5, 0xAE, 0x60, 0x2A, 0x67, 0x05, 0xCB, 0x19, 0x2D, 0xE8, 0xD8,
                0x39, 0x41, 0x8A, 0x9E, 0x4D, 0x2C, 0x3C, 0x92, 0x7A, 0xE4, 0x3D, 0xE6, 0xDC, 0x22, 0xCB, 0x89, 0x89,
                0x67, 0xB2, 0xDC, 0xE7, 0x9C, 0xE3, 0x0F, 0x6F, 0x5A, 0x03, 0xBA, 0xBE, 0xFB, 0x01, 0x52, 0xE6, 0xE3,
                0x0B, 0x0A, 0x2E, 0xBC, 0xD4, 0xFC, 0x0E, 0x05, 0xD9, 0x43, 0x0C, 0xBC, 0x4D, 0x15, 0x64, 0xC3, 0x6C,
                0x1A, 0x06, 0x90, 0x6C, 0xD6, 0x90, 0xBE, 0x1B, 0x25, 0xC7, 0x69, 0x3A, 0x1F, 0x24, 0xCC, 0x06, 0x64,
                0x71, 0xA1, 0x91, 0x32, 0xC6, 0xF2, 0x7D, 0xAF, 0x6C, 0xDD, 0xA8, 0x13, 0x3F, 0xC8, 0x16, 0xA6, 0xAF,
                0xA7, 0x8E, 0x31, 0x04, 0x03, 0xB3, 0x08, 0x03, 0x15, 0x63, 0x1F, 0xE4, 0x61, 0x98, 0x72, 0x7C, 0x10,
                0x9B, 0x85, 0x81, 0xB2, 0x71, 0xD9, 0x08, 0x3C, 0xC8, 0x2B, 0xE7, 0x4E, 0x38, 0x79, 0x82, 0x87, 0xBB,
                0xA1, 0x8C, 0x39, 0x87, 0x4D, 0xE8, 0x95, 0x45, 0x79, 0xCE, 0x1B, 0xC4, 0xCA, 0xA8, 0x93, 0xBC, 0xBB,
                0x59, 0x94, 0x1B, 0x1E, 0x89, 0xEB, 0xFC, 0x01, 0x8B, 0x8A, 0x0B, 0x5B, 0x43, 0x30, 0x9E, 0xE2, 0xB9,
                0xB7, 0x27, 0x90, 0xA8, 0x74, 0x6C, 0x0F, 0x89, 0xC1, 0x90, 0xEC, 0x52, 0x92, 0x43, 0x40, 0xBE, 0x6C,
                0x44, 0x71, 0x1B, 0x8B, 0xA9, 0x4F, 0x59, 0x16, 0xA8, 0x9C, 0x07, 0x79, 0x9A, 0xB2, 0x22, 0x86, 0xA6,
                0xDE, 0x71, 0x51, 0x31, 0x65, 0x58, 0x3F, 0x03, 0xD3, 0x01, 0x41, 0x79, 0x54, 0x29, 0x41, 0x2F, 0xE4,
                0x51, 0x89, 0xE7, 0x41, 0xCC, 0xC7, 0x35, 0xCC, 0x0B, 0x04, 0x2B, 0x24, 0xF2, 0x27, 0x8C, 0xA7, 0x08,
                0x62, 0x24, 0x86, 0xDC, 0x64, 0xD2, 0x6F, 0xB0, 0x30, 0x93, 0x10, 0x84, 0x7E, 0x08, 0x34, 0x89, 0x8D,
                0x1D, 0x1E, 0x98, 0x12, 0x08, 0x42, 0xDA, 0x85, 0xD1, 0xC1, 0x69, 0x75, 0x4D, 0x89, 0xC0, 0x7C, 0x45,
                0x10, 0x3A, 0x3C, 0x30, 0xC7, 0x7D, 0xBD, 0x67, 0xE5, 0xE5, 0xBD, 0x1D, 0x72, 0x10, 0x19, 0xBF, 0xFB,
                0x02, 0x2B, 0xDD, 0x19, 0x94, 0x3F, 0xF2, 0x66, 0x89, 0x4B, 0xBF, 0x69, 0x8B, 0x17, 0x07, 0x2A, 0x63,
                0xD8, 0x8A, 0x89, 0x7E, 0x76, 0x44, 0x54, 0xE5, 0xA2, 0xF3, 0x98, 0x32, 0x74, 0x8E, 0xED, 0x3C, 0xE6,
                0x45, 0xC1, 0xB0, 0xB0, 0x7A, 0xCC, 0x7D, 0xED, 0xE8, 0xAD, 0x76, 0x8B, 0x71, 0x98, 0xC8, 0x67, 0x26,
                0x41, 0x83, 0x53, 0xC9, 0x8D, 0x71, 0xCD, 0xCD, 0x6A, 0x68, 0x7D, 0x1A, 0x71, 0xD4, 0x7F, 0x45, 0xDB,
                0xB9, 0x06, 0xAD, 0x83, 0x15, 0x5D, 0x75, 0x3F, 0x5B, 0xB3, 0xFF, 0x25, 0x3A, 0xFB, 0xDB, 0xAF, 0x02,
                0xF7, 0xCB, 0x45, 0x71, 0xD9, 0xFC, 0x2C, 0x25, 0x74, 0x73, 0xDF, 0x08, 0x2B, 0x67, 0x19, 0x65, 0xAC,
                0x20, 0xD7, 0x96, 0xE9, 0x49, 0x49, 0xD1, 0x3E, 0x99, 0x5E, 0x5B, 0x77, 0x18, 0x98, 0xEC, 0xDA, 0x2A,
                0x6E, 0x0D, 0xDF, 0xCA, 0xFD, 0xDA, 0xBC, 0x71, 0xB8, 0x44, 0x35, 0xCE, 0xDD, 0x34, 0x9F, 0x53, 0x5C,
                0xAC, 0xF5, 0x79, 0xB1, 0x91, 0x6D, 0x6D, 0x7C, 0x4F, 0x5B, 0x12, 0xF0, 0x08, 0x74, 0xBA, 0x46, 0x55,
                0xE6, 0xA8, 0x51, 0x57, 0x2D, 0x8F, 0xCF, 0x3B, 0xD3, 0x7C, 0x1F, 0xDD, 0xA2, 0x28, 0xDC, 0xAC, 0x58,
                0x4A, 0x87, 0x7F, 0x9A, 0x92, 0x94, 0x5E, 0xEF, 0x5B, 0x30, 0x2A, 0x46, 0xA3, 0x9B, 0xE7, 0x2A, 0xEE,
                0x4F, 0x2B, 0x9A, 0x6E, 0x7A, 0x55, 0xBB, 0xDD, 0xF2, 0x03, 0xFD, 0x45, 0xD2, 0x1C, 0x25, 0x7F, 0x2A,
                0x37, 0xEC, 0x59, 0xB9, 0x8B, 0x22, 0x34, 0xF1, 0xE0, 0xAD, 0x6D, 0x2F, 0x79, 0x2B, 0xF4, 0x3F, 0xBC,
                0x3D, 0xC2, 0xA4, 0x50, 0xAA, 0x16, 0x7A, 0x03, 0xD7, 0x4A, 0x79, 0x90, 0xCA, 0xBF, 0x22, 0x47, 0x9B,
                0xBB, 0x5D, 0xFF, 0xFA, 0xAA, 0xE4, 0x75, 0x3F, 0x28, 0xD9, 0xF1, 0x4E, 0x4A, 0xED, 0xAA, 0x0E, 0x44,
                0x49, 0x56, 0xD0, 0x64, 0xEF, 0x4D, 0xE5, 0xB6, 0x1A, 0x17, 0x3C, 0xEC, 0xC4, 0x8F, 0xA2, 0xE5, 0xB6,
                0x87, 0xAE, 0xB9, 0x86, 0x31, 0x02, 0x32, 0x3F, 0xBD, 0x16, 0x9D, 0xBC, 0xEC, 0xDB, 0x49, 0xD5, 0x70,
                0xD3, 0x48, 0xED, 0xA2, 0x8C, 0x73, 0x6B, 0x88, 0x04, 0x5E, 0x73, 0xF9, 0x20, 0x7F, 0x10, 0xCD, 0x65,
                0x7B, 0x05, 0x7E, 0xFC, 0x07, 0xCA, 0xF2, 0x7C, 0x89
            };
            Debugger.WriteLine(ZlibStream.UncompressString(home2), null, 5);
            ;

            SetData(data.ToArray());
        }
    }
}