using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.Xml;

namespace JsonManipulation.Models
{
    public class JsonModel
    {
    }
    public class Root
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public double Balance { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastLogin { get; set; }
        public Preferences Preferences { get; set; }
        public List<int> Scores { get; set; }
        public List<Grade> Grades { get; set; }
        public object MetaData { get; set; }
        public string BinaryData { get; set; }
        public Address Address { get; set; }
        public List<string> Tags { get; set; }
        public double Rating { get; set; }
        public List<CustomLevel> CustomLevels { get; set; }
        public bool IsHidden { get; set; }
        public string Status { get; set; } // Enum represented as string
        public string UniqueId { get; set; } // GUID represented as string
        public Settings Settings { get; set; }
        public string Time { get; set; } // Time represented as string
        public List<List<int>> NestedArray { get; set; } // Nested Arrays
    }
    public class Preferences
    {
        public string Theme { get; set; }
        public bool Notifications { get; set; }
        public string Language { get; set; }
    }
    public class Grade
    {
        public string Subject { get; set; }
        public double Score { get; set; }
        public DateTime Date { get; set; }
    }
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Coordinates Coordinates { get; set; }
    }
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class CustomLevel
    {
        public string Type { get; set; }
        public string Hierarchy { get; set; }
        public string Level { get; set; }
    }
    public class Settings
    {
        public int Volume { get; set; }
        public int Brightness { get; set; }
    }
    public class ParsedValue
    {
        public string Value { get; set; }
        public string Type { get; set; }
        public bool AutoParse { get; set; }
    }

}
