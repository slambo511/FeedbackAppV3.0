﻿#region UsingDirectives

using System;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.Win32;
using static FeedbackAppV3._0.Crypto;

#endregion UsingDirectives

namespace FeedbackAppV3._0
{
    public partial class Form1 : Form
    {

        #region Form Initialiser

        public Form1()
        {
            InitializeComponent();
        }

#endregion Form Initialiser 

        #region Test Encryption

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
                var ivMessage = "";
                foreach (var character in encrypted)
                {
                    message += character;
                }

                foreach (var keyPart in myRijndael.Key)
                {
                    keyMessage += keyPart;
                }

                foreach (var ivPart in myRijndael.IV)
                {
                    ivMessage += ivPart;
                }

                MessageBox.Show(@"Key: " + keyMessage);
                MessageBox.Show(@"IV: " + ivMessage);
                MessageBox.Show(@"Encrypted Message: " + message);
                MessageBox.Show(@"Round Trip: " + roundTrip);
            }
        }

        #endregion Test Encryption

        #region testDB Button Handler

        private void btnTestDB_Click(object sender, EventArgs e)
        {
            FindSqlServers();
        }

        #endregion testDB Button Handler

        #region btnTestDBExists Button Handler

        private void btnTestDBExists_Click(object sender, EventArgs e)
        {
            var check = false;
            foreach (var listItem in cboTables.Items)
            {
                if (listItem.ToString() == "feedbackDB")
                {
                    check = true;
                }
            }

            MessageBox.Show(check ? @"Table exists." : @"Table does not exist.");
        }

        #endregion btnTestDBExists Button Handler

        #region btnChooseThisServer Button Handler

        private void btnChooseThisServer_Click(object sender, EventArgs e)
        {
            // add chosen SQL Server instance to app.config.
            //if (cboIntances.Text == null) return;
            //var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(@"Saving " + cboIntances.Text + @" to app.config.");
            //config.AppSettings.Settings["SQLServerInstance"].Value = cboIntances.Text;
            //config.Save();

            if (!CheckSqlExists()) return;
            var filePath = Path.GetFullPath("settings.app.config");

            var map = new ExeConfigurationFileMap {ExeConfigFilename = filePath};
            try
            {
                // Open App.Config of executable
                var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                // Add an Application Setting if not exist

                config.AppSettings.Settings.Add("SQLServer", cboIntances.Text);

                // Save the changes in App.config file.
                config.Save(ConfigurationSaveMode.Modified);

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
                MessageBox.Show(@"Added");
            }
            catch (ConfigurationErrorsException ex)
            {
                if (ex.BareMessage == "Root element is missing.")
                {
                    File.Delete(filePath);
                    return;
                }

                MessageBox.Show(ex.Message);
            }
        }

        #endregion btnChooseThisServer Button Handler

        #region Form Load Handler

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        #endregion Form Load Handler

        #region Subroutine FindSqlServers Handler

        private void FindSqlServers()
        {
            // Get remote SQL Server instances
            var dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow dr in dt.Rows)
            {
                cboIntances.Items.Add(string.Concat(dr["ServerName"], @"\", dr["InstanceName"]));
            }

            // Get local SQL serve instances, including default one which appears as blank normally
            var registryViewArray = new[] { RegistryView.Registry32, RegistryView.Registry64 };
            foreach (var registryView in registryViewArray)
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server"))
                {
                    var instances = (string[])key?.GetValue("InstalledInstances");
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

            var server = new Server(cboIntances.Items[0].ToString());

            foreach (Database db in server.Databases)
            {
                cboTables.Items.Add(db.Name);
            }

        }

        #endregion Subroutine FindSqlServers Handler

        #region Function (bool)CheckSqlExists Handler

        private bool CheckSqlExists()
        {
            // Check key exists in settings.app.config
            var s = ConfigurationManager.AppSettings["SqlServer"];
            if (!string.IsNullOrEmpty(s))
            {
                // Key Exists
                return true;
            }
            else
            {
                // Key does not exist
                return false;
            }
        }

        #endregion Function (bool)CheckSqlExists Handler

    }
}
