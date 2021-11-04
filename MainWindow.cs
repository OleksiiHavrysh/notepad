﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace notepad
{
	public partial class MainWindow : Form
	{
		string filePath = "";

		public MainWindow()
		{
			InitializeComponent();
		}


		private void New_Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
		}

		private void Open_Click(object sender, EventArgs e)
		{
			/*if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
			}*/
			openFileDialog1.Filter = "txt files (*.txt)|*.txt";
			try
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)

				{

					filePath = openFileDialog1.FileName;
					richTextBox1.Text = File.ReadAllText(filePath);
				}
			}
			catch
			{
				MessageBox.Show("Error Reading of TXT-File!");
			}
		}

		private void Save_Click(object sender, EventArgs e)
		{
			if(filePath == "")
			{
				SaveAs_Click(sender, e);
			}
			else
			{
				File.WriteAllText(filePath, richTextBox1.Text);
			}
		}

		private void SaveAs_Click(object sender, EventArgs e)
		{
			//saveFileDialog1.DefaultExt = ".txt";
			saveFileDialog1.Filter = "txt files (*.txt)|*.txt";//|PDF file|*.pdf|Word File|*.doc
			try
			{
				DialogResult dr = saveFileDialog1.ShowDialog();
				if (dr == DialogResult.OK)
				{
					filePath = saveFileDialog1.FileName;
					File.WriteAllText(filePath, richTextBox1.Text);
				}
			}
			catch
			{
				MessageBox.Show("Error Reading of TXT-File!");
			}
		}
	}
}