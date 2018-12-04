using System;
using System.Collections.Generic;


namespace SoleaScouting
{

    [Serializable]
    public class Holder
    {
        private int playersLeft;
        private List<Player> players;
        private List<List<Player>> playersByPos;
        private Random r;

        public Holder()
        {
            players = new List<Player>();
            playersByPos = new List<List<Player>>();
            r = new Random();
            playersLeft = 80;
            LoadPlayers();
            for (int i = 1; i <= 5; i++)
            {
                playersByPos.Add(new List<Player>());
                for (int j = 0; j < players.Count; j++)
                {
                    if (players[j].GetPosition() == i)
                    {
                        playersByPos[i - 1].Add(players[j]);
                    }
                }
            }

        }
        public int GetNumLeft()
        {
            return playersLeft;
        }      

        public List<Player> GetPlayers(int pos)
        {
            return playersByPos[pos-1];
        }

        private void LoadPlayers()
        {
            players.Add(new Player("Abosa Aludetsei ", "Dotruga", 1, 4, 3, 1, 1, 2, 8, 9, 10, 4, 6, 7, 22, 30, 36, 7, " University of Shmupland 3", new double[] { 48.1, 406, 123, 465, 18.8 }, r));
            players.Add(new Player("Alve Higashikuni ", "Barsein", 1, 7, 7, 3, 4, 4, 3, 3, 6, 6, 8, 10, 21, 28, 34, 5, " University of Naxda", new double[] { 51.6, 558, 156, 237, 46.7 }, r));
            players.Add(new Player("Atusosa Hisei ", "Dotruga", 1, 5, 6, 2, 1, 5, 3, 4, 7, 5, 5, 10, 20, 28, 33, 2, " Naskitrusk University", new double[] { 50.9, 216, 100, 185, 55.6 }, r));
            players.Add(new Player("Cagi  ", "Aiyota", 1, 5, 8, 1, 3, 2, 5, 6, 9, 5, 4, 9, 20, 27, 33, 5, " University of Atapwa", new double[] { 55.5, 869, 79, 502, 33.2 }, r));
            players.Add(new Player("Charrat  ", "Aiyota", 1, 4, 7, 2, 2, 3, 5, 2, 7, 6, 2, 8, 22, 30, 36, 1, " University of Pyzus", new double[] { 58.6, 634, 118, 421, 49.3 }, r));
            players.Add(new Player("Cocogo  ", "Aiyota", 1, 4, 5, 3, 1, 4, 5, 2, 7, 8, 7, 6, 23, 27, 33, 7, " University of Pyzus", new double[] { 50, 90, 34, 64, 50 }, r));
            players.Add(new Player("Dgenek Kvviiké ", "Transhimalia", 1, 4, 4, 1, 4, 5, 7, 8, 7, 3, 4, 5, 19, 30, 36, 4, " University of Oasis City", new double[] { 41.3, 289, 289, 492, 22.4 }, r));
            players.Add(new Player("Goormurra", "Aiyota", 1, 8, 6, 4, 2, 7, 6, 4, 6, 5, 9, 6, 22, 30, 34, 4, " University of Soniara", new double[] { 47.3, 275, 342, 231, 38.5 }, r));
            players.Add(new Player("Harri Umlauf ", "TND", 1, 5, 8, 2, 3, 2, 5, 6, 9, 6, 1, 6, 21, 30, 34, 5, " University of Aahrus 1", new double[] { 55.3, 242, 30, 233, 42.1 }, r));
            players.Add(new Player("Kersuvi Himamosei ", "Dotruga", 1, 8, 6, 1, 1, 4, 4, 3, 8, 2, 8, 5, 21, 30, 35, 4, " University of Kholka", new double[] { 36.3, 287, 323, 474, 45.9 }, r));
            players.Add(new Player("Makan Savang ", "Pyxanovia", 1, 6, 7, 1, 2, 1, 10, 8, 8, 1, 2, 6, 20, 31, 32, 1, " University of Vikkada", new double[] { 41.3, 456, 60, 414, 23.4 }, r));
            players.Add(new Player("Nagata Saikaku ", "Transhimalia", 1, 7, 7, 1, 4, 1, 4, 5, 7, 1, 8, 10, 19, 28, 34, 2, " University of Fiik Lanki Akol", new double[] { 36.9, 272, 89, 330, 43.4 }, r));
            players.Add(new Player("Nàsà Sikasbë ", "Darvincia", 1, 6, 4, 3, 4, 3, 7, 8, 6, 7, 5, 6, 23, 28, 31, 6, " University of Nausicaa", new double[] { 57.3, 556, 159, 437, 24 }, r));
            players.Add(new Player("noe  ", "Czalliso", 1, 8, 5, 1, 2, 4, 9, 4, 8, 6, 7, 8, 19, 31, 35, 5, " University of Imperial Institute at Faehrenfall", new double[] { 50.7, 847, 240, 504, 38.7 }, r));
            players.Add(new Player("Pusu Iode ", "Bongatar", 1, 9, 1, 2, 4, 4, 6, 6, 7, 4, 5, 5, 20, 30, 34, 6, " University of Pokoj", new double[] { 42.5, 401, 220, 459, 37.6 }, r));
            players.Add(new Player("Rezinal Naizen ", "Aeridani", 1, 6, 7, 1, 1, 8, 4, 5, 6, 8, 10, 9, 19, 29, 34, 10, " University of Uxnua", new double[] { 64.3, 144, 64, 69, 47.9 }, r));
            players.Add(new Player("Sagolna Hartotasek ", "Dotruga", 1, 5, 7, 1, 4, 4, 6, 5, 9, 3, 9, 8, 22, 31, 32, 6, " University of Barsein", new double[] { 46.1, 635, 198, 519, 40.6 }, r));
            players.Add(new Player("Sovnox Naixi ", "Blaist Blaland", 1, 6, 7, 4, 4, 3, 3, 2, 8, 3, 8, 8, 24, 32, 34, 7, " University of Zhiwasen", new double[] { 42.7, 637, 159, 481, 51.1 }, r));
            players.Add(new Player("Sovtanzax Kibla ", "Blaist Blaland", 1, 5, 8, 2, 1, 4, 4, 1, 7, 2, 4, 7, 24, 29, 34, 6, " University of Pentadominion 2", new double[] { 44.9, 665, 245, 476, 58.2 }, r));
            players.Add(new Player("Thomas Skinner", "Wyverncliff", 1, 6, 10, 4, 2, 5, 7, 7, 9, 7, 3, 8, 19, 28, 34, 6, " University of Uxnua", new double[] { 56.9, 952, 235, 474, 31.3 }, r));
            players.Add(new Player("Volkhardt Klostermann ", "TND", 1, 5, 4, 1, 2, 2, 10, 10, 4, 1, 1, 8, 20, 28, 34, 6, " Esmal District University", new double[] { 31.6, 185, 79, 345, 21.8 }, r));
            players.Add(new Player("Volkhardt Schröpfer ", "TND", 1, 7, 5, 4, 4, 4, 3, 5, 7, 4, 8, 8, 22, 32, 35, 1, " University of Maxwmkakki", new double[] { 45.7, 533, 173, 387, 38.5 }, r));
            players.Add(new Player("Alfred Alt ", "TND", 2, 4, 3, 5, 3, 1, 5, 4, 6, 3, 10, 10, 21, 29, 34, 6, " University of Vincent", new double[] { 49, 563, 47, 325, 43 }, r));
            players.Add(new Player("Alotru Amodetsei ", "Dotruga", 2, 7, 3, 3, 2, 4, 6, 6, 8, 10, 6, 7, 21, 29, 34, 5, " Stedro Institute of Technology", new double[] { 62, 490, 154, 326, 33.7 }, r));
            players.Add(new Player("Anthony Mendez", "Wyverncliff", 2, 8, 4, 1, 1, 2, 3, 2, 7, 5, 3, 8, 23, 32, 33, 8, " University of Hinaika Oceanography Institute", new double[] { 53.8, 499, 96, 390, 46.2 }, r));
            players.Add(new Player("Asser Hutto ", "TND", 2, 10, 2, 4, 5, 6, 7, 7, 7, 8, 5, 7, 23, 27, 33, 7, " University of Futi'akep", new double[] { 52.2, 909, 260, 424, 37.2 }, r));
            players.Add(new Player("Autanblanaix Auproda ", "Blaist Blaland", 2, 5, 6, 3, 4, 3, 7, 6, 7, 5, 4, 7, 22, 32, 34, 7, " University of Akarine", new double[] { 48.4, 707, 161, 425, 40.9 }, r));
            players.Add(new Player("Bane Phothisarath ", "Lyintaria", 2, 6, 6, 10, 9, 3, 3, 3, 7, 3, 4, 9, 19, 27, 31, 9, " University of Seraphia", new double[] { 45.3, 949, 159, 452, 51.1 }, r));
            players.Add(new Player("Boḿa Pámhóǵwá ", "Nausicaa", 2, 5, 5, 5, 2, 3, 6, 4, 7, 7, 6, 5, 21, 31, 32, 1, " University of Sapphire Bay", new double[] { 54.1, 940, 153, 449, 46.6 }, r));
            players.Add(new Player("Dennis Tsoi", "Ethanthova", 2, 7, 7, 3, 4, 3, 8, 8, 4, 5, 2, 9, 21, 29, 33, 8, " University of Pyzus", new double[] { 49.9, 788, 184, 287, 21.6 }, r));
            players.Add(new Player("Ingo Samter ", "TND", 2, 6, 6, 6, 6, 1, 7, 4, 7, 6, 2, 5, 23, 31, 32, 1, " University of Antarion 3", new double[] { 54.9, 137, 19, 51, 54.2 }, r));
            players.Add(new Player("James Dunn", "Wyverncliff", 2, 7, 4, 3, 1, 2, 8, 2, 9, 6, 8, 7, 22, 28, 31, 4, " University of Herelle", new double[] { 48.5, 773, 90, 443, 47.8 }, r));
            players.Add(new Player("Joshua Doney", "Wyverncliff", 2, 4, 4, 5, 3, 5, 10, 6, 5, 2, 8, 6, 22, 27, 30, 4, " University of Shmupland 2", new double[] { 46.5, 757, 239, 406, 30.3 }, r));
            players.Add(new Player("Kanoa Thammavong ", "Bielosia", 2, 4, 5, 4, 1, 4, 6, 8, 8, 7, 7, 9, 21, 27, 32, 5, " University of Yoka Tse", new double[] { 53.8, 668, 223, 432, 32.2 }, r));
            players.Add(new Player("Liko Menorath ", "Bielosia", 2, 6, 6, 7, 2, 3, 6, 5, 7, 5, 6, 8, 22, 28, 33, 3, " University of Hkamnsi", new double[] { 45.7, 537, 147, 453, 37.9 }, r));
            players.Add(new Player("Louis Wagenseil ", "TND", 2, 6, 4, 2, 2, 7, 3, 10, 7, 3, 5, 7, 24, 27, 33, 1, " University of Norkute", new double[] { 45.7, 343, 472, 407, 28.6 }, r));
            players.Add(new Player("Maik Menorath ", "Holy Yektonisa", 2, 6, 7, 1, 1, 5, 6, 4, 9, 4, 7, 7, 22, 31, 34, 6, " University of Shmupland 4", new double[] { 50, 460, 236, 357, 43.9 }, r));
            players.Add(new Player("Matthew Vermillion", "Ethanthova", 2, 4, 5, 3, 5, 2, 6, 4, 8, 4, 5, 7, 20, 28, 34, 6, " University of Issamore", new double[] { 55, 399, 108, 297, 39.9 }, r));
            players.Add(new Player("Nyning  ", "Aiyota", 2, 7, 7, 5, 2, 1, 6, 6, 10, 6, 8, 7, 19, 27, 30, 4, " University of Biodry", new double[] { 51.7, 582, 57, 467, 38.3 }, r));
            players.Add(new Player("Onishi Yoshiiku ", "Barsein", 2, 5, 6, 4, 1, 3, 8, 9, 7, 8, 4, 7, 21, 29, 34, 5, " University of Naxda", new double[] { 55.5, 627, 154, 401, 26.6 }, r));
            players.Add(new Player("Phetdum Bouvanaat ", "Holy Yektonisa", 2, 10, 6, 6, 8, 3, 7, 6, 8, 9, 6, 8, 19, 28, 31, 6, " University of Soniara", new double[] { 59.9, 908, 127, 366, 37.1 }, r));
            players.Add(new Player("Pranga  ", "Aiyota", 2, 10, 6, 3, 3, 5, 4, 4, 7, 4, 5, 8, 23, 29, 33, 9, " University of Autolik", new double[] { 50.5, 492, 170, 359, 47.4 }, r));
            players.Add(new Player("Sathanalat Vatthana ", "Bielosia", 2, 4, 5, 6, 4, 5, 4, 10, 7, 6, 1, 10, 23, 27, 31, 3, " University of Chromasheep Farm", new double[] { 47.8, 495, 123, 258, 25 }, r));
            players.Add(new Player("Stanley Price", "Ethanthova", 2, 6, 8, 4, 6, 2, 4, 8, 8, 5, 6, 6, 21, 27, 30, 5, " University of Fiik Lanki Akol", new double[] { 49.1, 728, 87, 372, 35.2 }, r));
            players.Add(new Player("Uxnax Sovix ", "Blaist Blaland", 2, 3, 2, 1, 3, 7, 6, 4, 8, 10, 10, 10, 22, 31, 34, 5, " University of Radugrad", new double[] { 58.1, 516, 446, 443, 40.3 }, r));
            players.Add(new Player("Atumundikeili Bexote ", "Dotruga", 3, 6, 6, 6, 1, 3, 4, 3, 2, 9, 1, 7, 23, 30, 35, 3, " University of Svitharia", new double[] { 55.3, 754, 132, 175, 49.1 }, r));
            players.Add(new Player("Ixux Zaxau ", "Blaist Blaland", 3, 2, 7, 1, 9, 4, 4, 2, 10, 4, 3, 6, 21, 29, 33, 4, " University of Sande Sitei", new double[] { 46.8, 72, 36, 57, 47.6 }, r));
            players.Add(new Player("James Ayala", "Ethanthova", 3, 3, 7, 2, 2, 10, 1, 3, 10, 4, 4, 5, 24, 32, 36, 3, " Atresmi University", new double[] { 51.8, 438, 463, 312, 46.7 }, r));
            players.Add(new Player("Kiro Hidolundi ", "Dotruga", 3, 2, 2, 1, 8, 5, 1, 7, 3, 8, 7, 9, 21, 28, 32, 6, " University of Quiita-Kyudosia", new double[] { 57.5, 765, 250, 217, 37.3 }, r));
            players.Add(new Player("Lee Stidham", "Ethanthova", 3, 4, 1, 10, 8, 8, 9, 4, 4, 8, 8, 7, 19, 28, 33, 3, " University of Aahrus 1", new double[] { 53, 906, 426, 197, 42.9 }, r));
            players.Add(new Player("Ḿavwápŕi Pimh ", "Sagua", 3, 1, 6, 4, 9, 10, 9, 6, 7, 7, 7, 6, 22, 27, 32, 6, " University of Autolik", new double[] { 55.6, 734, 497, 195, 34.9 }, r));
            players.Add(new Player("Nukunaix Hjetohje ", "Blaist Blaland", 3, 9, 8, 4, 10, 8, 1, 1, 3, 7, 8, 7, 20, 29, 33, 5, " University of Vrelinku", new double[] { 52, 713, 404, 194, 54.3 }, r));
            players.Add(new Player("Olandi Amodetsei ", "Dotruga", 3, 5, 2, 8, 1, 8, 7, 7, 8, 8, 10, 5, 19, 27, 33, 7, " Stedro Institute of Technology", new double[] { 54.1, 519, 374, 191, 30.9 }, r));
            players.Add(new Player("Om Jae-Wook ", "Shmupland", 3, 2, 9, 4, 2, 8, 7, 8, 5, 5, 10, 10, 19, 32, 34, 4, " University of Nomvas", new double[] { 52.8, 555, 507, 237, 32.7 }, r));
            players.Add(new Player("Randy Feltman", "Ethanthova", 3, 10, 3, 5, 2, 9, 7, 5, 5, 3, 10, 7, 22, 32, 35, 6, " Stedro Institute of Technology", new double[] { 46.8, 136, 83, 49, 41.3 }, r));
            players.Add(new Player("Sol Young-Chul ", "Shmupland", 3, 8, 10, 6, 9, 6, 5, 4, 1, 10, 7, 10, 22, 29, 33, 6, " University of Shmupland 4", new double[] { 62.9, 572, 229, 118, 45.5 }, r));
            players.Add(new Player("Ulatrusiei Hisei ", "Dotruga", 3, 3, 6, 4, 9, 1, 7, 5, 3, 9, 8, 8, 23, 27, 30, 5, " University of Venasul", new double[] { 57.8, 1012, 59, 200, 39.7 }, r));
            players.Add(new Player("Váqáp Qlámipanońqo ", "Sagua", 3, 1, 10, 7, 7, 9, 8, 6, 3, 1, 10, 5, 20, 27, 32, 9, " University of Aahrus 1", new double[] { 42.3, 140, 64, 43, 31.8 }, r));
            players.Add(new Player("Ydar Jeem ", "Bongatar", 3, 6, 3, 2, 6, 4, 2, 1, 4, 9, 9, 5, 21, 32, 34, 4, " University of Bongatar 1", new double[] { 61.3, 898, 187, 149, 50 }, r));
            players.Add(new Player("Alumobei Hialerko ", "Dotruga", 4, 8, 4, 7, 6, 4, 1, 1, 2, 4, 5, 7, 22, 30, 33, 5, " University of Hkamnsi", new double[] { 44.5, 625, 174, 168, 50.4 }, r));
            players.Add(new Player("Alundi Bituna ", "Dotruga", 4, 10, 3, 4, 6, 5, 2, 5, 3, 6, 9, 9, 23, 29, 34, 6, " Esmal District University", new double[] { 43.8, 926, 243, 234, 52.1 }, r));
            players.Add(new Player("Ametsuchi Hideki ", "Aeridani", 4, 7, 2, 5, 6, 3, 6, 4, 2, 5, 4, 7, 21, 27, 31, 3, " University of Lveinta", new double[] { 46.5, 776, 149, 197, 43.3 }, r));
            players.Add(new Player("Charles Alday", "Ethanthova", 4, 8, 4, 3, 1, 7, 6, 4, 2, 1, 5, 6, 20, 27, 32, 4, " University of Prokax", new double[] { 34.5, 367, 547, 239, 47.2 }, r));
            players.Add(new Player("Danomobei Hiemeta ", "Dotruga", 4, 9, 1, 8, 2, 5, 2, 2, 3, 7, 9, 8, 22, 30, 33, 7, " University of Soniara", new double[] { 51.4, 565, 210, 166, 45.6 }, r));
            players.Add(new Player("Handa Seiki ", "Transhimalia", 4, 5, 3, 6, 4, 7, 7, 9, 1, 4, 8, 9, 22, 30, 36, 1, " University of Nja", new double[] { 46.8, 832, 459, 223, 34.7 }, r));
            players.Add(new Player("Havika Phothisarath ", "Lyintaria", 4, 3, 4, 4, 4, 6, 5, 7, 2, 5, 2, 9, 24, 31, 32, 3, " University of Pentadominion 1", new double[] { 47.9, 683, 442, 195, 42.2 }, r));
            players.Add(new Player("Himiba Olalomundi ", "Dotruga", 4, 10, 2, 8, 5, 3, 8, 5, 3, 3, 1, 8, 19, 32, 33, 5, " University of Aavana", new double[] { 40.3, 921, 168, 268, 45 }, r));
            players.Add(new Player("Iklo Eloalerko ", "Dotruga", 4, 9, 4, 9, 8, 5, 8, 8, 6, 9, 5, 9, 19, 28, 33, 6, " University of Shmupland 4", new double[] { 58.2, 1016, 258, 224, 34 }, r));
            players.Add(new Player("Ingo Wagenseil ", "TND", 4, 7, 2, 6, 7, 4, 7, 4, 1, 8, 1, 5, 20, 31, 32, 7, " University of Blanaxon", new double[] { 58.2, 990, 205, 181, 47.2 }, r));
            players.Add(new Player("Jeff Bellow", "Ethanthova", 4, 6, 3, 5, 5, 7, 2, 6, 4, 6, 4, 5, 19, 28, 34, 6, " University of Aahrus 2", new double[] { 49.6, 737, 307, 193, 40.3 }, r));
            players.Add(new Player("Kimo Rattanavongsa ", "Bielosia", 4, 10, 1, 4, 3, 4, 9, 1, 3, 4, 4, 9, 21, 28, 31, 3, " University of Biodry", new double[] { 44.1, 624, 168, 150, 50.7 }, r));
            players.Add(new Player("Leilani Thammavong ", "Pyxanovia", 4, 9, 3, 5, 3, 4, 10, 5, 2, 1, 1, 7, 22, 27, 31, 6, " University of Aahrus 1", new double[] { 39.3, 333, 171, 164, 44.6 }, r));
            players.Add(new Player("Milton Solorzano", "Ethanthova", 4, 7, 1, 5, 5, 2, 3, 6, 4, 3, 9, 6, 23, 29, 35, 8, " University of Protopolis", new double[] { 39.9, 621, 112, 229, 44.7 }, r));
            players.Add(new Player("Ńà Nhòà ", "Pentadominion", 4, 9, 3, 2, 1, 3, 7, 5, 1, 4, 3, 10, 24, 31, 34, 6, " University of Barsein", new double[] { 43.4, 529, 135, 153, 45.1 }, r));
            players.Add(new Player("Pakomha Nánpa ", "Key to Don", 4, 6, 2, 7, 6, 6, 5, 5, 3, 6, 3, 9, 22, 29, 34, 9, " Stedro Institute of Technology", new double[] { 53.8, 694, 176, 140, 42.9 }, r));
            players.Add(new Player("Rael Ssekien ", "Barsein", 4, 8, 3, 5, 5, 3, 8, 5, 4, 5, 8, 10, 20, 31, 35, 10, " University of Nomvas", new double[] { 49.6, 726, 121, 164, 45 }, r));
            players.Add(new Player("Timblejoorany  ", "Aiyota", 4, 1, 1, 2, 3, 5, 2, 5, 2, 3, 9, 6, 21, 31, 35, 7, " University of Arinis", new double[] { 48.7, 467, 204, 133, 43.1 }, r));
            players.Add(new Player("Uwe Bischoff ", "TND", 4, 8, 4, 4, 3, 4, 4, 9, 2, 9, 7, 9, 23, 29, 34, 4, " University of Tri_National_Dominion 2", new double[] { 56.4, 932, 205, 177, 39.8 }, r));
            players.Add(new Player("Wahlady", "Aiyota", 4, 3, 3, 7, 6, 5, 5, 7, 4, 6, 10, 7, 21, 27, 30, 4, " University of Kaeshar 4", new double[] { 48.9, 989, 258, 222, 41.8 }, r));
            players.Add(new Player("Weer  ", "Aiyota", 4, 3, 3, 7, 7, 7, 3, 2, 1, 5, 5, 7, 22, 27, 30, 7, " University of Vincent", new double[] { 49.8, 800, 383, 185, 50.5 }, r));
            players.Add(new Player("Xai Alodetsei ", "Dotruga", 4, 8, 4, 6, 4, 3, 4, 2, 4, 9, 9, 9, 22, 29, 35, 4, " University of Sande Sitei", new double[] { 59.8, 1124, 142, 211, 50.2 }, r));
            players.Add(new Player("Yamataka Hiroaki ", "Transhimalia", 4, 7, 2, 6, 5, 5, 5, 8, 4, 5, 4, 8, 22, 27, 30, 3, " University of Noxium", new double[] { 42.9, 747, 265, 244, 38.1 }, r));
            players.Add(new Player("Yuguchi Izo ", "Transhimalia", 4, 8, 4, 8, 4, 6, 3, 5, 1, 3, 10, 7, 24, 31, 34, 1, " University of Vrelinku", new double[] { 46.1, 437, 190, 152, 45.5 }, r));
            players.Add(new Player("Alotru Fevioka ", "Dotruga", 5, 4, 5, 7, 6, 8, 2, 6, 4, 2, 1, 8, 22, 32, 35, 7, " University of Byisotia", new double[] { 42, 839, 511, 247, 44 }, r));
            players.Add(new Player("Blaki Dazaxka ", "Blaist Blaland", 5, 3, 1, 4, 5, 7, 3, 3, 4, 10, 7, 8, 21, 29, 33, 6, " University of Dongua", new double[] { 50.5, 800, 424, 219, 45.4 }, r));
            players.Add(new Player("Calvin Hayhurst", "Ethanthova", 5, 4, 2, 5, 6, 9, 6, 4, 4, 2, 2, 7, 21, 30, 36, 9, " University of University of Central Paradaniton", new double[] { 39.3, 616, 488, 227, 43.7 }, r));
            players.Add(new Player("Hannes Kluck ", "TND", 5, 6, 1, 3, 3, 8, 5, 4, 1, 2, 7, 7, 20, 29, 32, 3, " University of Atapwa", new double[] { 37.9, 229, 420, 143, 44.5 }, r));
            players.Add(new Player("Hvanne Shunmyo ", "Barsein", 5, 7, 4, 5, 2, 7, 3, 5, 1, 3, 7, 8, 20, 28, 34, 6, " University of Biodry", new double[] { 36.4, 234, 398, 145, 47.6 }, r));
            players.Add(new Player("Kawata Hakuseki ", "Transhimalia", 5, 5, 1, 7, 4, 8, 2, 3, 4, 2, 10, 6, 19, 30, 35, 3, " University of Sozaxon", new double[] { 41.4, 640, 440, 243, 49.5 }, r));
            players.Add(new Player("Kiromibakeili Tute ", "Dotruga", 5, 4, 1, 6, 5, 5, 8, 6, 2, 2, 9, 10, 22, 28, 32, 6, " University of Klanaxon", new double[] { 41, 644, 340, 201, 36.5 }, r));
            players.Add(new Player("Kompasu Toshiyuki ", "Aeridani", 5, 3, 4, 5, 3, 10, 6, 2, 4, 7, 3, 5, 19, 30, 35, 4, " University of Kaeshar 4", new double[] { 46.9, 500, 451, 153, 49.7 }, r));
            players.Add(new Player("Kye Genevong ", "Bielosia", 5, 5, 2, 4, 2, 4, 5, 8, 1, 3, 4, 9, 23, 29, 35, 7, " University of Kaeshar 5", new double[] { 37.4, 373, 418, 292, 38.4 }, r));
            players.Add(new Player("Làto Cows ", "Darvincia", 5, 4, 9, 8, 10, 10, 9, 7, 1, 9, 8, 10, 22, 27, 32, 5, " University of Issamore", new double[] { 62, 822, 513, 183, 37.3 }, r));
            players.Add(new Player("lu  ", "Norkute", 5, 7, 3, 5, 6, 4, 5, 3, 2, 4, 5, 10, 21, 28, 31, 2, " University of Levikeana Solvae", new double[] { 40.6, 612, 385, 249, 44.4 }, r));
            players.Add(new Player("Mack Cesar", "Ethanthova", 5, 5, 4, 6, 4, 6, 8, 7, 1, 3, 6, 10, 20, 29, 35, 7, " University of Svitharia", new double[] { 41.9, 627, 406, 213, 39.1 }, r));
            players.Add(new Player("Nho'ja Vanho ", "Key to Don", 5, 4, 1, 7, 6, 8, 5, 3, 1, 3, 3, 10, 19, 28, 31, 5, " University of Nausicaa", new double[] { 48.3, 760, 412, 170, 49 }, r));
            players.Add(new Player("Nuux Naxix ", "Blaist Blaland", 5, 6, 4, 3, 5, 9, 2, 5, 2, 6, 9, 10, 23, 32, 33, 6, " University of Hinaika Oceanography Institute", new double[] { 48.8, 624, 514, 223, 39.8 }, r));
            players.Add(new Player("Stephen Chapman", "Wyverncliff", 5, 8, 1, 5, 3, 6, 3, 5, 2, 7, 6, 8, 22, 28, 32, 5, " University of Pokoj", new double[] { 52.2, 642, 359, 130, 37.6 }, r));
            players.Add(new Player("Tugano Bexosek ", "Dotruga", 5, 2, 1, 7, 3, 8, 3, 8, 3, 1, 2, 8, 22, 32, 34, 4, " Atresmi University", new double[] { 47.2, 628, 236, 160, 39.3 }, r));
            players.Add(new Player("Tusaro Elolapo ", "Dotruga", 5, 3, 1, 6, 4, 5, 8, 4, 3, 2, 10, 10, 22, 28, 34, 5, " University of Pxalit'k'a", new double[] { 44, 447, 252, 152, 42.9 }, r));
            players.Add(new Player("Uxku Toxium ", "Blaist Blaland", 5, 4, 2, 4, 6, 7, 7, 5, 1, 2, 6, 9, 23, 32, 35, 4, " University of Aahrus 2", new double[] { 46.7, 390, 435, 173, 44.6 }, r));
            players.Add(new Player("Warren Radcliffe", "Ethanthova", 5, 6, 8, 1, 1, 5, 5, 4, 1, 7, 9, 8, 21, 31, 33, 5, " University of Tri_National_Dominion 2", new double[] { 54.8, 502, 373, 142, 40.3 }, r));
            players.Add(new Player("Watsuji Sumiteru ", "Barsein", 5, 2, 1, 5, 4, 3, 1, 4, 3, 4, 6, 10, 23, 32, 36, 6, " University of Kholka", new double[] { 47.7, 610, 99, 128, 43.5 }, r));



        }

        public Player GetPlayer(int currList, int i, bool scouted = false)
        {
            if (playersLeft == 0 && scouted) return null;
            if (scouted) playersLeft--;
            return playersByPos[currList][i];
        }
    }
}
