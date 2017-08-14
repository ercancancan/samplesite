using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// bu yardımcıların olduğu sınıf static olmak zorunda
/// <summary>
/// Summary description for StringHelper
/// </summary>
public static class StringHelper
{
    public static string TrimText(this string text, int newLength)
    {
        // bu metnin 0'ncı karakterinden başla, eğer metinin uzunluğu
        // benim göderdiğim uzunlukltan kısa değilse, kısalt. 
        return text.Substring(0, Math.Min(text.Length, newLength));
    }

    public static string TrimDescription(this string text, int newLength)
    {
        while (text.IndexOf(' ') > -1 && text.Length > newLength)
        {
            text = text.Substring(0, text.LastIndexOf(" "));
        }
        return text;

    }
    //public static string yazTarım(this string yazıtext)
    //{
    //    int sayı = yazıtext.Length;
        
    //    if (sayı > 50 )
    //    {
            
    //    }







        //public static string TrimTextFromSpace(this string text, int newLength)
        //{
        //    while (text.IndexOf(' ') > -1 && text.Length > newLength)
        //    {
        //        text = text.Substring(0, text.LastIndexOf(" "));
        //    }
        //    return text;
        //}
        //public static string a(this string text, int newLength)
        //{
        //    if(text.IndexOf(' ') > -1 && text.Length > newLength)
        //    {
        //        text = text.Substring(0, text.LastIndexOf(" "));
        //    }
        //    else
        //    {
        //        text = text.Substring(0, text.Length);
        //    }
        //}
        //public StringHelper()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}

        //public StringHelper(string p)
        //{
        //    // TODO: Complete member initialization
        //    this.p = p;
        //}
        //public void TrimDescription(string description)
        //{
        //    if (true)
        //    {
        //        description.Substring(0, 25);
        //    }
        // else
        //    {
        //        description.Substring(24);
        //    }


        //}
    }
