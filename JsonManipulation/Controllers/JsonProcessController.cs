using JsonManipulation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JsonManipulation.Controllers
{
    public class JsonProcessController : Controller
    {
        public IActionResult Index()
        {
            var table = JsonValueType();
            return View(table);
        }

        public List<ParsedValue> JsonValueType()
        {
            string json = @"{
    ""id"": 12345,
    ""name"": ""John Doe"",
    ""isActive"": true,
    ""balance"": 2500.75,
    ""dateOfBirth"": ""1993-07-16"",
    ""lastLogin"": ""2024-12-19T14:30:00Z"",
    ""preferences"": {
        ""theme"": ""dark"",
        ""notifications"": true,
        ""language"": ""en""
    },
    ""scores"": [98, 85, 76, 91],
    ""grades"": [
        {
            ""subject"": ""Math"",
            ""score"": 95.5,
            ""date"": ""2024-11-15""
        }
    ],
    ""metaData"": null,
    ""binaryData"": ""SGVsbG8gV29ybGQ="",
    ""address"": {
        ""street"": ""123 Main St"",
        ""city"": ""New York"",
        ""zipCode"": ""10001"",
        ""coordinates"": {
            ""latitude"": 40.712776,
            ""longitude"": -74.005974
        }
    },
    ""tags"": [""developer"", ""engineer"", ""coder""],
    ""rating"": 4.7,
    ""customLevels"": [
        {
            ""type"": ""level"",
            ""hierarchy"": ""Category"",
            ""level"": ""Beginner""
        }
    ],
    ""isHidden"": false,
    ""status"": ""Active"",
    ""uniqueId"": ""550e8400-e29b-41d4-a716-446655440000"",
    ""settings"": {
        ""volume"": 80,
        ""brightness"": 50
    },
    ""time"": ""14:30:00"",
    ""nestedArray"": [[1, 2], [3, 4]]
}";

            // Parse JSON
            var root = JsonSerializer.Deserialize<Root>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Prepare table data
            // Ek veri tiplerini tabloya dahil et
            var tableData = new List<ParsedValue>();

            // ID
            var idValue = new ParsedValue
            {
                Value = root.Id.ToString(),
                Type = "int: " + root.Id.GetType(),
                AutoParse = true
            };
            tableData.Add(idValue);

            // Name
            var nameValue = new ParsedValue
            {
                Value = root.Name,
                Type = "string: " + root.Name.GetType(),
                AutoParse = true
            };
            tableData.Add(nameValue);

            // IsActive
            var isActiveValue = new ParsedValue
            {
                Value = root.IsActive.ToString(),
                Type = "boolean: " + root.IsActive.GetType(),
                AutoParse = true
            };
            tableData.Add(isActiveValue);

            // Balance
            var balanceValue = new ParsedValue
            {
                Value = root.Balance.ToString(),
                Type = "double: " + root.Balance.GetType(),
                AutoParse = true
            };
            tableData.Add(balanceValue);

            // DateOfBirth
            var dateOfBirthValue = new ParsedValue
            {
                Value = root.DateOfBirth.ToString("yyyy-MM-dd"),
                Type = "Date: " + root.DateOfBirth.GetType(),
                AutoParse = true
            };
            tableData.Add(dateOfBirthValue);

            // LastLogin
            var lastLoginValue = new ParsedValue
            {
                Value = root.LastLogin.ToString("o"),
                Type = "DateTime: " + root.LastLogin.GetType(),
                AutoParse = true
            };
            tableData.Add(lastLoginValue);

            // MetaData
            var metaDataValue = new ParsedValue
            {
                Value = root.MetaData?.ToString() ?? "null",
                Type = "null: " + (root.MetaData?.GetType()?.ToString() ?? "null"),
                AutoParse = true
            };
            tableData.Add(metaDataValue);

            // Tags
            var tagsValue = new ParsedValue
            {
                Value = string.Join(", ", root.Tags),
                Type = "array: " + root.Tags.GetType(),
                AutoParse = true
            };
            tableData.Add(tagsValue);

            // BinaryData
            var binaryDataValue = new ParsedValue
            {
                Value = root.BinaryData,
                Type = "Base64: " + root.BinaryData.GetType(),
                AutoParse = false
            };
            tableData.Add(binaryDataValue);

            // Status
            var statusValue = new ParsedValue
            {
                Value = root.Status,
                Type = "Enum: " + root.Status.GetType(),
                AutoParse = true
            };
            tableData.Add(statusValue);

            // UniqueId
            var uniqueIdValue = new ParsedValue
            {
                Value = root.UniqueId,
                Type = "GUID: " + root.UniqueId.GetType(),
                AutoParse = false
            };
            tableData.Add(uniqueIdValue);

            // Settings
            var settingsValue = new ParsedValue
            {
                Value = $"Volume: {root.Settings.Volume}, Brightness: {root.Settings.Brightness}",
                Type = "Dictionary: " + root.Settings.GetType(),
                AutoParse = false
            };
            tableData.Add(settingsValue);

            // Time
            var timeValue = new ParsedValue
            {
                Value = root.Time,
                Type = "Time: " + root.Time.GetType(),
                AutoParse = false
            };
            tableData.Add(timeValue);

            // NestedArray
            var nestedArrayValue = new ParsedValue
            {
                Value = string.Join("; ", root.NestedArray.Select(arr => string.Join(", ", arr))),
                Type = "NestedArray: " + root.NestedArray.GetType(),
                AutoParse = false
            };
            tableData.Add(nestedArrayValue);


            return tableData;
        }
    }
}
