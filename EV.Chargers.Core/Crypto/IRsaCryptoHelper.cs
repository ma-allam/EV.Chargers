﻿namespace EV.Chargers.Core.Crypto
{
    public interface IRsaCryptoHelper
    {
        string Encrypt(string text);
        string Decrypt(string encrypted);
    }
}
