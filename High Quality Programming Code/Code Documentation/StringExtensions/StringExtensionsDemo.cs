// -----------------------------------------------------------------------
// <copyright file="StringExtensionsDemo.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
// -

using System;
using System.Text;
using Telerik.ILS.Common;

/// <summary>
/// StringExtensions demo 
/// </summary>
internal class StringExtensionsDemo
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    private static void Main()
    {
        string value1 = "Telerik Academy";
        Console.WriteLine(value1.ToMd5Hash());
    }
}