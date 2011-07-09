﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cosmos.Cosmos_VS_Windows
{
    /// <summary>
    /// Interaction logic for StackUC.xaml
    /// </summary>
    public partial class StackUC : UserControl
    {
        public StackUC()
        {
            InitializeComponent();
        }

        public void UpdateFrame(byte[] aData)
        {
            int xOffset = 0;
            string xData = BitConverter.ToString(aData);
            xData = xData.Trim();
            xData = xData.Replace("-", "");
            if (xData.Length == 256)
            {
                for (int i = 0; i < 256; i += 8)
                {
                    string xTemp = xData.Substring(i, 8);
                    tboxSourceFrame.Text += ("EBP + " + xOffset.ToString() + " : " + xTemp + "\n");
                    xOffset += 4;
                }
            }
            else tboxSourceFrame.Text = "Error loading the frame.";
        }

        public void UpdateStack(byte[] aData)
        {
            int xOffset = -124;
            string xData = BitConverter.ToString(aData);
            xData = xData.Trim();
            xData = xData.Replace("-", "");
            if (xData.Length == 256)
            {
                for (int i = 0; i < 256; i += 8)
                {
                    string xTemp = xData.Substring(i, 8);
                    tboxSourceStack.Text += ("EBP + " + xOffset.ToString() + " : " + xTemp + "\n");
                    xOffset += 4;
                }
            }
            else tboxSourceStack.Text = "Error loading the stack.";
        }
    }
}