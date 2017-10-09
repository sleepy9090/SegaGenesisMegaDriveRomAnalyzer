using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Shawn M. Crawford - [sleepy9090] - 2017
namespace SegaGenesisMegaDriveRomAnalyzer
{
    public partial class FormSGMDROMA : Form
    {
        string filepath;

        public FormSGMDROMA()
        {
            InitializeComponent();
            writeROMToolStripMenuItem.Enabled = false;
            fixChecksumToolStripMenuItem.Enabled = false;

            textBoxConsoleName.MaxLength = 0xF;
            textBoxFirmName.MaxLength = 0x8;
            textBoxBuildDate.MaxLength = 0x8;
            textBoxDomesticName.MaxLength = 0x30;
            textBoxInternationName.MaxLength = 0x30;
            textBoxProgramType.MaxLength = 0x2;
            textBoxSerialNumber.MaxLength = 0x8;
            textBoxVersionNumber.MaxLength = 0x3;
            textBoxChecksum.MaxLength = 0x4;
            textBoxFixedChecksum.MaxLength = 0x4;
            textBoxIODeviceSupport.MaxLength = 0x10;
            textBoxROMStart.MaxLength = 0x8;
            textBoxROMEnd.MaxLength = 0x8;
            textBoxRAMStart.MaxLength = 0x8;
            textBoxRAMEnd.MaxLength = 0x8;
            textBoxBackupRAMStart.MaxLength = 0x8;
            textBoxBackupRAMEnd.MaxLength = 0x8;
            textBoxModemSupport.MaxLength = 0xA;
            textBoxNotes.MaxLength = 0x28;
            textBoxCountryCodes.MaxLength = 0x3;

            textBoxFileName.Enabled = false;
            textBoxIODeviceSupport.Enabled = false;
            textBoxCountryCodes.Enabled = false;

            textBoxConsoleName.Enabled = false;
            textBoxFirmName.Enabled = false;
            textBoxBuildDate.Enabled = false;
            textBoxDomesticName.Enabled = false;
            textBoxInternationName.Enabled = false;
            textBoxProgramType.Enabled = false;
            textBoxProgramTypeSimple.Enabled = false;
            textBoxSerialNumber.Enabled = false;
            textBoxVersionNumber.Enabled = false;
            textBoxChecksum.Enabled = false;
            textBoxFixedChecksum.Enabled = false;
            textBoxCorrectROMSize.Enabled = false;
            textBoxROMStart.Enabled = false;
            textBoxROMEnd.Enabled = false;
            textBoxRAMStart.Enabled = false;
            textBoxRAMEnd.Enabled = false;
            textBoxBackupRAMStart.Enabled = false;
            textBoxBackupRAMEnd.Enabled = false;
            textBoxModemSupport.Enabled = false;
            textBoxNotes.Enabled = false;
            textBoxCompanyName.Enabled = false;

            checkBoxActivator.Enabled = false;
            checkBoxCDROM.Enabled = false;
            checkBoxControlBall.Enabled = false;
            checkBoxFloppyDiskDrive.Enabled = false;
            checkBoxJoypad.Enabled = false;
            checkBoxJoystickForMS.Enabled = false;
            checkBoxKeyboard.Enabled = false;
            checkBoxMegaMouse.Enabled = false;
            checkBoxPaddleController.Enabled = false;
            checkBoxPrinter.Enabled = false;
            checkBoxSerialRS232C.Enabled = false;
            checkBoxSixButtonJoypad.Enabled = false;
            checkBoxTablet.Enabled = false;
            checkBoxTeamPlay.Enabled = false;

            checkBoxAsia.Enabled = false;
            checkBoxBrazil4.Enabled = false;
            checkBoxBrazilB.Enabled = false;
            checkBoxEurope.Enabled = false;
            checkBoxFrance.Enabled = false;
            checkBoxHongKong.Enabled = false;
            checkBoxJapan.Enabled = false;
            checkBoxUSA.Enabled = false;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open file...";
            openFileDialog.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFileName.Enabled = true;
                textBoxIODeviceSupport.Enabled = true;
                textBoxCountryCodes.Enabled = true;

                textBoxConsoleName.Enabled = true;
                textBoxFirmName.Enabled = true;
                textBoxBuildDate.Enabled = true;
                textBoxDomesticName.Enabled = true;
                textBoxInternationName.Enabled = true;
                textBoxProgramType.Enabled = true;
                textBoxProgramTypeSimple.Enabled = true;
                textBoxSerialNumber.Enabled = true;
                textBoxVersionNumber.Enabled = true;
                textBoxChecksum.Enabled = true;
                textBoxFixedChecksum.Enabled = true;
                textBoxCorrectROMSize.Enabled = true;
                textBoxROMStart.Enabled = true;
                textBoxROMEnd.Enabled = true;
                textBoxRAMStart.Enabled = true;
                textBoxRAMEnd.Enabled = true;
                textBoxBackupRAMStart.Enabled = true;
                textBoxBackupRAMEnd.Enabled = true;
                textBoxModemSupport.Enabled = true;
                textBoxNotes.Enabled = true;
                //textBoxCompanyName.Enabled = true;

                checkBoxActivator.Enabled = true;
                checkBoxCDROM.Enabled = true;
                checkBoxControlBall.Enabled = true;
                checkBoxFloppyDiskDrive.Enabled = true;
                checkBoxJoypad.Enabled = true;
                checkBoxJoystickForMS.Enabled = true;
                checkBoxKeyboard.Enabled = true;
                checkBoxMegaMouse.Enabled = true;
                checkBoxPaddleController.Enabled = true;
                checkBoxPrinter.Enabled = true;
                checkBoxSerialRS232C.Enabled = true;
                checkBoxSixButtonJoypad.Enabled = true;
                checkBoxTablet.Enabled = true;
                checkBoxTeamPlay.Enabled = true;

                checkBoxAsia.Enabled = true;
                checkBoxBrazil4.Enabled = true;
                checkBoxBrazilB.Enabled = true;
                checkBoxEurope.Enabled = true;
                checkBoxFrance.Enabled = true;
                checkBoxHongKong.Enabled = true;
                checkBoxJapan.Enabled = true;
                checkBoxUSA.Enabled = true;

                textBoxFileName.Clear();
                textBoxConsoleName.Clear();
                textBoxFirmName.Clear();
                textBoxBuildDate.Clear();
                textBoxDomesticName.Clear();
                textBoxInternationName.Clear();
                textBoxProgramType.Clear();
                textBoxProgramTypeSimple.Clear();
                textBoxSerialNumber.Clear();
                textBoxVersionNumber.Clear();
                textBoxChecksum.Clear();
                textBoxFixedChecksum.Clear();
                textBoxCorrectROMSize.Clear();
                textBoxIODeviceSupport.Clear();
                textBoxROMStart.Clear();
                textBoxROMEnd.Clear();
                textBoxRAMStart.Clear();
                textBoxRAMEnd.Clear();
                textBoxBackupRAMStart.Clear();
                textBoxBackupRAMEnd.Clear();
                textBoxModemSupport.Clear();
                textBoxNotes.Clear();
                textBoxCountryCodes.Clear();
                textBoxCompanyName.Clear();

                checkBoxActivator.Checked = false;
                checkBoxCDROM.Checked = false;
                checkBoxControlBall.Checked = false;
                checkBoxFloppyDiskDrive.Checked = false;
                checkBoxJoypad.Checked = false;
                checkBoxJoystickForMS.Checked = false;
                checkBoxKeyboard.Checked = false;
                checkBoxMegaMouse.Checked = false;
                checkBoxPaddleController.Checked = false;
                checkBoxPrinter.Checked = false;
                checkBoxSerialRS232C.Checked = false;
                checkBoxSixButtonJoypad.Checked = false;
                checkBoxTablet.Checked = false;
                checkBoxTeamPlay.Checked = false;

                checkBoxAsia.Checked = false;
                checkBoxBrazil4.Checked = false;
                checkBoxBrazilB.Checked = false;
                checkBoxEurope.Checked = false;
                checkBoxFrance.Checked = false;
                checkBoxHongKong.Checked = false;
                checkBoxJapan.Checked = false;
                checkBoxUSA.Checked = false;

                writeROMToolStripMenuItem.Enabled = true;
                fixChecksumToolStripMenuItem.Enabled = true;
                textBoxFileName.Text = openFileDialog.FileName;
                

                string path = textBoxFileName.Text;
                filepath = path;
                parseROMFile(path);
            }
        }

        private void parseROMFile(string path)
        {
            try
            {
                SegaROMInfo segaROMInfo = new SegaROMInfo(path);
                textBoxConsoleName.Text = segaROMInfo.getConsoleName();

                string firmName = segaROMInfo.getFirmName();
                displayCompanyNameInTextBox(firmName);
                textBoxFirmName.Text = firmName;

                textBoxBuildDate.Text = segaROMInfo.getBuildDate();
                textBoxDomesticName.Text = segaROMInfo.getDomesticName();
                textBoxInternationName.Text = segaROMInfo.getInternationalName();
                textBoxProgramType.Text = segaROMInfo.getProgramType();
                textBoxProgramTypeSimple.Text = segaROMInfo.getProgramTypeSimple();
                textBoxSerialNumber.Text = segaROMInfo.getSerialNumber();
                textBoxVersionNumber.Text = segaROMInfo.getVersionNumber();
                textBoxChecksum.Text = segaROMInfo.getChecksum();
                textBoxFixedChecksum.Text = segaROMInfo.getCorrectedChecksum();
                textBoxCorrectROMSize.Text = segaROMInfo.getCorrectedROMSize();

                string supportedIODevices = segaROMInfo.getIODeviceSupport();
                checkSupportedIODevicesCheckBoxes(supportedIODevices);
                textBoxIODeviceSupport.Text = supportedIODevices;

                textBoxROMStart.Text = segaROMInfo.getROMStart();
                textBoxROMEnd.Text = segaROMInfo.getROMEnd();
                textBoxRAMStart.Text = segaROMInfo.getRAMStart();
                textBoxRAMEnd.Text = segaROMInfo.getRAMEnd();
                textBoxBackupRAMStart.Text = segaROMInfo.getBackupRAMStart();
                textBoxBackupRAMEnd.Text = segaROMInfo.getBackupRAMEnd();
                textBoxModemSupport.Text = segaROMInfo.getModemSupport();
                textBoxNotes.Text = segaROMInfo.getNotes();

                string countryCodes = segaROMInfo.getCountryCodes();
                checkCountryCodeCheckBoxes(countryCodes);
                //displayCountriesInTextBox(countryCodes);
                textBoxCountryCodes.Text = countryCodes;

                validateChecksumAndRomSize();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error reading the ROM: " + ex,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

        }

        private void validateChecksumAndRomSize()
        {
            SegaROMInfo segaROMInfo = new SegaROMInfo(filepath);
            string correctROMEnd = segaROMInfo.getCorrectedROMSize();

            if((textBoxChecksum.Text != textBoxFixedChecksum.Text) || (textBoxROMEnd.Text != correctROMEnd))
            {
                textBoxChecksum.ForeColor = Color.Red;
                //textBoxFixedChecksum.ForeColor = Color.Red;
                textBoxROMEnd.ForeColor = Color.Red;
            }
            else
            {
                textBoxChecksum.ForeColor = Color.Black;
                //textBoxFixedChecksum.ForeColor = Color.Black;
                textBoxROMEnd.ForeColor = Color.Black;
            }
        }

        private void checkCountryCodeCheckBoxes(string countryCodes)
        {
            if(countryCodes.ToLower().Contains("e"))
            {
                checkBoxEurope.Checked = true;
            }

            if(countryCodes.ToLower().Contains("j"))
            {
                checkBoxJapan.Checked = true;
            }

            if(countryCodes.ToLower().Contains("u"))
            {
                checkBoxUSA.Checked = true;
            }

            if(countryCodes.ToLower().Contains("a"))
            {
                checkBoxAsia.Checked = true;
            }

            if(countryCodes.ToLower().Contains("b"))
            {
                checkBoxBrazilB.Checked = true;
            }

            if(countryCodes.ToLower().Contains("4"))
            {
                checkBoxBrazil4.Checked = true;
            }

            if(countryCodes.ToLower().Contains("f"))
            {
                checkBoxFrance.Checked = true;
            }

            if(countryCodes.ToLower().Contains("8"))
            {
                checkBoxHongKong.Checked = true;
            }
        }

        private void displayCompanyNameInTextBox(string firmName)
        {
            string companyName = "";
            if(firmName.ToLower().Contains("acld"))
            {
                companyName = "Ballistic";
            }
            else if(firmName.ToLower().Contains("asci"))
            {
                companyName = "Asciiware";
            }
            else if(firmName.ToLower().Contains("rsi"))
            {
                companyName = "Razorsoft";
            }
            else if(firmName.ToLower().Contains("sega"))
            {
                companyName = "SEGA";
            }
            else if(firmName.ToLower().Contains("trec"))
            {
                companyName = "Treco";
            }
            else if(firmName.ToLower().Contains("vrgn"))
            {
                companyName = "Virgin Games";
            }
            else if(firmName.ToLower().Contains("wstn"))
            {
                companyName = "Westone";
            }
            else if(firmName.ToLower().Contains("t-snk 95-feb"))
            {
                companyName = "HI-TECH entertainment";
            }
            else if(firmName.Contains("100"))
            {
                companyName = "T*HQ Software";
            }
            else if(firmName.Contains("101"))
            {
                companyName = "Tecmagik";
            }
            else if(firmName.Contains("112"))
            {
                companyName = "Designer Software";
            }
            else if(firmName.Contains("113"))
            {
                companyName = "Psygnosis";
            }
            else if(firmName.Contains("119"))
            {
                companyName = "Accolade";
            }
            else if(firmName.Contains("120"))
            {
                companyName = "Code Masters";
            }
            else if(firmName.Contains("125"))
            {
                companyName = "Interplay";
            }
            else if(firmName.Contains("130"))
            {
                companyName = "Activision";
            }
            else if(firmName.Contains("132"))
            {
                companyName = "Shiny & Playmates";
            }
            else if(firmName.Contains("144"))
            {
                companyName = "Atlus";
            }
            else if(firmName.Contains("151") || firmName.ToLower().Contains("infogrames"))
            {
                companyName = "Infogrames";
            }
            else if(firmName.Contains("161"))
            {
                companyName = "Fox Interactive";
            }
            else if(firmName.Contains("239"))
            {
                companyName = "Disney Interactive";
            }
            else if(firmName.Contains("10"))
            {
                companyName = "Takara";
            }
            else if(firmName.Contains("11"))
            {
                companyName = "Taito or Accolade";
            }
            else if(firmName.Contains("12"))
            {
                companyName = "Capcom";
            }
            else if(firmName.Contains("13"))
            {
                companyName = "Data East";
            }
            else if(firmName.Contains("14"))
            {
                companyName = "Namco or Tengen";
            }
            else if(firmName.Contains("15"))
            {
                companyName = "Sunsoft";
            }
            else if(firmName.Contains("16"))
            {
                companyName = "Bandai";
            }
            else if(firmName.Contains("17"))
            {
                companyName = "Dempa";
            }
            else if(firmName.Contains("18"))
            {
                companyName = "Technosoft";
            }
            else if(firmName.Contains("19"))
            {
                companyName = "Technosoft";
            }
            else if(firmName.Contains("20"))
            {
                companyName = "Asmik";
            }
            else if(firmName.Contains("22"))
            {
                companyName = "Micronet";
            }
            else if(firmName.Contains("23"))
            {
                companyName = "Vic Tokai";
            }
            else if(firmName.Contains("24"))
            {
                companyName = "American Sammy";
            }
            else if(firmName.Contains("29"))
            {
                companyName = "Kyugo";
            }
            else if(firmName.Contains("32"))
            {
                companyName = "Wolfteam";
            }
            else if(firmName.Contains("33"))
            {
                companyName = "Kaneko";
            }
            else if(firmName.Contains("35"))
            {
                companyName = "Toaplan";
            }
            else if(firmName.Contains("36"))
            {
                companyName = "Tecmo";
            }
            else if(firmName.Contains("40"))
            {
                companyName = "Toaplan";
            }
            else if(firmName.Contains("42"))
            {
                companyName = "UFL Company Limited";
            }
            else if(firmName.Contains("43"))
            {
                companyName = "Human";
            }
            else if(firmName.Contains("45"))
            {
                companyName = "Game Arts";
            }
            else if(firmName.Contains("47"))
            {
                companyName = "Sage's Creation";
            }
            else if(firmName.Contains("48"))
            {
                companyName = "Tengen";
            }
            else if(firmName.Contains("49"))
            {
                companyName = "Renovation or Telenet";
            }
            else if(firmName.Contains("50"))
            {
                companyName = "Eletronic Arts";
            }
            else if(firmName.Contains("56"))
            {
                companyName = "Razorsoft";
            }
            else if(firmName.Contains("58"))
            {
                companyName = "Mentrix";
            }
            else if(firmName.Contains("60"))
            {
                companyName = "Victor Musical Industries";
            }
            else if(firmName.Contains("69"))
            {
                companyName = "Arena";
            }
            else if(firmName.Contains("70"))
            {
                companyName = "Virgin";
            }
            else if(firmName.Contains("73"))
            {
                companyName = "Soft Vision";
            }
            else if(firmName.Contains("74"))
            {
                companyName = "Palsoft";
            }
            else if(firmName.Contains("76"))
            {
                companyName = "Koei";
            }
            else if(firmName.Contains("79"))
            {
                companyName = "U.S. Gold";
            }
            else if(firmName.Contains("81"))
            {
                companyName = "Acclaim/Flying Edge";
            }
            else if(firmName.Contains("83"))
            {
                companyName = "Gametek";
            }
            else if(firmName.Contains("86"))
            {
                companyName = "Absolute";
            }
            else if(firmName.Contains("93"))
            {
                companyName = "Sony";
            }
            else if(firmName.Contains("95"))
            {
                companyName = "Konami";
            }
            else if(firmName.Contains("97"))
            {
                companyName = "Tradewest";
            }
            else
            {
                companyName = "NOT FOUND";
            }

            textBoxCompanyName.Text = companyName;
        }

        //private void displayCountriesInTextBox(string countryCodes)
        //{
        //    string countryCodesSimple = "";

        //    if(countryCodes.ToLower().Contains("e"))
        //    {
        //        countryCodesSimple += "Europe, ";
        //    }

        //    if(countryCodes.ToLower().Contains("j"))
        //    {
        //        countryCodesSimple += "Japan, ";
        //    }

        //    if(countryCodes.ToLower().Contains("u"))
        //    {
        //        countryCodesSimple += "USA, ";
        //    }

        //    if(countryCodes.ToLower().Contains("a"))
        //    {
        //        countryCodesSimple += "Asia, ";
        //    }

        //    if(countryCodes.ToLower().Contains("b") || countryCodes.ToLower().Contains("4"))
        //    {
        //        countryCodesSimple += "Brazil, ";
        //    }

        //    if(countryCodes.ToLower().Contains("f"))
        //    {
        //        countryCodesSimple += "France, ";
        //    }

        //    if(countryCodes.ToLower().Contains("8"))
        //    {
        //        countryCodesSimple += "Hong Kong, ";
        //    }

        //    countryCodesSimple = countryCodesSimple.TrimEnd(' ');
        //    textBoxCountryCodesSimple.Text = countryCodesSimple.TrimEnd(',');
        //}

        private void checkSupportedIODevicesCheckBoxes(string supportedIODevices)
        {
            if(supportedIODevices.ToLower().Contains("j"))
            {
                checkBoxJoypad.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("6"))
            {
                checkBoxSixButtonJoypad.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("k"))
            {
                checkBoxKeyboard.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("p"))
            {
                checkBoxPrinter.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("b"))
            {
                checkBoxControlBall.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("f"))
            {
                checkBoxFloppyDiskDrive.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("l"))
            {
                checkBoxActivator.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("4"))
            {
                checkBoxTeamPlay.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("0"))
            {
                checkBoxJoystickForMS.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("r"))
            {
                checkBoxSerialRS232C.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("t"))
            {
                checkBoxTablet.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("v"))
            {
                checkBoxPaddleController.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("c"))
            {
                checkBoxCDROM.Checked = true;
            }

            if(supportedIODevices.ToLower().Contains("m"))
            {
                checkBoxMegaMouse.Checked = true;
            }
        }

        private void updateSupportedIODevicesTextBox()
        {
            textBoxIODeviceSupport.Clear();
            string updatedIODeviceSupport = "";

            if(checkBoxJoypad.Checked)
            {
                updatedIODeviceSupport += "J";
            }

            if(checkBoxSixButtonJoypad.Checked)
            {
                updatedIODeviceSupport += "6";
            }

            if(checkBoxKeyboard.Checked)
            {
                updatedIODeviceSupport += "K";
            }

            if(checkBoxPrinter.Checked)
            {
                updatedIODeviceSupport += "P";
            }

            if(checkBoxControlBall.Checked)
            {
                updatedIODeviceSupport += "B";
            }

            if(checkBoxFloppyDiskDrive.Checked)
            {
                updatedIODeviceSupport += "F";
            }

            if(checkBoxActivator.Checked)
            {
                updatedIODeviceSupport += "L";
            }

            if(checkBoxTeamPlay.Checked)
            {
                updatedIODeviceSupport += "4";
            }

            if(checkBoxJoystickForMS.Checked)
            {
                updatedIODeviceSupport += "0";
            }

            if(checkBoxSerialRS232C.Checked)
            {
                updatedIODeviceSupport += "R";
            }

            if(checkBoxTablet.Checked)
            {
                updatedIODeviceSupport += "T";
            }

            if(checkBoxPaddleController.Checked)
            {
                updatedIODeviceSupport += "V";
            }

            if(checkBoxCDROM.Checked)
            {
                updatedIODeviceSupport += "C";
            }

            if(checkBoxMegaMouse.Checked)
            {
                updatedIODeviceSupport += "M";
            }

            textBoxIODeviceSupport.Text = updatedIODeviceSupport;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox = new AboutBox1();
            aboutbox.ShowDialog();
        }

        private void writeROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = textBoxFileName.Text;
            SegaROMInfo segaROMInfo = new SegaROMInfo(path);

            // these are written as bytes
            string newChecksum = textBoxChecksum.Text.ToUpper();
            string newROMStart = textBoxROMStart.Text.ToUpper();
            string newROMEnd = textBoxROMEnd.Text.ToUpper();
            string newRAMStart = textBoxRAMStart.Text.ToUpper();
            string newRAMEnd = textBoxRAMEnd.Text.ToUpper();
            string newBackupRAMStart = textBoxBackupRAMStart.Text.ToUpper();
            string newBackupRAMEnd = textBoxBackupRAMEnd.Text.ToUpper();

            // these are written as ascii
            string newConsoleName = textBoxConsoleName.Text.ToUpper();
            string newFirmName = textBoxFirmName.Text.ToUpper();
            string newBuildDate = textBoxBuildDate.Text.ToUpper();
            string newDomesticName = textBoxDomesticName.Text.ToUpper();
            string newInternationalName = textBoxInternationName.Text.ToUpper();
            string newProgramType = textBoxProgramType.Text.ToUpper();
            string newSerialNumber = textBoxSerialNumber.Text.ToUpper();
            string newVersionNumber = textBoxVersionNumber.Text.ToUpper();
            string newIODeviceSupport = textBoxIODeviceSupport.Text.ToUpper();
            string newModemSupport = textBoxModemSupport.Text.ToUpper();
            string newNotes = textBoxNotes.Text.ToUpper();
            string newCountryCodes = textBoxCountryCodes.Text.ToUpper();

            bool result1 = segaROMInfo.setChecksum(newChecksum);
            bool result2 = segaROMInfo.setROMStart(newROMStart);
            bool result3 = segaROMInfo.setROMEnd(newROMEnd);
            bool result4 = segaROMInfo.setRAMStart(newRAMStart);
            bool result5 = segaROMInfo.setRAMEnd(newRAMEnd);
            bool result6 = segaROMInfo.setBackupRAMStart(newBackupRAMStart);
            bool result7 = segaROMInfo.setBackupRAMEnd(newBackupRAMEnd);
            bool result8 = segaROMInfo.setConsoleName(newConsoleName);
            bool result9 = segaROMInfo.setFirmName(newFirmName);
            bool result10 = segaROMInfo.setBuildDate(newBuildDate);
            bool result11 = segaROMInfo.setDomesticName(newDomesticName);
            bool result12 = segaROMInfo.setInternationName(newInternationalName);
            bool result13 = segaROMInfo.setProgramType(newProgramType);
            bool result14 = segaROMInfo.setSerialNumber(newSerialNumber);
            bool result15 = segaROMInfo.setVersionNumber(newVersionNumber);
            bool result16 = segaROMInfo.setIODeviceSupport(newIODeviceSupport);
            bool result17 = segaROMInfo.setModemSupport(newModemSupport);
            bool result18 = segaROMInfo.setNotes(newNotes);
            bool result19 = segaROMInfo.setCountryCodes(newCountryCodes);

            #region errorMessage
            if(!result1 || !result2 || !result3 || !result4 || !result5 || !result6 || !result7 || !result8 || !result9 || !result10 || !result11 || !result12 || !result13 || !result14
                 || !result15 || !result16 || !result17 || !result18 || !result19)
            {
                string errorMsg = "Unable to update: ";

                if(!result1)
                {
                    errorMsg += "Checksum, ";
                }

                if(!result2)
                {
                    errorMsg += "ROMStart, ";
                }

                if(!result3)
                {
                    errorMsg += "ROMEnd, ";
                }

                if(!result4)
                {
                    errorMsg += "RAMStart, ";
                }

                if(!result5)
                {
                    errorMsg += "RAMEnd, ";
                }

                if(!result6)
                {
                    errorMsg += "BackupRAMStart, ";
                }

                if(!result7)
                {
                    errorMsg += "BackupRAMEnd, ";
                }

                if(!result8)
                {
                    errorMsg += "ConsoleName, ";
                }

                if(!result9)
                {
                    errorMsg += "FirmName, ";
                }

                if(!result10)
                {
                    errorMsg += "BuildDate, ";
                }

                if(!result11)
                {
                    errorMsg += "DomesticName, ";
                }

                if(!result12)
                {
                    errorMsg += "InternationName, ";
                }

                if(!result13)
                {
                    errorMsg += "ProgramType, ";
                }

                if(!result14)
                {
                    errorMsg += "SerialNumber, ";
                }

                if(!result15)
                {
                    errorMsg += "VersionNumber, ";
                }

                if(!result16)
                {
                    errorMsg += "IODeviceSupport, ";
                }

                if(!result17)
                {
                    errorMsg += "ModemSupport, ";
                }

                if(!result18)
                {
                    errorMsg += "Notes, ";
                }

                if(!result19)
                {
                    errorMsg += "CountryCodes, ";
                }

                errorMsg = errorMsg.TrimEnd(' ');
                errorMsg = errorMsg.TrimEnd(',');

                MessageBox.Show("There was a problem updating the ROM header. " + errorMsg + ".",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("ROM header updated!.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
            #endregion

            parseROMFile(path);
        }

        #region Country Code CheckBox Handlers
        private void checkBoxEurope_CheckedChanged(object sender, EventArgs e)
        {
            if(validateCountryCodeCheckBoxes(checkBoxEurope))
            {
                updateCountryCodesTextBox();
            }
        }

        private void checkBoxJapan_CheckedChanged(object sender, EventArgs e)
        {
            if(validateCountryCodeCheckBoxes(checkBoxJapan))
            {
                updateCountryCodesTextBox();
            }
        }

        private void checkBoxUSA_CheckedChanged(object sender, EventArgs e)
        {
            if(validateCountryCodeCheckBoxes(checkBoxUSA))
            {
                updateCountryCodesTextBox();
            }
        }

        private void checkBoxAsia_CheckedChanged(object sender, EventArgs e)
        {
            if(validateCountryCodeCheckBoxes(checkBoxAsia))
            {
                updateCountryCodesTextBox();
            }
        }

        private void checkBoxBrazilB_CheckedChanged(object sender, EventArgs e)
        {
            if(validateCountryCodeCheckBoxes(checkBoxBrazilB))
            {
                updateCountryCodesTextBox();
            }
        }

        private void checkBoxBrazil4_CheckedChanged(object sender, EventArgs e)
        {
            if(validateCountryCodeCheckBoxes(checkBoxBrazil4))
            {
                updateCountryCodesTextBox();
            }
        }

        private void checkBoxFrance_CheckedChanged(object sender, EventArgs e)
        {
            if(validateCountryCodeCheckBoxes(checkBoxFrance))
            {
                updateCountryCodesTextBox();
            }
        }

        private void checkBoxHongKong_CheckedChanged(object sender, EventArgs e)
        {
            if(validateCountryCodeCheckBoxes(checkBoxHongKong))
            {
                updateCountryCodesTextBox();
            }
        }
        #endregion

        public void validateHexInput(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar >= 'A' && e.KeyChar <= 'F' || e.KeyChar >= 'a' && e.KeyChar <= 'f' || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void updateCountryCodesTextBox()
        {
            textBoxCountryCodes.Clear();
            string updatedCountryCodes = "";

            if(checkBoxJapan.Checked)
            {
                updatedCountryCodes += "J";
            }

            if(checkBoxUSA.Checked)
            {
                updatedCountryCodes += "U";
            }

            if(checkBoxEurope.Checked)
            {
                updatedCountryCodes += "E";
            }

            if(checkBoxAsia.Checked)
            {
                updatedCountryCodes += "A";
            }

            if(checkBoxBrazilB.Checked)
            {
                updatedCountryCodes += "B";
            }

            if(checkBoxBrazil4.Checked)
            {
                updatedCountryCodes += "4";
            }

            if(checkBoxFrance.Checked)
            {
                updatedCountryCodes += "F";
            }

            if(checkBoxHongKong.Checked)
            {
                updatedCountryCodes += "8";
            }

            textBoxCountryCodes.Text = updatedCountryCodes;
        }

        private bool validateCountryCodeCheckBoxes(CheckBox lastCheckedCheckBox)
        {
            // Only 3 checkboxes can be checked at a time.
            int numberOfCheckBoxesChecked = 0;

            if(checkBoxEurope.Checked)
            {
                numberOfCheckBoxesChecked++;
            }

            if(checkBoxJapan.Checked)
            {
                numberOfCheckBoxesChecked++;
            }

            if(checkBoxUSA.Checked)
            {
                numberOfCheckBoxesChecked++;
            }

            if(checkBoxAsia.Checked)
            {
                numberOfCheckBoxesChecked++;
            }

            if(checkBoxBrazilB.Checked)
            {
                numberOfCheckBoxesChecked++;
            }

            if(checkBoxBrazil4.Checked)
            {
                numberOfCheckBoxesChecked++;
            }

            if(checkBoxFrance.Checked)
            {
                numberOfCheckBoxesChecked++;
            }

            if(checkBoxHongKong.Checked)
            {
                numberOfCheckBoxesChecked++;
            }

            if(numberOfCheckBoxesChecked > 3)
            {
                MessageBox.Show("Only 3 country codes can be selected.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);

                lastCheckedCheckBox.Checked = false;
                return false;
            }
            return true;
        }

        #region Support IO Devices CheckBox Handlers
        private void checkBoxJoypad_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxSixButtonJoypad_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxPrinter_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxControlBall_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxTeamPlay_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxJoystickForMS_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxSerialRS232C_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxTablet_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxPaddleController_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxActivator_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxMegaMouse_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxFloppyDiskDrive_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }

        private void checkBoxCDROM_CheckedChanged(object sender, EventArgs e)
        {
            updateSupportedIODevicesTextBox();
        }
        #endregion

        private void fixChecksumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SegaROMInfo segaROMInfo = new SegaROMInfo(filepath);
            string correctedChecksum = segaROMInfo.getCorrectedChecksum();
            textBoxFixedChecksum.Text = correctedChecksum;
            textBoxChecksum.Text = correctedChecksum;
            string correctROMEnd = segaROMInfo.getCorrectedROMSize();
            textBoxROMEnd.Text = correctROMEnd;

            bool result1 = segaROMInfo.setChecksum(correctedChecksum);
            bool result2 = segaROMInfo.setROMEnd(correctROMEnd);

            if(result1 && result2)
            {
                MessageBox.Show("Checksum fixed!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("There was a problem fixing the checksum.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

            validateChecksumAndRomSize();
        }
    }
}
