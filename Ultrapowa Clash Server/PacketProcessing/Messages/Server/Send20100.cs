﻿using System.Collections.Generic;

namespace UCS.PacketProcessing
{
    //Packet 24303
    internal class Send20100 : Message
    {
        public Send20100(Client client) : base(client)
        {
            SetMessageType(20100);
        }

        public override void Encode()
        {
            var pack = new List<byte>();
            SetData(pack.ToArray());
        }
    }
}