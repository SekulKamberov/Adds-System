namespace AddsSystem.Client.Hubs
{
    using System;
    using Microsoft.AspNet.SignalR;
    using System.Net;
    using System.Text.RegularExpressions;

    public class ChatHub : Hub
    {
        private WebClient webClient;
        private Random rnd;
        private Regex rgx;

        private string[] catUrls = new string[]
        {
            "https://2.bp.blogspot.com/-iNRxwwXHMY0/WLsFxeOi6TI/AAAAAAAAU-s/aQ9uVNl1NBM72lKths2vijQl7jLOX72igCLcB/s1600/smooch-smiley.png",
            "http://3.bp.blogspot.com/-n4nniZBLL00/U-VtVKFtwmI/AAAAAAAALb4/LUw9J0Zue-4/s1600/prayer-smiley.png",
            "http://4.bp.blogspot.com/-nn9iheSg_HY/VOfoPqYN-bI/AAAAAAAAODA/lZ259SUvwiY/s1600/laughing-smiley-cries-tears-of-joy.png",
            "https://i.pinimg.com/736x/58/ec/ed/58eced2a090b4df0083bab80727b9a4c--symbols-emoticons-emoji-emoticons.jpg",
            "http://4.bp.blogspot.com/-SEIBrfgFB3Q/VpPxKlsZZkI/AAAAAAAAR8M/Nr1NwEcYcIo/s1600/tearful-emoticon.png",
            "https://i.pinimg.com/736x/4e/5c/f7/4e5cf7d4ccb9c59b6620a9c71944d51e--emoticons-text-smileys.jpg",
            "https://i.pinimg.com/736x/44/34/f5/4434f5f63b3a0994a4e8412d178a29ac--symbols-emoticons-smiley-faces.jpg",
            "https://i.pinimg.com/736x/9a/fa/81/9afa819f6b9ed7590dc8cec0db16005b--emoticon-love-animated-emoticons.jpg",
            "https://s-media-cache-ak0.pinimg.com/originals/d9/61/80/d96180b4a09537b0429a45319494761d.png",
            "https://s-media-cache-ak0.pinimg.com/736x/34/dd/3e/34dd3e7c30c1a6623de3b6ada6f8fc5c.jpg",
            "https://s-media-cache-ak0.pinimg.com/originals/75/c2/47/75c247d32c50d15a690add8dbe00b29f.png"
        };

        public ChatHub()
        {
            this.rgx = new Regex("\\/watch\\?v=(.{11})");
            this.rnd = new Random();
            this.webClient = new WebClient();
        }

        public void GetMessage(string name, string message)  
        {
            // tozi public method moga go izvikam ot clienta, a ako iskam dostupvam clientite mi: Clients.All, ot nqkoq grupa, Clients.Group, Clients.User
            Clients.All.getMessage(name, message);
        }

        public void GetCat(string name)
        {
            Clients.All.GetCat(name, this.catUrls[this.rnd.Next(0, 9)]);
        }

        public void GetVideo(string name, string query)
        {

            string videoId = this.ExtractVideoId(query);
            Clients.All.getVideo(name, videoId);
        }

        private string ExtractVideoId(string query)
        {
            string html = this.webClient.DownloadString($"https://www.youtube.com/results?search_query={query}");
            string videoId = this.rgx.Match(html).Groups[1].Value;
            return videoId;
        }
    }
}