using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Shawn M. Crawford - [sleepy9090] - 2017
namespace SegaGenesisMegaDriveRomAnalyzer
{
    class SegaROMInfo
    {
        string path;

        public SegaROMInfo(string gamePath)
        {
            path = gamePath;
        }

        // The checksum is calculated by adding up every word from 0x200 to the end of the ROM.
        // WORD = 16 bits or 2 bytes
        // FFFF = 16 bits or 2 bytes
        public string getCorrectedChecksum()
        {
            string correctedChecksum = "";
            int correctedChecksumInt = 0;
            string hexString = "";
            int fileLocation = 0x200;
            long fileLength = new FileInfo(path).Length;
            long fileLengthReduced = fileLength - 0x200;
            int incrementLength = 0x2;

            using(FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read))
            {
                long offset = fileStream.Seek(fileLocation, SeekOrigin.Begin);

                while(fileLengthReduced > 0)
                {
                    hexString = fileStream.ReadByte().ToString("X2"); // pad 2 spaces
                    hexString += fileStream.ReadByte().ToString("X2"); // pad 2 spaces
                    fileLengthReduced = fileLengthReduced - incrementLength;

                    correctedChecksumInt += int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
                }
            }

            correctedChecksum = correctedChecksumInt.ToString("X");
            // Ignore the upper bits
            correctedChecksum = correctedChecksum.Substring(Math.Max(0, correctedChecksum.Length - 4));
            return correctedChecksum;
        }

        public string getCorrectedROMSize()
        {
            long romSize = new FileInfo(path).Length - 1;
            return romSize.ToString("X").PadLeft(0x8, '0');
        }

        public string getConsoleName()
        {
            return convertHexToAscii(getHexStringFromFile(0x100, 0xF));
        }

        public string getFirmName()
        {
            return convertHexToAscii(getHexStringFromFile(0x110, 0x8));
        }

        public string getBuildDate()
        {
            return convertHexToAscii(getHexStringFromFile(0x118, 0x8));
        }

        public string getDomesticName()
        {
            return convertHexToAscii(getHexStringFromFile(0x120, 0x30));
        }

        public string getInternationalName()
        {
            return convertHexToAscii(getHexStringFromFile(0x150, 0x30));
        }

        public string getProgramType()
        {
            return convertHexToAscii(getHexStringFromFile(0x180, 0x2));
        }

        public string getProgramTypeSimple()
        {
            string programType = convertHexToAscii(getHexStringFromFile(0x180, 0x2));
            string programTypeSimple;
            
            if(programType.Equals("GM"))
            {
                programTypeSimple = "game";
            }
            else if(programType.Equals("AL"))
            {
                programTypeSimple = "educational";
            }
            else
            {
                programTypeSimple = "unknown";
            }

            return programTypeSimple;
        }

        public string getSerialNumber()
        {
            return convertHexToAscii(getHexStringFromFile(0x183, 0x8));
        }

        public string getVersionNumber()
        {
            return convertHexToAscii(getHexStringFromFile(0x18B, 0x3));
        }

        public string getChecksum()
        {
            return getHexStringFromFile(0x18E, 0x2);
        }

        //  I/0 support: (this is 16 bytes long)
        //J = Joypad                4 = Team Play
        //6 = 6-button Joypad       0 = Joystick for MS
        //K = Keyboard              R = Serial RS232C
        //P = Printer               T = Tablet
        //B = Control Ball          V = Paddle Controller
        //F = Floppy Disk Drive     C = CD-ROM
        //L = Activator             M = Mega Mouse
        public string getIODeviceSupport()
        {
            return convertHexToAscii(getHexStringFromFile(0x190, 0x10));
        }

        public string getROMStart()
        {
            return getHexStringFromFile(0x1A0, 0x4);
        }

        public string getROMEnd()
        {
            return getHexStringFromFile(0x1A4, 0x4);
        }

        public string getRAMStart()
        {
            return getHexStringFromFile(0x1A8, 0x4);
        }

        public string getRAMEnd()
        {
            return getHexStringFromFile(0x1AC, 0x4);
        }

        public string getBackupRAMStart()
        {
            return getHexStringFromFile(0x1B4, 0x4);
        }

        public string getBackupRAMEnd()
        {
            return getHexStringFromFile(0x1B8, 0x4);
        }

        // MOxxxxyy.z
        //xxxx  Firm name the same as in 2
        //yy    MODEM NO.
        //z     Version
        public string getModemSupport()
        {
            string modemSupport = convertHexToAscii(getHexStringFromFile(0x1BC, 0xA));

            //if(String.IsNullOrWhiteSpace(modemSupport))
            //{
            //    modemSupport = "NOT FOUND";
            //}

            return modemSupport;
        }

        public string getNotes()
        {
            return convertHexToAscii(getHexStringFromFile(0x1C8, 0x28));
        }

        public string getCountryCodes()
        {
            return convertHexToAscii(getHexStringFromFile(0x1F0, 0x3));
        }

        public bool setChecksum(string checksum)
        {
            return writeByteArrayToFile(this.path, 0x18E, StringToByteArray(checksum.PadRight(0x4, '0')));
        }

        public bool setROMStart(string romStart)
        {
            return writeByteArrayToFile(this.path, 0x1A0, StringToByteArray(romStart.PadRight(0x8, '0')));
        }

        public bool setROMEnd(string romEnd)
        {
            return writeByteArrayToFile(this.path, 0x1A4, StringToByteArray(romEnd.PadRight(0x8, '0')));
        }

        public bool setRAMStart(string ramStart)
        {
            return writeByteArrayToFile(this.path, 0x1A8, StringToByteArray(ramStart.PadRight(0x8, '0')));
        }

        public bool setRAMEnd(string ramEnd)
        {
            return writeByteArrayToFile(this.path, 0x1AC, StringToByteArray(ramEnd.PadRight(0x8, '0')));
        }

        public bool setBackupRAMStart(string backupRAMStart)
        {
            return writeByteArrayToFile(this.path, 0x1B4, StringToByteArray(backupRAMStart.PadRight(0x8, '0')));
        }

        public bool setBackupRAMEnd(string backupRAMEnd)
        {
            return writeByteArrayToFile(this.path, 0x1B8, StringToByteArray(backupRAMEnd.PadRight(0x8, '0')));
        }

        public bool setConsoleName(string consoleName)
        {
            string hexValue = convertAsciiToHex(consoleName.PadRight(0xF));
            return writeByteArrayToFile(this.path, 0x100, StringToByteArray(hexValue));
        }

        public bool setFirmName(string firmName)
        {
            string hexValue = convertAsciiToHex(firmName.PadRight(0x8));
            return writeByteArrayToFile(this.path, 0x110, StringToByteArray(hexValue));
        }

        public bool setBuildDate(string buildDate)
        {
            string hexValue = convertAsciiToHex(buildDate.PadRight(0x8));
            return writeByteArrayToFile(this.path, 0x118, StringToByteArray(hexValue));
        }

        public bool setDomesticName(string domesticName)
        {
            string hexValue = convertAsciiToHex(domesticName.PadRight(0x30));
            return writeByteArrayToFile(this.path, 0x120, StringToByteArray(hexValue));
        }

        public bool setInternationName(string internationName)
        {
            string hexValue = convertAsciiToHex(internationName.PadRight(0x30));
            return writeByteArrayToFile(this.path, 0x150, StringToByteArray(hexValue));
        }

        public bool setProgramType(string programType)
        {
            string hexValue = convertAsciiToHex(programType.PadRight(0x2));
            return writeByteArrayToFile(this.path, 0x180, StringToByteArray(hexValue));
        }

        public bool setSerialNumber(string serialNumber)
        {
            string hexValue = convertAsciiToHex(serialNumber.PadRight(0x8));
            return writeByteArrayToFile(this.path, 0x183, StringToByteArray(hexValue));
        }

        public bool setVersionNumber(string versionNumber)
        {
            string hexValue = convertAsciiToHex(versionNumber.PadRight(0x3));
            return writeByteArrayToFile(this.path, 0x18B, StringToByteArray(hexValue));
        }

        public bool setIODeviceSupport(string ioDeviceSupport)
        {
            string hexValue = convertAsciiToHex(ioDeviceSupport.PadRight(0x10));
            return writeByteArrayToFile(this.path, 0x190, StringToByteArray(hexValue));
        }

        public bool setModemSupport(string modemSupport)
        {
            string hexValue = convertAsciiToHex(modemSupport.PadRight(0xA));
            return writeByteArrayToFile(this.path, 0x1BC, StringToByteArray(hexValue));
        }

        public bool setNotes(string notes)
        {
            string hexValue = convertAsciiToHex(notes.PadRight(0x28));
            return writeByteArrayToFile(this.path, 0x1C8, StringToByteArray(hexValue));
        }

        public bool setCountryCodes(string countryCodes)
        {
            string hexValue = convertAsciiToHex(countryCodes.PadRight(0x3));
            return writeByteArrayToFile(this.path, 0x1F0, StringToByteArray(hexValue));
        }

        private static string convertAsciiToHex(String asciiString)
        {
            char[] charValues = asciiString.ToCharArray();
            string hexValue = "";
            foreach(char c in charValues)
            {
                int value = Convert.ToInt32(c);
                hexValue += String.Format("{0:X}", value);
            }
            return hexValue;
        }

        private static string convertHexToAscii(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for(int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch(Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }

            return string.Empty;
        }

        private string getHexStringFromFile(int startPoint, int length)
        {
            string hexString = "";
            using(FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read))
            {
                long offset = fileStream.Seek(startPoint, SeekOrigin.Begin);

                for(int x = 0; x < length; x++)
                {
                    hexString += fileStream.ReadByte().ToString("X2");
                }

            }

            return hexString;
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private bool writeByteArrayToFile(string fileName, int startPoint, byte[] byteArray)
        {
            bool result = false;
            try
            {
                using(var fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    fs.Position = startPoint;
                    fs.Write(byteArray, 0, byteArray.Length);
                    result = true;
                }
            }
            catch(Exception ex)
            {
                // Console.WriteLine("Error writing file: {0}", ex);
                result = false;
            }

            return result;
        }
    }
}
