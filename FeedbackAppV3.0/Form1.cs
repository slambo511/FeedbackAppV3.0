﻿using System;
using System.Data;
using System.Data.Sql;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using static FeedbackAppV3._0.Crypto;

namespace FeedbackAppV3._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestEncryption_Click(object sender, EventArgs e)
        {
            var original = "Here is some data to encrypt";

            using (var myRijndael = new RijndaelManaged())
            {

                myRijndael.GenerateKey();
                myRijndael.GenerateIV();
                // Encrypt the message
                var encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);
                // Decrypt the message
                var roundTrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);
                // Show the process
                MessageBox.Show(@"Original: " + original);
                var message = "";
                var keyMessage = "";
                var IVMessage = "";
                foreach (var character in encrypted)
                {
                    message += character;
                }

                foreach (var keyPart in myRijndael.Key)
                {
                    keyMessage += keyPart;
                }

                foreach (var IVPart in myRijndael.IV)
                {
                    IVMessage += IVPart;
                }

                MessageBox.Show(@"Key: " + keyMessage);
                MessageBox.Show(@"IV: " + IVMessage);
                MessageBox.Show(@"Encrypted Message: " + message);
                MessageBox.Show(@"Round Trip: " + roundTrip);
            }
        }

        private void btnTestDB_Click(object sender, EventArgs e)
        {
            var server = new Server("DESKTOP-T74VM4I");

            // Get remote SQL Server instances
            var dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow dr in dt.Rows)
            {
                cboIntances.Items.Add(string.Concat(dr["ServerName"], @"\", dr["InstanceName"]));
            }

            // Get local SQL serve instances, including default one which appears as blank normally
            var registryViewArray = new[] {RegistryView.Registry32, RegistryView.Registry64};
            foreach (var registryView in registryViewArray)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server"))
                {
                    var instances = (string[]) key?.GetValue("InstalledInstances");
                    if (instances != null)
                    {
                        foreach (var element in instances)
                        {
                            if (element == "MSSQLSERVER")
                                cboIntances.Items.Add(Environment.MachineName);
                            else
                                cboIntances.Items.Add(Environment.MachineName + @"\\" + element);
                        }
                    }
                }
            }

            foreach (Database db in server.Databases)
                {
                    cboTables.Items.Add(db.Name);
                }

        }
    }
}
