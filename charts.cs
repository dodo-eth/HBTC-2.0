using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions; 
using Newtonsoft.Json; 
using System.Diagnostics;
using System.Drawing;
using ScottPlot;
using ScottPlot.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net; 
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading; 
using Telegram.Bot;
using Telegram.Bot.Args; 
using System.Globalization;
using System.Timers; 

namespace HBTC_linux
{
    class charts
    {
        public static int count_name_file = 0;
        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            return origin.AddSeconds(timestamp);

        }
       public static string chart(string pair)
        {
            List<string> pena = new List<string>();
            System.Net.WebClient wc1 = new System.Net.WebClient();
            int sum_chart = 150;
            double last_price=0;
            String link_Response = wc1.DownloadString("https://api.hbtc.com/openapi/quote/v1/klines?symbol="+ pair + "&interval=15m&limit=" + sum_chart);
             
            MatchCollection matchList = System.Text.RegularExpressions.Regex.Matches(link_Response, @"(\d+.\d+)|\d+\d+|\d");
            pena = matchList.Cast<Match>().Select(match => match.Value).ToList();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
  
            int count = 0;
            int count_draw = 0;
            //Оишбка в апи hbc в конце несколкьо нулей 0 0 0 0 0
            //введен костыль-переменная 
            ScottPlot.OHLC[] ohlcs = new ScottPlot.OHLC[sum_chart];
            var plt = new ScottPlot.Plot(800, 400);
            for (int i = 0; i < sum_chart; i++)
            {
                double Open = Convert.ToDouble(pena[count_draw + 1]);
                double High = Convert.ToDouble(pena[count_draw + 2]);
                double Low = Convert.ToDouble(pena[count_draw + 3]);
                double Close = Convert.ToDouble(pena[count_draw + 4]);
                double Opentime = ((Convert.ToDouble(pena[count_draw])) / 1000) + (3600 * 3);

                ohlcs[count] = new ScottPlot.OHLC(Open, High, Low, Close, ConvertFromUnixTimestamp(Opentime), 1);
                count_draw = count_draw + 11;
                count++;
                last_price = Close;
            }
            
            plt.Title("15 Minute Chart");
            plt.YLabel("Stock Price ("+ pair + ")");
            plt.Ticks(dateTimeX: true, dateTimeFormatStringX: "HH:mm:ss", numericFormatStringY: "n");
            plt.PlotCandlestick(ohlcs);
            plt.Style(tick: Color.White, label: Color.White, title: Color.White, dataBg: Color.FromArgb(255, 36, 43, 60), grid: Color.FromArgb(255, 36, 43, 60), figBg: Color.FromArgb(255, 36, 43, 60));
            DateTime date1 = new DateTime();
            date1 = DateTime.Now;

            string name = "PlotTypes"+ pair +"№"+ date1.Ticks + ".png"; 
          
            string name_file = name;
            string label_name = Convert.ToString(last_price);
            plt.PlotHLine(y: last_price, color: Color.Green, lineWidth: 0.5, label: label_name);
            plt.Legend(backColor: Color.FromArgb(255, 36, 43, 60),location: legendLocation.upperCenter);



            plt.SaveFig(name_file);

           

            return name_file;
        }
    }
}
