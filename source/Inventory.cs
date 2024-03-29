﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using MTG_App;
//
//    var myInventory = MyInventory.FromJson(jsonString);

namespace MTG_App
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MyInventory
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("tcg_low")]
        public string TcgLow { get; set; }

        [JsonProperty("tcg_mid")]
        public string TcgMid { get; set; }

        [JsonProperty("purchase_link")]
        public Uri PurchaseLink { get; set; }

        [JsonProperty("foil_price")]
        public object FoilPrice { get; set; }

        [JsonProperty("price_change")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long PriceChange { get; set; }

        [JsonProperty("mc")]
        public string Mc { get; set; }

        [JsonProperty("main_type")]
        public string MainType { get; set; }

        [JsonProperty("colors")]
        public string Colors { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Mid { get; set; }

        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("set")]
        public string Set { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("types")]
        public string Types { get; set; }

        [JsonProperty("set_code")]
        public string SetCode { get; set; }

        [JsonProperty("expansion")]
        public string Expansion { get; set; }

        [JsonProperty("reserve_list")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ReserveList { get; set; }

        [JsonProperty("emid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Emid { get; set; }

        [JsonProperty("inventory_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long InventoryId { get; set; }

        [JsonProperty("note_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NoteId { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("date_acquired")]
        public string DateAcquired { get; set; }

        [JsonProperty("foil")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Foil { get; set; }

        [JsonProperty("price_acquired")]
        public string PriceAcquired { get; set; }

        [JsonProperty("current_price")]
        public string CurrentPrice { get; set; }

        [JsonProperty("personal_gain")]
        public string PersonalGain { get; set; }

        [JsonProperty("set_image")]
        public Uri SetImage { get; set; }

        [JsonProperty("image_cropped")]
        public Uri ImageCropped { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("gain")]
        public string Gain { get; set; }

        [JsonProperty("echo_set_url")]
        public Uri EchoSetUrl { get; set; }

        [JsonProperty("echo_url")]
        public Uri EchoUrl { get; set; }

        [JsonProperty("percentage_html")]
        public string PercentageHtml { get; set; }

        [JsonProperty("market_percentage_html")]
        public string MarketPercentageHtml { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("scalar")]
        public string Scalar { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("items_per_page")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ItemsPerPage { get; set; }

        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("filter_color")]
        public bool FilterColor { get; set; }

        [JsonProperty("filter_type")]
        public bool FilterType { get; set; }

        [JsonProperty("filter_search")]
        public bool FilterSearch { get; set; }

        [JsonProperty("filter_set")]
        public bool FilterSet { get; set; }

        [JsonProperty("blue")]
        public Black Blue { get; set; }

        [JsonProperty("red")]
        public Black Red { get; set; }

        [JsonProperty("white")]
        public Black White { get; set; }

        [JsonProperty("black")]
        public Black Black { get; set; }

        [JsonProperty("green")]
        public Black Green { get; set; }

        [JsonProperty("land")]
        public Black Land { get; set; }

        [JsonProperty("multicolor")]
        public Black Multicolor { get; set; }

        [JsonProperty("colorless")]
        public Black Colorless { get; set; }
    }

    public partial class Black
    {
        [JsonProperty("scalar")]
        public string Scalar { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }

    public partial class MyInventory
    {
        public static MyInventory FromJson(string json) => JsonConvert.DeserializeObject<MyInventory>(json, MTG_App.Converter.Settings);
    }
}
