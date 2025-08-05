using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;

namespace PangyaUccViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string loadedFilename = string.Empty;
        private Bitmap bmpBack;
        private Bitmap bmpFront;
        private MemoryStream iconStream;
        private int[] bmpDimensions;
        private int bytesToRead = 4;
        private int[] bmpSize;
        
        private int[] wndDimension;
        private int[] gb1Dimension;
        private int[] gb2Dimension;

        private Bitmap GetBitmapFromUccFile(MemoryStream uccFile)
        {
            bmpSize = new int[2];

            BinaryReader binaryReader = new BinaryReader(uccFile);

            /* Standard 128x128 textures */
            if(uccFile.Length == 65536)
            {
                bmpSize[0] = 128;
                bmpSize[1] = 128;                
            }
            /* Support for 256x256 textures */
            else if(uccFile.Length == 196608 || uccFile.Length == 262144)
            {
                bmpSize[0] = 256;
                bmpSize[1] = 256;
            }
            /* Fallback: Assume 128x128 */
            else
            {
                bmpSize[0] = 128;
                bmpSize[1] = 128;
            }

            this.Width = wndDimension[0] + ((bmpSize[0] - 128) * 2);
            this.Height = wndDimension[1] + (bmpSize[1] - 128);

            groupBox1.Width = gb1Dimension[0] + (bmpSize[0] - 128);
            groupBox1.Height = gb1Dimension[1] + (bmpSize[1] - 128);

            groupBox2.Width = gb2Dimension[0] + (bmpSize[0] - 128);
            groupBox2.Height = gb2Dimension[1] + (bmpSize[1] - 128);
            groupBox2.Left = gb2Dimension[2] + (bmpSize[0] - 128);

            long fileSize = uccFile.Length;
            int curPos = 0;

            int x = 0;
            int y = 0;

            Bitmap ucc = new Bitmap(bmpSize[0], bmpSize[1]);

            while (curPos < fileSize)
            {
                byte[] currentPixel = binaryReader.ReadBytes(bytesToRead);
                curPos += bytesToRead;

                // Construct the color from the bytes we just read...
                Color c = Color.Black;

                if (bytesToRead == 4)
                    c = Color.FromArgb(currentPixel[3], currentPixel[2], currentPixel[1], currentPixel[0]);
                else
                    c = Color.FromArgb(255, currentPixel[2], currentPixel[1], currentPixel[0]);

                // Draw the pixel...
                ucc.SetPixel(x, y, c);

                // And set the new position on the canvas
                x++;

                if (x > (bmpSize[0] - 1))
                {
                    x = 0;
                    y++;
                }
            }

            bmpDimensions = new int[2];

            // Correct before saving...
            if (x == 0)
                x = bmpSize[0];

            // Store for saving...
            bmpDimensions[0] = x;
            bmpDimensions[1] = y;

            // Because we didn't know how large the bitmap was before,
            // we'll create a new one and copy the old one onto it...
            Bitmap ucc_realsize = new Bitmap(x, y);
            Graphics g = Graphics.FromImage(ucc_realsize);
            g.DrawImageUnscaled(ucc, 0, 0);

            return ucc_realsize;
        }

        private MemoryStream CreateUccFileFromBitmap(Bitmap bitmap)
        {
            int x = 0;
            int y = 0;

            MemoryStream fileStream = new MemoryStream();

            while (y < bmpDimensions[1])
            {
                Color currentPixel = bitmap.GetPixel(x, y);

                fileStream.WriteByte(currentPixel.B);
                fileStream.WriteByte(currentPixel.G);
                fileStream.WriteByte(currentPixel.R);

                if (bytesToRead == 4)
                    fileStream.WriteByte(currentPixel.A);

                x++;

                if (x > (bmpSize[0] - 1))
                {
                    x = 0;
                    y++;
                }
            }

            fileStream.Seek(0, SeekOrigin.Begin);

            return fileStream;
        }

        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Pangya! UCC File";
            openFileDialog.Filter = "Pangya! UCC File|*.jpg";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                OpenFile(openFileDialog.FileName);
            }
        }

        private void OpenFile(string fileName)
        {
            if (ZipFile.IsZipFile(fileName))
            {
                MemoryStream frontStream = new MemoryStream();
                MemoryStream backStream = new MemoryStream();

                // Reset indicator before processing the new file...
                bytesToRead = 4;

                using (ZipFile zip = ZipFile.Read(fileName))
                {
                    foreach (ZipEntry z in zip)
                    {
                        if (z.FileName == "back")
                        {
                            MemoryStream ms = new MemoryStream();
                            z.Extract(ms);
                            ms.Seek(0, SeekOrigin.Begin);

                            backStream = ms;
                        }

                        if (z.FileName == "front")
                        {
                            MemoryStream ms = new MemoryStream();
                            z.Extract(ms);
                            ms.Seek(0, SeekOrigin.Begin);

                            frontStream = ms;
                        }

                        // Make sure to also read the icon for saving...
                        if (z.FileName == "icon")
                        {
                            bytesToRead = 3;
                            iconStream = new MemoryStream();
                            z.Extract(iconStream);
                            iconStream.Seek(0, SeekOrigin.Begin);
                        }
                    }
                }

                bmpFront = GetBitmapFromUccFile(frontStream);

                bmpBack = GetBitmapFromUccFile(backStream);

                picFront.Image = bmpFront;
                picBack.Image = bmpBack;

                lblLoadedFile.Text = fileName;
                loadedFilename = fileName;
            }
        }

        private void tsbSaveFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(loadedFilename))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save Pangya! UCC File";
                saveFileDialog.Filter = "Pangya! UCC Files|*.jpg";
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Delete old file, just to be sure...
                    if (File.Exists(saveFileDialog.FileName))
                        File.Delete(saveFileDialog.FileName);

                    using (ZipFile zip = new ZipFile(saveFileDialog.FileName))
                    {
                        zip.CompressionLevel = CompressionLevel.BestCompression;

                        zip.AddEntry("front", CreateUccFileFromBitmap(bmpFront));
                        zip.AddEntry("back", CreateUccFileFromBitmap(bmpBack));

                        // If it's a final UCC, also save the unmodified icon
                        if (bytesToRead == 3)
                            zip.AddEntry("icon", iconStream);

                        zip.Save();
                    }
                    MessageBox.Show("UCC File written!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please load a file first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void tsbExportPng_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(loadedFilename))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Select a path to save the PNGs";
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string fileNamePrefix = Path.GetFileNameWithoutExtension(loadedFilename);
                    bmpFront.Save(folderBrowserDialog.SelectedPath + Path.DirectorySeparatorChar + fileNamePrefix + "_front.png", ImageFormat.Png);
                    bmpBack.Save(folderBrowserDialog.SelectedPath + Path.DirectorySeparatorChar + fileNamePrefix + "_back.png", ImageFormat.Png);
                    MessageBox.Show("Done!", "Woot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please load a file first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void tsbImportPng_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(loadedFilename))
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Select the path that contains the PNGs to import";
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string fileNamePrefix = Path.GetFileNameWithoutExtension(loadedFilename);

                    if (File.Exists(folderBrowserDialog.SelectedPath + Path.DirectorySeparatorChar + fileNamePrefix + "_front.png") &&
                        File.Exists(folderBrowserDialog.SelectedPath + Path.DirectorySeparatorChar + fileNamePrefix + "_back.png"))
                    {
                        bmpFront = new Bitmap(folderBrowserDialog.SelectedPath + Path.DirectorySeparatorChar + fileNamePrefix + "_front.png");
                        if (bytesToRead == 4)
                            bmpFront.MakeTransparent();

                        bmpBack = new Bitmap(folderBrowserDialog.SelectedPath + Path.DirectorySeparatorChar + fileNamePrefix + "_back.png");
                        if (bytesToRead == 4)
                            bmpBack.MakeTransparent();

                        picFront.Image = bmpFront;
                        picBack.Image = bmpBack;
                    }
                    else
                    {
                        MessageBox.Show("Required files not found. Please export the PNGs first and do not rename them!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please load a file first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            wndDimension = new int[2];
            wndDimension[0] = this.Width;
            wndDimension[1] = this.Height;

            gb1Dimension = new int[3];
            gb1Dimension[0] = groupBox1.Width;
            gb1Dimension[1] = groupBox1.Height;
            gb1Dimension[2] = groupBox1.Left;

            gb2Dimension = new int[3];
            gb2Dimension[0] = groupBox2.Width;
            gb2Dimension[1] = groupBox2.Height;
            gb2Dimension[2] = groupBox2.Left;
        }
    }
}
