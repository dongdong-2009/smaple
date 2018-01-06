using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DiskManage
{
    #region 2.2      设备信息
    /// <summary>
    /// 2.2.1   设备信息结构体
    ///     NET_DVR_Login_V30()参数结构
    ///     NET_DVR_DEVICEINFO_V30, *LPNET_DVR_DEVICEINFO_V30;
    /// </summary>
    public struct NET_DVR_DEVICEINFO_V30
    {
        /// <summary>
        /// 序列号
        ///     public byte sSerialNumber[SERIALNO_LEN];
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HCNetSDK.SERIALNO_LEN)]
        public byte[] sSerialNumber;
        /// <summary>
        /// 报警输入个数
        /// </summary>
        public byte byAlarmInPortNum;
        /// <summary>
        /// 报警输出个数
        /// </summary>
        public byte byAlarmOutPortNum;
        /// <summary>
        /// 硬盘个数
        /// </summary>
        public byte byDiskNum;
        /// <summary>
        /// 设备类型, 1:DVR 2:ATM DVR 3:DVS ......
        /// </summary>
        public byte byDVRType;
        /// <summary>
        /// 模拟通道个数
        /// </summary>
        public byte byChanNum;
        /// <summary>
        /// 起始通道号,例如DVS-1,DVR - 1
        /// </summary>
        public byte byStartChan;
        /// <summary>
        /// 语音通道数
        /// </summary>
        public byte byAudioChanNum;
        /// <summary>
        /// 最大数字通道个数
        /// </summary>
        public byte byIPChanNum;
        /// <summary>
        /// 保留
        ///     public byte byRes1[24];
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] byRes1;
    }
    /// <summary>
    /// 7.4.1   录像文件时间信息结构体
    ///     相关函数
    ///         NET_DVR_FindFile、NET_DVR_FindFileByCard、
    ///         NET_DVR_PlayBackByTime、
    ///         NET_DVR_GetPlayBackOsdTime、
    ///         NET_DVR_GetFileByTime、
    ///         NET_DVR_UnlockFileByTime
    ///    NET_DVR_TIME, *LPNET_DVR_TIME;
    /// </summary>
    public struct NET_DVR_TIME
    {
        /// <summary>
        /// 年
        /// </summary>
        //[MarshalAs(UnmanagedType.U4)]
        public uint dwYear;
        /// <summary>
        /// 月
        /// </summary>
        ///[MarshalAs(UnmanagedType.U4)]
        public uint dwMonth;
        /// <summary>
        /// 日
        /// </summary>
        //  [MarshalAs(UnmanagedType.U4)]
        public uint dwDay;
        /// <summary>
        /// 时
        /// </summary>
        //  [MarshalAs(UnmanagedType.U4)]
        public uint dwHour;
        /// <summary>
        /// 分
        /// </summary>
        //  [MarshalAs(UnmanagedType.U4)]
        public uint dwMinute;
        /// <summary>
        /// 秒
        /// </summary>
        //  [MarshalAs(UnmanagedType.U4)]
        public uint dwSecond;
    }
    /// <summary>
    /// 设备信息结构体
    ///     NET_DVR_Login()参数结构
    ///     NET_DVR_DEVICEINFO, *LPNET_DVR_DEVICEINFO;
    /// </summary>
    public struct NET_DVR_DEVICEINFO
    {
        /// <summary>
        /// 序列号
        ///     public byte sSerialNumber[SERIALNO_LEN];
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HCNetSDK.SERIALNO_LEN)]
        public byte[] sSerialNumber;
        /// <summary>
        /// DVR报警输入个数
        /// </summary>
        public byte byAlarmInPortNum;
        /// <summary>
        /// DVR报警输出个数
        /// </summary>
        public byte byAlarmOutPortNum;
        /// <summary>
        /// DVR硬盘个数
        /// </summary>
        public byte byDiskNum;
        /// <summary>
        /// DVR类型, 1:DVR 2:ATM DVR 3:DVS ......
        /// </summary>
        public byte byDVRType;
        /// <summary>
        /// DVR 通道个数
        /// </summary>
        public byte byChanNum;
        /// <summary>
        /// 起始通道号,例如DVS-1,DVR - 1
        /// </summary>
        public byte byStartChan;
    }

   
    #endregion

    public sealed class HCNetSDK
    {
        /// <summary>
        /// DVR本地登陆名
        /// </summary>
        public const int MAX_NAMELEN = 16;
        /// <summary>
        /// 设备支持的权限（1-12表示本地权限，13-32表示远程权限）
        /// </summary>
        public const int MAX_RIGHT = 32;
        /// <summary>
        /// 用户名长度
        /// </summary>
        public const int NAME_LEN = 32;
        /// <summary>
        /// /密码长度
        /// </summary>
        public const int PASSWD_LEN = 16;
        /// <summary>
        /// 序列号长度
        /// </summary>
        public const int SERIALNO_LEN = 48;
        /// <summary>
        /// 8000设备最大通道数
        /// </summary>
        public const int MAX_CHANNUM = 16;
        /// <summary>
        /// 8000设备最大报警输入数
        /// </summary>
        public const int MAX_ALARMIN = 16;
        /// <summary>
        /// 8000设备最大报警输出数
        /// </summary>
        public const int MAX_ALARMOUT = 4;
        /// <summary>
        /// 最大32个模拟通道
        /// </summary>
        public const int MAX_ANALOG_CHANNUM = 32;
        /// <summary>
        /// 最大32路模拟报警输出 
        /// </summary>
        public const int MAX_ANALOG_ALARMOUT = 32;
        /// <summary>
        /// 最大32路模拟报警输入
        /// </summary>
        public const int MAX_ANALOG_ALARMIN = 32;
        /// <summary>
        /// 允许接入的最大IP设备数
        /// </summary>
        public const int MAX_IP_DEVICE = 32;
        /// <summary>
        /// 允许加入的最多IP通道数
        /// </summary>
        public const int MAX_IP_CHANNEL = 32;
        /// <summary>
        /// 允许加入的最多报警输入数
        /// </summary>
        public const int MAX_IP_ALARMIN = 128;
        /// <summary>
        /// 允许加入的最多报警输出数
        /// </summary>
        public const int MAX_IP_ALARMOUT = 64;
        /* 最大支持的通道数 最大模拟加上最大IP支持 */
        public const int MAX_CHANNUM_V30 = (MAX_ANALOG_CHANNUM + MAX_IP_CHANNEL);//64
        public const int MAX_ALARMOUT_V30 = (MAX_ANALOG_ALARMOUT + MAX_IP_ALARMOUT);//96
        public const int MAX_ALARMIN_V30 = (MAX_ANALOG_ALARMIN + MAX_IP_ALARMIN);//160

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICEINFO_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 48, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;
            public byte byAlarmInPortNum;
            public byte byAlarmOutPortNum;
            public byte byDiskNum;
            public byte byDVRType;
            public byte byChanNum;
            public byte byStartChan;
            public byte byAudioChanNum;
            public byte byIPChanNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
        }



        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PHY_DISK_INFO
        {
            public long wPhySlot;

            public Int32 byType;
            public Int32 byStatus;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
            public byte[] byMode;

            public uint dwHCapacity;

            public uint dwLCapacity;

            public int byArrrayName;

            public int wArrayID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 102)]
            public byte[] byRes;

        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SINGLE_HD
        {
            public uint dwHDNo;
            public uint dwCapacity;
            public uint dwFreeSpace;
            public uint dwHdStatus;
            public byte byHDAttr;
            public byte byHDType;
            public byte byDiskDriver;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] byRes1;

            public long dwHdGroup;
            public byte byRecycling;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 119)]
            public byte[] byRes2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HDCFG
        {
            public uint dwSize;
            public uint dwHDCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public NET_DVR_SINGLE_HD[] struHDInfo;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PHY_DISK_LIST
        {
            public long dwSize;
            public long dwCount;

            public NET_DVR_PHY_DISK_INFO stance_NET_DVR_PHY_DISK_INFO;

        }

        public struct NET_DVR_SHOWSTRINGINFO
        {
            public uint wShowString;
            public uint wStringSize;
            public uint wShowStringTopLeftX;
            public uint wShowStringTopLeftY;
            public string sString;
        }

        public struct NET_DVR_SHOWSTRING_V30
        {
            public uint dwSize;
            public NET_DVR_SHOWSTRINGINFO[] struStringInfo;
        }

        public struct NET_DVR_CLIENTINFO
        {
            public Int32 lChannel;//通道号
            public Int32 lLinkMode;//最高位(31)为0表示主码流，为1表示子码流，0－30位表示码流连接方式: 0：TCP方式,1：UDP方式,2：多播方式,3 - RTP方式，4-音视频分开(TCP)
            public IntPtr hPlayWnd;//播放窗口的句柄,为NULL表示不播放图象
            public string sMultiCastIP;//多播组地址
        }
        /// <summary>
        /// 14.2.3 设备状态信息结构体(DVR工作状态(9000扩展))
        ///     NET_DVR_WORKSTATE_V30, *LPNET_DVR_WORKSTATE_V30;
        /// </summary>
        public struct NET_DVR_WORKSTATE_V30
        {
            /// <summary>
            /// 设备的状态,0-正常,1-CPU占用率太高,超过85%,2-硬件错误,例如串口死掉
            /// </summary>
            public uint dwDeviceStatic;
            /// <summary>
            /// 硬盘状态
            ///     NET_DVR_DISKSTATE  struHardDiskStatic[MAX_DISKNUM_V30];
            /// </summary>
            public NET_DVR_DISKSTATE[] struHardDiskStatic;
            /// <summary>
            /// 通道状态
            ///     NET_DVR_CHANNELSTATE_V30 struChanStatic[MAX_CHANNUM_V30];
            /// </summary>
            public NET_DVR_CHANNELSTATE_V30[] struChanStatic;
            /// <summary>
            /// 报警端口的状态,0-没有报警,1-有报警
            ///     public byte  byAlarmInStatic[MAX_ALARMIN_V30];
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HCNetSDK.MAX_ALARMIN_V30)]
            public byte[] byAlarmInStatic;
            /// <summary>
            /// 报警输出端口的状态,0-没有输出,1-有报警输出
            ///     public byte  byAlarmOutStatic[MAX_ALARMOUT_V30];
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HCNetSDK.MAX_ALARMOUT_V30)]
            public byte[] byAlarmOutStatic;
            /// <summary>
            /// 本地显示状态,0-正常,1-不正常
            /// </summary>
            public uint dwLocalDisplay;
            /// <summary>
            /// 表示语音通道的状态 0-未使用，1-使用中, 0xff无效
            ///     public byte  byAudioChanStatus[MAX_AUDIO_V30];
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HCNetSDK.MAX_ALARMIN)]
            public byte[] byAudioChanStatus;
            /// <summary>
            /// public byte  byRes[10];
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] byRes;
        }
        /// <summary>
        /// 设备状态信息结构体(DVR工作状态)
        ///     NET_DVR_WORKSTATE, *LPNET_DVR_WORKSTATE;
        /// </summary>
        public struct NET_DVR_WORKSTATE
        {
            /// <summary>
            /// 设备的状态,0-正常,1-CPU占用率太高,超过85%,2-硬件错误,例如串口死掉
            /// </summary>
            public uint dwDeviceStatic;
            /// <summary>
            /// 硬盘状态
            ///     NET_DVR_DISKSTATE  struHardDiskStatic[MAX_DISKNUM];
            /// </summary>
            public NET_DVR_DISKSTATE[] struHardDiskStatic;
            /// <summary>
            /// 通道状态
            ///     NET_DVR_CHANNELSTATE struChanStatic[MAX_CHANNUM];
            /// </summary>
            public NET_DVR_CHANNELSTATE[] struChanStatic;
            /// <summary>
            /// 报警端口的状态,0-没有报警,1-有报警
            ///     public byte  byAlarmInStatic[MAX_ALARMIN];
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HCNetSDK.MAX_ALARMIN)]
            public byte[] byAlarmInStatic;
            /// <summary>
            /// 报警输出端口的状态,0-没有输出,1-有报警输出
            ///     public byte  byAlarmOutStatic[MAX_ALARMOUT];
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HCNetSDK.MAX_ALARMOUT)]
            public byte[] byAlarmOutStatic;
            /// <summary>
            /// 本地显示状态,0-正常,1-不正常
            /// </summary>
            public uint dwLocalDisplay;
        }
        #region 14.2          设备状态信息
        /// <summary>
        /// 14.2.1 硬盘信息结构体
        ///     NET_DVR_DISKSTATE, *LPNET_DVR_DISKSTATE;
        /// </summary>
        public struct NET_DVR_DISKSTATE
        {
            /// <summary>
            /// 硬盘的容量
            /// </summary>
            public uint dwVolume;
            /// <summary>
            /// 硬盘的剩余空间
            /// </summary>
            public uint dwFreeSpace;
            /// <summary>
            /// 硬盘的状态,0-活动,1-休眠,2-不正常
            /// </summary>
            public uint dwHardDiskStatic;
        }
        /// <summary>
        /// 14.2.2 通道信息(9000扩展)
        ///     NET_DVR_CHANNELSTATE_V30, *LPNET_DVR_CHANNELSTATE_V30;
        /// </summary>
        public struct NET_DVR_CHANNELSTATE_V30
        {
            /// <summary>
            /// 通道是否在录像,0-不录像,1-录像
            /// </summary>
            public byte byRecordStatic;
            /// <summary>
            /// 连接的信号状态,0-正常,1-信号丢失
            /// </summary>
            public byte bySignalStatic;
            /// <summary>
            /// 通道硬件状态,0-正常,1-异常,例如DSP死掉
            /// </summary>
            public byte byHardwareStatic;
            /// <summary>
            /// 保留
            /// </summary>
            public byte byRes1;
            /// <summary>
            /// 实际码率
            /// </summary>
            public uint dwBitRate;
            /// <summary>
            /// 客户端连接的个数
            /// </summary>
            public uint dwLinkNum;
            /// <summary>
            /// 客户端的IP地址
            ///     public NET_DVR_IPADDR struClientIP[MAX_LINK];
            /// </summary>
            public NET_DVR_IPADDR[] struClientIP;
            /// <summary>
            /// 如果该通道为IP接入，那么表示IP接入当前的连接数
            /// </summary>
            public uint dwIPLinkNum;
            /// <summary>
            ///     public byte byRes[12];
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[] byRes;
        }
        /// <summary>
        /// 通道信息(通道状态)
        ///     NET_DVR_CHANNELSTATE, *LPNET_DVR_CHANNELSTATE;
        /// </summary>
        public struct NET_DVR_CHANNELSTATE
        {
            /// <summary>
            /// 通道是否在录像,0-不录像,1-录像
            /// </summary>
            public byte byRecordStatic;
            /// <summary>
            /// 连接的信号状态,0-正常,1-信号丢失
            /// </summary>
            public byte bySignalStatic;
            /// <summary>
            /// 通道硬件状态,0-正常,1-异常,例如DSP死掉
            /// </summary>
            public byte byHardwareStatic;
            /// <summary>
            /// 保留
            /// </summary>
            public char reservedData;
            /// <summary>
            /// 实际码率
            /// </summary>
            public uint dwBitRate;
            /// <summary>
            /// 客户端连接的个数
            /// </summary>
            public uint dwLinkNum;
            /// <summary>
            /// 客户端的IP地址
            ///     public uint dwClientIP[MAX_LINK];
            /// </summary>
            public uint dwClientIP;
        }
        #endregion
        /// <summary>
        /// IP地址结构体
        ///    NET_DVR_IPADDR, *LPNET_DVR_IPADDR;
        /// </summary>
        public struct NET_DVR_IPADDR
        {
            /// <summary>
            /// IPv4地址
            ///    char	sIpV4[16];
            /// </summary>
            public string sIpV4;
            /// <summary>
            /// 保留
            ///     public byte byRes[128]
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] byRes;
        }


        #region 1.1   初始化
        /// <summary>
        /// 1.1.1      初始化SDK
        /// </summary>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Init();
        /// <summary>
        /// 1.1.2     释放SDK资源
        /// </summary>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Cleanup();
        #region 1.1.3 NET_DVR_IsSupport
        /*************************************************
        NET_DVR_IsSupport()返回值
        1－9位分别表示以下信息（位与是TRUE)表示支持；
        **************************************************/
        /// <summary>
        /// 支持DIRECTDRAW，如果不支持，则播放器不能工作；
        /// </summary>
        public const int NET_DVR_SUPPORT_DDRAW = 0x01;//
        /// <summary>
        /// 显卡支持BLT操作，如果不支持，则播放器不能工作；
        /// </summary>
        public const int NET_DVR_SUPPORT_BLT = 0x02;//
        /// <summary>
        /// 显卡BLT支持颜色转换，如果不支持，播放器会用软件方法作RGB转换；
        /// </summary>
        public const int NET_DVR_SUPPORT_BLTFOURCC = 0x04;//
        /// <summary>
        /// 显卡BLT支持X轴缩小；如果不支持，系统会用软件方法转换；
        /// </summary>
        public const int NET_DVR_SUPPORT_BLTSHRINKX = 0x08;//
        /// <summary>
        /// 显卡BLT支持Y轴缩小；如果不支持，系统会用软件方法转换；
        /// </summary>
        public const int NET_DVR_SUPPORT_BLTSHRINKY = 0x10;//
        /// <summary>
        /// 显卡BLT支持X轴放大；如果不支持，系统会用软件方法转换；
        /// </summary>
        public const int NET_DVR_SUPPORT_BLTSTRETCHX = 0x20;//
        /// <summary>
        /// 显卡BLT支持Y轴放大；如果不支持，系统会用软件方法转换；
        /// </summary>
        public const int NET_DVR_SUPPORT_BLTSTRETCHY = 0x40;//
        /// <summary>
        /// CPU支持SSE指令，Intel Pentium3以上支持SSE指令；
        /// </summary>
        public const int NET_DVR_SUPPORT_SSE = 0x80;//
        /// <summary>
        /// CPU支持MMX指令集，Intel Pentium3以上支持SSE指令；
        /// </summary>
        public const int NET_DVR_SUPPORT_MMX = 0x100;//
        /// <summary>
        /// 1.1.3    判断运行客户端的PC配置是否符合要求(保留不使用)
        ///     NET_DVR_API int __stdcall NET_DVR_IsSupport();
        /// </summary>
        /// <returns>
        /// 1～9位分别表示以下信息（位与是TRUE，表示支持）
        /// #define  NET_DVR_SUPPORT_DDRAW          0x01    支持DIRECTDRAW，如果不支持，则播放器不能工作
        /// #define  NET_DVR_SUPPORT_BLT            0x02    显卡支持BLT操作，如果不支持，则播放器不能工作
        /// #define  NET_DVR_SUPPORT_BLTFOURCC      0x04    显卡BLT支持颜色转换，如果不支持，播放器会用软件方法作RGB转换
        /// #define  NET_DVR_SUPPORT_BLTSHRINKX     0x08    显卡BLT支持X轴缩小；如果不支持，系统会用软件方法转换
        /// #define  NET_DVR_SUPPORT_BLTSHRINKY     0x10    显卡BLT支持Y轴缩小；如果不支持，系统会用软件方法转换
        /// #define  NET_DVR_SUPPORT_BLTSTRETCHX    0x20    显卡BLT支持X轴放大；如果不支持，系统会用软件方法转换
        /// #define  NET_DVR_SUPPORT_BLTSTRETCHY    0x40    显卡BLT支持Y轴放大；如果不支持，系统会用软件方法转换
        /// #define  NET_DVR_SUPPORT_SSE            0x80    CPU支持SSE指令，Intel Pentium3以上支持SSE指令
        /// #define  NET_DVR_SUPPORT_MMX            0x100   CPU支持MMX指令集，Intel Pentium3以上支持SSE指令
        /// </returns>
        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_IsSupport();
        #endregion
        /// <summary>
        /// 1.1.4   设置连接超时时间和连接尝试次数
        ///     NET_DVR_API BOOL __stdcall NET_DVR_SetConnectTime(DWORD dwWaitTime = 5000, DWORD dwTryTimes = 3);
        /// </summary>
        /// <param name="dwWaitTime">[in]超时时间，单位：毫秒 ，取值范围（>300，<60*1000）</param>
        /// <param name="dwTryTimes">[in]连接尝试次数（暂时保留）</param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_SetConnectTime(uint dwWaitTime, uint dwTryTimes);
        /// <summary>
        /// 1.1.5   通过IPServer获取设备动态IP地址
        ///     注意
        ///         设备名称和设备序列号不能同时为空。
        ///         IPServer是海康威视提供的一款域名解析服务器软件
        ///     NET_DVR_API BOOL __stdcall NET_DVR_GetDVRIPByResolveSvr(char *sServerIP, WORD wServerPort, BYTE *sDVRName,WORD wDVRNameLen,BYTE *sDVRSerialNumber,WORD wDVRSerialLen,char* sGetIP);
        /// </summary>
        /// <param name="sServerIP">[in]解析服务器的IP地址</param>
        /// <param name="wServerPort">[in]解析服务器的端口号，我们提供的解析服务器（IPServer）端口号为7071</param>
        /// <param name="sDVRName">[in]设备名称，可以为NULL</param>
        /// <param name="wDVRNameLen">[in]设备名称的长度</param>
        /// <param name="sDVRSerialNumber">[in]设备的序列号，可以为NULL</param>
        /// <param name="wDVRSerialLen">[in]设备序列号的长度</param>
        /// <param name="sGetIP">[out]保存获取到的IP地址的指针</param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRIPByResolveSvr(string sServerIP, ushort wServerPort, string sDVRName, ushort wDVRNameLen, string sDVRSerialNumber, ushort wDVRSerialLen, StringBuilder sGetIP);
        #endregion
        #region 2.1    用户注册
        /// <summary>
        /// 1.1.1      初始化SDK
        /// </summary>
        /// <returns>TRUE表示成功，FALSE表示失败</returns>
        /// <summary>
        /// 2.1.1   注册用户(用户登录)
        ///     NET_DVR_API LONG __stdcall NET_DVR_Login_V30(char *sDVRIP, WORD wDVRPort, char *sUserName, char *sPassword, LPNET_DVR_DEVICEINFO_V30 lpDeviceInfo);
        /// </summary>
        /// <param name="sDVRIP">[in]设备的IP地址</param>
        /// <param name="wDVRPort">[in]设备的端口号</param>
        /// <param name="sUserName">[in]登录的用户名</param>
        /// <param name="sPassword">[in]用户密码</param>
        /// <param name="lpDeviceInfo">[out]指向NET_DVR_DEVICEINFO_V30结构</param>
        /// <returns>获得的用户ID号</returns>
        [DllImport("HCNetSDK.dll", EntryPoint = "NET_DVR_Login_V30")]
        public static extern int NET_DVR_Login_V30(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, out NET_DVR_DEVICEINFO_V30 lpDeviceInfo);
        /// <summary>
        /// 注册用户(用户登录)
        ///     NET_DVR_API LONG __stdcall NET_DVR_Login(char *sDVRIP,WORD wDVRPort,char *sUserName,char *sPassword,LPNET_DVR_DEVICEINFO lpDeviceInfo);
        /// </summary>
        /// <param name="sDVRIP">[in]设备的IP地址</param>
        /// <param name="wDVRPort">[in]设备的端口号</param>
        /// <param name="sUserName">[in]登录的用户名</param>
        /// <param name="sPassword">[in]用户密码</param>
        /// <param name="lpDeviceInfo">[out]指向NET_DVR_DEVICEINFO结构</param>
        /// <returns>-1表示失败，其他值表示返回的用户ID值，该ID值是由SDK分配，每个用户ID值在客户端是唯一的</returns>
        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_Login(string sDVRIP, ushort wDVRPort, string sUserName, string sPassword, out NET_DVR_DEVICEINFO lpDeviceInfo);
        #endregion
        #region 2.1.2       注销用户
        /// <summary>
        /// 2.1.2   注销用户
        ///     说明
        ///         强制停止该用户的所有操作和释放所有的资源，确保该ID对应的线程都安全退出，资源得到释放。
        ///     注意
        ///         NET_DVR_Logout_V30会等待或者强制将该用户的所有资源释放或者退出（如线程等），
        ///         而 NET_DVR_Logout则不会，仅仅将当前的用户从设备上注销了。
        ///     NET_DVR_API BOOL __stdcall NET_DVR_Logout_V30(LONG lUserID);
        /// </summary>
        /// <param name="lUserID">[in] NET_DVR_Login或者NET_DVR_Login_V30的返回值</param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Logout_V30(int lUserID);
        /// <summary>
        /// 注销用户
        ///     NET_DVR_API BOOL __stdcall NET_DVR_Logout(LONG lUserID);
        /// </summary>
        /// <param name="lUserID">[in]用户ID值，由NET_DVR_Login或者NET_DVR_Login_V30返回的ID值</param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_Logout(int lUserID);

        /// <summary>
        /// 7.3.18 按时间下载
        ///     NET_DVR_API LONG __stdcall NET_DVR_GetFileByTime(LONG lUserID,LONG lChannel, LPNET_DVR_TIME lpStartTime, LPNET_DVR_TIME lpStopTime, char *sSavedFileName);
        /// </summary>
        /// <param name="lUserID">[in]NET_DVR_Login或者NET_DVR_Login_V30的返回值</param>
        /// <param name="lChannel">[in]通道号</param>
        /// <param name="lpStartTime">[in]开始时间</param>
        /// <param name="lpStopTime">[in]结束时间</param>
        /// <param name="sSavedFileName">[in]下载后保存到PC机的文件名</param>
        /// <returns>-1表示失败，其他值表示成功，作为NET_DVR_StopGetFile等函数的参数</returns>
        /// [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [DllImport("HCNetSDK.dll")]
        public static extern int NET_DVR_GetFileByTime(int lUserID, int lChannel, ref NET_DVR_TIME lpStartTime, ref NET_DVR_TIME lpStopTime, string sSavedFileName);

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public static string SavedFileName;
        #endregion
        #region 14.1          获取设备状态
        /// <summary>
        /// 14.1.1 获取硬盘录像机工作状态
        ///     NET_DVR_API BOOL __stdcall NET_DVR_GetDVRWorkState_V30(LONG lUserID, LPNET_DVR_WORKSTATE_V30 lpWorkState);
        /// </summary>
        /// <param name="lUserID">[in] NET_DVR_Login或者NET_DVR_Login_V30的返回值</param>
        /// <param name="lpWorkState">[out]指向NET_DVR_WORKSTATE_V30结构</param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRWorkState_V30(int lUserID, out NET_DVR_WORKSTATE_V30 lpWorkState);
        /// <summary>
        /// 获取硬盘录像机工作状态
        ///     NET_DVR_API BOOL __stdcall NET_DVR_GetDVRWorkState(LONG lUserID, LPNET_DVR_WORKSTATE lpWorkState);
        /// </summary>
        /// <param name="lUserID">[in]NET_DVR_Login或者NET_DVR_Login_V30的返回值</param>
        /// <param name="lpWorkState">[out]存放获得工作状态信息</param>
        /// <returns></returns>
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRWorkState(int lUserID, out NET_DVR_WORKSTATE lpWorkState);


//        BOOL NET_DVR_ClientGetVideoEffect(
//  LONG lRealHandle,
//  DWORD* pBrightValue,
//  DWORD* pContrastValue,
//  DWORD* pSaturationValue,
//  DWORD* pHueValue
//);
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_ClientGetVideoEffect(int lRealHandle, ref long pBrightValue, ref long pContrastValue, ref long pSaturationValue, ref long pHueValue);
        #endregion

  

        /*********************************************************
        Function:	NET_DVR_Login_V30
        Desc:		
        Input:	sDVRIP [in] 设备IP地址 
                wServerPort [in] 设备端口号 
                sUserName [in] 登录的用户名 
                sPassword [in] 用户密码 
        Output:	lpDeviceInfo [out] 设备信息 
        Return:	-1表示失败，其他值表示返回的用户ID值
        **********************************************************/
        [DllImport("HCNetSDK.dll")]
        public static extern Int32 NET_DVR_Login_V30(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo);



        /*********************************************************
        Function:	REALDATACALLBACK
        Desc:		预览回调
        Input:	lRealHandle 当前的预览句柄 
                dwDataType 数据类型
                pBuffer 存放数据的缓冲区指针 
                dwBufSize 缓冲区大小 
                pUser 用户数据 
        Output:	
        Return:	void
        **********************************************************/
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void REALDATACALLBACK(Int32 lRealHandle, UInt32 dwDataType, [MarshalAs(UnmanagedType.LPArray, SizeConst = 20480)] byte[] pBuffer, UInt32 dwBufSize, IntPtr pUser);
        [DllImport("HCNetSDK.dll")]

        /*********************************************************
        Function:	NET_DVR_RealPlay_V30
        Desc:		实时预览。
        Input:	lUserID [in] NET_DVR_Login()或NET_DVR_Login_V30()的返回值 
                lpClientInfo [in] 预览参数 
                cbRealDataCallBack [in] 码流数据回调函数 
                pUser [in] 用户数据 
                bBlocked [in] 请求码流过程是否阻塞：0－否；1－是 
        Output:	
        Return:	1表示失败，其他值作为NET_DVR_StopRealPlay等函数的句柄参数
        **********************************************************/
        public static extern Int32 NET_DVR_RealPlay_V30(Int32 lUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, int bBlocked);

        // NET_DVR_API BOOL __stdcall NET_DVR_CapturePicture(LONG lRealHandle,char *sPicFileName);//bmp
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_CapturePicture(Int32 lRealHandle, string sPicFileName);

        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetPDList(Int32 lUserID, ref NET_DVR_PHY_DISK_LIST LPNET_DVR_PHY_DISK_LIST);


//        BOOL NET_DVR_GetDVRConfig(
//  LONG lUserID,
//  DWORD dwCommand,
//  LONG lChannel,
//  LPVOID lpOutBuffer,
//  DWORD dwOutBufferSize,
//  LPDWORD lpBytesReturned
//);
        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRConfig(Int32 lUserID, long dwCommand, Int32 lChannel, out NET_DVR_SHOWSTRING_V30 NET_DVR_SHOWSTRING, long dwOutBufferSize, out long lpBytesReturned);


        [DllImport("HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRConfig(Int32 lUserID, uint dwCommand, Int32 lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned);
    }
}
