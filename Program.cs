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
    class Program
    {  
        static public string link_pars = null;
        static public string link_new = null;
        static public string link_New_Listings = null;
        static public string link_New_Listings_new = null;
        static public string link_Notice = null;
        static public string link_Notice_new = null;
        static public string link_Others = null;
        static public string link_Others_new = null;

        static public int count = 0;
        static public int count1 = 0;
        static public int count2 = 0;
        static public int count3 = 0; 
        private static System.Timers.Timer aTimer;

        //test
        //-1001159086291

        // Команда HBTC RU
        // -1001406705730 

        // HBTC Russia
        //-1001466544027

        // HBTC oficial
        //-1001284050118
        static public long test = -1001159086291;
        static public long chat_id_team = -1001406705730;
        static public long chat_id_ru_chat= -1001466544027;
        static public long chat_id_eng_off= -1001284050118;
        static public long HBTCIndonesia_chat = -1001474077561;
        static public long HBTCHBTCJapan_chat = -1001281216258;
        static public long HBTCHBTCKorean_chat = -1001355441140;
        static public long HBTCHBTCTurkey_chat = -1001373911208;
        static public long ginance_chat = -1001435475314;
        static public long forward_chat = -1001444262173;
        static public long reply_chat = -1001426552679;


        static TelegramBotClient Bot;
        static TelegramBotClient Bot_Ginance;


       

        static void Main(string[] args)
        {
            try
            {
                aTimer = new System.Timers.Timer(100000);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
                string test_api_bot = "673649420:AAG2O4s9qDmBVpmFtt4wG12dZ3nV-nBm3JA";
                string hbtc_api_bot = "1470290796:AAE_hLDL1FjOJ5-YuTmQXHvNiutfjDqwfYo";
                string ginance_api_bot = "1496019784:AAGWirthfgMcDOZpkBZfUHwrS3Ve9ckfxvY";


                Bot = new TelegramBotClient(hbtc_api_bot);
                var me = Bot.GetMeAsync().Result;

                Bot.OnUpdate += BotOnUpdate;

                Console.WriteLine($"bot id:{me.Id }.bot name:{me.FirstName}");
                Bot.StartReceiving();

                ///Bot ginance 
                Bot_Ginance = new TelegramBotClient(ginance_api_bot);
                var me_Ginance = Bot_Ginance.GetMeAsync().Result;

                Bot_Ginance.OnUpdate += BotOnUpdate;

                Console.WriteLine($"bot id:{me_Ginance.Id }.bot name:{me_Ginance.FirstName}");
                Bot_Ginance.StartReceiving();
                Console.ReadLine();
            }
            catch
            {

            }

        }


        private async static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                var KEyboard_event_ENG = new InlineKeyboardMarkup(new[]
                                 {
                                            new [] { new InlineKeyboardButton { Text = "🟦 Register on HBTC", CallbackData = "demo", Url = "https://www.hbtc.com/register/gtqJqM" } }
                                });
                System.Net.WebClient wc1 = new System.Net.WebClient();
                String link_Response = wc1.DownloadString("https://support.hbtc.co/hc/en-us/sections/360002667194-Recent-Activities");
                System.Net.WebClient wc2 = new System.Net.WebClient();
                String link_Response_Listings = wc2.DownloadString("https://support.hbtc.co/hc/en-us/sections/360009462813-New-Listings");
                System.Net.WebClient wc3 = new System.Net.WebClient();
                String link_Response_Notice = wc3.DownloadString("https://support.hbtc.co/hc/en-us/sections/360009462793-Withdrawal-Opening-Suspension-Notice");
                System.Net.WebClient wc4 = new System.Net.WebClient();
                String link_Response_Others = wc4.DownloadString("https://support.hbtc.co/hc/en-us/sections/360001994473-Others");
                /*
               if (Program.count > 20)
               {
                   Program.count1 = 0;
                   Program.count2 = 0;
                   Program.count3 = 0;
                   Program.count = 0;
                   link_pars = null;
                   link_new = null;
                   link_New_Listings = null;
                   link_New_Listings_new = null;
                   link_Notice = null;
                   link_Notice_new = null;
                   link_Others = null;
                   link_Others_new = null;

               }*/



                link_new = System.Text.RegularExpressions.Regex.Match(link_Response, @"(/hc/en-us/articles)+(.+)(?="" class)").Groups[0].Value;

                if (link_pars != link_new)
                {
                    if (Program.count != 0 && link_pars != link_new)
                    {
                        Console.WriteLine(link_pars + "\n" + link_new);
                        await Bot.SendTextMessageAsync(chat_id_team, "@ProAggress1ve, @doretos, @bar1nn, @off_fov" + "\n" + "Новая новость на сайте" + "\n" + "https://support.hbtc.co" + link_new, ParseMode.Html, false, true, 0, null);
                        // await Bot.SendTextMessageAsync(chat_id_ru_chat, "Новая новость на сайте" + "\n" + "https://support.hbtc.co" + link_new, ParseMode.Html, false, false, 0, null);
                        await Bot.SendTextMessageAsync(chat_id_eng_off, "New news on the site." + "\n" + "https://support.hbtc.co" + link_new, ParseMode.Html, false, false, 0, KEyboard_event_ENG);


                    }
                    link_pars = link_new;
                    Program.count++;
                }

                link_New_Listings_new = System.Text.RegularExpressions.Regex.Match(link_Response_Listings, @"(/hc/en-us/articles)+(.+)(?="" class)").Groups[0].Value;
                //listing

                if (link_New_Listings != link_New_Listings_new)
                {
                    if (Program.count1 != 0 && link_New_Listings != link_New_Listings_new)
                    {
                        Console.WriteLine(link_New_Listings + "\n" + link_New_Listings_new);
                        await Bot.SendTextMessageAsync(chat_id_team, "@ProAggress1ve, @doretos, @bar1nn, @off_fov" + "\n" + "Новая новость на сайте" + "\n" + "https://support.hbtc.co" + link_New_Listings_new, ParseMode.Html, false, true, 0, null);
                        // await Bot.SendTextMessageAsync(chat_id_ru_chat, "Новая новость на сайте" + "\n" + "https://support.hbtc.co" + link_New_Listings_new, ParseMode.Html, false, false, 0, null);
                        await Bot.SendTextMessageAsync(chat_id_eng_off, "New news on the site." + "\n" + "https://support.hbtc.co" + link_New_Listings_new, ParseMode.Html, false, false, 0, KEyboard_event_ENG);


                    }
                    link_New_Listings = link_New_Listings_new;
                    Program.count1++;
                }

                link_Notice_new = System.Text.RegularExpressions.Regex.Match(link_Response_Notice, @"(/hc/en-us/articles)+(.+)(?="" class)").Groups[0].Value;
                // Notice
                if (link_Notice != link_Notice_new)
                {

                    if (Program.count2 != 0 & link_Notice != link_Notice_new)
                    {
                        Console.WriteLine(link_Notice + "\n" + link_Notice_new);
                        await Bot.SendTextMessageAsync(chat_id_team, "@ProAggress1ve, @doretos, @bar1nn, @off_fov" + "\n" + "Новая новость на сайте" + "\n" + "https://support.hbtc.co" + link_Notice_new, ParseMode.Html, false, true, 0, null);
                        //  await Bot.SendTextMessageAsync(chat_id_ru_chat, "Новая новость на сайте" + "\n" + "https://support.hbtc.co" + link_Notice_new, ParseMode.Html, false, false, 0, null);
                        await Bot.SendTextMessageAsync(chat_id_eng_off, "New news on the site." + "\n" + "https://support.hbtc.co" + link_Notice_new, ParseMode.Html, false, false, 0, KEyboard_event_ENG);

                    }
                    link_Notice = link_Notice_new;
                    Program.count2++;
                }

                link_Others_new = System.Text.RegularExpressions.Regex.Match(link_Response_Others, @"(/hc/en-us/articles)+(.+)(?="" class)").Groups[0].Value;
                // others
                if (link_Others != link_Others_new)
                {

                    if (Program.count3 != 0 & link_Others != link_Others_new)
                    {
                        Console.WriteLine(link_Others + "\n" + link_Others_new);
                        await Bot.SendTextMessageAsync(chat_id_team, "@ProAggress1ve, @doretos, @bar1nn, @off_fov" + "\n" + "Новая новость на сайте" + "\n" + "https://support.hbtc.co" + link_Others_new, ParseMode.Html, false, true, 0, null);
                        //  await Bot.SendTextMessageAsync(chat_id_ru_chat, "Новая новость на сайте" + "\n" + "https://support.hbtc.co" + link_Others_new, ParseMode.Html, false, false, 0, null);
                        await Bot.SendTextMessageAsync(chat_id_eng_off, "New news on the site." + "\n" + "https://support.hbtc.co" + link_Others_new, ParseMode.Html, false, false, 0, KEyboard_event_ENG);

                    }
                    link_Others = link_Others_new;
                    Program.count3++;
                }
            }
            catch
            {

            }
        }

        //listing https://support.hbtc.co/hc/en-us/sections/360009462813-New-Listings

        // Notice  https://support.hbtc.co/hc/en-us/sections/360009462793-Withdrawal-Opening-Suspension-Notice
        // others https://support.hbtc.co/hc/en-us/sections/360001994473-Others

                // Inlin'ы
              


private static async void BotOnUpdate(object su, Telegram.Bot.Args.UpdateEventArgs evu)

    {
                    try
                    {
                        var update = evu.Update;
                        var message = update.Message;

                        if (message == null) return; 
                        /*
                        if (question1.Count == 2 || message.From.Username == @"off_fov")
                        {
                            question1[1] = message.Text;
                            await Bot.SendTextMessageAsync(message.Chat.Id, question1[0] + "\n" + question1[1], ParseMode.Html, false, false, 0, keyboard_full);
                            await Bot.SendTextMessageAsync(message.Chat.Id, @"Вопрос ответ! Добавлен", ParseMode.Html, false, false, 0, keyboard_full);

                        }*/

                        if (message.Text == "/win" & message.From.Username == @"off_fov")
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, @"сам макака", ParseMode.Html, false, false, 0, null);

                        }

                // https://www.hbtc.com/api/v1/hobbit/repurchase/info

                // @"https://api.hbtc.com/openapi/quote/v1/ticker/price"

                // charts 
                // https://finviz.com/crypto_charts.ashx?t=ALL&tf=h1



                ///
                /// ginance 
                /// 

                var inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                                         new [] { new InlineKeyboardButton { Text = "🔶 Зарегистрироваться /20% скидка ", CallbackData = "demo", Url = "https://accounts.binance.com/en/register?ref=Z6EIEROX" } },
                            new [] { new InlineKeyboardButton { Text = "🔶 Торгую на фьючерсах тут", CallbackData = "demo", Url = "https://www.binance.cc/ru/futures/ref/Z6EIEROX" } },
                            new [] { new InlineKeyboardButton { Text = "🔶 Купить криптовалюту за RUB/KZT/USD", CallbackData = "demo", Url = "https://www.binance.com/ru/buy-sell-crypto?fiat=KZT&crypto=USDT&amount=&ref=BQCOIJ8Y" } }
                                 });
                var inlineKeyboardMarkupHBTC_ENG = new InlineKeyboardMarkup(new[]
                              {
                                        new [] { new InlineKeyboardButton { Text = "🟦 Spot trading", CallbackData = "demo", Url = "https://www.hbtc.com/exchange/BTC/USDT" } },
                                          new [] { new InlineKeyboardButton { Text = "🟦 Margin trading", CallbackData = "demo", Url = "https://www.hbtc.com/cross-margin/BTC/USDT" } },
                                            new [] { new InlineKeyboardButton { Text = "🟦 Register on HBTC", CallbackData = "demo", Url = "https://www.hbtc.com/register/gtqJqM" } }
                                });



                var inlineKeyboardMarkupHBTC = new InlineKeyboardMarkup(new[]
                                {
                                        new [] { new InlineKeyboardButton { Text = "🟦 Спот торговля", CallbackData = "demo", Url = "https://www.hbtc.com/exchange/BTC/USDT" } },
                                          new [] { new InlineKeyboardButton { Text = "🟦 Маржинальная торговля", CallbackData = "demo", Url = "https://www.hbtc.com/cross-margin/BTC/USDT" } },
                                            new [] { new InlineKeyboardButton { Text = "🟦 Зарегистрироваться на HBTC", CallbackData = "demo", Url = "https://www.hbtc.com/register/gtqJqM" } }
                                });

                if (message.Chat.Id == ginance_chat || message.Chat.Id == test)
                {
                    if (message.Text == "/1inch_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "1INCH";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol="+symbol+"USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value; 

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            
                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>"+ symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT"+"\n"+ "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false,  0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/grt_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "GRT";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/btc_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "BTC";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/eth_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "ETH";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/ltc_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "LTC";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/xrp_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "XRP";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/eos_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "EOS";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/bnb_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "BNB";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/trx_usdt@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "TRX";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/cake_busd@Ginance_BOT")
                    {
                        try
                        {
                            string symbol = "CAKE";
                            string two_symbol = "BUSD";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://www.binance.com/api/v1/ticker/24hr?symbol=" + symbol + two_symbol);

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9][0-9][0-9]").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9][0-9][0-9]").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9][0-9][0-9]").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9][0-9]").Groups[0].Value;


                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts_binance.chart(symbol + two_symbol);
                            Console.WriteLine(name_file);
                            await Bot_Ginance.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/"+ two_symbol + "</b>" + "\n" + "Price:" + hbc_price + " "+ two_symbol + "\n" + "24H High:" + hbc_highPrice + " "+ two_symbol + "\n" + "24H Low:" + hbc_lowPrice + " "+ two_symbol + "\n" + "24H Total:" + hbc_quoteVolume + " "+ two_symbol + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkup);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }                    
                    if (message.Text == "/buy_usdt@Ginance_BOT")
                    {
                        try
                        {

                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot_Ginance.ForwardMessageAsync(message.Chat.Id, forward_chat, 11);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/futures@Ginance_BOT")
                    {
                        try
                        {

                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot_Ginance.ForwardMessageAsync(message.Chat.Id, forward_chat, 13);

                        }
                        catch
                        {

                        }
                    } 

                } 
                //eng laung
                if (message.Chat.Id == chat_id_eng_off ||  message.Chat.Id == HBTCIndonesia_chat || message.Chat.Id == HBTCHBTCJapan_chat || message.Chat.Id == HBTCHBTCKorean_chat || message.Chat.Id == HBTCHBTCTurkey_chat || message.Chat.Id== -1001138048230)
                {
                    
                    if (message.Text == "/1inch_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "1INCH";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/grt_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "GRT";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file); 
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/daily_repo@HBTC_RU_BOT")
                    {
                        try
                        {
                            System.Net.WebClient wc1 = new System.Net.WebClient();
                            String price_Responsehbc = wc1.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/price");
                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Responsehbc, @"HBCUSDT""+,""price"":""+[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://www.hbtc.com/api/v1/hobbit/repurchase/info");
                            String Distributed1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"allocated"":""+[0-9]+.[0-9][0-9]").Groups[0].Value;
                            String Distributed = System.Text.RegularExpressions.Regex.Match(Distributed1, @"[0-9]+.[0-9][0-9]").Groups[0].Value;

                            System.Net.WebClient wc2 = new System.Net.WebClient();
                            String LatestPricefor10xPE_Response = wc2.DownloadString("https://www.hbtc.com/api/v1/hobbit/repurchase/info");
                            String LatestPricefor10xPE1 = System.Text.RegularExpressions.Regex.Match(LatestPricefor10xPE_Response, @"tenTimesPrice"":""+[0-9]+.[0-9][0-9]").Groups[0].Value;
                            String LatestPricefor10xPE = System.Text.RegularExpressions.Regex.Match(LatestPricefor10xPE1, @"[0-9]+.[0-9][0-9]").Groups[0].Value;


                            System.Net.WebClient wc3 = new System.Net.WebClient();
                            String LatestPricefor5xPE_Response = wc3.DownloadString("https://www.hbtc.com/api/v1/hobbit/repurchase/info");
                            String LatestPricefor5xPE1 = System.Text.RegularExpressions.Regex.Match(LatestPricefor5xPE_Response, @"fiveTimesPrice"":""+[0-9]+.[0-9][0-9]").Groups[0].Value;
                            String LatestPricefor5xPE = System.Text.RegularExpressions.Regex.Match(LatestPricefor5xPE1, @"[0-9]+.[0-9][0-9]").Groups[0].Value;

                            System.Net.WebClient wc4 = new System.Net.WebClient();
                            String LockedVolume_Response = wc4.DownloadString("https://www.hbtc.com/api/v1/hobbit/repurchase/info");
                            String LockedVolume1 = System.Text.RegularExpressions.Regex.Match(LockedVolume_Response, @"lockTotal"":""+[0-9]+").Groups[0].Value;
                            String LockedVolume = System.Text.RegularExpressions.Regex.Match(LockedVolume1, @"[0-9]+").Groups[0].Value;

                            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");


                            double dist_usdt = Convert.ToDouble(Convert.ToString(hbc_price)) * Convert.ToDouble(Convert.ToString(Distributed));

                            decimal dist_usdt_out = Convert.ToDecimal(dist_usdt.ToString("0.##"));


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                await Bot.SendTextMessageAsync(message.Chat.Id, "<code>Accu.to be Distributed: " + Distributed + " HBC" + "\n" + "Accu.to be Distributed: ~ " + dist_usdt_out + " USDT" + "\n" + "Latest Price 10xPE: " + LatestPricefor10xPE + " USDT \n" + "Latest Price 5PE: " + LatestPricefor5xPE + " USDT \n" + "LockedVolume: " + LockedVolume + " HBC</code>", ParseMode.Html, false, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/hbc_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "HBC";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/btc_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "BTC";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file); 
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/bch_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "BCH";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file); 
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/eth_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "ETH";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file); 
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/ltc_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "LTC";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file); 
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/eos_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "EOS";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file); 
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/xrp_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "XRP";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file); 
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC_ENG);

                        }
                        catch
                        {

                        }
                    }

                    if (message.Text == "/registration@HBTC_RU_BOT")
                    {
                        try
                        {


                          await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, reply_chat, 3);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/2fa@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, reply_chat, 4);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/account_review@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, reply_chat, 5);


                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/vip_levels@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, reply_chat, 6);


                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/referral_program@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, reply_chat, 7);


                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/deposit_withdrawal@HBTC_RU_BOT")
                    {
                        try
                        {

                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, reply_chat, 8);

                        }
                        catch
                        {

                        }
                    }

                    if (message.Text == "/buy_usdt@HBTC_RU_BOT")
                    {
                        try
                        {

                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 21);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/staking@HBTC_RU_BOT")
                    {
                        try
                        {

                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 22);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/trading@HBTC_RU_BOT")
                    {
                        try
                        {

                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 23);

                        }
                        catch
                        {

                        }
                    }
                }


                //rus laung
                if ( message.Chat.Id == chat_id_ru_chat || message.Chat.Id == test )
                {
                    if (message.Text == "/1inch_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "1INCH";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            
                             await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                        }
                        catch
                        {

                        }
                    } 
                    if (message.Text == "/grt_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "GRT";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                           
                             await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/daily_repo@HBTC_RU_BOT")
                    {
                        try
                        {
                            System.Net.WebClient wc1 = new System.Net.WebClient();
                            String price_Responsehbc = wc1.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/price");
                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Responsehbc, @"HBCUSDT""+,""price"":""+[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://www.hbtc.com/api/v1/hobbit/repurchase/info");
                            String Distributed1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"allocated"":""+[0-9]+.[0-9][0-9]").Groups[0].Value;
                            String Distributed = System.Text.RegularExpressions.Regex.Match(Distributed1, @"[0-9]+.[0-9][0-9]").Groups[0].Value;

                            System.Net.WebClient wc2 = new System.Net.WebClient();
                            String LatestPricefor10xPE_Response = wc2.DownloadString("https://www.hbtc.com/api/v1/hobbit/repurchase/info");
                            String LatestPricefor10xPE1 = System.Text.RegularExpressions.Regex.Match(LatestPricefor10xPE_Response, @"tenTimesPrice"":""+[0-9]+.[0-9][0-9]").Groups[0].Value;
                            String LatestPricefor10xPE = System.Text.RegularExpressions.Regex.Match(LatestPricefor10xPE1, @"[0-9]+.[0-9][0-9]").Groups[0].Value;


                            System.Net.WebClient wc3 = new System.Net.WebClient();
                            String LatestPricefor5xPE_Response = wc3.DownloadString("https://www.hbtc.com/api/v1/hobbit/repurchase/info");
                            String LatestPricefor5xPE1 = System.Text.RegularExpressions.Regex.Match(LatestPricefor5xPE_Response, @"fiveTimesPrice"":""+[0-9]+.[0-9][0-9]").Groups[0].Value;
                            String LatestPricefor5xPE = System.Text.RegularExpressions.Regex.Match(LatestPricefor5xPE1, @"[0-9]+.[0-9][0-9]").Groups[0].Value;

                            System.Net.WebClient wc4 = new System.Net.WebClient();
                            String LockedVolume_Response = wc4.DownloadString("https://www.hbtc.com/api/v1/hobbit/repurchase/info");
                            String LockedVolume1 = System.Text.RegularExpressions.Regex.Match(LockedVolume_Response, @"lockTotal"":""+[0-9]+").Groups[0].Value;
                            String LockedVolume = System.Text.RegularExpressions.Regex.Match(LockedVolume1, @"[0-9]+").Groups[0].Value;

                            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");


                            double dist_usdt = Convert.ToDouble(Convert.ToString(hbc_price)) * Convert.ToDouble(Convert.ToString(Distributed));

                            decimal dist_usdt_out = Convert.ToDecimal(dist_usdt.ToString("0.##"));


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                           
                                await Bot.SendTextMessageAsync(message.Chat.Id, "<code>Accu.to be Distributed: " + Distributed + " HBC" + "\n" + "Accu.to be Distributed: ~ " + dist_usdt_out + " USDT" + "\n" + "Latest Price 10xPE: " + LatestPricefor10xPE + " USDT \n" + "Latest Price 5PE: " + LatestPricefor5xPE + " USDT \n" + "LockedVolume: " + LockedVolume + " HBC</code>", ParseMode.Html, false, false, 0, inlineKeyboardMarkupHBTC);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/hbc_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "HBC";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                           
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    if (message.Text == "/btc_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "BTC";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                           
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                            
                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/bch_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "BCH";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                           
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                            
                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/eth_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "ETH";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                            
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                            
                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/ltc_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "LTC";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                         
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                            
                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/eos_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "EOS";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                           
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                            
                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/xrp_usdt@HBTC_RU_BOT")
                    {
                        try
                        {
                            string symbol = "XRP";
                            System.Net.WebClient wc = new System.Net.WebClient();
                            String price_Response = wc.DownloadString("https://api.hbtc.com/openapi/quote/v1/ticker/24hr?symbol=" + symbol + "USDT");

                            String hbc_price1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lastPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_price = System.Text.RegularExpressions.Regex.Match(hbc_price1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_highPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"highPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_highPrice = System.Text.RegularExpressions.Regex.Match(hbc_highPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_lowPrice1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"lowPrice"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_lowPrice = System.Text.RegularExpressions.Regex.Match(hbc_lowPrice1, @"[0-9]+.[0-9]+").Groups[0].Value;

                            String hbc_quoteVolume1 = System.Text.RegularExpressions.Regex.Match(price_Response, @"quoteVolume"":""[0-9]+.[0-9]+").Groups[0].Value;
                            String hbc_quoteVolume = System.Text.RegularExpressions.Regex.Match(hbc_quoteVolume1, @"[0-9]+.[0-9]+").Groups[0].Value;


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            string name_file = HBTC_linux.charts.chart(symbol + "USDT");
                            Console.WriteLine(name_file);
                           
                                await Bot.SendPhotoAsync(message.Chat.Id, System.IO.File.Open(name_file, FileMode.Open), "<code><b>" + symbol + "/USDT</b>" + "\n" + "Price:" + hbc_price + " USDT" + "\n" + "24H High:" + hbc_highPrice + " USDT" + "\n" + "24H Low:" + hbc_lowPrice + " USDT" + "\n" + "24H Total:" + hbc_quoteVolume + " USDT" + "</code>", ParseMode.Html, false, 0, inlineKeyboardMarkupHBTC);

                            
                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/registration@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 2);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/2fa@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 3);


                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/account_review@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 4);


                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/vip_levels@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 5);


                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/referral_program@HBTC_RU_BOT")
                    {
                        try
                        {


                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 6);


                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/deposit_withdrawal@HBTC_RU_BOT")
                    {
                        try
                        {

                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 7);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/buy_usdt@HBTC_RU_BOT")
                    {
                        try
                        {

                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 8);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/staking@HBTC_RU_BOT")
                    {
                        try
                        {

                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 9);

                        }
                        catch
                        {

                        }
                    }
                    if (message.Text == "/trading@HBTC_RU_BOT")
                    {
                        try
                        {

                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                            await Bot.ForwardMessageAsync(message.Chat.Id, forward_chat, 10);

                        }
                        catch
                        {

                        }
                    }
                }

                if (message.Type == MessageType.ChatMemberLeft || message.Type == MessageType.ChatMembersAdded)
                {
                            try
                            {
                        if(message.Chat.Id == ginance_chat || message.Chat.Id == test)
                        {
                            await Bot_Ginance.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        }
                        if (message.Chat.Id == chat_id_ru_chat || message.Chat.Id == chat_id_eng_off || message.Chat.Id == HBTCIndonesia_chat || message.Chat.Id == HBTCHBTCJapan_chat || message.Chat.Id == HBTCHBTCKorean_chat || message.Chat.Id == HBTCHBTCTurkey_chat)

                        {
                            await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                        }
                            

                    }
                            catch
                            {

                            }
                            return;

                        }
                /*
                var entities = message.Entities.Where(t => t.Type == MessageEntityType.Url
                                   || t.Type == MessageEntityType.Mention || t.Type == MessageEntityType.TextLink);


                foreach (var entity in entities)
                {
                    if (entity.Type == MessageEntityType.TextLink || entity.Type==MessageEntityType.Url)
                    {
                        try
                        {
                    //40103694 - @off_fov
                    //454938622 - @bar1nn
                    //1300557072 - @ProAggress1ve
                    //1091842873 - @Mira_miranda
                    //571522545 -  @ProAggressive                                    
                    //320968789 - @timcheg1
                    //273228404 - @hydranik
                    //435567580 - Никита                           
                    //352345393 - @i_am_zaytsev
                    //430153320 - @KingOfMlnD
                    //579784 - @kamiyar
                    //536915847 - @m1Bean
                    //460657014 - @DenisSenatorov
                    //-1001284050118 - HBTC oficill

                    if (message.ForwardFromChat.Id == -1001284050118 || message.From.Id== 777000 || message.ForwardFromChat.Id== -1001487385729  || message.From.Id == 40103694 || message.From.Id== 454938622 || message.From.Id== 501931698 || message.From.Id== 1300557072 || message.From.Id == 1091842873)
                    {

                        return;
                            }
                            else
                            {
                                await Bot.DeleteMessageAsync(message.Chat.Id, message.MessageId);
                                if (update.Message.From.Username != null)
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, "@" + message.From.Username + ", Ссылки запрещены!");
                                    return;
                                }
                                else
                                {
                                    await Bot.SendTextMessageAsync(message.Chat.Id, message.From.FirstName + ", Ссылки запрещены!");
                                    return;
                                }
                            }


                }
                        catch
                        {

                        }
                        return;


                    }
            }*/
            }

            catch
                    {

                    }
                } 


                // запускаем прием обновлений


            
    }
}

