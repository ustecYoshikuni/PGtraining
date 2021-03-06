﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static PGtraining.Lib.Log.LogLeverl;

namespace PGtraining.Lib.Log
{
    public class Log
    {
        public int LogLevel = 4;
        public List<string> StockData = new List<string>();

        public Log()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public void Write(string text, LevelEnum level, string outFolderPath)
        {
            var filePath = $"{outFolderPath}\\Log_{DateTime.Now.ToString("yyyyMMdd")}.log";

            ; if (LogLevel <= (int)level) return;

            var message = $"{DateTime.Now}  【{level.ToString()}】:{ text}";

            try
            {
                using (var sw = new StreamWriter(filePath, true, System.Text.Encoding.GetEncoding("Shift_JIS")))
                {
                    if (0 < this.StockData.Count)
                    {
                        try
                        {
                            Console.SetOut(sw);
                            Console.WriteLine(string.Join($"{Environment.NewLine}", this.StockData));
                            this.StockData.Clear();
                        }
                        catch (Exception)
                        {
                        }
                    }

                    Console.SetOut(sw);
                    Console.WriteLine(message);
                }
            }
            catch (Exception)
            {
                this.StockData.Add(message);
            }
        }
    }
}