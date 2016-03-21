﻿using System;
using System.Collections.Generic;
using System.Text;
using UCS.Helpers;
using UCS.Logic;
using Ionic.Zlib;
using System.IO;
using Sodium;
using System.Linq;

namespace UCS.PacketProcessing
{
    //Packet 24101
    internal class OwnHomeDataMessage : Message
    {
        public OwnHomeDataMessage(Client client, Level level) : base(client)
        {
            SetMessageType(24101);
            Player = level;
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public Level Player { get; set; }

        public override void Encode()
        {
            var Avatar = Player.GetPlayerAvatar();

            var data = new List<byte>();

            var home = new ClientHome(Avatar.GetId());

            home.SetShieldDurationSeconds(Avatar.RemainingShieldTime);

            home.SetHomeJSON(Player.SaveToJSON());

            data.AddInt32(0);

            data.AddInt32(-1);

            data.AddInt32((int)Player.GetTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

            data.AddRange(home.Encode());

            data.AddRange(Avatar.Encode());
            Encrypt8(data.ToArray());
            //Encrypt8(Utilities.HexToBinary("0000004fffffffff56effe9b000000000000002300f14d5b0003f3cf0000070800042c0f000004b00000003c01000003a27f110000789ca598c96edb301086df45671510172df6b12d7aeaa92d7a290a81b6984428231a5ab220c8bb7728d2318748db896a1d6c93e2c7e1cc3f43514f997e38b5777accf62ccfd4d08db6efdaa3e9f53067fb795c34b41ee7fe4eb7463dda051a8b3cf33fdb6956b3cef63f8afce5fa996787a5375d3f5c4fd0f394756a56c02edc0766e8bb6c5f16e103a03bb3021fb23d9779f6085fe239c7a3241ec5f028b18e62bb3c1bf5d4cefd2d18d4ec649d520a4ce198b2f37343eb32f4b3b3fc6702602506080c60af1bcf12e3e56594b1c75fba3bfbd8319a9521ca6770a23d80738f46c74e6c56447d268af3ba606ce5bd5039ac9ddbdbc5ccfdc93c86c05e8c7a15c156040bd313190d66f09551af881d8d5062825809a25c11250d5161848c1722258d51604619cb8a88487c51c56670e252126fd42b437a339cba36c4b58962425c89c0849d8f89cf4cc6690c89180c653795813dcabc42855f0a27ae057b94711458a21dd81f2c6894fb4ca937d9e145ea652e88662408af51e66b8e336a03c38b34d4dc8286e01851c72b213a23417889366f8a6b82f01a7532db5cbd7811ad4412fdc93082c53121e67c82f00a65be968b661343c4de909bea06979134b6253d0f0af589c28941491855ac0de29e82f395872a5afc4725e64d5c7ba85149185ea3d2bb8311758e232bbc4699b7836d528760b11d3477309c6e2294d1e00e5aaea40c2f52e97385b61286b76921e3e736a2ce5346197b941614860526aad8a1c4ca9132ea38ed89f9c670ae082f5226de52ce53c62e7629236e09f8094c16f1638b20da81452abd4879f5967d256520954ae25ab03c64d8ec8b37257ec290e8c97e1ba38ce342ccb8a4a4cb0af974d3f624bd4e85cf5a41cc17ac31d920c6a6a71f898a29752d98511668abfd933ee01c368feab41e07f3acd3471b7ec251f3a4ee87ef6a8486a76c829ea19b3e8df6f6b39ae62fbe171ebdeb975bbf6a77d67bc7196f4a5157e5e584f7c168357eb0cb30bb49c11477866d67db5eebdb837d68e1447e72cb65cc6dee6b673f9c3b4f7aec6de7f60351bac36776b4d674f67e08860efafeeb8d3dbd8f8ee40c8ee9ece52a727e39bcc3ff32faf7ea75817e0baef9cb2d1f83cb582e03ff1f74c2ec063cdc82cfae17dd8e6af8155e4840a332a657c35143ef9d36eb0b8df8e6e966b9ba32fa72ffa4d56407f8d210ab77e7bbc1f429b4b9427aafc6765e663bf6ca9cdb43f3414d40bb82f6f525c9d1c5b0bd32cab9196e394028c24b9356773dcc77038169f57819f6fc1b3e0af52a00000000000000002300f14d5b0000002300f14d5b00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffffffff00000000000000000000000000000000000000000000000442657a6fffffffff0000000100000000000001f4000001f4000004b00000003c000000000000000000000000000000000000000000000000000000000000000001000000dc6cf5eb4800ffffffff000000000000000000000001000000000000000000000006002dc6c1000003e8002dc6c2000003e8002dc6c300000000002dc6c4000003e8002dc6c5000003e8002dc6c60000000000000002002dc6c100000304002dc6c2000002ee0000000000000000000000000000000000000000000000000000000000000000000000000000000000000003015ef3c600000001015ef3c700000001015ef3c80000000100000000000000000000000000000000000000000000000000000000000000000000000000000153a8eaf1f800000153a8eaf1f800000153a9066938"));
            //Console.WriteLine(ByteArrayToString(data.ToArray()));
        }
    }
}