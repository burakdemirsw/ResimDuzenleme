﻿using System;

namespace ResimDuzenleme
{
    public static class StaticFunctions
    {
        public static Uri ToServisUri(this string Alan_Adi, string Path)
        {
            string adres_format = "https://{0}/Servis/{1}.svc";
            return new Uri(string.Format(adres_format, Alan_Adi, Path));
        }
    }
}
