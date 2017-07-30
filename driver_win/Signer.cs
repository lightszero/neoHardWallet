using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NeoDun
{
    public class SignTool
    {
        static UInt32[] Crc32Table = {
0x00000000,0x77073096,0xEE0E612C,0x990951BA,
0x076DC419,0x706AF48F,0xE963A535,0x9E6495A3,
0x0EDB8832,0x79DCB8A4,0xE0D5E91E,0x97D2D988,
0x09B64C2B,0x7EB17CBD,0xE7B82D07,0x90BF1D91,
0x1DB71064,0x6AB020F2,0xF3B97148,0x84BE41DE,
0x1ADAD47D,0x6DDDE4EB,0xF4D4B551,0x83D385C7,
0x136C9856,0x646BA8C0,0xFD62F97A,0x8A65C9EC,
0x14015C4F,0x63066CD9,0xFA0F3D63,0x8D080DF5,
0x3B6E20C8,0x4C69105E,0xD56041E4,0xA2677172,
0x3C03E4D1,0x4B04D447,0xD20D85FD,0xA50AB56B,
0x35B5A8FA,0x42B2986C,0xDBBBC9D6,0xACBCF940,
0x32D86CE3,0x45DF5C75,0xDCD60DCF,0xABD13D59,
0x26D930AC,0x51DE003A,0xC8D75180,0xBFD06116,
0x21B4F4B5,0x56B3C423,0xCFBA9599,0xB8BDA50F,
0x2802B89E,0x5F058808,0xC60CD9B2,0xB10BE924,
0x2F6F7C87,0x58684C11,0xC1611DAB,0xB6662D3D,
0x76DC4190,0x01DB7106,0x98D220BC,0xEFD5102A,
0x71B18589,0x06B6B51F,0x9FBFE4A5,0xE8B8D433,
0x7807C9A2,0x0F00F934,0x9609A88E,0xE10E9818,
0x7F6A0DBB,0x086D3D2D,0x91646C97,0xE6635C01,
0x6B6B51F4,0x1C6C6162,0x856530D8,0xF262004E,
0x6C0695ED,0x1B01A57B,0x8208F4C1,0xF50FC457,
0x65B0D9C6,0x12B7E950,0x8BBEB8EA,0xFCB9887C,
0x62DD1DDF,0x15DA2D49,0x8CD37CF3,0xFBD44C65,
0x4DB26158,0x3AB551CE,0xA3BC0074,0xD4BB30E2,
0x4ADFA541,0x3DD895D7,0xA4D1C46D,0xD3D6F4FB,
0x4369E96A,0x346ED9FC,0xAD678846,0xDA60B8D0,
0x44042D73,0x33031DE5,0xAA0A4C5F,0xDD0D7CC9,
0x5005713C,0x270241AA,0xBE0B1010,0xC90C2086,
0x5768B525,0x206F85B3,0xB966D409,0xCE61E49F,
0x5EDEF90E,0x29D9C998,0xB0D09822,0xC7D7A8B4,
0x59B33D17,0x2EB40D81,0xB7BD5C3B,0xC0BA6CAD,
0xEDB88320,0x9ABFB3B6,0x03B6E20C,0x74B1D29A,
0xEAD54739,0x9DD277AF,0x04DB2615,0x73DC1683,
0xE3630B12,0x94643B84,0x0D6D6A3E,0x7A6A5AA8,
0xE40ECF0B,0x9309FF9D,0x0A00AE27,0x7D079EB1,
0xF00F9344,0x8708A3D2,0x1E01F268,0x6906C2FE,
0xF762575D,0x806567CB,0x196C3671,0x6E6B06E7,
0xFED41B76,0x89D32BE0,0x10DA7A5A,0x67DD4ACC,
0xF9B9DF6F,0x8EBEEFF9,0x17B7BE43,0x60B08ED5,
0xD6D6A3E8,0xA1D1937E,0x38D8C2C4,0x4FDFF252,
0xD1BB67F1,0xA6BC5767,0x3FB506DD,0x48B2364B,
0xD80D2BDA,0xAF0A1B4C,0x36034AF6,0x41047A60,
0xDF60EFC3,0xA867DF55,0x316E8EEF,0x4669BE79,
0xCB61B38C,0xBC66831A,0x256FD2A0,0x5268E236,
0xCC0C7795,0xBB0B4703,0x220216B9,0x5505262F,
0xC5BA3BBE,0xB2BD0B28,0x2BB45A92,0x5CB36A04,
0xC2D7FFA7,0xB5D0CF31,0x2CD99E8B,0x5BDEAE1D,
0x9B64C2B0,0xEC63F226,0x756AA39C,0x026D930A,
0x9C0906A9,0xEB0E363F,0x72076785,0x05005713,
0x95BF4A82,0xE2B87A14,0x7BB12BAE,0x0CB61B38,
0x92D28E9B,0xE5D5BE0D,0x7CDCEFB7,0x0BDBDF21,
0x86D3D2D4,0xF1D4E242,0x68DDB3F8,0x1FDA836E,
0x81BE16CD,0xF6B9265B,0x6FB077E1,0x18B74777,
0x88085AE6,0xFF0F6A70,0x66063BCA,0x11010B5C,
0x8F659EFF,0xF862AE69,0x616BFFD3,0x166CCF45,
0xA00AE278,0xD70DD2EE,0x4E048354,0x3903B3C2,
0xA7672661,0xD06016F7,0x4969474D,0x3E6E77DB,
0xAED16A4A,0xD9D65ADC,0x40DF0B66,0x37D83BF0,
0xA9BCAE53,0xDEBB9EC5,0x47B2CF7F,0x30B5FFE9,
0xBDBDF21C,0xCABAC28A,0x53B39330,0x24B4A3A6,
0xBAD03605,0xCDD70693,0x54DE5729,0x23D967BF,
0xB3667A2E,0xC4614AB8,0x5D681B02,0x2A6F2B94,
0xB40BBE37,0xC30C8EA1,0x5A05DF1B,0x2D02EF8D
        };
        static SHA256 sha256 = SHA256.Create();
        static Random random = new Random();

        public static byte[] ComputeCRC32(byte[] src, int begin, int length)
        {

            UInt32 crc = 0xFFFFFFFF;
            for (int i = 0; i < length; i++)
            {
                crc = ((crc >> 8) & 0x00FFFFFF) ^ Crc32Table[(crc ^ src[i + begin]) & 0xFF];
            }
            crc = crc ^ 0xFFFFFFFF;
            return BitConverter.GetBytes(crc);
        }
        public static byte[] ComputeSHA256(byte[] src, int begin, int length)
        {
            return sha256.ComputeHash(src, begin, length);
        }

        public static string Hex2String(byte[] data, int begin, int length)
        {
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                sb.Append(data[i + begin].ToString("X02"));
            }
            return sb.ToString();
        }

        public static UInt16 RandomShort()
        {
            UInt16 v = (UInt16)random.Next();
            return v;
        }
        public static void RandomData(byte[] data)
        {
            random.NextBytes(data);
        }
    }

    public class Error_MsgHashNotMatch : System.Exception
    {
        public Error_MsgHashNotMatch() : base()
        {

        }
        public Error_MsgHashNotMatch(string name) : base(name)
        {

        }
    }

    //一条报文
    public class Message
    {
        public byte tag1;
        public byte tag2;
        public UInt16 msgid;
        public byte[] data = new byte[58];
        public byte crc1;
        public byte crc2;
        public void ToData(byte[] _data)
        {
            _data[0] = tag1;
            _data[1] = tag2;
            var d = BitConverter.GetBytes(msgid);
            _data[2] = d[0];
            _data[3] = d[1];
            for (var i = 4; i < 62; i++)
            {
                var seek = i - 4;
                if (seek < this.data.Length)
                    _data[i] = this.data[seek];
                else
                    _data[i] = 0;
            }
            var crc = SignTool.ComputeCRC32(_data, 0, 62);
            _data[62] = crc[0];
            _data[63] = crc[1];
        }
        public void FromData(byte[] _data)
        {
            this.tag1 = _data[0];
            this.tag2 = _data[1];
            this.msgid = BitConverter.ToUInt16(_data, 2);
            for (var i = 4; i < 62; i++)
            {
                this.data[i - 4] = _data[i];
            }
            this.crc1 = this.data[62];
            this.crc2 = this.data[63];
            var crc = SignTool.ComputeCRC32(_data, 0, 62);
            if (this.crc1 != crc[0] || this.crc2 != crc[1])
            {
                throw new Error_MsgHashNotMatch("the message hash not match");
            }
        }
    }

    public class Signer
    {
        public delegate void deleUserHandleRecv(Message recv, Message src);
        deleUserHandleRecv userHandleRecv = null;
        public delegate void deleUserHandleSend(Message send, bool needBack);
        deleUserHandleSend userHandleSend = null;

        ConcurrentDictionary<string, byte[]> datapool = new ConcurrentDictionary<string, byte[]>();
        ConcurrentQueue<Message> msgForSend = new ConcurrentQueue<Message>();
        ConcurrentDictionary<UInt16, Message> needBackMessage = new ConcurrentDictionary<ushort, Message>();

        public void Start(deleUserHandleRecv _userHandleRecv, deleUserHandleSend _userHandleSend)
        {
            lock (this)
            {
                userHandleRecv = _userHandleRecv;
                userHandleSend = _userHandleSend;
            }
            USBHIDDriver.StartRead((data) =>
            {
                Message m = new Message();
                m.FromData(data);
                OnMsg(m);
            });
            System.Threading.Thread t = new System.Threading.Thread(() =>
              {
                  bExit = false;
                  StartSendQueue();
              });
            t.Start();
        }
        //消息发送线程
        void StartSendQueue()
        {
            var data = new byte[64];
            while (bExit == false)
            {
                if (USBHIDDriver.IsActive())
                {
                    if (msgForSend.Count > 0)
                    {
                        Message msg = null;
                        if (msgForSend.TryDequeue(out msg))
                        {
                            msg.ToData(data);
                            USBHIDDriver.Send(data);
                        }
                    }
                }
            }
        }
        void OnMsg(Message msg)
        {
            Message srcmsg = null;
            if (msg.tag1 == 0x00 || msg.tag2 >= 0xa0)//如果是一条回复消息，找原始消息
            {
                srcmsg = this.needBackMessage[msg.msgid];
            }
            System.Threading.ThreadPool.QueueUserWorkItem((_state) =>
            {
                if (msg.tag1 == 0x01 && msg.tag2 == 0x10)//请求数据
                {
                    int blockbegin = BitConverter.ToUInt16(msg.data, 0);
                    int blockend = BitConverter.ToUInt16(msg.data, 2);
                    string hash = SignTool.Hex2String(msg.data, 4, 32);
                    if (datapool.ContainsKey(hash) == false)
                    {
                        //发送错误回应，下一步再说
                    }
                    else
                    {

                        for (var i = blockbegin; i < blockend; i++)
                        {
                            int begin = i * 50;
                            int end = (i + 1) * 50;
                            //Send0102
                            Message msg1 = new Message();
                            msg1.tag1 = 0x01;
                            msg1.tag2 = 0x02;
                            msg1.msgid = msg.msgid;//这是一条回复消息
                            var bytepiece = BitConverter.GetBytes((ushort)i);
                            msg1.data[0] = bytepiece[0];
                            msg1.data[1] = bytepiece[1];
                            var srcdata = datapool[hash];
                            for (var s = begin; s < end; s++)
                            {
                                if (s < srcdata.Length)
                                {
                                    msg1.data[s - begin + 2] = srcdata[s];
                                }
                                else
                                {
                                    msg1.data[s - begin + 2] = 0;
                                }
                            }
                            SendMessage(msg1, false);
                        }
                        //Send0103
                        Message msg2 = new Message();
                        msg2.tag1 = 0x01;
                        msg2.tag2 = 0x03;
                        msg2.msgid = msg.msgid;//这是一条回复消息
                        SendMessage(msg2, false);
                    }
                }
                if (userHandleRecv != null)
                {
                    userHandleRecv(msg, srcmsg);
                }
            });
        }
        bool bExit = false;
        public void Stop()
        {
            bExit = true;
            USBHIDDriver.StopRead();
        }
        public int CheckDevice()//检查设备
        {
            int count = USBHIDDriver.CheckDevice();

            return count;
        }


        void SendMessage(Message msg, bool needback)
        {
            if (needback)
            {
                needBackMessage[msg.msgid] = msg;//这是一条需要回复的消息，记下来
                if (this.userHandleSend != null)
                {
                    this.userHandleSend(msg, true);
                }
            }
            else
            {
                if (this.userHandleSend != null)
                {
                    this.userHandleSend(msg, false);
                }
            }
            //crc会在sendmsg 自动发送
            msgForSend.Enqueue(msg);
        }
        //发送包
        public void SendPackage(byte[] data)
        {
            byte[] sha = SignTool.ComputeSHA256(data, 0, data.Length);
            string key = SignTool.Hex2String(sha, 0, sha.Length);
            datapool[key] = sha;
            Message msg = new Message();
            msg.tag1 = 0x01; //0字节 
            msg.tag2 = 0x01; //1字节
            msg.msgid = SignTool.RandomShort();// 2 3 字节

            //4~7 字节
            var byteLength = BitConverter.GetBytes((UInt32)data.Length);
            for (var i = 0; i < 4; i++)
            {
                msg.data[i] = byteLength[i];
            }
            //8 到39 字节
            for (var i = 0; i < 32; i++)
            {
                msg.data[i + 4] = sha[i];
            }

            SendMessage(msg, true);
        }
    }
}
