using System.Net;
using System.Net.Sockets;
using System.Globalization;

namespace WolHubServer.Classes
{
    public class WakeOnLan
    {
        public string MacAddress { get; set; }

        public WakeOnLan(string macAddress) { 
            MacAddress = macAddress;
        }


        private void WakeUp()
        {
            UdpClient udpClient = new UdpClient();

            //Habilitamos transmision UDP al cliente
            udpClient.EnableBroadcast = true;

            byte[] dgram = new byte[1024];

            //6 magic bytes
            for(int i=0; i<6; i++)
            {
                dgram[i] = 255;
            }

            //Convertir la dirección MAC a bytes
            byte[] address_bytes = new byte[6];
            for(int i=0; i<6; i++)
            {
                address_bytes[i] = byte.Parse(MacAddress.Substring(3 * i, 2), NumberStyles.HexNumber);
            }

            //Repetir la dirección MAC 16 veces en el datagram
            var macaddress_block = dgram.AsSpan(6, 16 * 6);
            for(int i=0; i < 16; i++)
            {
                address_bytes.CopyTo(macaddress_block.Slice(6 * i));
            }

            udpClient.Send(dgram, dgram.Length, new System.Net.IPEndPoint(IPAddress.Broadcast, 0));
            udpClient.Close();
        }
    }
}
