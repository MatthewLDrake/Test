﻿using System;

public class StringUtils
{
    public StringUtils()
    {
    }
    public static String rightPad(String teamName, int i)
    {
        if (teamName.Length >= i) return teamName;
        for (int j = teamName.Length; j < i; j++)
        {
            teamName = teamName + " ";
        }


        return teamName;
    }
    public static Country GetCountryFromString(String str)
    {
        switch(str)
        {
            case "Aiyota":
                return Country.Aiyota;
            case "Bielosia":
                return Country.Bielosia;
            case "Dotruga":
                return Country.Dotruga;
            case "Transhimalia":
                return Country.Transhimalia;
            case "Auspikitan":
                return Country.Auspikitan;
            case "Aeridani":
                return Country.Aeridani;
            case "Wyverncliff":
                return Country.Wyverncliff;
            case "Loviniosa":
                return Country.Loviniosa;
            case "Solea":
                return Country.Solea;
            case "Tri_National_Dominion":
                return Country.Tri_National_Dominion;
            case "Blaist_Blaland":
                return Country.Blaist_Blaland;
            case "Red_Rainbow":
                return Country.Red_Rainbow;
            case "Sagua":
                return Country.Sagua;
            case "Darvincia":
                return Country.Darvincia;
            case "Pyxanovia":
                return Country.Pyxanovia;
            case "Shmupland":
                return Country.Shmupland;
            case "Ethanthova":
                return Country.Ethanthova;
            case "Aahrus":
                return Country.Aahrus;
            case "Barsein":
                return Country.Barsein;
            case "Oesa":
                return Country.Oesa;
            case "Lyintaria":
                return Country.Lyintaria;
            case "Nausicaa":
                return Country.Nausicaa;
            case "Height_Sagua":
                return Country.Height_Sagua;
            case "Holykol":
                return Country.Holykol;
            case "Bongatar":
                return Country.Bongatar;
            case "Czalliso":
                return Country.Czalliso;
            case "Key_to_Don":
                return Country.Key_to_Don;
            case "Dtersauuw_Sagua":
                return Country.Dtersauuw_Sagua;
            case "Holy_Yektonisa":
                return Country.Holy_Yektonisa;
            case "Hinaika":
                return Country.Hinaika;
            case "Pqalik":
                return Country.Pqalik;
            case "Kareng":
                return Country.Kareng;
            case "Kolauk":
                return Country.Kolauk;
            case "Eksola":
                return Country.Eksola;
            case "Aitessek":
                return Country.Aitessek;
            case "Eqkirium":
                return Country.Eqkirium;
            case "Aovensiiv":
                return Country.Aovensiiv;
            case "Ipal":
                return Country.Ipal;
            case "Keich":
                return Country.Keich;
            case "Teralm":
                return Country.Teralm;
            case "Lemos":
                return Country.Lemos;
            case "Timbalta":
                return Country.Timbalta;
            case "Elvine":
                return Country.Elvine;
            case "Tjedigar":
                return Country.Tjedigar;
            case "Helvaena":
                return Country.Helvaena;
            case "Pentadominion":
                return Country.Pentadominion;
            case "Norkute":
                return Country.Norkute;
            case "Futiakep":
                return Country.Futiakep;
            case "Atapwa":
                return Country.Atapwa;
            case "Antarion":
                return Country.Antarion;
            case "Nja":
                return Country.Nja;
            case "Kaeshar":
                return Country.Kaeshar;
            default:
                return Country.Other;
        }
    }
}